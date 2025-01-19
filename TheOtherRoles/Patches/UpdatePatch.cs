using System;
using System.Collections.Generic;
using System.Linq;
using AmongUs.GameOptions;
using TheOtherRoles.CustomGameModes;
using TheOtherRoles.Modules;
using TheOtherRoles.Objects;
using TheOtherRoles.Utilities;
using UnityEngine;
using static TheOtherRoles.TheOtherRoles;

namespace TheOtherRoles.Patches;

[HarmonyPatch(typeof(HudManager), nameof(HudManager.Update))]
class HudManagerUpdatePatch
{
    private static Dictionary<byte, (string name, Color color)> TagColorDict = new();
    static void resetNameTagsAndColors()
    {
        var localPlayer = CachedPlayer.LocalPlayer.PlayerControl;
        var myData = CachedPlayer.LocalPlayer.Data;
        var amImpostor = myData.Role.IsImpostor;
        var morphTimerNotUp = Morphling.morphTimer > 0f;
        var morphTargetNotNull = Morphling.morphTarget != null;

        var dict = TagColorDict;
        dict.Clear();

        foreach (var data in GameData.Instance.AllPlayers.GetFastEnumerator())
        {
            var player = data.Object;
            string text = data.PlayerName;
            Color color;
            if (player)
            {
                var playerName = text;
                if (morphTimerNotUp && morphTargetNotNull && Morphling.morphling == player) playerName = Morphling.morphTarget.Data.PlayerName;
                var nameText = player.cosmetics.nameText;

                nameText.text = hidePlayerName(localPlayer, player) ? "" : playerName;
                nameText.color = color = amImpostor && data.Role.IsImpostor ? Palette.ImpostorRed : Color.white;
                nameText.color = nameText.color.SetAlpha(Chameleon.visibility(player.PlayerId));
            }
            else
            {
                color = Color.white;
            }


            dict.Add(data.PlayerId, (text, color));
        }

        if (MeetingHud.Instance != null)
        {
            foreach (PlayerVoteArea playerVoteArea in MeetingHud.Instance.playerStates)
            {
                var data = dict[playerVoteArea.TargetPlayerId];
                var text = playerVoteArea.NameText;
                text.text = data.name;
                text.color = data.color;
            }
        }
    }

    static void setPlayerNameColor(PlayerControl p, Color color)
    {
        p.cosmetics.nameText.color = color.SetAlpha(Chameleon.visibility(p.PlayerId));
        if (MeetingHud.Instance != null)
            foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                if (player.NameText != null && p.PlayerId == player.TargetPlayerId)
                    player.NameText.color = color;
    }

    static void updateBlindReport()
    {
        if (Blind.blind != null && CachedPlayer.LocalPlayer.PlayerControl == Blind.blind)
        {
            DestroyableSingleton<HudManager>.Instance.ReportButton.SetActive(false);
            // Sadly the report button cannot be hidden due to preventing R to report
        }
    }

