using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Hazel;
using InnerNet;
using TheOtherRoles.Patches;
using TheOtherRoles.Players;

namespace TheOtherRoles.Helper;

public static class HandshakeHelper
{
    public static readonly Dictionary<int, PlayerVersion> playerVersions = new();
    
    public enum ShareMode
    {
        Guid = 0,
        Again = 1
    }

    public static readonly Dictionary<int, AgainInfo> PlayerAgainInfo = new();

    public static void ShareGameMode()
    {
        FastRpcWriter.StartNewRpcWriter(CustomRPC.ShareGamemode)
            .Write((byte)TORMapOptions.gameMode)
            .RPCSend();
    }

    #nullable enable
    public static bool GetVersionHandshake(out ClientData[]? players, out string message)
    {
        players = null;
        message = string.Empty;
#if DEBUG
        return false;
#endif
        var versionMismatch = false;
        foreach (var client in AmongUsClient.Instance.allClients.ToArray().Where(data => data.Id != AmongUsClient.Instance.ClientId)) {
                if (client.Character == null) continue;
                var dummyComponent = client.Character.GetComponent<DummyBehaviour>();
                if (dummyComponent != null && dummyComponent.enabled)
                    continue;
                
                if (!playerVersions.ContainsKey(client.Id))  
                {
                    againSend(client.Id, ShareMode.Again);
                    versionMismatch = true;
                    message += $"<color=#FF0000FF>{client.Character.Data.PlayerName} has a different or no version of The Other Us\n</color>";
                } 
                else 
                {
                    var PV = playerVersions[client.Id];
                    var diff = Main.Version.CompareTo(PV.version);
                    if (PV.guid == null)
                    {
                        againSend(client.Id, ShareMode.Guid);
                        continue;
                    }
                    
                    switch (diff)
                    {
                        case > 0:
                            versionMismatch = false;
                            message += $"<color=#FF0000FF>{client.Character.Data.PlayerName} has an older version of The Other Us (v{playerVersions[client.Id].version.ToString()})\n</color>";
                            break;
                        case < 0:
                            versionMismatch = false;
                            message += $"<color=#FF0000FF>{client.Character.Data.PlayerName} has a newer version of The Other Us (v{playerVersions[client.Id].version.ToString()})\n</color>";
                            break;
                        default:
                        {
                            versionMismatch = PV.GuidMatches();
                            message += $"<color=#FF0000FF>{client.Character.Data.PlayerName} has a modified version of TOU v{playerVersions[client.Id].version.ToString()} <size=30%>({PV.guid.ToString()})</size>\n</color>";
                            break;
                        }
                    }
                }
        }
        return versionMismatch;
    }
    #nullable disable
    
    public static void shareGameVersion()
    {
        var writer = FastRpcWriter.StartNewRpcWriter(CustomRPC.VersionHandshake)
            .WritePacked(AmongUsClient.Instance.ClientId)
            .Write(Main.Version.Major)
            .Write(Main.Version.Minor)
            .Write(Main.Version.Build)
            .Write(AmongUsClient.Instance.AmHost ? GameStartManagerPatch.timer : -1f)
            .Write((byte)(Main.Version.Revision < 0 ? 0xFF : Main.Version.Revision));
        writer.RPCSend();
    }

    public static void versionHandshake(int major, int minor, int build, int revision, int clientId)
    {
        var ver = revision < 0 ? new Version(major, minor, build) : new Version(major, minor, build, revision);
        playerVersions[clientId] = new PlayerVersion(ver)
        {
            PlayerId = clientId
        };
    }

    public static void VersionHandshakeEx(MessageReader reader)
    {
        var clientId = reader.ReadPackedInt32();
        switch ((ShareMode)reader.ReadByte())
        {
            case ShareMode.Guid:
                ShareGuid();
                break;

            case ShareMode.Again:
                Again();
                break;
        }

        return;

        void ShareGuid()
        {
            var length = reader.ReadInt32();
            var bytes = reader.ReadBytes(length);
            playerVersions[clientId].guid = new Guid(bytes);
        }

        void Again()
        {
            var mode = (ShareMode)reader.ReadByte();

            switch (mode)
            {
                case ShareMode.Again:
                    shareGameVersion();
                    break;
                case ShareMode.Guid:
                    shareGameGUID();
                    break;
            }
        }
    }

    public static void shareGameGUID()
    {
        var clientId = AmongUsClient.Instance.ClientId;
        var bytes = Assembly.GetExecutingAssembly().ManifestModule.ModuleVersionId.ToByteArray();
        playerVersions[clientId].guid = new Guid(bytes);

        var writer = FastRpcWriter.StartNewRpcWriter(CustomRPC.VersionHandshakeEx)
            .WritePacked(AmongUsClient.Instance.ClientId)
            .Write((byte)ShareMode.Guid)
            .Write(bytes.Length)
            .Write(bytes);
        writer.RPCSend();
    }

    public static void againSend(int playerId, ShareMode mode)
    {
        if (PlayerAgainInfo.TryGetValue(playerId, out var againInfo))
        {
            againInfo.Update(mode);
        }
        else
        {
            var info = PlayerAgainInfo[playerId] = new AgainInfo { playerId = playerId };
            info.Start(mode);
        }
    }
}

public class AgainInfo
{
    public int playerId = -1;
    public int MaxCount { get; set; } = 5;
    public int Count { get; set; }
    public int Time { get; set; }

    public int MaxTime { get; set; } = 2;

    public void Start(HandshakeHelper.ShareMode mode)
    {
        Send(mode);
        Time = MaxTime;
    }

    public void Update(HandshakeHelper.ShareMode mode)
    {
        if (Count == MaxCount) return;
        if (Time < 0)
        {
            Send(mode);
            Time = MaxTime;
            Count++;
        }
        else
        {
            Time--;
        }
    }

    public void Send(HandshakeHelper.ShareMode mode)
    {
            
        Info($"again send mode:{mode} id:{playerId}");

        if (AmongUsClient.Instance == null || CachedPlayer.LocalPlayer.PlayerControl == null) return;
        
        var writer = FastRpcWriter.StartNewRpcWriter(CustomRPC.VersionHandshakeEx, mode: RPCSendMode.SendToPlayer)
            .WritePacked(AmongUsClient.Instance.ClientId)
            .Write((byte)HandshakeHelper.ShareMode.Again)
            .Write((byte)mode);
        writer.RPCSend();
    }
}

public class PlayerVersion(Version version)
{
    public Version version { get; private set; } = version;
    
    public int PlayerId { get; internal set; }
    public Guid? guid { get; internal set; }

    public bool GuidMatches() 
    {
        return Assembly.GetExecutingAssembly().ManifestModule.ModuleVersionId.Equals(this.guid);
    }
}