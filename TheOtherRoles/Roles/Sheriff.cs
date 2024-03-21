using UnityEngine;

namespace TheOtherRoles;


    public static class Sheriff {
        public static PlayerControl sheriff;
        public static Color color = new Color32(248, 205, 70, byte.MaxValue);

        public static float cooldown = 30f;
        public static bool canKillNeutrals = false;
        public static bool canKillArsonist = false;
        public static bool canKillLawyer = false;
        public static bool canKillJester = false;
        public static bool canKillPursuer = false;
        public static bool canKillVulture = false;
        public static bool canKillThief = false;
        public static bool canKillAmnesiac = false;
        public static bool canKillProsecutor = false;
        public static bool spyCanDieToSheriff = false;
        public static int misfireKills; // Self: 0, Target: 1, Both: 2

        public static PlayerControl currentTarget;

        public static PlayerControl formerDeputy;  // Needed for keeping handcuffs + shifting
        public static PlayerControl formerSheriff;  // When deputy gets promoted...

        public static void replaceCurrentSheriff(PlayerControl deputy)
        {
            if (!formerSheriff) formerSheriff = sheriff;
            sheriff = deputy;
            currentTarget = null;
            cooldown = CustomOptionHolder.sheriffCooldown.getFloat();
        }

        public static void clearAndReload() {
            sheriff = null;
            currentTarget = null;
            formerDeputy = null;
            formerSheriff = null;
            misfireKills = CustomOptionHolder.sheriffMisfireKills.getSelection();
            cooldown = CustomOptionHolder.sheriffCooldown.getFloat();
            canKillNeutrals = CustomOptionHolder.sheriffCanKillNeutrals.getBool();
            canKillArsonist = CustomOptionHolder.sheriffCanKillArsonist.getBool();
            canKillLawyer = CustomOptionHolder.sheriffCanKillLawyer.getBool();
            canKillJester = CustomOptionHolder.sheriffCanKillJester.getBool();
            canKillPursuer = CustomOptionHolder.sheriffCanKillPursuer.getBool();
            canKillVulture = CustomOptionHolder.sheriffCanKillVulture.getBool();
            canKillThief = CustomOptionHolder.sheriffCanKillThief.getBool();
            canKillAmnesiac = CustomOptionHolder.sheriffCanKillAmnesiac.getBool();
            canKillProsecutor = CustomOptionHolder.sheriffCanKillProsecutor.getBool();
            spyCanDieToSheriff = CustomOptionHolder.spyCanDieToSheriff.getBool();
        }
    }
