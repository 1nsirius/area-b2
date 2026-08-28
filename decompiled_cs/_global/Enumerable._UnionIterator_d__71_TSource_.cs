// Namespace: 
[CompilerGeneratedAttribute] // RVA: 0x4EE18C Offset: 0x4EE18C VA: 0x4EE18C
private sealed class Enumerable.<UnionIterator>d__71<TSource> : IEnumerable<TSource>, IEnumerable, IEnumerator<TSource>, IDisposable, IEnumerator // TypeDefIndex: 2897
{
	// Fields
	private int <>1__state; // 0x0
	private TSource <>2__current; // 0x0
	private int <>l__initialThreadId; // 0x0
	private IEqualityComparer<TSource> comparer; // 0x0
	public IEqualityComparer<TSource> <>3__comparer; // 0x0
	private IEnumerable<TSource> first; // 0x0
	public IEnumerable<TSource> <>3__first; // 0x0
	private Set<TSource> <set>5__1; // 0x0
	private IEnumerable<TSource> second; // 0x0
	public IEnumerable<TSource> <>3__second; // 0x0
	private IEnumerator<TSource> <>7__wrap1; // 0x0

	// Properties
	private TSource System.Collections.Generic.IEnumerator<TSource>.Current { get; }
	private object System.Collections.IEnumerator.Current { get; }

	// Methods

	[DebuggerHiddenAttribute] // RVA: 0x4EF1F0 Offset: 0x4EF1F0 VA: 0x4EF1F0
	// RVA: -1 Offset: -1
	public void .ctor(int <>1__state) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1F90AC4 Offset: 0x1F90AC4 VA: 0x1F90AC4
	|-Enumerable.<UnionIterator>d__71<char>..ctor
	|
	|-RVA: 0x1F915AC Offset: 0x1F915AC VA: 0x1F915AC
	|-Enumerable.<UnionIterator>d__71<object>..ctor
	*/

	[DebuggerHiddenAttribute] // RVA: 0x4EF200 Offset: 0x4EF200 VA: 0x4EF200
	// RVA: -1 Offset: -1 Slot: 7
	private void System.IDisposable.Dispose() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1F90B04 Offset: 0x1F90B04 VA: 0x1F90B04
	|-Enumerable.<UnionIterator>d__71<char>.System.IDisposable.Dispose
	|
	|-RVA: 0x1F915EC Offset: 0x1F915EC VA: 0x1F915EC
	|-Enumerable.<UnionIterator>d__71<object>.System.IDisposable.Dispose
	*/

	// RVA: -1 Offset: -1 Slot: 8
	private bool MoveNext() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1F90B6C Offset: 0x1F90B6C VA: 0x1F90B6C
	|-Enumerable.<UnionIterator>d__71<char>.MoveNext
	|
	|-RVA: 0x1F91654 Offset: 0x1F91654 VA: 0x1F91654
	|-Enumerable.<UnionIterator>d__71<object>.MoveNext
	*/

	// RVA: -1 Offset: -1
	private void <>m__Finally1() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1F91204 Offset: 0x1F91204 VA: 0x1F91204
	|-Enumerable.<UnionIterator>d__71<char>.<>m__Finally1
	|
	|-RVA: 0x1F91CEC Offset: 0x1F91CEC VA: 0x1F91CEC
	|-Enumerable.<UnionIterator>d__71<object>.<>m__Finally1
	*/

	// RVA: -1 Offset: -1
	private void <>m__Finally2() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1F912DC Offset: 0x1F912DC VA: 0x1F912DC
	|-Enumerable.<UnionIterator>d__71<char>.<>m__Finally2
	|
	|-RVA: 0x1F91DC4 Offset: 0x1F91DC4 VA: 0x1F91DC4
	|-Enumerable.<UnionIterator>d__71<object>.<>m__Finally2
	*/

	[DebuggerHiddenAttribute] // RVA: 0x4EF210 Offset: 0x4EF210 VA: 0x4EF210
	// RVA: -1 Offset: -1 Slot: 6
	private TSource System.Collections.Generic.IEnumerator<TSource>.get_Current() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1F913B4 Offset: 0x1F913B4 VA: 0x1F913B4
	|-Enumerable.<UnionIterator>d__71<char>.System.Collections.Generic.IEnumerator<TSource>.get_Current
	|
	|-RVA: 0x1F91E9C Offset: 0x1F91E9C VA: 0x1F91E9C
	|-Enumerable.<UnionIterator>d__71<object>.System.Collections.Generic.IEnumerator<TSource>.get_Current
	*/

	[DebuggerHiddenAttribute] // RVA: 0x4EF220 Offset: 0x4EF220 VA: 0x4EF220
	// RVA: -1 Offset: -1 Slot: 10
	private void System.Collections.IEnumerator.Reset() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1F913BC Offset: 0x1F913BC VA: 0x1F913BC
	|-Enumerable.<UnionIterator>d__71<char>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x1F91EA4 Offset: 0x1F91EA4 VA: 0x1F91EA4
	|-Enumerable.<UnionIterator>d__71<object>.System.Collections.IEnumerator.Reset
	*/

	[DebuggerHiddenAttribute] // RVA: 0x4EF230 Offset: 0x4EF230 VA: 0x4EF230
	// RVA: -1 Offset: -1 Slot: 9
	private object System.Collections.IEnumerator.get_Current() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1F91444 Offset: 0x1F91444 VA: 0x1F91444
	|-Enumerable.<UnionIterator>d__71<char>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x1F91F2C Offset: 0x1F91F2C VA: 0x1F91F2C
	|-Enumerable.<UnionIterator>d__71<object>.System.Collections.IEnumerator.get_Current
	*/

	[DebuggerHiddenAttribute] // RVA: 0x4EF240 Offset: 0x4EF240 VA: 0x4EF240
	// RVA: -1 Offset: -1 Slot: 4
	private IEnumerator<TSource> System.Collections.Generic.IEnumerable<TSource>.GetEnumerator() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1F9148C Offset: 0x1F9148C VA: 0x1F9148C
	|-Enumerable.<UnionIterator>d__71<char>.System.Collections.Generic.IEnumerable<TSource>.GetEnumerator
	|
	|-RVA: 0x1F91F34 Offset: 0x1F91F34 VA: 0x1F91F34
	|-Enumerable.<UnionIterator>d__71<object>.System.Collections.Generic.IEnumerable<TSource>.GetEnumerator
	*/

	[DebuggerHiddenAttribute] // RVA: 0x4EF250 Offset: 0x4EF250 VA: 0x4EF250
	// RVA: -1 Offset: -1 Slot: 5
	private IEnumerator System.Collections.IEnumerable.GetEnumerator() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1F91570 Offset: 0x1F91570 VA: 0x1F91570
	|-Enumerable.<UnionIterator>d__71<char>.System.Collections.IEnumerable.GetEnumerator
	|
	|-RVA: 0x1F92018 Offset: 0x1F92018 VA: 0x1F92018
	|-Enumerable.<UnionIterator>d__71<object>.System.Collections.IEnumerable.GetEnumerator
	*/
}
