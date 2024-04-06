using System.Linq;
using Hazel;
using TheOtherRoles.Players;
using UnityEngine;

namespace TheOtherRoles.Helper;

internal class FastRpcWriter(MessageWriter writer)
{
     private byte CallId;

    private int msgCount;

    private SendOption Option;

    private RPCSendMode _rpcSendMode;

    private int SendTargetId;

    private uint targetObjectId;
    
    private FastRpcWriter(SendOption option, RPCSendMode mode = RPCSendMode.SendToAll, int TargetId = -1, uint ObjectId = 255) : this(MessageWriter.Get(option))
    {
        Option = option;
        _rpcSendMode = mode;
        SetTargetId(TargetId);
        SetTargetObjectId(ObjectId);
    }

    private static FastRpcWriter StartNew(SendOption option = SendOption.Reliable, RPCSendMode mode = RPCSendMode.SendToAll, int TargetId = -1, uint targetObjectId = 255)
    {
        var writer = new FastRpcWriter(option, mode, TargetId, targetObjectId);
        writer.CreateWriter();
        return writer;
    }
    
    internal static FastRpcWriter StartNewRpcWriter(CustomRPC rpc, SendOption option = SendOption.Reliable, RPCSendMode mode = RPCSendMode.SendToAll, int TargetId = -1, uint targetObjectId = 255)
    {
        var writer = StartNew(option, mode, TargetId, targetObjectId);
        writer.SetRpcCallId(rpc);

        writer.CreateWriter();
        
        if (mode == RPCSendMode.SendToAll)
            writer.StartDataAllMessage();

        if (mode == RPCSendMode.SendToPlayer)
            writer.StartDataToPlayerMessage();
        
        writer.StartRPCMessage();
        return writer;
    }

    public FastRpcWriter CreateWriter()
    {
        Clear();
        writer = MessageWriter.Get(Option);
        return this;
    }

    public FastRpcWriter StartSendAllRPCWriter()
    {
        CreateWriter();
        StartDataAllMessage();
        StartRPCMessage();
        return this;
    }

    public FastRpcWriter StartSendToPlayerRPCWriter()
    {
        CreateWriter();
        StartDataToPlayerMessage();
        StartRPCMessage();
        return this;
    }

    public FastRpcWriter SetSendOption(SendOption option)
    {
        Option = option;
        return this;
    }

    public FastRpcWriter SetTargetObjectId(uint id)
    {
        if (targetObjectId == 255)
        {
            targetObjectId = CachedPlayer.LocalPlayer.PlayerControl.NetId;
            return this;
        }

        targetObjectId = id;
        return this;
    }
    
    public FastRpcWriter SetRpcCallId(CustomRPC id)
    {
        CallId = (byte)id;
        return this;
    }

    public FastRpcWriter SetRpcCallId(byte id)
    {
        CallId = id;
        return this;
    }

    public FastRpcWriter SetTargetId(int id)
    {
        if (id == -1)
            return this;
        
        SendTargetId = id;
        return this;
    }

    public void Clear()
    {
        if (writer == null) return;
        Recycle();
        writer = null;
    }

    public FastRpcWriter Write(bool value)
    {
        writer?.Write(value);
        return this;
    }

    public FastRpcWriter Write(int value)
    {
        writer?.Write(value);
        return this;
    }

    public FastRpcWriter Write(float value)
    {
        writer?.Write(value);
        return this;
    }

    public FastRpcWriter Write(string value)
    {
        writer?.Write(value);
        return this;
    }

    public FastRpcWriter Write(byte value)
    {
        writer?.Write(value);
        return this;
    }
    
    public FastRpcWriter Write(byte[] value)
    {
        writer?.Write(value);
        return this;
    }
    
    public FastRpcWriter Write(Vector2 value)
    {
        writer?.Write(value.x);
        writer?.Write(value.y);
        return this;
    }
    
    public FastRpcWriter Write(Vector3 value)
    {
        writer?.Write(value.x);
        writer?.Write(value.y);
        writer?.Write(value.z);
        return this;
    }

    public FastRpcWriter Write(Rect value)
    {
        writer?.Write(value.x);
        writer?.Write(value.y);
        writer?.Write(value.width);
        writer?.Write(value.height);
        return this;
    }

    public FastRpcWriter Write(params object[] objects)
    {
        if (objects == null) return this;
        
        foreach (var obj in objects)
        {
            switch (obj)
            {
                case byte _byte:
                    writer.Write(_byte);
                    break;
                case string _string:
                    writer.Write(_string);
                    break;
                case float _float:
                    writer.Write(_float);
                    break;
                case int _int:
                    writer.Write(_int);
                    break;
                case bool _bool:
                    writer.Write(_bool);
                    break;
                case byte[] _bytes:
                    writer.Write(_bytes);
                    break;
            }
        }
        return this;
    }

    public FastRpcWriter WritePacked(int value)
    {
        writer?.WritePacked(value);
        return this;
    }

    public FastRpcWriter WritePacked(uint value)
    {
        writer?.WritePacked(value);
        return this;
    }

    private void StartDataAllMessage()
    {
        StartMessage((byte)_rpcSendMode);
        Write(AmongUsClient.Instance.GameId);
    }

    private void StartDataToPlayerMessage()
    {
        StartMessage((byte)_rpcSendMode);
        Write(AmongUsClient.Instance.GameId);
        WritePacked(SendTargetId);
    }

    private void StartRPCMessage()
    {
        StartMessage(2);
        WritePacked(targetObjectId);
        Write(CallId);
    }

    public FastRpcWriter StartMessage(byte flag)
    {
        writer?.StartMessage(flag);
        msgCount++;
        return this;
    }

    public FastRpcWriter EndMessage()
    {
        writer?.EndMessage();
        msgCount--;
        return this;
    }

    public void EndAllMessage()
    {
        while (msgCount > 0) 
            EndMessage();
    }

    public void Recycle()
    {
        writer?.Recycle();
    }

    public void RPCSend()
    {
        EndAllMessage();
        AmongUsClient.Instance.SendOrDisconnect(writer);
        Recycle();
    }
}

public static class FastRPCExtension
{
    public static Vector2 ReadVector2(this MessageReader reader)
    {
        var x = reader.ReadSingle();
        var y = reader.ReadSingle();
        return new Vector2(x, y);
    }
    
    public static Vector3 ReadVector3(this MessageReader reader)
    {
        var x = reader.ReadSingle();
        var y = reader.ReadSingle();
        var z = reader.ReadSingle();
        return new Vector3(x, y, z);
    }

    public static Rect ReadRect(this MessageReader reader)
    {
        var x = reader.ReadSingle();
        var y = reader.ReadSingle();
        var width = reader.ReadSingle();
        var height = reader.ReadSingle();
        return new Rect(x, y, width, height);
    }
}

internal enum RPCSendMode
{
    SendToAll = 5,
    SendToPlayer = 6
}