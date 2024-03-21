using UnityEngine;

namespace TheOtherRoles;

public static class Undertaker
{
    public static PlayerControl undertaker;
    public static Color color = Palette.ImpostorRed;

    public static float dragingDelaiAfterKill = 0f;

    public static bool isDraging = false;
    public static DeadBody deadBodyDraged = null;
    public static bool canDragAndVent = false;
        
    private static Sprite buttonSprite;
    public static Sprite getButtonSprite()
    {
        if (buttonSprite) return buttonSprite;
        buttonSprite = Helpers.loadSpriteFromResources("TheOtherRoles.Resources.UndertakerDragButton.png", 115f);
        return buttonSprite;
    }

    public static void clearAndReload()
    {
        undertaker = null;
        isDraging = false;
        canDragAndVent = CustomOptionHolder.undertakerCanDragAndVent.getBool();
        deadBodyDraged = null;
        dragingDelaiAfterKill = CustomOptionHolder.undertakerDragingDelaiAfterKill.getFloat();
    }
}