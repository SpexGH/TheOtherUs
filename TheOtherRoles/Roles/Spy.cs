using UnityEngine;

namespace TheOtherRoles;

public static class Spy {
    public static PlayerControl spy;
    public static Color color = Palette.ImpostorRed;

    public static bool impostorsCanKillAnyone = true;
    public static bool canEnterVents = false;
    public static bool hasImpostorVision = false;

    public static void clearAndReload() {
        spy = null;
        impostorsCanKillAnyone = CustomOptionHolder.spyImpostorsCanKillAnyone.getBool();
        canEnterVents = CustomOptionHolder.spyCanEnterVents.getBool();
        hasImpostorVision = CustomOptionHolder.spyHasImpostorVision.getBool();
    }
}