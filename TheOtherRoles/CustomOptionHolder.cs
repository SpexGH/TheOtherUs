using System.Collections.Generic;
using UnityEngine;
using static TheOtherRoles.TheOtherRoles;
using Types = TheOtherRoles.CustomOption.CustomOptionType;

namespace TheOtherRoles;

public class CustomOptionHolder
{
    public static string[] rates = ["0%", "10%", "20%", "30%", "40%", "50%", "60%", "70%", "80%", "90%", "100%"];
    public static string[] ratesModifier = ["1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15"];
    public static string[] presets = ["Preset 1", "Preset 2", "Preset 3", "Random Preset Skeld", "Random Preset Mira HQ", "Random Preset Polus", "Random Preset Airship", "Random Preset Fungle", "Random Preset Submerged"];

    public static CustomOption presetSelection;
    public static CustomOption activateRoles;
    public static CustomOption crewmateRolesCountMin;
    public static CustomOption crewmateRolesCountMax;
    public static CustomOption crewmateRolesFill;
    public static CustomOption neutralRolesCountMin;
    public static CustomOption neutralRolesCountMax;
    public static CustomOption impostorRolesCountMin;
    public static CustomOption impostorRolesCountMax;
    public static CustomOption modifiersCountMin;
    public static CustomOption modifiersCountMax;

    public static CustomOption anyPlayerCanStopStart;

    //public static CustomOption enableCodenameHorsemode;
    //public static CustomOption enableCodenameDisableHorses;
    public static CustomOption enableEventMode;

    public static CustomOption cultistSpawnRate;

    public static CustomOption minerSpawnRate;
    public static CustomOption minerCooldown;
    public static CustomOption mafiaSpawnRate;
    public static CustomOption janitorCooldown;

    public static CustomOption yoyoSpawnRate;
    public static CustomOption yoyoBlinkDuration;
    public static CustomOption yoyoMarkCooldown;
    public static CustomOption yoyoMarkStaysOverMeeting;
    public static CustomOption yoyoHasAdminTable;
    public static CustomOption yoyoAdminTableCooldown;
    public static CustomOption yoyoSilhouetteVisibility;

    public static CustomOption morphlingSpawnRate;
    public static CustomOption morphlingCooldown;
    public static CustomOption morphlingDuration;

    public static CustomOption bomber2SpawnRate;
    public static CustomOption bomber2BombCooldown;
    public static CustomOption bomber2Delay;
    public static CustomOption bomber2Timer;
    //public static CustomOption bomber2HotPotatoMode;

    public static CustomOption undertakerSpawnRate;
    public static CustomOption undertakerDragingDelaiAfterKill;
    public static CustomOption undertakerDragingAfterVelocity;
    public static CustomOption undertakerCanDragAndVent;

    public static CustomOption camouflagerSpawnRate;
    public static CustomOption camouflagerCooldown;
    public static CustomOption camouflagerDuration;

    public static CustomOption vampireSpawnRate;
    public static CustomOption vampireKillDelay;
    public static CustomOption vampireCooldown;
    public static CustomOption vampireGarlicButton;
    public static CustomOption vampireCanKillNearGarlics;

    public static CustomOption poucherSpawnRate;
    public static CustomOption mimicSpawnRate;

    public static CustomOption eraserSpawnRate;
    public static CustomOption eraserCooldown;
    public static CustomOption eraserCanEraseAnyone;

    public static CustomOption guesserSpawnRate;
    public static CustomOption guesserIsImpGuesserRate;
    public static CustomOption guesserNumberOfShots;
    public static CustomOption guesserHasMultipleShotsPerMeeting;
    public static CustomOption guesserShowInfoInGhostChat;
    public static CustomOption guesserKillsThroughShield;
    public static CustomOption guesserEvilCanKillSpy;
    public static CustomOption guesserEvilCanKillCrewmate;
    public static CustomOption guesserSpawnBothRate;
    public static CustomOption guesserCantGuessSnitchIfTaksDone;

    public static CustomOption jesterSpawnRate;
    public static CustomOption jesterCanCallEmergency;
    public static CustomOption jesterCanVent;
    public static CustomOption jesterHasImpostorVision;

    public static CustomOption amnisiacSpawnRate;
    public static CustomOption amnisiacShowArrows;
    public static CustomOption amnisiacResetRole;

    public static CustomOption arsonistSpawnRate;
    public static CustomOption arsonistCooldown;
    public static CustomOption arsonistDuration;

    public static CustomOption jackalSpawnRate;
    public static CustomOption jackalKillCooldown;
    public static CustomOption jackalChanceSwoop;
    public static CustomOption swooperCooldown;
    public static CustomOption swooperDuration;
    public static CustomOption jackalCreateSidekickCooldown;
    public static CustomOption jackalImpostorCanFindSidekick;
    public static CustomOption jackalKillFakeImpostor;
    public static CustomOption jackalCanUseVents;
    public static CustomOption jackalCanUseSabo;
    public static CustomOption jackalCanCreateSidekick;
    public static CustomOption sidekickPromotesToJackal;
    public static CustomOption sidekickCanKill;
    public static CustomOption sidekickCanUseVents;
    public static CustomOption jackalPromotedFromSidekickCanCreateSidekick;
    public static CustomOption jackalCanCreateSidekickFromImpostor;
    public static CustomOption jackalAndSidekickHaveImpostorVision;

    public static CustomOption bountyHunterSpawnRate;
    public static CustomOption bountyHunterBountyDuration;
    public static CustomOption bountyHunterReducedCooldown;
    public static CustomOption bountyHunterPunishmentTime;
    public static CustomOption bountyHunterShowArrow;
    public static CustomOption bountyHunterArrowUpdateIntervall;

    public static CustomOption witchSpawnRate;
    public static CustomOption witchCooldown;
    public static CustomOption witchAdditionalCooldown;
    public static CustomOption witchCanSpellAnyone;
    public static CustomOption witchSpellCastingDuration;
    public static CustomOption witchTriggerBothCooldowns;
    public static CustomOption witchVoteSavesTargets;

    public static CustomOption ninjaSpawnRate;
    public static CustomOption ninjaCooldown;
    public static CustomOption ninjaKnowsTargetLocation;
    public static CustomOption ninjaTraceTime;
    public static CustomOption ninjaTraceColorTime;
    public static CustomOption ninjaInvisibleDuration;

    public static CustomOption blackmailerSpawnRate;
    public static CustomOption blackmailerCooldown;

    public static CustomOption mayorSpawnRate;
    public static CustomOption mayorCanSeeVoteColors;
    public static CustomOption mayorTasksNeededToSeeVoteColors;
    public static CustomOption mayorMeetingButton;
    public static CustomOption mayorMaxRemoteMeetings;
    public static CustomOption mayorChooseSingleVote;

    public static CustomOption portalmakerSpawnRate;
    public static CustomOption portalmakerCooldown;
    public static CustomOption portalmakerUsePortalCooldown;
    public static CustomOption portalmakerLogOnlyColorType;
    public static CustomOption portalmakerLogHasTime;
    public static CustomOption portalmakerCanPortalFromAnywhere;

    public static CustomOption engineerSpawnRate;
    public static CustomOption engineerRemoteFix;
    //public static CustomOption engineerExpertRepairs;
    public static CustomOption engineerResetFixAfterMeeting;
    public static CustomOption engineerNumberOfFixes;
    public static CustomOption engineerHighlightForImpostors;
    public static CustomOption engineerHighlightForTeamJackal;

    public static CustomOption privateInvestigatorSpawnRate;
    public static CustomOption privateInvestigatorSeeColor;

    public static CustomOption sheriffSpawnRate;
    public static CustomOption sheriffMisfireKills;
    public static CustomOption sheriffCooldown;
    public static CustomOption sheriffCanKillNeutrals;
    public static CustomOption sheriffCanKillArsonist;
    public static CustomOption sheriffCanKillLawyer;
    public static CustomOption sheriffCanKillProsecutor;
    public static CustomOption sheriffCanKillJester;
    public static CustomOption sheriffCanKillVulture;
    public static CustomOption sheriffCanKillThief;
    public static CustomOption sheriffCanKillAmnesiac;
    public static CustomOption sheriffCanKillPursuer;
    public static CustomOption deputySpawnRate;

    public static CustomOption deputyNumberOfHandcuffs;
    public static CustomOption deputyHandcuffCooldown;
    public static CustomOption deputyGetsPromoted;
    public static CustomOption deputyKeepsHandcuffs;
    public static CustomOption deputyHandcuffDuration;
    public static CustomOption deputyKnowsSheriff;

    public static CustomOption lighterSpawnRate;
    public static CustomOption lighterModeLightsOnVision;
    public static CustomOption lighterModeLightsOffVision;
    public static CustomOption lighterFlashlightWidth;

    public static CustomOption detectiveSpawnRate;
    public static CustomOption detectiveAnonymousFootprints;
    public static CustomOption detectiveFootprintIntervall;
    public static CustomOption detectiveFootprintDuration;
    public static CustomOption detectiveReportNameDuration;
    public static CustomOption detectiveReportColorDuration;

    public static CustomOption timeMasterSpawnRate;
    public static CustomOption timeMasterCooldown;
    public static CustomOption timeMasterRewindTime;
    public static CustomOption timeMasterShieldDuration;

    public static CustomOption veterenSpawnRate;
    public static CustomOption veterenCooldown;
    public static CustomOption veterenAlertDuration;

    public static CustomOption medicSpawnRate;
    public static CustomOption medicShowShielded;
    public static CustomOption medicShowAttemptToShielded;
    public static CustomOption medicSetOrShowShieldAfterMeeting;
    public static CustomOption medicShowAttemptToMedic;
    public static CustomOption medicSetShieldAfterMeeting;
    public static CustomOption medicBreakShield;
    public static CustomOption medicResetTargetAfterMeeting;

    public static CustomOption swapperSpawnRate;
    public static CustomOption swapperCanCallEmergency;
    public static CustomOption swapperCanFixSabotages;
    public static CustomOption swapperCanOnlySwapOthers;
    public static CustomOption swapperSwapsNumber;
    public static CustomOption swapperRechargeTasksNumber;

    public static CustomOption seerSpawnRate;
    public static CustomOption seerMode;
    public static CustomOption seerSoulDuration;
    public static CustomOption seerLimitSoulDuration;

    public static CustomOption hackerSpawnRate;
    public static CustomOption hackerCooldown;
    public static CustomOption hackerHackeringDuration;
    public static CustomOption hackerOnlyColorType;
    public static CustomOption hackerToolsNumber;
    public static CustomOption hackerRechargeTasksNumber;
    public static CustomOption hackerNoMove;

    public static CustomOption trackerSpawnRate;
    public static CustomOption trackerUpdateIntervall;
    public static CustomOption trackerResetTargetAfterMeeting;
    public static CustomOption trackerCanTrackCorpses;
    public static CustomOption trackerCorpsesTrackingCooldown;
    public static CustomOption trackerCorpsesTrackingDuration;
    public static CustomOption trackerTrackingMethod;
    /*
    public static CustomOption snitchSpawnRate;
    public static CustomOption snitchLeftTasksForReveal;
    public static CustomOption snitchMode;
    public static CustomOption snitchTargets;
    */
    public static CustomOption snitchSpawnRate;
    public static CustomOption snitchLeftTasksForReveal;
    public static CustomOption snitchSeeMeeting;
    public static CustomOption snitchCanSeeRoles;
    public static CustomOption snitchIncludeNeutralTeam;
    public static CustomOption snitchTeamNeutraUseDifferentArrowColor;

    public static CustomOption spySpawnRate;
    public static CustomOption spyCanDieToSheriff;
    public static CustomOption spyImpostorsCanKillAnyone;
    public static CustomOption spyCanEnterVents;
    public static CustomOption spyHasImpostorVision;

    public static CustomOption tricksterSpawnRate;
    public static CustomOption tricksterPlaceBoxCooldown;
    public static CustomOption tricksterLightsOutCooldown;
    public static CustomOption tricksterLightsOutDuration;

    public static CustomOption cleanerSpawnRate;
    public static CustomOption cleanerCooldown;

    public static CustomOption warlockSpawnRate;
    public static CustomOption warlockCooldown;
    public static CustomOption warlockRootTime;

    public static CustomOption securityGuardSpawnRate;
    public static CustomOption securityGuardCooldown;
    public static CustomOption securityGuardTotalScrews;
    public static CustomOption securityGuardCamPrice;
    public static CustomOption securityGuardVentPrice;
    public static CustomOption securityGuardCamDuration;
    public static CustomOption securityGuardCamMaxCharges;
    public static CustomOption securityGuardCamRechargeTasksNumber;
    public static CustomOption securityGuardNoMove;

