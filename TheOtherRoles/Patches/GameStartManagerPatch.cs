using System;
using System.Collections.Generic;
using System.Linq;
using HarmonyLib;
using Hazel;
using InnerNet;
using Reactor.Utilities.Extensions;
using TMPro;
using UnityEngine;
using Object = UnityEngine.Object;

namespace TheOtherRoles.Patches;

public class GameStartManagerPatch
{
    public static readonly Dictionary<int, PlayerVersion> playerVersions = new();
    public static float timer = 600f;
    private static float kickingTimer;
    private static string lobbyCodeText = "";

    private static bool IsStart(GameStartManager __instance)
    {
        return __instance.GameStartText.text.StartsWith(
            FastDestroyableSingleton<TranslationController>.Instance.GetString(StringNames.GameStarting));
    }

    [HarmonyPatch(typeof(AmongUsClient), nameof(AmongUsClient.OnPlayerJoined))]
    public class AmongUsClientOnPlayerJoinedPatch
    {
        public static void Postfix(AmongUsClient __instance)
        {
            if (AmongUsClient.Instance.AmHost) HandshakeHelper.ShareGameMode();

            if (CachedPlayer.LocalPlayer == null) return;
            HandshakeHelper.shareGameVersion();
            HandshakeHelper.shareGameGUID();
        }
    }

    [HarmonyPatch(typeof(GameStartManager), nameof(GameStartManager.Start))]
    public class GameStartManagerStartPatch
    {
        public static void Postfix(GameStartManager __instance)
        {
            // Reset lobby countdown timer
            timer = 600f;
            // Reset kicking timer
            kickingTimer = 0f;
            // Copy lobby code
            var code = GameCode.IntToGameName(AmongUsClient.Instance.GameId);
            GUIUtility.systemCopyBuffer = code;
            lobbyCodeText =
                FastDestroyableSingleton<TranslationController>.Instance.GetString(StringNames.RoomCode,
                    new Il2CppReferenceArray<Il2CppSystem.Object>(0)) + "\r\n" + code;

            // Send version as soon as CachedPlayer.LocalPlayer.PlayerControl exists
            if (CachedPlayer.LocalPlayer != null)
            {
                HandshakeHelper.shareGameVersion();
                HandshakeHelper.shareGameGUID();
            }

            HandshakeHelper.PlayerAgainInfo.Clear();

            if (AmongUsClient.Instance.AmHost) HandshakeHelper.ShareGameMode();
        }
    }

    [HarmonyPatch(typeof(GameStartManager), nameof(GameStartManager.Update))]
    public class GameStartManagerUpdatePatch
    {
        public static float startingTimer;
        private static bool update;
        private static string currentText = "";
        private static GameObject copiedStartButton;

        public static void Prefix(GameStartManager __instance)
        {
            if (!GameData.Instance) return; // No instance
            __instance.MinPlayers = 1;
            update = GameData.Instance.PlayerCount != __instance.LastPlayerCount;
        }

