using System.Collections.Generic;
using UnityEngine;

namespace TheOtherRoles;

public static class Eraser {
    public static PlayerControl eraser;
    public static Color color = Palette.ImpostorRed;

    public static List<byte> alreadyErased = new List<byte>();

    public static List<PlayerControl> futureErased = new List<PlayerControl>();
    public static PlayerControl currentTarget;
    public static float cooldown = 30f;
    public static bool canEraseAnyone = false; 

    private static Sprite buttonSprite;
    public static Sprite getButtonSprite() {
        if (buttonSprite) return buttonSprite;
        buttonSprite = Helpers.loadSpriteFromResources("TheOtherRoles.Resources.EraserButton.png", 115f);
        return buttonSprite;
    }

    public static void clearAndReload() {
        eraser = null;
        futureErased = new List<PlayerControl>();
        currentTarget = null;
        cooldown = CustomOptionHolder.eraserCooldown.getFloat();
        canEraseAnyone = CustomOptionHolder.eraserCanEraseAnyone.getBool();
        alreadyErased = new List<byte>();
    }
}