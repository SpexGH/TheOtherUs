using System;
using HarmonyLib;

namespace TheOtherRoles;

[HarmonyPatch]
public static class TheOtherRoles
{
    public static Random rnd = new((int)DateTime.Now.Ticks);

    public static void clearAndReloadRoles()
    {
        /*Jester.clearAndReload();
        Mayor.clearAndReload();
        Portalmaker.clearAndReload();
        Poucher.clearAndReload();
        Mimic.clearAndReload();
        Engineer.clearAndReload();
        Sheriff.clearAndReload();
        Cursed.clearAndReload();
        Deputy.clearAndReload();
        Amnisiac.clearAndReload();
        Lighter.clearAndReload();
        Godfather.clearAndReload();
        Mafioso.clearAndReload();
        Janitor.clearAndReload();
        Detective.clearAndReload();
        Werewolf.clearAndReload();
        TimeMaster.clearAndReload();
        BodyGuard.clearAndReload();
        Veteren.clearAndReload();
        Medic.clearAndReload();
        PrivateInvestigator.clearAndReload();
        Shifter.clearAndReload();
        Swapper.clearAndReload();
        Lovers.clearAndReload();
        Seer.clearAndReload();
        Morphling.clearAndReload();
        Bomber2.clearAndReload();
        Camouflager.clearAndReload();
        Cultist.clearAndReload();
        Hacker.clearAndReload();
        Tracker.clearAndReload();
        Vampire.clearAndReload();
        Snitch.clearAndReload();
        Jackal.clearAndReload();
        Sidekick.clearAndReload();
        Follower.clearAndReload();
        Eraser.clearAndReload();
        Spy.clearAndReload();
        Trickster.clearAndReload();
        Cleaner.clearAndReload();
        Undertaker.clearAndReload();
        Warlock.clearAndReload();
        SecurityGuard.clearAndReload();
        Arsonist.clearAndReload();
        BountyHunter.clearAndReload();
        Vulture.clearAndReload();
        Medium.clearAndReload();
        Lawyer.clearAndReload();
        Pursuer.clearAndReload();
        Witch.clearAndReload();
        Jumper.clearAndReload();
        Escapist.clearAndReload();
        Ninja.clearAndReload();
        Blackmailer.clearAndReload();
        Thief.clearAndReload();
        Miner.clearAndReload();
        Trapper.clearAndReload();
        Bomber.clearAndReload();
        //Guesser.clearAndReload();
        //Swooper.clearAndReload();

        // Modifier
        Bait.clearAndReload();
        Bloody.clearAndReload();
        AntiTeleport.clearAndReload();
        Tiebreaker.clearAndReload();
        Sunglasses.clearAndReload();
        Torch.clearAndReload();
        Blind.clearAndReload();
        Watcher.clearAndReload();
        Radar.clearAndReload();
        Tunneler.clearAndReload();
        Multitasker.clearAndReload();
        Disperser.clearAndReload();
        Mini.clearAndReload();
        Indomitable.clearAndReload();
        Slueth.clearAndReload();
        Vip.clearAndReload();
        Invert.clearAndReload();
        Chameleon.clearAndReload();

        // Gamemodes
        HandleGuesser.clearAndReload();
        HideNSeek.clearAndReload();
        PropHunt.clearAndReload();*/
    }
}