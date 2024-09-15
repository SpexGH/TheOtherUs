using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using AmongUs.GameOptions;
using BepInEx;
using BepInEx.Configuration;
using BepInEx.Unity.IL2CPP;
using Hazel;
using Reactor.Utilities.Extensions;
using TheOtherRoles.Utilities;
using UnityEngine;
using static TheOtherRoles.Modules.CustomOption;
using static TheOtherRoles.TheOtherRoles;

namespace TheOtherRoles.Modules;

public class CustomOption
{
    public enum CustomOptionType
    {
        General,
        Impostor,
        Neutral,
        Crewmate,
        Modifier,
        Guesser,
        HideNSeekMain,
        HideNSeekRoles,
        PropHunt,
    }

    public static List<CustomOption> options = new();
    public static int preset;
    public static ConfigEntry<string> vanillaSettings;

    public int id;
    public string name;
    public object[] selections;

    public int defaultSelection;
    public ConfigEntry<int> entry;
    public int selection;
    public OptionBehaviour optionBehaviour;
    public CustomOption parent;
    public bool isHeader;
    public CustomOptionType type;
    public Action onChange;

    // Option creation

    public CustomOption(int id, CustomOptionType type, string name, object[] selections, object defaultValue, CustomOption parent, bool isHeader, Action onChange = null)
    {
        this.id = id;
        this.name = parent == null ? name : "- " + name;
        this.selections = selections;
        int index = Array.IndexOf(selections, defaultValue);
        defaultSelection = index >= 0 ? index : 0;
        this.parent = parent;
        this.isHeader = isHeader;
        this.type = type;
        this.onChange = onChange;
        selection = 0;
        if (id != 0)
        {
            entry = Main.Instance.Config.Bind($"Preset{preset}", id.ToString(), defaultSelection);
            selection = Mathf.Clamp(entry.Value, 0, selections.Length - 1);
        }
        options.Add(this);
    }

    public static CustomOption Create(int id, CustomOptionType type, string name, string[] selections, CustomOption parent = null, bool isHeader = false, Action onChange = null)
    {
        return new CustomOption(id, type, name, selections, "", parent, isHeader, onChange);
    }

    public static CustomOption Create(int id, CustomOptionType type, string name, float defaultValue, float min, float max, float step, CustomOption parent = null, bool isHeader = false, Action onChange = null)
    {
        List<object> selections = new();
        for (float s = min; s <= max; s += step)
            selections.Add(s);
        return new CustomOption(id, type, name, selections.ToArray(), defaultValue, parent, isHeader, onChange);
    }

    public static CustomOption Create(int id, CustomOptionType type, string name, bool defaultValue, CustomOption parent = null, bool isHeader = false, Action onChange = null)
    {
        return new CustomOption(id, type, name, new string[] { "Off", "On" }, defaultValue ? "On" : "Off", parent, isHeader, onChange);
    }

    // Static behaviour

    public static void switchPreset(int newPreset)
    {
        saveVanillaOptions();
        preset = newPreset;
        vanillaSettings = Main.Instance.Config.Bind($"Preset{preset}", "GameOptions", "");
        loadVanillaOptions();
        foreach (CustomOption option in options)
        {
            if (option.id == 0) continue;

            option.entry = Main.Instance.Config.Bind($"Preset{preset}", option.id.ToString(), option.defaultSelection);
            option.selection = Mathf.Clamp(option.entry.Value, 0, option.selections.Length - 1);
            if (option.optionBehaviour != null && option.optionBehaviour is StringOption stringOption)
            {
                stringOption.oldValue = stringOption.Value = option.selection;
                stringOption.ValueText.text = option.selections[option.selection].ToString();
            }
        }
    }

    public static void saveVanillaOptions()
    {
        vanillaSettings.Value = Convert.ToBase64String(GameOptionsManager.Instance.gameOptionsFactory.ToBytes(GameManager.Instance.LogicOptions.currentGameOptions, false));
    }

    public static void loadVanillaOptions()
    {
        string optionsString = vanillaSettings.Value;
        if (optionsString == "") return;
        GameOptionsManager.Instance.GameHostOptions = GameOptionsManager.Instance.gameOptionsFactory.FromBytes(Convert.FromBase64String(optionsString));
        GameOptionsManager.Instance.CurrentGameOptions = GameOptionsManager.Instance.GameHostOptions;
        GameManager.Instance.LogicOptions.SetGameOptions(GameOptionsManager.Instance.CurrentGameOptions);
        GameManager.Instance.LogicOptions.SyncOptions();
    }

    public static void ShareOptionChange(uint optionId)
    {
        var option = options.FirstOrDefault(x => x.id == optionId);
        if (option == null) return;
        var writer = AmongUsClient.Instance!.StartRpcImmediately(CachedPlayer.LocalPlayer.PlayerControl.NetId, (byte)CustomRPC.ShareOptions, SendOption.Reliable, -1);
        writer.Write((byte)1);
        writer.WritePacked((uint)option.id);
        writer.WritePacked(Convert.ToUInt32(option.selection));
        AmongUsClient.Instance.FinishRpcImmediately(writer);
    }

    public static void ShareOptionSelections()
    {
        if (CachedPlayer.AllPlayers.Count <= 1 || AmongUsClient.Instance!.AmHost == false && CachedPlayer.LocalPlayer.PlayerControl == null) return;
        var optionsList = new List<CustomOption>(options);
        while (optionsList.Any())
        {
            byte amount = (byte)Math.Min(optionsList.Count, 200); // takes less than 3 bytes per option on average
            var writer = AmongUsClient.Instance!.StartRpcImmediately(CachedPlayer.LocalPlayer.PlayerControl.NetId, (byte)CustomRPC.ShareOptions, SendOption.Reliable, -1);
            writer.Write(amount);
            for (int i = 0; i < amount; i++)
            {
                var option = optionsList[0];
                optionsList.RemoveAt(0);
                writer.WritePacked((uint)option.id);
                writer.WritePacked(Convert.ToUInt32(option.selection));
            }
            AmongUsClient.Instance.FinishRpcImmediately(writer);
        }
    }

    // Getter

    public int getSelection()
    {
        return selection;
    }

    public bool getBool()
    {
        return selection > 0;
    }

    public float getFloat()
    {
        return (float)selections[selection];
    }

    public int getQuantity()
    {
        return selection + 1;
    }

    // Option changes

    public void updateSelection(int newSelection)
    {
        selection = Mathf.Clamp((newSelection + selections.Length) % selections.Length, 0, selections.Length - 1);
        try
        {
            if (onChange != null) onChange();
        }
        catch { }
        if (optionBehaviour != null && optionBehaviour is StringOption stringOption)
        {
            stringOption.oldValue = stringOption.Value = selection;
            stringOption.ValueText.text = selections[selection].ToString();
            if (AmongUsClient.Instance?.AmHost == true && CachedPlayer.LocalPlayer.PlayerControl)
            {
                if (id == 0 && selection != preset)
                {
                    switchPreset(selection); // Switch presets
                    ShareOptionSelections();
                }
                else if (entry != null)
                {
                    entry.Value = selection; // Save selection to config
                    ShareOptionChange((uint)id);// Share single selection
                }
            }
        }
        else if (id == 0 && AmongUsClient.Instance?.AmHost == true && PlayerControl.LocalPlayer)
        {  // Share the preset switch for random maps, even if the menu isnt open!
            switchPreset(selection);
            ShareOptionSelections();// Share all selections
        }

    }

    public static byte[] serializeOptions()
    {
        using (MemoryStream memoryStream = new())
        {
            using (BinaryWriter binaryWriter = new(memoryStream))
            {
                int lastId = -1;
                foreach (var option in options.OrderBy(x => x.id))
                {
                    if (option.id == 0) continue;
                    bool consecutive = lastId + 1 == option.id;
                    lastId = option.id;

                    binaryWriter.Write((byte)(option.selection + (consecutive ? 128 : 0)));
                    if (!consecutive) binaryWriter.Write((ushort)option.id);
                }
                binaryWriter.Flush();
                memoryStream.Position = 0L;
                return memoryStream.ToArray();
            }
        }
    }

