// Namespace: 
[Serializable]
public struct RandomAccessQueue.Enumerator<T> : IEnumerator<T>, IEnumerator, IDisposable // TypeDefIndex: 8851
{
	// Fields
	private readonly RandomAccessQueue<T> _q; // 0x0
	private int _index; // 0x0
	private readonly int _version; // 0x0
	private T _currentElement; // 0x0

	// Properties
	public T Current { get; }
	private object System.Collections.IEnumerator.Current { get; }

	// Methods

	// RVA: -1 Offset: -1
	internal void .ctor(RandomAccessQueue<T> q) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x7693B4 Offset: 0x7693B4 VA: 0x7693B4
	|-RandomAccessQueue.Enumerator<object>..ctor
	*/

	// RVA: -1 Offset: -1 Slot: 5
	public void Dispose() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x7693F4 Offset: 0x7693F4 VA: 0x7693F4
	|-RandomAccessQueue.Enumerator<object>.Dispose
	*/

	// RVA: -1 Offset: -1 Slot: 6
	public bool MoveNext() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x769408 Offset: 0x769408 VA: 0x769408
	|-RandomAccessQueue.Enumerator<object>.MoveNext
	*/

	// RVA: -1 Offset: -1 Slot: 4
	public T get_Current() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x769410 Offset: 0x769410 VA: 0x769410
	|-RandomAccessQueue.Enumerator<object>.get_Current
	*/

	// RVA: -1 Offset: -1 Slot: 7
	private object System.Collections.IEnumerator.get_Current() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x769418 Offset: 0x769418 VA: 0x769418
	|-RandomAccessQueue.Enumerator<object>.System.Collections.IEnumerator.get_Current
	*/

	// RVA: -1 Offset: -1 Slot: 8
	private void System.Collections.IEnumerator.Reset() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x769420 Offset: 0x769420 VA: 0x769420
	|-RandomAccessQueue.Enumerator<object>.System.Collections.IEnumerator.Reset
	*/
}
