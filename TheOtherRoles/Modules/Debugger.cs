using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using TheOtherRoles.Patches;
using TheOtherRoles.Utilities;
using UnityEngine;
using static TheOtherRoles.TORMapOptions;

namespace TheOtherRoles.Modules;

[HarmonyPatch]
[HarmonyPriority(Priority.First)]
public class Debugger
{
    [HarmonyPatch(typeof(GameStartManager), nameof(GameStartManager.Update))]
    public static class CountdownPatch
    {
        public static void Prefix(GameStartManager __instance)
        {
            if (DebugMode) __instance.countDownTimer = 0;
        }
    }


    [HarmonyPatch(typeof(LogicGameFlow), nameof(LogicGameFlow.CheckEndCriteria))]
    [HarmonyPatch(typeof(LogicGameFlowHnS), nameof(LogicGameFlowHnS.CheckEndCriteria))]
    [HarmonyPatch(typeof(LogicGameFlowNormal), nameof(LogicGameFlowNormal.CheckEndCriteria))]
    public static bool Prefix()
    {
        return !DisableGameEnd;
    }

    [HarmonyPatch(typeof(EndGameNavigation), nameof(EndGameNavigation.ShowDefaultNavigation))]
    internal static class AutoPlayAgainPatch
    {
        public static void Postfix(EndGameNavigation __instance)
        {
            if (!DebugMode) return;
            if (AmongUsClient.Instance.AmHost) return;
            __instance.NextGame();
        }
    }

}

[HarmonyPatch(typeof(KeyboardJoystick), nameof(KeyboardJoystick.Update))]
public class KeyboardHandler
{
    //private static readonly string passwordHash = "d1f51dfdfd8d38027fd2ca9dfeb299399b5bdee58e6c0b3b5e9a45cd4e502848";
    private static readonly System.Random random = new((int)DateTime.Now.Ticks);
    private static readonly List<PlayerControl> bots = [];

    private static void Postfix(KeyboardJoystick __instance)
    {
        if (AmongUsClient.Instance && (AmongUsClient.Instance.AmHost || DebugMode))
        {
            // Spawn dummys
            /*if (AmongUsClient.Instance.AmHost && Input.GetKeyDown(KeyCode.F) && Input.GetKey(KeyCode.RightShift))
            {
                var playerControl = UnityEngine.Object.Instantiate(AmongUsClient.Instance.PlayerPrefab);
                var i = playerControl.PlayerId = (byte)GameData.Instance.GetAvailableId();

                bots.Add(playerControl);
                GameData.Instance.AddPlayer(playerControl);
                AmongUsClient.Instance.Spawn(playerControl, -2, InnerNet.SpawnFlags.None);

                playerControl.transform.position = PlayerControl.LocalPlayer.transform.position;
                playerControl.GetComponent<DummyBehaviour>().enabled = true;
                playerControl.NetTransform.enabled = false;
                playerControl.SetName(RandomString(10));
                playerControl.SetColor((byte)random.Next(Palette.PlayerColors.Length));
                GameData.Instance.RpcSetTasks(playerControl.PlayerId, new byte[0]);
            }*/

            // 强制结束游戏
            if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.F5) && InGame)
            {
                GameManager.Instance.RpcEndGame((GameOverReason)CustomGameOverReason.MiniLose, false);
            }
            // 快速开始游戏
            if (Input.GetKeyDown(KeyCode.LeftShift) && IsCountDown)
            {
                GameStartManager.Instance.countDownTimer = 0;
            }
        }
    }
    public static string RandomString(int length)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
    }
}


[HarmonyPatch(typeof(ControllerManager), nameof(ControllerManager.Update))]
public class ControllerManagerUpdate
{
    private static int resolutionIndex;
    private static readonly (int, int)[] resolutions =
    [
        (640, 360),
        (960, 540),
        (1280, 720),
        (1600, 900),
        (1920, 1080),
        (Screen.currentResolution.width, Screen.currentResolution.height),
    ];

    private static void Postfix(ControllerManager __instance)
    {

        if (Input.GetKeyDown(KeyCode.F11))
        {
            resolutionIndex++;
            if (resolutionIndex >= resolutions.Length) resolutionIndex = 0;
            bool fullScreen = resolutionIndex == resolutions.Length - 1;
            ResolutionManager.SetResolution(resolutions[resolutionIndex].Item1, resolutions[resolutionIndex].Item2, fullScreen);
        }
    }
}
