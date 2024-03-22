using UnityEngine;

namespace TheOtherRoles.Roles.Crewmate;

[RegisterRole]
public class BodyGuard : RoleBase
{
    public PlayerControl bodyguard;
    public Color color = new Color32(145, 102, 64, byte.MaxValue);
    public PlayerControl currentTarget;
    private ResourceSprite guardButtonSprite = new ("Shield.png");
    public PlayerControl guarded;
    public bool guardFlash;
    public bool reset = true;
    public bool usedGuard;

    public void resetGuarded()
    {
        currentTarget = guarded = null;
        usedGuard = false;
    }

    public override void ClearAndReload()
    {
        bodyguard = null;
        guardFlash = CustomOptionHolder.bodyGuardFlash.getBool();
        reset = CustomOptionHolder.bodyGuardResetTargetAfterMeeting.getBool();
        guarded = null;
        usedGuard = false;
    }
}