using UnityEngine;

namespace TheOtherRoles;


public static class Crew {
    public static PlayerControl crew;
    public static Color color = Palette.White;
    public static void clearAndReload() {
        crew = null;
    } 
}