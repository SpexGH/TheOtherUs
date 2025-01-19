using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TheOtherRoles.Modules;
using TheOtherRoles.Utilities;
using UnityEngine;
using static TheOtherRoles.TheOtherRoles;

namespace TheOtherRoles;

public class RoleInfo
{
    private static string ReadmePage = "";
    public Color color;
    public string introDescription;
    public bool isGuessable;
    public bool isImpostor;
    public bool isModifier;
    public bool isNeutral;
    public string name;
    public RoleId roleId;
    public string shortDescription;

    public RoleInfo(string name, Color color, RoleId roleId, bool isNeutral = false, bool isModifier = false, bool isGuessable = false, bool isImpostor = false)
    {
        this.color = color;
        this.name = name.Translate();
        this.introDescription = getString(name + "IntroDesc");
        this.shortDescription = getString(name + "ShortDesc");
        this.roleId = roleId;
        this.isNeutral = isNeutral;
        this.isModifier = isModifier;
        this.isGuessable = isGuessable;
        this.isImpostor = isImpostor;
    }

    public static RoleInfo impostor = new("Impostor", Palette.ImpostorRed, RoleId.Impostor);
    public static RoleInfo assassin = new("assassin", Color.red, RoleId.EvilGuesser, false, true);
    public static RoleInfo godfather = new("godfather", Godfather.color, RoleId.Godfather);
    public static RoleInfo mafioso = new("mafioso", Mafioso.color, RoleId.Mafioso);
    public static RoleInfo janitor = new("Janitor", Janitor.color, RoleId.Janitor);
    public static RoleInfo morphling = new("morphling", Morphling.color, RoleId.Morphling);
    public static RoleInfo bomber = new("bomber", Bomber.color, RoleId.Bomber);
    public static RoleInfo mimic = new("mimic", Mimic.color, RoleId.Mimic);
    public static RoleInfo camouflager = new("camouflager", Camouflager.color, RoleId.Camouflager);
    public static RoleInfo miner = new("miner", Miner.color, RoleId.Miner);
    public static RoleInfo eraser = new("eraser", Eraser.color, RoleId.Eraser);
    public static RoleInfo vampire = new("vampire", Vampire.color, RoleId.Vampire);
    public static RoleInfo cleaner = new("cleaner", Cleaner.color, RoleId.Cleaner);
    public static RoleInfo undertaker = new("undertaker", Undertaker.color, RoleId.Undertaker);
    public static RoleInfo escapist = new("escapist", Escapist.color, RoleId.Escapist);
    public static RoleInfo warlock = new("warlock", Warlock.color, RoleId.Warlock);
    public static RoleInfo trickster = new("Trickster", Trickster.color, RoleId.Trickster);
    public static RoleInfo bountyHunter = new("bountyHunter", BountyHunter.color, RoleId.BountyHunter);
    public static RoleInfo cultist = new("cultist", Cultist.color, RoleId.Cultist);
    public static RoleInfo follower = new("Follower", Cleaner.color, RoleId.Follower, true);
    public static RoleInfo terrorist = new("terrorist", Terrorist.color, RoleId.Terrorist);
    public static RoleInfo blackmailer = new("blackmailer", Blackmailer.color, RoleId.Blackmailer);
    public static RoleInfo witch = new("witch", Witch.color, RoleId.Witch);
    public static RoleInfo ninja = new("ninja", Ninja.color, RoleId.Ninja);
    public static RoleInfo poucher = new("poucher", Poucher.color, RoleId.Poucher);
    public static RoleInfo yoyo = new("yoyo", Yoyo.color, RoleId.Yoyo);
    //Neutral

