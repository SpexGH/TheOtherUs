using System.Collections.Generic;
using TheOtherRoles.Objects;
using UnityEngine;

namespace TheOtherRoles;

public static class Vulture {
    public static PlayerControl vulture;
    public static Color color = new Color32(139, 69, 19, byte.MaxValue);
    public static List<Arrow> localArrows = new List<Arrow>();
    public static float cooldown = 30f;
    public static int vultureNumberToWin = 4;
    public static int eatenBodies = 0;
    public static bool triggerVultureWin = false;
    public static bool canUseVents = true;
    public static bool showArrows = true;
    private static Sprite buttonSprite;
    public static Sprite getButtonSprite() {
        if (buttonSprite) return buttonSprite;
        buttonSprite = Helpers.loadSpriteFromResources("TheOtherRoles.Resources.VultureButton.png", 115f);
        return buttonSprite;
    }

    public static void clearAndReload() {
        vulture = null;
        vultureNumberToWin = Mathf.RoundToInt(CustomOptionHolder.vultureNumberToWin.getFloat());
        eatenBodies = 0;
        cooldown = CustomOptionHolder.vultureCooldown.getFloat();
        triggerVultureWin = false;
        canUseVents = CustomOptionHolder.vultureCanUseVents.getBool();
        showArrows = CustomOptionHolder.vultureShowArrows.getBool();
        if (localArrows != null) {
            foreach (Arrow arrow in localArrows)
                if (arrow?.arrow != null)
                    UnityEngine.Object.Destroy(arrow.arrow);
        }
        localArrows = new List<Arrow>();
    }
}