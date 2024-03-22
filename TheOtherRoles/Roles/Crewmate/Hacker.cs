using UnityEngine;

namespace TheOtherRoles.Roles.Crewmate;

[RegisterRole]
public class Hacker : RoleBase
{
    private Sprite adminSprite;

    private Sprite buttonSprite;
    public bool cantMove = true;
    public int chargesAdminTable = 1;
    public int chargesVitals = 1;
    public Color color = new Color32(117, 250, 76, byte.MaxValue);

    public float cooldown = 30f;
    public Minigame doorLog;
    public float duration = 10f;
    public PlayerControl hacker;
    public float hackerTimer;
    private Sprite logSprite;
    public bool onlyColorType;
    public int rechargedTasks = 2;
    public int rechargeTasksNumber = 2;
    public float toolsNumber = 5f;
    public Minigame vitals;
    private Sprite vitalsSprite;

    public Sprite getButtonSprite()
    {
        if (buttonSprite) return buttonSprite;
        buttonSprite = Helpers.loadSpriteFromResources("TheOtherRoles.Resources.HackerButton.png", 115f);
        return buttonSprite;
    }

    public Sprite getVitalsSprite()
    {
        if (vitalsSprite) return vitalsSprite;
        vitalsSprite = FastDestroyableSingleton<HudManager>.Instance.UseButton.fastUseSettings[ImageNames.VitalsButton]
            .Image;
        return vitalsSprite;
    }

    public Sprite getLogSprite()
    {
        if (logSprite) return logSprite;
        logSprite = FastDestroyableSingleton<HudManager>.Instance.UseButton.fastUseSettings[ImageNames.DoorLogsButton]
            .Image;
        return logSprite;
    }

    public Sprite getAdminSprite()
    {
        var mapId = GameOptionsManager.Instance.currentNormalGameOptions.MapId;
        var button =
            FastDestroyableSingleton<HudManager>.Instance.UseButton
                .fastUseSettings[ImageNames.PolusAdminButton]; // Polus
        if (Helpers.isSkeld() || mapId == 3)
            button = FastDestroyableSingleton<HudManager>.Instance.UseButton
                .fastUseSettings[ImageNames.AdminMapButton]; // Skeld || Dleks
        else if (Helpers.isMira())
            button = FastDestroyableSingleton<HudManager>.Instance.UseButton
                .fastUseSettings[ImageNames.MIRAAdminButton]; // Mira HQ
        else if (Helpers.isAirship())
            button = FastDestroyableSingleton<HudManager>.Instance.UseButton.fastUseSettings[
                ImageNames.AirshipAdminButton]; // Airship
        else if (Helpers.isFungle())
            button = FastDestroyableSingleton<HudManager>.Instance.UseButton
                .fastUseSettings[ImageNames.AdminMapButton]; // Hacker can Access the Admin panel on Fungle
        adminSprite = button.Image;
        return adminSprite;
    }

    public void clearAndReload()
    {
        hacker = null;
        vitals = null;
        doorLog = null;
        hackerTimer = 0f;
        adminSprite = null;
        cooldown = CustomOptionHolder.hackerCooldown.getFloat();
        duration = CustomOptionHolder.hackerHackeringDuration.getFloat();
        onlyColorType = CustomOptionHolder.hackerOnlyColorType.getBool();
        toolsNumber = CustomOptionHolder.hackerToolsNumber.getFloat();
        rechargeTasksNumber = Mathf.RoundToInt(CustomOptionHolder.hackerRechargeTasksNumber.getFloat());
        rechargedTasks = Mathf.RoundToInt(CustomOptionHolder.hackerRechargeTasksNumber.getFloat());
        chargesVitals = Mathf.RoundToInt(CustomOptionHolder.hackerToolsNumber.getFloat()) / 2;
        chargesAdminTable = Mathf.RoundToInt(CustomOptionHolder.hackerToolsNumber.getFloat()) / 2;
        cantMove = CustomOptionHolder.hackerNoMove.getBool();
    }
}