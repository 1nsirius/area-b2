// Namespace: 
[CompilerGeneratedAttribute] // RVA: 0x55B654 Offset: 0x55B654 VA: 0x55B654
private sealed class Selecter.<SelectAll>d__1<TSource, TResult> : IEnumerable<TResult>, IEnumerable, IEnumerator<TResult>, IEnumerator, IDisposable // TypeDefIndex: 10101
{
	// Fields
	private int <>1__state; // 0x0
	private TResult <>2__current; // 0x0
	private int <>l__initialThreadId; // 0x0
	private IEnumerable<TSource> source; // 0x0
	public IEnumerable<TSource> <>3__source; // 0x0
	private Func<TSource, bool> condition; // 0x0
	public Func<TSource, bool> <>3__condition; // 0x0
	private Func<TSource, TResult> convertor; // 0x0
	public Func<TSource, TResult> <>3__convertor; // 0x0
	private IEnumerator<TSource> <>7__wrap1; // 0x0

	// Properties
	private TResult System.Collections.Generic.IEnumerator<TResult>.Current { get; }
	private object System.Collections.IEnumerator.Current { get; }

	// Methods

	[DebuggerHiddenAttribute] // RVA: 0x65D270 Offset: 0x65D270 VA: 0x65D270
	// RVA: -1 Offset: -1
	public void .ctor(int <>1__state) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x26A4F40 Offset: 0x26A4F40 VA: 0x26A4F40
	|-Selecter.<SelectAll>d__1<object, object>..ctor
	*/

	[DebuggerHiddenAttribute] // RVA: 0x65D280 Offset: 0x65D280 VA: 0x65D280
	// RVA: -1 Offset: -1 Slot: 7
	private void System.IDisposable.Dispose() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x26A4F80 Offset: 0x26A4F80 VA: 0x26A4F80
	|-Selecter.<SelectAll>d__1<object, object>.System.IDisposable.Dispose
	*/

	// RVA: -1 Offset: -1 Slot: 8
	private bool MoveNext() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x26A4FA8 Offset: 0x26A4FA8 VA: 0x26A4FA8
	|-Selecter.<SelectAll>d__1<object, object>.MoveNext
	*/

	// RVA: -1 Offset: -1
	private void <>m__Finally1() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x26A5364 Offset: 0x26A5364 VA: 0x26A5364
	|-Selecter.<SelectAll>d__1<object, object>.<>m__Finally1
	*/

	[DebuggerHiddenAttribute] // RVA: 0x65D290 Offset: 0x65D290 VA: 0x65D290
	// RVA: -1 Offset: -1 Slot: 6
	private TResult System.Collections.Generic.IEnumerator<TResult>.get_Current() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x26A543C Offset: 0x26A543C VA: 0x26A543C
	|-Selecter.<SelectAll>d__1<object, object>.System.Collections.Generic.IEnumerator<TResult>.get_Current
	*/

	[DebuggerHiddenAttribute] // RVA: 0x65D2A0 Offset: 0x65D2A0 VA: 0x65D2A0
	// RVA: -1 Offset: -1 Slot: 10
	private void System.Collections.IEnumerator.Reset() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x26A5444 Offset: 0x26A5444 VA: 0x26A5444
	|-Selecter.<SelectAll>d__1<object, object>.System.Collections.IEnumerator.Reset
	*/

	[DebuggerHiddenAttribute] // RVA: 0x65D2B0 Offset: 0x65D2B0 VA: 0x65D2B0
	// RVA: -1 Offset: -1 Slot: 9
	private object System.Collections.IEnumerator.get_Current() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x26A54CC Offset: 0x26A54CC VA: 0x26A54CC
	|-Selecter.<SelectAll>d__1<object, object>.System.Collections.IEnumerator.get_Current
	*/

	[DebuggerHiddenAttribute] // RVA: 0x65D2C0 Offset: 0x65D2C0 VA: 0x65D2C0
	// RVA: -1 Offset: -1 Slot: 4
	private IEnumerator<TResult> System.Collections.Generic.IEnumerable<TResult>.GetEnumerator() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x26A54D4 Offset: 0x26A54D4 VA: 0x26A54D4
	|-Selecter.<SelectAll>d__1<object, object>.System.Collections.Generic.IEnumerable<TResult>.GetEnumerator
	*/

	[DebuggerHiddenAttribute] // RVA: 0x65D2D0 Offset: 0x65D2D0 VA: 0x65D2D0
	// RVA: -1 Offset: -1 Slot: 5
	private IEnumerator System.Collections.IEnumerable.GetEnumerator() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x26A55B8 Offset: 0x26A55B8 VA: 0x26A55B8
	|-Selecter.<SelectAll>d__1<object, object>.System.Collections.IEnumerable.GetEnumerator
	*/
}