    public static void deserializeOptions(byte[] inputValues)
    {
        BinaryReader reader = new(new MemoryStream(inputValues));
        int lastId = -1;
        while (reader.BaseStream.Position < inputValues.Length)
        {
            try
            {
                int selection = reader.ReadByte();
                int id = -1;
                bool consecutive = selection >= 128;
                if (consecutive)
                {
                    selection -= 128;
                    id = lastId + 1;
                }
                else
                {
                    id = reader.ReadUInt16();
                }
                if (id == 0) continue;
                lastId = id;
                CustomOption option = options.First(option => option.id == id);
                option.updateSelection(selection);
            }
            catch (Exception e)
            {
                Warn($"{e}: while deserializing - tried to paste invalid settings!");
            }
        }
    }

    // Copy to or paste from clipboard (as string)
    public static void copyToClipboard()
    {
        GUIUtility.systemCopyBuffer = $"{Main.VersionString}!{Convert.ToBase64String(serializeOptions())}!{vanillaSettings.Value}";
    }

    public static bool pasteFromClipboard()
    {
        string allSettings = GUIUtility.systemCopyBuffer;
        try
        {
            var settingsSplit = allSettings.Split("!");
            string versionInfo = settingsSplit[0];
            string torSettings = settingsSplit[1];
            string vanillaSettingsSub = settingsSplit[2];
            deserializeOptions(Convert.FromBase64String(torSettings));

            vanillaSettings.Value = vanillaSettingsSub;
            loadVanillaOptions();
            return true;
        }
        catch (Exception e)
        {
            Warn($"{e}: tried to paste invalid settings!");
            SoundEffectsManager.Load();
            SoundEffectsManager.play("fail");
            return false;
        }
    }
}

[HarmonyPatch(typeof(GameOptionsMenu), nameof(GameOptionsMenu.Start))]
class GameOptionsMenuStartPatch
{
    public static void Postfix(GameOptionsMenu __instance)
    {

        switch (TORMapOptions.gameMode)
        {
            case CustomGamemodes.Classic:
                createClassicTabs(__instance);
                break;
            case CustomGamemodes.Guesser:
                createGuesserTabs(__instance);
                break;
            case CustomGamemodes.HideNSeek:
                createHideNSeekTabs(__instance);
                break;
            case CustomGamemodes.PropHunt:
                createPropHuntTabs(__instance);
                break;
        }

        // create copy to clipboard and paste from clipboard buttons.
        var template = GameObject.Find("CloseButton");
        var copyButton = UnityEngine.Object.Instantiate(template, template.transform.parent);
        copyButton.transform.localPosition += Vector3.down * 0.8f;
        var copyButtonPassive = copyButton.GetComponent<PassiveButton>();
        var copyButtonRenderer = copyButton.GetComponent<SpriteRenderer>();
        copyButtonRenderer.sprite = loadSpriteFromResources("TheOtherRoles.Resources.CopyButton.png", 175f);
        copyButtonPassive.OnClick.RemoveAllListeners();
        copyButtonPassive.OnClick = new UnityEngine.UI.Button.ButtonClickedEvent();
        copyButtonPassive.OnClick.AddListener((Action)(() =>
        {
            copyToClipboard();
            copyButtonRenderer.color = Color.green;
            __instance.StartCoroutine(Effects.Lerp(1f, new Action<float>((p) =>
            {
                if (p > 0.95)
                    copyButtonRenderer.color = Color.white;
            })));
        }));
        var pasteButton = UnityEngine.Object.Instantiate(template, template.transform.parent);
        pasteButton.transform.localPosition += Vector3.down * 1.6f;
        var pasteButtonPassive = pasteButton.GetComponent<PassiveButton>();
        var pasteButtonRenderer = pasteButton.GetComponent<SpriteRenderer>();
        pasteButtonRenderer.sprite = loadSpriteFromResources("TheOtherRoles.Resources.PasteButton.png", 175f);
        pasteButtonPassive.OnClick.RemoveAllListeners();
        pasteButtonPassive.OnClick = new UnityEngine.UI.Button.ButtonClickedEvent();
        pasteButtonPassive.OnClick.AddListener((Action)(() =>
        {
            pasteButtonRenderer.color = Color.yellow;
            bool success = pasteFromClipboard();
            pasteButtonRenderer.color = success ? Color.green : Color.red;
            __instance.StartCoroutine(Effects.Lerp(1f, new Action<float>((p) =>
            {
                if (p > 0.95)
                    pasteButtonRenderer.color = Color.white;
            })));
        }));

    }

    private static void createClassicTabs(GameOptionsMenu __instance)
    {
        bool isReturn = setNames(
            new Dictionary<string, string>()
            {
                ["TORSettings"] = "The Other Us Settings",
                ["ImpostorSettings"] = "Impostor Roles Settings",
                ["NeutralSettings"] = "Neutral Roles Settings",
                ["CrewmateSettings"] = "Crewmate Roles Settings",
                ["ModifierSettings"] = "Modifier Settings"
            });

        if (isReturn) return;

        // Setup TOR tab
        var template = UnityEngine.Object.FindObjectsOfType<StringOption>().FirstOrDefault();
        if (template == null) return;
        var gameSettings = GameObject.Find("Game Settings");
        var gameSettingMenu = UnityEngine.Object.FindObjectsOfType<GameSettingMenu>().FirstOrDefault();

        var torSettings = UnityEngine.Object.Instantiate(gameSettings, gameSettings.transform.parent);
        var torMenu = getMenu(torSettings, "TORSettings");

        var impostorSettings = UnityEngine.Object.Instantiate(gameSettings, gameSettings.transform.parent);
        var impostorMenu = getMenu(impostorSettings, "ImpostorSettings");

        var neutralSettings = UnityEngine.Object.Instantiate(gameSettings, gameSettings.transform.parent);
        var neutralMenu = getMenu(neutralSettings, "NeutralSettings");

        var crewmateSettings = UnityEngine.Object.Instantiate(gameSettings, gameSettings.transform.parent);
        var crewmateMenu = getMenu(crewmateSettings, "CrewmateSettings");

        var modifierSettings = UnityEngine.Object.Instantiate(gameSettings, gameSettings.transform.parent);
        var modifierMenu = getMenu(modifierSettings, "ModifierSettings");

        var roleTab = GameObject.Find("RoleTab");
        var gameTab = GameObject.Find("GameTab");

        var torTab = UnityEngine.Object.Instantiate(roleTab, roleTab.transform.parent);
        var torTabHighlight = getTabHighlight(torTab, "TheOtherRolesTab", "TheOtherRoles.Resources.TabIcon.png");

        var impostorTab = UnityEngine.Object.Instantiate(roleTab, torTab.transform);
        var impostorTabHighlight = getTabHighlight(impostorTab, "ImpostorTab", "TheOtherRoles.Resources.TabIconImpostor.png");

        var neutralTab = UnityEngine.Object.Instantiate(roleTab, impostorTab.transform);
        var neutralTabHighlight = getTabHighlight(neutralTab, "NeutralTab", "TheOtherRoles.Resources.TabIconNeutral.png");

        var crewmateTab = UnityEngine.Object.Instantiate(roleTab, neutralTab.transform);
        var crewmateTabHighlight = getTabHighlight(crewmateTab, "CrewmateTab", "TheOtherRoles.Resources.TabIconCrewmate.png");

        var modifierTab = UnityEngine.Object.Instantiate(roleTab, crewmateTab.transform);
        var modifierTabHighlight = getTabHighlight(modifierTab, "ModifierTab", "TheOtherRoles.Resources.TabIconModifier.png");

        // Position of Tab Icons
        gameTab.transform.position += Vector3.left * 3f;
        roleTab.transform.position += Vector3.left * 3f;
        torTab.transform.position += Vector3.left * 2f;
        impostorTab.transform.localPosition = Vector3.right * 1f;
        neutralTab.transform.localPosition = Vector3.right * 1f;
        crewmateTab.transform.localPosition = Vector3.right * 1f;
        modifierTab.transform.localPosition = Vector3.right * 1f;

        var tabs = new GameObject[] { gameTab, roleTab, torTab, impostorTab, neutralTab, crewmateTab, modifierTab };
        var settingsHighlightMap = new Dictionary<GameObject, SpriteRenderer>
        {
            [gameSettingMenu.RegularGameSettings] = gameSettingMenu.GameSettingsHightlight,
            [gameSettingMenu.RolesSettings.gameObject] = gameSettingMenu.RolesSettingsHightlight,
            [torSettings.gameObject] = torTabHighlight,
            [impostorSettings.gameObject] = impostorTabHighlight,
            [neutralSettings.gameObject] = neutralTabHighlight,
            [crewmateSettings.gameObject] = crewmateTabHighlight,
            [modifierSettings.gameObject] = modifierTabHighlight
        };
        for (int i = 0; i < tabs.Length; i++)
        {
            var button = tabs[i].GetComponentInChildren<PassiveButton>();
            if (button == null) continue;
            int copiedIndex = i;
            button.OnClick = new UnityEngine.UI.Button.ButtonClickedEvent();
            button.OnClick.AddListener((Action)(() =>
            {
                setListener(settingsHighlightMap, copiedIndex);
            }));
        }

        destroyOptions(new List<List<OptionBehaviour>>{
            torMenu.GetComponentsInChildren<OptionBehaviour>().ToList(),
            impostorMenu.GetComponentsInChildren<OptionBehaviour>().ToList(),
            neutralMenu.GetComponentsInChildren<OptionBehaviour>().ToList(),
            crewmateMenu.GetComponentsInChildren<OptionBehaviour>().ToList(),
            modifierMenu.GetComponentsInChildren<OptionBehaviour>().ToList()
        });

        List<OptionBehaviour> torOptions = new();
        List<OptionBehaviour> impostorOptions = new();
        List<OptionBehaviour> neutralOptions = new();
        List<OptionBehaviour> crewmateOptions = new();
        List<OptionBehaviour> modifierOptions = new();


        List<Transform> menus = new() { torMenu.transform, impostorMenu.transform, neutralMenu.transform, crewmateMenu.transform, modifierMenu.transform };
        List<List<OptionBehaviour>> optionBehaviours = new() { torOptions, impostorOptions, neutralOptions, crewmateOptions, modifierOptions };

        for (int i = 0; i < options.Count; i++)
        {
            CustomOption option = options[i];
            if ((int)option.type > 4) continue;
            if (option.optionBehaviour == null)
            {
                StringOption stringOption = UnityEngine.Object.Instantiate(template, menus[(int)option.type]);
                optionBehaviours[(int)option.type].Add(stringOption);
                stringOption.OnValueChanged = new Action<OptionBehaviour>((o) => { });
                stringOption.TitleText.text = option.name;
                stringOption.Value = stringOption.oldValue = option.selection;
                stringOption.ValueText.text = option.selections[option.selection].ToString();

                option.optionBehaviour = stringOption;
            }
            option.optionBehaviour.gameObject.SetActive(true);
        }

        setOptions(
            new List<GameOptionsMenu> { torMenu, impostorMenu, neutralMenu, crewmateMenu, modifierMenu },
            new List<List<OptionBehaviour>> { torOptions, impostorOptions, neutralOptions, crewmateOptions, modifierOptions },
            new List<GameObject> { torSettings, impostorSettings, neutralSettings, crewmateSettings, modifierSettings }
        );

        adaptTaskCount(__instance);
    }

