using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TheOtherRoles;

public static class Medium
{
    public static PlayerControl medium;
    public static DeadPlayer target;
    public static DeadPlayer soulTarget;
    public static Color color = new Color32(98, 120, 115, byte.MaxValue);
    public static List<Tuple<DeadPlayer, Vector3>> deadBodies = new();
    public static List<Tuple<DeadPlayer, Vector3>> futureDeadBodies = new();
    public static List<SpriteRenderer> souls = new();
    public static DateTime meetingStartTime = DateTime.UtcNow;

    public static float cooldown = 30f;
    public static float duration = 3f;
    public static bool oneTimeUse;
    public static float chanceAdditionalInfo;

    private static Sprite soulSprite;

    private static Sprite question;

    public static Sprite getSoulSprite()
    {
        if (soulSprite) return soulSprite;
        soulSprite = Helpers.loadSpriteFromResources("TheOtherRoles.Resources.Soul.png", 500f);
        return soulSprite;
    }

    public static Sprite getQuestionSprite()
    {
        if (question) return question;
        question = Helpers.loadSpriteFromResources("TheOtherRoles.Resources.MediumButton.png", 115f);
        return question;
    }

    public static void clearAndReload()
    {
        medium = null;
        target = null;
        soulTarget = null;
        deadBodies = new List<Tuple<DeadPlayer, Vector3>>();
        futureDeadBodies = new List<Tuple<DeadPlayer, Vector3>>();
        souls = new List<SpriteRenderer>();
        meetingStartTime = DateTime.UtcNow;
        cooldown = CustomOptionHolder.mediumCooldown.getFloat();
        duration = CustomOptionHolder.mediumDuration.getFloat();
        oneTimeUse = CustomOptionHolder.mediumOneTimeUse.getBool();
        chanceAdditionalInfo = CustomOptionHolder.mediumChanceAdditionalInfo.getSelection() / 10f;
    }

