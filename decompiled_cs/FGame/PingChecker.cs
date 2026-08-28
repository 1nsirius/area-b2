namespace FGame
{

// Namespace: FGame
public class PingChecker : IDisposable // TypeDefIndex: 9891
{
	// Fields
	private static readonly int CheckCount; // 0x0
	private string mAdderss; // 0x8
	private uint mBattleZoneId; // 0xC
	private float mEndTime; // 0x10
	private uint mLinkId; // 0x14
	private float mPingSum; // 0x18
	private int mRecvCnt; // 0x1C
	private int mSendCnt; // 0x20
	private PingChecker.State mState; // 0x24
	private float mTimeout; // 0x28

	// Methods

	// RVA: 0xF60168 Offset: 0xF60168 VA: 0xF60168 Slot: 4
	public void Dispose() { }

	// RVA: 0xF602A8 Offset: 0xF602A8 VA: 0xF602A8
	public bool IsDone() { }

	// RVA: 0xF602BC Offset: 0xF602BC VA: 0xF602BC
	public PingChecker Init(uint battleZoneId, string address, float timeout) { }

	// RVA: 0xF602CC Offset: 0xF602CC VA: 0xF602CC
	public void Start() { }

	// RVA: 0xF60EEC Offset: 0xF60EEC VA: 0xF60EEC
	public bool OnTick() { }

	// RVA: 0xF60FC0 Offset: 0xF60FC0 VA: 0xF60FC0
	private bool CheckTimeout() { }

	// RVA: 0xF60BF4 Offset: 0xF60BF4 VA: 0xF60BF4
	private void StartConnect(INetworkService netserver, string ip, int port) { }

	// RVA: 0xF60640 Offset: 0xF60640 VA: 0xF60640
	private bool TryParseAddress(out string ip, out int port) { }

	[PacketHandlerAttribute] // RVA: 0x646DA0 Offset: 0x646DA0 VA: 0x646DA0
	// RVA: 0xF612E4 Offset: 0xF612E4 VA: 0xF612E4
	private void HandleOnRspPing(object sender, RspPing rsp) { }

	// RVA: 0xF618B0 Offset: 0xF618B0 VA: 0xF618B0
	private void HandleOnConnect() { }

	// RVA: 0xF618E0 Offset: 0xF618E0 VA: 0xF618E0
	private void HandleOnError(int error) { }

	// RVA: 0xF61BB8 Offset: 0xF61BB8 VA: 0xF61BB8
	private void HandleOnDisconnect() { }

	// RVA: 0xF6112C Offset: 0xF6112C VA: 0xF6112C
	private void SendPingReq() { }

	// RVA: 0xF61C80 Offset: 0xF61C80 VA: 0xF61C80
	public void .ctor() { }

	// RVA: 0xF61C88 Offset: 0xF61C88 VA: 0xF61C88
	private static void .cctor() { }
}

} // namespace FGame
