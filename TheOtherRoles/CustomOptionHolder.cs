using System.Collections.Generic;
using UnityEngine;
using static TheOtherRoles.TheOtherRoles;
using Types = TheOtherRoles.CustomOption.CustomOptionType;

namespace TheOtherRoles {
    public class CustomOptionHolder {
        public static string[] rates = new string[]{"0%", "10%", "20%", "30%", "40%", "50%", "60%", "70%", "80%", "90%", "100%"};
        public static string[] ratesModifier = new string[]{"1", "2", "3"};
        public static string[] presets = new string[]{"Preset 1", "Preset 2", "Preset 3", "Preset 4", "Preset 5"};

        public static CustomOption presetSelection;
        public static CustomOption activateRoles;
        public static CustomOption crewmateRolesCountMin;
        public static CustomOption crewmateRolesCountMax;
        public static CustomOption neutralRolesCountMin;
        public static CustomOption neutralRolesCountMax;
        public static CustomOption impostorRolesCountMin;
        public static CustomOption impostorRolesCountMax;
        public static CustomOption modifiersCountMin;
        public static CustomOption modifiersCountMax;
        
        public static CustomOption cultistSpawnRate;

        public static CustomOption impostorsTitle;

        public static CustomOption swooperSpawnRate;
        public static CustomOption swooperCooldown;
        public static CustomOption swooperAsWell;
        public static CustomOption swooperDuration;
        public static CustomOption swooperHasImpVision;
        
        public static CustomOption minerSpawnRate;
		public static CustomOption minerCooldown;
		
        public static CustomOption mafiaSpawnRate;
        public static CustomOption janitorCooldown;

        public static CustomOption morphlingSpawnRate;
        public static CustomOption morphlingCooldown;
        public static CustomOption morphlingDuration;
        
        public static CustomOption bomberSpawnRate;
        public static CustomOption bomberBombCooldown;
        public static CustomOption bomberDelay;
        public static CustomOption bomberTimer;

        public static CustomOption undertakerSpawnRate;
        public static CustomOption undertakerDragingDelaiAfterKill;
        public static CustomOption undertakerCanDragAndVent;

        public static CustomOption camouflagerSpawnRate;
        public static CustomOption camouflagerCooldown;
        public static CustomOption camouflagerDuration;


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
		
        public static CustomOption prosecutorSpawnRate;
        public static CustomOption prosecutorPreferAmnesiac;

        public static CustomOption amnisiacSpawnRate;
        public static CustomOption amnisiacShowArrows;
        public static CustomOption amnisiacResetRole;

        public static CustomOption arsonistSpawnRate;
        public static CustomOption arsonistCooldown;
        public static CustomOption arsonistDuration;

        public static CustomOption jackalSpawnRate;
        public static CustomOption jackalKillCooldown;
        public static CustomOption jackalCreateSidekickCooldown;
        public static CustomOption jackalKillFakeImpostor;
        public static CustomOption jackalCanUseVents;
        public static CustomOption jackalCanUseSabo;
        public static CustomOption jackalhasChat;
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

        public static CustomOption doorHackerSpawnRate;
        public static CustomOption doorHackerNumberOfUses;
        public static CustomOption doorHackerCooldown;
        public static CustomOption doorHackerDuration;

        public static CustomOption ninjaSpawnRate;
        public static CustomOption ninjaCooldown;
        public static CustomOption ninjaKnowsTargetLocation;
        public static CustomOption ninjaTraceTime;
        public static CustomOption ninjaTraceColorTime;
        public static CustomOption ninjaInvisibleDuration;

        public static CustomOption blackmailerSpawnRate;
        public static CustomOption blackmailerCooldown;

        public static CustomOption shifterSpawnRate;
        public static CustomOption shifterShiftsModifiers;
        public static CustomOption mayorSpawnRate;
        public static CustomOption mayorCanSeeVoteColors;
        public static CustomOption mayorTasksNeededToSeeVoteColors;
        public static CustomOption mayorMeetingButton;
        public static CustomOption mayorMaxRemoteMeetings;

        public static CustomOption portalmakerSpawnRate;
        public static CustomOption portalmakerCooldown;
        public static CustomOption portalmakerUsePortalCooldown;
        public static CustomOption portalmakerLogOnlyColorType;
        public static CustomOption portalmakerLogHasTime;

        public static CustomOption engineerSpawnRate;
        public static CustomOption engineerRemoteFix;
        public static CustomOption engineerExpertRepairs;
        public static CustomOption engineerResetFixAfterMeeting;
        public static CustomOption engineerNumberOfFixes;
        public static CustomOption engineerHighlightForImpostors;
        public static CustomOption engineerHighlightForTeamJackal;

        public static CustomOption sheriffSpawnRate;
        public static CustomOption sheriffCooldown;
        public static CustomOption sheriffMisfireKills;
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
        public static CustomOption lighterCooldown;
        public static CustomOption lighterDuration;

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

        public static CustomOption snitchSpawnRate;
        public static CustomOption snitchLeftTasksForReveal;
     //   public static CustomOption snitchCanSeeRoles;
        public static CustomOption snitchIncludeTeamJackal;
        public static CustomOption snitchTeamJackalUseDifferentArrowColor;

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
     //   public static CustomOption jumperChargesGainOnMeeting;
        public static CustomOption jumperMaxCharges;

        public static CustomOption escapistSpawnRate;
        public static CustomOption escapistEscapeTime;
        public static CustomOption escapistChargesOnPlace;
        public static CustomOption escapistResetPlaceAfterMeeting;
     //   public static CustomOption jumperChargesGainOnMeeting;
        public static CustomOption escapistMaxCharges;

        public static CustomOption werewolfSpawnRate;
        public static CustomOption werewolfRampageCooldown;
        public static CustomOption werewolfRampageDuration;
        public static CustomOption werewolfKillCooldown;
        
        public static CustomOption thiefSpawnRate;
        public static CustomOption thiefCooldown;
        public static CustomOption thiefHasImpVision;
        public static CustomOption thiefCanUseVents;
        public static CustomOption thiefCanKillSheriff;

        public static CustomOption trapperSpawnRate;
        public static CustomOption trapperCooldown;
        public static CustomOption trapperMaxCharges;
        public static CustomOption trapperRechargeTasksNumber;
        public static CustomOption trapperTrapNeededTriggerToReveal;
        public static CustomOption trapperAnonymousMap;
        public static CustomOption trapperInfoType;
        public static CustomOption trapperTrapDuration;

        public static CustomOption madmateSpawnRate;
        public static CustomOption madmateCanVent;
        public static CustomOption madmateCanFixLightAndComms;
        public static CustomOption madmateHasImpostorVision;

        public static CustomOption modifiersAreHidden;

        public static CustomOption modifierAssassin;
        public static CustomOption modifierAssassinQuantity;
        public static CustomOption modifierAssassinNumberOfShots;
        public static CustomOption modifierAssassinMultipleShotsPerMeeting;
        public static CustomOption modifierAssassinKillsThroughShield;

        public static CustomOption modifierPhantomAbility;

        public static CustomOption modifierBait;
        public static CustomOption modifierBaitQuantity;
        public static CustomOption modifierBaitReportDelayMin;
        public static CustomOption modifierBaitReportDelayMax;
        public static CustomOption modifierBaitShowKillFlash;

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

        public static CustomOption modifierMultitasker;
        public static CustomOption modifierMultitaskerQuantity;

        public static CustomOption modifierDisperser;
        
        public static CustomOption modifierMini;
        public static CustomOption modifierMiniGrowingUpDuration;
        public static CustomOption modifierMiniGrowingUpInMeeting;

        public static CustomOption modifierIndomitable;
    //    public static CustomOption modifierLifeGuard;
        public static CustomOption modifierTunneler;
        public static CustomOption modifierBlind;
        public static CustomOption modifierWatcher;
        public static CustomOption modifierRadar;
        public static CustomOption modifierSlueth;
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

        public static CustomOption maxNumberOfMeetings;
        public static CustomOption blockSkippingInEmergencyMeetings;
        public static CustomOption noVoteIsSelfVote;
        public static CustomOption hidePlayerNames;
        public static CustomOption showButtonTarget;
        public static CustomOption blockGameEnd;
        public static CustomOption allowParallelMedBayScans;
        public static CustomOption shieldFirstKill;
        public static CustomOption nightVisionLightSabotage;
        public static CustomOption hideVentAnimOnShadows;
     //   public static CustomOption screenShakeReactorSabotage;
        public static CustomOption impostorSeeRoles;
        public static CustomOption transparentTasks;
        public static CustomOption impostorCanKillCustomRolesInTheVent;
        public static CustomOption debugMode;

