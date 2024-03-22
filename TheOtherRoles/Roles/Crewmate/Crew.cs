using UnityEngine;

namespace TheOtherRoles.Roles.Crewmate;

[RegisterRole]
public class Crew : RoleBase
{
    public Color color = Palette.White;
    public PlayerControl crew;

    public void clearAndReload()
    {
        crew = null;
    }
}