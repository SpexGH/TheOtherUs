using UnityEngine;

namespace TheOtherRoles;

public static class Escapist {
    public static PlayerControl escapist;
    public static Color color = Palette.ImpostorRed;

    public static float escapistEscapeTime = 30f;
    public static float escapistChargesOnPlace = 1f;
    public static bool resetPlaceAfterMeeting = false;
    //    public static float jumperChargesGainOnMeeting = 2f;
    //public static float escapistMaxCharges = 3f;
    public static float escapistCharges = 1f;

    public static Vector3 escapeLocation;

    private static Sprite escapeMarkButtonSprite;
    private static Sprite escapeButtonSprite;
    public static bool usedPlace = false;

    public static Sprite getEscapeMarkButtonSprite() {
        if (escapeMarkButtonSprite) return escapeMarkButtonSprite;
        escapeMarkButtonSprite = Helpers.loadSpriteFromResources("TheOtherRoles.Resources.Mark.png", 115f);
        return escapeMarkButtonSprite;
    }

    public static Sprite getEscapeButtonSprite() {
        if (escapeButtonSprite) return escapeButtonSprite;
        escapeButtonSprite = Helpers.loadSpriteFromResources("TheOtherRoles.Resources.Recall.png", 115f);
        return escapeButtonSprite;
    }

    public static void resetPlaces() {
        escapistCharges = Mathf.RoundToInt(CustomOptionHolder.escapistChargesOnPlace.getFloat());
        escapeLocation = Vector3.zero;
        usedPlace = false;
    }

    public static void clearAndReload() {
        resetPlaces();
        escapeLocation = Vector3.zero;
        escapist = null;
        resetPlaceAfterMeeting = true;
        escapistCharges = 1f;
        escapistEscapeTime = CustomOptionHolder.escapistEscapeTime.getFloat();
        escapistChargesOnPlace = CustomOptionHolder.escapistChargesOnPlace.getFloat();
        //      jumperChargesGainOnMeeting = CustomOptionHolder.jumperChargesGainOnMeeting.getFloat();
        //escapistMaxCharges = CustomOptionHolder.escapistMaxCharges.getFloat();
        usedPlace = false;
    }
}