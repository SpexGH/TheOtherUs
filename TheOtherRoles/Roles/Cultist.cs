using System.Collections.Generic;
using TheOtherRoles.Objects;
using UnityEngine;

namespace TheOtherRoles;


    public static class Cultist {
        public static PlayerControl cultist;
        public static PlayerControl currentTarget;
        public static Color color = Palette.ImpostorRed;
        public static List<Arrow> localArrows = new List<Arrow>();
        public static bool chatTarget = true;
        public static bool chatTarget2 = true;
        public static bool isCultistGame = false;
        public static bool needsFollower = true;
        //      public static PlayerControl currentFollower;
        public static Sprite buttonSprite;


        public static Sprite getSidekickButtonSprite() {
            if (buttonSprite) return buttonSprite;
            buttonSprite = Helpers.loadSpriteFromResources("TheOtherRoles.Resources.SidekickButton.png", 115f);
            return buttonSprite;
        }

        public static void clearAndReload() {
            if (localArrows != null) {
                foreach (Arrow arrow in localArrows)
                    if (arrow?.arrow != null)
                        UnityEngine.Object.Destroy(arrow.arrow);
            }
            localArrows = new List<Arrow>();
            cultist = null;
            currentTarget = null;
            //            currentFollower = null;
            needsFollower = true;
            chatTarget = true;
            chatTarget2 = true;
        }
    }