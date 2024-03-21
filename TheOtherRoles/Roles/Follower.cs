using System.Collections.Generic;
using TheOtherRoles.Objects;
using UnityEngine;

namespace TheOtherRoles;


    public static class Follower {
        public static PlayerControl follower;
        public static PlayerControl currentTarget;
        public static Color color = Palette.ImpostorRed;
        public static List<Arrow> localArrows = new List<Arrow>();
        public static bool getsAssassin = false;
        public static bool chatTarget = true;
        public static bool chatTarget2 = true;

        public static void clearAndReload() {
            if (localArrows != null) {
                foreach (Arrow arrow in localArrows)
                    if (arrow?.arrow != null)
                        UnityEngine.Object.Destroy(arrow.arrow);
            }
            localArrows = new List<Arrow>();
            follower = null;
            currentTarget = null;
            chatTarget = true;
            chatTarget2 = true;
            getsAssassin = CustomOptionHolder.modifierAssassinCultist.getBool();
        }
    }