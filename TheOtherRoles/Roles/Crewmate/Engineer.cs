using UnityEngine;

namespace TheOtherRoles.Roles.Crewmate;

[RegisterRole]
public class Engineer : RoleBase
{
    private Sprite buttonSprite;
    public Color color = new Color32(0, 40, 245, byte.MaxValue);
    public PlayerControl engineer;
    public bool highlightForImpostors = true;
    public bool highlightForTeamJackal = true;
    public int remainingFixes = 1;

    public bool remoteFix = true;

    public bool resetFixAfterMeeting;

    public bool usedFix;

    public Sprite getButtonSprite()
    {
        if (buttonSprite) return buttonSprite;
        buttonSprite = Helpers.loadSpriteFromResources("TheOtherRoles.Resources.RepairButton.png", 115f);
        return buttonSprite;
    }

    public void resetFixes()
    {
        remainingFixes = Mathf.RoundToInt(CustomOptionHolder.engineerNumberOfFixes.getFloat());
        usedFix = false;
    }

    public void clearAndReload()
    {
        engineer = null;
        resetFixes();
        remoteFix = CustomOptionHolder.engineerRemoteFix.getBool();
        //expertRepairs = CustomOptionHolder.engineerExpertRepairs.getBool();
        resetFixAfterMeeting = CustomOptionHolder.engineerResetFixAfterMeeting.getBool();
        remainingFixes = Mathf.RoundToInt(CustomOptionHolder.engineerNumberOfFixes.getFloat());
        highlightForImpostors = CustomOptionHolder.engineerHighlightForImpostors.getBool();
        highlightForTeamJackal = CustomOptionHolder.engineerHighlightForTeamJackal.getBool();
        usedFix = false;
    }
}