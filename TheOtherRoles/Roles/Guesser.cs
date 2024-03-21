using System.Collections.Generic;
using UnityEngine;

namespace TheOtherRoles;

public static class Guesser {
    public static PlayerControl niceGuesser;
    //public static PlayerControl evilGuesser;
    public static List<PlayerControl> evilGuesser = new List<PlayerControl>();
    public static Color color = new Color32(255, 255, 0, byte.MaxValue);

    public static int remainingShotsEvilGuesser = 2;
    public static int remainingShotsNiceGuesser = 2;
    public static bool hasMultipleShotsPerMeeting = false;
    public static bool assassinMultipleShotsPerMeeting = false;
    public static bool showInfoInGhostChat = true;
    public static bool killsThroughShield = true;
    public static bool assassinKillsThroughShield = true;
    public static bool evilGuesserCanGuessSpy = true;
    public static bool guesserCantGuessSnitch = false;
    public static bool evilGuesserCanGuessCrewmate = true;

    public static bool isGuesser(byte playerId)
    {
        foreach (PlayerControl item in evilGuesser)
        {
            if (item.PlayerId == playerId && evilGuesser != null)
            {
                return true;
            }
        }
        if (niceGuesser != null && niceGuesser.PlayerId == playerId)
        {
            return true;
        }
        return false;
    }

    public static void clear(byte playerId)
    {
        if (niceGuesser != null && niceGuesser.PlayerId == playerId)
        {
            niceGuesser = null;
        }
        foreach (PlayerControl item in evilGuesser)
        {
            if (item.PlayerId == playerId && evilGuesser != null)
            {
                evilGuesser = null;
            }
        }
    }

    public static int remainingShots(byte playerId, bool shoot = false)
    {
        int result = remainingShotsEvilGuesser;
        if (niceGuesser != null && niceGuesser.PlayerId == playerId)
        {
            result = remainingShotsNiceGuesser;
            if (shoot)
            {
                remainingShotsNiceGuesser = Mathf.Max(0, remainingShotsNiceGuesser - 1);
            }
        }
        else if (shoot)
        {
            remainingShotsEvilGuesser = Mathf.Max(0, remainingShotsEvilGuesser - 1);
        }
        return result;
    }

    public static void clearAndReload() {
        niceGuesser = null;
        evilGuesser = new List<PlayerControl>();
        guesserCantGuessSnitch = CustomOptionHolder.guesserCantGuessSnitchIfTaksDone.getBool();
        remainingShotsEvilGuesser = Mathf.RoundToInt(CustomOptionHolder.modifierAssassinNumberOfShots.getFloat());
        remainingShotsNiceGuesser = Mathf.RoundToInt(CustomOptionHolder.guesserNumberOfShots.getFloat());
        hasMultipleShotsPerMeeting = CustomOptionHolder.guesserHasMultipleShotsPerMeeting.getBool();
        assassinMultipleShotsPerMeeting = CustomOptionHolder.modifierAssassinMultipleShotsPerMeeting.getBool();
        showInfoInGhostChat = CustomOptionHolder.guesserShowInfoInGhostChat.getBool();
        killsThroughShield = CustomOptionHolder.guesserKillsThroughShield.getBool();
        assassinKillsThroughShield = CustomOptionHolder.modifierAssassinKillsThroughShield.getBool();
        evilGuesserCanGuessSpy = CustomOptionHolder.guesserEvilCanKillSpy.getBool();
        evilGuesserCanGuessCrewmate = CustomOptionHolder.guesserEvilCanKillCrewmate.getBool();
    }
}