using System.Collections.Generic;

namespace TheOtherRoles;

public static class Sunglasses {
    public static List<PlayerControl> sunglasses = new List<PlayerControl>();
    public static int vision = 1;

    public static void clearAndReload() {
        sunglasses = new List<PlayerControl>();
        vision = CustomOptionHolder.modifierSunglassesVision.getSelection() + 1;
    }
}