    static void setNameColors()
    {
        var localPlayer = CachedPlayer.LocalPlayer.PlayerControl;
        var localRole = RoleInfo.getRoleInfoForPlayer(localPlayer, false).FirstOrDefault();
        setPlayerNameColor(localPlayer, localRole.color);

        if (Sheriff.sheriff != null && Sheriff.sheriff == localPlayer)
        {
            setPlayerNameColor(Sheriff.sheriff, Sheriff.color);
            if (Deputy.deputy != null && Deputy.knowsSheriff) setPlayerNameColor(Deputy.deputy, Sheriff.color);
        }

        if (Deputy.deputy != null && Deputy.deputy == localPlayer)
        {
            setPlayerNameColor(Deputy.deputy, Deputy.color);
            if (Sheriff.sheriff != null && Deputy.knowsSheriff) setPlayerNameColor(Sheriff.sheriff, Sheriff.color);
        }

        else if (Jackal.jackal != null && Jackal.jackal == localPlayer)
        {
            // Jackal can see his sidekick
            setPlayerNameColor(Jackal.jackal, Jackal.color);
            if (Sidekick.sidekick != null)
            {
                setPlayerNameColor(Sidekick.sidekick, Jackal.color);
            }
            if (Jackal.fakeSidekick != null)
            {
                setPlayerNameColor(Jackal.fakeSidekick, Jackal.color);
            }
        }

        if (Snitch.snitch != null)
        {
            var (playerCompleted, playerTotal) = TasksHandler.taskInfo(Snitch.snitch.Data);
            int numberOfTasks = playerTotal - playerCompleted;
            var snitchIsDead = Snitch.snitch.Data.IsDead;

            bool forImp = localPlayer.Data.Role.IsImpostor;
            bool forKillerTeam = Snitch.Team == Snitch.includeNeutralTeam.KillNeutral && isKiller(localPlayer);
            bool forEvilTeam = Snitch.Team == Snitch.includeNeutralTeam.EvilNeutral && isEvil(localPlayer);
            bool forNeutraTeam = Snitch.Team == Snitch.includeNeutralTeam.AllNeutral && isNeutral(localPlayer);
            if (numberOfTasks <= Snitch.taskCountForReveal)
            {
                foreach (PlayerControl p in CachedPlayer.AllPlayers)
                {
                    if (forImp || forKillerTeam || forEvilTeam || forNeutraTeam)
                    {
                        setPlayerNameColor(Snitch.snitch, Snitch.color);
                    }
                }
            }
            if (numberOfTasks == 0 && Snitch.seeInMeeting && !snitchIsDead)
            {
                foreach (PlayerControl p in CachedPlayer.AllPlayers)
                {
                    bool TargetsImp = p.Data.Role.IsImpostor;
                    bool TargetsKillerTeam = Snitch.Team == Snitch.includeNeutralTeam.KillNeutral && isKiller(p);
                    bool TargetsEvilTeam = Snitch.Team == Snitch.includeNeutralTeam.EvilNeutral && isEvil(p);
                    bool TargetsNeutraTeam = Snitch.Team == Snitch.includeNeutralTeam.AllNeutral && isNeutral(p);
                    var targetsRole = RoleInfo.getRoleInfoForPlayer(p, false).FirstOrDefault();
                    if (localPlayer == Snitch.snitch && (TargetsImp || TargetsKillerTeam || TargetsEvilTeam || TargetsNeutraTeam))
                    {
                        if (Snitch.teamNeutraUseDifferentArrowColor)
                        {
                            setPlayerNameColor(p, targetsRole.color);
                        }
                        else
                        {
                            setPlayerNameColor(p, Palette.ImpostorRed);
                        }
                    }
                }
            }
        }

        // No else if here, as a Lover of team Jackal needs the colors
        if (Sidekick.sidekick != null && Sidekick.sidekick == localPlayer)
        {
            // Sidekick can see the jackal
            setPlayerNameColor(Sidekick.sidekick, Sidekick.color);
            if (Jackal.jackal != null)
            {
                setPlayerNameColor(Jackal.jackal, Jackal.color);
            }
        }

        // No else if here, as the Impostors need the Spy name to be colored
        if (Spy.spy != null && localPlayer.Data.Role.IsImpostor)
        {
            setPlayerNameColor(Spy.spy, Spy.color);
        }
        if (Sidekick.sidekick != null && Sidekick.wasTeamRed && localPlayer.Data.Role.IsImpostor)
        {
            setPlayerNameColor(Sidekick.sidekick, Spy.color);
        }
        if (Jackal.jackal != null && Jackal.wasTeamRed && localPlayer.Data.Role.IsImpostor)
        {
            setPlayerNameColor(Jackal.jackal, Spy.color);
        }

        // Crewmate roles with no changes: Mini
        // Impostor roles with no changes: Morphling, Camouflager, Vampire, Godfather, Eraser, Janitor, Cleaner, Warlock, BountyHunter,  Witch and Mafioso
    }

