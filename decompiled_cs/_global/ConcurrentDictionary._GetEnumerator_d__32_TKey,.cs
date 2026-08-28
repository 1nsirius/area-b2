// Namespace: 
[CompilerGeneratedAttribute] // RVA: 0x4DE980 Offset: 0x4DE980 VA: 0x4DE980
private sealed class ConcurrentDictionary.<GetEnumerator>d__32<TKey, TValue> : IEnumerator<KeyValuePair<TKey, TValue>>, IDisposable, IEnumerator // TypeDefIndex: 1406
{
	// Fields
	private int <>1__state; // 0x0
	private KeyValuePair<TKey, TValue> <>2__current; // 0x0
	public ConcurrentDictionary<TKey, TValue> <>4__this; // 0x0
	private ConcurrentDictionary.Node<TKey, TValue>[] <buckets>5__1; // 0x0
	private ConcurrentDictionary.Node<TKey, TValue> <current>5__2; // 0x0
	private int <i>5__3; // 0x0

	// Properties
	private KeyValuePair<TKey, TValue> System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<TKey,TValue>>.Current { get; }
	private object System.Collections.IEnumerator.Current { get; }

	// Methods

	[DebuggerHiddenAttribute] // RVA: 0x4E4528 Offset: 0x4E4528 VA: 0x4E4528
	// RVA: -1 Offset: -1
	public void .ctor(int <>1__state) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1458FC8 Offset: 0x1458FC8 VA: 0x1458FC8
	|-ConcurrentDictionary.<GetEnumerator>d__32<object, object>..ctor
	*/

	[DebuggerHiddenAttribute] // RVA: 0x4E4538 Offset: 0x4E4538 VA: 0x4E4538
	// RVA: -1 Offset: -1 Slot: 5
	private void System.IDisposable.Dispose() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1458FFC Offset: 0x1458FFC VA: 0x1458FFC
	|-ConcurrentDictionary.<GetEnumerator>d__32<object, object>.System.IDisposable.Dispose
	*/

	// RVA: -1 Offset: -1 Slot: 6
	private bool MoveNext() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1459000 Offset: 0x1459000 VA: 0x1459000
	|-ConcurrentDictionary.<GetEnumerator>d__32<object, object>.MoveNext
	*/

	[DebuggerHiddenAttribute] // RVA: 0x4E4548 Offset: 0x4E4548 VA: 0x4E4548
	// RVA: -1 Offset: -1 Slot: 4
	private KeyValuePair<TKey, TValue> System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<TKey,TValue>>.get_Current() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x145917C Offset: 0x145917C VA: 0x145917C
	|-ConcurrentDictionary.<GetEnumerator>d__32<object, object>.System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<TKey,TValue>>.get_Current
	*/

	[DebuggerHiddenAttribute] // RVA: 0x4E4558 Offset: 0x4E4558 VA: 0x4E4558
	// RVA: -1 Offset: -1 Slot: 8
	private void System.Collections.IEnumerator.Reset() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1459190 Offset: 0x1459190 VA: 0x1459190
	|-ConcurrentDictionary.<GetEnumerator>d__32<object, object>.System.Collections.IEnumerator.Reset
	*/

	[DebuggerHiddenAttribute] // RVA: 0x4E4568 Offset: 0x4E4568 VA: 0x4E4568
	// RVA: -1 Offset: -1 Slot: 7
	private object System.Collections.IEnumerator.get_Current() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1459218 Offset: 0x1459218 VA: 0x1459218
	|-ConcurrentDictionary.<GetEnumerator>d__32<object, object>.System.Collections.IEnumerator.get_Current
	*/
}
