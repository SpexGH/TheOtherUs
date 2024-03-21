using UnityEngine;

namespace TheOtherRoles;

public static partial class TheOtherRoles
{
    public static class Detective {
        public static PlayerControl detective;
        public static Color color = new Color32(8, 180, 180, byte.MaxValue);

        public static float footprintIntervall = 1f;
        public static float footprintDuration = 1f;
        public static bool anonymousFootprints = false;
        public static float reportNameDuration = 0f;
        public static float reportColorDuration = 20f;
        public static float timer = 6.2f;

        public static void clearAndReload() {
            detective = null;
            anonymousFootprints = CustomOptionHolder.detectiveAnonymousFootprints.getBool();
            footprintIntervall = CustomOptionHolder.detectiveFootprintIntervall.getFloat();
            footprintDuration = CustomOptionHolder.detectiveFootprintDuration.getFloat();
            reportNameDuration = CustomOptionHolder.detectiveReportNameDuration.getFloat();
            reportColorDuration = CustomOptionHolder.detectiveReportColorDuration.getFloat();
            timer = 6.2f;
        }
    }
}