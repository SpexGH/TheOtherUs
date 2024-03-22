using UnityEngine;

namespace TheOtherRoles.Roles.Crewmate;

public class Crew
{
    public PlayerControl crew;
    public Color color = Palette.White;

    public void clearAndReload()
    {
        crew = null;
    }
}