    private static void createGuesserTabs(GameOptionsMenu __instance)
    {
        bool isReturn = setNames(
            new Dictionary<string, string>()
            {
                ["TORSettings"] = "The Other Us Settings",
                ["GuesserSettings"] = "Guesser Mode Settings",
                ["ImpostorSettings"] = "Impostor Roles Settings",
                ["NeutralSettings"] = "Neutral Roles Settings",
                ["CrewmateSettings"] = "Crewmate Roles Settings",
                ["ModifierSettings"] = "Modifier Settings"
            });

        if (isReturn) return;

        // Setup TOR tab
        var template = UnityEngine.Object.FindObjectsOfType<StringOption>().FirstOrDefault();
        if (template == null) return;
        var gameSettings = GameObject.Find("Game Settings");
        var gameSettingMenu = UnityEngine.Object.FindObjectsOfType<GameSettingMenu>().FirstOrDefault();

        var torSettings = UnityEngine.Object.Instantiate(gameSettings, gameSettings.transform.parent);
        var torMenu = getMenu(torSettings, "TORSettings");

        var guesserSettings = UnityEngine.Object.Instantiate(gameSettings, gameSettings.transform.parent);
        var guesserMenu = getMenu(guesserSettings, "GuesserSettings");

        var impostorSettings = UnityEngine.Object.Instantiate(gameSettings, gameSettings.transform.parent);
        var impostorMenu = getMenu(impostorSettings, "ImpostorSettings");

        var neutralSettings = UnityEngine.Object.Instantiate(gameSettings, gameSettings.transform.parent);
        var neutralMenu = getMenu(neutralSettings, "NeutralSettings");

        var crewmateSettings = UnityEngine.Object.Instantiate(gameSettings, gameSettings.transform.parent);
        var crewmateMenu = getMenu(crewmateSettings, "CrewmateSettings");

        var modifierSettings = UnityEngine.Object.Instantiate(gameSettings, gameSettings.transform.parent);
        var modifierMenu = getMenu(modifierSettings, "ModifierSettings");

        var roleTab = GameObject.Find("RoleTab");
        var gameTab = GameObject.Find("GameTab");

        var torTab = UnityEngine.Object.Instantiate(roleTab, gameTab.transform.parent);
        var torTabHighlight = getTabHighlight(torTab, "TheOtherRolesTab", "TheOtherRoles.Resources.TabIcon.png");

        var guesserTab = UnityEngine.Object.Instantiate(roleTab, torTab.transform);
        var guesserTabHighlight = getTabHighlight(guesserTab, "GuesserTab", "TheOtherRoles.Resources.TabIconGuesserSettings.png");

        var impostorTab = UnityEngine.Object.Instantiate(roleTab, guesserTab.transform);
        var impostorTabHighlight = getTabHighlight(impostorTab, "ImpostorTab", "TheOtherRoles.Resources.TabIconImpostor.png");

        var neutralTab = UnityEngine.Object.Instantiate(roleTab, impostorTab.transform);
        var neutralTabHighlight = getTabHighlight(neutralTab, "NeutralTab", "TheOtherRoles.Resources.TabIconNeutral.png");

        var crewmateTab = UnityEngine.Object.Instantiate(roleTab, neutralTab.transform);
        var crewmateTabHighlight = getTabHighlight(crewmateTab, "CrewmateTab", "TheOtherRoles.Resources.TabIconCrewmate.png");

        var modifierTab = UnityEngine.Object.Instantiate(roleTab, crewmateTab.transform);
        var modifierTabHighlight = getTabHighlight(modifierTab, "ModifierTab", "TheOtherRoles.Resources.TabIconModifier.png");

        roleTab.active = false;
        // Position of Tab Icons
        gameTab.transform.position += Vector3.left * 3f;
        torTab.transform.position += Vector3.left * 3f;
        guesserTab.transform.localPosition = Vector3.right * 1f;
        impostorTab.transform.localPosition = Vector3.right * 1f;
        neutralTab.transform.localPosition = Vector3.right * 1f;
        crewmateTab.transform.localPosition = Vector3.right * 1f;
        modifierTab.transform.localPosition = Vector3.right * 1f;

        var tabs = new GameObject[] { gameTab, torTab, impostorTab, neutralTab, crewmateTab, modifierTab, guesserTab };
        var settingsHighlightMap = new Dictionary<GameObject, SpriteRenderer>
        {
            [gameSettingMenu.RegularGameSettings] = gameSettingMenu.GameSettingsHightlight,
            [torSettings.gameObject] = torTabHighlight,
            [impostorSettings.gameObject] = impostorTabHighlight,
            [neutralSettings.gameObject] = neutralTabHighlight,
            [crewmateSettings.gameObject] = crewmateTabHighlight,
            [modifierSettings.gameObject] = modifierTabHighlight,
            [guesserSettings.gameObject] = guesserTabHighlight
        };
        for (int i = 0; i < tabs.Length; i++)
        {
            var button = tabs[i].GetComponentInChildren<PassiveButton>();
            if (button == null) continue;
            int copiedIndex = i;
            button.OnClick = new UnityEngine.UI.Button.ButtonClickedEvent();
            button.OnClick.AddListener((Action)(() =>
            {
                setListener(settingsHighlightMap, copiedIndex);
            }));
        }

        destroyOptions(new List<List<OptionBehaviour>>{
            torMenu.GetComponentsInChildren<OptionBehaviour>().ToList(),
            guesserMenu.GetComponentsInChildren<OptionBehaviour>().ToList(),
            impostorMenu.GetComponentsInChildren<OptionBehaviour>().ToList(),
            neutralMenu.GetComponentsInChildren<OptionBehaviour>().ToList(),
            crewmateMenu.GetComponentsInChildren<OptionBehaviour>().ToList(),
            modifierMenu.GetComponentsInChildren<OptionBehaviour>().ToList()
        });

        List<OptionBehaviour> torOptions = new();
        List<OptionBehaviour> guesserOptions = new();
        List<OptionBehaviour> impostorOptions = new();
        List<OptionBehaviour> neutralOptions = new();
        List<OptionBehaviour> crewmateOptions = new();
        List<OptionBehaviour> modifierOptions = new();


        List<Transform> menus = new() { torMenu.transform, impostorMenu.transform, neutralMenu.transform, crewmateMenu.transform, modifierMenu.transform, guesserMenu.transform };
        List<List<OptionBehaviour>> optionBehaviours = new() { torOptions, impostorOptions, neutralOptions, crewmateOptions, modifierOptions, guesserOptions };
        List<int> exludedIds = new() { 10000, 10001, 10002, 10003, 10004, 10005, 10006, 10007, 10008, 30100, 30101, 30102, 30103, 30104 };

        for (int i = 0; i < options.Count; i++)
        {
            CustomOption option = options[i];
            if (exludedIds.Contains(option.id)) continue;
            if ((int)option.type > 5) continue;
            if (option.optionBehaviour == null)
            {
                StringOption stringOption = UnityEngine.Object.Instantiate(template, menus[(int)option.type]);
                optionBehaviours[(int)option.type].Add(stringOption);
                stringOption.OnValueChanged = new Action<OptionBehaviour>((o) => { });
                stringOption.TitleText.text = option.name;
                stringOption.Value = stringOption.oldValue = option.selection;
                stringOption.ValueText.text = option.selections[option.selection].ToString();

                option.optionBehaviour = stringOption;
            }
            option.optionBehaviour.gameObject.SetActive(true);
        }

        setOptions(
            new List<GameOptionsMenu> { torMenu, impostorMenu, neutralMenu, crewmateMenu, modifierMenu, guesserMenu },
            new List<List<OptionBehaviour>> { torOptions, impostorOptions, neutralOptions, crewmateOptions, modifierOptions, guesserOptions },
            new List<GameObject> { torSettings, impostorSettings, neutralSettings, crewmateSettings, modifierSettings, guesserSettings }
        );

        adaptTaskCount(__instance);
    }