    public static CustomOption bodyGuardSpawnRate;
    public static CustomOption bodyGuardFlash;
    public static CustomOption bodyGuardResetTargetAfterMeeting;

    public static CustomOption vultureSpawnRate;
    public static CustomOption vultureCooldown;
    public static CustomOption vultureNumberToWin;
    public static CustomOption vultureCanUseVents;
    public static CustomOption vultureShowArrows;

    public static CustomOption mediumSpawnRate;
    public static CustomOption mediumCooldown;
    public static CustomOption mediumDuration;
    public static CustomOption mediumOneTimeUse;
    public static CustomOption mediumChanceAdditionalInfo;

    public static CustomOption lawyerSpawnRate;
    public static CustomOption lawyerTargetKnows;
    public static CustomOption lawyerIsProsecutorChance;
    public static CustomOption lawyerTargetCanBeJester;
    public static CustomOption lawyerVision;
    public static CustomOption lawyerKnowsRole;
    public static CustomOption lawyerCanCallEmergency;
    public static CustomOption pursuerCooldown;
    public static CustomOption pursuerBlanksNumber;

    public static CustomOption jumperSpawnRate;
    public static CustomOption jumperJumpTime;
    public static CustomOption jumperChargesOnPlace;
    public static CustomOption jumperResetPlaceAfterMeeting;
    //public static CustomOption jumperChargesGainOnMeeting;
    //public static CustomOption jumperMaxCharges;

    public static CustomOption escapistSpawnRate;
    public static CustomOption escapistEscapeTime;
    public static CustomOption escapistChargesOnPlace;
    public static CustomOption escapistResetPlaceAfterMeeting;
    //public static CustomOption escapistChargesGainOnMeeting;
    //public static CustomOption escapistMaxCharges;

    public static CustomOption werewolfSpawnRate;
    public static CustomOption werewolfRampageCooldown;
    public static CustomOption werewolfRampageDuration;
    public static CustomOption werewolfKillCooldown;

    public static CustomOption thiefSpawnRate;
    public static CustomOption thiefCooldown;
    public static CustomOption thiefHasImpVision;
    public static CustomOption thiefCanUseVents;
    public static CustomOption thiefCanKillSheriff;
    public static CustomOption thiefCanStealWithGuess;


    public static CustomOption trapperSpawnRate;
    public static CustomOption trapperCooldown;
    public static CustomOption trapperMaxCharges;
    public static CustomOption trapperRechargeTasksNumber;
    public static CustomOption trapperTrapNeededTriggerToReveal;
    public static CustomOption trapperAnonymousMap;
    public static CustomOption trapperInfoType;
    public static CustomOption trapperTrapDuration;

    public static CustomOption bomberSpawnRate;
    public static CustomOption terroristBombDestructionTime;
    public static CustomOption terroristBombDestructionRange;
    public static CustomOption terroristBombHearRange;
    public static CustomOption terroristDefuseDuration;
    public static CustomOption terroristBombCooldown;
    public static CustomOption terroristBombActiveAfter;

    public static CustomOption modifiersAreHidden;

    public static CustomOption modifierAssassin;
    public static CustomOption modifierAssassinQuantity;
    public static CustomOption modifierAssassinNumberOfShots;
    public static CustomOption modifierAssassinMultipleShotsPerMeeting;
    public static CustomOption modifierAssassinKillsThroughShield;
    public static CustomOption modifierAssassinCultist;

    public static CustomOption modifierBait;
    public static CustomOption modifierBaitQuantity;
    public static CustomOption modifierBaitReportDelayMin;
    public static CustomOption modifierBaitReportDelayMax;
    public static CustomOption modifierBaitShowKillFlash;

    public static CustomOption modifierAftermath;

    public static CustomOption modifierLover;
    public static CustomOption modifierLoverImpLoverRate;
    public static CustomOption modifierLoverBothDie;
    public static CustomOption modifierLoverEnableChat;

    public static CustomOption modifierBloody;
    public static CustomOption modifierBloodyQuantity;
    public static CustomOption modifierBloodyDuration;

    public static CustomOption modifierAntiTeleport;
    public static CustomOption modifierAntiTeleportQuantity;

    public static CustomOption modifierTieBreaker;

    public static CustomOption modifierSunglasses;
    public static CustomOption modifierSunglassesQuantity;
    public static CustomOption modifierSunglassesVision;

    public static CustomOption modifierTorch;
    public static CustomOption modifierTorchQuantity;
    public static CustomOption modifierTorchVision;

    public static CustomOption modifierFlash;
    public static CustomOption modifierFlashQuantity;
    public static CustomOption modifierFlashSpeed;

    public static CustomOption modifierMultitasker;
    public static CustomOption modifierMultitaskerQuantity;

    public static CustomOption modifierDisperser;
    public static CustomOption modifierDisperserCooldown;
    public static CustomOption modifierDisperserNumberOfUses;
    public static CustomOption modifierDisperserDispersesToVent;

    public static CustomOption modifierMini;
    public static CustomOption modifierMiniGrowingUpDuration;
    public static CustomOption modifierMiniGrowingUpInMeeting;

    public static CustomOption modifierIndomitable;

    public static CustomOption modifierBlind;

    public static CustomOption modifierTunneler;

    public static CustomOption modifierWatcher;

    public static CustomOption modifierRadar;

    public static CustomOption modifierSlueth;
    //public static CustomOption modifierSwooper;

    public static CustomOption modifierCursed;

    public static CustomOption modifierVip;
    public static CustomOption modifierVipQuantity;
    public static CustomOption modifierVipShowColor;

    public static CustomOption modifierInvert;
    public static CustomOption modifierInvertQuantity;
    public static CustomOption modifierInvertDuration;

    public static CustomOption modifierChameleon;
    public static CustomOption modifierChameleonQuantity;
    public static CustomOption modifierChameleonHoldDuration;
    public static CustomOption modifierChameleonFadeDuration;
    public static CustomOption modifierChameleonMinVisibility;


    public static CustomOption modifierShifter;

    //public static CustomOption preventTaskEnd; 
    public static CustomOption resteButtonCooldown;

    public static CustomOption maxNumberOfMeetings;
    public static CustomOption blockSkippingInEmergencyMeetings;
    public static CustomOption noVoteIsSelfVote;
    public static CustomOption hidePlayerNames;
    public static CustomOption showButtonTarget;
    public static CustomOption blockGameEnd;
    public static CustomOption allowParallelMedBayScans;
    public static CustomOption shieldFirstKill;
    public static CustomOption hideVentAnimOnShadows;
    public static CustomOption disableCamsRound1;
    public static CustomOption hideOutOfSightNametags;
    public static CustomOption impostorSeeRoles;
    public static CustomOption transparentTasks;
    public static CustomOption randomGameStartPosition;
    public static CustomOption randomGameStartToVents;
    public static CustomOption ShowVentsOnMap;
    public static CustomOption ShowVentsOnMeetingMap;
    public static CustomOption allowModGuess;
    public static CustomOption finishTasksBeforeHauntingOrZoomingOut;
    public static CustomOption camsNightVision;
    public static CustomOption camsNoNightVisionIfImpVision;
    public static CustomOption deadImpsBlockSabotage;

    public static CustomOption dynamicMap;
    public static CustomOption dynamicMapEnableSkeld;
    public static CustomOption dynamicMapEnableMira;
    public static CustomOption dynamicMapEnablePolus;
    public static CustomOption dynamicMapEnableAirShip;
    public static CustomOption dynamicMapEnableFungle;
    public static CustomOption dynamicMapEnableSubmerged;
    public static CustomOption dynamicMapSeparateSettings;

    public static CustomOption movePolusVents;
    public static CustomOption swapNavWifi;
    public static CustomOption movePolusVitals;
    public static CustomOption enableBetterPolus;
    public static CustomOption moveColdTemp;

    public static CustomOption disableMedbayWalk;

    public static CustomOption enableCamoComms;

    public static CustomOption restrictDevices;
    //public static CustomOption restrictAdmin;
    public static CustomOption restrictCameras;
    public static CustomOption restrictVents;

    //Guesser Gamemode
    public static CustomOption guesserGamemodeCrewNumber;
    public static CustomOption guesserGamemodeNeutralNumber;
    public static CustomOption guesserGamemodeImpNumber;
    public static CustomOption guesserForceJackalGuesser;
    public static CustomOption guesserGamemodeSidekickIsAlwaysGuesser;
    public static CustomOption guesserForceThiefGuesser;
    public static CustomOption guesserGamemodeHaveModifier;
    public static CustomOption guesserGamemodeNumberOfShots;
    public static CustomOption guesserGamemodeHasMultipleShotsPerMeeting;
    public static CustomOption guesserGamemodeKillsThroughShield;
    public static CustomOption guesserGamemodeEvilCanKillSpy;
    public static CustomOption guesserGamemodeCantGuessSnitchIfTaksDone;

    // Hide N Seek Gamemode
    public static CustomOption hideNSeekHunterCount;
    public static CustomOption hideNSeekKillCooldown;
    public static CustomOption hideNSeekHunterVision;
    public static CustomOption hideNSeekHuntedVision;
    public static CustomOption hideNSeekTimer;
    public static CustomOption hideNSeekCommonTasks;
    public static CustomOption hideNSeekShortTasks;
    public static CustomOption hideNSeekLongTasks;
    public static CustomOption hideNSeekTaskWin;
    public static CustomOption hideNSeekTaskPunish;
    public static CustomOption hideNSeekCanSabotage;
    public static CustomOption hideNSeekMap;
    public static CustomOption hideNSeekHunterWaiting;

    public static CustomOption hunterLightCooldown;
    public static CustomOption hunterLightDuration;
    public static CustomOption hunterLightVision;
    public static CustomOption hunterLightPunish;
    public static CustomOption hunterAdminCooldown;
    public static CustomOption hunterAdminDuration;
    public static CustomOption hunterAdminPunish;
    public static CustomOption hunterArrowCooldown;
    public static CustomOption hunterArrowDuration;
    public static CustomOption hunterArrowPunish;

    public static CustomOption huntedShieldCooldown;
    public static CustomOption huntedShieldDuration;
    public static CustomOption huntedShieldRewindTime;
    public static CustomOption huntedShieldNumber;

    // Prop Hunt Settings
    public static CustomOption propHuntMap;
    public static CustomOption propHuntTimer;
    public static CustomOption propHuntNumberOfHunters;
    public static CustomOption hunterInitialBlackoutTime;
    public static CustomOption hunterMissCooldown;
    public static CustomOption hunterHitCooldown;
    public static CustomOption hunterMaxMissesBeforeDeath;
    public static CustomOption propBecomesHunterWhenFound;
    public static CustomOption propHunterVision;
    public static CustomOption propVision;
    public static CustomOption propHuntRevealCooldown;
    public static CustomOption propHuntRevealDuration;
    public static CustomOption propHuntRevealPunish;
    public static CustomOption propHuntUnstuckCooldown;
    public static CustomOption propHuntUnstuckDuration;
    public static CustomOption propHuntInvisCooldown;
    public static CustomOption propHuntInvisDuration;
    public static CustomOption propHuntSpeedboostCooldown;
    public static CustomOption propHuntSpeedboostDuration;
    public static CustomOption propHuntSpeedboostSpeed;
    public static CustomOption propHuntSpeedboostEnabled;
    public static CustomOption propHuntInvisEnabled;
    public static CustomOption propHuntAdminCooldown;
    public static CustomOption propHuntFindCooldown;
    public static CustomOption propHuntFindDuration;

    internal static Dictionary<byte, byte[]> blockedRolePairings = new Dictionary<byte, byte[]>();

    public static string cs(Color c, string s)
    {
        return string.Format("<color=#{0:X2}{1:X2}{2:X2}{3:X2}>{4}</color>", ToByte(c.r), ToByte(c.g), ToByte(c.b), ToByte(c.a), s);
    }

    private static byte ToByte(float f)
    {
        f = Mathf.Clamp01(f);
        return (byte)(f * 255);
    }

    public static bool isMapSelectionOption(CustomOption option)
    {
        return option == propHuntMap && option == hideNSeekMap;
    }

