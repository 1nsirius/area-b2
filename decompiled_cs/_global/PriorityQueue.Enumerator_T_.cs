// Namespace: 
public struct PriorityQueue.Enumerator<T> : IEnumerator<T>, IEnumerator, IDisposable // TypeDefIndex: 8917
{
	// Fields
	private PriorityQueue<T> _queue; // 0x0
	private int _index; // 0x0
	private readonly int _version; // 0x0
	private T _current; // 0x0

	// Properties
	public T Current { get; }
	private object System.Collections.IEnumerator.Current { get; }

	// Methods

	// RVA: -1 Offset: -1 Slot: 4
	public T get_Current() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x7692A4 Offset: 0x7692A4 VA: 0x7692A4
	|-PriorityQueue.Enumerator<object>.get_Current
	*/

	// RVA: -1 Offset: -1 Slot: 7
	private object System.Collections.IEnumerator.get_Current() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x7692AC Offset: 0x7692AC VA: 0x7692AC
	|-PriorityQueue.Enumerator<object>.System.Collections.IEnumerator.get_Current
	*/

	// RVA: -1 Offset: -1
	internal void .ctor(PriorityQueue<T> queue) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x7692B4 Offset: 0x7692B4 VA: 0x7692B4
	|-PriorityQueue.Enumerator<object>..ctor
	*/

	// RVA: -1 Offset: -1 Slot: 5
	public void Dispose() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x7692F0 Offset: 0x7692F0 VA: 0x7692F0
	|-PriorityQueue.Enumerator<object>.Dispose
	*/

	// RVA: -1 Offset: -1
	private void CheckState() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x769300 Offset: 0x769300 VA: 0x769300
	|-PriorityQueue.Enumerator<object>.CheckState
	*/

	// RVA: -1 Offset: -1 Slot: 6
	public bool MoveNext() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x769308 Offset: 0x769308 VA: 0x769308
	|-PriorityQueue.Enumerator<object>.MoveNext
	*/

	// RVA: -1 Offset: -1 Slot: 8
	private void System.Collections.IEnumerator.Reset() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x769310 Offset: 0x769310 VA: 0x769310
	|-PriorityQueue.Enumerator<object>.System.Collections.IEnumerator.Reset
	*/
}