    private static void createHideNSeekTabs(GameOptionsMenu __instance)
    {
        bool isReturn = setNames(
            new Dictionary<string, string>()
            {
                ["TORSettings"] = "The Other Us Settings",
                ["HideNSeekSettings"] = "Hide 'N Seek Settings"
            });

        if (isReturn) return;

        // Setup TOR tab
        var template = UnityEngine.Object.FindObjectsOfType<StringOption>().FirstOrDefault();
        if (template == null) return;
        var gameSettings = GameObject.Find("Game Settings");
        var gameSettingMenu = UnityEngine.Object.FindObjectsOfType<GameSettingMenu>().FirstOrDefault();

        var torSettings = UnityEngine.Object.Instantiate(gameSettings, gameSettings.transform.parent);
        var torMenu = getMenu(torSettings, "TORSettings");

        var hideNSeekSettings = UnityEngine.Object.Instantiate(gameSettings, gameSettings.transform.parent);
        var hideNSeekMenu = getMenu(hideNSeekSettings, "HideNSeekSettings");

        var roleTab = GameObject.Find("RoleTab");
        var gameTab = GameObject.Find("GameTab");

        var torTab = UnityEngine.Object.Instantiate(roleTab, gameTab.transform.parent);
        var torTabHighlight = getTabHighlight(torTab, "TheOtherRolesTab", "TheOtherRoles.Resources.TabIconHideNSeekSettings.png");

        var hideNSeekTab = UnityEngine.Object.Instantiate(roleTab, torTab.transform);
        var hideNSeekTabHighlight = getTabHighlight(hideNSeekTab, "HideNSeekTab", "TheOtherRoles.Resources.TabIconHideNSeekRoles.png");

        roleTab.active = false;
        gameTab.active = false;

        // Position of Tab Icons
        torTab.transform.position += Vector3.left * 3f;
        hideNSeekTab.transform.position += Vector3.right * 1f;

        var tabs = new GameObject[] { torTab, hideNSeekTab };
        var settingsHighlightMap = new Dictionary<GameObject, SpriteRenderer>
        {
            [torSettings.gameObject] = torTabHighlight,
            [hideNSeekSettings.gameObject] = hideNSeekTabHighlight
        };
        for (int i = 0; i < tabs.Length; i++)
        {
            var button = tabs[i].GetComponentInChildren<PassiveButton>();
            if (button == null) continue;
            int copiedIndex = i;
            button.OnClick = new UnityEngine.UI.Button.ButtonClickedEvent();
            button.OnClick.AddListener((Action)(() =>
            {
                setListener(settingsHighlightMap, copiedIndex);
            }));
        }

        destroyOptions(new List<List<OptionBehaviour>>{
            torMenu.GetComponentsInChildren<OptionBehaviour>().ToList(),
            hideNSeekMenu.GetComponentsInChildren<OptionBehaviour>().ToList()
        });

        List<OptionBehaviour> torOptions = new();
        List<OptionBehaviour> hideNSeekOptions = new();

        List<Transform> menus = new() { torMenu.transform, hideNSeekMenu.transform };
        List<List<OptionBehaviour>> optionBehaviours = new() { torOptions, hideNSeekOptions };

        for (int i = 0; i < options.Count; i++)
        {
            CustomOption option = options[i];
            if (option.type != CustomOptionType.HideNSeekMain && option.type != CustomOptionType.HideNSeekRoles) continue;
            if (option.optionBehaviour == null)
            {
                int index = (int)option.type - 6;
                StringOption stringOption = UnityEngine.Object.Instantiate(template, menus[index]);
                optionBehaviours[index].Add(stringOption);
                stringOption.OnValueChanged = new Action<OptionBehaviour>((o) => { });
                stringOption.TitleText.text = option.name;
                stringOption.Value = stringOption.oldValue = option.selection;
                stringOption.ValueText.text = option.selections[option.selection].ToString();

                option.optionBehaviour = stringOption;
            }
            option.optionBehaviour.gameObject.SetActive(true);
        }

        setOptions(
            new List<GameOptionsMenu> { torMenu, hideNSeekMenu },
            new List<List<OptionBehaviour>> { torOptions, hideNSeekOptions },
            new List<GameObject> { torSettings, hideNSeekSettings }
        );

        torSettings.gameObject.SetActive(true);
        torTabHighlight.enabled = true;
        gameSettingMenu.RegularGameSettings.SetActive(false);
        gameSettingMenu.GameSettingsHightlight.enabled = false;
    }


