// Namespace: 
private class TSPacketLink.Core // TypeDefIndex: 8809
{
	// Fields
	private readonly AsyncCallback mSendCallBack; // 0x8
	private ChaCha20NoGC mCipher; // 0xC
	private DHExchangeInstance mDHInstance; // 0x10
	private Nullable<bool> mIsSecretConnection; // 0x14
	private int mReceivedPublickeyLength; // 0x18
	private byte[] mServerPublicKey; // 0x1C
	private TSPacketLink.Core.InteriorState mState; // 0x20
	private TSPacketLink m_link; // 0x24
	private object m_lock; // 0x28
	private Socket m_socket; // 0x2C
	private byte[] m_buffer; // 0x30
	private MemoryInputStream m_inputStream; // 0x34
	private InputProgram m_inputProgram; // 0x38
	private int m_inputState; // 0x3C
	private IInputable m_inputObject; // 0x40
	private PacketFactory.PacketInfo m_packetInfo; // 0x44

	// Methods

	// RVA: 0x10DB8F0 Offset: 0x10DB8F0 VA: 0x10DB8F0
	public void .ctor(TSPacketLink link, object lck) { }

	// RVA: 0x10DBA4C Offset: 0x10DBA4C VA: 0x10DBA4C
	public void connect(string host, int port) { }

	// RVA: 0x10DBF0C Offset: 0x10DBF0C VA: 0x10DBF0C
	public void connect(EndPoint end_point) { }

	// RVA: 0x10DD134 Offset: 0x10DD134 VA: 0x10DD134
	public void send(IBuffer buffer, int length) { }

	// RVA: 0x10DC134 Offset: 0x10DC134 VA: 0x10DC134
	public void close() { }

	// RVA: 0x10DD398 Offset: 0x10DD398 VA: 0x10DD398
	private void _onConnectCallback(IAsyncResult ar) { }

	// RVA: 0x10DD81C Offset: 0x10DD81C VA: 0x10DD81C
	private void _onReceiveCallback(IAsyncResult ar) { }

	// RVA: 0x10DDB70 Offset: 0x10DDB70 VA: 0x10DDB70
	private void OnReceiveSecretFlag(int length) { }

	// RVA: 0x10DDCD0 Offset: 0x10DDCD0 VA: 0x10DDCD0
	private void OnReceiveServerPublicKey(int offset, int length) { }

	// RVA: 0x10DDE54 Offset: 0x10DDE54 VA: 0x10DDE54
	private void OnCalSecretKeyAndSendPublicKey() { }

	// RVA: 0x10DE57C Offset: 0x10DE57C VA: 0x10DE57C
	private void SendPublicKey() { }

	// RVA: 0x10DE310 Offset: 0x10DE310 VA: 0x10DE310
	private void StartReceive() { }

	// RVA: 0x10DE25C Offset: 0x10DE25C VA: 0x10DE25C
	private void OnConnected() { }

	// RVA: 0x10DDFA4 Offset: 0x10DDFA4 VA: 0x10DDFA4
	private void OnRunning(int length) { }

	// RVA: 0x10DECEC Offset: 0x10DECEC VA: 0x10DECEC
	private void _onSendCallback(IAsyncResult ar) { }

	// RVA: 0x10DE6D8 Offset: 0x10DE6D8 VA: 0x10DE6D8
	private TSPacketLink.Core.InputState _runInputProgram() { }

	[CompilerGeneratedAttribute] // RVA: 0x65C320 Offset: 0x65C320 VA: 0x65C320
	// RVA: 0x10DF0C0 Offset: 0x10DF0C0 VA: 0x10DF0C0
	private void <SendPublicKey>b__18_0(object sender, SocketAsyncEventArgs e) { }
}
