// Namespace: 
internal class Task.ContingentProperties // TypeDefIndex: 839
{
	// Fields
	internal ExecutionContext m_capturedContext; // 0x8
	internal ManualResetEventSlim m_completionEvent; // 0xC
	internal TaskExceptionHolder m_exceptionsHolder; // 0x10
	internal CancellationToken m_cancellationToken; // 0x14
	internal Shared<CancellationTokenRegistration> m_cancellationRegistration; // 0x18
	internal int m_internalCancellationRequested; // 0x1C
	internal int m_completionCountdown; // 0x20
	internal List<Task> m_exceptionalChildren; // 0x24

	// Methods

	// RVA: 0x1AB9A40 Offset: 0x1AB9A40 VA: 0x1AB9A40
	internal void SetCompleted() { }

	// RVA: 0x1AB9A68 Offset: 0x1AB9A68 VA: 0x1AB9A68
	internal void DeregisterCancellationCallback() { }

	// RVA: 0x1AB9408 Offset: 0x1AB9408 VA: 0x1AB9408
	public void .ctor() { }
}
