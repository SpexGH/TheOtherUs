using System.Collections.Generic;
using TheOtherRoles.Objects;
using UnityEngine;

namespace TheOtherRoles;

public static class Follower
{
    public static PlayerControl follower;
    public static PlayerControl currentTarget;
    public static Color color = Palette.ImpostorRed;
    public static List<Arrow> localArrows = new();
    public static bool getsAssassin;
    public static bool chatTarget = true;
    public static bool chatTarget2 = true;

    public static void clearAndReload()
    {
        if (localArrows != null)
            foreach (var arrow in localArrows)
                if (arrow?.arrow != null)
                    Object.Destroy(arrow.arrow);
        localArrows = new List<Arrow>();
        follower = null;
        currentTarget = null;
        chatTarget = true;
        chatTarget2 = true;
        getsAssassin = CustomOptionHolder.modifierAssassinCultist.getBool();
    }
}