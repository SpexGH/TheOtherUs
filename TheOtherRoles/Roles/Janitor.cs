using UnityEngine;

namespace TheOtherRoles;

public static class Janitor
{
    public static PlayerControl janitor;
    public static Color color = Palette.ImpostorRed;

    public static float cooldown = 30f;

    private static Sprite buttonSprite;

    public static Sprite getButtonSprite()
    {
        if (buttonSprite) return buttonSprite;
        buttonSprite = Helpers.loadSpriteFromResources("TheOtherRoles.Resources.CleanButton.png", 115f);
        return buttonSprite;
    }

    public static void clearAndReload()
    {
        janitor = null;
        cooldown = CustomOptionHolder.janitorCooldown.getFloat();
    }
}