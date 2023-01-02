using System.Collections.Generic;
using UnityEngine;
using TheOtherRoles.Players;

namespace TheOtherRoles{
    static class MapOptions {
        // Set values
        public static int maxNumberOfMeetings = 10;
        public static bool blockSkippingInEmergencyMeetings = false;
        public static bool noVoteIsSelfVote = false;
        public static bool hidePlayerNames = false;
        public static bool ghostsSeeRoles = true;
        public static bool ghostsSeeModifier = true;
        public static bool ghostsSeeTasks = true;
        public static bool ghostsSeeVotes = true;
        public static bool showRoleSummary = true;
        public static bool allowParallelMedBayScans = false;
        public static bool showLighterDarker = false;
        public static bool toggleCursor = true;
        public static bool showKillAnimation = true;
        public static bool camoComms = false;

        public static int restrictDevices = 0;
        public static float restrictAdminTime = 600f;
        public static float restrictAdminTimeMax = 600f;
        public static float restrictCamerasTime = 600f;
        public static float restrictCamerasTimeMax = 600f;
        public static float restrictVitalsTime = 600f;
        public static float restrictVitalsTimeMax = 600f;

        public static bool enableHorseMode = false;
        public static bool shieldFirstKill = false;
        public static bool nightVision = false;
        public static bool hideVentAnim = false;
    //    public static bool shakeScreenReactor = false;
        public static bool impostorSeeRoles = false;
        public static bool transparentTasks = false;
        public static CustomGamemodes gameMode = CustomGamemodes.Classic;

        // Updating values
        public static int meetingsCount = 0;
        public static List<GameObject> nightOverlay = new List<GameObject>();
        public static bool canNightOverlay = true;
        public static bool removeNightOverlay = true;
        public static bool isLightsOut = false;
        public static List<SurvCamera> camerasToAdd = new List<SurvCamera>();
        public static List<Vent> ventsToSeal = new List<Vent>();
        public static Dictionary<byte, PoolablePlayer> playerIcons = new Dictionary<byte, PoolablePlayer>();
        public static string firstKillName;
        public static PlayerControl firstKillPlayer;

        public static void clearAndReloadMapOptions() {
            meetingsCount = 0;
            nightOverlay = new List<GameObject>();
            canNightOverlay = true;
            removeNightOverlay = true;
            isLightsOut = false;
            camerasToAdd = new List<SurvCamera>();
            ventsToSeal = new List<Vent>();
            playerIcons = new Dictionary<byte, PoolablePlayer>(); ;

            maxNumberOfMeetings = Mathf.RoundToInt(CustomOptionHolder.maxNumberOfMeetings.getSelection());
            blockSkippingInEmergencyMeetings = CustomOptionHolder.blockSkippingInEmergencyMeetings.getBool();
            noVoteIsSelfVote = CustomOptionHolder.noVoteIsSelfVote.getBool();
            hidePlayerNames = CustomOptionHolder.hidePlayerNames.getBool();
            allowParallelMedBayScans = CustomOptionHolder.allowParallelMedBayScans.getBool();
            shieldFirstKill = CustomOptionHolder.shieldFirstKill.getBool();
            nightVision = CustomOptionHolder.nightVisionLightSabotage.getBool();
            hideVentAnim = CustomOptionHolder.hideVentAnimOnShadows.getBool();
      //      shakeScreenReactor = CustomOptionHolder.screenShakeReactorSabotage.getBool();
            impostorSeeRoles = CustomOptionHolder.impostorSeeRoles.getBool();
            transparentTasks = CustomOptionHolder.transparentTasks.getBool();
            firstKillPlayer = null;
            restrictDevices = CustomOptionHolder.restrictDevices.getSelection();
            restrictAdminTime = restrictAdminTimeMax = CustomOptionHolder.restrictAdmin.getFloat();
            restrictCamerasTime = restrictCamerasTimeMax = CustomOptionHolder.restrictCameras.getFloat();
            restrictVitalsTime = restrictVitalsTimeMax = CustomOptionHolder.restrictVents.getFloat();
            camoComms = CustomOptionHolder.enableCamoComms.getBool();

        }

        public static void reloadPluginOptions() {
            ghostsSeeRoles = TheOtherRolesPlugin.GhostsSeeRoles.Value;
            ghostsSeeModifier = TheOtherRolesPlugin.GhostsSeeModifier.Value;
            ghostsSeeTasks = TheOtherRolesPlugin.GhostsSeeTasks.Value;
            ghostsSeeVotes = TheOtherRolesPlugin.GhostsSeeVotes.Value;
            showRoleSummary = TheOtherRolesPlugin.ShowRoleSummary.Value;
            showLighterDarker = TheOtherRolesPlugin.ShowLighterDarker.Value;
            toggleCursor = TheOtherRolesPlugin.ToggleCursor.Value;
            showKillAnimation = TheOtherRolesPlugin.showKillAnimation.Value;

            enableHorseMode = TheOtherRolesPlugin.EnableHorseMode.Value;
            Patches.ShouldAlwaysHorseAround.isHorseMode = TheOtherRolesPlugin.EnableHorseMode.Value;
        }

        public static void resetDeviceTimes() {
            restrictAdminTime = restrictAdminTimeMax;
            restrictCamerasTime = restrictCamerasTimeMax;
            restrictVitalsTime = restrictVitalsTimeMax;
        }

        public static bool canUseAdmin  { get { return restrictDevices == 0 || restrictAdminTime > 0f || CachedPlayer.LocalPlayer.PlayerControl == Hacker.hacker || CachedPlayer.LocalPlayer.Data.IsDead; }}

        public static bool couldUseAdmin { get { return restrictDevices == 0 || restrictAdminTimeMax > 0f  || CachedPlayer.LocalPlayer.PlayerControl == Hacker.hacker || CachedPlayer.LocalPlayer.Data.IsDead; }}

        public static bool canUseCameras {get { return restrictDevices == 0 || restrictCamerasTime > 0f || CachedPlayer.LocalPlayer.PlayerControl == Hacker.hacker || CachedPlayer.LocalPlayer.Data.IsDead; }}

        public static bool couldUseCameras { get { return restrictDevices == 0 || restrictCamerasTimeMax > 0f || CachedPlayer.LocalPlayer.PlayerControl == Hacker.hacker || CachedPlayer.LocalPlayer.Data.IsDead; }}

        public static bool canUseVitals { get { return restrictDevices == 0 || restrictVitalsTime > 0f || CachedPlayer.LocalPlayer.PlayerControl == Hacker.hacker || CachedPlayer.LocalPlayer.Data.IsDead; }}

        public static bool couldUseVitals { get { return restrictDevices == 0 || restrictVitalsTimeMax > 0f || CachedPlayer.LocalPlayer.PlayerControl == Hacker.hacker || CachedPlayer.LocalPlayer.Data.IsDead; }}

    }
}