    private static void createPropHuntTabs(GameOptionsMenu __instance)
    {
        bool isReturn = setNames(
            new Dictionary<string, string>()
            {
                ["TORSettings"] = "Prop Hunt Settings"
            });

        if (isReturn) return;

        // Setup TOR tab
        var template = UnityEngine.Object.FindObjectsOfType<StringOption>().FirstOrDefault();
        if (template == null) return;
        var gameSettings = GameObject.Find("Game Settings");
        var gameSettingMenu = UnityEngine.Object.FindObjectsOfType<GameSettingMenu>().FirstOrDefault();

        var torSettings = UnityEngine.Object.Instantiate(gameSettings, gameSettings.transform.parent);
        var torMenu = getMenu(torSettings, "TORSettings");
        var roleTab = GameObject.Find("RoleTab");
        var gameTab = GameObject.Find("GameTab");

        var torTab = UnityEngine.Object.Instantiate(roleTab, gameTab.transform.parent);
        var torTabHighlight = getTabHighlight(torTab, "TheOtherRolesTab", "TheOtherRoles.Resources.TabIconPropHuntSettings.png");

        roleTab.active = false;
        gameTab.active = false;

        // Position of Tab Icons
        torTab.transform.position += Vector3.left * 3f;

        var tabs = new GameObject[] { torTab };
        var settingsHighlightMap = new Dictionary<GameObject, SpriteRenderer>
        {
            [torSettings.gameObject] = torTabHighlight
        };
        for (int i = 0; i < tabs.Length; i++)
        {
            var button = tabs[i].GetComponentInChildren<PassiveButton>();
            if (button == null) continue;
            int copiedIndex = i;
            button.OnClick = new UnityEngine.UI.Button.ButtonClickedEvent();
            button.OnClick.AddListener((Action)(() =>
            {
                setListener(settingsHighlightMap, copiedIndex);
            }));
        }

        destroyOptions(new List<List<OptionBehaviour>>{
            torMenu.GetComponentsInChildren<OptionBehaviour>().ToList(),
        });

        List<OptionBehaviour> torOptions = new();

        List<Transform> menus = new() { torMenu.transform };
        List<List<OptionBehaviour>> optionBehaviours = new() { torOptions };

        for (int i = 0; i < options.Count; i++)
        {
            CustomOption option = options[i];
            if (option.type != CustomOptionType.PropHunt) continue;
            if (option.optionBehaviour == null)
            {
                int index = 0;
                StringOption stringOption = UnityEngine.Object.Instantiate(template, menus[index]);
                optionBehaviours[index].Add(stringOption);
                stringOption.OnValueChanged = new Action<OptionBehaviour>((o) => { });
                stringOption.TitleText.text = option.name;
                stringOption.Value = stringOption.oldValue = option.selection;
                stringOption.ValueText.text = option.selections[option.selection].ToString();

                option.optionBehaviour = stringOption;
            }
            option.optionBehaviour.gameObject.SetActive(true);
        }

        setOptions(
            new List<GameOptionsMenu> { torMenu },
            new List<List<OptionBehaviour>> { torOptions },
            new List<GameObject> { torSettings }
        );

        torSettings.gameObject.SetActive(true);
        torTabHighlight.enabled = true;
        gameSettingMenu.RegularGameSettings.SetActive(false);
        gameSettingMenu.GameSettingsHightlight.enabled = false;
    }

    private static void setListener(Dictionary<GameObject, SpriteRenderer> settingsHighlightMap, int index)
    {
        foreach (KeyValuePair<GameObject, SpriteRenderer> entry in settingsHighlightMap)
        {
            entry.Key.SetActive(false);
            entry.Value.enabled = false;
        }
        settingsHighlightMap.ElementAt(index).Key.SetActive(true);
        settingsHighlightMap.ElementAt(index).Value.enabled = true;
    }

    private static void destroyOptions(List<List<OptionBehaviour>> optionBehavioursList)
    {
        foreach (List<OptionBehaviour> optionBehaviours in optionBehavioursList)
        {
            foreach (OptionBehaviour option in optionBehaviours)
                UnityEngine.Object.Destroy(option.gameObject);
        }
    }

    private static bool setNames(Dictionary<string, string> gameObjectNameDisplayNameMap)
    {
        foreach (KeyValuePair<string, string> entry in gameObjectNameDisplayNameMap)
        {
            if (GameObject.Find(entry.Key) != null)
            { // Settings setup has already been performed, fixing the title of the tab and returning
                GameObject.Find(entry.Key).transform.FindChild("GameGroup").FindChild("Text").GetComponent<TMPro.TextMeshPro>().SetText(entry.Value);
                return true;
            }
        }

        return false;
    }

    private static GameOptionsMenu getMenu(GameObject setting, string settingName)
    {
        var menu = setting.transform.FindChild("GameGroup").FindChild("SliderInner").GetComponent<GameOptionsMenu>();
        setting.name = settingName;

        return menu;
    }

    private static SpriteRenderer getTabHighlight(GameObject tab, string tabName, string tabSpritePath)
    {
        var tabHighlight = tab.transform.FindChild("Hat Button").FindChild("Tab Background").GetComponent<SpriteRenderer>();
        tab.transform.FindChild("Hat Button").FindChild("Icon").GetComponent<SpriteRenderer>().sprite = loadSpriteFromResources(tabSpritePath, 100f);
        tab.name = "tabName";

        return tabHighlight;
    }

    private static void setOptions(List<GameOptionsMenu> menus, List<List<OptionBehaviour>> options, List<GameObject> settings)
    {
        if (!(menus.Count == options.Count && options.Count == settings.Count))
        {
            Error("List counts are not equal");
            return;
        }
        for (int i = 0; i < menus.Count; i++)
        {
            menus[i].Children = options[i].ToArray();
            settings[i].gameObject.SetActive(false);
        }
    }

    private static void adaptTaskCount(GameOptionsMenu __instance)
    {
        // Adapt task count for main options
        var commonTasksOption = __instance.Children.FirstOrDefault(x => x.name == "NumCommonTasks").TryCast<NumberOption>();
        if (commonTasksOption != null) commonTasksOption.ValidRange = new FloatRange(0f, 4f);

        var shortTasksOption = __instance.Children.FirstOrDefault(x => x.name == "NumShortTasks").TryCast<NumberOption>();
        if (shortTasksOption != null) shortTasksOption.ValidRange = new FloatRange(0f, 23f);

        var longTasksOption = __instance.Children.FirstOrDefault(x => x.name == "NumLongTasks").TryCast<NumberOption>();
        if (longTasksOption != null) longTasksOption.ValidRange = new FloatRange(0f, 15f);
    }
}

[HarmonyPatch(typeof(StringOption), nameof(StringOption.OnEnable))]
public class StringOptionEnablePatch
{
    public static bool Prefix(StringOption __instance)
    {
        CustomOption option = options.FirstOrDefault(option => option.optionBehaviour == __instance);
        if (option == null) return true;

        __instance.OnValueChanged = new Action<OptionBehaviour>((o) => { });
        __instance.TitleText.text = option.name;
        __instance.Value = __instance.oldValue = option.selection;
        __instance.ValueText.text = option.selections[option.selection].ToString();

        return false;
    }
}

[HarmonyPatch(typeof(StringOption), nameof(StringOption.Increase))]
public class StringOptionIncreasePatch
{
    public static bool Prefix(StringOption __instance)
    {
        CustomOption option = options.FirstOrDefault(option => option.optionBehaviour == __instance);
        if (option == null) return true;
        option.updateSelection(option.selection + 1);
        if (CustomOptionHolder.isMapSelectionOption(option))
        {
            IGameOptions currentGameOptions = GameOptionsManager.Instance.CurrentGameOptions;
            currentGameOptions.SetByte(ByteOptionNames.MapId, (byte)option.selection);
            GameOptionsManager.Instance.GameHostOptions = GameOptionsManager.Instance.CurrentGameOptions;
            GameManager.Instance.LogicOptions.SyncOptions();
        }
        return false;
    }
}

[HarmonyPatch(typeof(StringOption), nameof(StringOption.Decrease))]
public class StringOptionDecreasePatch
{
    public static bool Prefix(StringOption __instance)
    {
        CustomOption option = options.FirstOrDefault(option => option.optionBehaviour == __instance);
        if (option == null) return true;
        option.updateSelection(option.selection - 1);
        if (CustomOptionHolder.isMapSelectionOption(option))
        {
            IGameOptions currentGameOptions = GameOptionsManager.Instance.CurrentGameOptions;
            currentGameOptions.SetByte(ByteOptionNames.MapId, (byte)option.selection);
            GameOptionsManager.Instance.GameHostOptions = GameOptionsManager.Instance.CurrentGameOptions;
            GameManager.Instance.LogicOptions.SyncOptions();
        }
        return false;
    }
}

[HarmonyPatch(typeof(StringOption), nameof(StringOption.FixedUpdate))]
public class StringOptionFixedUpdate
{
    public static void Postfix(StringOption __instance)
    {
        if (!IL2CPPChainloader.Instance.Plugins.TryGetValue("com.DigiWorm.LevelImposter", out PluginInfo _)) return;
        CustomOption option = options.FirstOrDefault(option => option.optionBehaviour == __instance);
        if (option == null || !CustomOptionHolder.isMapSelectionOption(option)) return;
        if (GameOptionsManager.Instance.CurrentGameOptions.MapId == 6)
            if (option.optionBehaviour != null && option.optionBehaviour is StringOption stringOption)
            {
                stringOption.ValueText.text = option.selections[option.selection].ToString();
            }
            else if (option.optionBehaviour != null && option.optionBehaviour is StringOption stringOptionToo)
            {
                stringOptionToo.oldValue = stringOptionToo.Value = option.selection;
                stringOptionToo.ValueText.text = option.selections[option.selection].ToString();
            }
    }
}