    public static RoleInfo amnisiac = new("amnesiac", Amnisiac.color, RoleId.Amnisiac, true);
    public static RoleInfo jester = new("jester", Jester.color, RoleId.Jester, true);
    public static RoleInfo vulture = new("vulture", Vulture.color, RoleId.Vulture, true);
    public static RoleInfo lawyer = new("lawyer", Lawyer.color, RoleId.Lawyer, true);
    public static RoleInfo prosecutor = new("prosecutor", Lawyer.color, RoleId.Prosecutor, true);
    public static RoleInfo pursuer = new("pursuer", Pursuer.color, RoleId.Pursuer);
    public static RoleInfo doomsayer = new("doomsayer", Doomsayer.color, RoleId.Doomsayer, true);
    public static RoleInfo jackal = new("jackal", Jackal.color, RoleId.Jackal, true);
    public static RoleInfo sidekick = new("sidekick", Sidekick.color, RoleId.Sidekick, true);
    public static RoleInfo arsonist = new("arsonist", Arsonist.color, RoleId.Arsonist, true);
    public static RoleInfo werewolf = new("werewolf", Werewolf.color, RoleId.Werewolf, true);
    public static RoleInfo juggernaut = new("juggernaut", Juggernaut.color, RoleId.Juggernaut, true);
    public static RoleInfo thief = new("thief", Thief.color, RoleId.Thief, true);

    //Crewmate
    public static RoleInfo crewmate = new("crewmate", Color.white, RoleId.Crewmate);
    public static RoleInfo goodGuesser = new("vigilante", Guesser.color, RoleId.NiceGuesser);
    public static RoleInfo mayor = new("mayor", Mayor.color, RoleId.Mayor);
    public static RoleInfo portalmaker = new("portalmaker", Portalmaker.color, RoleId.Portalmaker);
    public static RoleInfo engineer = new("engineer", Engineer.color, RoleId.Engineer);
    public static RoleInfo privateInvestigator = new("detective", PrivateInvestigator.color, RoleId.PrivateInvestigator);
    public static RoleInfo sheriff = new("sheriff", Sheriff.color, RoleId.Sheriff);
    public static RoleInfo bodyguard = new("bodyGuard", BodyGuard.color, RoleId.BodyGuard, false);
    public static RoleInfo deputy = new("deputy", Sheriff.color, RoleId.Deputy);
    public static RoleInfo lighter = new("lighter", Lighter.color, RoleId.Lighter);
    public static RoleInfo jumper = new("jumper", Jumper.color, RoleId.Jumper);
    public static RoleInfo detective = new("investigator", Detective.color, RoleId.Detective);
    public static RoleInfo timeMaster = new("timeMaster", TimeMaster.color, RoleId.TimeMaster);
    public static RoleInfo veteren = new("veteran", Veteren.color, RoleId.Veteren);
    public static RoleInfo medic = new("medic", Medic.color, RoleId.Medic);
    public static RoleInfo swapper = new("swapper", Swapper.color, RoleId.Swapper);
    public static RoleInfo seer = new("seer", Seer.color, RoleId.Seer);
    public static RoleInfo hacker = new("hacker", Hacker.color, RoleId.Hacker);
    public static RoleInfo tracker = new("tracker", Tracker.color, RoleId.Tracker);
    public static RoleInfo snitch = new("snitch", Snitch.color, RoleId.Snitch);
    public static RoleInfo spy = new("spy", Spy.color, RoleId.Spy);
    public static RoleInfo securityGuard = new("securityGuard", SecurityGuard.color, RoleId.SecurityGuard);
    public static RoleInfo medium = new("Medium", Medium.color, RoleId.Medium);
    public static RoleInfo trapper = new("trapper", Trapper.color, RoleId.Trapper);