    static void setNameTags()
    {
        // Mafia
        if (CachedPlayer.LocalPlayer != null && CachedPlayer.LocalPlayer.Data.Role.IsImpostor)
        {
            foreach (PlayerControl player in CachedPlayer.AllPlayers)
                if (Godfather.godfather != null && Godfather.godfather == player)
                    player.cosmetics.nameText.text = player.Data.PlayerName + "mafiaNameTextG".Translate();
                else if (Mafioso.mafioso != null && Mafioso.mafioso == player)
                    player.cosmetics.nameText.text = player.Data.PlayerName + "mafiaNameTextM".Translate();
                else if (Janitor.janitor != null && Janitor.janitor == player)
                    player.cosmetics.nameText.text = player.Data.PlayerName + "mafiaNameTextJ".Translate();
            if (MeetingHud.Instance != null)
                foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                    if (Godfather.godfather != null && Godfather.godfather.PlayerId == player.TargetPlayerId)
                        player.NameText.text = Godfather.godfather.Data.PlayerName + "mafiaNameTextG".Translate();
                    else if (Mafioso.mafioso != null && Mafioso.mafioso.PlayerId == player.TargetPlayerId)
                        player.NameText.text = Mafioso.mafioso.Data.PlayerName + "mafiaNameTextM".Translate();
                    else if (Janitor.janitor != null && Janitor.janitor.PlayerId == player.TargetPlayerId)
                        player.NameText.text = Janitor.janitor.Data.PlayerName + "mafiaNameTextJ".Translate();
        }

        // Lovers
        if (Lovers.lover1 != null && Lovers.lover2 != null && (Lovers.lover1 == CachedPlayer.LocalPlayer.PlayerControl || Lovers.lover2 == CachedPlayer.LocalPlayer.PlayerControl))
        {
            string suffix = cs(Lovers.color, " ♥");
            Lovers.lover1.cosmetics.nameText.text += suffix;
            Lovers.lover2.cosmetics.nameText.text += suffix;

            if (MeetingHud.Instance != null)
                foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                    if (Lovers.lover1.PlayerId == player.TargetPlayerId || Lovers.lover2.PlayerId == player.TargetPlayerId)
                        player.NameText.text += suffix;
        }

        // Lawyer or Prosecutor
        bool localIsLawyer = Lawyer.lawyer != null && Lawyer.target != null && Lawyer.lawyer == PlayerControl.LocalPlayer;
        bool localIsKnowingTarget = Lawyer.lawyer != null && !Lawyer.isProsecutor && Lawyer.target != null && Lawyer.targetKnows && Lawyer.target == PlayerControl.LocalPlayer;
        if (localIsLawyer || (localIsKnowingTarget && !Lawyer.lawyer.Data.IsDead))
        {
            //Color color = Lawyer.color;
            //PlayerControl target = Lawyer.target;
            string suffix = cs(Lawyer.color, " §");
            Lawyer.target.cosmetics.nameText.text += suffix;

            if (MeetingHud.Instance != null)
                foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                    if (player.TargetPlayerId == Lawyer.target.PlayerId)
                        player.NameText.text += suffix;
        }

        // Former Thief
        if (Thief.formerThief != null && (Thief.formerThief == CachedPlayer.LocalPlayer.PlayerControl || CachedPlayer.LocalPlayer.PlayerControl.Data.IsDead))
        {
            string suffix = cs(Thief.color, " $");
            Thief.formerThief.cosmetics.nameText.text += suffix;
            if (MeetingHud.Instance != null)
                foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                    if (player.TargetPlayerId == Thief.formerThief.PlayerId)
                        player.NameText.text += suffix;
        }

        // Display lighter / darker color for all alive players
        if (CachedPlayer.LocalPlayer != null && MeetingHud.Instance != null && TORMapOptions.showLighterDarker)
        {
            foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
            {
                var target = playerById(player.TargetPlayerId);
                if (target != null) player.NameText.text += $" ({(isLighterColor(target) ? "playerColorL".Translate() : "playerColorD".Translate())})";
            }
        }
        // Add medic shield info:
        if (MeetingHud.Instance != null && Medic.medic != null && Medic.shielded != null && Medic.shieldVisible(Medic.shielded))
        {
            foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                if (player.TargetPlayerId == Medic.shielded.PlayerId)
                {
                    player.NameText.text = Helpers.cs(Medic.color, "[") + player.NameText.text + Helpers.cs(Medic.color, "]");
                }
        }
    }

