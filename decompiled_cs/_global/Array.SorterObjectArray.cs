// Namespace: 
private struct Array.SorterObjectArray // TypeDefIndex: 116
{
	// Fields
	private object[] keys; // 0x0
	private object[] items; // 0x4
	private IComparer comparer; // 0x8

	// Methods

	// RVA: 0x76E334 Offset: 0x76E334 VA: 0x76E334
	internal void .ctor(object[] keys, object[] items, IComparer comparer) { }

	// RVA: 0x76E350 Offset: 0x76E350 VA: 0x76E350
	internal void SwapIfGreaterWithItems(int a, int b) { }

	// RVA: 0x76E358 Offset: 0x76E358 VA: 0x76E358
	private void Swap(int i, int j) { }

	// RVA: 0x76E360 Offset: 0x76E360 VA: 0x76E360
	internal void Sort(int left, int length) { }

	// RVA: 0x76E368 Offset: 0x76E368 VA: 0x76E368
	private void IntrospectiveSort(int left, int length) { }

	// RVA: 0x76E370 Offset: 0x76E370 VA: 0x76E370
	private void IntroSort(int lo, int hi, int depthLimit) { }

	// RVA: 0x76E38C Offset: 0x76E38C VA: 0x76E38C
	private int PickPivotAndPartition(int lo, int hi) { }

	// RVA: 0x76E394 Offset: 0x76E394 VA: 0x76E394
	private void Heapsort(int lo, int hi) { }

	// RVA: 0x76E39C Offset: 0x76E39C VA: 0x76E39C
	private void DownHeap(int i, int n, int lo) { }

	// RVA: 0x76E3B8 Offset: 0x76E3B8 VA: 0x76E3B8
	private void InsertionSort(int lo, int hi) { }
}
