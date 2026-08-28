// Namespace: 
private struct Array.SorterGenericArray // TypeDefIndex: 117
{
	// Fields
	private Array keys; // 0x0
	private Array items; // 0x4
	private IComparer comparer; // 0x8

	// Methods

	// RVA: 0x76E24C Offset: 0x76E24C VA: 0x76E24C
	internal void .ctor(Array keys, Array items, IComparer comparer) { }

	// RVA: 0x76E268 Offset: 0x76E268 VA: 0x76E268
	internal void SwapIfGreaterWithItems(int a, int b) { }

	// RVA: 0x76E270 Offset: 0x76E270 VA: 0x76E270
	private void Swap(int i, int j) { }

	// RVA: 0x76E278 Offset: 0x76E278 VA: 0x76E278
	internal void Sort(int left, int length) { }

	// RVA: 0x76E280 Offset: 0x76E280 VA: 0x76E280
	private void IntrospectiveSort(int left, int length) { }

	// RVA: 0x76E288 Offset: 0x76E288 VA: 0x76E288
	private void IntroSort(int lo, int hi, int depthLimit) { }

	// RVA: 0x76E2A4 Offset: 0x76E2A4 VA: 0x76E2A4
	private int PickPivotAndPartition(int lo, int hi) { }

	// RVA: 0x76E2AC Offset: 0x76E2AC VA: 0x76E2AC
	private void Heapsort(int lo, int hi) { }

	// RVA: 0x76E2B4 Offset: 0x76E2B4 VA: 0x76E2B4
	private void DownHeap(int i, int n, int lo) { }

	// RVA: 0x76E2D0 Offset: 0x76E2D0 VA: 0x76E2D0
	private void InsertionSort(int lo, int hi) { }
}