    public static string getInfo(PlayerControl target, PlayerControl killer)
    {
        var msg = "";

        var infos = new List<SpecialMediumInfo>();
        // collect fitting death info types.
        // suicides:
        if (killer == target)
        {
            if (target == Sheriff.sheriff || target == Sheriff.formerSheriff)
                infos.Add(SpecialMediumInfo.SheriffSuicide);
            if (target == Lovers.lover1 || target == Lovers.lover2) infos.Add(SpecialMediumInfo.PassiveLoverSuicide);
            if (target == Thief.thief) infos.Add(SpecialMediumInfo.ThiefSuicide);
            if (target == Warlock.warlock) infos.Add(SpecialMediumInfo.WarlockSuicide);
        }
        else
        {
            if (target == Lovers.lover1 || target == Lovers.lover2) infos.Add(SpecialMediumInfo.ActiveLoverDies);
            if (target.Data.Role.IsImpostor && killer.Data.Role.IsImpostor && Thief.formerThief != killer)
                infos.Add(SpecialMediumInfo.ImpostorTeamkill);
        }

        if (target == Sidekick.sidekick &&
            (killer == Jackal.jackal || Jackal.formerJackals.Any(x => x.PlayerId == killer.PlayerId)))
            infos.Add(SpecialMediumInfo.JackalKillsSidekick);
        if (target == Lawyer.lawyer && killer == Lawyer.target) infos.Add(SpecialMediumInfo.LawyerKilledByClient);
        if (Medium.target.wasCleaned) infos.Add(SpecialMediumInfo.BodyCleaned);

        if (infos.Count > 0)
        {
            var selectedInfo = infos[TheOtherRoles.rnd.Next(infos.Count)];
            switch (selectedInfo)
            {
                case SpecialMediumInfo.SheriffSuicide:
                    msg = "Yikes, that Sheriff shot backfired.";
                    break;
                case SpecialMediumInfo.WarlockSuicide:
                    msg = "MAYBE I cursed the person next to me and killed myself. Oops.";
                    break;
                case SpecialMediumInfo.ThiefSuicide:
                    msg = "I tried to steal the gun from their pocket, but they were just happy to see me.";
                    break;
                case SpecialMediumInfo.ActiveLoverDies:
                    msg = "I wanted to get out of this toxic relationship anyways.";
                    break;
                case SpecialMediumInfo.PassiveLoverSuicide:
                    msg = "The love of my life died, thus with a kiss I die.";
                    break;
                case SpecialMediumInfo.LawyerKilledByClient:
                    msg = "My client killed me. Do I still get paid?";
                    break;
                case SpecialMediumInfo.JackalKillsSidekick:
                    msg = "First they sidekicked me, then they killed me. At least I don't need to do tasks anymore.";
                    break;
                case SpecialMediumInfo.ImpostorTeamkill:
                    msg = "I guess they confused me for the Spy, is there even one?";
                    break;
                case SpecialMediumInfo.BodyCleaned:
                    msg = "Is my dead body some kind of art now or... aaand it's gone.";
                    break;
            }
        }
        else
        {
            var randomNumber = TheOtherRoles.rnd.Next(4);
            var typeOfColor = Helpers.isLighterColor(Medium.target.killerIfExisting) ? "lighter" : "darker";
            var timeSinceDeath = (float)(meetingStartTime - Medium.target.timeOfDeath).TotalMilliseconds;
            var roleString = RoleInfo.GetRolesString(Medium.target.player, false);
            if (randomNumber == 0)
            {
                if (!roleString.Contains("Impostor") && !roleString.Contains("Crewmate"))
                    msg = "If my role hasn't been saved, there's no " + roleString + " in the game anymore.";
                else
                    msg = "I am a " + roleString + " without an other role.";
            }
            else if (randomNumber == 1)
            {
                msg = "I'm not sure, but I guess a " + typeOfColor + " color killed me.";
            }
            else if (randomNumber == 2)
            {
                msg = "If I counted correctly, I died " + Math.Round(timeSinceDeath / 1000) +
                      "s before the next meeting started.";
            }
            else
            {
                msg = "It seems like my killer is the " +
                      RoleInfo.GetRolesString(Medium.target.killerIfExisting, false, false, true) + ".";
            }
        }

        if (TheOtherRoles.rnd.NextDouble() < chanceAdditionalInfo)
        {
            var count = 0;
            var condition = "";
            var alivePlayersList = PlayerControl.AllPlayerControls.ToArray().Where(pc => !pc.Data.IsDead);
            switch (TheOtherRoles.rnd.Next(3))
            {
                case 0:
                    count = alivePlayersList.Where(pc =>
                        pc.Data.Role.IsImpostor ||
                        new List<RoleInfo> { RoleInfo.jackal, RoleInfo.sidekick, RoleInfo.sheriff, RoleInfo.thief }
                            .Contains(RoleInfo.getRoleInfoForPlayer(pc, false).FirstOrDefault())).Count();
                    condition = "killer" + (count == 1 ? "" : "s");
                    break;
                case 1:
                    count = alivePlayersList.Where(Helpers.roleCanUseVents).Count();
                    condition = "player" + (count == 1 ? "" : "s") + " who can use vents";
                    break;
                case 2:
                    count = alivePlayersList.Where(pc =>
                            Helpers.isNeutral(pc) && pc != Jackal.jackal && pc != Sidekick.sidekick &&
                            pc != Thief.thief)
                        .Count();
                    condition = "player" + (count == 1 ? "" : "s") + " who " + (count == 1 ? "is" : "are") +
                                " neutral but cannot kill";
                    break;
                case 3:
                    //count = alivePlayersList.Where(pc =>
                    break;
            }

            msg += $"\nWhen you asked, {count} " + condition + (count == 1 ? " was" : " were") + " still alive";
        }

        return Medium.target.player.Data.PlayerName + "'s Soul:\n" + msg;
    }

    private enum SpecialMediumInfo
    {
        SheriffSuicide,
        ThiefSuicide,
        ActiveLoverDies,
        PassiveLoverSuicide,
        LawyerKilledByClient,
        JackalKillsSidekick,
        ImpostorTeamkill,
        SubmergedO2,
        WarlockSuicide,
        BodyCleaned
    }
}