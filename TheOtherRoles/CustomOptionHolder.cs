using System.Collections.Generic;
using TheOtherRoles.Modules;
using UnityEngine;
using static TheOtherRoles.Modules.CustomOption;
using static TheOtherRoles.TheOtherRoles;
using Types = TheOtherRoles.Modules.CustomOption.CustomOptionType;

namespace TheOtherRoles;

public class CustomOptionHolder
{
    public static string[] rates = ["0%", "10%", "20%", "30%", "40%", "50%", "60%", "70%", "80%", "90%", "100%"];
    public static string[] ratesModifier = ["1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15"];
    public static string[] presets = ["Preset 1", "Preset 2", "Preset 3", "Random Preset Skeld", "Random Preset Mira HQ", "Random Preset Polus", "Random Preset Airship", "Random Preset Fungle", "Random Preset Submerged"];

    public static CustomOption presetSelection;
    public static CustomOption neutralRolesCountMin;
    public static CustomOption neutralRolesCountMax;
    public static CustomOption modifiersCountMin;
    public static CustomOption modifiersCountMax;

    public static CustomOption anyPlayerCanStopStart;

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

    public static CustomOption bomberSpawnRate;
    public static CustomOption bomberBombCooldown;
    public static CustomOption bomberDelay;
    public static CustomOption bomberTimer;
    public static CustomOption bomberTriggerBothCooldowns;
    public static CustomOption bomberCanGiveToBomber;
    public static CustomOption bomberHotPotatoMode;

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
    public static CustomOption jackalCanUseVents;
    public static CustomOption jackalCanUseSabo;
    public static CustomOption jackalCanCreateSidekick;
    public static CustomOption sidekickPromotesToJackal;
    public static CustomOption sidekickCanKill;
    public static CustomOption sidekickCanUseVents;
    public static CustomOption jackalPromotedFromSidekickCanCreateSidekick;
    public static CustomOption jackalAndSidekickHaveImpostorVision;
    public static CustomOption jackalCanCreateSidekickFromImpostor;
    public static CustomOption jackalKillFakeImpostor;

    public static CustomOption juggernautSpawnRate;
    public static CustomOption juggernautCooldown;
    public static CustomOption juggernautHasImpVision;
    public static CustomOption juggernautCanVent;
    public static CustomOption juggernautReducedkillEach;

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
    public static CustomOption sheriffCanKillDoomsayer;
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
    //public static CustomOption snitchCanSeeRoles;
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

    public static CustomOption doomsayerSpawnRate;
    public static CustomOption doomsayerCooldown;
    //public static CustomOption doomsayerHasMultipleShotsPerMeeting;
    public static CustomOption doomsayerCanGuessImpostor;
    public static CustomOption doomsayerCanGuessNeutral;
    public static CustomOption doomsayerOnlineTarger;
    public static CustomOption doomsayerKillToWin;
    public static CustomOption doomsayerDormationNum;

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

    public static CustomOption terroristSpawnRate;
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

    public static CustomOption modifierGiant;
    public static CustomOption modifierGiantSpped;

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

    public static CustomOption modifierArmored;

    public static CustomOption modifierShifter;

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
    public static CustomOption preventTaskEnd;
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

    public static CustomOption debugMode;
    public static CustomOption disableGameEnd;

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
    public static CustomOption guesserGamemodeCrewGuesserNumberOfTasks;

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

    internal static Dictionary<byte, byte[]> blockedRolePairings = new();

