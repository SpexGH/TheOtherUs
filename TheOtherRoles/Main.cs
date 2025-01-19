using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AmongUs.Data;
using BepInEx;
using BepInEx.Configuration;
using BepInEx.Unity.IL2CPP;
using Hazel;
using Reactor.Networking.Attributes;
using TheOtherRoles.Modules;
using TheOtherRoles.Modules.CustomHats;
using TheOtherRoles.Utilities;
using UnityEngine;

namespace TheOtherRoles;

[BepInPlugin(Id, ModName, VersionString)]
[BepInDependency(SubmergedCompatibility.SUBMERGED_GUID, BepInDependency.DependencyFlags.SoftDependency)]
[BepInProcess("Among Us.exe")]
[ReactorModFlags(Reactor.Networking.ModFlags.RequireOnAllClients)]

public class TheOtherRolesPlugin : BasePlugin
{
    public const string Id = "Spex.TheOtherUs.Options";
    public const string ModName = MyPluginInfo.PLUGIN_NAME;
    public const string VersionString = MyPluginInfo.PLUGIN_VERSION;
    public static uint betaDays;  // amount of days for the build to be usable (0 for infinite!)

    public static Version Version = Version.Parse(VersionString);

    public Harmony Harmony { get; } = new(Id);
    public static Main Instance;

    public static int optionsPage = 2;

    public static ConfigEntry<bool> DebugMode { get; private set; }
    public static ConfigEntry<bool> GhostsSeeInformation { get; set; }
    public static ConfigEntry<bool> GhostsSeeRoles { get; set; }
    public static ConfigEntry<bool> GhostsSeeModifier { get; set; }
    public static ConfigEntry<bool> GhostsSeeVotes { get; set; }
    public static ConfigEntry<bool> ShowLighterDarker { get; set; }
    public static ConfigEntry<bool> EnableSoundEffects { get; set; }
    public static ConfigEntry<bool> ShowFPS { get; set; }
    public static ConfigEntry<bool> MuteLobbyBGM { get; set; }
    public static ConfigEntry<bool> ShowChatNotifications { get; set; }
    public static ConfigEntry<bool> EnableHorseMode { get; set; }
    public static ConfigEntry<bool> ToggleCursor { get; set; }
    public static ConfigEntry<string> Ip { get; set; }
    public static ConfigEntry<ushort> Port { get; set; }
    public static ConfigEntry<string> ShowPopUpVersion { get; set; }

    public static Sprite ModStamp;

    public static IRegionInfo[] defaultRegions;


    // This is part of the Mini.RegionInstaller, Licensed under GPLv3
    // file="RegionInstallPlugin.cs" company="miniduikboot">
    public static void UpdateRegions()
    {
        var serverManager = FastDestroyableSingleton<ServerManager>.Instance;
        var regions = new[] {
            new StaticHttpRegionInfo("Custom", StringNames.NoTranslation, Ip.Value, new Il2CppReferenceArray<ServerInfo>(new ServerInfo[1] { new("Custom", Ip.Value, Port.Value, false) })).CastFast<IRegionInfo>()
        };

        var currentRegion = serverManager.CurrentRegion;
        Info($"Adding {regions.Length} regions");
        foreach (IRegionInfo region in regions)
        {
            if (region == null)
                Error("Could not add region");
            else
            {
                if (currentRegion != null && region.Name.Equals(currentRegion.Name, StringComparison.OrdinalIgnoreCase))
                    currentRegion = region;
                serverManager.AddOrUpdateRegion(region);
            }
        }

        // AU remembers the previous region that was set, so we need to restore it
        if (currentRegion == null) return;
        Debug("Resetting previous region");
        serverManager.SetRegion(currentRegion);
    }

    public override void Load()
    {
        ModTranslation.Load();

        if (ConsoleManager.ConsoleEnabled) System.Console.OutputEncoding = Encoding.UTF8;
        SetLogSource(Log);
        Instance = this;

        _ = checkBeta(); // Exit if running an expired beta
        _ = Patches.CredentialsPatch.MOTD.loadMOTDs();

        DebugMode = Config.Bind("Custom", "Enable Debug Mode", false);
        GhostsSeeInformation = Config.Bind("Custom", "Ghosts See Remaining Tasks", true);
        GhostsSeeRoles = Config.Bind("Custom", "Ghosts See Roles", true);
        GhostsSeeModifier = Config.Bind("Custom", "Ghosts See Modifier", true);
        GhostsSeeVotes = Config.Bind("Custom", "Ghosts See Votes", true);
        ShowLighterDarker = Config.Bind("Custom", "Show Lighter / Darker", true);
        ToggleCursor = Config.Bind("Custom", "Better Cursor", true);
        EnableSoundEffects = Config.Bind("Custom", "Enable Sound Effects", true);
        EnableHorseMode = Config.Bind("Custom", "Enable Horse Mode", false);
        ShowPopUpVersion = Config.Bind("Custom", "Show PopUp", "0");
        ShowFPS = Config.Bind("Custom", "Show FPS", true);
        MuteLobbyBGM = Config.Bind("Custom", "Mute Lobby BGM", true);
        ShowChatNotifications = Config.Bind("Custom", "Show Chat Notifications", true);

        Ip = Config.Bind("Custom", "Custom Server IP", "127.0.0.1");
        Port = Config.Bind("Custom", "Custom Server Port", (ushort)22023);
        defaultRegions = ServerManager.DefaultRegions;
        // Removes vanilla Servers
        ServerManager.DefaultRegions = new Il2CppReferenceArray<IRegionInfo>(new IRegionInfo[0]);

        UpdateRegions();

        DebugMode = Config.Bind("Custom", "Enable Debug Mode", false);
        Harmony.PatchAll();

        if (BepInExUpdater.UpdateRequired)
        {
            AddComponent<BepInExUpdater>();
            return;
        }

        CustomOptionHolder.Load();
        TORMapOptions.reloadPluginOptions();
        CustomColors.Load();
        CustomHatManager.LoadHats();

        if (ToggleCursor.Value) enableCursor(true);
        EventUtility.Load();
        SubmergedCompatibility.Initialize();
        MainMenuPatch.addSceneChangeCallbacks();
        _ = RoleInfo.loadReadme();
        AddToKillDistanceSetting.addKillDistance();

        AddComponent<ModUpdater>();
        Info("Loading TOR completed!");
    }
}

// Deactivate bans, since I always leave my local testing game and ban myself
[HarmonyPatch(typeof(StatsManager), nameof(StatsManager.AmBanned), MethodType.Getter)]
public static class AmBannedPatch
{
    public static void Postfix(out bool __result)
    {
        __result = false;
    }
}
[HarmonyPatch(typeof(ChatController), nameof(ChatController.Awake))]
public static class ChatControllerAwakePatch
{
    private static void Prefix()
    {
        if (!EOSManager.Instance.isKWSMinor)
        {
            DataManager.Settings.Multiplayer.ChatMode = InnerNet.QuickChatModes.FreeChatOrQuickChat;
        }
    }
}
