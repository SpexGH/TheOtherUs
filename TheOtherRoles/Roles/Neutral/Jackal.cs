using System.Collections.Generic;
using System.Linq;
using TheOtherRoles.Objects;
using UnityEngine;

namespace TheOtherRoles;

public static class Jackal
{
    public static PlayerControl jackal;

    public static Color color = new Color32(0, 180, 235, byte.MaxValue);

    //public static Color color = new Color32(224, 197, 219, byte.MaxValue);
    public static PlayerControl fakeSidekick;
    public static PlayerControl currentTarget;
    public static List<PlayerControl> formerJackals = new();

    public static float cooldown = 30f;
    public static bool isInvisable;
    public static float duration = 5f;
    public static float swoopCooldown = 30f;
    public static float swoopTimer = 0f;
    public static float createSidekickCooldown = 30f;
    public static bool canUseVents = true;
    public static bool canCreateSidekick = true;
    public static Sprite buttonSprite;
    public static Sprite buttonSprite2;
    public static bool jackalPromotedFromSidekickCanCreateSidekick = true;
    public static bool canCreateSidekickFromImpostor = true;
    public static bool hasImpostorVision;
    public static bool killFakeImpostor;
    public static bool wasTeamRed;
    public static bool canSabotage;
    public static bool wasImpostor;
    public static bool wasSpy;
    public static float chanceSwoop;
    public static bool canSwoop;
    public static bool canSwoop2;


    public static Sprite getSidekickButtonSprite()
    {
        if (buttonSprite) return buttonSprite;
        buttonSprite = Helpers.loadSpriteFromResources("TheOtherRoles.Resources.SidekickButton.png", 115f);
        return buttonSprite;
    }

    public static Sprite getSwoopButtonSprite()
    {
        if (buttonSprite2) return buttonSprite2;
        buttonSprite2 = Helpers.loadSpriteFromResources("TheOtherRoles.Resources.Swoop.png", 115f);
        return buttonSprite2;
    }

    public static Vector3 getSwooperSwoopVector()
    {
        return CustomButton.ButtonPositions.upperRowLeft; //brb
    }

    public static void removeCurrentJackal()
    {
        if (!formerJackals.Any(x => x.PlayerId == jackal.PlayerId)) formerJackals.Add(jackal);
        jackal = null;
        currentTarget = null;
        fakeSidekick = null;
        cooldown = CustomOptionHolder.jackalKillCooldown.getFloat();
        createSidekickCooldown = CustomOptionHolder.jackalCreateSidekickCooldown.getFloat();
    }

    public static void clearAndReload()
    {
        jackal = null;
        currentTarget = null;
        fakeSidekick = null;
        isInvisable = false;
        cooldown = CustomOptionHolder.jackalKillCooldown.getFloat();
        createSidekickCooldown = CustomOptionHolder.jackalCreateSidekickCooldown.getFloat();
        canUseVents = CustomOptionHolder.jackalCanUseVents.getBool();
        canSabotage = CustomOptionHolder.jackalCanUseSabo.getBool();
        canCreateSidekick = CustomOptionHolder.jackalCanCreateSidekick.getBool();
        jackalPromotedFromSidekickCanCreateSidekick =
            CustomOptionHolder.jackalPromotedFromSidekickCanCreateSidekick.getBool();
        canCreateSidekickFromImpostor = CustomOptionHolder.jackalCanCreateSidekickFromImpostor.getBool();
        killFakeImpostor = CustomOptionHolder.jackalKillFakeImpostor.getBool();
        swoopCooldown = CustomOptionHolder.swooperCooldown.getFloat();
        duration = CustomOptionHolder.swooperDuration.getFloat();
        formerJackals.Clear();
        hasImpostorVision = CustomOptionHolder.jackalAndSidekickHaveImpostorVision.getBool();
        wasTeamRed = wasImpostor = wasSpy = false;
        chanceSwoop = CustomOptionHolder.jackalChanceSwoop.getSelection() / 10f;
        if (TheOtherRoles.rnd.NextDouble() < chanceSwoop)
            canSwoop = true;
        else
            canSwoop = false;
        canSwoop2 = false;
    }
}