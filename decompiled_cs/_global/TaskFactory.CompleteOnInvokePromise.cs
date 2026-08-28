// Namespace: 
internal sealed class TaskFactory.CompleteOnInvokePromise : Task<Task>, ITaskCompletionAction // TypeDefIndex: 864
{
	// Fields
	private IList<Task> _tasks; // 0x2C
	private int m_firstTaskAlreadyCompleted; // 0x30

	// Methods

	// RVA: 0x1ABC614 Offset: 0x1ABC614 VA: 0x1ABC614
	public void .ctor(IList<Task> tasks) { }

	// RVA: 0x1ABC770 Offset: 0x1ABC770 VA: 0x1ABC770 Slot: 20
	public void Invoke(Task completingTask) { }
}