    static void updateShielded()
    {
        if (Medic.shielded == null) return;

        if (Medic.shielded.Data.IsDead || Medic.medic == null || Medic.medic.Data.IsDead)
        {
            Medic.shielded = null;
        }
    }

    static void timerUpdate()
    {
        var dt = Time.deltaTime;
        Hacker.hackerTimer -= dt;
        Trickster.lightsOutTimer -= dt;
        Tracker.corpsesTrackingTimer -= dt;
        Ninja.invisibleTimer -= dt;
        Jackal.swoopTimer -= dt;
        HideNSeek.timer -= dt;
        foreach (byte key in Deputy.handcuffedKnows.Keys)
            Deputy.handcuffedKnows[key] -= dt;
    }

    public static void miniUpdate()
    {
        if (Mini.mini == null || Camouflager.camouflageTimer > 0f || MushroomSabotageActive() || (Mini.mini == Morphling.morphling && Morphling.morphTimer > 0f) || (Mini.mini == Ninja.ninja && Ninja.isInvisble) || SurveillanceMinigamePatch.nightVisionIsActive || (Mini.mini == Jackal.jackal && Jackal.isInvisable) || isActiveCamoComms()) return;

        float growingProgress = Mini.growingProgress();
        float scale = (growingProgress * 0.35f) + 0.35f;
        string suffix = "";
        if (growingProgress != 1f)
            suffix = " <color=#FAD934FF>(" + Mathf.FloorToInt(growingProgress * 18) + ")</color>";
        if (!Mini.isGrowingUpInMeeting && MeetingHud.Instance != null && Mini.ageOnMeetingStart != 0 && !(Mini.ageOnMeetingStart >= 18))
            suffix = " <color=#FAD934FF>(" + Mini.ageOnMeetingStart + ")</color>";

        Mini.mini.cosmetics.nameText.text += suffix;
        if (MeetingHud.Instance != null)
        {
            foreach (PlayerVoteArea player in MeetingHud.Instance.playerStates)
                if (player.NameText != null && Mini.mini.PlayerId == player.TargetPlayerId)
                    player.NameText.text += suffix;
        }

        if (Morphling.morphling != null && Morphling.morphTarget == Mini.mini && Morphling.morphTimer > 0f)
            Morphling.morphling.cosmetics.nameText.text += suffix;
    }

    static void updateImpostorKillButton(HudManager __instance)
    {
        if (!CachedPlayer.LocalPlayer.Data.Role.IsImpostor) return;
        if (MeetingHud.Instance)
        {
            __instance.KillButton.Hide();
            return;
        }
        bool enabled = true;
        if (Vampire.vampire != null && Vampire.vampire == CachedPlayer.LocalPlayer.PlayerControl)
            enabled = false;
        else if (Mafioso.mafioso != null && Mafioso.mafioso == CachedPlayer.LocalPlayer.PlayerControl && Godfather.godfather != null && !Godfather.godfather.Data.IsDead)
            enabled = false;
        else if (Janitor.janitor != null && Janitor.janitor == CachedPlayer.LocalPlayer.PlayerControl)
            enabled = false;
        else if (Cultist.cultist != null && Cultist.cultist == CachedPlayer.LocalPlayer.PlayerControl && Cultist.needsFollower)
        {
            enabled = false;
        }

        if (enabled) __instance.KillButton.Show();
        else __instance.KillButton.Hide();

        if (Deputy.handcuffedKnows.ContainsKey(CachedPlayer.LocalPlayer.PlayerId) && Deputy.handcuffedKnows[CachedPlayer.LocalPlayer.PlayerId] > 0) __instance.KillButton.Hide();
    }

