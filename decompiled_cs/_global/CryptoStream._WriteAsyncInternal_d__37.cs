// Namespace: 
[CompilerGeneratedAttribute] // RVA: 0x4DB6F8 Offset: 0x4DB6F8 VA: 0x4DB6F8
private struct CryptoStream.<WriteAsyncInternal>d__37 : IAsyncStateMachine // TypeDefIndex: 930
{
	// Fields
	public int <>1__state; // 0x0
	public AsyncTaskMethodBuilder <>t__builder; // 0x4
	public CryptoStream <>4__this; // 0x10
	public int count; // 0x14
	public int offset; // 0x18
	public byte[] buffer; // 0x1C
	public CancellationToken cancellationToken; // 0x20
	private int <bytesToWrite>5__1; // 0x24
	private int <currentInputIndex>5__2; // 0x28
	private int <numWholeBlocksInBytes>5__3; // 0x2C
	private SemaphoreSlim <sem>5__4; // 0x30
	private CryptoStream.HopToThreadPoolAwaitable <>u__1; // 0x34
	private ConfiguredTaskAwaitable.ConfiguredTaskAwaiter <>u__2; // 0x38

	// Methods

	// RVA: 0x769B1C Offset: 0x769B1C VA: 0x769B1C Slot: 4
	private void MoveNext() { }

	[DebuggerHiddenAttribute] // RVA: 0x4E3D90 Offset: 0x4E3D90 VA: 0x4E3D90
	// RVA: 0x769B24 Offset: 0x769B24 VA: 0x769B24 Slot: 5
	private void SetStateMachine(IAsyncStateMachine stateMachine) { }
}
