using Hazel;

namespace TheOtherRoles.Helper;

internal class FastRpcWriter(MessageWriter writer)
{
    private readonly RPCSendMode _rpcSendMode;
    private byte CallId;

    private int msgCount;

    private SendOption Option;

    private int SendTargetId;

    private uint targetObjectId;

    private FastRpcWriter(SendOption option, RPCSendMode mode = RPCSendMode.SendToAll, int TargetId = -1,
        uint ObjectId = 255) : this(MessageWriter.Get(option))
    {
        Option = option;
        _rpcSendMode = mode;
        SetTargetId(TargetId);
        SetTargetObjectId(ObjectId);
    }

    private static FastRpcWriter StartNew(SendOption option = SendOption.Reliable,
        RPCSendMode mode = RPCSendMode.SendToAll, int TargetId = -1, uint targetObjectId = 255)
    {
        return new FastRpcWriter(option, mode, TargetId, targetObjectId);
    }

    internal static FastRpcWriter StartNewRpcWriter(CustomRPC rpc, SendOption option = SendOption.Reliable,
        RPCSendMode mode = RPCSendMode.SendToAll, int TargetId = -1, uint targetObjectId = 255)
    {
        var writer = StartNew(option, mode, TargetId, targetObjectId);
        writer.SetRpcCallId(rpc);

        if (mode == RPCSendMode.SendToAll)
            writer.StartDataAllMessage();

        if (mode == RPCSendMode.SendToPlayer)
            writer.StartDataToPlayerMessage();

        writer.StartRPCMessage();
        return writer;
    }

    public FastRpcWriter StartSendAllRPCWriter()
    {
        Clear();
        writer = MessageWriter.Get(Option);
        StartDataAllMessage();
        StartRPCMessage();
        return this;
    }

    public FastRpcWriter StartSendToPlayerRPCWriter()
    {
        Clear();
        writer = MessageWriter.Get(Option);
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

    public FastRpcWriter Write(params object[] objects)
    {
        if (objects == null) return this;

        foreach (var obj in objects)
        {
            if (obj is byte _byte)
                writer.Write(_byte);

            if (obj is string _string)
                writer.Write(_string);

            if (obj is float _float)
                writer.Write(_float);

            if (obj is int _int)
                writer.Write(_int);

            if (obj is bool _bool)
                writer.Write(_bool);
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

internal enum RPCSendMode
{
    SendToAll = 5,
    SendToPlayer = 6
}