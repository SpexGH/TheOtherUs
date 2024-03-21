using System;
using UnityEngine;

namespace TheOtherRoles;

public static class Swapper {
    public static PlayerControl swapper;
    public static Color color = new Color32(134, 55, 86, byte.MaxValue);
    private static Sprite spriteCheck;
    public static bool canCallEmergency = false;
    public static bool canOnlySwapOthers = false;
    public static int charges;
    public static float rechargeTasksNumber;
    public static bool canFixSabotages = false;
    public static float rechargedTasks;
 
    public static byte playerId1 = Byte.MaxValue;
    public static byte playerId2 = Byte.MaxValue;

    public static Sprite getCheckSprite() {
        if (spriteCheck) return spriteCheck;
        spriteCheck = Helpers.loadSpriteFromResources("TheOtherRoles.Resources.SwapperCheck.png", 150f);
        return spriteCheck;
    }

    public static void clearAndReload() {
        swapper = null;
        playerId1 = Byte.MaxValue;
        playerId2 = Byte.MaxValue;
        canCallEmergency = CustomOptionHolder.swapperCanCallEmergency.getBool();
        canOnlySwapOthers = CustomOptionHolder.swapperCanOnlySwapOthers.getBool();
        canFixSabotages = CustomOptionHolder.swapperCanFixSabotages.getBool();
        charges = Mathf.RoundToInt(CustomOptionHolder.swapperSwapsNumber.getFloat());
        rechargeTasksNumber = Mathf.RoundToInt(CustomOptionHolder.swapperRechargeTasksNumber.getFloat());
        rechargedTasks = Mathf.RoundToInt(CustomOptionHolder.swapperRechargeTasksNumber.getFloat());
    }
}