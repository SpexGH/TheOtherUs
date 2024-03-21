using UnityEngine;

namespace TheOtherRoles;

public static class Medic {
    public static PlayerControl medic;
    public static PlayerControl shielded;
    public static PlayerControl futureShielded;
        
    public static Color color = new Color32(126, 251, 194, byte.MaxValue);
    public static bool usedShield;

    public static int showShielded = 0;
    public static bool showAttemptToShielded = false;
    public static bool showAttemptToMedic = false;
    public static bool unbreakableShield = true;
    public static bool setShieldAfterMeeting = false;
    public static bool showShieldAfterMeeting = false;
    public static bool meetingAfterShielding = false;
    public static bool reset = false;

    public static Color shieldedColor = new Color32(0, 221, 255, byte.MaxValue);
    public static PlayerControl currentTarget;

    private static Sprite buttonSprite;

    public static void resetShielded() {
        currentTarget = shielded = null;
        usedShield = false;
    }
    public static Sprite getButtonSprite() {
        if (buttonSprite) return buttonSprite;
        buttonSprite = Helpers.loadSpriteFromResources("TheOtherRoles.Resources.ShieldButton.png", 115f);
        return buttonSprite;
    }

    public static void clearAndReload() {
        medic = null;
        shielded = null;
        futureShielded = null;
        currentTarget = null;
        usedShield = false;
        reset = CustomOptionHolder.medicResetTargetAfterMeeting.getBool();
        showShielded = CustomOptionHolder.medicShowShielded.getSelection();
        showAttemptToShielded = CustomOptionHolder.medicShowAttemptToShielded.getBool();
        //      unbreakableShield = true; //CustomOptionHolder.medicBreakShield.getBool();
        unbreakableShield = CustomOptionHolder.medicBreakShield.getBool();
        showAttemptToMedic = CustomOptionHolder.medicShowAttemptToMedic.getBool();
        setShieldAfterMeeting = CustomOptionHolder.medicSetOrShowShieldAfterMeeting.getSelection() == 2;
        showShieldAfterMeeting = CustomOptionHolder.medicSetOrShowShieldAfterMeeting.getSelection() == 1;
        meetingAfterShielding = false;
    }
}