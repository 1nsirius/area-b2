// Namespace: 
internal sealed class Stream.SynchronousAsyncResult : IAsyncResult // TypeDefIndex: 626
{
	// Fields
	private readonly object _stateObject; // 0x8
	private readonly bool _isWrite; // 0xC
	private ManualResetEvent _waitHandle; // 0x10
	private ExceptionDispatchInfo _exceptionInfo; // 0x14
	private bool _endXxxCalled; // 0x18
	private int _bytesRead; // 0x1C

	// Properties
	public bool IsCompleted { get; }
	public WaitHandle AsyncWaitHandle { get; }
	public object AsyncState { get; }
	public bool CompletedSynchronously { get; }

	// Methods

	// RVA: 0x165B280 Offset: 0x165B280 VA: 0x165B280
	internal void .ctor(int bytesRead, object asyncStateObject) { }

	// RVA: 0x165B398 Offset: 0x165B398 VA: 0x165B398
	internal void .ctor(object asyncStateObject) { }

	// RVA: 0x165B2A8 Offset: 0x165B2A8 VA: 0x165B2A8
	internal void .ctor(Exception ex, object asyncStateObject, bool isWrite) { }

	// RVA: 0x165C394 Offset: 0x165C394 VA: 0x165C394 Slot: 4
	public bool get_IsCompleted() { }

	// RVA: 0x165C39C Offset: 0x165C39C VA: 0x165C39C Slot: 5
	public WaitHandle get_AsyncWaitHandle() { }

	// RVA: 0x165C4E4 Offset: 0x165C4E4 VA: 0x165C4E4 Slot: 6
	public object get_AsyncState() { }

	// RVA: 0x165C4EC Offset: 0x165C4EC VA: 0x165C4EC Slot: 7
	public bool get_CompletedSynchronously() { }

	// RVA: 0x165C4F4 Offset: 0x165C4F4 VA: 0x165C4F4
	internal void ThrowIfError() { }

	// RVA: 0x165B2E4 Offset: 0x165B2E4 VA: 0x165B2E4
	internal static int EndRead(IAsyncResult asyncResult) { }

	// RVA: 0x165B3C0 Offset: 0x165B3C0 VA: 0x165B3C0
	internal static void EndWrite(IAsyncResult asyncResult) { }
}