    // Modifier
    public static RoleInfo bloody = new("bloody", Color.yellow, RoleId.Bloody, false, true);
    public static RoleInfo antiTeleport = new("antiTeleport", Color.yellow, RoleId.AntiTeleport, false, true);
    public static RoleInfo tiebreaker = new("tieBreaker", Color.yellow, RoleId.Tiebreaker, false, true);
    public static RoleInfo bait = new("bait", Color.yellow, RoleId.Bait, false, true);
    public static RoleInfo aftermath = new("aftermath", Color.yellow, RoleId.Aftermath, false, true);
    public static RoleInfo sunglasses = new("sunglasses", Color.yellow, RoleId.Sunglasses, false, true);
    public static RoleInfo torch = new("torch", Color.yellow, RoleId.Torch, false, true);
    public static RoleInfo flash = new("flash", Color.yellow, RoleId.Flash, false, true);
    public static RoleInfo multitasker = new("multitasker", Color.yellow, RoleId.Multitasker, false, true);
    public static RoleInfo lover = new("lover", Lovers.color, RoleId.Lover, false, true);
    public static RoleInfo mini = new("mini", Color.yellow, RoleId.Mini, false, true);
    public static RoleInfo giant = new("giant", Color.yellow, RoleId.Giant, false, true);
    public static RoleInfo vip = new("vip", Color.yellow, RoleId.Vip, false, true);
    public static RoleInfo indomitable = new("indomitable", Color.yellow, RoleId.Indomitable, false, true);
    public static RoleInfo slueth = new("sleuth", Color.yellow, RoleId.Slueth, false, true);
    public static RoleInfo cursed = new("fanatic", Color.yellow, RoleId.Cursed, false, true, true);
    public static RoleInfo invert = new("invert", Color.yellow, RoleId.Invert, false, true);
    public static RoleInfo blind = new("blind", Color.yellow, RoleId.Blind, false, true);
    public static RoleInfo watcher = new("watcher", Color.yellow, RoleId.Watcher, false, true);
    public static RoleInfo radar = new("radar", Color.yellow, RoleId.Radar, false, true);
    public static RoleInfo tunneler = new("tunneler", Color.yellow, RoleId.Tunneler, false, true);
    public static RoleInfo disperser = new("disperser", Color.red, RoleId.Disperser, false, true);
    public static RoleInfo chameleon = new("chameleon", Color.yellow, RoleId.Chameleon, false, true);
    public static RoleInfo shifter = new("shifter", Color.yellow, RoleId.Shifter, false, true);
    public static RoleInfo armored = new RoleInfo("armored", Color.yellow, RoleId.Armored, false, true);

    public static RoleInfo hunter = new("hunter", Palette.ImpostorRed, RoleId.Impostor);
    public static RoleInfo hunted = new("hunted", Color.white, RoleId.Crewmate);
    public static RoleInfo prop = new("prop", Color.white, RoleId.Crewmate);


    public static List<RoleInfo> allRoleInfos = new()
        {
            //Impostor
            impostor,
            assassin,
            godfather,
            mafioso,
            janitor,
            morphling,
            bomber,
            mimic,
            camouflager,
            miner,
            eraser,
            vampire,
            undertaker,
            escapist,
            warlock,
            trickster,
            bountyHunter,
            cultist,
            cleaner,
            terrorist,
            blackmailer,
            witch,
            ninja,
            yoyo,

            //Neutral
            amnisiac,
            jester,
            vulture,
            lawyer,
            prosecutor,
            pursuer,
            jackal,
            sidekick,
            arsonist,
            werewolf,
            juggernaut,
            doomsayer,
            thief,

            //Crewmate
            crewmate,
            goodGuesser,
            mayor,
            portalmaker,
            engineer,
            privateInvestigator,
            sheriff,
            deputy,
            bodyguard,
            lighter,
            jumper,
            detective,
            timeMaster,
            veteren,
            medic,
            swapper,
            seer,
            hacker,
            tracker,
            snitch,
            spy,
            securityGuard,
            medium,
            trapper,

            //Modifier
            disperser,
            poucher,
            bloody,
            antiTeleport,
            tiebreaker,
            bait,
            sunglasses,
            torch,
            flash,
            multitasker,
            lover,
            mini,
            giant,
            vip,
            indomitable,
            slueth,
            cursed,
            invert,
            blind,
            watcher,
            radar,
            tunneler,
            chameleon,
            armored,
            shifter,
        };