        public static void Postfix(GameStartManager __instance)
        {
            // Check version handshake infos

            var versionMismatch = false;
            var message = "";
            foreach (var client in AmongUsClient.Instance.allClients.ToArray())
            {
                if (client.Character == null) continue;
                var dummyComponent = client.Character.GetComponent<DummyBehaviour>();
                if (dummyComponent != null && dummyComponent.enabled)
                    continue;

                if (!playerVersions.ContainsKey(client.Id))
                {
                    HandshakeHelper.againSend(client.Id, HandshakeHelper.ShareMode.Again);
                    versionMismatch = true;
                    message +=
                        $"<color=#FF0000FF>{client.Character.Data.PlayerName} has a different or no version of The Other Us\n</color>";
                }
                else
                {
                    var PV = playerVersions[client.Id];
                    var diff = Main.Version.CompareTo(PV.version);
                    if (PV.guid == null)
                    {
                        HandshakeHelper.againSend(client.Id, HandshakeHelper.ShareMode.Guid);
                        continue;
                    }

                    switch (diff)
                    {
                        case > 0:
                            message +=
                                $"<color=#FF0000FF>{client.Character.Data.PlayerName} has an older version of The Other Us (v{playerVersions[client.Id].version.ToString()})\n</color>";
                            versionMismatch = true;
                            break;
                        case < 0:
                            message +=
                                $"<color=#FF0000FF>{client.Character.Data.PlayerName} has a newer version of The Other Us (v{playerVersions[client.Id].version.ToString()})\n</color>";
                            versionMismatch = true;
                            break;
                        default:
                        {
                            if (!PV.GuidMatches())
                            {
                                // version presumably matches, check if Guid matches
                                message +=
                                    $"<color=#FF0000FF>{client.Character.Data.PlayerName} has a modified version of TOU v{playerVersions[client.Id].version.ToString()} <size=30%>({PV.guid.ToString()})</size>\n</color>";
                                versionMismatch = true;
                            }

                            break;
                        }
                    }
                }
            }

            // Display message to the host
            if (AmongUsClient.Instance.AmHost)
            {
                if (versionMismatch)
                {
                    __instance.StartButton.color = __instance.startLabelText.color = Palette.DisabledClear;
                    __instance.GameStartText.text = message;
                    __instance.GameStartText.transform.localPosition =
                        __instance.StartButton.transform.localPosition + (Vector3.up * 2);
                }
                else
                {
                    __instance.StartButton.color = __instance.startLabelText.color =
                        __instance.LastPlayerCount >= __instance.MinPlayers
                            ? Palette.EnabledColor
                            : Palette.DisabledClear;
                    __instance.GameStartText.transform.localPosition = __instance.StartButton.transform.localPosition;
                }

                if (__instance.startState != GameStartManager.StartingStates.Countdown)
                    copiedStartButton.Destroy();

                // Make starting info available to clients:
                if (startingTimer <= 0 && __instance.startState == GameStartManager.StartingStates.Countdown)
                {
                    var writer = AmongUsClient.Instance.StartRpcImmediately(
                        CachedPlayer.LocalPlayer.PlayerControl.NetId, (byte)CustomRPC.SetGameStarting,
                        SendOption.Reliable);
                    AmongUsClient.Instance.FinishRpcImmediately(writer);
                    RPCProcedure.setGameStarting();

                    // Activate Stop-Button
                    copiedStartButton = Object.Instantiate(__instance.StartButton.gameObject,
                        __instance.StartButton.gameObject.transform.parent);
                    copiedStartButton.transform.localPosition = __instance.StartButton.transform.localPosition;
                    copiedStartButton.GetComponent<SpriteRenderer>().sprite =
                        Helpers.loadSpriteFromResources("TheOtherRoles.Resources.StopClean.png", 180f);
                    copiedStartButton.SetActive(true);
                    var startButtonText = copiedStartButton.GetComponentInChildren<TextMeshPro>();
                    startButtonText.text = "STOP";
                    startButtonText.fontSize *= 0.8f;
                    startButtonText.fontSizeMax = startButtonText.fontSize;
                    startButtonText.gameObject.transform.localPosition = Vector3.zero;
                    var startButtonPassiveButton = copiedStartButton.GetComponent<PassiveButton>();

                    void StopStartFunc()
                    {
                        __instance.ResetStartState();
                        copiedStartButton.Destroy();
                        startingTimer = 0;
                    }

                    startButtonPassiveButton.OnClick.AddListener((Action)(() => StopStartFunc()));
                    __instance.StartCoroutine(Effects.Lerp(.1f,
                        new Action<float>(p => { startButtonText.text = "STOP"; })));
                }

                if (__instance.startState == GameStartManager.StartingStates.Countdown)
                    __instance.GameStartText.transform.localPosition =
                        __instance.StartButton.transform.localPosition + (Vector3.up * 0.6f);
            }

            // Client update with handshake infos
            else
            {
                if (!playerVersions.ContainsKey(AmongUsClient.Instance.HostId) ||
                    TheOtherRolesPlugin.Version.CompareTo(playerVersions[AmongUsClient.Instance.HostId].version) != 0)
                {
                    kickingTimer += Time.deltaTime;
                    if (kickingTimer > 10)
                    {
                        kickingTimer = 0;
                        AmongUsClient.Instance.ExitGame(DisconnectReasons.ExitGame);
                        SceneChanger.ChangeScene("MainMenu");
                    }

                    __instance.GameStartText.text =
                        $"<color=#FF0000FF>The host has no or a different version of The Other Us\nYou will be kicked in {Math.Round(10 - kickingTimer)}s</color>";
                    __instance.GameStartText.transform.localPosition =
                        __instance.StartButton.transform.localPosition + (Vector3.up * 2);
                }
                else if (versionMismatch)
                {
                    __instance.GameStartText.text =
                        "<color=#FF0000FF>Players With Different Versions:\n</color>" + message;
                    __instance.GameStartText.transform.localPosition =
                        __instance.StartButton.transform.localPosition + (Vector3.up * 2);
                }
                else
                {
                    __instance.GameStartText.transform.localPosition = __instance.StartButton.transform.localPosition;
                    if (!IsStart(__instance))
                        __instance.GameStartText.text = string.Empty;
                }

                if (!IsStart(__instance) || !CustomOptionHolder.anyPlayerCanStopStart.getBool())
                    copiedStartButton.Destroy();

                if (CustomOptionHolder.anyPlayerCanStopStart.getBool() && copiedStartButton == null &&
                    IsStart(__instance))
                {
                    // Activate Stop-Button
                    copiedStartButton = Object.Instantiate(__instance.StartButton.gameObject,
                        __instance.StartButton.gameObject.transform.parent);
                    copiedStartButton.transform.localPosition = __instance.StartButton.transform.localPosition;
                    copiedStartButton.GetComponent<SpriteRenderer>().sprite =
                        Helpers.loadSpriteFromResources("TheOtherRoles.Resources.StopClean.png", 180f);
                    copiedStartButton.SetActive(true);
                    var startButtonText = copiedStartButton.GetComponentInChildren<TextMeshPro>();
                    startButtonText.text = "STOP";
                    startButtonText.fontSize *= 0.8f;
                    startButtonText.fontSizeMax = startButtonText.fontSize;
                    startButtonText.gameObject.transform.localPosition = Vector3.zero;
                    var startButtonPassiveButton = copiedStartButton.GetComponent<PassiveButton>();

                    void StopStartFunc()
                    {
                        var writer = AmongUsClient.Instance.StartRpcImmediately(
                            CachedPlayer.LocalPlayer.PlayerControl.NetId, (byte)CustomRPC.StopStart,
                            SendOption.Reliable, AmongUsClient.Instance.HostId);
                        writer.Write(PlayerControl.LocalPlayer.PlayerId);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        copiedStartButton.Destroy();
                        __instance.GameStartText.text = string.Empty;
                        startingTimer = 0;
                    }

                    startButtonPassiveButton.OnClick.AddListener((Action)(() => StopStartFunc()));
                    __instance.StartCoroutine(Effects.Lerp(.1f,
                        new Action<float>(p => { startButtonText.text = "STOP"; })));
                }

                if (IsStart(__instance) && CustomOptionHolder.anyPlayerCanStopStart.getBool())
                    __instance.GameStartText.transform.localPosition =
                        __instance.StartButton.transform.localPosition + (Vector3.up * 0.6f);
            }

            // Start Timer
            if (startingTimer > 0) startingTimer -= Time.deltaTime;
            // Lobby timer
            if (!GameData.Instance) return; // No instance

            if (update) currentText = __instance.PlayerCounter.text;

            timer = Mathf.Max(0f, timer -= Time.deltaTime);
            var minutes = (int)timer / 60;
            var seconds = (int)timer % 60;
            var suffix = $" ({minutes:00}:{seconds:00})";

            __instance.PlayerCounter.text = currentText + suffix;
            __instance.PlayerCounter.autoSizeTextContainer = true;
        }
    }

