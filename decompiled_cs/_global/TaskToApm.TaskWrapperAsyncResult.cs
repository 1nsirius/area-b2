// Namespace: 
private sealed class TaskToApm.TaskWrapperAsyncResult : IAsyncResult // TypeDefIndex: 870
{
	// Fields
	internal readonly Task Task; // 0x8
	private readonly object m_state; // 0xC
	private readonly bool m_completedSynchronously; // 0x10

	// Properties
	private object System.IAsyncResult.AsyncState { get; }
	private bool System.IAsyncResult.CompletedSynchronously { get; }
	private bool System.IAsyncResult.IsCompleted { get; }
	private WaitHandle System.IAsyncResult.AsyncWaitHandle { get; }

	// Methods

	// RVA: 0x1ABD8C8 Offset: 0x1ABD8C8 VA: 0x1ABD8C8
	internal void .ctor(Task task, object state, bool completedSynchronously) { }

	// RVA: 0x1ABDB68 Offset: 0x1ABDB68 VA: 0x1ABDB68 Slot: 6
	private object System.IAsyncResult.get_AsyncState() { }

	// RVA: 0x1ABDB70 Offset: 0x1ABDB70 VA: 0x1ABDB70 Slot: 7
	private bool System.IAsyncResult.get_CompletedSynchronously() { }

	// RVA: 0x1ABDB78 Offset: 0x1ABDB78 VA: 0x1ABDB78 Slot: 4
	private bool System.IAsyncResult.get_IsCompleted() { }

	// RVA: 0x1ABDBA4 Offset: 0x1ABDBA4 VA: 0x1ABDBA4 Slot: 5
	private WaitHandle System.IAsyncResult.get_AsyncWaitHandle() { }
}
