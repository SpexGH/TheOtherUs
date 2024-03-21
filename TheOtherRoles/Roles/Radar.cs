using System.Collections.Generic;
using TheOtherRoles.Objects;
using UnityEngine;

namespace TheOtherRoles;

public static class Radar {
    public static PlayerControl radar;
    public static List<Arrow> localArrows = new List<Arrow>();
    public static PlayerControl ClosestPlayer;
    public static Color color = new Color32(255, 0, 128, byte.MaxValue);
    public static bool showArrows = true;
        


    public static void clearAndReload() {
        radar = null;
        showArrows = true;
        if (localArrows != null) {
            foreach (Arrow arrow in localArrows)
                if (arrow?.arrow != null)
                    UnityEngine.Object.Destroy(arrow.arrow);
        }
        localArrows = new List<Arrow>();
    }
}