[HarmonyPatch(typeof(PlayerControl), nameof(PlayerControl.RpcSyncSettings))]
public class RpcSyncSettingsPatch
{
    public static void Postfix()
    {
        ShareOptionSelections();
        saveVanillaOptions();
    }
}

[HarmonyPatch(typeof(PlayerPhysics), nameof(PlayerPhysics.CoSpawnPlayer))]
public class AmongUsClientOnPlayerJoinedPatch
{
    public static void Postfix()
    {
        if (PlayerControl.LocalPlayer != null && AmongUsClient.Instance.AmHost)
        {
            GameManager.Instance.LogicOptions.SyncOptions();
            ShareOptionSelections();
        }
    }
}


[HarmonyPatch(typeof(GameOptionsMenu), nameof(GameOptionsMenu.Update))]
class GameOptionsMenuUpdatePatch
{
    private static float timer = 1f;
    public static void Postfix(GameOptionsMenu __instance)
    {
        // Return Menu Update if in normal among us settings 
        var gameSettingMenu = UnityEngine.Object.FindObjectsOfType<GameSettingMenu>().FirstOrDefault();
        if (gameSettingMenu.RegularGameSettings.active || gameSettingMenu.RolesSettings.gameObject.active) return;

        __instance.GetComponentInParent<Scroller>().ContentYBounds.max = -0.5F + __instance.Children.Length * 0.55F;
        timer += Time.deltaTime;
        if (timer < 0.1f) return;
        timer = 0f;

        float offset = 2.75f;
        foreach (CustomOption option in options)
        {
            if (GameObject.Find("TORSettings") && option.type != CustomOptionType.General && option.type != CustomOptionType.HideNSeekMain && option.type != CustomOptionType.PropHunt)
                continue;
            if (GameObject.Find("ImpostorSettings") && option.type != CustomOptionType.Impostor)
                continue;
            if (GameObject.Find("NeutralSettings") && option.type != CustomOptionType.Neutral)
                continue;
            if (GameObject.Find("CrewmateSettings") && option.type != CustomOptionType.Crewmate)
                continue;
            if (GameObject.Find("ModifierSettings") && option.type != CustomOptionType.Modifier)
                continue;
            if (GameObject.Find("GuesserSettings") && option.type != CustomOptionType.Guesser)
                continue;
            if (GameObject.Find("HideNSeekSettings") && option.type != CustomOptionType.HideNSeekRoles)
                continue;
            if (option?.optionBehaviour != null && option.optionBehaviour.gameObject != null)
            {
                bool enabled = true;
                var parent = option.parent;
                while (parent != null && enabled)
                {
                    enabled = parent.selection != 0;
                    parent = parent.parent;
                }
                option.optionBehaviour.gameObject.SetActive(enabled);
                if (enabled)
                {
                    offset -= option.isHeader ? 0.75f : 0.5f;
                    option.optionBehaviour.transform.localPosition = new Vector3(option.optionBehaviour.transform.localPosition.x, offset, option.optionBehaviour.transform.localPosition.z);
                }
            }
        }
    }
}


[HarmonyPatch]
class GameOptionsDataPatch
{
    private static string buildRoleOptions()
    {
        var impRoles = "<size=150%><color=#ff1c1c>Impostors</color></size>" + buildOptionsOfType(CustomOptionType.Impostor, true) + "\n";
        var neutralRoles = "<size=150%><color=#50544c>Neutrals</color></size>" + buildOptionsOfType(CustomOptionType.Neutral, true) + "\n";
        var crewRoles = "<size=150%><color=#08fcfc>Crewmates</color></size>" + buildOptionsOfType(CustomOptionType.Crewmate, true) + "\n";
        var modifiers = "<size=150%><color=#ffec04>Modifiers</color></size>" + buildOptionsOfType(CustomOptionType.Modifier, true);
        return impRoles + neutralRoles + crewRoles + modifiers;
    }
    private static string buildModifierExtras(CustomOption customOption)
    {
        // find options children with quantity
        var children = options.Where(o => o.parent == customOption);
        var quantity = children.Where(o => o.name.Contains("Quantity")).ToList();
        if (customOption.getSelection() == 0) return "";
        if (quantity.Count == 1) return $" ({quantity[0].getQuantity()})";
        if (customOption == CustomOptionHolder.modifierLover)
        {
            return $" (1 Evil: {CustomOptionHolder.modifierLoverImpLoverRate.getSelection() * 10}%)";
        }
        return "";
    }

    private static string buildOptionsOfType(CustomOptionType type, bool headerOnly)
    {
        StringBuilder sb = new("\n");
        var options = CustomOption.options.Where(o => o.type == type);
        if (TORMapOptions.gameMode == CustomGamemodes.Guesser)
        {
            if (type == CustomOptionType.General)
                options = CustomOption.options.Where(o => o.type == type || o.type == CustomOptionType.Guesser);
            List<int> remove = new() { 10000, 10001, 10002, 10003, 10004, 10005, 10006, 10007, 10008, 30100, 30101, 30102, 30103, 30104 };
            options = options.Where(x => !remove.Contains(x.id));
        }
        else if (TORMapOptions.gameMode == CustomGamemodes.Classic)
            options = options.Where(x => !(x.type == CustomOptionType.Guesser));
        else if (TORMapOptions.gameMode == CustomGamemodes.HideNSeek)
            options = options.Where(x => x.type == CustomOptionType.HideNSeekMain || x.type == CustomOptionType.HideNSeekRoles);
        else if (TORMapOptions.gameMode == CustomGamemodes.PropHunt)
            options = options.Where(x => x.type == CustomOptionType.PropHunt);

        foreach (var option in options)
        {
            if (option.parent == null)
            {
                string line = $"{option.name}: {option.selections[option.selection].ToString()}";
                if (type == CustomOptionType.Modifier) line += buildModifierExtras(option);
                sb.AppendLine(line);
            }
            else if (option.parent.getSelection() > 0)
            {
                if (option.id == 30060) //Deputy
                    sb.AppendLine($"- {cs(Deputy.color, "Deputy")}: {option.selections[option.selection].ToString()}");
                else if (option.id == 20048) //Sidekick
                    sb.AppendLine($"- {cs(Sidekick.color, "Sidekick")}: {option.selections[option.selection].ToString()}");
                else if (option.id == 20071) //Prosecutor
                    sb.AppendLine($"- {cs(Lawyer.color, "Prosecutor")}: {option.selections[option.selection].ToString()}");
                else if (option.id == 20042) //Can Swoop
                    sb.AppendLine($"- {cs(Swooper.color, "Swooper")}: {option.selections[option.selection].ToString()}");

            }
        }
        if (headerOnly) return sb.ToString();
        else sb = new StringBuilder();

        foreach (CustomOption option in options)
        {
            if (TORMapOptions.gameMode == CustomGamemodes.HideNSeek && option.type != CustomOptionType.HideNSeekMain && option.type != CustomOptionType.HideNSeekRoles) continue;
            if (TORMapOptions.gameMode == CustomGamemodes.PropHunt && option.type != CustomOptionType.PropHunt) continue;
            if (option.parent != null)
            {
                bool isIrrelevant = option.parent.getSelection() == 0 || option.parent.parent != null && option.parent.parent.getSelection() == 0;

                Color c = isIrrelevant ? Color.grey : Color.white;  // No use for now
                if (isIrrelevant) continue;
                sb.AppendLine(cs(c, $"{option.name}: {option.selections[option.selection].ToString()}"));
            }
            else
            {
                if (option == CustomOptionHolder.neutralRolesCountMin)
                {
                    var optionName = CustomOptionHolder.cs(new Color32(204, 204, 0, 255), "Neutral Roles");
                    var min = CustomOptionHolder.neutralRolesCountMin.getSelection();
                    var max = CustomOptionHolder.neutralRolesCountMax.getSelection();
                    if (min > max) min = max;
                    var optionValue = min == max ? $"{max}" : $"{min} - {max}";
                    sb.AppendLine($"{optionName}: {optionValue}");
                }
                else if (option == CustomOptionHolder.modifiersCountMin)
                {
                    var optionName = CustomOptionHolder.cs(new Color32(204, 204, 0, 255), "Modifiers");
                    var min = CustomOptionHolder.modifiersCountMin.getSelection();
                    var max = CustomOptionHolder.modifiersCountMax.getSelection();
                    if (min > max) min = max;
                    var optionValue = min == max ? $"{max}" : $"{min} - {max}";
                    sb.AppendLine($"{optionName}: {optionValue}");
                }
                else if (option == CustomOptionHolder.neutralRolesCountMax || option == CustomOptionHolder.modifiersCountMax)
                {
                    continue;
                }
                else
                {
                    sb.AppendLine($"\n{option.name}: {option.selections[option.selection].ToString()}");
                }
            }
        }
        return sb.ToString();
    }


