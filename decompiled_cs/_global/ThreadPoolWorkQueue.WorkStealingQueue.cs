// Namespace: 
internal class ThreadPoolWorkQueue.WorkStealingQueue // TypeDefIndex: 799
{
	// Fields
	internal IThreadPoolWorkItem[] m_array; // 0x8
	private int m_mask; // 0xC
	private int m_headIndex; // 0x10
	private int m_tailIndex; // 0x14
	private SpinLock m_foreignLock; // 0x18

	// Methods

	// RVA: 0x1AC1228 Offset: 0x1AC1228 VA: 0x1AC1228
	public void LocalPush(IThreadPoolWorkItem obj) { }

	// RVA: 0x1AC180C Offset: 0x1AC180C VA: 0x1AC180C
	public bool LocalFindAndPop(IThreadPoolWorkItem obj) { }

	// RVA: 0x1AC1DD0 Offset: 0x1AC1DD0 VA: 0x1AC1DD0
	public bool LocalPop(out IThreadPoolWorkItem obj) { }

	// RVA: 0x1AC2274 Offset: 0x1AC2274 VA: 0x1AC2274
	public bool TrySteal(out IThreadPoolWorkItem obj, ref bool missedSteal) { }

	// RVA: 0x1AC2BEC Offset: 0x1AC2BEC VA: 0x1AC2BEC
	private bool TrySteal(out IThreadPoolWorkItem obj, ref bool missedSteal, int millisecondsTimeout) { }

	// RVA: 0x1AC2EAC Offset: 0x1AC2EAC VA: 0x1AC2EAC
	public void .ctor() { }
}
