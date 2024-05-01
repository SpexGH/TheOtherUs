using System;
using System.Collections.Generic;
using System.Linq;
using InnerNet;
using Reactor.Utilities.Extensions;
using TMPro;
using UnityEngine;
using Object = UnityEngine.Object;

namespace TheOtherRoles.Patches;

[HarmonyPatch]
public class GameStartManagerPatch
{
    public static float timer = 600f;
    private static float kickingTimer;
    private static string lobbyCodeText = "";

    private static bool IsStart(GameStartManager __instance)
    {
        var array = new Il2CppReferenceArray<Il2CppSystem.Object>(new Il2CppSystem.Object[]
            { Mathf.CeilToInt(__instance.countDownTimer) });
        return __instance.GameStartText.text.Contains(
            FastDestroyableSingleton<TranslationController>.Instance.GetString(StringNames.GameStarting, array));
    }
    
    [HarmonyPatch(typeof(AmongUsClient), nameof(AmongUsClient.OnGameEnd))]
    public class AmongUsClientOnGameEndPatch
    {
        public static void Postfix(AmongUsClient __instance)
        {
            if (AmongUsClient.Instance.AmHost) 
                HandshakeHelper.ShareGameMode();
        }
    }

    [HarmonyPatch(typeof(AmongUsClient), nameof(AmongUsClient.OnPlayerJoined))]
    public class AmongUsClientOnPlayerJoinedPatch
    {
        public static void Postfix(AmongUsClient __instance)
        {
            if (AmongUsClient.Instance.AmHost) 
                HandshakeHelper.ShareGameMode();

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

            HandshakeHelper.PlayerAgainInfo.Clear();
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
            var versionMismatch = HandshakeHelper.GetVersionHandshake(out var datas, out var message);

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
                    FastRpcWriter.StartNewRpcWriter(CustomRPC.SetGameStarting).RPCSend();
                    RPCProcedure.setGameStarting();

                    // Activate Stop-Button
                    var gameObject = __instance.StartButton.gameObject;
                    copiedStartButton = Object.Instantiate(gameObject, gameObject.transform.parent);
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
                if (!HandshakeHelper.playerVersions.ContainsKey(AmongUsClient.Instance.HostId) ||
                    Main.version.CompareTo(HandshakeHelper.playerVersions[AmongUsClient.Instance.HostId].version) != 0)
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
                    var gameObject = __instance.StartButton.gameObject;
                    copiedStartButton = Object.Instantiate(gameObject, gameObject.transform.parent);
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
                        FastRpcWriter.StartNewRpcWriter(CustomRPC.StopStart, mode: RPCSendMode.SendToPlayer,
                                TargetId: AmongUsClient.Instance.HostId).Write(PlayerControl.LocalPlayer.PlayerId)
                            .RPCSend();
                        copiedStartButton.Destroy();
                        __instance.GameStartText.text = string.Empty;
                        startingTimer = 0;
                    }

                    startButtonPassiveButton.OnClick.AddListener((Action)StopStartFunc);
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

            if (!AmongUsClient.Instance.AmHost) return true;
            var continueStart = !HandshakeHelper.CurrentMismatch;

            if (continueStart &&
                (TORMapOptions.gameMode == CustomGamemodes.HideNSeek ||
                 TORMapOptions.gameMode == CustomGamemodes.PropHunt) &&
                GameOptionsManager.Instance.CurrentGameOptions.MapId != 6)
            {
                byte mapId = TORMapOptions.gameMode switch
                {
                    CustomGamemodes.HideNSeek => (byte)CustomOptionHolder.hideNSeekMap.getSelection(),
                    CustomGamemodes.PropHunt => (byte)CustomOptionHolder.propHuntMap.getSelection(),
                    _ => 0
                };
                if (mapId >= 3) mapId++;
                FastRpcWriter.StartNewRpcWriter(CustomRPC.DynamicMapOption).Write(mapId).RPCSend();
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
                if (sum == 0) return true; // All maps set to 0, why are you doing this???
                for (var i = 0; i < probabilities.Count; i++) // Normalize to [0,1]
                    probabilities[i] /= sum;
                var selection = (float)TheOtherRoles.rnd.NextDouble();
                float cumsum = 0;
                for (byte i = 0; i < probabilities.Count; i++)
                {
                    cumsum += probabilities[i];
                    if (!(cumsum > selection)) continue;
                    chosenMapId = i;
                    break;
                }

                // Translate chosen map to presets page and use that maps random map preset page
                if (CustomOptionHolder.dynamicMapSeparateSettings.getBool())
                    CustomOptionHolder.presetSelection.updateSelection(chosenMapId + 2);
                if (chosenMapId >= 3) chosenMapId++; // Skip dlekS
                FastRpcWriter.StartNewRpcWriter(CustomRPC.DynamicMapOption).Write(chosenMapId).RPCSend();
                RPCProcedure.dynamicMapOption(chosenMapId);
            }

            return continueStart;
        }
    }
}