// Namespace: 
[CompilerGeneratedAttribute] // RVA: 0x4EE14C Offset: 0x4EE14C VA: 0x4EE14C
private sealed class Enumerable.<SelectManyIterator>d__23<TSource, TCollection, TResult> : IEnumerable<TResult>, IEnumerable, IEnumerator<TResult>, IDisposable, IEnumerator // TypeDefIndex: 2893
{
	// Fields
	private int <>1__state; // 0x0
	private TResult <>2__current; // 0x0
	private int <>l__initialThreadId; // 0x0
	private IEnumerable<TSource> source; // 0x0
	public IEnumerable<TSource> <>3__source; // 0x0
	private Func<TSource, IEnumerable<TCollection>> collectionSelector; // 0x0
	public Func<TSource, IEnumerable<TCollection>> <>3__collectionSelector; // 0x0
	private Func<TSource, TCollection, TResult> resultSelector; // 0x0
	public Func<TSource, TCollection, TResult> <>3__resultSelector; // 0x0
	private TSource <element>5__1; // 0x0
	private IEnumerator<TSource> <>7__wrap1; // 0x0
	private IEnumerator<TCollection> <>7__wrap2; // 0x0

	// Properties
	private TResult System.Collections.Generic.IEnumerator<TResult>.Current { get; }
	private object System.Collections.IEnumerator.Current { get; }

	// Methods

	[DebuggerHiddenAttribute] // RVA: 0x4EF030 Offset: 0x4EF030 VA: 0x4EF030
	// RVA: -1 Offset: -1
	public void .ctor(int <>1__state) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1F8FA78 Offset: 0x1F8FA78 VA: 0x1F8FA78
	|-Enumerable.<SelectManyIterator>d__23<object, object, object>..ctor
	*/

	[DebuggerHiddenAttribute] // RVA: 0x4EF040 Offset: 0x4EF040 VA: 0x4EF040
	// RVA: -1 Offset: -1 Slot: 7
	private void System.IDisposable.Dispose() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1F8FAB8 Offset: 0x1F8FAB8 VA: 0x1F8FAB8
	|-Enumerable.<SelectManyIterator>d__23<object, object, object>.System.IDisposable.Dispose
	*/

	// RVA: -1 Offset: -1 Slot: 8
	private bool MoveNext() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1F8FB40 Offset: 0x1F8FB40 VA: 0x1F8FB40
	|-Enumerable.<SelectManyIterator>d__23<object, object, object>.MoveNext
	*/

	// RVA: -1 Offset: -1
	private void <>m__Finally1() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1F90110 Offset: 0x1F90110 VA: 0x1F90110
	|-Enumerable.<SelectManyIterator>d__23<object, object, object>.<>m__Finally1
	*/

	// RVA: -1 Offset: -1
	private void <>m__Finally2() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1F901E8 Offset: 0x1F901E8 VA: 0x1F901E8
	|-Enumerable.<SelectManyIterator>d__23<object, object, object>.<>m__Finally2
	*/

	[DebuggerHiddenAttribute] // RVA: 0x4EF050 Offset: 0x4EF050 VA: 0x4EF050
	// RVA: -1 Offset: -1 Slot: 6
	private TResult System.Collections.Generic.IEnumerator<TResult>.get_Current() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1F902C0 Offset: 0x1F902C0 VA: 0x1F902C0
	|-Enumerable.<SelectManyIterator>d__23<object, object, object>.System.Collections.Generic.IEnumerator<TResult>.get_Current
	*/

	[DebuggerHiddenAttribute] // RVA: 0x4EF060 Offset: 0x4EF060 VA: 0x4EF060
	// RVA: -1 Offset: -1 Slot: 10
	private void System.Collections.IEnumerator.Reset() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1F902C8 Offset: 0x1F902C8 VA: 0x1F902C8
	|-Enumerable.<SelectManyIterator>d__23<object, object, object>.System.Collections.IEnumerator.Reset
	*/

	[DebuggerHiddenAttribute] // RVA: 0x4EF070 Offset: 0x4EF070 VA: 0x4EF070
	// RVA: -1 Offset: -1 Slot: 9
	private object System.Collections.IEnumerator.get_Current() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1F90350 Offset: 0x1F90350 VA: 0x1F90350
	|-Enumerable.<SelectManyIterator>d__23<object, object, object>.System.Collections.IEnumerator.get_Current
	*/

	[DebuggerHiddenAttribute] // RVA: 0x4EF080 Offset: 0x4EF080 VA: 0x4EF080
	// RVA: -1 Offset: -1 Slot: 4
	private IEnumerator<TResult> System.Collections.Generic.IEnumerable<TResult>.GetEnumerator() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1F90358 Offset: 0x1F90358 VA: 0x1F90358
	|-Enumerable.<SelectManyIterator>d__23<object, object, object>.System.Collections.Generic.IEnumerable<TResult>.GetEnumerator
	*/

	[DebuggerHiddenAttribute] // RVA: 0x4EF090 Offset: 0x4EF090 VA: 0x4EF090
	// RVA: -1 Offset: -1 Slot: 5
	private IEnumerator System.Collections.IEnumerable.GetEnumerator() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1F9043C Offset: 0x1F9043C VA: 0x1F9043C
	|-Enumerable.<SelectManyIterator>d__23<object, object, object>.System.Collections.IEnumerable.GetEnumerator
	*/
}