        public static CustomOption randomGameStartPosition;
        public static CustomOption allowModGuess;
        public static CustomOption resetRoundStartCooldown;

        public static CustomOption dynamicMap;
        public static CustomOption dynamicMapEnableSkeld;
        public static CustomOption dynamicMapEnableMira;
        public static CustomOption dynamicMapEnablePolus;
        public static CustomOption dynamicMapEnableAirShip;
		
		public static CustomOption movePolusVents;
		public static CustomOption swapNavWifi;
		public static CustomOption movePolusVitals;
		public static CustomOption enableBetterPolus;
		public static CustomOption moveColdTemp;
		
		
		public static CustomOption enableCamoComms;
		
        public static CustomOption restrictDevices;
        public static CustomOption restrictAdmin;
        public static CustomOption restrictCameras;
        public static CustomOption restrictVents;

        internal static Dictionary<byte, byte[]> blockedRolePairings = new Dictionary<byte, byte[]>();

        public static string cs(Color c, string s) {
            return string.Format("<color=#{0:X2}{1:X2}{2:X2}{3:X2}>{4}</color>", ToByte(c.r), ToByte(c.g), ToByte(c.b), ToByte(c.a), s);
        }
 
        private static byte ToByte(float f) {
            f = Mathf.Clamp01(f);
            return (byte)(f * 255);
        }

