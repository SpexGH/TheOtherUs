using UnityEngine;

namespace TheOtherRoles.Roles.Impostor;

public class Blackmailer : RoleBase
{
    public bool alreadyShook = false;
    private Sprite blackmailButtonSprite;
    public PlayerControl blackmailed;
    public Color blackmailedColor = Palette.White;
    public PlayerControl blackmailer;
    public Color color = Palette.ImpostorRed;
    public float cooldown = 30f;
    public PlayerControl currentTarget;
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