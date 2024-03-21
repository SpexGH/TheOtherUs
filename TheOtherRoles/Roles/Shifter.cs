using UnityEngine;

namespace TheOtherRoles;

public static class Shifter {
    public static PlayerControl shifter;

    public static PlayerControl futureShift;
    public static PlayerControl currentTarget;

    private static Sprite buttonSprite;
    public static Sprite getButtonSprite() {
        if (buttonSprite) return buttonSprite;
        buttonSprite = Helpers.loadSpriteFromResources("TheOtherRoles.Resources.ShiftButton.png", 115f);
        return buttonSprite;
    }

    public static void shiftRole (PlayerControl player1, PlayerControl player2, bool repeat = true) {
        if (TheOtherRoles.Mayor.mayor != null && TheOtherRoles.Mayor.mayor == player2) {
            if (repeat) shiftRole(player2, player1, false);
            TheOtherRoles.Mayor.mayor = player1;
        } else if (Portalmaker.portalmaker != null && Portalmaker.portalmaker == player2) {
            if (repeat) shiftRole(player2, player1, false);
            Portalmaker.portalmaker = player1;
        } else if (TheOtherRoles.Engineer.engineer != null && TheOtherRoles.Engineer.engineer == player2) {
            if (repeat) shiftRole(player2, player1, false);
            TheOtherRoles.Engineer.engineer = player1;
        } else if (TheOtherRoles.Sheriff.sheriff != null && TheOtherRoles.Sheriff.sheriff == player2) {
            if (repeat) shiftRole(player2, player1, false);
            if (TheOtherRoles.Sheriff.formerDeputy != null && TheOtherRoles.Sheriff.formerDeputy == TheOtherRoles.Sheriff.sheriff) TheOtherRoles.Sheriff.formerDeputy = player1;  // Shifter also shifts info on promoted deputy (to get handcuffs)
            TheOtherRoles.Sheriff.sheriff = player1;
        } else if (TheOtherRoles.Deputy.deputy != null && TheOtherRoles.Deputy.deputy == player2) {
            if (repeat) shiftRole(player2, player1, false);
            TheOtherRoles.Deputy.deputy = player1;
        } else if (TheOtherRoles.Lighter.lighter != null && TheOtherRoles.Lighter.lighter == player2) {
            if (repeat) shiftRole(player2, player1, false);
            TheOtherRoles.Lighter.lighter = player1;
        } else if (TheOtherRoles.Detective.detective != null && TheOtherRoles.Detective.detective == player2) {
            if (repeat) shiftRole(player2, player1, false);
            TheOtherRoles.Detective.detective = player1;
        } else if (TimeMaster.timeMaster != null && TimeMaster.timeMaster == player2) {
            if (repeat) shiftRole(player2, player1, false);
            TimeMaster.timeMaster = player1;
        }  else if (Medic.medic != null && Medic.medic == player2) {
            if (repeat) shiftRole(player2, player1, false);
            Medic.medic = player1;
        } else if (Swapper.swapper != null && Swapper.swapper == player2) {
            if (repeat) shiftRole(player2, player1, false);
            Swapper.swapper = player1;
        } else if (Seer.seer != null && Seer.seer == player2) {
            if (repeat) shiftRole(player2, player1, false);
            Seer.seer = player1;
        } else if (Hacker.hacker != null && Hacker.hacker == player2) {
            if (repeat) shiftRole(player2, player1, false);
            Hacker.hacker = player1;
        } else if (Tracker.tracker != null && Tracker.tracker == player2) {
            if (repeat) shiftRole(player2, player1, false);
            Tracker.tracker = player1;
        } else if (Snitch.snitch != null && Snitch.snitch == player2) {
            if (repeat) shiftRole(player2, player1, false);
            Snitch.snitch = player1;
        } else if (Spy.spy != null && Spy.spy == player2) {
            if (repeat) shiftRole(player2, player1, false);
            Spy.spy = player1;
        } else if (SecurityGuard.securityGuard != null && SecurityGuard.securityGuard == player2) {
            if (repeat) shiftRole(player2, player1, false);
            SecurityGuard.securityGuard = player1;
        } else if (Guesser.niceGuesser != null && Guesser.niceGuesser == player2) {
            if (repeat) shiftRole(player2, player1, false);
            Guesser.niceGuesser = player1;
        } else if (Medium.medium != null && Medium.medium == player2) {
            if (repeat) shiftRole(player2, player1, false);
            Medium.medium = player1;
        } else if (Pursuer.pursuer != null && Pursuer.pursuer == player2) {
            if (repeat) shiftRole(player2, player1, false);
            Pursuer.pursuer = player1;
        } else if (Trapper.trapper != null && Trapper.trapper == player2) {
            if (repeat) shiftRole(player2, player1, false);
            Trapper.trapper = player1;
        }
    }

    public static void clearAndReload() {
        shifter = null;
        currentTarget = null;
        futureShift = null;
    }
}