    public static List<RoleInfo> getRoleInfoForPlayer(PlayerControl p, bool showModifier = true)
    {
        List<RoleInfo> infos = new();
        if (p == null) return infos;
        // Modifier
        if (showModifier)
        {
            // after dead modifier
            if (!CustomOptionHolder.modifiersAreHidden.getBool() || PlayerControl.LocalPlayer.Data.IsDead || AmongUsClient.Instance.GameState == InnerNet.InnerNetClient.GameStates.Ended)
            {
                if (Bait.bait.Any(x => x.PlayerId == p.PlayerId)) infos.Add(bait);
                if (Bloody.bloody.Any(x => x.PlayerId == p.PlayerId)) infos.Add(bloody);
                if (Vip.vip.Any(x => x.PlayerId == p.PlayerId)) infos.Add(vip);
                if (p == Tiebreaker.tiebreaker) infos.Add(tiebreaker);
                if (p == Indomitable.indomitable) infos.Add(indomitable);
                if (p == Cursed.cursed) infos.Add(cursed);
            }
            if (p == Lovers.lover1 || p == Lovers.lover2) infos.Add(lover);
            if (AntiTeleport.antiTeleport.Any(x => x.PlayerId == p.PlayerId)) infos.Add(antiTeleport);
            if (Sunglasses.sunglasses.Any(x => x.PlayerId == p.PlayerId)) infos.Add(sunglasses);
            if (Torch.torch.Any(x => x.PlayerId == p.PlayerId)) infos.Add(torch);
            if (Flash.flash.Any(x => x.PlayerId == p.PlayerId)) infos.Add(flash);
            if (Multitasker.multitasker.Any(x => x.PlayerId == p.PlayerId)) infos.Add(multitasker);
            if (p == Mini.mini) infos.Add(mini);
            if (p == Blind.blind) infos.Add(blind);
            if (p == Watcher.watcher) infos.Add(watcher);
            if (p == Aftermath.aftermath) infos.Add(aftermath);
            if (p == Radar.radar) infos.Add(radar);
            if (p == Tunneler.tunneler) infos.Add(tunneler);
            if (p == Slueth.slueth) infos.Add(slueth);
            if (p == Giant.giant) infos.Add(giant);
            if (p == Disperser.disperser) infos.Add(disperser);
            if (Invert.invert.Any(x => x.PlayerId == p.PlayerId)) infos.Add(invert);
            if (Chameleon.chameleon.Any(x => x.PlayerId == p.PlayerId)) infos.Add(chameleon);
            if (p == Armored.armored) infos.Add(armored);
            if (p == Shifter.shifter) infos.Add(shifter);
            if (Guesser.evilGuesser.Any(x => x.PlayerId == p.PlayerId)) infos.Add(assassin);
        }

        int count = infos.Count;  // Save count after modifiers are added so that the role count can be checked

        // Special roles
        if (p == Mimic.mimic) infos.Add(mimic);
        if (p == Jester.jester) infos.Add(jester);
        if (p == Werewolf.werewolf) infos.Add(werewolf);
        if (p == Mayor.mayor) infos.Add(mayor);
        if (p == Portalmaker.portalmaker) infos.Add(portalmaker);
        if (p == Engineer.engineer) infos.Add(engineer);
        if (p == Sheriff.sheriff || p == Sheriff.formerSheriff) infos.Add(sheriff);
        if (p == Deputy.deputy) infos.Add(deputy);
        if (p == Lighter.lighter) infos.Add(lighter);
        if (p == Godfather.godfather) infos.Add(godfather);
        if (p == Miner.miner) infos.Add(miner);
        if (p == Mafioso.mafioso) infos.Add(mafioso);
        if (p == Janitor.janitor) infos.Add(janitor);
        if (p == Morphling.morphling) infos.Add(morphling);
        if (p == Bomber.bomber) infos.Add(bomber);
        if (p == Camouflager.camouflager) infos.Add(camouflager);
        if (p == Vampire.vampire) infos.Add(vampire);
        if (p == Eraser.eraser) infos.Add(eraser);
        if (p == Trickster.trickster) infos.Add(trickster);
        if (p == Cleaner.cleaner) infos.Add(cleaner);
        if (p == Doomsayer.doomsayer) infos.Add(doomsayer);
        if (p == Yoyo.yoyo) infos.Add(yoyo);
        if (p == Undertaker.undertaker) infos.Add(undertaker);
        if (p == PrivateInvestigator.privateInvestigator) infos.Add(privateInvestigator);
        if (p == Poucher.poucher) infos.Add(poucher);
        if (p == Warlock.warlock) infos.Add(warlock);
        if (p == Witch.witch) infos.Add(witch);
        if (p == Escapist.escapist) infos.Add(escapist);
        if (p == Ninja.ninja) infos.Add(ninja);
        if (p == Blackmailer.blackmailer) infos.Add(blackmailer);
        if (p == Terrorist.terrorist) infos.Add(terrorist);
        if (p == Detective.detective) infos.Add(detective);
        if (p == TimeMaster.timeMaster) infos.Add(timeMaster);
        if (p == Cultist.cultist) infos.Add(cultist);
        if (p == Amnisiac.amnisiac) infos.Add(amnisiac);
        if (p == Juggernaut.juggernaut) infos.Add(juggernaut);
        if (p == Veteren.veteren) infos.Add(veteren);
        if (p == Medic.medic) infos.Add(medic);
        if (p == Swapper.swapper) infos.Add(swapper);
        if (p == BodyGuard.bodyguard) infos.Add(bodyguard);
        if (p == Seer.seer) infos.Add(seer);
        if (p == Hacker.hacker) infos.Add(hacker);
        if (p == Tracker.tracker) infos.Add(tracker);
        if (p == Snitch.snitch) infos.Add(snitch);
        if (p == Jackal.jackal || (Jackal.formerJackals != null && Jackal.formerJackals.Any(x => x.PlayerId == p.PlayerId))) infos.Add(jackal);
        if (p == Sidekick.sidekick) infos.Add(sidekick);
        if (p == Follower.follower) infos.Add(follower);
        if (p == Spy.spy) infos.Add(spy);
        if (p == SecurityGuard.securityGuard) infos.Add(securityGuard);
        if (p == Arsonist.arsonist) infos.Add(arsonist);
        if (p == Guesser.niceGuesser) infos.Add(goodGuesser);
        //if (p == Guesser.evilGuesser) infos.Add(badGuesser);
        if (p == BountyHunter.bountyHunter) infos.Add(bountyHunter);
        if (p == Vulture.vulture) infos.Add(vulture);
        if (p == Medium.medium) infos.Add(medium);
        if (p == Lawyer.lawyer && !Lawyer.isProsecutor) infos.Add(lawyer);
        if (p == Lawyer.lawyer && Lawyer.isProsecutor) infos.Add(prosecutor);
        if (p == Trapper.trapper) infos.Add(trapper);
        if (p == Pursuer.pursuer) infos.Add(pursuer);
        if (p == Jumper.jumper) infos.Add(jumper);
        if (p == Thief.thief) infos.Add(thief);

        // Default roles (just impostor, just crewmate, or hunter / hunted for hide n seek, prop hunt prop ...
        if (infos.Count == count)
        {
            if (p.Data.Role.IsImpostor)
                infos.Add(TORMapOptions.gameMode == CustomGamemodes.HideNSeek || TORMapOptions.gameMode == CustomGamemodes.PropHunt ? hunter : impostor);
            else
                infos.Add(TORMapOptions.gameMode == CustomGamemodes.HideNSeek ? hunted : TORMapOptions.gameMode == CustomGamemodes.PropHunt ? prop : crewmate);
        }

        return infos;
    }

