using UnityEngine;

namespace TheOtherRoles;

public static class Lawyer {
    public static PlayerControl lawyer;
    public static PlayerControl target;
    public static Color color = new Color32(134, 153, 25, byte.MaxValue);
    public static Sprite targetSprite;
    public static bool triggerProsecutorWin = false;
    public static bool isProsecutor = false;
    public static bool canCallEmergency = true;
    public static bool targetKnows = false;

    public static float vision = 1f;
    public static bool lawyerKnowsRole = false;
    public static bool targetCanBeJester = false;
    public static bool targetWasGuessed = false;

    public static Sprite getTargetSprite() {
        if (targetSprite) return targetSprite;
        targetSprite = Helpers.loadSpriteFromResources("", 150f);
        return targetSprite;
    }

    public static void clearAndReload(bool clearTarget = true) {
        lawyer = null;
        if (clearTarget) {
            target = null;
            targetWasGuessed = false;
        }
        isProsecutor = false;
        triggerProsecutorWin = false;
        vision = CustomOptionHolder.lawyerVision.getFloat();
        targetKnows = CustomOptionHolder.lawyerTargetKnows.getBool();
        lawyerKnowsRole = CustomOptionHolder.lawyerKnowsRole.getBool();
        targetCanBeJester = CustomOptionHolder.lawyerTargetCanBeJester.getBool();
        canCallEmergency = CustomOptionHolder.jesterCanCallEmergency.getBool();
    }
}