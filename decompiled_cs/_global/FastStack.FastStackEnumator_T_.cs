// Namespace: 
public struct FastStack.FastStackEnumator<T> : IEnumerator<T>, IEnumerator, IDisposable // TypeDefIndex: 8898
{
	// Fields
	private FastStack<T> stack; // 0x0
	private int index; // 0x0
	private T current; // 0x0

	// Properties
	public T Current { get; }
	private object System.Collections.IEnumerator.Current { get; }

	// Methods

	// RVA: -1 Offset: -1
	internal void .ctor(FastStack<T> stack) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x769428 Offset: 0x769428 VA: 0x769428
	|-FastStack.FastStackEnumator<object>..ctor
	*/

	// RVA: -1 Offset: -1 Slot: 4
	public T get_Current() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x76943C Offset: 0x76943C VA: 0x76943C
	|-FastStack.FastStackEnumator<object>.get_Current
	*/

	// RVA: -1 Offset: -1 Slot: 7
	private object System.Collections.IEnumerator.get_Current() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x769444 Offset: 0x769444 VA: 0x769444
	|-FastStack.FastStackEnumator<object>.System.Collections.IEnumerator.get_Current
	*/

	// RVA: -1 Offset: -1 Slot: 5
	public void Dispose() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x76946C Offset: 0x76946C VA: 0x76946C
	|-FastStack.FastStackEnumator<object>.Dispose
	*/

	// RVA: -1 Offset: -1 Slot: 6
	public bool MoveNext() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x769470 Offset: 0x769470 VA: 0x769470
	|-FastStack.FastStackEnumator<object>.MoveNext
	*/

	// RVA: -1 Offset: -1
	private bool MoveNextRare() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x769478 Offset: 0x769478 VA: 0x769478
	|-FastStack.FastStackEnumator<object>.MoveNextRare
	*/

	// RVA: -1 Offset: -1 Slot: 8
	private void System.Collections.IEnumerator.Reset() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x7694B4 Offset: 0x7694B4 VA: 0x7694B4
	|-FastStack.FastStackEnumator<object>.System.Collections.IEnumerator.Reset
	*/
}