    static void updateReportButton(HudManager __instance)
    {
        if (GameOptionsManager.Instance.currentGameOptions.GameMode == GameModes.HideNSeek) return;
        if ((Deputy.handcuffedKnows.ContainsKey(CachedPlayer.LocalPlayer.PlayerId) && Deputy.handcuffedKnows[CachedPlayer.LocalPlayer.PlayerId] > 0) || MeetingHud.Instance) __instance.ReportButton.Hide();
        else if (!__instance.ReportButton.isActiveAndEnabled) __instance.ReportButton.Show();
    }

    static void updateVentButton(HudManager __instance)
    {
        if (GameOptionsManager.Instance.currentGameOptions.GameMode == GameModes.HideNSeek) return;
        if ((Deputy.handcuffedKnows.ContainsKey(CachedPlayer.LocalPlayer.PlayerId) && Deputy.handcuffedKnows[CachedPlayer.LocalPlayer.PlayerId] > 0) || MeetingHud.Instance) __instance.ImpostorVentButton.Hide();
        else if (CachedPlayer.LocalPlayer.PlayerControl.roleCanUseVents() && !__instance.ImpostorVentButton.isActiveAndEnabled) __instance.ImpostorVentButton.Show();

    }

    static void updateUseButton(HudManager __instance)
    {
        if (MeetingHud.Instance) __instance.UseButton.Hide();
    }

    static void updateSabotageButton(HudManager __instance)
    {
        if (MeetingHud.Instance || TORMapOptions.gameMode == CustomGamemodes.HideNSeek || TORMapOptions.gameMode == CustomGamemodes.PropHunt) __instance.SabotageButton.Hide();
        if (PlayerControl.LocalPlayer.Data.IsDead && CustomOptionHolder.deadImpsBlockSabotage.getBool()) __instance.SabotageButton.Hide();
    }

    static void updateMapButton(HudManager __instance)
    {
        if (Trapper.trapper == null || !(CachedPlayer.LocalPlayer.PlayerId == Trapper.trapper.PlayerId) || __instance == null || __instance.MapButton.HeldButtonSprite == null) return;
        __instance.MapButton.HeldButtonSprite.color = Trapper.playersOnMap.Any() ? Trapper.color : Color.white;
    }

    static void Postfix(HudManager __instance)
    {
        var player = PlayerControl.LocalPlayer;
        if (player == null) return;
        //壁抜け
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            if ((AmongUsClient.Instance.GameState != InnerNet.InnerNetClient.GameStates.Started || AmongUsClient.Instance.NetworkMode == NetworkModes.FreePlay)
                && player.CanMove)
            {
                player.Collider.offset = new Vector2(0f, 127f);
            }
        }
        //壁抜け解除
        if (player.Collider.offset.y == 127f)
        {
            if (!Input.GetKey(KeyCode.LeftControl) || AmongUsClient.Instance.IsGameStarted)
            {
                player.Collider.offset = new Vector2(0f, -0.3636f);
            }
        }
        if (AmongUsClient.Instance.GameState != InnerNet.InnerNetClient.GameStates.Started || GameOptionsManager.Instance.currentGameOptions.GameMode == GameModes.HideNSeek) return;

        EventUtility.Update();

        CustomButton.HudUpdate();
        resetNameTagsAndColors();
        setNameColors();
        updateShielded();
        setNameTags();

        // Impostors
        updateImpostorKillButton(__instance);
        // Timer updates
        timerUpdate();
        // Mini
        miniUpdate();

        // Deputy Sabotage, Use and Vent Button Disabling
        updateReportButton(__instance);
        updateVentButton(__instance);
        // Meeting hide buttons if needed (used for the map usage, because closing the map would show buttons)
        updateSabotageButton(__instance);
        updateUseButton(__instance);
        updateBlindReport();
        updateMapButton(__instance);
        if (!MeetingHud.Instance) __instance.AbilityButton?.Update();

        // Fix dead player's pets being visible by just always updating whether the pet should be visible at all.
        foreach (PlayerControl target in CachedPlayer.AllPlayers)
        {
            var pet = target.GetPet();
            if (pet != null)
            {
                pet.Visible = ((PlayerControl.LocalPlayer.Data.IsDead && target.Data.IsDead) || !target.Data.IsDead) && !target.inVent;
            }
        }
    }
}
