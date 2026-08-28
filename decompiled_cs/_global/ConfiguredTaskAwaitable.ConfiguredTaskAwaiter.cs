// Namespace: 
public struct ConfiguredTaskAwaitable.ConfiguredTaskAwaiter : ICriticalNotifyCompletion, INotifyCompletion // TypeDefIndex: 1275
{
	// Fields
	private readonly Task m_task; // 0x0
	private readonly bool m_continueOnCapturedContext; // 0x4

	// Properties
	public bool IsCompleted { get; }

	// Methods

	// RVA: 0x774FD8 Offset: 0x774FD8 VA: 0x774FD8
	internal void .ctor(Task task, bool continueOnCapturedContext) { }

	// RVA: 0x774FE4 Offset: 0x774FE4 VA: 0x774FE4
	public bool get_IsCompleted() { }

	// RVA: 0x774FEC Offset: 0x774FEC VA: 0x774FEC Slot: 5
	public void OnCompleted(Action continuation) { }

	// RVA: 0x775010 Offset: 0x775010 VA: 0x775010 Slot: 4
	public void UnsafeOnCompleted(Action continuation) { }

	// RVA: 0x775034 Offset: 0x775034 VA: 0x775034
	public void GetResult() { }
}
