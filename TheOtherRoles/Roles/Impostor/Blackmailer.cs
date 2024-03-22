using UnityEngine;

namespace TheOtherRoles.Roles.Impostor;

public class Blackmailer : RoleBase
{
    public PlayerControl blackmailer;
    public Color color = Palette.ImpostorRed;
    public Color blackmailedColor = Palette.White;

    public bool alreadyShook = false;
    public PlayerControl blackmailed;
    public PlayerControl currentTarget;
    public float cooldown = 30f;
    private Sprite blackmailButtonSprite;
    private Sprite overlaySprite;

    public Sprite getBlackmailOverlaySprite()
    {
        if (overlaySprite) return overlaySprite;
        overlaySprite = Helpers.loadSpriteFromResources("TheOtherRoles.Resources.BlackmailerOverlay.png", 100f);
        return overlaySprite;
    }

    public Sprite getBlackmailLetterSprite()
    {
        if (overlaySprite) return overlaySprite;
        overlaySprite = Helpers.loadSpriteFromResources("TheOtherRoles.Resources.BlackmailerLetter.png", 115f);
        return overlaySprite;
    }

    public Sprite getBlackmailButtonSprite()
    {
        if (blackmailButtonSprite) return blackmailButtonSprite;
        blackmailButtonSprite =
            Helpers.loadSpriteFromResources("TheOtherRoles.Resources.BlackmailerBlackmailButton.png", 115f);
        return blackmailButtonSprite;
    }

    public void clearAndReload()
    {
        blackmailer = null;
        currentTarget = null;
        blackmailed = null;
        cooldown = CustomOptionHolder.blackmailerCooldown.getFloat();
    }
}