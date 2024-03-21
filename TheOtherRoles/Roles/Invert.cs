using System.Collections.Generic;

namespace TheOtherRoles;

public static class Invert {
    public static List<PlayerControl> invert = new List<PlayerControl>();
    public static int meetings = 3;

    public static void clearAndReload() {
        invert = new List<PlayerControl>();
        meetings = (int) CustomOptionHolder.modifierInvertDuration.getFloat();
    }
}