using UnityEngine;

namespace TheOtherRoles.Roles.Crewmate;

[RegisterRole]
public class Jumper : RoleBase
{
    public Color color = new Color32(204, 155, 20, byte.MaxValue); // mint
    private Sprite jumpButtonSprite;
    public PlayerControl jumper;

    //    public static float jumperChargesGainOnMeeting = 2f;
    //public static float jumperMaxCharges = 3f;
    public float jumperCharges = 1f;
    public float jumperChargesOnPlace = 1f;

    public float jumperJumpTime = 30f;

    public Vector3 jumpLocation;

    private Sprite jumpMarkButtonSprite;

    public bool resetPlaceAfterMeeting;
    public bool usedPlace;

    public Sprite getJumpMarkButtonSprite()
    {
        if (jumpMarkButtonSprite) return jumpMarkButtonSprite;
        jumpMarkButtonSprite = Helpers.loadSpriteFromResources("TheOtherRoles.Resources.JumperButton.png", 115f);
        return jumpMarkButtonSprite;
    }

    public Sprite getJumpButtonSprite()
    {
        if (jumpButtonSprite) return jumpButtonSprite;
        jumpButtonSprite = Helpers.loadSpriteFromResources("TheOtherRoles.Resources.JumperJumpButton.png", 115f);
        return jumpButtonSprite;
    }

    public void resetPlaces()
    {
        jumperCharges = Mathf.RoundToInt(CustomOptionHolder.jumperChargesOnPlace.getFloat());
        jumpLocation = Vector3.zero;
        usedPlace = false;
    }

    public void clearAndReload()
    {
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