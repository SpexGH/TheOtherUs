using UnityEngine;

namespace TheOtherRoles;

public static class Tunneler
{
    public static PlayerControl tunneler;
    public static Color color = new Color32(48, 21, 89, byte.MaxValue);


    public static void clearAndReload()
    {
        tunneler = null;
    }
}