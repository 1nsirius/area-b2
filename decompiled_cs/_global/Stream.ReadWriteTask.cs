// Namespace: 
private sealed class Stream.ReadWriteTask : Task<int>, ITaskCompletionAction // TypeDefIndex: 624
{
	// Fields
	internal readonly bool _isRead; // 0x2C
	internal Stream _stream; // 0x30
	internal byte[] _buffer; // 0x34
	internal int _offset; // 0x38
	internal int _count; // 0x3C
	private AsyncCallback _callback; // 0x40
	private ExecutionContext _context; // 0x44
	private static ContextCallback s_invokeAsyncCallback; // 0x0

	// Methods

	// RVA: 0x165B794 Offset: 0x165B794 VA: 0x165B794
	internal void ClearBeginState() { }

	// RVA: 0x1659AC0 Offset: 0x1659AC0 VA: 0x1659AC0
	public void .ctor(bool isRead, Func<object, int> function, object state, Stream stream, byte[] buffer, int offset, int count, AsyncCallback callback) { }

	// RVA: 0x165C060 Offset: 0x165C060 VA: 0x165C060
	private static void InvokeAsyncCallback(object completedTask) { }

	// RVA: 0x165C174 Offset: 0x165C174 VA: 0x165C174 Slot: 20
	private void System.Threading.Tasks.ITaskCompletionAction.Invoke(Task completingTask) { }
}
