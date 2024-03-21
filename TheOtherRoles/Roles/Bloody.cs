using System.Collections.Generic;

namespace TheOtherRoles;

public static class Bloody {
    public static List<PlayerControl> bloody = new List<PlayerControl>();
    public static Dictionary<byte, float> active = new Dictionary<byte, float>();
    public static Dictionary<byte, byte> bloodyKillerMap = new Dictionary<byte, byte>();

    public static float duration = 5f;

    public static void clearAndReload() {
        bloody = new List<PlayerControl>();
        active = new Dictionary<byte, float>();
        bloodyKillerMap = new Dictionary<byte, byte>();
        duration = CustomOptionHolder.modifierBloodyDuration.getFloat();
    }
}