using System.Collections.Generic;
using Hazel;
using UnityEngine;

namespace TheOtherRoles.Roles.Crewmate;

[RegisterRole]
public class Deputy : RoleBase
{
    private Sprite buttonSprite;
    public Color color = Sheriff.color;

    public PlayerControl currentTarget;
    public PlayerControl deputy;
    public float handcuffCooldown;
    public float handcuffDuration;
    public Dictionary<byte, float> handcuffedKnows = new();
    public List<byte> handcuffedPlayers = new();
    private Sprite handcuffedSprite;
    public bool keepsHandcuffsOnPromotion;
    public bool knowsSheriff;
    public int promotesToSheriff; // No: 0, Immediately: 1, After Meeting: 2
    public float remainingHandcuffs;

    public Sprite getButtonSprite()
    {
        if (buttonSprite) return buttonSprite;
        buttonSprite = Helpers.loadSpriteFromResources("TheOtherRoles.Resources.DeputyHandcuffButton.png", 115f);
        return buttonSprite;
    }

    public Sprite getHandcuffedButtonSprite()
    {
        if (handcuffedSprite) return handcuffedSprite;
        handcuffedSprite = Helpers.loadSpriteFromResources("TheOtherRoles.Resources.DeputyHandcuffed.png", 115f);
        return handcuffedSprite;
    }

    // Can be used to enable / disable the handcuff effect on the target's buttons
    public void setHandcuffedKnows(bool active = true, byte playerId = byte.MaxValue)
    {
        if (playerId == byte.MaxValue)
            playerId = CachedPlayer.LocalPlayer.PlayerId;

        if (active && playerId == CachedPlayer.LocalPlayer.PlayerId)
        {
            var writer = AmongUsClient.Instance.StartRpcImmediately(CachedPlayer.LocalPlayer.PlayerControl.NetId,
                (byte)CustomRPC.ShareGhostInfo, SendOption.Reliable);
            writer.Write(CachedPlayer.LocalPlayer.PlayerId);
            writer.Write((byte)RPCProcedure.GhostInfoTypes.HandcuffNoticed);
            AmongUsClient.Instance.FinishRpcImmediately(writer);
        }

        if (active)
        {
            handcuffedKnows.Add(playerId, handcuffDuration);
            handcuffedPlayers.RemoveAll(x => x == playerId);
        }

        if (playerId == CachedPlayer.LocalPlayer.PlayerId)
        {
            HudManagerStartPatch.setAllButtonsHandcuffedStatus(active);
            SoundEffectsManager.play("deputyHandcuff");
        }
    }

    public void clearAndReload()
    {
        deputy = null;
        currentTarget = null;
        handcuffedPlayers = new List<byte>();
        handcuffedKnows = new Dictionary<byte, float>();
        HudManagerStartPatch.setAllButtonsHandcuffedStatus(false, true);
        promotesToSheriff = CustomOptionHolder.deputyGetsPromoted.getSelection();
        remainingHandcuffs = CustomOptionHolder.deputyNumberOfHandcuffs.getFloat();
        handcuffCooldown = CustomOptionHolder.deputyHandcuffCooldown.getFloat();
        keepsHandcuffsOnPromotion = CustomOptionHolder.deputyKeepsHandcuffs.getBool();
        handcuffDuration = CustomOptionHolder.deputyHandcuffDuration.getFloat();
        knowsSheriff = CustomOptionHolder.deputyKnowsSheriff.getBool();
    }
}