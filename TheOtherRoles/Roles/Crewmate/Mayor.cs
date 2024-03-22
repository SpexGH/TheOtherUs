using UnityEngine;

namespace TheOtherRoles.Roles.Crewmate;

[RegisterRole]
public class Mayor : RoleBase
{
    public bool canSeeVoteColors;
    public Color color = new Color32(32, 77, 66, byte.MaxValue);
    public Minigame emergency;
    public Sprite emergencySprite;
    public PlayerControl mayor;
    public int mayorChooseSingleVote;
    public bool meetingButton = true;
    public int remoteMeetingsLeft = 1;
    public int tasksNeededToSeeVoteColors;

    public bool voteTwice = true;

    public Sprite getMeetingSprite()
    {
        if (emergencySprite) return emergencySprite;
        emergencySprite = Helpers.loadSpriteFromResources("TheOtherRoles.Resources.EmergencyButton.png", 550f);
        return emergencySprite;
    }

    public static void clearAndReload()
    {
        mayor = null;
        emergency = null;
        emergencySprite = null;
        remoteMeetingsLeft = Mathf.RoundToInt(CustomOptionHolder.mayorMaxRemoteMeetings.getFloat());
        canSeeVoteColors = CustomOptionHolder.mayorCanSeeVoteColors.getBool();
        tasksNeededToSeeVoteColors = (int)CustomOptionHolder.mayorTasksNeededToSeeVoteColors.getFloat();
        meetingButton = CustomOptionHolder.mayorMeetingButton.getBool();
        mayorChooseSingleVote = CustomOptionHolder.mayorChooseSingleVote.getSelection();
        voteTwice = true;
    }
}