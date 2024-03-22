using UnityEngine;

namespace TheOtherRoles.Roles.Crewmate;

public class Crew
{
    public static PlayerControl crew;
    public static Color color = Palette.White;

    public void clearAndReload()
    {
        crew = null;
    }
}