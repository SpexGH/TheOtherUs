using UnityEngine;

namespace TheOtherRoles;

public static class Bomber2
{
    public static PlayerControl bomber2;
    public static Color color = Palette.ImpostorRed;
    public static Color alertColor = Palette.ImpostorRed;

    public static float cooldown = 30f;
    public static float bombDelay = 10f;
    public static float bombTimer = 10f;

    public static bool bombActive;

    // public static bool hotPotatoMode = false;
    public static PlayerControl currentBombTarget = null;
    public static bool hasAlerted = false;
    public static int timeLeft = 0;
    public static PlayerControl currentTarget = null;
    public static PlayerControl hasBomb = null;


    private static Sprite buttonSprite;

    public static Sprite getButtonSprite()
    {
        if (buttonSprite) return buttonSprite;
        buttonSprite = Helpers.loadSpriteFromResources("TheOtherRoles.Resources.Bomber2.png", 115f);
        return buttonSprite;
    }

    public static void clearAndReload()
    {
        bomber2 = null;
        bombActive = false;
        cooldown = CustomOptionHolder.bomber2BombCooldown.getFloat();
        bombDelay = CustomOptionHolder.bomber2Delay.getFloat();
        bombTimer = CustomOptionHolder.bomber2Timer.getFloat();
        //hotPotatoMode = CustomOptionHolder.bomber2HotPotatoMode.getBool();
    }
}