    [HarmonyPatch(typeof(GameStartManager), nameof(GameStartManager.BeginGame))]
    public class GameStartManagerBeginGame
    {
        public static bool Prefix(GameStartManager __instance)
        {
            // Block game start if not everyone has the same mod version
            var continueStart = true;

            if (AmongUsClient.Instance.AmHost)
            {
                foreach (var client in AmongUsClient.Instance.allClients.GetFastEnumerator())
                {
                    if (client.Character == null) continue;
                    var dummyComponent = client.Character.GetComponent<DummyBehaviour>();
                    if (dummyComponent != null && dummyComponent.enabled)
                        continue;

                    if (!playerVersions.ContainsKey(client.Id))
                    {
                        continueStart = false;
                        break;
                    }

                    var PV = playerVersions[client.Id];
                    var diff = TheOtherRolesPlugin.Version.CompareTo(PV.version);
                    if (diff != 0 || !PV.GuidMatches())
                    {
                        continueStart = false;
                        break;
                    }
                }

                if (continueStart &&
                    (TORMapOptions.gameMode == CustomGamemodes.HideNSeek ||
                     TORMapOptions.gameMode == CustomGamemodes.PropHunt) &&
                    GameOptionsManager.Instance.CurrentGameOptions.MapId != 6)
                {
                    byte mapId = 0;
                    if (TORMapOptions.gameMode == CustomGamemodes.HideNSeek)
                        mapId = (byte)CustomOptionHolder.hideNSeekMap.getSelection();
                    else if (TORMapOptions.gameMode == CustomGamemodes.PropHunt)
                        mapId = (byte)CustomOptionHolder.propHuntMap.getSelection();
                    if (mapId >= 3) mapId++;
                    var writer = AmongUsClient.Instance.StartRpcImmediately(
                        CachedPlayer.LocalPlayer.PlayerControl.NetId, (byte)CustomRPC.DynamicMapOption,
                        SendOption.Reliable);
                    writer.Write(mapId);
                    AmongUsClient.Instance.FinishRpcImmediately(writer);
                    RPCProcedure.dynamicMapOption(mapId);
                }
                else if (CustomOptionHolder.dynamicMap.getBool() && continueStart)
                {
                    // 0 = Skeld
                    // 1 = Mira HQ
                    // 2 = Polus
                    // 3 = Dleks - deactivated
                    // 4 = Airship
                    // 5 = Submerged
                    byte chosenMapId = 0;
                    var probabilities = new List<float>();
                    probabilities.Add(CustomOptionHolder.dynamicMapEnableSkeld.getSelection() / 10f);
                    probabilities.Add(CustomOptionHolder.dynamicMapEnableMira.getSelection() / 10f);
                    probabilities.Add(CustomOptionHolder.dynamicMapEnablePolus.getSelection() / 10f);
                    probabilities.Add(CustomOptionHolder.dynamicMapEnableAirShip.getSelection() / 10f);
                    probabilities.Add(CustomOptionHolder.dynamicMapEnableFungle.getSelection() / 10f);
                    probabilities.Add(CustomOptionHolder.dynamicMapEnableSubmerged.getSelection() / 10f);

                    // if any map is at 100%, remove all maps that are not!
                    if (probabilities.Contains(1.0f))
                        for (var i = 0; i < probabilities.Count; i++)
                            if (probabilities[i] != 1.0)
                                probabilities[i] = 0;

                    var sum = probabilities.Sum();
                    if (sum == 0) return continueStart; // All maps set to 0, why are you doing this???
                    for (var i = 0; i < probabilities.Count; i++) // Normalize to [0,1]
                        probabilities[i] /= sum;
                    var selection = (float)ListHelper.rnd.NextDouble();
                    float cumsum = 0;
                    for (byte i = 0; i < probabilities.Count; i++)
                    {
                        cumsum += probabilities[i];
                        if (cumsum > selection)
                        {
                            chosenMapId = i;
                            break;
                        }
                    }

                    // Translate chosen map to presets page and use that maps random map preset page
                    if (CustomOptionHolder.dynamicMapSeparateSettings.getBool())
                        CustomOptionHolder.presetSelection.updateSelection(chosenMapId + 2);
                    if (chosenMapId >= 3) chosenMapId++; // Skip dlekS

                    var writer = AmongUsClient.Instance.StartRpcImmediately(
                        CachedPlayer.LocalPlayer.PlayerControl.NetId, (byte)CustomRPC.DynamicMapOption,
                        SendOption.Reliable);
                    writer.Write(chosenMapId);
                    AmongUsClient.Instance.FinishRpcImmediately(writer);
                    RPCProcedure.dynamicMapOption(chosenMapId);
                }
            }

            return continueStart;
        }
    }
}