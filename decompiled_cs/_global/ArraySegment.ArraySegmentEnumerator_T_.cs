// Namespace: 
[Serializable]
private sealed class ArraySegment.ArraySegmentEnumerator<T> : IEnumerator<T>, IDisposable, IEnumerator // TypeDefIndex: 160
{
	// Fields
	private T[] _array; // 0x0
	private int _start; // 0x0
	private int _end; // 0x0
	private int _current; // 0x0

	// Properties
	public T Current { get; }
	private object System.Collections.IEnumerator.Current { get; }

	// Methods

	// RVA: -1 Offset: -1
	internal void .ctor(ArraySegment<T> arraySegment) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x14557D8 Offset: 0x14557D8 VA: 0x14557D8
	|-ArraySegment.ArraySegmentEnumerator<byte>..ctor
	|
	|-RVA: 0x1455A34 Offset: 0x1455A34 VA: 0x1455A34
	|-ArraySegment.ArraySegmentEnumerator<int>..ctor
	|
	|-RVA: 0x1455C90 Offset: 0x1455C90 VA: 0x1455C90
	|-ArraySegment.ArraySegmentEnumerator<object>..ctor
	*/

	// RVA: -1 Offset: -1 Slot: 6
	public bool MoveNext() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1455828 Offset: 0x1455828 VA: 0x1455828
	|-ArraySegment.ArraySegmentEnumerator<byte>.MoveNext
	|
	|-RVA: 0x1455A84 Offset: 0x1455A84 VA: 0x1455A84
	|-ArraySegment.ArraySegmentEnumerator<int>.MoveNext
	|
	|-RVA: 0x1455CE0 Offset: 0x1455CE0 VA: 0x1455CE0
	|-ArraySegment.ArraySegmentEnumerator<object>.MoveNext
	*/

	// RVA: -1 Offset: -1 Slot: 4
	public T get_Current() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1455858 Offset: 0x1455858 VA: 0x1455858
	|-ArraySegment.ArraySegmentEnumerator<byte>.get_Current
	|
	|-RVA: 0x1455AB4 Offset: 0x1455AB4 VA: 0x1455AB4
	|-ArraySegment.ArraySegmentEnumerator<int>.get_Current
	|
	|-RVA: 0x1455D10 Offset: 0x1455D10 VA: 0x1455D10
	|-ArraySegment.ArraySegmentEnumerator<object>.get_Current
	*/

	// RVA: -1 Offset: -1 Slot: 7
	private object System.Collections.IEnumerator.get_Current() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x14559AC Offset: 0x14559AC VA: 0x14559AC
	|-ArraySegment.ArraySegmentEnumerator<byte>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x1455C08 Offset: 0x1455C08 VA: 0x1455C08
	|-ArraySegment.ArraySegmentEnumerator<int>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x1455E64 Offset: 0x1455E64 VA: 0x1455E64
	|-ArraySegment.ArraySegmentEnumerator<object>.System.Collections.IEnumerator.get_Current
	*/

	// RVA: -1 Offset: -1 Slot: 8
	private void System.Collections.IEnumerator.Reset() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1455A20 Offset: 0x1455A20 VA: 0x1455A20
	|-ArraySegment.ArraySegmentEnumerator<byte>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x1455C7C Offset: 0x1455C7C VA: 0x1455C7C
	|-ArraySegment.ArraySegmentEnumerator<int>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x1455EA0 Offset: 0x1455EA0 VA: 0x1455EA0
	|-ArraySegment.ArraySegmentEnumerator<object>.System.Collections.IEnumerator.Reset
	*/

	// RVA: -1 Offset: -1 Slot: 5
	public void Dispose() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1455A30 Offset: 0x1455A30 VA: 0x1455A30
	|-ArraySegment.ArraySegmentEnumerator<byte>.Dispose
	|
	|-RVA: 0x1455C8C Offset: 0x1455C8C VA: 0x1455C8C
	|-ArraySegment.ArraySegmentEnumerator<int>.Dispose
	|
	|-RVA: 0x1455EB0 Offset: 0x1455EB0 VA: 0x1455EB0
	|-ArraySegment.ArraySegmentEnumerator<object>.Dispose
	*/
}