    public static string cs(Color c, string s)
    {
        return string.Format("<color=#{0:X2}{1:X2}{2:X2}{3:X2}>{4}</color>", ToByte(c.r), ToByte(c.g), ToByte(c.b), ToByte(c.a), getString(s));
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

        vanillaSettings = TheOtherRolesPlugin.Instance.Config.Bind("Preset0", "VanillaOptions", "");

        // Role Options
        presetSelection = Create(0, Types.General, cs(new Color32(204, 204, 0, 255), "optionPreset"), presets, null, true);

        // Using new id's for the options to not break compatibilty with older versions
        neutralRolesCountMin = Create(8, Types.General, cs(new Color32(204, 204, 0, 255), "neutralRolesCountMin"), 15f, 0f, 15f, 1f, heading: "miniMaxRole");
        neutralRolesCountMax = Create(9, Types.General, cs(new Color32(204, 204, 0, 255), "neutralRolesCountMax"), 15f, 0f, 15f, 1f);
        modifiersCountMin = Create(12, Types.General, cs(new Color32(204, 204, 0, 255), "modifiersCountMin"), 15f, 0f, 15f, 1f);
        modifiersCountMax = Create(13, Types.General, cs(new Color32(204, 204, 0, 255), "modifiersCountMax"), 15f, 0f, 15f, 1f);

        //-------------------------- Other options 1 - 599 -------------------------- //


        maxNumberOfMeetings = Create(3, Types.General, "maxNumberOfMeetings", 10, 0, 15, 1, null, true, heading: "gameplaySettings");
        if (Utilities.EventUtility.canBeEnabled) enableEventMode = Create(3, Types.General, cs(Color.green, "enableEventMode"), true, null);
        anyPlayerCanStopStart = Create(2, Types.General, cs(new Color32(204, 204, 0, 255), "anyPlayerCanStopStart"), false, null);
        resteButtonCooldown = Create(20, Types.General, "resteButtonCooldown", 10f, 2.5f, 30f, 2.5f);
        blockSkippingInEmergencyMeetings = Create(22, Types.General, "blockSkippingInEmergencyMeetings", false);
        noVoteIsSelfVote = Create(23, Types.General, "noVoteIsSelfVote", false, blockSkippingInEmergencyMeetings);
        shieldFirstKill = Create(24, Types.General, "shieldFirstKill", false);
        hidePlayerNames = Create(25, Types.General, "hidePlayerNames", false);
        hideOutOfSightNametags = Create(26, Types.General, "hideOutOfSightNametags", false);
        hideVentAnimOnShadows = Create(27, Types.General, "hideVentAnimOnShadows", false);
        showButtonTarget = Create(28, Types.General, "showButtonTarget", true);
        impostorSeeRoles = Create(29, Types.General, "impostorSeeRoles", false);
        blockGameEnd = Create(30, Types.General, "blockGameEnd", false);
        allowModGuess = Create(31, Types.General, "allowModGuess", false);
        enableCamoComms = Create(101, Types.General, "enableCamoComms", false, null, false);
        restrictDevices = Create(102, Types.General, "restrictDevices", ["optionOff".Translate(), "perRound".Translate(), "perGame".Translate()], null, false);
        //restrictAdmin = Create(103, Types.General, "Restrict Admin Table", 30f, 0f, 600f, 5f, restrictDevices);
        restrictCameras = Create(104, Types.General, "restrictCameras", 30f, 0f, 600f, 5f, restrictDevices);
        restrictVents = Create(105, Types.General, "restrictVents", 30f, 0f, 600f, 5f, restrictDevices);
        disableCamsRound1 = Create(106, Types.General, "disableCamsRound1", false, null, false);
        deadImpsBlockSabotage = Create(109, Types.General, cs(Palette.ImpostorRed, "deadImpsBlockSabotage"), false, null, false);

        transparentTasks = Create(32, Types.General, "transparentTasks", false, null, true);
        disableMedbayWalk = Create(33, Types.General, "disableMedbayWalk", false);
        allowParallelMedBayScans = Create(34, Types.General, "allowParallelMedBayScans", false);
        finishTasksBeforeHauntingOrZoomingOut = Create(35, Types.General, "finishTasksBeforeHauntingOrZoomingOut", true);
        preventTaskEnd = Create(36, Types.General, "preventTaskEnd", false);

        //Map options
        randomGameStartPosition = Create(50, Types.General, "randomGameStartPosition", false, null, true, heading: "mapOptions");
        randomGameStartToVents = Create(51, Types.General, "randomGameStartToVents", false, randomGameStartPosition);
        ShowVentsOnMap = Create(65, Types.General, "ShowVentsOnMap", false, null);
        ShowVentsOnMeetingMap = Create(66, Types.General, "ShowVentsOnMeetingMap", true, ShowVentsOnMap);

        enableBetterPolus = Create(60, Types.General, "enableBetterPolus", false, null, true, heading: "betterPolus");
        movePolusVents = Create(61, Types.General, "movePolusVents", false, enableBetterPolus, false);
        movePolusVitals = Create(62, Types.General, "movePolusVitals", false, enableBetterPolus, false);
        swapNavWifi = Create(63, Types.General, "swapNavWifi", false, enableBetterPolus, false);
        moveColdTemp = Create(64, Types.General, "moveColdTemp", false, enableBetterPolus, false);

        camsNightVision = Create(107, Types.General, "camsNightVision", false, null, true, heading: "nightVision".Translate());
        camsNoNightVisionIfImpVision = Create(108, Types.General, "camsNoNightVisionIfImpVision", false, camsNightVision, false);

        dynamicMap = Create(120, Types.General, "dynamicMap", false, null, true, heading: "randomMaps");
        dynamicMapEnableSkeld = Create(121, Types.General, "Skeld", rates, dynamicMap, false);
        dynamicMapEnableMira = Create(122, Types.General, "Mira", rates, dynamicMap, false);
        dynamicMapEnablePolus = Create(123, Types.General, "Polus", rates, dynamicMap, false);
        dynamicMapEnableAirShip = Create(124, Types.General, "Airship", rates, dynamicMap, false);
        dynamicMapEnableFungle = Create(125, Types.General, "Fungle", rates, dynamicMap, false);
        dynamicMapEnableSubmerged = Create(126, Types.General, "Submerged", rates, dynamicMap, false);
        dynamicMapSeparateSettings = Create(127, Types.General, "dynamicMapSeparateSettings", false, dynamicMap, false);

        debugMode = Create(200, Types.General, "debugModeEnable", false, null, true, heading: "debugMode");
        disableGameEnd = Create(201, Types.General, "disableGameEnd", false, debugMode);

        //-------------------------- Impostor Options 10000-19999 -------------------------- //

        modifierAssassin = Create(10000, Types.Impostor, cs(Color.red, "assassin"), rates, null, true);
        modifierAssassinQuantity = Create(10001, Types.Impostor, cs(Color.red, "modifierAssassinQuantity"), ratesModifier, modifierAssassin);
        modifierAssassinNumberOfShots = Create(10002, Types.Impostor, "modifierAssassinNumberOfShots", 5f, 1f, 15f, 1f, modifierAssassin);
        modifierAssassinMultipleShotsPerMeeting = Create(10003, Types.Impostor, "modifierAssassinMultipleShotsPerMeeting", true, modifierAssassin);
        guesserEvilCanKillSpy = Create(10004, Types.Impostor, "guesserEvilCanKillSpy", true, modifierAssassin);
        guesserEvilCanKillCrewmate = Create(10005, Types.Impostor, "guesserEvilCanKillCrewmate", true, modifierAssassin);
        guesserCantGuessSnitchIfTaksDone = Create(10006, Types.Impostor, "guesserCantGuessSnitchIfTaksDone", true, modifierAssassin);
        modifierAssassinKillsThroughShield = Create(10007, Types.Impostor, "modifierAssassinKillsThroughShield", false, modifierAssassin);
        modifierAssassinCultist = Create(10008, Types.Impostor, "modifierAssassinCultist", false, modifierAssassin);

        mafiaSpawnRate = Create(10010, Types.Impostor, cs(Janitor.color, "mafia"), rates, null, true);
        janitorCooldown = Create(10011, Types.Impostor, "janitorCooldown", 30f, 10f, 60f, 2.5f, mafiaSpawnRate);

        morphlingSpawnRate = Create(10020, Types.Impostor, cs(Morphling.color, "morphling"), rates, null, true);
        morphlingCooldown = Create(10021, Types.Impostor, "morphlingCooldown", 30f, 10f, 60f, 2.5f, morphlingSpawnRate);
        morphlingDuration = Create(10022, Types.Impostor, "morphlingDuration", 10f, 1f, 20f, 0.5f, morphlingSpawnRate);

        bomberSpawnRate = Create(10030, Types.Impostor, cs(Bomber.color, "bomber"), rates, null, true);
        bomberBombCooldown = Create(10031, Types.Impostor, "bomberBombCooldown", 25f, 10f, 60f, 2.5f, bomberSpawnRate);
        bomberDelay = Create(10032, Types.Impostor, "bomberDelay", 5f, 1f, 20f, 0.5f, bomberSpawnRate);
        bomberTimer = Create(10033, Types.Impostor, "bomberTimer", 12.5f, 5f, 30f, 0.5f, bomberSpawnRate);
        bomberTriggerBothCooldowns = Create(10034, Types.Impostor, "bomberTriggerBothCooldowns", true, bomberSpawnRate);
        bomberCanGiveToBomber = Create(10035, Types.Impostor, "bomberCanGiveToBomber", false, bomberSpawnRate);
        bomberHotPotatoMode = Create(10036, Types.Impostor, "bomberHotPotatoMode", false, bomberSpawnRate);

        undertakerSpawnRate = Create(10040, Types.Impostor, cs(Undertaker.color, "undertaker"), rates, null, true);
        undertakerDragingDelaiAfterKill = Create(10041, Types.Impostor, "undertakerDragingDelaiAfterKill", 0f, 0f, 15, 1f, undertakerSpawnRate);
        undertakerDragingAfterVelocity = Create(10042, Types.Impostor, "undertakerDragingAfterVelocity", 0.75f, 0.5f, 2f, 0.125f, undertakerSpawnRate);
        undertakerCanDragAndVent = Create(10043, Types.Impostor, "undertakerCanDragAndVent", true, undertakerSpawnRate);

        camouflagerSpawnRate = Create(10050, Types.Impostor, cs(Camouflager.color, "camouflager"), rates, null, true);
        camouflagerCooldown = Create(10051, Types.Impostor, "camouflagerCooldown", 30f, 10f, 60f, 2.5f, camouflagerSpawnRate);
        camouflagerDuration = Create(10052, Types.Impostor, "camouflagerDuration", 10f, 1f, 20f, 0.5f, camouflagerSpawnRate);

        vampireSpawnRate = Create(10060, Types.Impostor, cs(Vampire.color, "vampire"), rates, null, true);
        vampireKillDelay = Create(10061, Types.Impostor, "vampireKillDelay", 10f, 1f, 20f, 1f, vampireSpawnRate);
        vampireCooldown = Create(10062, Types.Impostor, "vampireCooldown", 30f, 10f, 60f, 2.5f, vampireSpawnRate);
        vampireGarlicButton = Create(10063, Types.Impostor, "vampireGarlicButton", true, vampireSpawnRate);
        vampireCanKillNearGarlics = Create(10064, Types.Impostor, "vampireCanKillNearGarlics", true, vampireGarlicButton);

        eraserSpawnRate = Create(10070, Types.Impostor, cs(Eraser.color, "eraser"), rates, null, true);
        eraserCooldown = Create(10071, Types.Impostor, "eraserCooldown", 30f, 10f, 120f, 5f, eraserSpawnRate);
        eraserCanEraseAnyone = Create(10072, Types.Impostor, "eraserCanEraseAnyone", false, eraserSpawnRate);

        poucherSpawnRate = Create(10080, Types.Impostor, cs(Poucher.color, "poucher"), rates, null, true);
        mimicSpawnRate = Create(10081, Types.Impostor, cs(Mimic.color, "mimic"), rates, null, true);

        escapistSpawnRate = Create(10090, Types.Impostor, cs(Escapist.color, "escapist"), rates, null, true);
        escapistEscapeTime = Create(10091, Types.Impostor, "escapistEscapeTime", 30, 0, 60, 5, escapistSpawnRate);
        escapistChargesOnPlace = Create(10092, Types.Impostor, "escapistChargesOnPlace", 1, 1, 10, 1, escapistSpawnRate);
        //escapistResetPlaceAfterMeeting = Create(10093, Types.Crewmate, "Reset Places After Meeting", true, jumperSpawnRate);
        //escapistChargesGainOnMeeting = Create(10094, Types.Crewmate, "Charges Gained After Meeting", 2, 0, 10, 1, jumperSpawnRate);
        //escapistMaxCharges = Create(10095, Types.Impostor, "Maximum Charges", 3, 0, 10, 1, escapistSpawnRate);

        cultistSpawnRate = Create(10100, Types.Impostor, cs(Cultist.color, "cultist"), rates, null, true);

        tricksterSpawnRate = Create(10110, Types.Impostor, cs(Trickster.color, "trickster"), rates, null, true);
        tricksterPlaceBoxCooldown = Create(10111, Types.Impostor, "tricksterPlaceBoxCooldown", 10f, 2.5f, 30f, 2.5f, tricksterSpawnRate);
        tricksterLightsOutCooldown = Create(10112, Types.Impostor, "tricksterLightsOutCooldown", 30f, 10f, 60f, 5f, tricksterSpawnRate);
        tricksterLightsOutDuration = Create(10113, Types.Impostor, "tricksterLightsOutDuration", 15f, 5f, 60f, 2.5f, tricksterSpawnRate);

        cleanerSpawnRate = Create(10120, Types.Impostor, cs(Cleaner.color, "cleaner"), rates, null, true);
        cleanerCooldown = Create(10121, Types.Impostor, "cleanerCooldown", 30f, 10f, 60f, 2.5f, cleanerSpawnRate);

        warlockSpawnRate = Create(10130, Types.Impostor, cs(Cleaner.color, "warlock"), rates, null, true);
        warlockCooldown = Create(10131, Types.Impostor, "warlockCooldown", 30f, 10f, 60f, 2.5f, warlockSpawnRate);
        warlockRootTime = Create(10132, Types.Impostor, "warlockRootTime", 5f, 0f, 15f, 1f, warlockSpawnRate);

        bountyHunterSpawnRate = Create(10140, Types.Impostor, cs(BountyHunter.color, "bountyHunter"), rates, null, true);
        bountyHunterBountyDuration = Create(10141, Types.Impostor, "bountyHunterBountyDuration", 60f, 10f, 180f, 10f, bountyHunterSpawnRate);
        bountyHunterReducedCooldown = Create(10142, Types.Impostor, "bountyHunterReducedCooldown", 2.5f, 0f, 30f, 2.5f, bountyHunterSpawnRate);
        bountyHunterPunishmentTime = Create(10143, Types.Impostor, "bountyHunterPunishmentTime", 20f, 0f, 60f, 2.5f, bountyHunterSpawnRate);
        bountyHunterShowArrow = Create(10144, Types.Impostor, "bountyHunterShowArrow", true, bountyHunterSpawnRate);
        bountyHunterArrowUpdateIntervall = Create(10145, Types.Impostor, "bountyHunterArrowUpdateIntervall", 15f, 2.5f, 60f, 2.5f, bountyHunterShowArrow);

        witchSpawnRate = Create(10150, Types.Impostor, cs(Witch.color, "witch"), rates, null, true);
        witchCooldown = Create(10151, Types.Impostor, "witchCooldown", 30f, 10f, 120f, 5f, witchSpawnRate);
        witchAdditionalCooldown = Create(10152, Types.Impostor, "witchAdditionalCooldown", 10f, 0f, 60f, 5f, witchSpawnRate);
        witchCanSpellAnyone = Create(10153, Types.Impostor, "witchCanSpellAnyone", false, witchSpawnRate);
        witchSpellCastingDuration = Create(10154, Types.Impostor, "witchSpellCastingDuration", 1f, 0f, 10f, 1f, witchSpawnRate);
        witchTriggerBothCooldowns = Create(10155, Types.Impostor, "witchTriggerBothCooldowns", true, witchSpawnRate);
        witchVoteSavesTargets = Create(10156, Types.Impostor, "witchVoteSavesTargets", true, witchSpawnRate);

        ninjaSpawnRate = Create(10160, Types.Impostor, cs(Ninja.color, "ninja"), rates, null, true);
        ninjaCooldown = Create(10161, Types.Impostor, "ninjaCooldown", 30f, 10f, 120f, 5f, ninjaSpawnRate);
        ninjaKnowsTargetLocation = Create(10162, Types.Impostor, "ninjaKnowsTargetLocation", true, ninjaSpawnRate);
        ninjaTraceTime = Create(10163, Types.Impostor, "ninjaTraceTime", 5f, 1f, 20f, 0.5f, ninjaSpawnRate);
        ninjaTraceColorTime = Create(10164, Types.Impostor, "ninjaTraceColorTime", 2f, 0f, 20f, 0.5f, ninjaSpawnRate);
        ninjaInvisibleDuration = Create(10165, Types.Impostor, "ninjaInvisibleDuration", 3f, 0f, 20f, 1f, ninjaSpawnRate);

        blackmailerSpawnRate = Create(10170, Types.Impostor, cs(Blackmailer.color, "blackmailer"), rates, null, true);
        blackmailerCooldown = Create(10171, Types.Impostor, "blackmailerCooldown", 30f, 5f, 120f, 5f, blackmailerSpawnRate);

        terroristSpawnRate = Create(10180, Types.Impostor, cs(Terrorist.color, "terrorist"), rates, null, true);
        terroristBombDestructionTime = Create(10181, Types.Impostor, "terroristBombDestructionTime", 20f, 2.5f, 120f, 2.5f, terroristSpawnRate);
        terroristBombDestructionRange = Create(10182, Types.Impostor, "terroristBombDestructionRange", 50f, 5f, 150f, 5f, terroristSpawnRate);
        terroristBombHearRange = Create(10183, Types.Impostor, "terroristBombHearRange", 60f, 5f, 150f, 5f, terroristSpawnRate);
        terroristDefuseDuration = Create(10184, Types.Impostor, "terroristDefuseDuration", 3f, 0.5f, 30f, 0.5f, terroristSpawnRate);
        terroristBombCooldown = Create(10185, Types.Impostor, "terroristBombCooldown", 15f, 2.5f, 30f, 2.5f, terroristSpawnRate);
        terroristBombActiveAfter = Create(10186, Types.Impostor, "terroristBombActiveAfter", 3f, 0.5f, 15f, 0.5f, terroristSpawnRate);

        minerSpawnRate = Create(10190, Types.Impostor, cs(Miner.color, "miner"), rates, null, true);
        minerCooldown = Create(10191, Types.Impostor, "minerCooldown", 25f, 10f, 60f, 2.5f, minerSpawnRate);

        yoyoSpawnRate = Create(10200, Types.Impostor, cs(Yoyo.color, "yoyo"), rates, null, true);
        yoyoBlinkDuration = Create(10201, Types.Impostor, "yoyoBlinkDuration", 20f, 2.5f, 120f, 2.5f, yoyoSpawnRate);
        yoyoMarkCooldown = Create(10202, Types.Impostor, "yoyoMarkCooldown", 20f, 2.5f, 120f, 2.5f, yoyoSpawnRate);
        yoyoMarkStaysOverMeeting = Create(10203, Types.Impostor, "yoyoMarkStaysOverMeeting", true, yoyoSpawnRate);
        yoyoHasAdminTable = Create(10204, Types.Impostor, "yoyoHasAdminTable", true, yoyoSpawnRate);
        yoyoAdminTableCooldown = Create(10205, Types.Impostor, "yoyoAdminTableCooldown", 20f, 2.5f, 120f, 2.5f, yoyoHasAdminTable);
        yoyoSilhouetteVisibility = Create(10206, Types.Impostor, "yoyoSilhouetteVisibility", ["0%", "10%", "20%", "30%", "40%", "50%"], yoyoSpawnRate);


        //-------------------------- Neutral Options 20000-29999 -------------------------- //

        jesterSpawnRate = Create(20000, Types.Neutral, cs(Jester.color, "jester"), rates, null, true);
        jesterCanCallEmergency = Create(20001, Types.Neutral, "jesterCanCallEmergency", true, jesterSpawnRate);
        jesterCanVent = Create(20002, Types.Neutral, "jesterCanVent", true, jesterSpawnRate);
        jesterHasImpostorVision = Create(20003, Types.Neutral, "jesterHasImpostorVision", false, jesterSpawnRate);

        amnisiacSpawnRate = Create(20010, Types.Neutral, cs(Amnisiac.color, "amnesiac"), rates, null, true);
        amnisiacShowArrows = Create(20011, Types.Neutral, "amnisiacShowArrows", true, amnisiacSpawnRate);
        amnisiacResetRole = Create(20012, Types.Neutral, "amnisiacResetRole", true, amnisiacSpawnRate);

        arsonistSpawnRate = Create(20030, Types.Neutral, cs(Arsonist.color, "arsonist"), rates, null, true);
        arsonistCooldown = Create(20031, Types.Neutral, "arsonistCooldown", 12.5f, 2.5f, 60f, 2.5f, arsonistSpawnRate);
        arsonistDuration = Create(20032, Types.Neutral, "arsonistDuration", 3f, 1f, 10f, 1f, arsonistSpawnRate);

        jackalSpawnRate = Create(20040, Types.Neutral, cs(Jackal.color, "jackal"), rates, null, true);
        jackalKillCooldown = Create(20041, Types.Neutral, "jackalKillCooldown", 30f, 10f, 60f, 2.5f, jackalSpawnRate);
        jackalChanceSwoop = Create(20042, Types.Neutral, cs(Swooper.color, "jackalChanceSwoop"), rates, jackalSpawnRate);
        swooperCooldown = Create(20043, Types.Neutral, "swooperCooldown", 30f, 10f, 60f, 2.5f, jackalChanceSwoop);
        swooperDuration = Create(20044, Types.Neutral, "swooperDuration", 10f, 1f, 20f, 0.5f, jackalChanceSwoop);
        jackalCanUseVents = Create(20045, Types.Neutral, "jackalCanUseVents", true, jackalSpawnRate);
        jackalCanUseSabo = Create(20046, Types.Neutral, "jackalCanUseSabo", false, jackalSpawnRate);
        jackalAndSidekickHaveImpostorVision = Create(20047, Types.Neutral, "jackalAndSidekickHaveImpostorVision", false, jackalSpawnRate);
        jackalCanCreateSidekick = Create(20048, Types.Neutral, "jackalCanCreateSidekick", false, jackalSpawnRate);
        jackalCreateSidekickCooldown = Create(20049, Types.Neutral, "jackalCreateSidekickCooldown", 30f, 10f, 60f, 2.5f, jackalCanCreateSidekick);
        jackalImpostorCanFindSidekick = Create(20050, Types.Neutral, cs(Palette.ImpostorRed, "jackalImpostorCanFindSidekick"), true, jackalCanCreateSidekick);
        sidekickCanKill = Create(20051, Types.Neutral, "sidekickCanKill", false, jackalCanCreateSidekick);
        sidekickCanUseVents = Create(20052, Types.Neutral, "sidekickCanUseVents", true, jackalCanCreateSidekick);
        sidekickPromotesToJackal = Create(20053, Types.Neutral, "sidekickPromotesToJackal", false, jackalCanCreateSidekick);
        jackalPromotedFromSidekickCanCreateSidekick = Create(20054, Types.Neutral, "jackalPromotedFromSidekickCanCreateSidekick", true, sidekickPromotesToJackal);
        jackalCanCreateSidekickFromImpostor = Create(20055, Types.Neutral, "jackalCanCreateSidekickFromImpostor", true, jackalCanCreateSidekick);
        jackalKillFakeImpostor = Create(20056, Types.Neutral, "jackalKillFakeImpostor", true, jackalCanCreateSidekick);

        vultureSpawnRate = Create(20060, Types.Neutral, cs(Vulture.color, "vulture"), rates, null, true);
        vultureCooldown = Create(20061, Types.Neutral, "vultureCooldown", 15f, 10f, 60f, 2.5f, vultureSpawnRate);
        vultureNumberToWin = Create(20062, Types.Neutral, "vultureNumberToWin", 4f, 1f, 10f, 1f, vultureSpawnRate);
        vultureCanUseVents = Create(20063, Types.Neutral, "vultureCanUseVents", true, vultureSpawnRate);
        vultureShowArrows = Create(20064, Types.Neutral, "vultureShowArrows", true, vultureSpawnRate);

        lawyerSpawnRate = Create(20070, Types.Neutral, cs(Lawyer.color, "lawyer"), rates, null, true);
        lawyerIsProsecutorChance = Create(20071, Types.Neutral, "lawyerIsProsecutorChance", rates, lawyerSpawnRate);
        lawyerTargetKnows = Create(20072, Types.Neutral, "lawyerTargetKnows", true, lawyerSpawnRate);
        lawyerVision = Create(20073, Types.Neutral, "lawyerVision", 1f, 0.25f, 3f, 0.25f, lawyerSpawnRate);
        lawyerKnowsRole = Create(20074, Types.Neutral, "lawyerKnowsRole", false, lawyerSpawnRate);
        lawyerCanCallEmergency = Create(20075, Types.Neutral, "lawyerCanCallEmergency", true, lawyerSpawnRate);
        lawyerTargetCanBeJester = Create(20076, Types.Neutral, "lawyerTargetCanBeJester", false, lawyerSpawnRate);
        pursuerCooldown = Create(20077, Types.Neutral, "pursuerCooldown", 30f, 5f, 60f, 2.5f, lawyerSpawnRate);
        pursuerBlanksNumber = Create(20078, Types.Neutral, "pursuerBlanksNumber", 5f, 1f, 20f, 1f, lawyerSpawnRate);

        doomsayerSpawnRate = Create(20221, Types.Neutral, cs(Doomsayer.color, "doomsayer"), rates, null, true);
        doomsayerCooldown = Create(20222, Types.Neutral, "doomsayerCooldown", 20f, 2.5f, 60f, 2.5f, doomsayerSpawnRate);
        //doomsayerHasMultipleShotsPerMeeting = Create(20223, Types.Neutral, "", true, doomsayerSpawnRate);
        //doomsayerCanGuessImpostor = Create(20226, Types.Neutral, $"Can Guess {cs(Palette.ImpostorRed, "Impostor")}", true, doomsayerSpawnRate);
        doomsayerCanGuessNeutral = Create(20225, Types.Neutral, $"doomsayerCanGuessNeutral".Translate() + $" {cs(Color.gray, "neutral")}", true, doomsayerSpawnRate);
        doomsayerOnlineTarger = Create(20227, Types.Neutral, "doomsayerOnlineTarger", false, doomsayerSpawnRate);
        doomsayerKillToWin = Create(20228, Types.Neutral, "doomsayerKillToWin", 3f, 1f, 10f, 1f, doomsayerSpawnRate);
        doomsayerDormationNum = Create(20229, Types.Neutral, "doomsayerDormationNum ", 5f, 1f, 10f, 1f, doomsayerSpawnRate);

        werewolfSpawnRate = Create(20080, Types.Neutral, cs(Werewolf.color, "werewolf"), rates, null, true);
        werewolfRampageCooldown = Create(20081, Types.Neutral, "werewolfRampageCooldown", 30f, 10f, 60f, 2.5f, werewolfSpawnRate);
        werewolfRampageDuration = Create(20082, Types.Neutral, "werewolfRampageDuration", 15f, 1f, 20f, 0.5f, werewolfSpawnRate);
        werewolfKillCooldown = Create(20083, Types.Neutral, "werewolfKillCooldown", 3f, 1f, 60f, 1f, werewolfSpawnRate);

        juggernautSpawnRate = Create(20110, Types.Neutral, cs(Juggernaut.color, "juggernaut"), rates, null, true);
        juggernautCooldown = Create(20111, Types.Neutral, "juggernautCooldown", 25f, 2.5f, 60f, 2.5f, juggernautSpawnRate);
        juggernautHasImpVision = Create(20112, Types.Neutral, "juggernautHasImpVision", true, juggernautSpawnRate);
        juggernautCanVent = Create(20113, Types.Neutral, "juggernautCanVent", true, juggernautSpawnRate);
        juggernautReducedkillEach = Create(20114, Types.Neutral, "juggernautReducedkillEach", 5f, 1f, 15f, 0.5f, juggernautSpawnRate);

        thiefSpawnRate = Create(20120, Types.Neutral, cs(Thief.color, "thief"), rates, null, true);
        thiefCooldown = Create(20121, Types.Neutral, "thiefCooldown", 30f, 5f, 120f, 5f, thiefSpawnRate);
        thiefCanKillSheriff = Create(20122, Types.Neutral, "thiefCanKillSheriff", true, thiefSpawnRate);
        thiefHasImpVision = Create(20123, Types.Neutral, "thiefHasImpVision", true, thiefSpawnRate);
        thiefCanUseVents = Create(20124, Types.Neutral, "thiefCanUseVents", true, thiefSpawnRate);
        thiefCanStealWithGuess = Create(20125, Types.Neutral, "thiefCanStealWithGuess", false, thiefSpawnRate);

        //-------------------------- Crewmate Options 30000-39999 -------------------------- //

        guesserSpawnRate = Create(30000, Types.Crewmate, cs(Guesser.color, "vigilante"), rates, null, true);
        guesserNumberOfShots = Create(30001, Types.Crewmate, "guesserNumberOfShots", 5f, 1f, 15f, 1f, guesserSpawnRate);
        guesserHasMultipleShotsPerMeeting = Create(30002, Types.Crewmate, "guesserHasMultipleShotsPerMeeting", true, guesserSpawnRate);
        guesserShowInfoInGhostChat = Create(30003, Types.Crewmate, "guesserShowInfoInGhostChat", true, guesserSpawnRate);
        guesserKillsThroughShield = Create(30004, Types.Crewmate, "guesserKillsThroughShield", false, guesserSpawnRate);

        mayorSpawnRate = Create(30010, Types.Crewmate, cs(Mayor.color, "mayor"), rates, null, true);
        mayorCanSeeVoteColors = Create(30011, Types.Crewmate, "mayorCanSeeVoteColors", false, mayorSpawnRate);
        mayorTasksNeededToSeeVoteColors = Create(30012, Types.Crewmate, "mayorTasksNeededToSeeVoteColors", 5f, 0f, 20f, 1f, mayorCanSeeVoteColors);
        mayorMeetingButton = Create(30013, Types.Crewmate, "mayorMeetingButton", true, mayorSpawnRate);
        mayorMaxRemoteMeetings = Create(30014, Types.Crewmate, "mayorMaxRemoteMeetings", 1f, 1f, 5f, 1f, mayorMeetingButton);
        mayorChooseSingleVote = Create(30015, Types.Crewmate, "mayorChooseSingleVote", ["optionOff".Translate(), "mayorChooseSingleVote1".Translate(), "mayorChooseSingleVote2".Translate()], mayorSpawnRate);

        engineerSpawnRate = Create(30020, Types.Crewmate, cs(Engineer.color, "engineer"), rates, null, true);
        engineerRemoteFix = Create(30021, Types.Crewmate, "engineerRemoteFix", true, engineerSpawnRate);
        engineerResetFixAfterMeeting = Create(30022, Types.Crewmate, "engineerResetFixAfterMeeting", false, engineerRemoteFix);
        engineerNumberOfFixes = Create(30023, Types.Crewmate, "engineerNumberOfFixes", 1f, 1f, 3f, 1f, engineerRemoteFix);
        //engineerExpertRepairs = Create(30024, Types.Crewmate, "Advanced Sabotage Repair", false, engineerSpawnRate);
        engineerHighlightForImpostors = Create(30025, Types.Crewmate, "engineerHighlightForImpostors", true, engineerSpawnRate);
        engineerHighlightForTeamJackal = Create(30026, Types.Crewmate, "engineerHighlightForTeamJackal", true, engineerSpawnRate);

        privateInvestigatorSpawnRate = Create(30030, Types.Crewmate, cs(PrivateInvestigator.color, "detective"), rates, null, true);
        privateInvestigatorSeeColor = Create(30031, Types.Crewmate, "privateInvestigatorSeeColor", true, privateInvestigatorSpawnRate);

        sheriffSpawnRate = Create(30040, Types.Crewmate, cs(Sheriff.color, "sheriff"), rates, null, true);
        sheriffCooldown = Create(30041, Types.Crewmate, "sheriffCooldown", 30f, 10f, 60f, 2.5f, sheriffSpawnRate);
        sheriffMisfireKills = Create(30042, Types.Crewmate, "sheriffMisfireKills", ["sheriffMisfireKills1".Translate(), "sheriffMisfireKills2".Translate(), "sheriffMisfireKills3".Translate()], sheriffSpawnRate);
        sheriffCanKillNeutrals = Create(30043, Types.Crewmate, "sheriffCanKillNeutrals", false, sheriffSpawnRate);
        sheriffCanKillJester = Create(30044, Types.Crewmate, "sheriffCanKill".Translate() + cs(Jester.color, "jester"), false, sheriffCanKillNeutrals);
        sheriffCanKillProsecutor = Create(30045, Types.Crewmate, "sheriffCanKill".Translate() + cs(Lawyer.color, "prosecutor"), false, sheriffCanKillNeutrals);
        sheriffCanKillAmnesiac = Create(30046, Types.Crewmate, "sheriffCanKill".Translate() + cs(Amnisiac.color, "amnesiac"), false, sheriffCanKillNeutrals);
        sheriffCanKillArsonist = Create(30047, Types.Crewmate, "sheriffCanKill".Translate() + cs(Arsonist.color, "arsonist"), false, sheriffCanKillNeutrals);
        sheriffCanKillVulture = Create(30048, Types.Crewmate, "sheriffCanKill".Translate() + cs(Vulture.color, "vulture"), false, sheriffCanKillNeutrals);
        sheriffCanKillLawyer = Create(30049, Types.Crewmate, "sheriffCanKill".Translate() + cs(Lawyer.color, "lawyer"), false, sheriffCanKillNeutrals);
        sheriffCanKillThief = Create(30050, Types.Crewmate, "sheriffCanKill".Translate() + cs(Thief.color, "thief"), false, sheriffCanKillNeutrals);
        sheriffCanKillPursuer = Create(30051, Types.Crewmate, "sheriffCanKill".Translate() + cs(Pursuer.color, "pursuer"), false, sheriffCanKillNeutrals);
        sheriffCanKillDoomsayer = Create(30052, Types.Crewmate, "sheriffCanKill".Translate() + cs(Doomsayer.color, "doomsayer"), false, sheriffCanKillNeutrals);

        deputySpawnRate = Create(30060, Types.Crewmate, cs(Deputy.color, "deputySpawnRate"), rates, sheriffSpawnRate);
        deputyNumberOfHandcuffs = Create(30061, Types.Crewmate, "deputyNumberOfHandcuffs", 3f, 1f, 10f, 1f, deputySpawnRate);
        deputyHandcuffCooldown = Create(30062, Types.Crewmate, "deputyHandcuffCooldown", 30f, 10f, 60f, 2.5f, deputySpawnRate);
        deputyHandcuffDuration = Create(30063, Types.Crewmate, "deputyHandcuffDuration", 15f, 5f, 60f, 2.5f, deputySpawnRate);
        deputyKnowsSheriff = Create(30064, Types.Crewmate, "deputyKnowsSheriff", true, deputySpawnRate);
        deputyGetsPromoted = Create(30065, Types.Crewmate, "deputyGetsPromoted", ["optionOff".Translate(), "deputyGetsPromoted1".Translate(), "deputyGetsPromoted2".Translate()], deputySpawnRate);
        deputyKeepsHandcuffs = Create(30066, Types.Crewmate, "deputyKeepsHandcuffs", true, deputyGetsPromoted);

        lighterSpawnRate = Create(30070, Types.Crewmate, cs(Lighter.color, "lighter"), rates, null, true);
        lighterModeLightsOnVision = Create(30071, Types.Crewmate, "lighterModeLightsOnVision", 1.5f, 0.25f, 5f, 0.25f, lighterSpawnRate);
        lighterModeLightsOffVision = Create(30072, Types.Crewmate, "lighterModeLightsOffVision", 0.5f, 0.25f, 5f, 0.25f, lighterSpawnRate);
        lighterFlashlightWidth = Create(30073, Types.Crewmate, "lighterFlashlightWidth", 0.3f, 0.1f, 1f, 0.1f, lighterSpawnRate);

        detectiveSpawnRate = Create(30080, Types.Crewmate, cs(Detective.color, "investigator"), rates, null, true);
        detectiveAnonymousFootprints = Create(30081, Types.Crewmate, "detectiveAnonymousFootprints", false, detectiveSpawnRate);
        detectiveFootprintIntervall = Create(30082, Types.Crewmate, "detectiveFootprintIntervall", 0.5f, 0.25f, 10f, 0.25f, detectiveSpawnRate);
        detectiveFootprintDuration = Create(30083, Types.Crewmate, "detectiveFootprintDuration", 5f, 0.25f, 10f, 0.25f, detectiveSpawnRate);
        detectiveReportNameDuration = Create(30084, Types.Crewmate, "detectiveReportNameDuration", 0, 0, 60, 2.5f, detectiveSpawnRate);
        detectiveReportColorDuration = Create(30085, Types.Crewmate, "detectiveReportColorDuration", 20, 0, 120, 2.5f, detectiveSpawnRate);

        timeMasterSpawnRate = Create(30090, Types.Crewmate, cs(TimeMaster.color, "timeMaster"), rates, null, true);
        timeMasterCooldown = Create(30091, Types.Crewmate, "timeMasterCooldown", 30f, 10f, 120f, 2.5f, timeMasterSpawnRate);
        timeMasterRewindTime = Create(30092, Types.Crewmate, "timeMasterRewindTime", 3f, 1f, 10f, 1f, timeMasterSpawnRate);
        timeMasterShieldDuration = Create(30093, Types.Crewmate, "timeMasterShieldDuration", 3f, 1f, 20f, 1f, timeMasterSpawnRate);

        veterenSpawnRate = Create(30100, Types.Crewmate, cs(Veteren.color, "veteran"), rates, null, true);
        veterenCooldown = Create(30101, Types.Crewmate, "veterenCooldown", 30f, 10f, 120f, 2.5f, veterenSpawnRate);
        veterenAlertDuration = Create(30102, Types.Crewmate, "veterenAlertDuration", 3f, 1f, 20f, 1f, veterenSpawnRate);

        medicSpawnRate = Create(30110, Types.Crewmate, cs(Medic.color, "medic"), rates, null, true);
        medicShowShielded = Create(30111, Types.Crewmate, "medicShowShielded", ["medicShowShielded1", "medicShowShielded2", "medicShowShielded3"], medicSpawnRate);
        medicBreakShield = Create(30112, Types.Crewmate, "medicBreakShield", true, medicSpawnRate);
        medicShowAttemptToShielded = Create(30113, Types.Crewmate, "medicShowAttemptToShielded", false, medicBreakShield);
        medicResetTargetAfterMeeting = Create(30114, Types.Crewmate, "medicResetTargetAfterMeeting", false, medicSpawnRate);
        medicSetOrShowShieldAfterMeeting = Create(30115, Types.Crewmate, "medicSetOrShowShieldAfterMeeting", ["medicSetOrShowShieldAfterMeeting1".Translate(), "medicSetOrShowShieldAfterMeeting2".Translate(), "medicSetOrShowShieldAfterMeeting3".Translate()], medicSpawnRate);
        medicShowAttemptToMedic = Create(30116, Types.Crewmate, "medicShowAttemptToMedic", false, medicBreakShield);

        swapperSpawnRate = Create(30120, Types.Crewmate, cs(Swapper.color, "swapper"), rates, null, true);
        swapperCanCallEmergency = Create(30121, Types.Crewmate, "swapperCanCallEmergency", false, swapperSpawnRate);
        swapperCanFixSabotages = Create(30122, Types.Crewmate, "swapperCanFixSabotages", false, swapperSpawnRate);
        swapperCanOnlySwapOthers = Create(30123, Types.Crewmate, "swapperCanOnlySwapOthers", false, swapperSpawnRate);
        swapperSwapsNumber = Create(30124, Types.Crewmate, "swapperSwapsNumber", 1f, 0f, 5f, 1f, swapperSpawnRate);
        swapperRechargeTasksNumber = Create(30125, Types.Crewmate, "swapperRechargeTasksNumber", 2f, 1f, 10f, 1f, swapperSpawnRate);

        seerSpawnRate = Create(30140, Types.Crewmate, cs(Seer.color, "seer"), rates, null, true);
        seerMode = Create(30141, Types.Crewmate, "seerMode", ["seerMode1".Translate(), "seerMode2".Translate(), "seerMode3".Translate()], seerSpawnRate);
        seerLimitSoulDuration = Create(30142, Types.Crewmate, "seerLimitSoulDuration", false, seerSpawnRate);
        seerSoulDuration = Create(30143, Types.Crewmate, "seerSoulDuration", 15f, 0f, 120f, 5f, seerLimitSoulDuration);

        hackerSpawnRate = Create(30150, Types.Crewmate, cs(Hacker.color, "Hacker"), rates, null, true);
        hackerCooldown = Create(30151, Types.Crewmate, "hackerCooldown", 30f, 5f, 60f, 5f, hackerSpawnRate);
        hackerHackeringDuration = Create(30152, Types.Crewmate, "hackerHackeringDuration", 10f, 2.5f, 60f, 2.5f, hackerSpawnRate);
        hackerOnlyColorType = Create(30153, Types.Crewmate, "hackerOnlyColorType", false, hackerSpawnRate);
        hackerToolsNumber = Create(30154, Types.Crewmate, "hackerToolsNumber", 5f, 1f, 30f, 1f, hackerSpawnRate);
        hackerRechargeTasksNumber = Create(30155, Types.Crewmate, "hackerRechargeTasksNumber", 2f, 1f, 5f, 1f, hackerSpawnRate);
        hackerNoMove = Create(30156, Types.Crewmate, "hackerNoMove", true, hackerSpawnRate);

        trackerSpawnRate = Create(30160, Types.Crewmate, cs(Tracker.color, "tracker"), rates, null, true);
        trackerUpdateIntervall = Create(30161, Types.Crewmate, "trackerUpdateIntervall", 5f, 1f, 30f, 1f, trackerSpawnRate);
        trackerResetTargetAfterMeeting = Create(30162, Types.Crewmate, "trackerResetTargetAfterMeeting", false, trackerSpawnRate);
        trackerCanTrackCorpses = Create(30163, Types.Crewmate, "trackerCanTrackCorpses", true, trackerSpawnRate);
        trackerCorpsesTrackingCooldown = Create(30164, Types.Crewmate, "trackerCorpsesTrackingCooldown", 30f, 5f, 120f, 5f, trackerCanTrackCorpses);
        trackerCorpsesTrackingDuration = Create(30165, Types.Crewmate, "trackerCorpsesTrackingDuration", 5f, 2.5f, 30f, 2.5f, trackerCanTrackCorpses);
        trackerTrackingMethod = Create(30166, Types.Crewmate, "trackerTrackingMethod", ["trackerTrackingMethod1".Translate(), "trackerTrackingMethod2".Translate(), "trackerTrackingMethod3".Translate()], trackerSpawnRate);

        snitchSpawnRate = Create(30170, Types.Crewmate, cs(Snitch.color, "snitch"), rates, null, true);
        snitchLeftTasksForReveal = Create(30171, Types.Crewmate, "snitchLeftTasksForReveal", 1f, 0f, 10f, 1f, snitchSpawnRate);
        snitchSeeMeeting = Create(30172, Types.Crewmate, "snitchSeeMeeting", true, snitchSpawnRate);
        //snitchCanSeeRoles = Create(30173, Types.Crewmate, "Can See Roles Info", false, snitchSeeMeeting);
        snitchIncludeNeutralTeam = Create(30174, Types.Crewmate, "snitchIncludeNeutralTeam", ["optionOff", "snitchIncludeNeutralTeam1".Translate(), "snitchIncludeNeutralTeam2".Translate(), ""], snitchSpawnRate);
        snitchTeamNeutraUseDifferentArrowColor = Create(30175, Types.Crewmate, "snitchTeamNeutraUseDifferentArrowColor", true, snitchIncludeNeutralTeam);

        spySpawnRate = Create(30180, Types.Crewmate, cs(Spy.color, "spy"), rates, null, true);
        spyCanDieToSheriff = Create(30181, Types.Crewmate, "spyCanDieToSheriff", false, spySpawnRate);
        spyImpostorsCanKillAnyone = Create(30182, Types.Crewmate, "spyImpostorsCanKillAnyone", true, spySpawnRate);
        spyCanEnterVents = Create(30183, Types.Crewmate, "spyCanEnterVents", false, spySpawnRate);
        spyHasImpostorVision = Create(30184, Types.Crewmate, "spyHasImpostorVision", false, spySpawnRate);

        portalmakerSpawnRate = Create(30190, Types.Crewmate, cs(Portalmaker.color, "portalmaker"), rates, null, true);
        portalmakerCooldown = Create(30191, Types.Crewmate, "portalmakerCooldown", 30f, 10f, 60f, 2.5f, portalmakerSpawnRate);
        portalmakerUsePortalCooldown = Create(30192, Types.Crewmate, "portalmakerUsePortalCooldown", 30f, 10f, 60f, 2.5f, portalmakerSpawnRate);
        portalmakerLogOnlyColorType = Create(30193, Types.Crewmate, "portalmakerLogOnlyColorType", true, portalmakerSpawnRate);
        portalmakerLogHasTime = Create(30194, Types.Crewmate, "portalmakerLogHasTime", true, portalmakerSpawnRate);
        portalmakerCanPortalFromAnywhere = Create(30195, Types.Crewmate, "portalmakerCanPortalFromAnywhere", true, portalmakerSpawnRate);

        securityGuardSpawnRate = Create(30200, Types.Crewmate, cs(SecurityGuard.color, "securityGuard"), rates, null, true);
        securityGuardCooldown = Create(30201, Types.Crewmate, "securityGuardCooldown", 30f, 10f, 60f, 2.5f, securityGuardSpawnRate);
        securityGuardTotalScrews = Create(30202, Types.Crewmate, "securityGuardTotalScrews", 7f, 1f, 15f, 1f, securityGuardSpawnRate);
        securityGuardCamPrice = Create(30203, Types.Crewmate, "securityGuardCamPrice", 2f, 1f, 15f, 1f, securityGuardSpawnRate);
        securityGuardVentPrice = Create(30204, Types.Crewmate, "securityGuardVentPrice", 1f, 1f, 15f, 1f, securityGuardSpawnRate);
        securityGuardCamDuration = Create(30205, Types.Crewmate, "securityGuardCamDuration", 10f, 2.5f, 60f, 2.5f, securityGuardSpawnRate);
        securityGuardCamMaxCharges = Create(30206, Types.Crewmate, "securityGuardCamMaxCharges", 5f, 1f, 30f, 1f, securityGuardSpawnRate);
        securityGuardCamRechargeTasksNumber = Create(30207, Types.Crewmate, "securityGuardCamRechargeTasksNumber", 3f, 1f, 10f, 1f, securityGuardSpawnRate);
        securityGuardNoMove = Create(30208, Types.Crewmate, "securityGuardNoMove", true, securityGuardSpawnRate);

        mediumSpawnRate = Create(30210, Types.Crewmate, cs(Medium.color, "Medium"), rates, null, true);
        mediumCooldown = Create(30211, Types.Crewmate, "Medium Questioning Cooldown", 30f, 5f, 120f, 5f, mediumSpawnRate);
        mediumDuration = Create(30212, Types.Crewmate, "Medium Questioning Duration", 3f, 0f, 15f, 1f, mediumSpawnRate);
        mediumOneTimeUse = Create(30213, Types.Crewmate, "Each Soul Can Only Be Questioned Once", false, mediumSpawnRate);
        mediumChanceAdditionalInfo = Create(30214, Types.Crewmate, "Chance That The Answer Contains \n    Additional Information", rates, mediumSpawnRate);

        jumperSpawnRate = Create(30220, Types.Crewmate, cs(Jumper.color, "jumper"), rates, null, true);
        jumperJumpTime = Create(30221, Types.Crewmate, "jumperJumpTime", 30, 0, 60, 5, jumperSpawnRate);
        jumperChargesOnPlace = Create(30222, Types.Crewmate, "jumperChargesOnPlace", 1, 1, 10, 1, jumperSpawnRate);
        //jumperResetPlaceAfterMeeting = Create(30223, Types.Crewmate, "Reset Places After Meeting", true, jumperSpawnRate);
        //jumperChargesGainOnMeeting = Create(30224, Types.Crewmate, "Charges Gained After Meeting", 2, 0, 10, 1, jumperSpawnRate);
        //jumperMaxCharges = Create(30225, Types.Crewmate, "Maximum Charges", 3, 0, 10, 1, jumperSpawnRate);

        bodyGuardSpawnRate = Create(30230, Types.Crewmate, cs(BodyGuard.color, "bodyGuard"), rates, null, true);
        bodyGuardResetTargetAfterMeeting = Create(30231, Types.Crewmate, "bodyGuardResetTargetAfterMeeting", true, bodyGuardSpawnRate);
        bodyGuardFlash = Create(30232, Types.Crewmate, "bodyGuardFlash", true, bodyGuardSpawnRate);

        trapperSpawnRate = Create(30250, Types.Crewmate, cs(Trapper.color, "trapper"), rates, null, true);
        trapperCooldown = Create(30251, Types.Crewmate, "trapperCooldown", 30f, 5f, 120f, 5f, trapperSpawnRate);
        trapperMaxCharges = Create(30252, Types.Crewmate, "trapperMaxCharges", 5f, 1f, 15f, 1f, trapperSpawnRate);
        trapperRechargeTasksNumber = Create(30253, Types.Crewmate, "trapperRechargeTasksNumber", 2f, 1f, 15f, 1f, trapperSpawnRate);
        trapperTrapNeededTriggerToReveal = Create(30254, Types.Crewmate, "trapperTrapNeededTriggerToReveal", 3f, 2f, 10f, 1f, trapperSpawnRate);
        trapperAnonymousMap = Create(30255, Types.Crewmate, "trapperAnonymousMap", false, trapperSpawnRate);
        trapperInfoType = Create(30256, Types.Crewmate, "trapperInfoType", ["trapperInfoType1".Translate(), "trapperInfoType2".Translate(), "trapperInfoType3".Translate()], trapperSpawnRate);
        trapperTrapDuration = Create(30257, Types.Crewmate, "trapperTrapDuration", 5f, 1f, 15f, 1f, trapperSpawnRate);

        //-------------------------- Modifier (1000 - 1999) -------------------------- //

        modifiersAreHidden = Create(1009, Types.Modifier, cs(Color.yellow, "modifiersAreHidden"), true, null, true, heading: cs(Color.yellow, "hideAfterDeathModifiers"));

        modifierDisperser = Create(1010, Types.Modifier, cs(Color.red, "disperser"), rates, null, true);
        modifierDisperserCooldown = Create(1011, Types.Modifier, "modifierDisperserCooldown", 30f, 10f, 60f, 2.5f, modifierDisperser);
        modifierDisperserNumberOfUses = Create(1012, Types.Modifier, "modifierDisperserNumberOfUses", 1, 1, 5, 1, modifierDisperser);
        modifierDisperserDispersesToVent = Create(1013, Types.Modifier, "modifierDisperserDispersesToVent", true, modifierDisperser);

        modifierBloody = Create(1020, Types.Modifier, cs(Color.yellow, "bloody"), rates, null, true);
        modifierBloodyQuantity = Create(1021, Types.Modifier, cs(Color.yellow, "modifierBloodyQuantity"), ratesModifier, modifierBloody);
        modifierBloodyDuration = Create(1022, Types.Modifier, "modifierBloodyDuration", 10f, 3f, 60f, 1f, modifierBloody);

        modifierAntiTeleport = Create(1030, Types.Modifier, cs(Color.yellow, "antiTeleport"), rates, null, true);
        modifierAntiTeleportQuantity = Create(1031, Types.Modifier, cs(Color.yellow, "modifierAntiTeleportQuantity"), ratesModifier, modifierAntiTeleport);

        modifierTieBreaker = Create(1040, Types.Modifier, cs(Color.yellow, "tieBreaker"), rates, null, true);

        modifierBait = Create(1050, Types.Modifier, cs(Color.yellow, "bait"), rates, null, true);
        modifierBaitQuantity = Create(1051, Types.Modifier, cs(Color.yellow, "modifierBaitQuantity"), ratesModifier, modifierBait);
        modifierBaitReportDelayMin = Create(1052, Types.Modifier, "modifierBaitReportDelayMin", 0f, 0f, 10f, 1f, modifierBait);
        modifierBaitReportDelayMax = Create(1053, Types.Modifier, "modifierBaitReportDelayMax", 0f, 0f, 10f, 1f, modifierBait);
        modifierBaitShowKillFlash = Create(1054, Types.Modifier, "modifierBaitShowKillFlash", true, modifierBait);

        modifierAftermath = Create(1230, Types.Modifier, cs(Color.yellow, "aftermath"), rates, null, true);

        modifierLover = Create(1060, Types.Modifier, cs(Color.yellow, "lovers"), rates, null, true);
        modifierLoverImpLoverRate = Create(1061, Types.Modifier, "modifierLoverImpLoverRate", rates, modifierLover);
        modifierLoverBothDie = Create(1062, Types.Modifier, "modifierLoverBothDie", true, modifierLover);
        modifierLoverEnableChat = Create(1063, Types.Modifier, "modifierLoverEnableChat", true, modifierLover);

        modifierSunglasses = Create(1070, Types.Modifier, cs(Color.yellow, "sunglasses"), rates, null, true);
        modifierSunglassesQuantity = Create(1071, Types.Modifier, cs(Color.yellow, "modifierSunglassesQuantity"), ratesModifier, modifierSunglasses);
        modifierSunglassesVision = Create(1072, Types.Modifier, "modifierSunglassesVision", ["-10%", "-20%", "-30%", "-40%", "-50%"], modifierSunglasses);

        modifierTorch = Create(1080, Types.Modifier, cs(Color.yellow, "torch"), rates, null, true);
        modifierTorchQuantity = Create(1081, Types.Modifier, cs(Color.yellow, "modifierTorchQuantity"), ratesModifier, modifierTorch);
        modifierTorchVision = Create(1082, Types.Modifier, cs(Color.yellow, "modifierTorchVision"), 1.5f, 1f, 3f, 0.125f, modifierTorch);

        modifierFlash = Create(1090, Types.Modifier, cs(Color.yellow, "flash"), rates, null, true);
        modifierFlashQuantity = Create(110, Types.Modifier, cs(Color.yellow, "modifierFlashQuantity"), ratesModifier, modifierFlash);
        modifierFlashSpeed = Create(1212, Types.Modifier, "modifierFlashSpeed", 1.25f, 1f, 3f, 0.125f, modifierFlash);

        modifierMultitasker = Create(1100, Types.Modifier, cs(Color.yellow, "multitasker"), rates, null, true);
        modifierMultitaskerQuantity = Create(1101, Types.Modifier, cs(Color.yellow, "modifierMultitaskerQuantity"), ratesModifier, modifierMultitasker);

        modifierMini = Create(1110, Types.Modifier, cs(Color.yellow, "mini"), rates, null, true);
        modifierMiniGrowingUpDuration = Create(1111, Types.Modifier, "modifierMiniGrowingUpDuration", 400f, 100f, 1500f, 100f, modifierMini);
        modifierMiniGrowingUpInMeeting = Create(1112, Types.Modifier, "modifierMiniGrowingUpInMeeting", true, modifierMini);

        modifierGiant = Create(1240, Types.Modifier, cs(Color.yellow, "giant"), rates, null, true);
        modifierGiantSpped = Create(1241, Types.Modifier, "modifierGiantSpped", 0.75f, 0.5f, 1.25f, 0.05f, modifierGiant);

        modifierIndomitable = Create(1120, Types.Modifier, cs(Color.yellow, "indomitable"), rates, null, true);

        modifierBlind = Create(1130, Types.Modifier, cs(Color.yellow, "blind"), rates, null, true);

        modifierWatcher = Create(1140, Types.Modifier, cs(Color.yellow, "watcher"), rates, null, true);

        modifierRadar = Create(1150, Types.Modifier, cs(Color.yellow, "radar"), rates, null, true);

        modifierTunneler = Create(1160, Types.Modifier, cs(Color.yellow, "tunneler"), rates, null, true);

        modifierSlueth = Create(1170, Types.Modifier, cs(Color.yellow, "sleuth"), rates, null, true);

        modifierCursed = Create(1180, Types.Modifier, cs(Color.yellow, "fanatic"), rates, null, true);

        modifierVip = Create(1190, Types.Modifier, cs(Color.yellow, "vip"), rates, null, true);
        modifierVipQuantity = Create(1191, Types.Modifier, cs(Color.yellow, "modifierVipQuantity"), ratesModifier, modifierVip);
        modifierVipShowColor = Create(1192, Types.Modifier, "modifierVipShowColor", true, modifierVip);

        modifierInvert = Create(1200, Types.Modifier, cs(Color.yellow, "invert"), rates, null, true);
        modifierInvertQuantity = Create(1201, Types.Modifier, cs(Color.yellow, "modifierInvertQuantity"), ratesModifier, modifierInvert);
        modifierInvertDuration = Create(1202, Types.Modifier, "modifierInvertDuration", 3f, 1f, 15f, 1f, modifierInvert);

        modifierChameleon = Create(1210, Types.Modifier, cs(Color.yellow, "chameleon"), rates, null, true);
        modifierChameleonQuantity = Create(1211, Types.Modifier, cs(Color.yellow, "modifierChameleonQuantity"), ratesModifier, modifierChameleon);
        modifierChameleonHoldDuration = Create(1212, Types.Modifier, "modifierChameleonHoldDuration", 3f, 1f, 10f, 0.5f, modifierChameleon);
        modifierChameleonFadeDuration = Create(1213, Types.Modifier, "modifierChameleonFadeDuration", 1f, 0.25f, 10f, 0.25f, modifierChameleon);
        modifierChameleonMinVisibility = Create(1214, Types.Modifier, "modifierChameleonMinVisibility", ["0%", "10%", "20%", "30%", "40%", "50%"], modifierChameleon);

        modifierArmored = CustomOption.Create(1101, Types.Modifier, cs(Color.yellow, "armored"), rates, null, true);

        modifierShifter = Create(1220, Types.Modifier, cs(Color.yellow, "shifter"), rates, null, true);

        //-------------------------- Guesser Gamemode 2000 - 2999 -------------------------- //

        guesserGamemodeCrewNumber = Create(2001, Types.Guesser, cs(Guesser.color, "guesserGamemodeCrewNumber"), 24f, 0f, 24f, 1f, null, true, heading: "headingAmountOfGuessers");
        guesserGamemodeNeutralNumber = Create(2002, Types.Guesser, cs(Guesser.color, "guesserGamemodeNeutralNumber"), 24f, 0f, 24f, 1f, null, false);
        guesserGamemodeImpNumber = Create(2003, Types.Guesser, cs(Guesser.color, "guesserGamemodeImpNumber"), 24f, 0f, 24f, 1f, null, false);
        guesserForceJackalGuesser = Create(2007, Types.Guesser, "guesserForceJackalGuesser", false, null, true, heading: "headingForceGuesser");
        guesserGamemodeSidekickIsAlwaysGuesser = Create(2012, Types.Guesser, "guesserGamemodeSidekickIsAlwaysGuesser", false, null);
        guesserForceThiefGuesser = Create(2011, Types.Guesser, "guesserForceThiefGuesser", false, null, true);
        guesserGamemodeHaveModifier = Create(2004, Types.Guesser, "guesserGamemodeHaveModifier", true, null, true, heading: "headingGeneralGuesser");
        guesserGamemodeNumberOfShots = Create(2005, Types.Guesser, "guesserGamemodeNumberOfShots", 3f, 1f, 24f, 1f, null, false);
        guesserGamemodeHasMultipleShotsPerMeeting = Create(2006, Types.Guesser, "guesserGamemodeHasMultipleShotsPerMeeting", false, null);
        guesserGamemodeCrewGuesserNumberOfTasks = Create(2013, Types.Guesser, "guesserGamemodeCrewGuesserNumberOfTasks", 0f, 0f, 15f, 1f, null); guesserGamemodeKillsThroughShield = Create(2008, Types.Guesser, "guesserGamemodeKillsThroughShield", true, null);
        guesserGamemodeEvilCanKillSpy = Create(2009, Types.Guesser, "guesserGamemodeEvilCanKillSpy", true, null);
        guesserGamemodeCantGuessSnitchIfTaksDone = Create(2010, Types.Guesser, "guesserGamemodeCantGuessSnitchIfTaksDone", true, null);

        //-------------------------- Hide N Seek 3000 - 3999 -------------------------- //

        hideNSeekMap = Create(3020, Types.HideNSeekMain, cs(Color.yellow, "hideNSeekMap"), new string[] { "The Skeld", "Mira", "Polus", "Airship", "Submerged" }, null, true);
        hideNSeekHunterCount = Create(3000, Types.HideNSeekMain, cs(Color.yellow, "hideNSeekHunterCount"), 1f, 1f, 3f, 1f);
        hideNSeekKillCooldown = Create(3021, Types.HideNSeekMain, cs(Color.yellow, "hideNSeekKillCooldown"), 10f, 2.5f, 60f, 2.5f);
        hideNSeekHunterVision = Create(3001, Types.HideNSeekMain, cs(Color.yellow, "hideNSeekHunterVision"), 0.5f, 0.25f, 2f, 0.25f);
        hideNSeekHuntedVision = Create(3002, Types.HideNSeekMain, cs(Color.yellow, "hideNSeekHuntedVision"), 2f, 0.25f, 5f, 0.25f);
        hideNSeekCommonTasks = Create(3023, Types.HideNSeekMain, cs(Color.yellow, "hideNSeekCommonTasks"), 1f, 0f, 4f, 1f);
        hideNSeekShortTasks = Create(3024, Types.HideNSeekMain, cs(Color.yellow, "hideNSeekShortTasks"), 3f, 1f, 23f, 1f);
        hideNSeekLongTasks = Create(3025, Types.HideNSeekMain, cs(Color.yellow, "hideNSeekLongTasks"), 3f, 0f, 15f, 1f);
        hideNSeekTimer = Create(3003, Types.HideNSeekMain, cs(Color.yellow, "hideNSeekTimer"), 5f, 1f, 30f, 1f);
        hideNSeekTaskWin = Create(3004, Types.HideNSeekMain, cs(Color.yellow, "hideNSeekTaskWin"), false);
        hideNSeekTaskPunish = Create(3017, Types.HideNSeekMain, cs(Color.yellow, "hideNSeekTaskPunish"), 10f, 0f, 30f, 1f);
        hideNSeekCanSabotage = Create(3019, Types.HideNSeekMain, cs(Color.yellow, "hideNSeekCanSabotage"), false);
        hideNSeekHunterWaiting = Create(3022, Types.HideNSeekMain, cs(Color.yellow, "hideNSeekHunterWaiting"), 15f, 2.5f, 60f, 2.5f);

        hunterLightCooldown = Create(3005, Types.HideNSeekRoles, cs(Color.red, "hunterLightCooldown"), 30f, 5f, 60f, 1f, null, true, heading: "headingHunterLight");
        hunterLightDuration = Create(3006, Types.HideNSeekRoles, cs(Color.red, "hunterLightDuration"), 5f, 1f, 60f, 1f);
        hunterLightVision = Create(3007, Types.HideNSeekRoles, cs(Color.red, "hunterLightVision"), 3f, 1f, 5f, 0.25f);
        hunterLightPunish = Create(3008, Types.HideNSeekRoles, cs(Color.red, "hunterLightPunish"), 5f, 0f, 30f, 1f);
        hunterAdminCooldown = Create(3009, Types.HideNSeekRoles, cs(Color.red, "hunterAdminCooldown"), 30f, 5f, 60f, 1f);
        hunterAdminDuration = Create(3010, Types.HideNSeekRoles, cs(Color.red, "hunterAdminDuration"), 5f, 1f, 60f, 1f);
        hunterAdminPunish = Create(3011, Types.HideNSeekRoles, cs(Color.red, "hunterAdminPunish"), 5f, 0f, 30f, 1f);
        hunterArrowCooldown = Create(3012, Types.HideNSeekRoles, cs(Color.red, "hunterArrowCooldown"), 30f, 5f, 60f, 1f);
        hunterArrowDuration = Create(3013, Types.HideNSeekRoles, cs(Color.red, "hunterArrowDuration"), 5f, 0f, 60f, 1f);
        hunterArrowPunish = Create(3014, Types.HideNSeekRoles, cs(Color.red, "hunterArrowPunish"), 5f, 0f, 30f, 1f);

        huntedShieldCooldown = Create(3015, Types.HideNSeekRoles, cs(Color.gray, "huntedShieldCooldown"), 30f, 5f, 60f, 1f, null, true, heading: "headingHuntedShield");
        huntedShieldDuration = Create(3016, Types.HideNSeekRoles, cs(Color.gray, "huntedShieldDuration"), 5f, 1f, 60f, 1f);
        huntedShieldRewindTime = Create(3018, Types.HideNSeekRoles, cs(Color.gray, "huntedShieldRewindTime"), 3f, 1f, 10f, 1f);
        huntedShieldNumber = Create(3026, Types.HideNSeekRoles, cs(Color.gray, "huntedShieldNumber"), 3f, 1f, 15f, 1f);

        //-------------------------- Prop Hunt General Options 4000 - 4999 -------------------------- //

        propHuntMap = Create(4020, Types.PropHunt, cs(Color.yellow, "hideNSeekMap"),
            ["The Skeld", "Mira", "Polus", "Airship", "Fungle", "Submerged", "LI Map"], null, true, onChange: () =>
            {
                int map = propHuntMap.selection; if (map >= 3) map++;
                GameOptionsManager.Instance.currentNormalGameOptions.MapId = (byte)map;
            });
        propHuntTimer = Create(4021, Types.PropHunt, cs(Color.yellow, "propHuntTimer"), 5f, 1f, 30f, 0.5f, null, true, heading: "generalPropHuntSettings");
        propHuntUnstuckCooldown = Create(4011, Types.PropHunt, cs(Color.yellow, "propHuntUnstuckCooldown"), 30f, 2.5f, 60f, 2.5f);
        propHuntUnstuckDuration = Create(4012, Types.PropHunt, cs(Color.yellow, "propHuntUnstuckDuration"), 2f, 1f, 60f, 1f);
        propHunterVision = Create(4006, Types.PropHunt, cs(Color.yellow, "propHunterVision"), 0.5f, 0.25f, 2f, 0.25f);
        propVision = Create(4007, Types.PropHunt, cs(Color.yellow, "propVision"), 2f, 0.25f, 5f, 0.25f);
        // Hunter Options
        propHuntNumberOfHunters = Create(4000, Types.PropHunt, cs(Color.red, "propHuntNumberOfHunters"), 1f, 1f, 5f, 1f, null, true, heading: "hunterSettings");
        hunterInitialBlackoutTime = Create(4001, Types.PropHunt, cs(Color.red, "hunterInitialBlackoutTime"), 10f, 5f, 20f, 1f);
        hunterMissCooldown = Create(4004, Types.PropHunt, cs(Color.red, "hunterMissCooldown"), 10f, 2.5f, 60f, 2.5f);
        hunterHitCooldown = Create(4005, Types.PropHunt, cs(Color.red, "hunterHitCooldown"), 10f, 2.5f, 60f, 2.5f);
        propHuntRevealCooldown = Create(4008, Types.PropHunt, cs(Color.red, "propHuntRevealCooldown"), 30f, 10f, 90f, 2.5f);
        propHuntRevealDuration = Create(4009, Types.PropHunt, cs(Color.red, "propHuntRevealDuration"), 5f, 1f, 60f, 1f);
        propHuntRevealPunish = Create(4010, Types.PropHunt, cs(Color.red, "propHuntRevealPunish"), 10f, 0f, 1800f, 5f);
        propHuntAdminCooldown = Create(4022, Types.PropHunt, cs(Color.red, "propHuntAdminCooldown"), 30f, 2.5f, 1800f, 2.5f);
        propHuntFindCooldown = Create(4023, Types.PropHunt, cs(Color.red, "propHuntFindCooldown"), 60f, 2.5f, 1800f, 2.5f);
        propHuntFindDuration = Create(4024, Types.PropHunt, cs(Color.red, "propHuntFindDuration"), 5f, 1f, 15f, 1f);
        // Prop Options
        propBecomesHunterWhenFound = Create(4003, Types.PropHunt, cs(Palette.CrewmateBlue, "propBecomesHunterWhenFound"), false, null, true, heading: "propSettings");
        propHuntInvisEnabled = Create(4013, Types.PropHunt, cs(Palette.CrewmateBlue, "propHuntInvisEnabled"), true, null, true);
        propHuntInvisCooldown = Create(4014, Types.PropHunt, cs(Palette.CrewmateBlue, "propHuntInvisCooldown"), 120f, 10f, 1800f, 2.5f, propHuntInvisEnabled);
        propHuntInvisDuration = Create(4015, Types.PropHunt, cs(Palette.CrewmateBlue, "propHuntInvisDuration"), 5f, 1f, 30f, 1f, propHuntInvisEnabled);
        propHuntSpeedboostEnabled = Create(4016, Types.PropHunt, cs(Palette.CrewmateBlue, "propHuntSpeedboostEnabled"), true, null, true);
        propHuntSpeedboostCooldown = Create(4017, Types.PropHunt, cs(Palette.CrewmateBlue, "propHuntSpeedboostCooldown"), 60f, 2.5f, 1800f, 2.5f, propHuntSpeedboostEnabled);
        propHuntSpeedboostDuration = Create(4018, Types.PropHunt, cs(Palette.CrewmateBlue, "propHuntSpeedboostDuration"), 5f, 1f, 15f, 1f, propHuntSpeedboostEnabled);
        propHuntSpeedboostSpeed = Create(4019, Types.PropHunt, cs(Palette.CrewmateBlue, "propHuntSpeedboostSpeed"), 2f, 1.25f, 5f, 0.25f, propHuntSpeedboostEnabled);


        blockedRolePairings.Add((byte)RoleId.Vampire, [(byte)RoleId.Warlock]);
        blockedRolePairings.Add((byte)RoleId.Witch, [(byte)RoleId.Warlock]);
        blockedRolePairings.Add((byte)RoleId.Warlock, [(byte)RoleId.Vampire]);

        blockedRolePairings.Add((byte)RoleId.Vulture, [(byte)RoleId.Cleaner]);
        blockedRolePairings.Add((byte)RoleId.Cleaner, [(byte)RoleId.Vulture]);
    }
}
