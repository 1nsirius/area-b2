// Namespace: 
[CompilerGeneratedAttribute] // RVA: 0x4EE13C Offset: 0x4EE13C VA: 0x4EE13C
private sealed class Enumerable.<SelectManyIterator>d__17<TSource, TResult> : IEnumerable<TResult>, IEnumerable, IEnumerator<TResult>, IDisposable, IEnumerator // TypeDefIndex: 2892
{
	// Fields
	private int <>1__state; // 0x0
	private TResult <>2__current; // 0x0
	private int <>l__initialThreadId; // 0x0
	private IEnumerable<TSource> source; // 0x0
	public IEnumerable<TSource> <>3__source; // 0x0
	private Func<TSource, IEnumerable<TResult>> selector; // 0x0
	public Func<TSource, IEnumerable<TResult>> <>3__selector; // 0x0
	private IEnumerator<TSource> <>7__wrap1; // 0x0
	private IEnumerator<TResult> <>7__wrap2; // 0x0

	// Properties
	private TResult System.Collections.Generic.IEnumerator<TResult>.Current { get; }
	private object System.Collections.IEnumerator.Current { get; }

	// Methods

	[DebuggerHiddenAttribute] // RVA: 0x4EEFC0 Offset: 0x4EEFC0 VA: 0x4EEFC0
	// RVA: -1 Offset: -1
	public void .ctor(int <>1__state) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1F8F0DC Offset: 0x1F8F0DC VA: 0x1F8F0DC
	|-Enumerable.<SelectManyIterator>d__17<object, object>..ctor
	*/

	[DebuggerHiddenAttribute] // RVA: 0x4EEFD0 Offset: 0x4EEFD0 VA: 0x4EEFD0
	// RVA: -1 Offset: -1 Slot: 7
	private void System.IDisposable.Dispose() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1F8F11C Offset: 0x1F8F11C VA: 0x1F8F11C
	|-Enumerable.<SelectManyIterator>d__17<object, object>.System.IDisposable.Dispose
	*/

	// RVA: -1 Offset: -1 Slot: 8
	private bool MoveNext() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1F8F1A4 Offset: 0x1F8F1A4 VA: 0x1F8F1A4
	|-Enumerable.<SelectManyIterator>d__17<object, object>.MoveNext
	*/

	// RVA: -1 Offset: -1
	private void <>m__Finally1() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1F8F72C Offset: 0x1F8F72C VA: 0x1F8F72C
	|-Enumerable.<SelectManyIterator>d__17<object, object>.<>m__Finally1
	*/

	// RVA: -1 Offset: -1
	private void <>m__Finally2() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1F8F804 Offset: 0x1F8F804 VA: 0x1F8F804
	|-Enumerable.<SelectManyIterator>d__17<object, object>.<>m__Finally2
	*/

	[DebuggerHiddenAttribute] // RVA: 0x4EEFE0 Offset: 0x4EEFE0 VA: 0x4EEFE0
	// RVA: -1 Offset: -1 Slot: 6
	private TResult System.Collections.Generic.IEnumerator<TResult>.get_Current() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1F8F8DC Offset: 0x1F8F8DC VA: 0x1F8F8DC
	|-Enumerable.<SelectManyIterator>d__17<object, object>.System.Collections.Generic.IEnumerator<TResult>.get_Current
	*/

	[DebuggerHiddenAttribute] // RVA: 0x4EEFF0 Offset: 0x4EEFF0 VA: 0x4EEFF0
	// RVA: -1 Offset: -1 Slot: 10
	private void System.Collections.IEnumerator.Reset() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1F8F8E4 Offset: 0x1F8F8E4 VA: 0x1F8F8E4
	|-Enumerable.<SelectManyIterator>d__17<object, object>.System.Collections.IEnumerator.Reset
	*/

	[DebuggerHiddenAttribute] // RVA: 0x4EF000 Offset: 0x4EF000 VA: 0x4EF000
	// RVA: -1 Offset: -1 Slot: 9
	private object System.Collections.IEnumerator.get_Current() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1F8F96C Offset: 0x1F8F96C VA: 0x1F8F96C
	|-Enumerable.<SelectManyIterator>d__17<object, object>.System.Collections.IEnumerator.get_Current
	*/

	[DebuggerHiddenAttribute] // RVA: 0x4EF010 Offset: 0x4EF010 VA: 0x4EF010
	// RVA: -1 Offset: -1 Slot: 4
	private IEnumerator<TResult> System.Collections.Generic.IEnumerable<TResult>.GetEnumerator() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1F8F974 Offset: 0x1F8F974 VA: 0x1F8F974
	|-Enumerable.<SelectManyIterator>d__17<object, object>.System.Collections.Generic.IEnumerable<TResult>.GetEnumerator
	*/

	[DebuggerHiddenAttribute] // RVA: 0x4EF020 Offset: 0x4EF020 VA: 0x4EF020
	// RVA: -1 Offset: -1 Slot: 5
	private IEnumerator System.Collections.IEnumerable.GetEnumerator() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1F8FA3C Offset: 0x1F8FA3C VA: 0x1F8FA3C
	|-Enumerable.<SelectManyIterator>d__17<object, object>.System.Collections.IEnumerable.GetEnumerator
	*/
}
