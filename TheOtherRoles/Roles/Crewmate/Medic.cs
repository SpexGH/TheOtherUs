using UnityEngine;

namespace TheOtherRoles.Roles.Crewmate;

[RegisterRole]
public class Medic : RoleBase
{
    public PlayerControl medic;
    public PlayerControl shielded;
    public PlayerControl futureShielded;

    public Color color = new Color32(126, 251, 194, byte.MaxValue);
    public bool usedShield;

    public int showShielded;
    public bool showAttemptToShielded;
    public bool showAttemptToMedic;
    public bool unbreakableShield = true;
    public bool setShieldAfterMeeting;
    public bool showShieldAfterMeeting;
    public bool meetingAfterShielding;
    public bool reset;

    public Color shieldedColor = new Color32(0, 221, 255, byte.MaxValue);
    public PlayerControl currentTarget;

    private ResourceSprite buttonSprite = new("ShieldButton.png");

    public void resetShielded()
    {
        currentTarget = shielded = null;
        usedShield = false;
    }

    public override void ClearAndReload()
    {
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