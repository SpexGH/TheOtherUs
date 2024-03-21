using System.Collections.Generic;
using UnityEngine;

namespace TheOtherRoles;

public static class Bait {
    public static List<PlayerControl> bait = new List<PlayerControl>();
    public static Dictionary<DeadPlayer, float> active = new Dictionary<DeadPlayer, float>();
    public static Color color = new Color32(0, 247, 255, byte.MaxValue);

    public static float reportDelayMin = 0f;
    public static float reportDelayMax = 0f;
    public static bool showKillFlash = true;

    public static void clearAndReload() {
        bait = new List<PlayerControl>();
        active = new Dictionary<DeadPlayer, float>();
        reportDelayMin = CustomOptionHolder.modifierBaitReportDelayMin.getFloat();
        reportDelayMax = CustomOptionHolder.modifierBaitReportDelayMax.getFloat();
        if (reportDelayMin > reportDelayMax) reportDelayMin = reportDelayMax;
        showKillFlash = CustomOptionHolder.modifierBaitShowKillFlash.getBool();
    }
}