    public static string GetRolesString(PlayerControl p, bool useColors, bool showModifier = true, bool suppressGhostInfo = false)
    {
        string roleName;
        roleName = String.Join(" ", getRoleInfoForPlayer(p, showModifier).Select(x => useColors ? cs(x.color, x.name) : x.name).ToArray());
        if (Lawyer.target != null && p.PlayerId == Lawyer.target.PlayerId && PlayerControl.LocalPlayer != Lawyer.target)
            roleName += useColors ? cs(Pursuer.color, " §") : " §";
        if (HandleGuesser.isGuesserGm && HandleGuesser.isGuesser(p.PlayerId))
        {
            int remainingShots = HandleGuesser.remainingShots(p.PlayerId);
            var (playerCompleted, playerTotal) = TasksHandler.taskInfo(p.Data);
            if (!Helpers.isEvil(p) && playerCompleted < HandleGuesser.tasksToUnlock || remainingShots == 0)
                roleName += Helpers.cs(Color.gray, "roleInfoGuesser");
            else
                roleName += Helpers.cs(Color.white, "roleInfoGuesser");
        }

        if (p == Jackal.jackal && Jackal.canSwoop) roleName += "roleInfoSwooper".Translate();

        if (!suppressGhostInfo && p != null)
        {
            if (p == Shifter.shifter && (PlayerControl.LocalPlayer == Shifter.shifter || shouldShowGhostInfo()) && Shifter.futureShift != null)
                roleName += cs(Color.yellow, " ← " + Shifter.futureShift.Data.PlayerName);
            if (p == Vulture.vulture && (PlayerControl.LocalPlayer == Vulture.vulture || shouldShowGhostInfo()))
                roleName = roleName + cs(Vulture.color, string.Format("roleInfoVulture".Translate(), Vulture.vultureNumberToWin - Vulture.eatenBodies));
            if (shouldShowGhostInfo())
            {
                if (Eraser.futureErased.Contains(p))
                    roleName = cs(Color.gray, "roleInfoEraser") + roleName;
                if (Vampire.vampire != null && !Vampire.vampire.Data.IsDead && Vampire.bitten == p && !p.Data.IsDead)
                    roleName = cs(Vampire.color, string.Format("roleInfoVampire", (int)HudManagerStartPatch.vampireKillButton.Timer + 1)) + roleName;
                if (Deputy.handcuffedPlayers.Contains(p.PlayerId))
                    roleName = cs(Color.gray, "roleInfoDeputy") + roleName;
                if (Deputy.handcuffedKnows.ContainsKey(p.PlayerId))  // Active cuff
                    roleName = cs(Deputy.color, "roleInfoDeputy") + roleName;
                if (p == Warlock.curseVictim)
                    roleName = cs(Warlock.color, "roleInfoWarlock") + roleName;
                if (p == Ninja.ninjaMarked)
                    roleName = cs(Ninja.color, "roleInfoNinja") + roleName;
                if (Pursuer.blankedList.Contains(p) && !p.Data.IsDead)
                    roleName = cs(Pursuer.color, "roleInfoPursuer") + roleName;
                if (Witch.futureSpelled.Contains(p) && !MeetingHud.Instance) // This is already displayed in meetings!
                    roleName = cs(Witch.color, "☆ ") + roleName;
                if (BountyHunter.bounty == p)
                    roleName = cs(BountyHunter.color, "roleInfoBountyHunter") + roleName;
                if (Arsonist.dousedPlayers.Contains(p))
                    roleName = cs(Arsonist.color, "♨ ") + roleName;
                if (p == Arsonist.arsonist)
                    roleName = roleName + Helpers.cs(Arsonist.color, string.Format("roleInfoArsonist".Translate(), PlayerControl.AllPlayerControls.ToArray().Count(x => { return x != Arsonist.arsonist && !x.Data.IsDead && !x.Data.Disconnected && !Arsonist.dousedPlayers.Any(y => y.PlayerId == x.PlayerId); })));
                if (p == Jackal.fakeSidekick)
                    roleName = cs(Sidekick.color, "roleInfoJackal") + roleName;
                /*
            if ((p == Swooper.swooper) && Jackal.canSwoop2)
                roleName = Helpers.cs(Swooper.color, $" (Swooper) ") + roleName;
                */

                // Death Reason on Ghosts
                if (p.Data.IsDead)
                {
                    string deathReasonString = "";
                    var deadPlayer = GameHistory.deadPlayers.FirstOrDefault(x => x.player.PlayerId == p.PlayerId);

                    Color killerColor = new();
                    if (deadPlayer != null && deadPlayer.killerIfExisting != null)
                    {
                        killerColor = getRoleInfoForPlayer(deadPlayer.killerIfExisting, false).FirstOrDefault().color;
                    }

                    if (deadPlayer != null)
                    {
                        switch (deadPlayer.deathReason)
                        {
                            case DeadPlayer.CustomDeathReason.Disconnect:
                                deathReasonString = ModTranslation.getString("roleSummaryDisconnected");
                                break;
                            case DeadPlayer.CustomDeathReason.Exile:
                                deathReasonString = ModTranslation.getString("roleSummaryExiled");
                                break;
                            case DeadPlayer.CustomDeathReason.Kill:
                                deathReasonString = string.Format(ModTranslation.getString("roleSummaryKilled"), Helpers.cs(killerColor, deadPlayer.killerIfExisting.Data.PlayerName));
                                break;
                            case DeadPlayer.CustomDeathReason.Guess:
                                if (deadPlayer.killerIfExisting.Data.PlayerName == p.Data.PlayerName)
                                    deathReasonString = ModTranslation.getString("roleSummaryFailedGuess");
                                else
                                    deathReasonString = string.Format(ModTranslation.getString("roleSummaryGuess"), Helpers.cs(killerColor, deadPlayer.killerIfExisting.Data.PlayerName));
                                break;
                            case DeadPlayer.CustomDeathReason.Shift:
                                deathReasonString = $" - {Helpers.cs(Color.yellow, ModTranslation.getString("roleSummaryShift"))} {Helpers.cs(killerColor, deadPlayer.killerIfExisting.Data.PlayerName)}";
                                break;
                            case DeadPlayer.CustomDeathReason.WitchExile:
                                deathReasonString = string.Format(ModTranslation.getString("roleSummarySpelled"), Helpers.cs(killerColor, deadPlayer.killerIfExisting.Data.PlayerName));
                                break;
                            case DeadPlayer.CustomDeathReason.LoverSuicide:
                                deathReasonString = $" - {Helpers.cs(Lovers.color, ModTranslation.getString("roleSummaryLoverDied"))}";
                                break;
                            case DeadPlayer.CustomDeathReason.LawyerSuicide:
                                deathReasonString = $" - {cs(Lawyer.color, "roleSummaryLawyerSuicide")}";
                                break;
                            case DeadPlayer.CustomDeathReason.Bomb:
                                deathReasonString = string.Format(ModTranslation.getString("roleSummaryBombed"), Helpers.cs(killerColor, deadPlayer.killerIfExisting.Data.PlayerName));
                                break;
                            case DeadPlayer.CustomDeathReason.Arson:
                                deathReasonString = string.Format(ModTranslation.getString("roleSummaryTorched"), Helpers.cs(killerColor, deadPlayer.killerIfExisting.Data.PlayerName));
                                break;
                        }
                        roleName = roleName + deathReasonString;
                    }
                }
            }
        }
        return roleName;
    }

    public static async Task loadReadme()
    {
        if (ReadmePage == "")
        {
            HttpClient client = new();
            HttpResponseMessage response = await client.GetAsync("https://raw.githubusercontent.com/TheOtherRolesAU/TheOtherRoles/main/README.md");
            response.EnsureSuccessStatusCode();
            string httpres = await response.Content.ReadAsStringAsync();
            ReadmePage = httpres;
        }
    }
    public static string GetRoleDescription(RoleInfo roleInfo)
    {
        while (ReadmePage == "")
        {
        }

        int index = ReadmePage.IndexOf($"## {roleInfo.name}");
        int endindex = ReadmePage.Substring(index).IndexOf("### Game Options");
        return ReadmePage.Substring(index, endindex);

    }
}
