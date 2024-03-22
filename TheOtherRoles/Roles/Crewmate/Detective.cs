using UnityEngine;

namespace TheOtherRoles.Roles.Crewmate;

[RegisterRole]
public class Detective : RoleBase
{
    public bool anonymousFootprints;
    public Color color = new Color32(8, 180, 180, byte.MaxValue);
    public PlayerControl detective;
    public float footprintDuration = 1f;

    public float footprintIntervall = 1f;
    public float reportColorDuration = 20f;
    public float reportNameDuration;
    public float timer = 6.2f;

    public void clearAndReload()
    {
        detective = null;
        anonymousFootprints = CustomOptionHolder.detectiveAnonymousFootprints.getBool();
        footprintIntervall = CustomOptionHolder.detectiveFootprintIntervall.getFloat();
        footprintDuration = CustomOptionHolder.detectiveFootprintDuration.getFloat();
        reportNameDuration = CustomOptionHolder.detectiveReportNameDuration.getFloat();
        reportColorDuration = CustomOptionHolder.detectiveReportColorDuration.getFloat();
        timer = 6.2f;
    }
}