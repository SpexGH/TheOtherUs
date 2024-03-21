using System;
using System.Collections.Generic;
using UnityEngine;

namespace TheOtherRoles;

public class Miner {
    public readonly static List<Vent> Vents = new List<Vent>();
    public static PlayerControl miner;
    public KillButton _mineButton;
    public static DateTime LastMined;
    public static Sprite buttonSprite;

    public static float cooldown = 30f;
    public static Color color = Palette.ImpostorRed;

    public bool CanPlace { get; set; }
    public static Vector2 VentSize { get; set; }

    public static void clearAndReload() {
        miner = null;
        cooldown = CustomOptionHolder.minerCooldown.getFloat();
    }
        
    public static Sprite getMineButtonSprite() {
        if (buttonSprite) return buttonSprite;
        buttonSprite = Helpers.loadSpriteFromResources("TheOtherRoles.Resources.Mine.png", 115f);
        return buttonSprite;
    }
}