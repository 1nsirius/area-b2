// Namespace: 
[CompilerGeneratedAttribute] // RVA: 0x4EE16C Offset: 0x4EE16C VA: 0x4EE16C
private sealed class Enumerable.<JoinIterator>d__38<TOuter, TInner, TKey, TResult> : IEnumerable<TResult>, IEnumerable, IEnumerator<TResult>, IDisposable, IEnumerator // TypeDefIndex: 2895
{
	// Fields
	private int <>1__state; // 0x0
	private TResult <>2__current; // 0x0
	private int <>l__initialThreadId; // 0x0
	private IEnumerable<TInner> inner; // 0x0
	public IEnumerable<TInner> <>3__inner; // 0x0
	private Func<TInner, TKey> innerKeySelector; // 0x0
	public Func<TInner, TKey> <>3__innerKeySelector; // 0x0
	private IEqualityComparer<TKey> comparer; // 0x0
	public IEqualityComparer<TKey> <>3__comparer; // 0x0
	private IEnumerable<TOuter> outer; // 0x0
	public IEnumerable<TOuter> <>3__outer; // 0x0
	private Lookup<TKey, TInner> <lookup>5__1; // 0x0
	private Func<TOuter, TKey> outerKeySelector; // 0x0
	public Func<TOuter, TKey> <>3__outerKeySelector; // 0x0
	private Func<TOuter, TInner, TResult> resultSelector; // 0x0
	public Func<TOuter, TInner, TResult> <>3__resultSelector; // 0x0
	private TOuter <item>5__2; // 0x0
	private Lookup.Grouping<TKey, TInner> <g>5__3; // 0x0
	private int <i>5__4; // 0x0
	private IEnumerator<TOuter> <>7__wrap1; // 0x0

	// Properties
	private TResult System.Collections.Generic.IEnumerator<TResult>.Current { get; }
	private object System.Collections.IEnumerator.Current { get; }

	// Methods

	[DebuggerHiddenAttribute] // RVA: 0x4EF110 Offset: 0x4EF110 VA: 0x4EF110
	// RVA: -1 Offset: -1
	public void .ctor(int <>1__state) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1F8E1E8 Offset: 0x1F8E1E8 VA: 0x1F8E1E8
	|-Enumerable.<JoinIterator>d__38<object, object, object, object>..ctor
	*/

	[DebuggerHiddenAttribute] // RVA: 0x4EF120 Offset: 0x4EF120 VA: 0x4EF120
	// RVA: -1 Offset: -1 Slot: 7
	private void System.IDisposable.Dispose() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1F8E228 Offset: 0x1F8E228 VA: 0x1F8E228
	|-Enumerable.<JoinIterator>d__38<object, object, object, object>.System.IDisposable.Dispose
	*/

	// RVA: -1 Offset: -1 Slot: 8
	private bool MoveNext() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1F8E250 Offset: 0x1F8E250 VA: 0x1F8E250
	|-Enumerable.<JoinIterator>d__38<object, object, object, object>.MoveNext
	*/

	// RVA: -1 Offset: -1
	private void <>m__Finally1() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1F8E72C Offset: 0x1F8E72C VA: 0x1F8E72C
	|-Enumerable.<JoinIterator>d__38<object, object, object, object>.<>m__Finally1
	*/

	[DebuggerHiddenAttribute] // RVA: 0x4EF130 Offset: 0x4EF130 VA: 0x4EF130
	// RVA: -1 Offset: -1 Slot: 6
	private TResult System.Collections.Generic.IEnumerator<TResult>.get_Current() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1F8E804 Offset: 0x1F8E804 VA: 0x1F8E804
	|-Enumerable.<JoinIterator>d__38<object, object, object, object>.System.Collections.Generic.IEnumerator<TResult>.get_Current
	*/

	[DebuggerHiddenAttribute] // RVA: 0x4EF140 Offset: 0x4EF140 VA: 0x4EF140
	// RVA: -1 Offset: -1 Slot: 10
	private void System.Collections.IEnumerator.Reset() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1F8E80C Offset: 0x1F8E80C VA: 0x1F8E80C
	|-Enumerable.<JoinIterator>d__38<object, object, object, object>.System.Collections.IEnumerator.Reset
	*/

	[DebuggerHiddenAttribute] // RVA: 0x4EF150 Offset: 0x4EF150 VA: 0x4EF150
	// RVA: -1 Offset: -1 Slot: 9
	private object System.Collections.IEnumerator.get_Current() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1F8E894 Offset: 0x1F8E894 VA: 0x1F8E894
	|-Enumerable.<JoinIterator>d__38<object, object, object, object>.System.Collections.IEnumerator.get_Current
	*/

	[DebuggerHiddenAttribute] // RVA: 0x4EF160 Offset: 0x4EF160 VA: 0x4EF160
	// RVA: -1 Offset: -1 Slot: 4
	private IEnumerator<TResult> System.Collections.Generic.IEnumerable<TResult>.GetEnumerator() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1F8E89C Offset: 0x1F8E89C VA: 0x1F8E89C
	|-Enumerable.<JoinIterator>d__38<object, object, object, object>.System.Collections.Generic.IEnumerable<TResult>.GetEnumerator
	*/

	[DebuggerHiddenAttribute] // RVA: 0x4EF170 Offset: 0x4EF170 VA: 0x4EF170
	// RVA: -1 Offset: -1 Slot: 5
	private IEnumerator System.Collections.IEnumerable.GetEnumerator() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1F8E9D4 Offset: 0x1F8E9D4 VA: 0x1F8E9D4
	|-Enumerable.<JoinIterator>d__38<object, object, object, object>.System.Collections.IEnumerable.GetEnumerator
	*/
}