    public static int maxPage = 7;
    public static string buildAllOptions(string vanillaSettings = "", bool hideExtras = false)
    {
        if (vanillaSettings == "")
            vanillaSettings = GameOptionsManager.Instance.CurrentGameOptions.ToHudString(PlayerControl.AllPlayerControls.Count);
        int counter = Main.optionsPage;
        string hudString = counter != 0 && !hideExtras ? cs(DateTime.Now.Second % 2 == 0 ? Color.white : Color.red, "(Use scroll wheel if necessary)\n\n") : "";

        if (TORMapOptions.gameMode == CustomGamemodes.HideNSeek)
        {
            if (Main.optionsPage > 1) Main.optionsPage = 0;
            maxPage = 2;
            switch (counter)
            {
                case 0:
                    hudString += "Page 1: Hide N Seek Settings \n\n" + buildOptionsOfType(CustomOptionType.HideNSeekMain, false);
                    break;
                case 1:
                    hudString += "Page 2: Hide N Seek Role Settings \n\n" + buildOptionsOfType(CustomOptionType.HideNSeekRoles, false);
                    break;
            }
        }
        else if (TORMapOptions.gameMode == CustomGamemodes.PropHunt)
        {
            maxPage = 1;
            switch (counter)
            {
                case 0:
                    hudString += "Page 1: Prop Hunt Settings \n\n" + buildOptionsOfType(CustomOptionType.PropHunt, false);
                    break;
            }
        }
        else
        {
            maxPage = 7;
            switch (counter)
            {
                case 0:
                    hudString += (!hideExtras ? "" : "Page 1: Vanilla Settings \n\n") + vanillaSettings;
                    break;
                case 1:
                    hudString += "Page 2: The Other Us Settings \n" + buildOptionsOfType(CustomOptionType.General, false);
                    break;
                case 2:
                    hudString += "Page 3: Role and Modifier Rates \n" + buildRoleOptions();
                    break;
                case 3:
                    hudString += "Page 4: Impostor Role Settings \n" + buildOptionsOfType(CustomOptionType.Impostor, false);
                    break;
                case 4:
                    hudString += "Page 5: Neutral Role Settings \n" + buildOptionsOfType(CustomOptionType.Neutral, false);
                    break;
                case 5:
                    hudString += "Page 6: Crewmate Role Settings \n" + buildOptionsOfType(CustomOptionType.Crewmate, false);
                    break;
                case 6:
                    hudString += "Page 7: Modifier Settings \n" + buildOptionsOfType(CustomOptionType.Modifier, false);
                    break;
            }
        }

        if (!hideExtras || counter != 0) hudString += $"\n Press TAB or Page Number for more... ({counter + 1}/{maxPage})";
        return hudString;
    }


    [HarmonyPatch(typeof(IGameOptionsExtensions), nameof(IGameOptionsExtensions.ToHudString))]
    private static void Postfix(ref string __result)
    {
        if (GameOptionsManager.Instance.currentGameOptions.GameMode == GameModes.HideNSeek) return; // Allow Vanilla Hide N Seek
        __result = buildAllOptions(vanillaSettings: __result);
    }
}

[HarmonyPatch]
public class AddToKillDistanceSetting
{
    [HarmonyPatch(typeof(GameOptionsData), nameof(GameOptionsData.AreInvalid))]
    [HarmonyPrefix]

    public static bool Prefix(GameOptionsData __instance, ref int maxExpectedPlayers)
    {
        //making the killdistances bound check higher since extra short is added
        return __instance.MaxPlayers > maxExpectedPlayers || __instance.NumImpostors < 1
                || __instance.NumImpostors > 3 || __instance.KillDistance < 0
                || __instance.KillDistance >= GameOptionsData.KillDistances.Count
                || __instance.PlayerSpeedMod <= 0f || __instance.PlayerSpeedMod > 3f;
    }

    [HarmonyPatch(typeof(NormalGameOptionsV07), nameof(NormalGameOptionsV07.AreInvalid))]
    [HarmonyPrefix]

    public static bool Prefix(NormalGameOptionsV07 __instance, ref int maxExpectedPlayers)
    {
        return __instance.MaxPlayers > maxExpectedPlayers || __instance.NumImpostors < 1
                || __instance.NumImpostors > 3 || __instance.KillDistance < 0
                || __instance.KillDistance >= GameOptionsData.KillDistances.Count
                || __instance.PlayerSpeedMod <= 0f || __instance.PlayerSpeedMod > 3f;
    }

    [HarmonyPatch(typeof(StringOption), nameof(StringOption.OnEnable))]
    [HarmonyPrefix]

    public static void Prefix(StringOption __instance)
    {
        //prevents indexoutofrange exception breaking the setting if long happens to be selected
        //when host opens the laptop
        if (__instance.Title == StringNames.GameKillDistance && __instance.Value == 3)
        {
            __instance.Value = 1;
            GameOptionsManager.Instance.currentNormalGameOptions.KillDistance = 1;
            GameManager.Instance.LogicOptions.SyncOptions();
        }
    }

    [HarmonyPatch(typeof(StringOption), nameof(StringOption.OnEnable))]
    [HarmonyPostfix]

    public static void Postfix(StringOption __instance)
    {
        if (__instance.Title == StringNames.GameKillDistance && __instance.Values.Count == 3)
        {
            __instance.Values = new(
                    new StringNames[] { (StringNames)49999, StringNames.SettingShort, StringNames.SettingMedium, StringNames.SettingLong });
        }
    }

    [HarmonyPatch(typeof(IGameOptionsExtensions), nameof(IGameOptionsExtensions.AppendItem),
        [typeof(Il2CppSystem.Text.StringBuilder), typeof(StringNames), typeof(string)])]
    [HarmonyPrefix]

    public static void Prefix(ref StringNames stringName, ref string value)
    {
        if (stringName == StringNames.GameKillDistance)
        {
            int index;
            if (GameOptionsManager.Instance.currentGameMode == GameModes.Normal)
            {
                index = GameOptionsManager.Instance.currentNormalGameOptions.KillDistance;
            }
            else
            {
                index = GameOptionsManager.Instance.currentHideNSeekGameOptions.KillDistance;
            }
            value = GameOptionsData.KillDistanceStrings[index];
        }
    }

    [HarmonyPatch(typeof(TranslationController), nameof(TranslationController.GetString),
        new[] { typeof(StringNames), typeof(Il2CppReferenceArray<Il2CppSystem.Object>) })]
    [HarmonyPriority(Priority.Last)]

    public static bool Prefix(ref string __result, ref StringNames id)
    {
        if ((int)id == 49999)
        {
            __result = "Very Short";
            return false;
        }
        return true;
    }

    public static void addKillDistance()
    {
        GameOptionsData.KillDistances = new(new float[] { 0.5f, 1f, 1.8f, 2.5f });
        GameOptionsData.KillDistanceStrings = new(new string[] { "Very Short", "Short", "Medium", "Long" });
    }
}

[HarmonyPatch(typeof(KeyboardJoystick), nameof(KeyboardJoystick.Update))]
public static class GameOptionsNextPagePatch
{
    public static void Postfix(KeyboardJoystick __instance)
    {
        int page = Main.optionsPage;
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Main.optionsPage = (Main.optionsPage + 1) % 7;
        }
        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
        {
            Main.optionsPage = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
        {
            Main.optionsPage = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3))
        {
            Main.optionsPage = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Keypad4))
        {
            Main.optionsPage = 3;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5) || Input.GetKeyDown(KeyCode.Keypad5))
        {
            Main.optionsPage = 4;
        }
        if (Input.GetKeyDown(KeyCode.Alpha6) || Input.GetKeyDown(KeyCode.Keypad6))
        {
            Main.optionsPage = 5;
        }
        if (Input.GetKeyDown(KeyCode.Alpha7) || Input.GetKeyDown(KeyCode.Keypad7))
        {
            Main.optionsPage = 6;
        }
        if (Input.GetKeyDown(KeyCode.F1))
            HudManagerUpdate.ToggleSettings(HudManager.Instance);
        if (Main.optionsPage >= GameOptionsDataPatch.maxPage) Main.optionsPage = 0;

        if (page != Main.optionsPage)
        {
            Vector3 position = (Vector3)FastDestroyableSingleton<HudManager>.Instance?.GameSettings?.transform.localPosition;
            FastDestroyableSingleton<HudManager>.Instance.GameSettings.transform.localPosition = new Vector3(position.x, 2.9f, position.z);
        }
    }
}


