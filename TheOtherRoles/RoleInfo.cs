using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
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
    public static Dictionary<RoleId, RoleInfo> roleInfoById = new();

    public RoleInfo(string name, Color color, string introDescription, string shortDescription, RoleId roleId,
        bool isNeutral = false, bool isModifier = false, bool isGuessable = false, bool isImpostor = false)
    {
        this.color = color;
        this.name = name;
        this.introDescription = introDescription;
        this.shortDescription = shortDescription;
        this.roleId = roleId;
        this.isNeutral = isNeutral;
        this.isModifier = isModifier;
        this.isGuessable = isGuessable;
        this.isImpostor = isImpostor;
        roleInfoById.TryAdd(roleId, this);
    }

    public static RoleInfo impostor = new("Impostor", Palette.ImpostorRed, cs(Palette.ImpostorRed, "Sabotage and kill everyone"), "Sabotage and kill everyone", RoleId.Impostor);
    public static RoleInfo assassin = new("Assassin", Color.red, "Guess and shoot", "Guess and shoot", RoleId.EvilGuesser, false, true);
    public static RoleInfo godfather = new("Godfather", Godfather.color, "Kill all Crewmates", "Kill all Crewmates", RoleId.Godfather);
    public static RoleInfo mafioso = new("Mafioso", Mafioso.color, "Work with the <color=#FF1919FF>Mafia</color> to kill the Crewmates", "Kill all Crewmates", RoleId.Mafioso);
    public static RoleInfo janitor = new("Janitor", Janitor.color, "Work with the <color=#FF1919FF>Mafia</color> by hiding dead bodies", "Hide dead bodies", RoleId.Janitor);
    public static RoleInfo morphling = new("Morphling", Morphling.color, "Change your look to not get caught", "Change your look", RoleId.Morphling);
    public static RoleInfo bomber = new("Bomber", Bomber.color, "Give bombs to players", "Bomb Everyone", RoleId.Bomber);
    public static RoleInfo mimic = new("Mimic", Mimic.color, "Pose as a crewmate by killing one", "Pose as a crewmate", RoleId.Mimic);
    public static RoleInfo camouflager = new("Camouflager", Camouflager.color, "Camouflage and kill the Crewmates", "Hide among others", RoleId.Camouflager);
    public static RoleInfo miner = new("Miner", Miner.color, "Make new Vents", "Create Vents", RoleId.Miner);
    public static RoleInfo eraser = new("Eraser", Eraser.color, "Kill the Crewmates and erase their roles", "Erase the roles of your enemies", RoleId.Eraser);
    public static RoleInfo vampire = new("Vampire", Vampire.color, "Kill the Crewmates with your bites", "Bite your enemies", RoleId.Vampire);
    public static RoleInfo cleaner = new("Cleaner", Cleaner.color, "Kill everyone and leave no traces", "Clean up dead bodies", RoleId.Cleaner);
    public static RoleInfo undertaker = new("Undertaker", Undertaker.color, "Kill everyone and leave no traces", "Drag up dead bodies to hide them", RoleId.Undertaker);
    public static RoleInfo escapist = new("Escapist", Escapist.color, "Get away from kills with ease", "Teleport to get away from bodies", RoleId.Escapist);
    public static RoleInfo warlock = new("Warlock", Warlock.color, "Curse other players and kill everyone", "Curse and kill everyone", RoleId.Warlock);
    public static RoleInfo trickster = new("Trickster", Trickster.color, "Use your jack-in-the-boxes to surprise others", "Surprise your enemies", RoleId.Trickster);
    public static RoleInfo bountyHunter = new("Bounty Hunter", BountyHunter.color, "Hunt your bounty down", "Hunt your bounty down", RoleId.BountyHunter);
    public static RoleInfo cultist = new("Cultist", Cultist.color, "Recruit for your cause", "Recruit for your cause", RoleId.Cultist);
    public static RoleInfo follower = new("Follower", Cleaner.color, "Follow your leader", "Follow your leader", RoleId.Follower, true);
    public static RoleInfo terrorist = new("Terrorist", Terrorist.color, "Bomb all Crewmates", "Bomb all Crewmates", RoleId.Terrorist);
    public static RoleInfo blackmailer = new("Blackmailer", Blackmailer.color, "Blackmail those who seek to hurt you", "Blackmail those who seek to hurt you", RoleId.Blackmailer);
    public static RoleInfo witch = new("Witch", Witch.color, "Cast a spell upon your foes", "Cast a spell upon your foes", RoleId.Witch);
    public static RoleInfo ninja = new("Ninja", Ninja.color, "Surprise and assassinate your foes", "Surprise and assassinate your foes", RoleId.Ninja);
    public static RoleInfo yoyo = new("Yo-Yo", Yoyo.color, "Blink to a marked location and Back", "Blink to a location", RoleId.Yoyo);
    //Neutral

    public static RoleInfo amnisiac = new("Amnesiac", Amnisiac.color, "Steal roles from the dead", "Steal roles from the dead", RoleId.Amnisiac, true);
    public static RoleInfo jester = new("Jester", Jester.color, "Get voted out", "Get voted out", RoleId.Jester, true);
    public static RoleInfo vulture = new("Vulture", Vulture.color, "Eat corpses to win", "Eat dead bodies", RoleId.Vulture, true);
    public static RoleInfo lawyer = new("Lawyer", Lawyer.color, "Defend your client", "Defend your client", RoleId.Lawyer, true);
    public static RoleInfo prosecutor = new("Prosecutor", Lawyer.color, "Vote out your target", "Vote out your target", RoleId.Prosecutor, true);
    public static RoleInfo pursuer = new("Pursuer", Pursuer.color, "Blank the Impostors", "Blank the Impostors", RoleId.Pursuer);
    public static RoleInfo doomsayer = new("Doomsayer", Doomsayer.color, "Guess People's Roles To Win!", "Win by guessing player's roles", RoleId.Doomsayer, true);
    public static RoleInfo jackal = new("Jackal", Jackal.color, "Kill all Crewmates and <color=#FF1919FF>Impostors</color> to win", "Kill everyone", RoleId.Jackal, true);
    public static RoleInfo sidekick = new("Sidekick", Sidekick.color, "Help your Jackal to kill everyone", "Help your Jackal to kill everyone", RoleId.Sidekick, true);
    public static RoleInfo arsonist = new("Arsonist", Arsonist.color, "Let them burn", "Let them burn", RoleId.Arsonist, true);
    public static RoleInfo werewolf = new("Werewolf", Werewolf.color, "Rampage and kill everyone", "Rampage and kill everyone", RoleId.Werewolf, true);
    public static RoleInfo juggernaut = new("Juggernaut", Juggernaut.color, "Your Power Grows With Every Kill", "With each kill your kill cooldown decreases", RoleId.Juggernaut, true);
    public static RoleInfo thief = new("Thief", Thief.color, "Steal a killers role by killing them", "Steal a killers role", RoleId.Thief, true);

    //Crewmate
    public static RoleInfo crewmate = new("Crewmate", Color.white, "Find the Impostors", "Find the Impostors", RoleId.Crewmate);
    public static RoleInfo goodGuesser = new("Vigilante", Guesser.color, "Guess and shoot", "Guess and shoot", RoleId.NiceGuesser);
    public static RoleInfo mayor = new("Mayor", Mayor.color, "Your vote counts twice", "Your vote counts twice", RoleId.Mayor);
    public static RoleInfo portalmaker = new("Portalmaker", Portalmaker.color, "You can create portals", "You can create portals", RoleId.Portalmaker);
    public static RoleInfo engineer = new("Engineer", Engineer.color, "Maintain important systems on the ship", "Repair the ship", RoleId.Engineer);
    public static RoleInfo privateInvestigator = new("Detective", PrivateInvestigator.color, "See who is interacting with others", "Spy on the ship.", RoleId.PrivateInvestigator);
    public static RoleInfo sheriff = new("Sheriff", Sheriff.color, "Shoot the <color=#FF1919FF>Impostors</color>", "Shoot the Impostors", RoleId.Sheriff);
    public static RoleInfo bodyguard = new("Body Guard", BodyGuard.color, "Protect someone with your own life", "Protect someone with your own life", RoleId.BodyGuard, false);
    public static RoleInfo deputy = new("Deputy", Sheriff.color, "Handcuff the <color=#FF1919FF>Impostors</color>", "Handcuff the Impostors", RoleId.Deputy);
    public static RoleInfo lighter = new("Lighter", Lighter.color, "Your light never goes out", "Your light never goes out", RoleId.Lighter);
    public static RoleInfo poucher = new("Poucher", Poucher.color, "Keep info on the players you kill", "Investigate the kills", RoleId.Poucher);
    public static RoleInfo jumper = new("Jumper", Jumper.color, "Surprise the <color=#FF1919FF>Impostors</color>", "Surprise the Impostors", RoleId.Jumper);
    public static RoleInfo detective = new("Investigator", Detective.color, "Find the <color=#FF1919FF>Impostors</color> by examining footprints", "Examine footprints", RoleId.Detective);
    public static RoleInfo timeMaster = new("Time Master", TimeMaster.color, "Save yourself with your time shield", "Use your time shield", RoleId.TimeMaster);
    public static RoleInfo veteren = new("Veteran", Veteren.color, "Protect yourself from other", "Protect yourself from others", RoleId.Veteren);
    public static RoleInfo medic = new("Medic", Medic.color, "Protect someone with your shield", "Protect other players", RoleId.Medic);
    public static RoleInfo swapper = new("Swapper", Swapper.color, "Swap votes to exile the <color=#FF1919FF>Impostors</color>", "Swap votes", RoleId.Swapper);
    public static RoleInfo seer = new("Seer", Seer.color, "You will see players die", "You will see players die", RoleId.Seer);
    public static RoleInfo hacker = new("Hacker", Hacker.color, "Hack systems to find the <color=#FF1919FF>Impostors</color>", "Hack to find the Impostors", RoleId.Hacker);
    public static RoleInfo tracker = new("Tracker", Tracker.color, "Track the <color=#FF1919FF>Impostors</color> down", "Track the Impostors down", RoleId.Tracker);
    public static RoleInfo snitch = new("Snitch", Snitch.color, "Finish your tasks to find the <color=#FF1919FF>Impostors</color>", "Finish your tasks", RoleId.Snitch);
    public static RoleInfo spy = new("Spy", Spy.color, "Confuse the <color=#FF1919FF>Impostors</color>", "Confuse the Impostors", RoleId.Spy);
    public static RoleInfo securityGuard = new("Security Guard", SecurityGuard.color, "Seal vents and place cameras", "Seal vents and place cameras", RoleId.SecurityGuard);
    public static RoleInfo medium = new("Medium", Medium.color, "Question the souls of the dead to gain information", "Question the souls", RoleId.Medium);
    public static RoleInfo trapper = new("Trapper", Trapper.color, "Place traps to find the Impostors", "Place traps", RoleId.Trapper);

    // Modifier
    public static RoleInfo bloody = new("Bloody", Color.yellow, "Your killer leaves a bloody trail", "Your killer leaves a bloody trail", RoleId.Bloody, false, true);
    public static RoleInfo antiTeleport = new("Anti tp", Color.yellow, "You will not get teleported", "You will not get teleported", RoleId.AntiTeleport, false, true);
    public static RoleInfo tiebreaker = new("Tiebreaker", Color.yellow, "Your vote breaks the tie", "Break the tie", RoleId.Tiebreaker, false, true);
    public static RoleInfo bait = new("Bait", Color.yellow, "Bait your enemies", "Bait your enemies", RoleId.Bait, false, true);
    public static RoleInfo aftermath = new("Aftermath", Color.yellow, "Force your killer to use their ability", "Force your killer to use their ability", RoleId.Aftermath, false, true);
    public static RoleInfo sunglasses = new("Sunglasses", Color.yellow, "You got the sunglasses", "Your vision is reduced", RoleId.Sunglasses, false, true);
    public static RoleInfo torch = new("Torch", Color.yellow, "You got the torch", "You can see in the dark", RoleId.Torch, false, true);
    public static RoleInfo flash = new("Flash", Color.yellow, "Super speed!", "Super speed!", RoleId.Flash, false, true);
    public static RoleInfo multitasker = new("Multitasker", Color.yellow, "Your task windows are transparent", "Your task windows are transparent", RoleId.Multitasker, false, true);
    public static RoleInfo lover = new("Lover", Lovers.color, $"You are in love", $"You are in love", RoleId.Lover, false, true);
    public static RoleInfo mini = new("Mini", Color.yellow, "No one will harm you until you grow up", "No one will harm you", RoleId.Mini, false, true);
    public static RoleInfo giant = new("Giant", Color.yellow, "You are ginormous", "You are ginormous", RoleId.Giant, false, true);
    public static RoleInfo vip = new("VIP", Color.yellow, "You are the VIP", "Everyone is notified when you die", RoleId.Vip, false, true);
    public static RoleInfo indomitable = new("Indomitable", Color.yellow, "Your role cannot be guessed", "You are Indomitable!", RoleId.Indomitable, false, true);
    public static RoleInfo slueth = new("Sleuth", Color.yellow, "Learn the roles of bodies you report", "You know the roles of bodies you report", RoleId.Slueth, false, true);
    public static RoleInfo cursed = new("Fanatic", Color.yellow, "You are crewmate....for now", "Discover your true potential", RoleId.Cursed, false, true, true);
    public static RoleInfo invert = new("Invert", Color.yellow, "Your movement is inverted", "Your movement is inverted", RoleId.Invert, false, true);
    public static RoleInfo blind = new("Blind", Color.yellow, "You cannot see your report button!", "Was that a dead body?", RoleId.Blind, false, true);
    public static RoleInfo watcher = new("Watcher", Color.yellow, "You can see everyone's votes during meetings", "Pay close attention to the crew's votes", RoleId.Watcher, false, true);
    public static RoleInfo radar = new("Radar", Color.yellow, "Be on high alert", "Be on high alert", RoleId.Radar, false, true);
    public static RoleInfo tunneler = new("Tunneler", Color.yellow, "Complete your tasks to gain the ability to vent", "Finish work so you can play", RoleId.Tunneler, false, true);
    public static RoleInfo disperser = new("Disperser", Color.red, "Separate the Crew", "Separate the Crew", RoleId.Disperser, false, true);
    public static RoleInfo chameleon = new("Chameleon", Color.yellow, "You're hard to see when not moving", "You're hard to see when not moving", RoleId.Chameleon, false, true);
    public static RoleInfo armored = new RoleInfo("Armored", Color.yellow, "You are protected from one murder attempt", "You are protected from one murder attempt", RoleId.Armored, false, true);
    public static RoleInfo shifter = new("Shifter", Color.yellow, "Shift your role", "Shift your role", RoleId.Shifter, false, true);

    public static RoleInfo hunter = new("Hunter", Palette.ImpostorRed, cs(Palette.ImpostorRed, "Seek and kill everyone"), "Seek and kill everyone", RoleId.Impostor);
    public static RoleInfo hunted = new("Hunted", Color.white, "Hide", "Hide", RoleId.Crewmate);
    public static RoleInfo prop = new("Prop", Color.white, "Disguise As An Object and Survive", "Disguise As An Object", RoleId.Crewmate);


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
            if (!isEvil(p) && playerCompleted < HandleGuesser.tasksToUnlock || remainingShots == 0)
                roleName += cs(Color.gray, " (Guesser)");
            else
                roleName += cs(Color.white, " (Guesser)");
        }

        if (p == Jackal.jackal && Jackal.canSwoop) roleName += " (Swooper)";

        if (!suppressGhostInfo && p != null)
        {
            if (p == Shifter.shifter && (PlayerControl.LocalPlayer == Shifter.shifter || shouldShowGhostInfo()) && Shifter.futureShift != null)
                roleName += cs(Color.yellow, " ← " + Shifter.futureShift.Data.PlayerName);
            if (p == Vulture.vulture && (PlayerControl.LocalPlayer == Vulture.vulture || shouldShowGhostInfo()))
                roleName = roleName + cs(Vulture.color, $" ({Vulture.vultureNumberToWin - Vulture.eatenBodies} left)");
            if (shouldShowGhostInfo())
            {
                if (Eraser.futureErased.Contains(p))
                    roleName = cs(Color.gray, "(erased) ") + roleName;
                if (Vampire.vampire != null && !Vampire.vampire.Data.IsDead && Vampire.bitten == p && !p.Data.IsDead)
                    roleName = cs(Vampire.color, $"(bitten {(int)HudManagerStartPatch.vampireKillButton.Timer + 1}) ") + roleName;
                if (Deputy.handcuffedPlayers.Contains(p.PlayerId))
                    roleName = cs(Color.gray, "(cuffed) ") + roleName;
                if (Deputy.handcuffedKnows.ContainsKey(p.PlayerId))  // Active cuff
                    roleName = cs(Deputy.color, "(cuffed) ") + roleName;
                if (p == Warlock.curseVictim)
                    roleName = cs(Warlock.color, "(cursed) ") + roleName;
                if (p == Ninja.ninjaMarked)
                    roleName = cs(Ninja.color, "(marked) ") + roleName;
                if (Pursuer.blankedList.Contains(p) && !p.Data.IsDead)
                    roleName = cs(Pursuer.color, "(blanked) ") + roleName;
                if (Witch.futureSpelled.Contains(p) && !MeetingHud.Instance) // This is already displayed in meetings!
                    roleName = cs(Witch.color, "☆ ") + roleName;
                if (BountyHunter.bounty == p)
                    roleName = cs(BountyHunter.color, "(bounty) ") + roleName;
                if (Arsonist.dousedPlayers.Contains(p))
                    roleName = cs(Arsonist.color, "♨ ") + roleName;
                if (p == Arsonist.arsonist)
                    roleName = roleName + cs(Arsonist.color, $" ({PlayerControl.AllPlayerControls.ToArray().Count(x => { return x != Arsonist.arsonist && !x.Data.IsDead && !x.Data.Disconnected && !Arsonist.dousedPlayers.Any(y => y.PlayerId == x.PlayerId); })} left)");
                if (p == Jackal.fakeSidekick)
                    roleName = cs(Sidekick.color, $" (fake SK) ") + roleName;
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
                                deathReasonString = " - disconnected";
                                break;
                            case DeadPlayer.CustomDeathReason.Exile:
                                deathReasonString = " - voted out";
                                break;
                            case DeadPlayer.CustomDeathReason.Kill:
                                deathReasonString = $" - killed by {cs(killerColor, deadPlayer.killerIfExisting.Data.PlayerName)}";
                                break;
                            case DeadPlayer.CustomDeathReason.Guess:
                                if (deadPlayer.killerIfExisting.Data.PlayerName == p.Data.PlayerName)
                                    deathReasonString = $" - failed guess";
                                else
                                    deathReasonString = $" - guessed by {cs(killerColor, deadPlayer.killerIfExisting.Data.PlayerName)}";
                                break;
                            case DeadPlayer.CustomDeathReason.Shift:
                                deathReasonString = $" - {cs(Color.yellow, "shifted")} {cs(killerColor, deadPlayer.killerIfExisting.Data.PlayerName)}";
                                break;
                            case DeadPlayer.CustomDeathReason.WitchExile:
                                deathReasonString = $" - {cs(Witch.color, "witched")} by {cs(killerColor, deadPlayer.killerIfExisting.Data.PlayerName)}";
                                break;
                            case DeadPlayer.CustomDeathReason.LoverSuicide:
                                deathReasonString = $" - {cs(Lovers.color, "lover died")}";
                                break;
                            case DeadPlayer.CustomDeathReason.LawyerSuicide:
                                deathReasonString = $" - {cs(Lawyer.color, "bad Lawyer")}";
                                break;
                            case DeadPlayer.CustomDeathReason.Bomb:
                                deathReasonString = $" - bombed by {cs(killerColor, deadPlayer.killerIfExisting.Data.PlayerName)}";
                                break;
                            case DeadPlayer.CustomDeathReason.Arson:
                                deathReasonString = $" - burnt by {cs(killerColor, deadPlayer.killerIfExisting.Data.PlayerName)}";
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
