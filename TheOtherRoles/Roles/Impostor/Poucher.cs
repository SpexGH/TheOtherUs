using System.Collections.Generic;
using UnityEngine;

namespace TheOtherRoles;

public static class Poucher
{
    public static PlayerControl poucher;
    public static Color color = Palette.ImpostorRed;
    public static List<PlayerControl> killed = new();


    public static void clearAndReload(bool clearList = true)
    {
        poucher = null;
        if (clearList) killed = new List<PlayerControl>();
    }
}