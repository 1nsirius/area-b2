// Namespace: 
private sealed class SemaphoreSlim.TaskNode : Task<bool>, IThreadPoolWorkItem // TypeDefIndex: 760
{
	// Fields
	internal SemaphoreSlim.TaskNode Prev; // 0x2C
	internal SemaphoreSlim.TaskNode Next; // 0x30

	// Methods

	// RVA: 0x1297B7C Offset: 0x1297B7C VA: 0x1297B7C
	internal void .ctor() { }

	// RVA: 0x12992DC Offset: 0x12992DC VA: 0x12992DC Slot: 4
	private void System.Threading.IThreadPoolWorkItem.ExecuteWorkItem() { }

	// RVA: 0x1299344 Offset: 0x1299344 VA: 0x1299344 Slot: 5
	private void System.Threading.IThreadPoolWorkItem.MarkAborted(ThreadAbortException tae) { }
}
