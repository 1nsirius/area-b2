// Namespace: 
internal class ThreadPoolWorkQueue.QueueSegment // TypeDefIndex: 800
{
	// Fields
	internal readonly IThreadPoolWorkItem[] nodes; // 0x8
	private int indexes; // 0xC
	public ThreadPoolWorkQueue.QueueSegment Next; // 0x10

	// Methods

	// RVA: 0x1AC2B5C Offset: 0x1AC2B5C VA: 0x1AC2B5C
	private void GetIndexes(out int upper, out int lower) { }

	// RVA: 0x1AC2B88 Offset: 0x1AC2B88 VA: 0x1AC2B88
	private bool CompareExchangeIndexes(ref int prevUpper, int newUpper, ref int prevLower, int newLower) { }

	[ReliabilityContractAttribute] // RVA: 0x4E38AC Offset: 0x4E38AC VA: 0x4E38AC
	// RVA: 0x1AC0EA8 Offset: 0x1AC0EA8 VA: 0x1AC0EA8
	public void .ctor() { }

	// RVA: 0x1AC220C Offset: 0x1AC220C VA: 0x1AC220C
	public bool IsUsedUp() { }

	// RVA: 0x1AC173C Offset: 0x1AC173C VA: 0x1AC173C
	public bool TryEnqueue(IThreadPoolWorkItem node) { }

	// RVA: 0x1AC20E8 Offset: 0x1AC20E8 VA: 0x1AC20E8
	public bool TryDequeue(out IThreadPoolWorkItem node) { }
}