        public static void Load() {
            
            
            // Role Options
            presetSelection = CustomOption.Create(0, Types.General, cs(new Color(204f / 255f, 204f / 255f, 0, 1f), "Preset"), presets, null, true);
            activateRoles = CustomOption.Create(1, Types.General, cs(new Color(204f / 255f, 204f / 255f, 0, 1f), "Enable Mod Roles And Block Vanilla Roles"), true, null, true);

            // Using new id's for the options to not break compatibilty with older versions
            crewmateRolesCountMin = CustomOption.Create(300, Types.General, cs(new Color(204f / 255f, 204f / 255f, 0, 1f), "Minimum Crewmate Roles"), 15f, 0f, 15f, 1f, null, true);
            crewmateRolesCountMax = CustomOption.Create(301, Types.General, cs(new Color(204f / 255f, 204f / 255f, 0, 1f), "Maximum Crewmate Roles"), 15f, 0f, 15f, 1f);
            neutralRolesCountMin = CustomOption.Create(302, Types.General, cs(new Color(204f / 255f, 204f / 255f, 0, 1f), "Minimum Neutral Roles"), 15f, 0f, 15f, 1f);
            neutralRolesCountMax = CustomOption.Create(303, Types.General, cs(new Color(204f / 255f, 204f / 255f, 0, 1f), "Maximum Neutral Roles"), 15f, 0f, 15f, 1f);
            impostorRolesCountMin = CustomOption.Create(304, Types.General, cs(new Color(204f / 255f, 204f / 255f, 0, 1f), "Minimum Impostor Roles"), 15f, 0f, 15f, 1f);
            impostorRolesCountMax = CustomOption.Create(305, Types.General, cs(new Color(204f / 255f, 204f / 255f, 0, 1f), "Maximum Impostor Roles"), 15f, 0f, 15f, 1f);
            modifiersCountMin = CustomOption.Create(306, Types.General, cs(new Color(204f / 255f, 204f / 255f, 0, 1f), "Minimum Modifiers"), 15f, 0f, 15f, 1f);
            modifiersCountMax = CustomOption.Create(307, Types.General, cs(new Color(204f / 255f, 204f / 255f, 0, 1f), "Maximum Modifiers"), 15f, 0f, 15f, 1f);
            
            modifierAssassin = CustomOption.Create(2000, Types.Impostor, cs(Color.red, "Assassin"), rates, null, true);
            modifierAssassinQuantity = CustomOption.Create(2001, Types.Impostor, cs(Color.red, "Assassin Quantity"), ratesModifier, modifierAssassin);
            modifierAssassinNumberOfShots = CustomOption.Create(2002, Types.Impostor, "Number Of Shots", 5f, 1f, 15f, 1f, modifierAssassin);
            modifierAssassinMultipleShotsPerMeeting = CustomOption.Create(2003, Types.Impostor, "Can Shoot Multiple Times Per Meeting", true, modifierAssassin);
            guesserEvilCanKillSpy = CustomOption.Create(2004, Types.Impostor, "Can Guess The Spy", true, modifierAssassin);
            guesserEvilCanKillCrewmate = CustomOption.Create(20045, Types.Impostor, "Can Guess Crewmate", true, modifierAssassin);
            guesserCantGuessSnitchIfTaksDone = CustomOption.Create(2005, Types.Impostor, "Can't Guess Snitch When Revealed", true, modifierAssassin);
            modifierAssassinKillsThroughShield = CustomOption.Create(2006, Types.Impostor, "Guesses Ignore The Medic Shield", false, modifierAssassin);
            
            mafiaSpawnRate = CustomOption.Create(10, Types.Impostor, cs(Janitor.color, "Mafia"), rates, null, true);
            janitorCooldown = CustomOption.Create(11, Types.Impostor, "Janitor Cooldown", 30f, 10f, 60f, 2.5f, mafiaSpawnRate);

            morphlingSpawnRate = CustomOption.Create(20, Types.Impostor, cs(Morphling.color, "Morphling"), rates, null, true);
            morphlingCooldown = CustomOption.Create(21, Types.Impostor, "Morphling Cooldown", 30f, 10f, 60f, 2.5f, morphlingSpawnRate);
            morphlingDuration = CustomOption.Create(22, Types.Impostor, "Morph Duration", 10f, 1f, 20f, 0.5f, morphlingSpawnRate);

        // public static CustomOption bomberSpawnRate;
        // public static CustomOption bomberBombCooldown;
        // public static CustomOption bomberDelay;
        // public static CustomOption bomberTimer;
        
            bomberSpawnRate = CustomOption.Create(8840, Types.Impostor, cs(Bomber.color, "Bomber [BETA]"), rates, null, true);
            bomberBombCooldown = CustomOption.Create(8841, Types.Impostor, "Bomber Cooldown", 30f, 25f, 60f, 2.5f, bomberSpawnRate);
            bomberDelay = CustomOption.Create(8842, Types.Impostor, "Bomb Delay", 10f, 1f, 20f, 0.5f, bomberSpawnRate);
            bomberTimer = CustomOption.Create(8843, Types.Impostor, "Bomb Timer", 10f, 5f, 30f, 5f, bomberSpawnRate);



            undertakerSpawnRate = CustomOption.Create(1201, Types.Impostor, cs(Undertaker.color, "Undertaker"), rates, null, true);
            undertakerDragingDelaiAfterKill = CustomOption.Create(1202, Types.Impostor, "Draging Delay After Kill", 0f, 0f, 15, 1f, undertakerSpawnRate);                     
            undertakerCanDragAndVent = CustomOption.Create(1203, Types.Impostor, "Can Vent While Dragging", true, undertakerSpawnRate);


            camouflagerSpawnRate = CustomOption.Create(30, Types.Impostor, cs(Camouflager.color, "Camouflager"), rates, null, true);
            camouflagerCooldown = CustomOption.Create(31, Types.Impostor, "Camouflager Cooldown", 30f, 10f, 60f, 2.5f, camouflagerSpawnRate);
            camouflagerDuration = CustomOption.Create(32, Types.Impostor, "Camo Duration", 10f, 1f, 20f, 0.5f, camouflagerSpawnRate);

            eraserSpawnRate = CustomOption.Create(230, Types.Impostor, cs(Eraser.color, "Eraser"), rates, null, true);
            eraserCooldown = CustomOption.Create(231, Types.Impostor, "Eraser Cooldown", 30f, 10f, 120f, 5f, eraserSpawnRate);
            eraserCanEraseAnyone = CustomOption.Create(232, Types.Impostor, "Eraser Can Erase Anyone", false, eraserSpawnRate);

            escapistSpawnRate = CustomOption.Create(905000, Types.Impostor, cs(Escapist.color, "Escapist"), rates, null, true);
            escapistEscapeTime = CustomOption.Create(905100, Types.Impostor, "Mark and Escape Cooldown", 30, 0, 60, 5, escapistSpawnRate);
            escapistChargesOnPlace = CustomOption.Create(905200, Types.Impostor, "Charges On Place", 1, 0, 10, 1, escapistSpawnRate);
     //       jumperResetPlaceAfterMeeting = CustomOption.Create(9052, Types.Crewmate, "Reset Places After Meeting", true, jumperSpawnRate);
     //       jumperChargesGainOnMeeting = CustomOption.Create(9053, Types.Crewmate, "Charges Gained After Meeting", 2, 0, 10, 1, jumperSpawnRate);
            escapistMaxCharges = CustomOption.Create(905400, Types.Impostor, "Maximum Charges", 3, 0, 10, 1, escapistSpawnRate);

            cultistSpawnRate =  CustomOption.Create(3801, Types.Impostor, cs(Cultist.color, "Cultist"), rates, null, true);

            tricksterSpawnRate = CustomOption.Create(250, Types.Impostor, cs(Trickster.color, "Trickster"), rates, null, true);
            tricksterPlaceBoxCooldown = CustomOption.Create(251, Types.Impostor, "Trickster Box Cooldown", 10f, 2.5f, 30f, 2.5f, tricksterSpawnRate);
            tricksterLightsOutCooldown = CustomOption.Create(252, Types.Impostor, "Trickster Lights Out Cooldown", 30f, 10f, 60f, 5f, tricksterSpawnRate);
            tricksterLightsOutDuration = CustomOption.Create(253, Types.Impostor, "Trickster Lights Out Duration", 15f, 5f, 60f, 2.5f, tricksterSpawnRate);

            cleanerSpawnRate = CustomOption.Create(260, Types.Impostor, cs(Cleaner.color, "Cleaner"), rates, null, true);
            cleanerCooldown = CustomOption.Create(261, Types.Impostor, "Cleaner Cooldown", 30f, 10f, 60f, 2.5f, cleanerSpawnRate);

            warlockSpawnRate = CustomOption.Create(270, Types.Impostor, cs(Cleaner.color, "Warlock"), rates, null, true);
            warlockCooldown = CustomOption.Create(271, Types.Impostor, "Warlock Cooldown", 30f, 10f, 60f, 2.5f, warlockSpawnRate);
            warlockRootTime = CustomOption.Create(272, Types.Impostor, "Warlock Root Time", 5f, 0f, 15f, 1f, warlockSpawnRate);

            bountyHunterSpawnRate = CustomOption.Create(320, Types.Impostor, cs(BountyHunter.color, "Bounty Hunter"), rates, null, true);
            bountyHunterBountyDuration = CustomOption.Create(321, Types.Impostor, "Duration After Which Bounty Changes",  60f, 10f, 180f, 10f, bountyHunterSpawnRate);
            bountyHunterReducedCooldown = CustomOption.Create(322, Types.Impostor, "Cooldown After Killing Bounty", 2.5f, 0f, 30f, 2.5f, bountyHunterSpawnRate);
            bountyHunterPunishmentTime = CustomOption.Create(323, Types.Impostor, "Additional Cooldown After Killing Others", 20f, 0f, 60f, 2.5f, bountyHunterSpawnRate);
            bountyHunterShowArrow = CustomOption.Create(324, Types.Impostor, "Show Arrow Pointing Towards The Bounty", true, bountyHunterSpawnRate);
            bountyHunterArrowUpdateIntervall = CustomOption.Create(325, Types.Impostor, "Arrow Update Intervall", 15f, 2.5f, 60f, 2.5f, bountyHunterShowArrow);

            witchSpawnRate = CustomOption.Create(370, Types.Impostor, cs(Witch.color, "Witch"), rates, null, true);
            witchCooldown = CustomOption.Create(371, Types.Impostor, "Witch Spell Casting Cooldown", 30f, 10f, 120f, 5f, witchSpawnRate);
            witchAdditionalCooldown = CustomOption.Create(372, Types.Impostor, "Witch Additional Cooldown", 10f, 0f, 60f, 5f, witchSpawnRate);
            witchCanSpellAnyone = CustomOption.Create(373, Types.Impostor, "Witch Can Spell Anyone", false, witchSpawnRate);
            witchSpellCastingDuration = CustomOption.Create(374, Types.Impostor, "Spell Casting Duration", 1f, 0f, 10f, 1f, witchSpawnRate);
            witchTriggerBothCooldowns = CustomOption.Create(375, Types.Impostor, "Trigger Both Cooldowns", true, witchSpawnRate);
            witchVoteSavesTargets = CustomOption.Create(376, Types.Impostor, "Voting The Witch Saves All The Targets", true, witchSpawnRate);

            ninjaSpawnRate = CustomOption.Create(380, Types.Impostor, cs(Ninja.color, "Ninja"), rates, null, true);
            ninjaCooldown = CustomOption.Create(381, Types.Impostor, "Ninja Mark Cooldown", 30f, 10f, 120f, 5f, ninjaSpawnRate);
            ninjaKnowsTargetLocation = CustomOption.Create(382, Types.Impostor, "Ninja Knows Location Of Target", true, ninjaSpawnRate);
            ninjaTraceTime = CustomOption.Create(383, Types.Impostor, "Trace Duration", 5f, 1f, 20f, 0.5f, ninjaSpawnRate);
            ninjaTraceColorTime = CustomOption.Create(384, Types.Impostor, "Time Till Trace Color Has Faded", 2f, 0f, 20f, 0.5f, ninjaSpawnRate);
            ninjaInvisibleDuration = CustomOption.Create(385, Types.Impostor, "Time The Ninja Is Invisible", 3f, 0f, 20f, 1f, ninjaSpawnRate);

            blackmailerSpawnRate = CustomOption.Create(710, Types.Impostor, cs(Blackmailer.color, "Blackmailer"), rates, null, true);
            blackmailerCooldown = CustomOption.Create(711, Types.Impostor, "Blackmail Cooldown", 30f, 5f, 120f, 5f, blackmailerSpawnRate);

            doorHackerSpawnRate = CustomOption.Create(910000200, Types.Impostor, cs(DoorHacker.color, "DoorHacker"), rates, null, true);
            doorHackerNumberOfUses = CustomOption.Create(910000203, Types.Impostor, "Number Of Uses", 0f, 0f, 15, 1f, doorHackerSpawnRate);
            doorHackerCooldown = CustomOption.Create(910000201, Types.Impostor, "DoorHacker Cooldown", 30f, 0f, 60f, 2.5f, doorHackerSpawnRate);
            doorHackerDuration = CustomOption.Create(910000202, Types.Impostor, "DoorHacker Duration", 5f, 1f, 30f, 0.5f, doorHackerSpawnRate);

            jesterSpawnRate = CustomOption.Create(60, Types.Neutral, cs(Jester.color, "Jester"), rates, null, true);
            jesterCanCallEmergency = CustomOption.Create(61, Types.Neutral, "Jester Can Call Emergency Meeting", true, jesterSpawnRate);
            jesterCanVent = CustomOption.Create(1901, Types.Neutral, "Jester Can Hide In Vent", true, jesterSpawnRate);
            jesterHasImpostorVision = CustomOption.Create(62, Types.Neutral, "Jester Has Impostor Vision", false, jesterSpawnRate);
			
            prosecutorSpawnRate = CustomOption.Create(615, Types.Neutral, cs(Prosecutor.color, "Executioner"),   rates, null, true);

            amnisiacSpawnRate = CustomOption.Create(616, Types.Neutral, cs(Amnisiac.color, "Amnesiac"), rates, null, true);
            amnisiacShowArrows = CustomOption.Create(617, Types.Neutral, "Show Arrows To Dead Bodies", true, amnisiacSpawnRate);
            amnisiacResetRole = CustomOption.Create(618, Types.Neutral, "Reset Role When Taken", true, amnisiacSpawnRate);


            arsonistSpawnRate = CustomOption.Create(290, Types.Neutral, cs(Arsonist.color, "Arsonist"), rates, null, true);
            arsonistCooldown = CustomOption.Create(291, Types.Neutral, "Arsonist Cooldown", 12.5f, 2.5f, 60f, 2.5f, arsonistSpawnRate);
            arsonistDuration = CustomOption.Create(292, Types.Neutral, "Arsonist Douse Duration", 3f, 1f, 10f, 1f, arsonistSpawnRate);

            jackalSpawnRate = CustomOption.Create(220, Types.Neutral, cs(Jackal.color, "Jackal"), rates, null, true);
            jackalKillCooldown = CustomOption.Create(221, Types.Neutral, "Jackal/Sidekick Kill Cooldown", 30f, 10f, 60f, 2.5f, jackalSpawnRate);
            jackalCreateSidekickCooldown = CustomOption.Create(222, Types.Neutral, "Jackal Create Sidekick Cooldown", 30f, 10f, 60f, 2.5f, jackalSpawnRate);
            jackalhasChat = CustomOption.Create(1197, Types.Neutral, "Jackal Team Has Chat", false, jackalSpawnRate);
            jackalCanUseVents = CustomOption.Create(223, Types.Neutral, "Jackal Can Use Vents", true, jackalSpawnRate);
            jackalCanUseSabo = CustomOption.Create(8876, Types.Neutral, "Jackal Team Can Sabotage", false, jackalSpawnRate);
            jackalCanCreateSidekick = CustomOption.Create(224, Types.Neutral, "Jackal Can Create A Sidekick", false, jackalSpawnRate);
            sidekickPromotesToJackal = CustomOption.Create(225, Types.Neutral, "Sidekick Gets Promoted To Jackal On Jackal Death", false, jackalCanCreateSidekick);
            sidekickCanKill = CustomOption.Create(226, Types.Neutral, "Sidekick Can Kill", false, jackalCanCreateSidekick);
            sidekickCanUseVents = CustomOption.Create(227, Types.Neutral, "Sidekick Can Use Vents", true, jackalCanCreateSidekick);
            jackalPromotedFromSidekickCanCreateSidekick = CustomOption.Create(228, Types.Neutral, "Jackals Promoted From Sidekick Can Create A Sidekick", true, sidekickPromotesToJackal);
            jackalCanCreateSidekickFromImpostor = CustomOption.Create(229, Types.Neutral, "Jackals Can Make An Impostor To His Sidekick", true, jackalCanCreateSidekick);
			jackalKillFakeImpostor = CustomOption.Create(7885, Types.Neutral, "Jackal Kills A Failed Sidekick Attempt", true, jackalCanCreateSidekick);
            jackalAndSidekickHaveImpostorVision = CustomOption.Create(430, Types.Neutral, "Jackal And Sidekick Have Impostor Vision", false, jackalSpawnRate);

            swooperSpawnRate = CustomOption.Create(1110, Types.Neutral, cs(Swooper.color, "Swooper"), rates, null, true); //jackalSpawnRate);
            swooperAsWell = CustomOption.Create(1113, Types.Neutral, "Spawn as Alternate Jackal", false, swooperSpawnRate);
            swooperCooldown = CustomOption.Create(1111, Types.Neutral, "Swoop Cooldown", 30f, 10f, 60f, 2.5f, swooperSpawnRate);
            swooperDuration = CustomOption.Create(1112, Types.Neutral, "Swoop Duration", 10f, 1f, 20f, 0.5f, swooperSpawnRate);
            swooperHasImpVision = CustomOption.Create(1114, Types.Neutral, "Swooper Has Impostor Vision", true, swooperSpawnRate);
			
            minerSpawnRate = CustomOption.Create(1120, Types.Impostor, cs(Miner.color, "Miner"), rates, null, true); //jackalSpawnRate);
            minerCooldown = CustomOption.Create(1121, Types.Impostor, "Mine Cooldown", 25f, 10f, 60f, 2.5f, minerSpawnRate);

            vultureSpawnRate = CustomOption.Create(340, Types.Neutral, cs(Vulture.color, "Vulture"), rates, null, true);
            vultureCooldown = CustomOption.Create(341, Types.Neutral, "Vulture Cooldown", 15f, 10f, 60f, 2.5f, vultureSpawnRate);
            vultureNumberToWin = CustomOption.Create(342, Types.Neutral, "Number Of Corpses Needed To Be Eaten", 4f, 1f, 10f, 1f, vultureSpawnRate);
            vultureCanUseVents = CustomOption.Create(343, Types.Neutral, "Vulture Can Use Vents", true, vultureSpawnRate);
            vultureShowArrows = CustomOption.Create(344, Types.Neutral, "Show Arrows Pointing Towards The Corpses", true, vultureSpawnRate);

            lawyerSpawnRate = CustomOption.Create(350, Types.Neutral, cs(Lawyer.color, "Lawyer"), rates, null, true);
            lawyerTargetKnows = CustomOption.Create(3511, Types.Neutral, "Lawyer Target Knows", true, lawyerSpawnRate);
            lawyerVision = CustomOption.Create(354, Types.Neutral, "Vision", 1f, 0.25f, 3f, 0.25f, lawyerSpawnRate);
            lawyerKnowsRole = CustomOption.Create(355, Types.Neutral, "Lawyer Knows Target Role", false, lawyerSpawnRate);
            lawyerCanCallEmergency = CustomOption.Create(352, Types.Neutral, "Lawyer Can Call Emergency Meeting", true, lawyerSpawnRate);
            lawyerTargetCanBeJester = CustomOption.Create(351, Types.Neutral, "Lawyer Target Can Be The Jester", false, lawyerSpawnRate);
            pursuerCooldown = CustomOption.Create(356, Types.Neutral, "Pursuer Blank Cooldown", 30f, 5f, 60f, 2.5f, lawyerSpawnRate);
            pursuerBlanksNumber = CustomOption.Create(357, Types.Neutral, "Pursuer Number Of Blanks", 5f, 1f, 20f, 1f, lawyerSpawnRate);
            
            werewolfSpawnRate = CustomOption.Create(1501, Types.Neutral, cs(Werewolf.color, "Werewolf"), rates, null, true);
            werewolfRampageCooldown  = CustomOption.Create(1502, Types.Neutral, "Rampage Cooldown", 30f, 10f, 60f, 2.5f, werewolfSpawnRate);
            werewolfRampageDuration = CustomOption.Create(1503, Types.Neutral, "Rampage Duration", 15f, 1f, 20f, 0.5f, werewolfSpawnRate);
            werewolfKillCooldown = CustomOption.Create(1504, Types.Neutral, "Kill Cooldown", 3f, 1f, 60f, 1f, werewolfSpawnRate);

            guesserSpawnRate = CustomOption.Create(310, Types.Crewmate, cs(Guesser.color, "Vigilante"), rates, null, true);
            guesserNumberOfShots = CustomOption.Create(311, Types.Crewmate, "Vigilante Number Of Shots", 5f, 1f, 15f, 1f, guesserSpawnRate);
            guesserHasMultipleShotsPerMeeting = CustomOption.Create(312, Types.Crewmate, "Vigilante Can Shoot Multiple Times Per Meeting", true, guesserSpawnRate);
            guesserShowInfoInGhostChat = CustomOption.Create(313, Types.Crewmate, "Guesses Visible In Ghost Chat", true, guesserSpawnRate);
            guesserKillsThroughShield = CustomOption.Create(314, Types.Crewmate, "Guesses Ignore The Medic Shield", false, guesserSpawnRate);

            mayorSpawnRate = CustomOption.Create(80, Types.Crewmate, cs(Mayor.color, "Mayor"), rates, null, true);
            mayorCanSeeVoteColors = CustomOption.Create(81, Types.Crewmate, "Mayor Can See Vote Colors", false, mayorSpawnRate);
            mayorTasksNeededToSeeVoteColors = CustomOption.Create(82, Types.Crewmate, "Completed Tasks Needed To See Vote Colors", 5f, 0f, 20f, 1f, mayorCanSeeVoteColors);
            mayorMeetingButton = CustomOption.Create(83, Types.Crewmate, "Mobile Emergency Button", true, mayorSpawnRate);
            mayorMaxRemoteMeetings = CustomOption.Create(84, Types.Crewmate, "Number Of Remote Meetings", 1f, 1f, 5f, 1f, mayorMeetingButton);

            engineerSpawnRate = CustomOption.Create(90, Types.Crewmate, cs(Engineer.color, "Engineer"), rates, null, true);
            engineerRemoteFix = CustomOption.Create(911221, Types.Crewmate, "Enable Remote Fix", true, engineerSpawnRate);
            engineerResetFixAfterMeeting = CustomOption.Create(9111, Types.Crewmate, "Reset Fixes After Meeting", false, engineerRemoteFix);
            engineerNumberOfFixes = CustomOption.Create(91, Types.Crewmate, "Number Of Sabotage Fixes", 1f, 1f, 3f, 1f, engineerRemoteFix);
            engineerExpertRepairs = CustomOption.Create(91121, Types.Crewmate, "Advanced Sabotage Repair", false, engineerSpawnRate);
            engineerHighlightForImpostors = CustomOption.Create(92, Types.Crewmate, "Impostors See Vents Highlighted", true, engineerSpawnRate);
            engineerHighlightForTeamJackal = CustomOption.Create(93, Types.Crewmate, "Jackal and Sidekick See Vents Highlighted ", true, engineerSpawnRate);

            sheriffSpawnRate = CustomOption.Create(100, Types.Crewmate, cs(Sheriff.color, "Sheriff"), rates, null, true);
            sheriffCooldown = CustomOption.Create(101, Types.Crewmate, "Sheriff Cooldown", 30f, 10f, 60f, 2.5f, sheriffSpawnRate);
            sheriffMisfireKills = CustomOption.Create(2101, Types.Crewmate, "Misfire Kills", new string[] { "Self", "Target", "Both" }, sheriffSpawnRate);
            sheriffCanKillNeutrals = CustomOption.Create(102, Types.Crewmate, "Sheriff Can Kill Neutrals", false, sheriffSpawnRate);
            sheriffCanKillJester = CustomOption.Create(2104, Types.Crewmate, "Sheriff Can Kill " + cs(Jester.color, "Jester"), false, sheriffCanKillNeutrals);
            sheriffCanKillProsecutor = CustomOption.Create(2105, Types.Crewmate, "Sheriff Can Kill " + cs(Prosecutor.color, "Executioner"), false, sheriffCanKillNeutrals);
            sheriffCanKillAmnesiac = CustomOption.Create(210278, Types.Crewmate, "Sheriff Can Kill " + cs(Amnisiac.color, "Amnesiac"), false, sheriffCanKillNeutrals);
            sheriffCanKillArsonist = CustomOption.Create(2102, Types.Crewmate, "Sheriff Can Kill " + cs(Arsonist.color, "Arsonist"), false, sheriffCanKillNeutrals);
            sheriffCanKillVulture = CustomOption.Create(2107, Types.Crewmate, "Sheriff Can Kill " + cs(Vulture.color, "Vulture"), false, sheriffCanKillNeutrals);
            sheriffCanKillLawyer = CustomOption.Create(2103, Types.Crewmate, "Sheriff Can Kill " + cs(Lawyer.color, "Lawyer"), false, sheriffCanKillNeutrals);
            sheriffCanKillThief = CustomOption.Create(210277, Types.Crewmate, "Sheriff Can Kill " + cs(Thief.color, "Thief"), false, sheriffCanKillNeutrals);
            sheriffCanKillPursuer = CustomOption.Create(2106, Types.Crewmate, "Sheriff Can Kill " + cs(Pursuer.color, "Pursuer"), false, sheriffCanKillNeutrals);

            deputySpawnRate = CustomOption.Create(103, Types.Crewmate, "Sheriff Has A Deputy", rates, sheriffSpawnRate);
            deputyNumberOfHandcuffs = CustomOption.Create(104, Types.Crewmate, "Deputy Number Of Handcuffs", 3f, 1f, 10f, 1f, deputySpawnRate);
            deputyHandcuffCooldown = CustomOption.Create(105, Types.Crewmate, "Handcuff Cooldown", 30f, 10f, 60f, 2.5f, deputySpawnRate);
            deputyHandcuffDuration = CustomOption.Create(106, Types.Crewmate, "Handcuff Duration", 15f, 5f, 60f, 2.5f, deputySpawnRate);
            deputyKnowsSheriff = CustomOption.Create(107, Types.Crewmate, "Sheriff And Deputy Know Each Other ", true, deputySpawnRate);
            deputyGetsPromoted = CustomOption.Create(108, Types.Crewmate, "Deputy Gets Promoted To Sheriff", new string[] { "Off", "On (Immediately)", "On (After Meeting)" }, deputySpawnRate);
            deputyKeepsHandcuffs = CustomOption.Create(109, Types.Crewmate, "Deputy Keeps Handcuffs When Promoted", true, deputyGetsPromoted);

            lighterSpawnRate = CustomOption.Create(110, Types.Crewmate, cs(Lighter.color, "Lighter"), rates, null, true);
            lighterModeLightsOnVision = CustomOption.Create(111, Types.Crewmate, "Lighter Mode Vision On Lights On", 2f, 0.25f, 5f, 0.25f, lighterSpawnRate);
            lighterModeLightsOffVision = CustomOption.Create(112, Types.Crewmate, "Lighter Mode Vision On Lights Off", 0.75f, 0.25f, 5f, 0.25f, lighterSpawnRate);
            lighterCooldown = CustomOption.Create(113, Types.Crewmate, "Lighter Cooldown", 30f, 5f, 120f, 5f, lighterSpawnRate);
            lighterDuration = CustomOption.Create(114, Types.Crewmate, "Lighter Duration", 5f, 2.5f, 60f, 2.5f, lighterSpawnRate);

            detectiveSpawnRate = CustomOption.Create(120, Types.Crewmate, cs(Detective.color, "Investigator"), rates, null, true);
            detectiveAnonymousFootprints = CustomOption.Create(121, Types.Crewmate, "Anonymous Footprints", false, detectiveSpawnRate); 
            detectiveFootprintIntervall = CustomOption.Create(122, Types.Crewmate, "Footprint Intervall", 0.5f, 0.25f, 10f, 0.25f, detectiveSpawnRate);
            detectiveFootprintDuration = CustomOption.Create(123, Types.Crewmate, "Footprint Duration", 5f, 0.25f, 10f, 0.25f, detectiveSpawnRate);
            detectiveReportNameDuration = CustomOption.Create(124, Types.Crewmate, "Time Where Investigator Reports Will Have Name", 0, 0, 60, 2.5f, detectiveSpawnRate);
            detectiveReportColorDuration = CustomOption.Create(125, Types.Crewmate, "Time Where Investigator Reports Will Have Color Type", 20, 0, 120, 2.5f, detectiveSpawnRate);

            timeMasterSpawnRate = CustomOption.Create(130, Types.Crewmate, cs(TimeMaster.color, "Time Master"), rates, null, true);
            timeMasterCooldown = CustomOption.Create(131, Types.Crewmate, "Time Master Cooldown", 30f, 10f, 120f, 2.5f, timeMasterSpawnRate);
            timeMasterRewindTime = CustomOption.Create(132, Types.Crewmate, "Rewind Time", 3f, 1f, 10f, 1f, timeMasterSpawnRate);
            timeMasterShieldDuration = CustomOption.Create(133, Types.Crewmate, "Time Master Shield Duration", 3f, 1f, 20f, 1f, timeMasterSpawnRate);

            veterenSpawnRate = CustomOption.Create(4450, Types.Crewmate, cs(Veteren.color, "Veteran"), rates, null, true);
            veterenCooldown = CustomOption.Create(4451, Types.Crewmate, "Alert Cooldown", 30f, 10f, 120f, 2.5f, veterenSpawnRate);
	        veterenAlertDuration = CustomOption.Create(4452, Types.Crewmate, "Alert Duration", 3f, 1f, 20f, 1f, veterenSpawnRate);

            medicSpawnRate = CustomOption.Create(140, Types.Crewmate, cs(Medic.color, "Medic"), rates, null, true);
            medicShowShielded = CustomOption.Create(143, Types.Crewmate, "Show Shielded Player", new string[] {"Everyone", "Shielded + Medic", "Medic"}, medicSpawnRate);
            medicBreakShield = CustomOption.Create(1146, Types.Crewmate, "Shield Is Unbreakable", true, medicSpawnRate);
            medicShowAttemptToShielded = CustomOption.Create(144, Types.Crewmate, "Shielded Player Sees Murder Attempt", false, medicBreakShield);
            medicSetOrShowShieldAfterMeeting = CustomOption.Create(145, Types.Crewmate, "Shield Will Be Activated", new string[] { "Instantly", "Instantly, Visible\nAfter Meeting", "After Meeting" }, medicSpawnRate);
            medicShowAttemptToMedic = CustomOption.Create(146, Types.Crewmate, "Medic Sees Murder Attempt On Shielded Player", false, medicBreakShield);

            swapperSpawnRate = CustomOption.Create(150, Types.Crewmate, cs(Swapper.color, "Swapper"), rates, null, true);
            swapperCanCallEmergency = CustomOption.Create(151, Types.Crewmate, "Swapper Can Call Emergency Meeting", false, swapperSpawnRate);
            swapperCanFixSabotages = CustomOption.Create(1512, Types.Crewmate, "Swapper Can Fix Sabotages", false, swapperSpawnRate);
            swapperCanOnlySwapOthers = CustomOption.Create(152, Types.Crewmate, "Swapper Can Only Swap Others", false, swapperSpawnRate);
            swapperSwapsNumber = CustomOption.Create(153, Types.Crewmate, "Initial Swap Charges", 1f, 0f, 5f, 1f, swapperSpawnRate);
            swapperRechargeTasksNumber = CustomOption.Create(154, Types.Crewmate, "Number Of Tasks Needed For Recharging", 2f, 1f, 10f, 1f, swapperSpawnRate);

            seerSpawnRate = CustomOption.Create(160, Types.Crewmate, cs(Seer.color, "Seer"), rates, null, true);
            seerMode = CustomOption.Create(161, Types.Crewmate, "Seer Mode", new string[]{ "Show Death Flash + Souls", "Show Death Flash", "Show Souls"}, seerSpawnRate);
            seerLimitSoulDuration = CustomOption.Create(163, Types.Crewmate, "Seer Limit Soul Duration", false, seerSpawnRate);
            seerSoulDuration = CustomOption.Create(162, Types.Crewmate, "Seer Soul Duration", 15f, 0f, 120f, 5f, seerLimitSoulDuration);
        
            hackerSpawnRate = CustomOption.Create(170, Types.Crewmate, cs(Hacker.color, "Hacker"), rates, null, true);
            hackerCooldown = CustomOption.Create(171, Types.Crewmate, "Hacker Cooldown", 30f, 5f, 60f, 5f, hackerSpawnRate);
            hackerHackeringDuration = CustomOption.Create(172, Types.Crewmate, "Hacker Duration", 10f, 2.5f, 60f, 2.5f, hackerSpawnRate);
            hackerOnlyColorType = CustomOption.Create(173, Types.Crewmate, "Hacker Only Sees Color Type", false, hackerSpawnRate);
            hackerToolsNumber = CustomOption.Create(174, Types.Crewmate, "Max Mobile Gadget Charges", 5f, 1f, 30f, 1f, hackerSpawnRate);
            hackerRechargeTasksNumber = CustomOption.Create(175, Types.Crewmate, "Number Of Tasks Needed For Recharging", 2f, 1f, 5f, 1f, hackerSpawnRate);
            hackerNoMove = CustomOption.Create(176, Types.Crewmate, "Cant Move During Mobile Gadget Duration", true, hackerSpawnRate);

            trackerSpawnRate = CustomOption.Create(200, Types.Crewmate, cs(Tracker.color, "Tracker"), rates, null, true);
            trackerUpdateIntervall = CustomOption.Create(201, Types.Crewmate, "Tracker Update Intervall", 5f, 1f, 30f, 1f, trackerSpawnRate);
            trackerResetTargetAfterMeeting = CustomOption.Create(202, Types.Crewmate, "Tracker Reset Target After Meeting", false, trackerSpawnRate);
            trackerCanTrackCorpses = CustomOption.Create(203, Types.Crewmate, "Tracker Can Track Corpses", true, trackerSpawnRate);
            trackerCorpsesTrackingCooldown = CustomOption.Create(204, Types.Crewmate, "Corpses Tracking Cooldown", 30f, 5f, 120f, 5f, trackerCanTrackCorpses);
            trackerCorpsesTrackingDuration = CustomOption.Create(205, Types.Crewmate, "Corpses Tracking Duration", 5f, 2.5f, 30f, 2.5f, trackerCanTrackCorpses);
                           
            snitchSpawnRate = CustomOption.Create(210, Types.Crewmate, cs(Snitch.color, "Snitch"), rates, null, true);
            snitchLeftTasksForReveal = CustomOption.Create(211, Types.Crewmate, "Task Count Where The Snitch Will Be Revealed", 1f, 0f, 5f, 1f, snitchSpawnRate);
     //       snitchCanSeeRoles = CustomOption.Create(2112234, Types.Crewmate, "Can See Roles", false, snitchSpawnRate);
            snitchIncludeTeamJackal = CustomOption.Create(212, Types.Crewmate, "Include Team Jackal", false, snitchSpawnRate);
            snitchTeamJackalUseDifferentArrowColor = CustomOption.Create(213, Types.Crewmate, "Use Different Arrow Color For Team Jackal", true, snitchIncludeTeamJackal);

            madmateSpawnRate = CustomOption.Create(4001, Types.Crewmate, cs(Madmate.color, "Madmate"), rates, null, true);
            madmateCanVent = CustomOption.Create(4002, Types.Crewmate, "Madmate Can Enter Vent", true, madmateSpawnRate);
            madmateCanFixLightAndComms = CustomOption.Create(4003, Types.Crewmate, "Madmate Can Fix Light And Comms", false, madmateSpawnRate);
            madmateHasImpostorVision = CustomOption.Create(4004, Types.Crewmate, "Madmate Has Impostor Vision", true, madmateSpawnRate);

            spySpawnRate = CustomOption.Create(240, Types.Crewmate, cs(Spy.color, "Spy"), rates, null, true);
            spyCanDieToSheriff = CustomOption.Create(241, Types.Crewmate, "Spy Can Die To Sheriff", false, spySpawnRate);
            spyImpostorsCanKillAnyone = CustomOption.Create(242, Types.Crewmate, "Impostors Can Kill Anyone If There Is A Spy", true, spySpawnRate);
            spyCanEnterVents = CustomOption.Create(243, Types.Crewmate, "Spy Can Enter Vents", false, spySpawnRate);
            spyHasImpostorVision = CustomOption.Create(244, Types.Crewmate, "Spy Has Impostor Vision", false, spySpawnRate);

            portalmakerSpawnRate = CustomOption.Create(390, Types.Crewmate, cs(Portalmaker.color, "Portalmaker"), rates, null, true);
            portalmakerCooldown = CustomOption.Create(391, Types.Crewmate, "Portalmaker Cooldown", 30f, 10f, 60f, 2.5f, portalmakerSpawnRate);
            portalmakerUsePortalCooldown = CustomOption.Create(392, Types.Crewmate, "Use Portal Cooldown", 30f, 10f, 60f, 2.5f, portalmakerSpawnRate);
            portalmakerLogOnlyColorType = CustomOption.Create(393, Types.Crewmate, "Portalmaker Log Only Shows Color Type", true, portalmakerSpawnRate);
            portalmakerLogHasTime = CustomOption.Create(394, Types.Crewmate, "Log Shows Time", true, portalmakerSpawnRate);
            securityGuardSpawnRate = CustomOption.Create(280, Types.Crewmate, cs(SecurityGuard.color, "Security Guard"), rates, null, true);
            securityGuardCooldown = CustomOption.Create(281, Types.Crewmate, "Security Guard Cooldown", 30f, 10f, 60f, 2.5f, securityGuardSpawnRate);
            securityGuardTotalScrews = CustomOption.Create(282, Types.Crewmate, "Security Guard Number Of Screws", 7f, 1f, 15f, 1f, securityGuardSpawnRate);
            securityGuardCamPrice = CustomOption.Create(283, Types.Crewmate, "Number Of Screws Per Cam", 2f, 1f, 15f, 1f, securityGuardSpawnRate);
            securityGuardVentPrice = CustomOption.Create(284, Types.Crewmate, "Number Of Screws Per Vent", 1f, 1f, 15f, 1f, securityGuardSpawnRate);
            securityGuardCamDuration = CustomOption.Create(285, Types.Crewmate, "Security Guard Duration", 10f, 2.5f, 60f, 2.5f, securityGuardSpawnRate);
            securityGuardCamMaxCharges = CustomOption.Create(286, Types.Crewmate, "Gadged Max Charges", 5f, 1f, 30f, 1f, securityGuardSpawnRate);
            securityGuardCamRechargeTasksNumber = CustomOption.Create(287, Types.Crewmate, "Number Of Tasks Needed For Recharging", 3f, 1f, 10f, 1f, securityGuardSpawnRate);
            securityGuardNoMove = CustomOption.Create(288, Types.Crewmate, "Cant Move During Cam Duration", true, securityGuardSpawnRate);

            mediumSpawnRate = CustomOption.Create(360, Types.Crewmate, cs(Medium.color, "Medium"), rates, null, true);
            mediumCooldown = CustomOption.Create(361, Types.Crewmate, "Medium Questioning Cooldown", 30f, 5f, 120f, 5f, mediumSpawnRate);
            mediumDuration = CustomOption.Create(362, Types.Crewmate, "Medium Questioning Duration", 3f, 0f, 15f, 1f, mediumSpawnRate);
            mediumOneTimeUse = CustomOption.Create(363, Types.Crewmate, "Each Soul Can Only Be Questioned Once", false, mediumSpawnRate);

            jumperSpawnRate = CustomOption.Create(9050, Types.Crewmate, cs(Jumper.color, "Jumper"), rates, null, true);
            jumperJumpTime = CustomOption.Create(9051, Types.Crewmate, "Jump Cooldown", 30, 0, 60, 5, jumperSpawnRate);
            jumperChargesOnPlace = CustomOption.Create(9052, Types.Crewmate, "Charges On Place", 1, 0, 10, 1, jumperSpawnRate);
     //       jumperResetPlaceAfterMeeting = CustomOption.Create(9052, Types.Crewmate, "Reset Places After Meeting", true, jumperSpawnRate);
     //       jumperChargesGainOnMeeting = CustomOption.Create(9053, Types.Crewmate, "Charges Gained After Meeting", 2, 0, 10, 1, jumperSpawnRate);
            jumperMaxCharges = CustomOption.Create(9054, Types.Crewmate, "Maximum Charges", 3, 0, 10, 1, jumperSpawnRate);
            
            bodyGuardSpawnRate = CustomOption.Create(8820, Types.Crewmate, cs(BodyGuard.color, "Bodyguard"), rates, null, true);
            bodyGuardResetTargetAfterMeeting = CustomOption.Create(8821, Types.Crewmate, "Reset Target After Meeting", true, bodyGuardSpawnRate);
            bodyGuardFlash = CustomOption.Create(8822, Types.Crewmate, "Show Flash On Death", true, bodyGuardSpawnRate);



            thiefSpawnRate = CustomOption.Create(400, Types.Neutral, cs(Thief.color, "Thief"), rates, null, true);
            thiefCooldown = CustomOption.Create(401, Types.Neutral, "Thief Cooldown", 30f, 5f, 120f, 5f, thiefSpawnRate);
            thiefCanKillSheriff = CustomOption.Create(402, Types.Neutral, "Thief Can Kill Sheriff", true, thiefSpawnRate);
            thiefHasImpVision = CustomOption.Create(403, Types.Neutral, "Thief Has Impostor Vision", true, thiefSpawnRate);
            thiefCanUseVents = CustomOption.Create(404, Types.Neutral, "Thief Can Use Vents", true, thiefSpawnRate);

            modifierPhantomAbility = CustomOption.Create(2000353, Types.Neutral, cs(PhantomRole.color, "Phantom"), rates, null, true);

            trapperSpawnRate = CustomOption.Create(410, Types.Crewmate, cs(Trapper.color, "Trapper"), rates, null, true);
            trapperCooldown = CustomOption.Create(420, Types.Crewmate, "Trapper Cooldown", 30f, 5f, 120f, 5f, trapperSpawnRate);
            trapperMaxCharges = CustomOption.Create(440, Types.Crewmate, "Max Traps Charges", 5f, 1f, 15f, 1f, trapperSpawnRate);
            trapperRechargeTasksNumber = CustomOption.Create(450, Types.Crewmate, "Number Of Tasks Needed For Recharging", 2f, 1f, 15f, 1f, trapperSpawnRate);
            trapperTrapNeededTriggerToReveal = CustomOption.Create(451, Types.Crewmate, "Trap Needed Trigger To Reveal", 3f, 2f, 10f, 1f, trapperSpawnRate);
            trapperAnonymousMap = CustomOption.Create(452, Types.Crewmate, "Show Anonymous Map", false, trapperSpawnRate);
            trapperInfoType = CustomOption.Create(453, Types.Crewmate, "Trap Information Type", new string[] { "Role", "Good/Evil Role", "Name" }, trapperSpawnRate);
            trapperTrapDuration = CustomOption.Create(454, Types.Crewmate, "Trap Duration", 5f, 1f, 15f, 1f, trapperSpawnRate);

            // Modifier (1000 - 1999)
            modifiersAreHidden = CustomOption.Create(1009, Types.Modifier, cs(Color.yellow, "Hide After Death Modifiers"), true, null, true);



            modifierDisperser = CustomOption.Create(200220, Types.Modifier, cs(Color.red, "Disperser"), rates, null, true);

            modifierBloody = CustomOption.Create(1000, Types.Modifier, cs(Color.yellow, "Bloody"), rates, null, true);
            modifierBloodyQuantity = CustomOption.Create(1001, Types.Modifier, cs(Color.yellow, "Bloody Quantity"), ratesModifier, modifierBloody);
            modifierBloodyDuration = CustomOption.Create(1002, Types.Modifier, "Trail Duration", 10f, 3f, 60f, 1f, modifierBloody);

            modifierAntiTeleport = CustomOption.Create(1010, Types.Modifier, cs(Color.yellow, "Anti Teleport"), rates, null, true);
            modifierAntiTeleportQuantity = CustomOption.Create(1011, Types.Modifier, cs(Color.yellow, "Anti Teleport Quantity"), ratesModifier, modifierAntiTeleport);

            modifierTieBreaker = CustomOption.Create(1020, Types.Modifier, cs(Color.yellow, "Tie Breaker"), rates, null, true);

            modifierBait = CustomOption.Create(1030, Types.Modifier, cs(Color.yellow, "Bait"), rates, null, true);
            modifierBaitQuantity = CustomOption.Create(1031, Types.Modifier, cs(Color.yellow, "Bait Quantity"), ratesModifier, modifierBait);
            modifierBaitReportDelayMin = CustomOption.Create(1032, Types.Modifier, "Bait Report Delay Min", 0f, 0f, 10f, 1f, modifierBait);
            modifierBaitReportDelayMax = CustomOption.Create(1033, Types.Modifier, "Bait Report Delay Max", 0f, 0f, 10f, 1f, modifierBait);
            modifierBaitShowKillFlash = CustomOption.Create(1034, Types.Modifier, "Warn The Killer With A Flash", true, modifierBait);

            modifierLover = CustomOption.Create(1040, Types.Modifier, cs(Color.yellow, "Lovers"), rates, null, true);
            modifierLoverImpLoverRate = CustomOption.Create(1041, Types.Modifier, "Chance That One Lover Is Impostor", rates, modifierLover);
            modifierLoverBothDie = CustomOption.Create(1042, Types.Modifier, "Both Lovers Die", true, modifierLover);
            modifierLoverEnableChat = CustomOption.Create(1043, Types.Modifier, "Enable Lover Chat", true, modifierLover);

            modifierSunglasses = CustomOption.Create(1050, Types.Modifier, cs(Color.yellow, "Sunglasses"), rates, null, true);
            modifierSunglassesQuantity = CustomOption.Create(1051, Types.Modifier, cs(Color.yellow, "Sunglasses Quantity"), ratesModifier, modifierSunglasses);
            modifierSunglassesVision = CustomOption.Create(1052, Types.Modifier, "Vision With Sunglasses", new string[] { "-10%", "-20%", "-30%", "-40%", "-50%" }, modifierSunglasses);

            modifierTorch = CustomOption.Create(1053, Types.Modifier, cs(Color.yellow, "Torch"), rates, null, true);
            modifierTorchQuantity = CustomOption.Create(1054, Types.Modifier, cs(Color.yellow, "Torch Quantity"), ratesModifier, modifierTorch);

            modifierMultitasker = CustomOption.Create(10523233, Types.Modifier, cs(Color.yellow, "Multitasker"), rates, null, true);
            modifierMultitaskerQuantity = CustomOption.Create(10232354, Types.Modifier, cs(Color.yellow, "Multitasker Quantity"), ratesModifier, modifierMultitasker);

            modifierMini = CustomOption.Create(1061, Types.Modifier, cs(Color.yellow, "Mini"), rates, null, true);
            modifierMiniGrowingUpDuration = CustomOption.Create(1062, Types.Modifier, "Mini Growing Up Duration", 400f, 100f, 1500f, 100f, modifierMini);
            modifierMiniGrowingUpInMeeting = CustomOption.Create(1063, Types.Modifier, "Mini Grows Up In Meeting", true, modifierMini);
            
            modifierIndomitable = CustomOption.Create(1276, Types.Modifier, cs(Color.yellow, "Indomitable"), rates, null, true);
        //    modifierLifeGuard = CustomOption.Create(1277, Types.Modifier, cs(Color.yellow, "Life Guard"), rates, null, true);

            modifierBlind = CustomOption.Create(8810, Types.Modifier, cs(Color.yellow, "Blind"), rates, null, true);
            modifierWatcher = CustomOption.Create(10401, Types.Modifier, cs(Color.yellow, "Watcher"), rates, null, true);
            modifierRadar = CustomOption.Create(1040122, Types.Modifier, cs(Color.yellow, "Radar"), rates, null, true);
            modifierTunneler = CustomOption.Create(8819, Types.Modifier, cs(Color.yellow, "Tunneler"), rates, null, true);
            modifierSlueth = CustomOption.Create(8830, Types.Modifier, cs(Color.yellow, "Sleuth"), rates, null, true);
            modifierCursed = CustomOption.Create(1277, Types.Modifier, cs(Color.yellow, "Fanatic"), rates, null, true);

            modifierVip = CustomOption.Create(1070, Types.Modifier, cs(Color.yellow, "VIP"), rates, null, true);
            modifierVipQuantity = CustomOption.Create(1071, Types.Modifier, cs(Color.yellow, "VIP Quantity"), ratesModifier, modifierVip);
            modifierVipShowColor = CustomOption.Create(1072, Types.Modifier, "Show Team Color", true, modifierVip);

            modifierInvert = CustomOption.Create(1080, Types.Modifier, cs(Color.yellow, "Invert"), rates, null, true);
            modifierInvertQuantity = CustomOption.Create(1081, Types.Modifier, cs(Color.yellow, "Modifier Quantity"), ratesModifier, modifierInvert);
            modifierInvertDuration = CustomOption.Create(1082, Types.Modifier, "Number Of Meetings Inverted", 3f, 1f, 15f, 1f, modifierInvert);

            modifierChameleon = CustomOption.Create(1090, Types.Modifier, cs(Color.yellow, "Chameleon"), rates, null, true);
            modifierChameleonQuantity = CustomOption.Create(1091, Types.Modifier, cs(Color.yellow, "Chameleon Quantity"), ratesModifier, modifierChameleon);
            modifierChameleonHoldDuration = CustomOption.Create(1092, Types.Modifier, "Time Until Fading Starts", 3f, 1f, 10f, 0.5f, modifierChameleon);
            modifierChameleonFadeDuration = CustomOption.Create(1093, Types.Modifier, "Fade Duration", 1f, 0.25f, 10f, 0.25f, modifierChameleon);
            modifierChameleonMinVisibility = CustomOption.Create(1094, Types.Modifier, "Minimum Visibility", new string[] { "0%", "10%", "20%", "30%", "40%", "50%" }, modifierChameleon);

            // Other options
            maxNumberOfMeetings = CustomOption.Create(3, Types.General, "Number Of Meetings (excluding Mayor meeting)", 10, 0, 15, 1, null, true);
            blockSkippingInEmergencyMeetings = CustomOption.Create(4, Types.General, "Block Skipping In Emergency Meetings", false);
            noVoteIsSelfVote = CustomOption.Create(5, Types.General, "No Vote Is Self Vote", false, blockSkippingInEmergencyMeetings);
            hidePlayerNames = CustomOption.Create(6, Types.General, "Hide Player Names", false);
            allowParallelMedBayScans = CustomOption.Create(7, Types.General, "Allow Parallel MedBay Scans", false);
            shieldFirstKill = CustomOption.Create(8, Types.General, "Shield Last Game First Kill", false);
            nightVisionLightSabotage = CustomOption.Create(89769, Types.General, "Camera Night Vision For Lights Sabotage", false);
            hideVentAnimOnShadows = CustomOption.Create(822445, Types.General, "Hide Vent Animation From Other Players", false);
      //      screenShakeReactorSabotage = CustomOption.Create(82414, Types.General, "Screen Shake For Reactor Sabotage", false);
            impostorSeeRoles = CustomOption.Create(9, Types.General, "Impostors Can See The Roles Of Their Team", false);
            impostorCanKillCustomRolesInTheVent = CustomOption.Create(920000003, Types.General, "Impostors Can Kill Players In Vents", false);
            transparentTasks = CustomOption.Create(814142, Types.General, "Tasks Are Transparent", false);

            dynamicMap = CustomOption.Create(500, Types.General, "Play On A Random Map", false, null, false);
            dynamicMapEnableSkeld = CustomOption.Create(501, Types.General, "Skeld", rates, dynamicMap, false);
            dynamicMapEnableMira = CustomOption.Create(502, Types.General, "Mira", rates, dynamicMap, false);
            dynamicMapEnablePolus = CustomOption.Create(503, Types.General, "Polus", rates, dynamicMap, false);
            dynamicMapEnableAirShip = CustomOption.Create(504, Types.General, "Airship", rates, dynamicMap, false);
            
            enableBetterPolus = CustomOption.Create(7878, Types.General, "Enable Better Polus", false, null, false);
            movePolusVents = CustomOption.Create(7879, Types.General, "Adjust Vents", false, enableBetterPolus, false);
            movePolusVitals = CustomOption.Create(7880, Types.General, "Move Vitals To Labs", false, enableBetterPolus, false);
			swapNavWifi = CustomOption.Create(7881, Types.General, "Swap Reboot And Chart Course", false, enableBetterPolus, false);
			moveColdTemp = CustomOption.Create(7882, Types.General, "Move Cold Temp To Death Valley", false, enableBetterPolus, false);



	        enableCamoComms = CustomOption.Create(1105, Types.General, "Enable Camouflage Comms", false,  null, false);

            restrictDevices = CustomOption.Create(1101, Types.General, "Restrict Map Information", new string[] {"Off", "Per Round", "Per Game"},  null, false);
            restrictAdmin = CustomOption.Create(1102, Types.General, "Restrict Admin Table", 30f, 0f, 600f, 5f, restrictDevices);
            restrictCameras = CustomOption.Create(1103, Types.General, "Restrict Cameras", 30f, 0f, 600f, 5f, restrictDevices);
            restrictVents = CustomOption.Create(1104, Types.General, "Restrict Vitals", 30f, 0f, 600f, 5f, restrictDevices);


            showButtonTarget = CustomOption.Create(9994, Types.General, "Show Button Target", true);
            blockGameEnd = CustomOption.Create(9995, Types.General, "Block Game End If Power Crew Is Alive", false);


            randomGameStartPosition = CustomOption.Create(9041, Types.General, "Random Spawn Location", false);
            allowModGuess = CustomOption.Create(9043, Types.General, "Allow Guessing Some Modifiers", false);
            resetRoundStartCooldown = CustomOption.Create(9042, Types.General, "Reset Spawn Cooldown", false);



            debugMode = CustomOption.Create(9996, Types.General, "Debug Mode", false);

            blockedRolePairings.Add((byte)RoleId.Spy, new [] { (byte)RoleId.Mini});
            blockedRolePairings.Add((byte)RoleId.Mini, new [] { (byte)RoleId.Spy});
            blockedRolePairings.Add((byte)RoleId.Vulture, new [] { (byte)RoleId.Cleaner});
            blockedRolePairings.Add((byte)RoleId.Cleaner, new [] { (byte)RoleId.Vulture});
      //      blockedRolePairings.Add((byte)RoleId.Swapper, new [] { (byte)RoleId.LifeGuard});
      //      blockedRolePairings.Add((byte)RoleId.LifeGuard, new [] { (byte)RoleId.Swapper});
            blockedRolePairings.Add((byte)RoleId.Engineer, new [] { (byte)RoleId.Tunneler});
            blockedRolePairings.Add((byte)RoleId.Tunneler, new [] { (byte)RoleId.Engineer});
            blockedRolePairings.Add((byte)RoleId.Bomber, new [] { (byte)RoleId.Bait});
            blockedRolePairings.Add((byte)RoleId.Bait, new [] { (byte)RoleId.Bomber});
            blockedRolePairings.Add((byte)RoleId.Mayor, new [] { (byte)RoleId.Watcher});
            blockedRolePairings.Add((byte)RoleId.Watcher, new [] { (byte)RoleId.Mayor});
    //        blockedRolePairings.Add((byte)RoleId.Ninja, new [] { (byte)RoleId.Chameleon});
    //        blockedRolePairings.Add((byte)RoleId.Chameleon, new [] { (byte)RoleId.Ninja});
   //         blockedRolePairings.Add((byte)RoleId.EvilGuesser, new [] { (byte)RoleId.Lover});
   //         blockedRolePairings.Add((byte)RoleId.Lover, new [] { (byte)RoleId.EvilGuesser});

			// Prosecutor
			blockedRolePairings.Add((byte)RoleId.Lawyer, new[] { (byte)RoleId.Prosecutor });
            blockedRolePairings.Add((byte)RoleId.Prosecutor, new[] { (byte)RoleId.Lawyer });            
        }
    }
}
