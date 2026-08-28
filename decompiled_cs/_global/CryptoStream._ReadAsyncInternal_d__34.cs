// Namespace: 
[CompilerGeneratedAttribute] // RVA: 0x4DB6E8 Offset: 0x4DB6E8 VA: 0x4DB6E8
private struct CryptoStream.<ReadAsyncInternal>d__34 : IAsyncStateMachine // TypeDefIndex: 929
{
	// Fields
	public int <>1__state; // 0x0
	public AsyncTaskMethodBuilder<int> <>t__builder; // 0x4
	public CryptoStream <>4__this; // 0x10
	public int count; // 0x14
	public int offset; // 0x18
	public byte[] buffer; // 0x1C
	public CancellationToken cancellationToken; // 0x20
	private byte[] <tempInputBuffer>5__1; // 0x24
	private int <currentOutputIndex>5__2; // 0x28
	private int <bytesToDeliver>5__3; // 0x2C
	private SemaphoreSlim <sem>5__4; // 0x30
	private CryptoStream.HopToThreadPoolAwaitable <>u__1; // 0x34
	private ConfiguredTaskAwaitable.ConfiguredTaskAwaiter <>u__2; // 0x38
	private int <>7__wrap1; // 0x40
	private ConfiguredTaskAwaitable.ConfiguredTaskAwaiter<int> <>u__3; // 0x44

	// Methods

	// RVA: 0x769B0C Offset: 0x769B0C VA: 0x769B0C Slot: 4
	private void MoveNext() { }

	[DebuggerHiddenAttribute] // RVA: 0x4E3D80 Offset: 0x4E3D80 VA: 0x4E3D80
	// RVA: 0x769B14 Offset: 0x769B14 VA: 0x769B14 Slot: 5
	private void SetStateMachine(IAsyncStateMachine stateMachine) { }
}
