using System.Collections.Generic;
using TheOtherRoles.Objects;
using UnityEngine;

namespace TheOtherRoles;

public static class Tracker
{
    public static PlayerControl tracker;
    public static Color color = new Color32(100, 58, 220, byte.MaxValue);
    public static List<Arrow> localArrows = new();

    public static float updateIntervall = 5f;
    public static bool resetTargetAfterMeeting;
    public static bool canTrackCorpses;
    public static float corpsesTrackingCooldown = 30f;
    public static float corpsesTrackingDuration = 5f;
    public static float corpsesTrackingTimer;
    public static List<Vector3> deadBodyPositions = new();

    public static PlayerControl currentTarget;
    public static PlayerControl tracked;
    public static bool usedTracker;
    public static float timeUntilUpdate;
    public static Arrow arrow = new(Color.blue);

    private static Sprite trackCorpsesButtonSprite;

    private static Sprite buttonSprite;

    public static Sprite getTrackCorpsesButtonSprite()
    {
        if (trackCorpsesButtonSprite) return trackCorpsesButtonSprite;
        trackCorpsesButtonSprite = Helpers.loadSpriteFromResources("TheOtherRoles.Resources.PathfindButton.png", 115f);
        return trackCorpsesButtonSprite;
    }

    public static Sprite getButtonSprite()
    {
        if (buttonSprite) return buttonSprite;
        buttonSprite = Helpers.loadSpriteFromResources("TheOtherRoles.Resources.TrackerButton.png", 115f);
        return buttonSprite;
    }

    public static void resetTracked()
    {
        currentTarget = tracked = null;
        usedTracker = false;
        if (arrow?.arrow != null) Object.Destroy(arrow.arrow);
        arrow = new Arrow(Color.blue);
        if (arrow.arrow != null) arrow.arrow.SetActive(false);
    }

    public static void clearAndReload()
    {
        tracker = null;
        resetTracked();
        timeUntilUpdate = 0f;
        updateIntervall = CustomOptionHolder.trackerUpdateIntervall.getFloat();
        resetTargetAfterMeeting = CustomOptionHolder.trackerResetTargetAfterMeeting.getBool();
        if (localArrows != null)
            foreach (var arrow in localArrows)
                if (arrow?.arrow != null)
                    Object.Destroy(arrow.arrow);
        deadBodyPositions = new List<Vector3>();
        corpsesTrackingTimer = 0f;
        corpsesTrackingCooldown = CustomOptionHolder.trackerCorpsesTrackingCooldown.getFloat();
        corpsesTrackingDuration = CustomOptionHolder.trackerCorpsesTrackingDuration.getFloat();
        canTrackCorpses = CustomOptionHolder.trackerCanTrackCorpses.getBool();
    }
}