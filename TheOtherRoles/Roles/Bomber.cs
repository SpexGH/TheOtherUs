using TheOtherRoles.Objects;
using UnityEngine;

namespace TheOtherRoles;

public static class Bomber
{
    public static PlayerControl bomber;
    public static Color color = Palette.ImpostorRed;

    public static Bomb bomb;
    public static bool isPlanted;
    public static bool isActive;
    public static float destructionTime = 20f;
    public static float destructionRange = 2f;
    public static float hearRange = 30f;
    public static float defuseDuration = 3f;
    public static float bombCooldown = 15f;
    public static float bombActiveAfter = 3f;

    private static Sprite buttonSprite;

    public static Sprite getButtonSprite()
    {
        if (buttonSprite) return buttonSprite;
        buttonSprite = Helpers.loadSpriteFromResources("TheOtherRoles.Resources.Bomb_Button_Plant.png", 115f);
        return buttonSprite;
    }

    public static void clearBomb(bool flag = true)
    {
        if (bomb != null)
        {
            Object.Destroy(bomb.bomb);
            Object.Destroy(bomb.background);
            bomb = null;
        }

        isPlanted = false;
        isActive = false;
        if (flag) SoundEffectsManager.stop("bombFuseBurning");
    }

    public static void clearAndReload()
    {
        clearBomb(false);
        bomber = null;
        bomb = null;
        isPlanted = false;
        isActive = false;
        destructionTime = CustomOptionHolder.bomberBombDestructionTime.getFloat();
        destructionRange = CustomOptionHolder.bomberBombDestructionRange.getFloat() / 10;
        hearRange = CustomOptionHolder.bomberBombHearRange.getFloat() / 10;
        defuseDuration = CustomOptionHolder.bomberDefuseDuration.getFloat();
        bombCooldown = CustomOptionHolder.bomberBombCooldown.getFloat();
        bombActiveAfter = CustomOptionHolder.bomberBombActiveAfter.getFloat();
        Bomb.clearBackgroundSprite();
    }
}