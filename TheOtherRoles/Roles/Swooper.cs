using UnityEngine;

namespace TheOtherRoles;

public static class Swooper
{
    public static PlayerControl swooper;
    public static Color color = new Color32(224, 197, 219, byte.MaxValue);


    public static void clearAndReload()
    {
        swooper = null;
    }
}