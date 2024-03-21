using UnityEngine;

namespace TheOtherRoles;

public static class Jumper {
    public static PlayerControl jumper;
    public static Color color = new Color32(204, 155, 20, byte.MaxValue); // mint

    public static float jumperJumpTime = 30f;
    public static float jumperChargesOnPlace = 1f;
    public static bool resetPlaceAfterMeeting = false;
    //    public static float jumperChargesGainOnMeeting = 2f;
    //public static float jumperMaxCharges = 3f;
    public static float jumperCharges = 1f;

    public static Vector3 jumpLocation;

    private static Sprite jumpMarkButtonSprite;
    private static Sprite jumpButtonSprite;
    public static bool usedPlace = false;

    public static Sprite getJumpMarkButtonSprite() {
        if (jumpMarkButtonSprite) return jumpMarkButtonSprite;
        jumpMarkButtonSprite = Helpers.loadSpriteFromResources("TheOtherRoles.Resources.JumperButton.png", 115f);
        return jumpMarkButtonSprite;
    }

    public static Sprite getJumpButtonSprite() {
        if (jumpButtonSprite) return jumpButtonSprite;
        jumpButtonSprite = Helpers.loadSpriteFromResources("TheOtherRoles.Resources.JumperJumpButton.png", 115f);
        return jumpButtonSprite;
    }

    public static void resetPlaces() {
        jumperCharges = Mathf.RoundToInt(CustomOptionHolder.jumperChargesOnPlace.getFloat());
        jumpLocation = Vector3.zero;
        usedPlace = false;
    }

    public static void clearAndReload() {
        resetPlaces();
        jumpLocation = Vector3.zero;
        jumper = null;
        resetPlaceAfterMeeting = true;
        jumperCharges = 1f;
        jumperJumpTime = CustomOptionHolder.jumperJumpTime.getFloat();
        jumperChargesOnPlace = CustomOptionHolder.jumperChargesOnPlace.getFloat();
        //      jumperChargesGainOnMeeting = CustomOptionHolder.jumperChargesGainOnMeeting.getFloat();
        //jumperMaxCharges = CustomOptionHolder.jumperMaxCharges.getFloat();
        usedPlace = false;
    }
}