    public static void Load()
    {

        CustomOption.vanillaSettings = TheOtherRolesPlugin.Instance.Config.Bind("Preset0", "VanillaOptions", "");

        // Role Options
        presetSelection = CustomOption.Create(0, Types.General, cs(new Color(204f / 255f, 204f / 255f, 0, 1f), "Preset"), presets, null, true);
        activateRoles = CustomOption.Create(1, Types.General, cs(new Color(204f / 255f, 204f / 255f, 0, 1f), "Enable Mod Roles And Block Vanilla Roles"), true, null, true);

        anyPlayerCanStopStart = CustomOption.Create(2, Types.General, cs(new Color(204f / 255f, 204f / 255f, 0, 1f), "Any Player Can Stop The Start"), false, null, false);

        if (Utilities.EventUtility.canBeEnabled) enableEventMode = CustomOption.Create(3, Types.General, cs(Color.green, "Enable Special Mode"), true, null, true);

        // Using new id's for the options to not break compatibilty with older versions
        crewmateRolesCountMin = CustomOption.Create(5, Types.General,
            cs(new Color(204f / 255f, 204f / 255f, 0, 1f), "Minimum Crewmate Roles"), 15f, 0f, 15f, 1f, null, true);
        crewmateRolesCountMax = CustomOption.Create(6, Types.General,
            cs(new Color(204f / 255f, 204f / 255f, 0, 1f), "Maximum Crewmate Roles"), 15f, 0f, 15f, 1f);
        crewmateRolesFill = CustomOption.Create(7, Types.General,
            cs(new Color(204f / 255f, 204f / 255f, 0, 1f), "Fill Crewmate Roles\n(Ignores Min/Max)"), false);
        neutralRolesCountMin = CustomOption.Create(8, Types.General,
            cs(new Color(204f / 255f, 204f / 255f, 0, 1f), "Minimum Neutral Roles"), 15f, 0f, 15f, 1f);
        neutralRolesCountMax = CustomOption.Create(9, Types.General,
            cs(new Color(204f / 255f, 204f / 255f, 0, 1f), "Maximum Neutral Roles"), 15f, 0f, 15f, 1f);
        impostorRolesCountMin = CustomOption.Create(10, Types.General,
            cs(new Color(204f / 255f, 204f / 255f, 0, 1f), "Minimum Impostor Roles"), 15f, 0f, 15f, 1f);
        impostorRolesCountMax = CustomOption.Create(11, Types.General,
            cs(new Color(204f / 255f, 204f / 255f, 0, 1f), "Maximum Impostor Roles"), 15f, 0f, 15f, 1f);
        modifiersCountMin = CustomOption.Create(12, Types.General,
            cs(new Color(204f / 255f, 204f / 255f, 0, 1f), "Minimum Modifiers"), 15f, 0f, 15f, 1f);
        modifiersCountMax = CustomOption.Create(13, Types.General,
            cs(new Color(204f / 255f, 204f / 255f, 0, 1f), "Maximum Modifiers"), 15f, 0f, 15f, 1f);

        //-------------------------- Other options 1 - 599 -------------------------- //

        resteButtonCooldown = CustomOption.Create(20, Types.General, "Game Start CoolDown", 10f, 2.5f, 30f, 2.5f, null, true);

        maxNumberOfMeetings = CustomOption.Create(21, Types.General, "Number Of Meetings (excluding Mayor meeting)", 10, 0, 15, 1, null, true);
        blockSkippingInEmergencyMeetings = CustomOption.Create(22, Types.General, "Block Skipping In Emergency Meetings", false);
        noVoteIsSelfVote = CustomOption.Create(23, Types.General, "No Vote Is Self Vote", false, blockSkippingInEmergencyMeetings);
        shieldFirstKill = CustomOption.Create(24, Types.General, "Shield Last Game First Kill", false);
        hidePlayerNames = CustomOption.Create(25, Types.General, "Hide Player Names", false);
        hideOutOfSightNametags = CustomOption.Create(26, Types.General, "Hide Obstructed Player Names", false);
        hideVentAnimOnShadows = CustomOption.Create(27, Types.General, "Hide Vent Animation Out Of Vision", false);
        showButtonTarget = CustomOption.Create(28, Types.General, "Show Button Target", true);
        impostorSeeRoles = CustomOption.Create(29, Types.General, "Impostors Can See The Roles Of Their Team", false);
        blockGameEnd = CustomOption.Create(30, Types.General, "Block Game End If Power Crew Is Alive", false);
        allowModGuess = CustomOption.Create(31, Types.General, "Allow Guessing Some Modifiers", false);

        transparentTasks = CustomOption.Create(32, Types.General, "Tasks Are Transparent", false, null, true);
        disableMedbayWalk = CustomOption.Create(33, Types.General, "Disable MedBay Animations", false);
        allowParallelMedBayScans = CustomOption.Create(34, Types.General, "Allow Parallel MedBay Scans", false);
        finishTasksBeforeHauntingOrZoomingOut = CustomOption.Create(35, Types.General, "Finish Tasks Before Haunting Or Zooming Out", true);
        //preventTaskEnd = CustomOption.Create(36, Types.General, "Prevent Task End Game", false);

        //Map options
        randomGameStartPosition = CustomOption.Create(50, Types.General, "Random Spawn Location", false, null, true);
        randomGameStartToVents = CustomOption.Create(51, Types.General, "Random Spawn To Vents", false, randomGameStartPosition);
        ShowVentsOnMap = CustomOption.Create(65, Types.General, "Show Vents On Map", false, null, true);
        ShowVentsOnMeetingMap = CustomOption.Create(66, Types.General, "Only show position of vents\n  during the meeting", true, ShowVentsOnMap);

        enableBetterPolus = CustomOption.Create(60, Types.General, "Enable Better Polus", false, null, true);
        movePolusVents = CustomOption.Create(61, Types.General, "Adjust Vents", false, enableBetterPolus, false);
        movePolusVitals = CustomOption.Create(62, Types.General, "Move Vitals To Labs", false, enableBetterPolus, false);
        swapNavWifi = CustomOption.Create(63, Types.General, "Swap Reboot And Chart Course", false, enableBetterPolus, false);
        moveColdTemp = CustomOption.Create(64, Types.General, "Move Cold Temp To Death Valley", false, enableBetterPolus, false);

        enableCamoComms = CustomOption.Create(101, Types.General, "Enable Camouflage Comms", false, null, false);
        restrictDevices = CustomOption.Create(102, Types.General, "Restrict Map Information", new string[] { "Off", "Per Round", "Per Game" }, null, false);
        //restrictAdmin = CustomOption.Create(103, Types.General, "Restrict Admin Table", 30f, 0f, 600f, 5f, restrictDevices);
        restrictCameras = CustomOption.Create(104, Types.General, "Restrict Cameras", 30f, 0f, 600f, 5f, restrictDevices);
        restrictVents = CustomOption.Create(105, Types.General, "Restrict Vitals", 30f, 0f, 600f, 5f, restrictDevices);
        disableCamsRound1 = CustomOption.Create(106, Types.General, "No Cameras First Round", false, null, false);
        camsNightVision = CustomOption.Create(107, Types.General, "Cams Switch To Night Vision If Lights Are Off", false, null, true);
        camsNoNightVisionIfImpVision = CustomOption.Create(108, Types.General, "Impostor Vision Ignores Night Vision Cams", false, camsNightVision, false);
        deadImpsBlockSabotage = CustomOption.Create(109, Types.General, cs(Palette.ImpostorRed, "Block Dead Impostor From Sabotaging"), false, null, false);

        dynamicMap = CustomOption.Create(120, Types.General, "Play On A Random Map", false, null, true);
        dynamicMapEnableSkeld = CustomOption.Create(121, Types.General, "Skeld", rates, dynamicMap, false);
        dynamicMapEnableMira = CustomOption.Create(122, Types.General, "Mira", rates, dynamicMap, false);
        dynamicMapEnablePolus = CustomOption.Create(123, Types.General, "Polus", rates, dynamicMap, false);
        dynamicMapEnableAirShip = CustomOption.Create(124, Types.General, "Airship", rates, dynamicMap, false);
        dynamicMapEnableFungle = CustomOption.Create(125, Types.General, "Fungle", rates, dynamicMap, false);
        dynamicMapEnableSubmerged = CustomOption.Create(126, Types.General, "Submerged", rates, dynamicMap, false);
        dynamicMapSeparateSettings = CustomOption.Create(127, Types.General, "Use Random Map Setting Presets", false, dynamicMap, false);

        //-------------------------- Impostor Options 10000-19999 -------------------------- //

        modifierAssassin = CustomOption.Create(10000, Types.Impostor, cs(Color.red, "Assassin"), rates, null, true);
        modifierAssassinQuantity = CustomOption.Create(10001, Types.Impostor, cs(Color.red, "Assassin Quantity"), ratesModifier, modifierAssassin);
        modifierAssassinNumberOfShots = CustomOption.Create(10002, Types.Impostor, "Number Of Shots", 5f, 1f, 15f, 1f, modifierAssassin);
        modifierAssassinMultipleShotsPerMeeting = CustomOption.Create(10003, Types.Impostor, "Can Shoot Multiple Times Per Meeting", true, modifierAssassin);
        guesserEvilCanKillSpy = CustomOption.Create(10004, Types.Impostor, "Can Guess The Spy", true, modifierAssassin);
        guesserEvilCanKillCrewmate = CustomOption.Create(10005, Types.Impostor, "Can Guess Crewmate", true, modifierAssassin);
        guesserCantGuessSnitchIfTaksDone = CustomOption.Create(10006, Types.Impostor, "Can't Guess Snitch When Revealed", true, modifierAssassin);
        modifierAssassinKillsThroughShield = CustomOption.Create(10007, Types.Impostor, "Guesses Ignore The Medic Shield", false, modifierAssassin);
        modifierAssassinCultist = CustomOption.Create(10008, Types.Impostor, "Cultist Follower Gets Ability", false, modifierAssassin);

        mafiaSpawnRate = CustomOption.Create(10010, Types.Impostor, cs(Janitor.color, "Mafia"), rates, null, true);
        janitorCooldown = CustomOption.Create(10011, Types.Impostor, "Janitor Cooldown", 30f, 10f, 60f, 2.5f, mafiaSpawnRate);

        morphlingSpawnRate = CustomOption.Create(10020, Types.Impostor, cs(Morphling.color, "Morphling"), rates, null, true);
        morphlingCooldown = CustomOption.Create(10021, Types.Impostor, "Morphling Cooldown", 30f, 10f, 60f, 2.5f, morphlingSpawnRate);
        morphlingDuration = CustomOption.Create(10022, Types.Impostor, "Morph Duration", 10f, 1f, 20f, 0.5f, morphlingSpawnRate);

        bomber2SpawnRate = CustomOption.Create(10030, Types.Impostor, cs(Bomber2.color, "Bomber [BETA]"), rates, null, true);
        bomber2BombCooldown = CustomOption.Create(10031, Types.Impostor, "Bomber2 Cooldown", 30f, 25f, 60f, 2.5f, bomber2SpawnRate);
        bomber2Delay = CustomOption.Create(10032, Types.Impostor, "Bomb Delay", 10f, 1f, 20f, 0.5f, bomber2SpawnRate);
        bomber2Timer = CustomOption.Create(10033, Types.Impostor, "Bomb Timer", 10f, 5f, 30f, 5f, bomber2SpawnRate);
        //bomber2HotPotatoMode = CustomOption.Create(10034, Types.Impostor, "Hot Potato Mode", false, bomber2SpawnRate);

        undertakerSpawnRate = CustomOption.Create(10040, Types.Impostor, cs(Undertaker.color, "Undertaker"), rates, null, true);
        undertakerDragingDelaiAfterKill = CustomOption.Create(10041, Types.Impostor, "Draging Delay After Kill", 0f, 0f, 15, 1f, undertakerSpawnRate);
        undertakerDragingAfterVelocity = CustomOption.Create(10042, Types.Impostor, "undertaker Drag Speed", 0.75f, 0.5f, 2f, 0.125f, undertakerSpawnRate);
        undertakerCanDragAndVent = CustomOption.Create(10043, Types.Impostor, "Can Vent While Dragging", true, undertakerSpawnRate);

        camouflagerSpawnRate = CustomOption.Create(10050, Types.Impostor, cs(Camouflager.color, "Camouflager"), rates, null, true);
        camouflagerCooldown = CustomOption.Create(10051, Types.Impostor, "Camouflager Cooldown", 30f, 10f, 60f, 2.5f, camouflagerSpawnRate);
        camouflagerDuration = CustomOption.Create(10052, Types.Impostor, "Camo Duration", 10f, 1f, 20f, 0.5f, camouflagerSpawnRate);

        vampireSpawnRate = CustomOption.Create(10060, Types.Impostor, cs(Vampire.color, "Vampire"), rates, null, true);
        vampireKillDelay = CustomOption.Create(10061, Types.Impostor, "Vampire Kill Delay", 10f, 1f, 20f, 1f, vampireSpawnRate);
        vampireCooldown = CustomOption.Create(10062, Types.Impostor, "Vampire Cooldown", 30f, 10f, 60f, 2.5f, vampireSpawnRate);
        vampireGarlicButton = CustomOption.Create(10063, Types.Impostor, "Enable Garlic", true, vampireSpawnRate);
        vampireCanKillNearGarlics = CustomOption.Create(10064, Types.Impostor, "Vampire Can Kill Near Garlics", true, vampireGarlicButton);

        eraserSpawnRate = CustomOption.Create(10070, Types.Impostor, cs(Eraser.color, "Eraser"), rates, null, true);
        eraserCooldown = CustomOption.Create(10071, Types.Impostor, "Eraser Cooldown", 30f, 10f, 120f, 5f, eraserSpawnRate);
        eraserCanEraseAnyone = CustomOption.Create(10072, Types.Impostor, "Eraser Can Erase Anyone", false, eraserSpawnRate);

        poucherSpawnRate = CustomOption.Create(10080, Types.Impostor, cs(Poucher.color, "Poucher"), rates, null, true);
        mimicSpawnRate = CustomOption.Create(10081, Types.Impostor, cs(Mimic.color, "Mimic"), rates, null, true);

        escapistSpawnRate = CustomOption.Create(10090, Types.Impostor, cs(Escapist.color, "Escapist"), rates, null, true);
        escapistEscapeTime = CustomOption.Create(10091, Types.Impostor, "Mark and Escape Cooldown", 30, 0, 60, 5, escapistSpawnRate);
        escapistChargesOnPlace = CustomOption.Create(10092, Types.Impostor, "Charges On Place", 1, 1, 10, 1, escapistSpawnRate);
        //escapistResetPlaceAfterMeeting = CustomOption.Create(10093, Types.Crewmate, "Reset Places After Meeting", true, jumperSpawnRate);
        //escapistChargesGainOnMeeting = CustomOption.Create(10094, Types.Crewmate, "Charges Gained After Meeting", 2, 0, 10, 1, jumperSpawnRate);
        //escapistMaxCharges = CustomOption.Create(10095, Types.Impostor, "Maximum Charges", 3, 0, 10, 1, escapistSpawnRate);

        cultistSpawnRate = CustomOption.Create(10100, Types.Impostor, cs(Cultist.color, "Cultist"), rates, null, true);

        tricksterSpawnRate = CustomOption.Create(10110, Types.Impostor, cs(Trickster.color, "Trickster"), rates, null, true);
        tricksterPlaceBoxCooldown = CustomOption.Create(10111, Types.Impostor, "Trickster Box Cooldown", 10f, 2.5f, 30f, 2.5f, tricksterSpawnRate);
        tricksterLightsOutCooldown = CustomOption.Create(10112, Types.Impostor, "Trickster Lights Out Cooldown", 30f, 10f, 60f, 5f, tricksterSpawnRate);
        tricksterLightsOutDuration = CustomOption.Create(10113, Types.Impostor, "Trickster Lights Out Duration", 15f, 5f, 60f, 2.5f, tricksterSpawnRate);

        cleanerSpawnRate = CustomOption.Create(10120, Types.Impostor, cs(Cleaner.color, "Cleaner"), rates, null, true);
        cleanerCooldown = CustomOption.Create(10121, Types.Impostor, "Cleaner Cooldown", 30f, 10f, 60f, 2.5f, cleanerSpawnRate);

        warlockSpawnRate = CustomOption.Create(10130, Types.Impostor, cs(Cleaner.color, "Warlock"), rates, null, true);
        warlockCooldown = CustomOption.Create(10131, Types.Impostor, "Warlock Cooldown", 30f, 10f, 60f, 2.5f, warlockSpawnRate);
        warlockRootTime = CustomOption.Create(10132, Types.Impostor, "Warlock Root Time", 5f, 0f, 15f, 1f, warlockSpawnRate);

        bountyHunterSpawnRate = CustomOption.Create(10140, Types.Impostor, cs(BountyHunter.color, "Bounty Hunter"), rates, null, true);
        bountyHunterBountyDuration = CustomOption.Create(10141, Types.Impostor, "Duration After Which Bounty Changes", 60f, 10f, 180f, 10f, bountyHunterSpawnRate);
        bountyHunterReducedCooldown = CustomOption.Create(10142, Types.Impostor, "Cooldown After Killing Bounty", 2.5f, 0f, 30f, 2.5f, bountyHunterSpawnRate);
        bountyHunterPunishmentTime = CustomOption.Create(10143, Types.Impostor, "Additional Cooldown After Killing Others", 20f, 0f, 60f, 2.5f, bountyHunterSpawnRate);
        bountyHunterShowArrow = CustomOption.Create(10144, Types.Impostor, "Show Arrow Pointing Towards The Bounty", true, bountyHunterSpawnRate);
        bountyHunterArrowUpdateIntervall = CustomOption.Create(10145, Types.Impostor, "Arrow Update Intervall", 15f, 2.5f, 60f, 2.5f, bountyHunterShowArrow);

        witchSpawnRate = CustomOption.Create(10150, Types.Impostor, cs(Witch.color, "Witch"), rates, null, true);
        witchCooldown = CustomOption.Create(10151, Types.Impostor, "Witch Spell Casting Cooldown", 30f, 10f, 120f, 5f, witchSpawnRate);
        witchAdditionalCooldown = CustomOption.Create(10152, Types.Impostor, "Witch Additional Cooldown", 10f, 0f, 60f, 5f, witchSpawnRate);
        witchCanSpellAnyone = CustomOption.Create(10153, Types.Impostor, "Witch Can Spell Anyone", false, witchSpawnRate);
        witchSpellCastingDuration = CustomOption.Create(10154, Types.Impostor, "Spell Casting Duration", 1f, 0f, 10f, 1f, witchSpawnRate);
        witchTriggerBothCooldowns = CustomOption.Create(10155, Types.Impostor, "Trigger Both Cooldowns", true, witchSpawnRate);
        witchVoteSavesTargets = CustomOption.Create(10156, Types.Impostor, "Voting The Witch Saves All The Targets", true, witchSpawnRate);

        ninjaSpawnRate = CustomOption.Create(10160, Types.Impostor, cs(Ninja.color, "Ninja"), rates, null, true);
        ninjaCooldown = CustomOption.Create(10161, Types.Impostor, "Ninja Mark Cooldown", 30f, 10f, 120f, 5f, ninjaSpawnRate);
        ninjaKnowsTargetLocation = CustomOption.Create(10162, Types.Impostor, "Ninja Knows Location Of Target", true, ninjaSpawnRate);
        ninjaTraceTime = CustomOption.Create(10163, Types.Impostor, "Trace Duration", 5f, 1f, 20f, 0.5f, ninjaSpawnRate);
        ninjaTraceColorTime = CustomOption.Create(10164, Types.Impostor, "Time Till Trace Color Has Faded", 2f, 0f, 20f, 0.5f, ninjaSpawnRate);
        ninjaInvisibleDuration = CustomOption.Create(10165, Types.Impostor, "Time The Ninja Is Invisible", 3f, 0f, 20f, 1f, ninjaSpawnRate);

        blackmailerSpawnRate = CustomOption.Create(10170, Types.Impostor, cs(Blackmailer.color, "Blackmailer"), rates, null, true);
        blackmailerCooldown = CustomOption.Create(10171, Types.Impostor, "Blackmail Cooldown", 30f, 5f, 120f, 5f, blackmailerSpawnRate);

        bomberSpawnRate = CustomOption.Create(10180, Types.Impostor, cs(Terrorist.color, "Terrorist"), rates, null, true);
        terroristBombDestructionTime = CustomOption.Create(10181, Types.Impostor, "Bomb Destruction Time", 20f, 2.5f, 120f, 2.5f, bomberSpawnRate);
        terroristBombDestructionRange = CustomOption.Create(10182, Types.Impostor, "Bomb Destruction Range", 50f, 5f, 150f, 5f, bomberSpawnRate);
        terroristBombHearRange = CustomOption.Create(10183, Types.Impostor, "Bomb Hear Range", 60f, 5f, 150f, 5f, bomberSpawnRate);
        terroristDefuseDuration = CustomOption.Create(10184, Types.Impostor, "Bomb Defuse Duration", 3f, 0.5f, 30f, 0.5f, bomberSpawnRate);
        terroristBombCooldown = CustomOption.Create(10185, Types.Impostor, "Bomb Cooldown", 15f, 2.5f, 30f, 2.5f, bomberSpawnRate);
        terroristBombActiveAfter = CustomOption.Create(10186, Types.Impostor, "Bomb Is Active After", 3f, 0.5f, 15f, 0.5f, bomberSpawnRate);

        minerSpawnRate = CustomOption.Create(10190, Types.Impostor, cs(Miner.color, "Miner"), rates, null, true);
        minerCooldown = CustomOption.Create(10191, Types.Impostor, "Mine Cooldown", 25f, 10f, 60f, 2.5f, minerSpawnRate);

        yoyoSpawnRate = CustomOption.Create(10200, Types.Impostor, cs(Yoyo.color, "Yo-Yo"), rates, null, true);
        yoyoBlinkDuration = CustomOption.Create(10201, Types.Impostor, "Blink Duration", 20f, 2.5f, 120f, 2.5f, yoyoSpawnRate);
        yoyoMarkCooldown = CustomOption.Create(10202, Types.Impostor, "Mark Location Cooldown", 20f, 2.5f, 120f, 2.5f, yoyoSpawnRate);
        yoyoMarkStaysOverMeeting = CustomOption.Create(10203, Types.Impostor, "Marked Location Stays After Meeting", true, yoyoSpawnRate);
        yoyoHasAdminTable = CustomOption.Create(10204, Types.Impostor, "Has Admin Table", true, yoyoSpawnRate);
        yoyoAdminTableCooldown = CustomOption.Create(10205, Types.Impostor, "Admin Table Cooldown", 20f, 2.5f, 120f, 2.5f, yoyoHasAdminTable);
        yoyoSilhouetteVisibility = CustomOption.Create(10206, Types.Impostor, "Silhouette Visibility", new string[] { "0%", "10%", "20%", "30%", "40%", "50%" }, yoyoSpawnRate);


        //-------------------------- Neutral Options 20000-29999 -------------------------- //

        jesterSpawnRate = CustomOption.Create(20000, Types.Neutral, cs(Jester.color, "Jester"), rates, null, true);
        jesterCanCallEmergency = CustomOption.Create(20001, Types.Neutral, "Jester Can Call Emergency Meeting", true, jesterSpawnRate);
        jesterCanVent = CustomOption.Create(20002, Types.Neutral, "Jester Can Hide In Vent", true, jesterSpawnRate);
        jesterHasImpostorVision = CustomOption.Create(20003, Types.Neutral, "Jester Has Impostor Vision", false, jesterSpawnRate);

        amnisiacSpawnRate = CustomOption.Create(20010, Types.Neutral, cs(Amnisiac.color, "Amnesiac"), rates, null, true);
        amnisiacShowArrows = CustomOption.Create(20011, Types.Neutral, "Show Arrows To Dead Bodies", true, amnisiacSpawnRate);
        amnisiacResetRole = CustomOption.Create(20012, Types.Neutral, "Reset Role When Taken", true, amnisiacSpawnRate);

        arsonistSpawnRate = CustomOption.Create(20030, Types.Neutral, cs(Arsonist.color, "Arsonist"), rates, null, true);
        arsonistCooldown = CustomOption.Create(20031, Types.Neutral, "Arsonist Cooldown", 12.5f, 2.5f, 60f, 2.5f, arsonistSpawnRate);
        arsonistDuration = CustomOption.Create(20032, Types.Neutral, "Arsonist Douse Duration", 3f, 1f, 10f, 1f, arsonistSpawnRate);

        jackalSpawnRate = CustomOption.Create(20040, Types.Neutral, cs(Jackal.color, "Jackal"), rates, null, true);
        jackalKillCooldown = CustomOption.Create(20041, Types.Neutral, "Jackal/Sidekick Kill Cooldown", 30f, 10f, 60f, 2.5f, jackalSpawnRate);
        jackalChanceSwoop = CustomOption.Create(20042, Types.Neutral, "Chance That Jackal Can Swoop", rates, jackalSpawnRate);
        swooperCooldown = CustomOption.Create(20043, Types.Neutral, "Swoop Cooldown", 30f, 10f, 60f, 2.5f, jackalChanceSwoop);
        swooperDuration = CustomOption.Create(20044, Types.Neutral, "Swoop Duration", 10f, 1f, 20f, 0.5f, jackalChanceSwoop);
        jackalCanUseVents = CustomOption.Create(20045, Types.Neutral, "Jackal Can Use Vents", true, jackalSpawnRate);
        jackalCanUseSabo = CustomOption.Create(20046, Types.Neutral, "Jackal Team Can Sabotage", false, jackalSpawnRate);
        jackalAndSidekickHaveImpostorVision = CustomOption.Create(20047, Types.Neutral, "Jackal And Sidekick Have Impostor Vision", false, jackalSpawnRate);
        jackalCanCreateSidekick = CustomOption.Create(20048, Types.Neutral, "Jackal Can Create A Sidekick", false, jackalSpawnRate);
        jackalCreateSidekickCooldown = CustomOption.Create(20049, Types.Neutral, "Jackal Create Sidekick Cooldown", 30f, 10f, 60f, 2.5f, jackalCanCreateSidekick);
        jackalImpostorCanFindSidekick = CustomOption.Create(20050, Types.Neutral, cs(Palette.ImpostorRed, "Impostors can see teammates turned Sidekick"), true, jackalCanCreateSidekick);
        sidekickCanKill = CustomOption.Create(20051, Types.Neutral, "Sidekick Can Kill", false, jackalCanCreateSidekick);
        sidekickCanUseVents = CustomOption.Create(20052, Types.Neutral, "Sidekick Can Use Vents", true, jackalCanCreateSidekick);
        sidekickPromotesToJackal = CustomOption.Create(20053, Types.Neutral, "Sidekick Gets Promoted To Jackal On Jackal Death", false, jackalCanCreateSidekick);
        jackalPromotedFromSidekickCanCreateSidekick = CustomOption.Create(20054, Types.Neutral, "Jackals Promoted From Sidekick Can Create A Sidekick", true, sidekickPromotesToJackal);
        jackalCanCreateSidekickFromImpostor = CustomOption.Create(20055, Types.Neutral, "Jackals Can Make An Impostor To His Sidekick", true, jackalCanCreateSidekick);
        jackalKillFakeImpostor = CustomOption.Create(20056, Types.Neutral, "Jackal Kills A Failed Sidekick Attempt", true, jackalCanCreateSidekick);

        vultureSpawnRate = CustomOption.Create(20060, Types.Neutral, cs(Vulture.color, "Vulture"), rates, null, true);
        vultureCooldown = CustomOption.Create(20061, Types.Neutral, "Vulture Cooldown", 15f, 10f, 60f, 2.5f, vultureSpawnRate);
        vultureNumberToWin = CustomOption.Create(20062, Types.Neutral, "Number Of Corpses Needed To Be Eaten", 4f, 1f, 10f, 1f, vultureSpawnRate);
        vultureCanUseVents = CustomOption.Create(20063, Types.Neutral, "Vulture Can Use Vents", true, vultureSpawnRate);
        vultureShowArrows = CustomOption.Create(20064, Types.Neutral, "Show Arrows Pointing Towards The Corpses", true, vultureSpawnRate);

        lawyerSpawnRate = CustomOption.Create(20070, Types.Neutral, cs(Lawyer.color, "Lawyer"), rates, null, true);
        lawyerIsProsecutorChance = CustomOption.Create(20071, Types.Neutral, "Chance That The Lawyer Is Prosecutor", rates, lawyerSpawnRate);
        lawyerTargetKnows = CustomOption.Create(20072, Types.Neutral, "Lawyer Target Knows", true, lawyerSpawnRate);
        lawyerVision = CustomOption.Create(20073, Types.Neutral, "Vision", 1f, 0.25f, 3f, 0.25f, lawyerSpawnRate);
        lawyerKnowsRole = CustomOption.Create(20074, Types.Neutral, "Lawyer/Prosecutor Knows Target Role", false, lawyerSpawnRate);
        lawyerCanCallEmergency = CustomOption.Create(20075, Types.Neutral, "Lawyer/Prosecutor Can Call Emergency Meeting", true, lawyerSpawnRate);
        lawyerTargetCanBeJester = CustomOption.Create(20076, Types.Neutral, "Lawyer Target Can Be The Jester", false, lawyerSpawnRate);
        pursuerCooldown = CustomOption.Create(20077, Types.Neutral, "Pursuer Blank Cooldown", 30f, 5f, 60f, 2.5f, lawyerSpawnRate);
        pursuerBlanksNumber = CustomOption.Create(20078, Types.Neutral, "Pursuer Number Of Blanks", 5f, 1f, 20f, 1f, lawyerSpawnRate);

        werewolfSpawnRate = CustomOption.Create(20080, Types.Neutral, cs(Werewolf.color, "Werewolf"), rates, null, true);
        werewolfRampageCooldown = CustomOption.Create(20081, Types.Neutral, "Rampage Cooldown", 30f, 10f, 60f, 2.5f, werewolfSpawnRate);
        werewolfRampageDuration = CustomOption.Create(20082, Types.Neutral, "Rampage Duration", 15f, 1f, 20f, 0.5f, werewolfSpawnRate);
        werewolfKillCooldown = CustomOption.Create(20083, Types.Neutral, "Kill Cooldown", 3f, 1f, 60f, 1f, werewolfSpawnRate);

        //-------------------------- Crewmate Options 30000-39999 -------------------------- //

        guesserSpawnRate = CustomOption.Create(30000, Types.Crewmate, cs(Guesser.color, "Vigilante"), rates, null, true);
        guesserNumberOfShots = CustomOption.Create(30001, Types.Crewmate, "Vigilante Number Of Shots", 5f, 1f, 15f, 1f, guesserSpawnRate);
        guesserHasMultipleShotsPerMeeting = CustomOption.Create(30002, Types.Crewmate, "Vigilante Can Shoot Multiple Times Per Meeting", true, guesserSpawnRate);
        guesserShowInfoInGhostChat = CustomOption.Create(30003, Types.Crewmate, "Guesses Visible In Ghost Chat", true, guesserSpawnRate);
        guesserKillsThroughShield = CustomOption.Create(30004, Types.Crewmate, "Guesses Ignore The Medic Shield", false, guesserSpawnRate);

        mayorSpawnRate = CustomOption.Create(30010, Types.Crewmate, cs(Mayor.color, "Mayor"), rates, null, true);
        mayorCanSeeVoteColors = CustomOption.Create(30011, Types.Crewmate, "Mayor Can See Vote Colors", false, mayorSpawnRate);
        mayorTasksNeededToSeeVoteColors = CustomOption.Create(30012, Types.Crewmate, "Completed Tasks Needed To See Vote Colors", 5f, 0f, 20f, 1f, mayorCanSeeVoteColors);
        mayorMeetingButton = CustomOption.Create(30013, Types.Crewmate, "Mobile Emergency Button", true, mayorSpawnRate);
        mayorMaxRemoteMeetings = CustomOption.Create(30014, Types.Crewmate, "Number Of Remote Meetings", 1f, 1f, 5f, 1f, mayorMeetingButton);
        mayorChooseSingleVote = CustomOption.Create(30015, Types.Crewmate, "Mayor Can Choose Single Vote", new string[] { "Off", "On (Before Voting)", "On (Until Meeting Ends)" }, mayorSpawnRate);

        engineerSpawnRate = CustomOption.Create(30020, Types.Crewmate, cs(Engineer.color, "Engineer"), rates, null, true);
        engineerRemoteFix = CustomOption.Create(30021, Types.Crewmate, "Enable Remote Fix", true, engineerSpawnRate);
        engineerResetFixAfterMeeting = CustomOption.Create(30022, Types.Crewmate, "Reset Fixes After Meeting", false, engineerRemoteFix);
        engineerNumberOfFixes = CustomOption.Create(30023, Types.Crewmate, "Number Of Sabotage Fixes", 1f, 1f, 3f, 1f, engineerRemoteFix);
        //engineerExpertRepairs = CustomOption.Create(30024, Types.Crewmate, "Advanced Sabotage Repair", false, engineerSpawnRate);
        engineerHighlightForImpostors = CustomOption.Create(30025, Types.Crewmate, "Impostors See Vents Highlighted", true, engineerSpawnRate);
        engineerHighlightForTeamJackal = CustomOption.Create(30026, Types.Crewmate, "Jackal and Sidekick See Vents Highlighted ", true, engineerSpawnRate);

        privateInvestigatorSpawnRate = CustomOption.Create(30030, Types.Crewmate, cs(PrivateInvestigator.color, "Detective"), rates, null, true);
        privateInvestigatorSeeColor = CustomOption.Create(30031, Types.Crewmate, "Can See Target Player Color", true, privateInvestigatorSpawnRate);

        sheriffSpawnRate = CustomOption.Create(30040, Types.Crewmate, cs(Sheriff.color, "Sheriff"), rates, null, true);
        sheriffCooldown = CustomOption.Create(30041, Types.Crewmate, "Sheriff Cooldown", 30f, 10f, 60f, 2.5f, sheriffSpawnRate);
        sheriffMisfireKills = CustomOption.Create(30042, Types.Crewmate, "Misfire Kills", new string[] { "Self", "Target", "Both" }, sheriffSpawnRate);
        sheriffCanKillNeutrals = CustomOption.Create(30043, Types.Crewmate, "Sheriff Can Kill Neutrals", false, sheriffSpawnRate);
        sheriffCanKillJester = CustomOption.Create(30044, Types.Crewmate, "Sheriff Can Kill " + cs(Jester.color, "Jester"), false, sheriffCanKillNeutrals);
        sheriffCanKillProsecutor = CustomOption.Create(30045, Types.Crewmate, "Sheriff Can Kill " + cs(Lawyer.color, "Prosecutor"), false, sheriffCanKillNeutrals);
        sheriffCanKillAmnesiac = CustomOption.Create(30046, Types.Crewmate, "Sheriff Can Kill " + cs(Amnisiac.color, "Amnesiac"), false, sheriffCanKillNeutrals);
        sheriffCanKillArsonist = CustomOption.Create(30047, Types.Crewmate, "Sheriff Can Kill " + cs(Arsonist.color, "Arsonist"), false, sheriffCanKillNeutrals);
        sheriffCanKillVulture = CustomOption.Create(30048, Types.Crewmate, "Sheriff Can Kill " + cs(Vulture.color, "Vulture"), false, sheriffCanKillNeutrals);
        sheriffCanKillLawyer = CustomOption.Create(30049, Types.Crewmate, "Sheriff Can Kill " + cs(Lawyer.color, "Lawyer"), false, sheriffCanKillNeutrals);
        sheriffCanKillThief = CustomOption.Create(30050, Types.Crewmate, "Sheriff Can Kill " + cs(Thief.color, "Thief"), false, sheriffCanKillNeutrals);
        sheriffCanKillPursuer = CustomOption.Create(30051, Types.Crewmate, "Sheriff Can Kill " + cs(Pursuer.color, "Pursuer"), false, sheriffCanKillNeutrals);

        deputySpawnRate = CustomOption.Create(30060, Types.Crewmate, "Sheriff Has A Deputy", rates, sheriffSpawnRate);
        deputyNumberOfHandcuffs = CustomOption.Create(30061, Types.Crewmate, "Deputy Number Of Handcuffs", 3f, 1f, 10f, 1f, deputySpawnRate);
        deputyHandcuffCooldown = CustomOption.Create(30062, Types.Crewmate, "Handcuff Cooldown", 30f, 10f, 60f, 2.5f, deputySpawnRate);
        deputyHandcuffDuration = CustomOption.Create(30063, Types.Crewmate, "Handcuff Duration", 15f, 5f, 60f, 2.5f, deputySpawnRate);
        deputyKnowsSheriff = CustomOption.Create(30064, Types.Crewmate, "Sheriff And Deputy Know Each Other ", true, deputySpawnRate);
        deputyGetsPromoted = CustomOption.Create(30065, Types.Crewmate, "Deputy Gets Promoted To Sheriff", new string[] { "Off", "On (Immediately)", "On (After Meeting)" }, deputySpawnRate);
        deputyKeepsHandcuffs = CustomOption.Create(30066, Types.Crewmate, "Deputy Keeps Handcuffs When Promoted", true, deputyGetsPromoted);

        lighterSpawnRate = CustomOption.Create(30070, Types.Crewmate, cs(Lighter.color, "Lighter"), rates, null, true);
        lighterModeLightsOnVision = CustomOption.Create(30071, Types.Crewmate, "Vision On Lights On", 1.5f, 0.25f, 5f, 0.25f, lighterSpawnRate);
        lighterModeLightsOffVision = CustomOption.Create(30072, Types.Crewmate, "Vision On Lights Off", 0.5f, 0.25f, 5f, 0.25f, lighterSpawnRate);
        lighterFlashlightWidth = CustomOption.Create(30073, Types.Crewmate, "Flashlight Width", 0.3f, 0.1f, 1f, 0.1f, lighterSpawnRate);

        detectiveSpawnRate = CustomOption.Create(30080, Types.Crewmate, cs(Detective.color, "Investigator"), rates, null, true);
        detectiveAnonymousFootprints = CustomOption.Create(30081, Types.Crewmate, "Anonymous Footprints", false, detectiveSpawnRate);
        detectiveFootprintIntervall = CustomOption.Create(30082, Types.Crewmate, "Footprint Intervall", 0.5f, 0.25f, 10f, 0.25f, detectiveSpawnRate);
        detectiveFootprintDuration = CustomOption.Create(30083, Types.Crewmate, "Footprint Duration", 5f, 0.25f, 10f, 0.25f, detectiveSpawnRate);
        detectiveReportNameDuration = CustomOption.Create(30084, Types.Crewmate, "Time Where Investigator Reports Will Have Name", 0, 0, 60, 2.5f, detectiveSpawnRate);
        detectiveReportColorDuration = CustomOption.Create(30085, Types.Crewmate, "Time Where Investigator Reports Will Have Color Type", 20, 0, 120, 2.5f, detectiveSpawnRate);

        timeMasterSpawnRate = CustomOption.Create(30090, Types.Crewmate, cs(TimeMaster.color, "Time Master"), rates, null, true);
        timeMasterCooldown = CustomOption.Create(30091, Types.Crewmate, "Time Master Cooldown", 30f, 10f, 120f, 2.5f, timeMasterSpawnRate);
        timeMasterRewindTime = CustomOption.Create(30092, Types.Crewmate, "Rewind Time", 3f, 1f, 10f, 1f, timeMasterSpawnRate);
        timeMasterShieldDuration = CustomOption.Create(30093, Types.Crewmate, "Time Master Shield Duration", 3f, 1f, 20f, 1f, timeMasterSpawnRate);

        veterenSpawnRate = CustomOption.Create(30100, Types.Crewmate, cs(Veteren.color, "Veteran"), rates, null, true);
        veterenCooldown = CustomOption.Create(30101, Types.Crewmate, "Alert Cooldown", 30f, 10f, 120f, 2.5f, veterenSpawnRate);
        veterenAlertDuration = CustomOption.Create(30102, Types.Crewmate, "Alert Duration", 3f, 1f, 20f, 1f, veterenSpawnRate);

        medicSpawnRate = CustomOption.Create(30110, Types.Crewmate, cs(Medic.color, "Medic"), rates, null, true);
        medicShowShielded = CustomOption.Create(30111, Types.Crewmate, "Show Shielded Player", new string[] { "Everyone", "Shielded + Medic", "Medic" }, medicSpawnRate);
        medicBreakShield = CustomOption.Create(30112, Types.Crewmate, "Shield Is Unbreakable", true, medicSpawnRate);
        medicShowAttemptToShielded = CustomOption.Create(30113, Types.Crewmate, "Shielded Player Sees Murder Attempt", false, medicBreakShield);
        medicResetTargetAfterMeeting = CustomOption.Create(30114, Types.Crewmate, "Reset Target After Meeting", false, medicSpawnRate);
        medicSetOrShowShieldAfterMeeting = CustomOption.Create(30115, Types.Crewmate, "Shield Will Be Activated", new string[] { "Instantly", "Instantly, Visible\nAfter Meeting", "After Meeting" }, medicSpawnRate);
        medicShowAttemptToMedic = CustomOption.Create(30116, Types.Crewmate, "Medic Sees Murder Attempt On Shielded Player", false, medicBreakShield);

        swapperSpawnRate = CustomOption.Create(30120, Types.Crewmate, cs(Swapper.color, "Swapper"), rates, null, true);
        swapperCanCallEmergency = CustomOption.Create(30121, Types.Crewmate, "Swapper Can Call Emergency Meeting", false, swapperSpawnRate);
        swapperCanFixSabotages = CustomOption.Create(30122, Types.Crewmate, "Swapper Can Fix Sabotages", false, swapperSpawnRate);
        swapperCanOnlySwapOthers = CustomOption.Create(30123, Types.Crewmate, "Swapper Can Only Swap Others", false, swapperSpawnRate);
        swapperSwapsNumber = CustomOption.Create(30124, Types.Crewmate, "Initial Swap Charges", 1f, 0f, 5f, 1f, swapperSpawnRate);
        swapperRechargeTasksNumber = CustomOption.Create(30125, Types.Crewmate, "Number Of Tasks Needed For Recharging", 2f, 1f, 10f, 1f, swapperSpawnRate);

        seerSpawnRate = CustomOption.Create(30140, Types.Crewmate, cs(Seer.color, "Seer"), rates, null, true);
        seerMode = CustomOption.Create(30141, Types.Crewmate, "Seer Mode", new string[] { "Show Death Flash + Souls", "Show Death Flash", "Show Souls" }, seerSpawnRate);
        seerLimitSoulDuration = CustomOption.Create(30142, Types.Crewmate, "Seer Limit Soul Duration", false, seerSpawnRate);
        seerSoulDuration = CustomOption.Create(30143, Types.Crewmate, "Seer Soul Duration", 15f, 0f, 120f, 5f, seerLimitSoulDuration);

        hackerSpawnRate = CustomOption.Create(30150, Types.Crewmate, cs(Hacker.color, "Hacker"), rates, null, true);
        hackerCooldown = CustomOption.Create(30151, Types.Crewmate, "Hacker Cooldown", 30f, 5f, 60f, 5f, hackerSpawnRate);
        hackerHackeringDuration = CustomOption.Create(30152, Types.Crewmate, "Hacker Duration", 10f, 2.5f, 60f, 2.5f, hackerSpawnRate);
        hackerOnlyColorType = CustomOption.Create(30153, Types.Crewmate, "Hacker Only Sees Color Type", false, hackerSpawnRate);
        hackerToolsNumber = CustomOption.Create(30154, Types.Crewmate, "Max Mobile Gadget Charges", 5f, 1f, 30f, 1f, hackerSpawnRate);
        hackerRechargeTasksNumber = CustomOption.Create(30155, Types.Crewmate, "Number Of Tasks Needed For Recharging", 2f, 1f, 5f, 1f, hackerSpawnRate);
        hackerNoMove = CustomOption.Create(30156, Types.Crewmate, "Cant Move During Mobile Gadget Duration", true, hackerSpawnRate);

        trackerSpawnRate = CustomOption.Create(30160, Types.Crewmate, cs(Tracker.color, "Tracker"), rates, null, true);
        trackerUpdateIntervall = CustomOption.Create(30161, Types.Crewmate, "Tracker Update Intervall", 5f, 1f, 30f, 1f, trackerSpawnRate);
        trackerResetTargetAfterMeeting = CustomOption.Create(30162, Types.Crewmate, "Tracker Reset Target After Meeting", false, trackerSpawnRate);
        trackerCanTrackCorpses = CustomOption.Create(30163, Types.Crewmate, "Tracker Can Track Corpses", true, trackerSpawnRate);
        trackerCorpsesTrackingCooldown = CustomOption.Create(30164, Types.Crewmate, "Corpses Tracking Cooldown", 30f, 5f, 120f, 5f, trackerCanTrackCorpses);
        trackerCorpsesTrackingDuration = CustomOption.Create(30165, Types.Crewmate, "Corpses Tracking Duration", 5f, 2.5f, 30f, 2.5f, trackerCanTrackCorpses);
        trackerTrackingMethod = CustomOption.Create(30166, Types.Crewmate, "How Tracker Gets Target Location", new string[] { "Arrow Only", "Proximity Dectector Only", "Arrow + Proximity" }, trackerSpawnRate);

        snitchSpawnRate = CustomOption.Create(30170, Types.Crewmate, cs(Snitch.color, "Snitch"), rates, null, true);
        snitchLeftTasksForReveal = CustomOption.Create(30171, Types.Crewmate, "Task Count Where The Snitch Will Be Revealed", 1f, 0f, 10f, 1f, snitchSpawnRate);
        snitchSeeMeeting = CustomOption.Create(30172, Types.Crewmate, "Show Roles Color", true, snitchSpawnRate);
        snitchCanSeeRoles = CustomOption.Create(30173, Types.Crewmate, "Can See Roles Info", false, snitchSeeMeeting);
        snitchIncludeNeutralTeam = CustomOption.Create(30174, Types.Crewmate, "Include Team Neutral", ["Off", "Killer", "Evil", "All"], snitchSpawnRate);
        snitchTeamNeutraUseDifferentArrowColor = CustomOption.Create(30175, Types.Crewmate, "Use Different Color For Neutra Team", true, snitchIncludeNeutralTeam);

        spySpawnRate = CustomOption.Create(30180, Types.Crewmate, cs(Spy.color, "Spy"), rates, null, true);
        spyCanDieToSheriff = CustomOption.Create(30181, Types.Crewmate, "Spy Can Die To Sheriff", false, spySpawnRate);
        spyImpostorsCanKillAnyone = CustomOption.Create(30182, Types.Crewmate, "Impostors Can Kill Anyone If There Is A Spy", true, spySpawnRate);
        spyCanEnterVents = CustomOption.Create(30183, Types.Crewmate, "Spy Can Enter Vents", false, spySpawnRate);
        spyHasImpostorVision = CustomOption.Create(30184, Types.Crewmate, "Spy Has Impostor Vision", false, spySpawnRate);

        portalmakerSpawnRate = CustomOption.Create(30190, Types.Crewmate, cs(Portalmaker.color, "Portalmaker"), rates, null, true);
        portalmakerCooldown = CustomOption.Create(30191, Types.Crewmate, "Portalmaker Cooldown", 30f, 10f, 60f, 2.5f, portalmakerSpawnRate);
        portalmakerUsePortalCooldown = CustomOption.Create(30192, Types.Crewmate, "Use Portal Cooldown", 30f, 10f, 60f, 2.5f, portalmakerSpawnRate);
        portalmakerLogOnlyColorType = CustomOption.Create(30193, Types.Crewmate, "Portalmaker Log Only Shows Color Type", true, portalmakerSpawnRate);
        portalmakerLogHasTime = CustomOption.Create(30194, Types.Crewmate, "Log Shows Time", true, portalmakerSpawnRate);
        portalmakerCanPortalFromAnywhere = CustomOption.Create(30195, Types.Crewmate, "Can Port To Portal From Everywhere", true, portalmakerSpawnRate);

        securityGuardSpawnRate = CustomOption.Create(30200, Types.Crewmate, cs(SecurityGuard.color, "Security Guard"), rates, null, true);
        securityGuardCooldown = CustomOption.Create(30201, Types.Crewmate, "Security Guard Cooldown", 30f, 10f, 60f, 2.5f, securityGuardSpawnRate);
        securityGuardTotalScrews = CustomOption.Create(30202, Types.Crewmate, "Security Guard Number Of Screws", 7f, 1f, 15f, 1f, securityGuardSpawnRate);
        securityGuardCamPrice = CustomOption.Create(30203, Types.Crewmate, "Number Of Screws Per Cam", 2f, 1f, 15f, 1f, securityGuardSpawnRate);
        securityGuardVentPrice = CustomOption.Create(30204, Types.Crewmate, "Number Of Screws Per Vent", 1f, 1f, 15f, 1f, securityGuardSpawnRate);
        securityGuardCamDuration = CustomOption.Create(30205, Types.Crewmate, "Security Guard Duration", 10f, 2.5f, 60f, 2.5f, securityGuardSpawnRate);
        securityGuardCamMaxCharges = CustomOption.Create(30206, Types.Crewmate, "Gadget Max Charges", 5f, 1f, 30f, 1f, securityGuardSpawnRate);
        securityGuardCamRechargeTasksNumber = CustomOption.Create(30207, Types.Crewmate, "Number Of Tasks Needed For Recharging", 3f, 1f, 10f, 1f, securityGuardSpawnRate);
        securityGuardNoMove = CustomOption.Create(30208, Types.Crewmate, "Cant Move During Cam Duration", true, securityGuardSpawnRate);

        mediumSpawnRate = CustomOption.Create(30210, Types.Crewmate, cs(Medium.color, "Medium"), rates, null, true);
        mediumCooldown = CustomOption.Create(30211, Types.Crewmate, "Medium Questioning Cooldown", 30f, 5f, 120f, 5f, mediumSpawnRate);
        mediumDuration = CustomOption.Create(30212, Types.Crewmate, "Medium Questioning Duration", 3f, 0f, 15f, 1f, mediumSpawnRate);
        mediumOneTimeUse = CustomOption.Create(30213, Types.Crewmate, "Each Soul Can Only Be Questioned Once", false, mediumSpawnRate);
        mediumChanceAdditionalInfo = CustomOption.Create(30214, Types.Crewmate, "Chance That The Answer Contains \n    Additional Information", rates, mediumSpawnRate);

        jumperSpawnRate = CustomOption.Create(30220, Types.Crewmate, cs(Jumper.color, "Jumper"), rates, null, true);
        jumperJumpTime = CustomOption.Create(30221, Types.Crewmate, "Jump Cooldown", 30, 0, 60, 5, jumperSpawnRate);
        jumperChargesOnPlace = CustomOption.Create(30222, Types.Crewmate, "Charges On Place", 1, 1, 10, 1, jumperSpawnRate);
        //jumperResetPlaceAfterMeeting = CustomOption.Create(30223, Types.Crewmate, "Reset Places After Meeting", true, jumperSpawnRate);
        //jumperChargesGainOnMeeting = CustomOption.Create(30224, Types.Crewmate, "Charges Gained After Meeting", 2, 0, 10, 1, jumperSpawnRate);
        //jumperMaxCharges = CustomOption.Create(30225, Types.Crewmate, "Maximum Charges", 3, 0, 10, 1, jumperSpawnRate);

        bodyGuardSpawnRate = CustomOption.Create(30230, Types.Crewmate, cs(BodyGuard.color, "Bodyguard"), rates, null, true);
        bodyGuardResetTargetAfterMeeting = CustomOption.Create(30231, Types.Crewmate, "Reset Target After Meeting", true, bodyGuardSpawnRate);
        bodyGuardFlash = CustomOption.Create(30232, Types.Crewmate, "Show Flash On Death", true, bodyGuardSpawnRate);

        thiefSpawnRate = CustomOption.Create(30240, Types.Neutral, cs(Thief.color, "Thief"), rates, null, true);
        thiefCooldown = CustomOption.Create(30241, Types.Neutral, "Thief Cooldown", 30f, 5f, 120f, 5f, thiefSpawnRate);
        thiefCanKillSheriff = CustomOption.Create(30242, Types.Neutral, "Thief Can Kill Sheriff", true, thiefSpawnRate);
        thiefHasImpVision = CustomOption.Create(30243, Types.Neutral, "Thief Has Impostor Vision", true, thiefSpawnRate);
        thiefCanUseVents = CustomOption.Create(30244, Types.Neutral, "Thief Can Use Vents", true, thiefSpawnRate);
        thiefCanStealWithGuess = CustomOption.Create(30245, Types.Neutral, "Thief Can Guess To Steal A Role (If Guesser)", false, thiefSpawnRate);

        trapperSpawnRate = CustomOption.Create(30250, Types.Crewmate, cs(Trapper.color, "Trapper"), rates, null, true);
        trapperCooldown = CustomOption.Create(30251, Types.Crewmate, "Trapper Cooldown", 30f, 5f, 120f, 5f, trapperSpawnRate);
        trapperMaxCharges = CustomOption.Create(30252, Types.Crewmate, "Max Traps Charges", 5f, 1f, 15f, 1f, trapperSpawnRate);
        trapperRechargeTasksNumber = CustomOption.Create(30253, Types.Crewmate, "Number Of Tasks Needed For Recharging", 2f, 1f, 15f, 1f, trapperSpawnRate);
        trapperTrapNeededTriggerToReveal = CustomOption.Create(30254, Types.Crewmate, "Trap Needed Trigger To Reveal", 3f, 2f, 10f, 1f, trapperSpawnRate);
        trapperAnonymousMap = CustomOption.Create(30255, Types.Crewmate, "Show Anonymous Map", false, trapperSpawnRate);
        trapperInfoType = CustomOption.Create(30256, Types.Crewmate, "Trap Information Type", new string[] { "Role", "Good/Evil Role", "Name" }, trapperSpawnRate);
        trapperTrapDuration = CustomOption.Create(30257, Types.Crewmate, "Trap Duration", 5f, 1f, 15f, 1f, trapperSpawnRate);

        //-------------------------- Modifier (1000 - 1999) -------------------------- //

        modifiersAreHidden = CustomOption.Create(1000, Types.Modifier, cs(Color.yellow, "Hide After Death Modifiers"), true, null, true);

        modifierDisperser = CustomOption.Create(1010, Types.Modifier, cs(Color.red, "Disperser"), rates, null, true);
        modifierDisperserCooldown = CustomOption.Create(1011, Types.Modifier, "Disperser Cooldown", 30f, 10f, 60f, 2.5f, modifierDisperser);
        modifierDisperserNumberOfUses = CustomOption.Create(1012, Types.Modifier, "Number Of Uses", 1, 1, 5, 1, modifierDisperser);
        modifierDisperserDispersesToVent = CustomOption.Create(1013, Types.Modifier, "disperse To Vent", true, modifierDisperser);

        modifierBloody = CustomOption.Create(1020, Types.Modifier, cs(Color.yellow, "Bloody"), rates, null, true);
        modifierBloodyQuantity = CustomOption.Create(1021, Types.Modifier, cs(Color.yellow, "Bloody Quantity"), ratesModifier, modifierBloody);
        modifierBloodyDuration = CustomOption.Create(1022, Types.Modifier, "Trail Duration", 10f, 3f, 60f, 1f, modifierBloody);

        modifierAntiTeleport = CustomOption.Create(1030, Types.Modifier, cs(Color.yellow, "Anti Teleport"), rates, null, true);
        modifierAntiTeleportQuantity = CustomOption.Create(1031, Types.Modifier, cs(Color.yellow, "Anti Teleport Quantity"), ratesModifier, modifierAntiTeleport);

        modifierTieBreaker = CustomOption.Create(1040, Types.Modifier, cs(Color.yellow, "Tie Breaker"), rates, null, true);

        modifierBait = CustomOption.Create(1050, Types.Modifier, cs(Color.yellow, "Bait"), rates, null, true);
        modifierBaitQuantity = CustomOption.Create(1051, Types.Modifier, cs(Color.yellow, "Bait Quantity"), ratesModifier, modifierBait);
        modifierBaitReportDelayMin = CustomOption.Create(1052, Types.Modifier, "Bait Report Delay Min", 0f, 0f, 10f, 1f, modifierBait);
        modifierBaitReportDelayMax = CustomOption.Create(1053, Types.Modifier, "Bait Report Delay Max", 0f, 0f, 10f, 1f, modifierBait);
        modifierBaitShowKillFlash = CustomOption.Create(1054, Types.Modifier, "Warn The Killer With A Flash", true, modifierBait);

        modifierAftermath = CustomOption.Create(1230, Types.Modifier, cs(Color.yellow, "Aftermath"), rates, null, true);

        modifierLover = CustomOption.Create(1060, Types.Modifier, cs(Color.yellow, "Lovers"), rates, null, true);
        modifierLoverImpLoverRate = CustomOption.Create(1061, Types.Modifier, "Chance That One Lover Is Impostor", rates, modifierLover);
        modifierLoverBothDie = CustomOption.Create(1062, Types.Modifier, "Both Lovers Die", true, modifierLover);
        modifierLoverEnableChat = CustomOption.Create(1063, Types.Modifier, "Enable Lover Chat", true, modifierLover);

        modifierSunglasses = CustomOption.Create(1070, Types.Modifier, cs(Color.yellow, "Sunglasses"), rates, null, true);
        modifierSunglassesQuantity = CustomOption.Create(1071, Types.Modifier, cs(Color.yellow, "Sunglasses Quantity"), ratesModifier, modifierSunglasses);
        modifierSunglassesVision = CustomOption.Create(1072, Types.Modifier, "Vision With Sunglasses", new string[] { "-10%", "-20%", "-30%", "-40%", "-50%" }, modifierSunglasses);

        modifierTorch = CustomOption.Create(1080, Types.Modifier, cs(Color.yellow, "Torch"), rates, null, true);
        modifierTorchQuantity = CustomOption.Create(1081, Types.Modifier, cs(Color.yellow, "Torch Quantity"), ratesModifier, modifierTorch);
        modifierTorchVision = CustomOption.Create(1082, Types.Modifier, cs(Color.yellow, "Vision With Torch"), 1.5f, 1f, 3f, 0.125f, modifierTorch);

        modifierFlash = CustomOption.Create(1090, Types.Modifier, cs(Color.yellow, "Flash"), rates, null, true);
        modifierFlashQuantity = CustomOption.Create(110, Types.Modifier, cs(Color.yellow, "Flash Quantity"), ratesModifier, modifierFlash);
        modifierFlashSpeed = CustomOption.Create(1212, Types.Modifier, "Flash Speed", 1.25f, 1f, 3f, 0.125f, modifierFlash);

        modifierMultitasker = CustomOption.Create(1100, Types.Modifier, cs(Color.yellow, "Multitasker"), rates, null, true);
        modifierMultitaskerQuantity = CustomOption.Create(1101, Types.Modifier, cs(Color.yellow, "Multitasker Quantity"), ratesModifier, modifierMultitasker);

        modifierMini = CustomOption.Create(1110, Types.Modifier, cs(Color.yellow, "Mini"), rates, null, true);
        modifierMiniGrowingUpDuration = CustomOption.Create(1111, Types.Modifier, "Mini Growing Up Duration", 400f, 100f, 1500f, 100f, modifierMini);
        modifierMiniGrowingUpInMeeting = CustomOption.Create(1112, Types.Modifier, "Mini Grows Up In Meeting", true, modifierMini);

        modifierIndomitable = CustomOption.Create(1120, Types.Modifier, cs(Color.yellow, "Indomitable"), rates, null, true);

        modifierBlind = CustomOption.Create(1130, Types.Modifier, cs(Color.yellow, "Blind"), rates, null, true);

        modifierWatcher = CustomOption.Create(1140, Types.Modifier, cs(Color.yellow, "Watcher"), rates, null, true);

        modifierRadar = CustomOption.Create(1150, Types.Modifier, cs(Color.yellow, "Radar"), rates, null, true);

        modifierTunneler = CustomOption.Create(1160, Types.Modifier, cs(Color.yellow, "Tunneler"), rates, null, true);

        modifierSlueth = CustomOption.Create(1170, Types.Modifier, cs(Color.yellow, "Sleuth"), rates, null, true);

        modifierCursed = CustomOption.Create(1180, Types.Modifier, cs(Color.yellow, "Fanatic"), rates, null, true);

        modifierVip = CustomOption.Create(1190, Types.Modifier, cs(Color.yellow, "VIP"), rates, null, true);
        modifierVipQuantity = CustomOption.Create(1191, Types.Modifier, cs(Color.yellow, "VIP Quantity"), ratesModifier, modifierVip);
        modifierVipShowColor = CustomOption.Create(1192, Types.Modifier, "Show Team Color", true, modifierVip);

        modifierInvert = CustomOption.Create(1200, Types.Modifier, cs(Color.yellow, "Invert"), rates, null, true);
        modifierInvertQuantity = CustomOption.Create(1201, Types.Modifier, cs(Color.yellow, "Modifier Quantity"), ratesModifier, modifierInvert);
        modifierInvertDuration = CustomOption.Create(1202, Types.Modifier, "Number Of Meetings Inverted", 3f, 1f, 15f, 1f, modifierInvert);

        modifierChameleon = CustomOption.Create(1210, Types.Modifier, cs(Color.yellow, "Chameleon"), rates, null, true);
        modifierChameleonQuantity = CustomOption.Create(1211, Types.Modifier, cs(Color.yellow, "Chameleon Quantity"), ratesModifier, modifierChameleon);
        modifierChameleonHoldDuration = CustomOption.Create(1212, Types.Modifier, "Time Until Fading Starts", 3f, 1f, 10f, 0.5f, modifierChameleon);
        modifierChameleonFadeDuration = CustomOption.Create(1213, Types.Modifier, "Fade Duration", 1f, 0.25f, 10f, 0.25f, modifierChameleon);
        modifierChameleonMinVisibility = CustomOption.Create(1214, Types.Modifier, "Minimum Visibility", new string[] { "0%", "10%", "20%", "30%", "40%", "50%" }, modifierChameleon);

        modifierShifter = CustomOption.Create(1220, Types.Modifier, cs(Color.yellow, "Shifter"), rates, null, true);

        // Guesser Gamemode (2000 - 2999)
        guesserGamemodeCrewNumber = CustomOption.Create(2001, Types.Guesser, cs(Guesser.color, "Number of Crew Guessers"), 15f, 1f, 15f, 1f, null, true);
        guesserGamemodeNeutralNumber = CustomOption.Create(2002, Types.Guesser, cs(Guesser.color, "Number of Neutral Guessers"), 15f, 1f, 15f, 1f);
        guesserGamemodeImpNumber = CustomOption.Create(2003, Types.Guesser, cs(Guesser.color, "Number of Impostor Guessers"), 15f, 1f, 15f, 1f);
        guesserForceJackalGuesser = CustomOption.Create(2007, Types.Guesser, "Force Jackal Guesser", false, null, true);
        guesserGamemodeSidekickIsAlwaysGuesser = CustomOption.Create(2012, Types.Guesser, "Sidekick Is Always Guesser", false);
        guesserForceThiefGuesser = CustomOption.Create(2011, Types.Guesser, "Force Thief Guesser", false);
        guesserGamemodeHaveModifier = CustomOption.Create(2004, Types.Guesser, "Guessers Can Have A Modifier", true, null, true);
        guesserGamemodeNumberOfShots = CustomOption.Create(2005, Types.Guesser, "Guesser Number Of Shots", 3f, 1f, 15f, 1f);
        guesserGamemodeHasMultipleShotsPerMeeting = CustomOption.Create(2006, Types.Guesser, "Guesser Can Shoot Multiple Times Per Meeting", false);
        guesserGamemodeKillsThroughShield = CustomOption.Create(2008, Types.Guesser, "Guesses Ignore The Medic Shield", true);
        guesserGamemodeEvilCanKillSpy = CustomOption.Create(2009, Types.Guesser, "Evil Guesser Can Guess The Spy", true);
        guesserGamemodeCantGuessSnitchIfTaksDone = CustomOption.Create(2010, Types.Guesser, "Guesser Can't Guess Snitch When Tasks Completed", true);

        //-------------------------- Hide N Seek 3000 - 3999 -------------------------- //

        hideNSeekMap = CustomOption.Create(3020, Types.HideNSeekMain, cs(Color.yellow, "Map"), new string[] { "The Skeld", "Mira", "Polus", "Airship", "Fungle", "Submerged", "LI Map" }, null, true, onChange: () => { int map = hideNSeekMap.selection; if (map >= 3) map++; GameOptionsManager.Instance.currentNormalGameOptions.MapId = (byte)map; });
        hideNSeekHunterCount = CustomOption.Create(3000, Types.HideNSeekMain, cs(Color.yellow, "Number Of Hunters"), 1f, 1f, 3f, 1f);
        hideNSeekKillCooldown = CustomOption.Create(3021, Types.HideNSeekMain, cs(Color.yellow, "Kill Cooldown"), 10f, 2.5f, 60f, 2.5f);
        hideNSeekHunterVision = CustomOption.Create(3001, Types.HideNSeekMain, cs(Color.yellow, "Hunter Vision"), 0.5f, 0.25f, 2f, 0.25f);
        hideNSeekHuntedVision = CustomOption.Create(3002, Types.HideNSeekMain, cs(Color.yellow, "Hunted Vision"), 2f, 0.25f, 5f, 0.25f);
        hideNSeekCommonTasks = CustomOption.Create(3023, Types.HideNSeekMain, cs(Color.yellow, "Common Tasks"), 1f, 0f, 4f, 1f);
        hideNSeekShortTasks = CustomOption.Create(3024, Types.HideNSeekMain, cs(Color.yellow, "Short Tasks"), 3f, 1f, 23f, 1f);
        hideNSeekLongTasks = CustomOption.Create(3025, Types.HideNSeekMain, cs(Color.yellow, "Long Tasks"), 3f, 0f, 15f, 1f);
        hideNSeekTimer = CustomOption.Create(3003, Types.HideNSeekMain, cs(Color.yellow, "Timer In Min"), 5f, 1f, 30f, 0.5f);
        hideNSeekTaskWin = CustomOption.Create(3004, Types.HideNSeekMain, cs(Color.yellow, "Task Win Is Possible"), false);
        hideNSeekTaskPunish = CustomOption.Create(3017, Types.HideNSeekMain, cs(Color.yellow, "Finish Tasks Punish In Sec"), 10f, 0f, 30f, 1f);
        hideNSeekCanSabotage = CustomOption.Create(3019, Types.HideNSeekMain, cs(Color.yellow, "Enable Sabotages"), false);
        hideNSeekHunterWaiting = CustomOption.Create(3022, Types.HideNSeekMain, cs(Color.yellow, "Time The Hunter Needs To Wait"), 15f, 2.5f, 60f, 2.5f);

        hunterLightCooldown = CustomOption.Create(3005, Types.HideNSeekRoles, cs(Color.red, "Hunter Light Cooldown"), 30f, 5f, 60f, 1f, null, true);
        hunterLightDuration = CustomOption.Create(3006, Types.HideNSeekRoles, cs(Color.red, "Hunter Light Duration"), 5f, 1f, 60f, 1f);
        hunterLightVision = CustomOption.Create(3007, Types.HideNSeekRoles, cs(Color.red, "Hunter Light Vision"), 3f, 1f, 5f, 0.25f);
        hunterLightPunish = CustomOption.Create(3008, Types.HideNSeekRoles, cs(Color.red, "Hunter Light Punish In Sec"), 5f, 0f, 30f, 1f);
        hunterAdminCooldown = CustomOption.Create(3009, Types.HideNSeekRoles, cs(Color.red, "Hunter Admin Cooldown"), 30f, 5f, 60f, 1f);
        hunterAdminDuration = CustomOption.Create(3010, Types.HideNSeekRoles, cs(Color.red, "Hunter Admin Duration"), 5f, 1f, 60f, 1f);
        hunterAdminPunish = CustomOption.Create(3011, Types.HideNSeekRoles, cs(Color.red, "Hunter Admin Punish In Sec"), 5f, 0f, 30f, 1f);
        hunterArrowCooldown = CustomOption.Create(3012, Types.HideNSeekRoles, cs(Color.red, "Hunter Arrow Cooldown"), 30f, 5f, 60f, 1f);
        hunterArrowDuration = CustomOption.Create(3013, Types.HideNSeekRoles, cs(Color.red, "Hunter Arrow Duration"), 5f, 0f, 60f, 1f);
        hunterArrowPunish = CustomOption.Create(3014, Types.HideNSeekRoles, cs(Color.red, "Hunter Arrow Punish In Sec"), 5f, 0f, 30f, 1f);

        huntedShieldCooldown = CustomOption.Create(3015, Types.HideNSeekRoles, cs(Color.gray, "Hunted Shield Cooldown"), 30f, 5f, 60f, 1f, null, true);
        huntedShieldDuration = CustomOption.Create(3016, Types.HideNSeekRoles, cs(Color.gray, "Hunted Shield Duration"), 5f, 1f, 60f, 1f);
        huntedShieldRewindTime = CustomOption.Create(3018, Types.HideNSeekRoles, cs(Color.gray, "Hunted Rewind Time"), 3f, 1f, 10f, 1f);
        huntedShieldNumber = CustomOption.Create(3026, Types.HideNSeekRoles, cs(Color.gray, "Hunted Shield Number"), 3f, 1f, 15f, 1f);

        //-------------------------- Prop Hunt General Options 4000 - 4999 -------------------------- //

        propHuntMap = CustomOption.Create(4020, Types.PropHunt, cs(Color.yellow, "Map"),
            ["The Skeld", "Mira", "Polus", "Airship", "Fungle", "Submerged", "LI Map"], null, true, onChange: () =>
            {
                int map = propHuntMap.selection; if (map >= 3) map++;
                GameOptionsManager.Instance.currentNormalGameOptions.MapId = (byte)map;
            });
        propHuntTimer = CustomOption.Create(4021, Types.PropHunt, cs(Color.yellow, "Timer In Min"), 5f, 1f, 30f, 0.5f);
        propHuntUnstuckCooldown = CustomOption.Create(4011, Types.PropHunt, cs(Color.yellow, "Unstuck Cooldown"), 30f, 2.5f, 60f, 2.5f);
        propHuntUnstuckDuration = CustomOption.Create(4012, Types.PropHunt, cs(Color.yellow, "Unstuck Duration"), 2f, 1f, 60f, 1f);
        propHunterVision = CustomOption.Create(4006, Types.PropHunt, cs(Color.yellow, "Hunter Vision"), 0.5f, 0.25f, 2f, 0.25f);
        propVision = CustomOption.Create(4007, Types.PropHunt, cs(Color.yellow, "Prop Vision"), 2f, 0.25f, 5f, 0.25f);
        // Hunter Options
        propHuntNumberOfHunters = CustomOption.Create(4000, Types.PropHunt, cs(Color.red, "Number Of Hunters"), 1f, 1f, 5f, 1f, null, true);
        hunterInitialBlackoutTime = CustomOption.Create(4001, Types.PropHunt, cs(Color.red, "Hunter Initial Blackout Duration"), 10f, 5f, 20f, 1f);
        hunterMissCooldown = CustomOption.Create(4004, Types.PropHunt, cs(Color.red, "Kill Cooldown After Miss"), 10f, 2.5f, 60f, 2.5f);
        hunterHitCooldown = CustomOption.Create(4005, Types.PropHunt, cs(Color.red, "Kill Cooldown After Hit"), 10f, 2.5f, 60f, 2.5f);
        propHuntRevealCooldown = CustomOption.Create(4008, Types.PropHunt, cs(Color.red, "Reveal Prop Cooldown"), 30f, 10f, 90f, 2.5f);
        propHuntRevealDuration = CustomOption.Create(4009, Types.PropHunt, cs(Color.red, "Reveal Prop Duration"), 5f, 1f, 60f, 1f);
        propHuntRevealPunish = CustomOption.Create(4010, Types.PropHunt, cs(Color.red, "Reveal Time Punish"), 10f, 0f, 1800f, 5f);
        propHuntAdminCooldown = CustomOption.Create(4022, Types.PropHunt, cs(Color.red, "Hunter Admin Cooldown"), 30f, 2.5f, 1800f, 2.5f);
        propHuntFindCooldown = CustomOption.Create(4023, Types.PropHunt, cs(Color.red, "Find Cooldown"), 60f, 2.5f, 1800f, 2.5f);
        propHuntFindDuration = CustomOption.Create(4024, Types.PropHunt, cs(Color.red, "Find Duration"), 5f, 1f, 15f, 1f);
        // Prop Options
        propBecomesHunterWhenFound = CustomOption.Create(4003, Types.PropHunt, cs(Palette.CrewmateBlue, "Props Become Hunters When Found"), false, null, true);
        propHuntInvisEnabled = CustomOption.Create(4013, Types.PropHunt, cs(Palette.CrewmateBlue, "Invisibility Enabled"), true, null, true);
        propHuntInvisCooldown = CustomOption.Create(4014, Types.PropHunt, cs(Palette.CrewmateBlue, "Invisibility Cooldown"), 120f, 10f, 1800f, 2.5f, propHuntInvisEnabled);
        propHuntInvisDuration = CustomOption.Create(4015, Types.PropHunt, cs(Palette.CrewmateBlue, "Invisibility Duration"), 5f, 1f, 30f, 1f, propHuntInvisEnabled);
        propHuntSpeedboostEnabled = CustomOption.Create(4016, Types.PropHunt, cs(Palette.CrewmateBlue, "Speedboost Enabled"), true, null, true);
        propHuntSpeedboostCooldown = CustomOption.Create(4017, Types.PropHunt, cs(Palette.CrewmateBlue, "Speedboost Cooldown"), 60f, 2.5f, 1800f, 2.5f, propHuntSpeedboostEnabled);
        propHuntSpeedboostDuration = CustomOption.Create(4018, Types.PropHunt, cs(Palette.CrewmateBlue, "Speedboost Duration"), 5f, 1f, 15f, 1f, propHuntSpeedboostEnabled);
        propHuntSpeedboostSpeed = CustomOption.Create(4019, Types.PropHunt, cs(Palette.CrewmateBlue, "Speedboost Ratio"), 2f, 1.25f, 5f, 0.25f, propHuntSpeedboostEnabled);


        blockedRolePairings.Add((byte)RoleId.Vampire, new[] { (byte)RoleId.Warlock });
        blockedRolePairings.Add((byte)RoleId.Warlock, new[] { (byte)RoleId.Vampire });
        blockedRolePairings.Add((byte)RoleId.Spy, new[] { (byte)RoleId.Mini });
        blockedRolePairings.Add((byte)RoleId.Mini, new[] { (byte)RoleId.Spy });
        blockedRolePairings.Add((byte)RoleId.Vulture, new[] { (byte)RoleId.Cleaner });
        blockedRolePairings.Add((byte)RoleId.Cleaner, new[] { (byte)RoleId.Vulture });

        blockedRolePairings.Add((byte)RoleId.Mayor, new[] { (byte)RoleId.Watcher });
        blockedRolePairings.Add((byte)RoleId.Watcher, new[] { (byte)RoleId.Mayor });
        blockedRolePairings.Add((byte)RoleId.Engineer, new[] { (byte)RoleId.Tunneler });
        blockedRolePairings.Add((byte)RoleId.Tunneler, new[] { (byte)RoleId.Engineer });
        blockedRolePairings.Add((byte)RoleId.Bomber2, new[] { (byte)RoleId.Bait });
        blockedRolePairings.Add((byte)RoleId.Bait, new[] { (byte)RoleId.Bomber2 });

    }
}
