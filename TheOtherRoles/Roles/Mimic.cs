using System.Collections.Generic;
using UnityEngine;

namespace TheOtherRoles;

public static class Mimic
{
    public static PlayerControl mimic;
    public static bool hasMimic = false;
    public static Color color = Palette.ImpostorRed;
    public static List<PlayerControl> killed = new List<PlayerControl>();



    public static void clearAndReload(bool clearList = true)
    {
        mimic = null;
        if (clearList) hasMimic = false;

    }
}