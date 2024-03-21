using System.Collections.Generic;
using TheOtherRoles.Objects;
using UnityEngine;

namespace TheOtherRoles;

public static class Amnisiac {
    public static PlayerControl amnisiac;
    public static List<Arrow> localArrows = new List<Arrow>();
    public static Color color = new Color(0.5f, 0.7f, 1f, 1f);
    public static List<PoolablePlayer> poolIcons = new List<PoolablePlayer>();

    public static bool showArrows = true;
    public static bool resetRole = false;

    private static Sprite buttonSprite;
    public static Sprite getButtonSprite() {
        if (buttonSprite) return buttonSprite;
        buttonSprite = Helpers.loadSpriteFromResources("TheOtherRoles.Resources.Remember.png", 115f);
        return buttonSprite;
    }

    public static void clearAndReload() {
        amnisiac = null;
        showArrows = CustomOptionHolder.amnisiacShowArrows.getBool();
        resetRole = CustomOptionHolder.amnisiacResetRole.getBool();
        if (localArrows != null) {
            foreach (Arrow arrow in localArrows)
                if (arrow?.arrow != null)
                    UnityEngine.Object.Destroy(arrow.arrow);
        }
        localArrows = new List<Arrow>();
    }
}