// Namespace: 
internal abstract class TimerThread.Timer : IDisposable // TypeDefIndex: 1933
{
	// Fields
	private readonly int m_StartTimeMilliseconds; // 0x8
	private readonly int m_DurationMilliseconds; // 0xC

	// Methods

	// RVA: 0x1810758 Offset: 0x1810758 VA: 0x1810758
	internal void .ctor(int durationMilliseconds) { }

	// RVA: -1 Offset: -1 Slot: 5
	internal abstract bool Cancel();

	// RVA: 0x1810784 Offset: 0x1810784 VA: 0x1810784 Slot: 4
	public void Dispose() { }
}