[HarmonyPatch(typeof(HudManager), nameof(HudManager.Update))]
public class GameSettingsScalePatch
{
    public static void Prefix(HudManager __instance)
    {
        if (__instance.GameSettings != null) __instance.GameSettings.fontSize = 1.2f;
    }
}


// This class is taken and adapted from Town of Us Reactivated, https://github.com/eDonnes124/Town-Of-Us-R/blob/master/source/Patches/CustomOption/Patches.cs, Licensed under GPLv3
[HarmonyPatch(typeof(HudManager), nameof(HudManager.Update))]
public class HudManagerUpdate
{
    public static float
        MinX,/*-5.3F*/
        OriginalY = 2.9F,
        MinY = 2.9F;


    public static Scroller Scroller;
    private static Vector3 LastPosition;
    private static float lastAspect;
    private static bool setLastPosition;

    public static void Prefix(HudManager __instance)
    {
        if (__instance.GameSettings?.transform == null) return;

        // Sets the MinX position to the left edge of the screen + 0.1 units
        Rect safeArea = Screen.safeArea;
        float aspect = Mathf.Min(Camera.main.aspect, safeArea.width / safeArea.height);
        float safeOrthographicSize = CameraSafeArea.GetSafeOrthographicSize(Camera.main);
        MinX = 0.1f - safeOrthographicSize * aspect;

        if (!setLastPosition || aspect != lastAspect)
        {
            LastPosition = new Vector3(MinX, MinY);
            lastAspect = aspect;
            setLastPosition = true;
            if (Scroller != null) Scroller.ContentXBounds = new FloatRange(MinX, MinX);
        }

        CreateScroller(__instance);

        Scroller.gameObject.SetActive(__instance.GameSettings.gameObject.activeSelf);

        if (!Scroller.gameObject.active) return;

        var rows = __instance.GameSettings.text.Count(c => c == '\n');
        float LobbyTextRowHeight = 0.06F;
        var maxY = Mathf.Max(MinY, rows * LobbyTextRowHeight + (rows - 38) * LobbyTextRowHeight);

        Scroller.ContentYBounds = new FloatRange(MinY, maxY);

        // Prevent scrolling when the player is interacting with a menu
        if (CachedPlayer.LocalPlayer?.PlayerControl.CanMove != true)
        {
            __instance.GameSettings.transform.localPosition = LastPosition;

            return;
        }

        if (__instance.GameSettings.transform.localPosition.x != MinX ||
            __instance.GameSettings.transform.localPosition.y < MinY) return;

        LastPosition = __instance.GameSettings.transform.localPosition;
    }

    private static void CreateScroller(HudManager __instance)
    {
        if (Scroller != null) return;

        Transform target = __instance.GameSettings.transform;

        Scroller = new GameObject("SettingsScroller").AddComponent<Scroller>();
        Scroller.transform.SetParent(__instance.GameSettings.transform.parent);
        Scroller.gameObject.layer = 5;

        Scroller.transform.localScale = Vector3.one;
        Scroller.allowX = false;
        Scroller.allowY = true;
        Scroller.active = true;
        Scroller.velocity = new Vector2(0, 0);
        Scroller.ScrollbarYBounds = new FloatRange(0, 0);
        Scroller.ContentXBounds = new FloatRange(MinX, MinX);
        Scroller.enabled = true;

        Scroller.Inner = target;
        target.SetParent(Scroller.transform);
    }

    [HarmonyPrefix]
    public static void Prefix2(HudManager __instance)
    {
        if (!settingsTMPs[0]) return;
        foreach (var tmp in settingsTMPs) tmp.text = "";
        var settingsString = GameOptionsDataPatch.buildAllOptions(hideExtras: true);
        var blocks = settingsString.Split("\n\n", StringSplitOptions.RemoveEmptyEntries); ;
        string curString = "";
        string curBlock;
        int j = 0;
        for (int i = 0; i < blocks.Length; i++)
        {
            curBlock = blocks[i];
            if (lineCount(curBlock) + lineCount(curString) < 43)
            {
                curString += curBlock + "\n\n";
            }
            else
            {
                settingsTMPs[j].text = curString;
                j++;

                curString = "\n" + curBlock + "\n\n";
                if (curString.Substring(0, 2) != "\n\n") curString = "\n" + curString;
            }
        }
        if (j < settingsTMPs.Length) settingsTMPs[j].text = curString;
        int blockCount = 0;
        foreach (var tmp in settingsTMPs)
        {
            if (tmp.text != "")
                blockCount++;
        }
        for (int i = 0; i < blockCount; i++)
        {
            settingsTMPs[i].transform.localPosition = new Vector3(-blockCount * 1.2f + 2.7f * i, 2.2f, -500f);
        }
    }

    private static TMPro.TextMeshPro[] settingsTMPs = new TMPro.TextMeshPro[4];
    private static GameObject settingsBackground;
    public static void OpenSettings(HudManager __instance)
    {
        if (__instance.FullScreen == null || MapBehaviour.Instance && MapBehaviour.Instance.IsOpen
            /*|| AmongUsClient.Instance.GameState != InnerNet.InnerNetClient.GameStates.Started*/
            || GameOptionsManager.Instance.currentGameOptions.GameMode == GameModes.HideNSeek) return;
        settingsBackground = UnityEngine.Object.Instantiate(__instance.FullScreen.gameObject, __instance.transform);
        settingsBackground.SetActive(true);
        var renderer = settingsBackground.GetComponent<SpriteRenderer>();
        renderer.color = new Color(0.2f, 0.2f, 0.2f, 0.9f);
        renderer.enabled = true;

        for (int i = 0; i < settingsTMPs.Length; i++)
        {
            settingsTMPs[i] = UnityEngine.Object.Instantiate(__instance.KillButton.cooldownTimerText, __instance.transform);
            settingsTMPs[i].alignment = TMPro.TextAlignmentOptions.TopLeft;
            settingsTMPs[i].enableWordWrapping = false;
            settingsTMPs[i].transform.localScale = Vector3.one * 0.25f;
            settingsTMPs[i].gameObject.SetActive(true);
        }
    }

    public static void CloseSettings()
    {
        foreach (var tmp in settingsTMPs)
            if (tmp) tmp.gameObject.Destroy();

        if (settingsBackground) settingsBackground.Destroy();
    }

    public static void ToggleSettings(HudManager __instance)
    {
        if (settingsTMPs[0]) CloseSettings();
        else OpenSettings(__instance);
    }

    static PassiveButton toggleSettingsButton;
    static GameObject toggleSettingsButtonObject;
    [HarmonyPostfix]
    public static void Postfix(HudManager __instance)
    {
        if (!toggleSettingsButton || !toggleSettingsButtonObject)
        {
            // add a special button for settings viewing:
            toggleSettingsButtonObject = UnityEngine.Object.Instantiate(__instance.MapButton.gameObject, __instance.MapButton.transform.parent);
            toggleSettingsButtonObject.transform.localPosition = __instance.MapButton.transform.localPosition + new Vector3(0, -0.66f, -500f);
            SpriteRenderer renderer = toggleSettingsButtonObject.GetComponent<SpriteRenderer>();
            renderer.sprite = loadSpriteFromResources("TheOtherRoles.Resources.CurrentSettingsButton.png", 180f);
            toggleSettingsButton = toggleSettingsButtonObject.GetComponent<PassiveButton>();
            toggleSettingsButton.OnClick.RemoveAllListeners();
            toggleSettingsButton.OnClick.AddListener((Action)(() => ToggleSettings(__instance)));
        }
        toggleSettingsButtonObject.SetActive(__instance.MapButton.gameObject.active && !(MapBehaviour.Instance && MapBehaviour.Instance.IsOpen) && GameOptionsManager.Instance.currentGameOptions.GameMode != GameModes.HideNSeek);
        toggleSettingsButtonObject.transform.localPosition = __instance.MapButton.transform.localPosition + new Vector3(0, -0.66f, -500f);
    }
}
