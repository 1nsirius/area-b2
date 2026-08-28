// Namespace: 
private struct UnitySynchronizationContext.WorkRequest // TypeDefIndex: 3443
{
	// Fields
	private readonly SendOrPostCallback m_DelagateCallback; // 0x0
	private readonly object m_DelagateState; // 0x4
	private readonly ManualResetEvent m_WaitHandle; // 0x8

	// Methods

	// RVA: 0x80DC1C Offset: 0x80DC1C VA: 0x80DC1C
	public void .ctor(SendOrPostCallback callback, object state, ManualResetEvent waitHandle) { }

	// RVA: 0x80DC28 Offset: 0x80DC28 VA: 0x80DC28
	public void Invoke() { }
}
