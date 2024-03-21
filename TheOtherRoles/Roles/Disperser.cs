using UnityEngine;

namespace TheOtherRoles;

public static class Disperser {
    public static PlayerControl disperser;
    public static Color color = new Color32(48, 21, 89, byte.MaxValue);

    public static float cooldown = 30f;
    public static int remainingDisperses = 1;
    public static bool dispersesToVent;
    private static Sprite buttonSprite;

    public static Sprite getButtonSprite() {
        if (buttonSprite) return buttonSprite;
        buttonSprite = Helpers.loadSpriteFromResources("TheOtherRoles.Resources.Disperse.png", 115f);
        return buttonSprite;
    }
    public static void clearAndReload()
    {
        disperser = null;
        cooldown = CustomOptionHolder.modifierDisperserCooldown.getFloat();
        remainingDisperses = CustomOptionHolder.modifierDisperserNumberOfUses.getSelection() + 1;
        dispersesToVent = CustomOptionHolder.modifierDisperserDispersesToVent.getBool();
    }
}