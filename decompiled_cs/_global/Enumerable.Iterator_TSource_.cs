// Namespace: 
private abstract class Enumerable.Iterator<TSource> : IEnumerable<TSource>, IEnumerable, IEnumerator<TSource>, IDisposable, IEnumerator // TypeDefIndex: 2883
{
	// Fields
	private int threadId; // 0x0
	internal int state; // 0x0
	internal TSource current; // 0x0

	// Properties
	public TSource Current { get; }
	private object System.Collections.IEnumerator.Current { get; }

	// Methods

	// RVA: -1 Offset: -1
	public void .ctor() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1F92054 Offset: 0x1F92054 VA: 0x1F92054
	|-Enumerable.Iterator<U64Id>..ctor
	|
	|-RVA: 0x1F922A0 Offset: 0x1F922A0 VA: 0x1F922A0
	|-Enumerable.Iterator<DictionaryEntry>..ctor
	|
	|-RVA: 0x1F924F4 Offset: 0x1F924F4 VA: 0x1F924F4
	|-Enumerable.Iterator<KeyValuePair<U64Id, object>>..ctor
	|
	|-RVA: 0x1F92748 Offset: 0x1F92748 VA: 0x1F92748
	|-Enumerable.Iterator<KeyValuePair<object, object>>..ctor
	|
	|-RVA: 0x1F9299C Offset: 0x1F9299C VA: 0x1F9299C
	|-Enumerable.Iterator<KeyValuePair<uint, object>>..ctor
	|
	|-RVA: 0x1F92BF0 Offset: 0x1F92BF0 VA: 0x1F92BF0
	|-Enumerable.Iterator<object>..ctor
	|
	|-RVA: 0x1F92DF0 Offset: 0x1F92DF0 VA: 0x1F92DF0
	|-Enumerable.Iterator<float>..ctor
	|
	|-RVA: 0x1F93028 Offset: 0x1F93028 VA: 0x1F93028
	|-Enumerable.Iterator<uint>..ctor
	*/

	// RVA: -1 Offset: -1 Slot: 6
	public TSource get_Current() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1F920AC Offset: 0x1F920AC VA: 0x1F920AC
	|-Enumerable.Iterator<U64Id>.get_Current
	|
	|-RVA: 0x1F922F8 Offset: 0x1F922F8 VA: 0x1F922F8
	|-Enumerable.Iterator<DictionaryEntry>.get_Current
	|
	|-RVA: 0x1F9254C Offset: 0x1F9254C VA: 0x1F9254C
	|-Enumerable.Iterator<KeyValuePair<U64Id, object>>.get_Current
	|
	|-RVA: 0x1F927A0 Offset: 0x1F927A0 VA: 0x1F927A0
	|-Enumerable.Iterator<KeyValuePair<object, object>>.get_Current
	|
	|-RVA: 0x1F929F4 Offset: 0x1F929F4 VA: 0x1F929F4
	|-Enumerable.Iterator<KeyValuePair<uint, object>>.get_Current
	|
	|-RVA: 0x1F92C48 Offset: 0x1F92C48 VA: 0x1F92C48
	|-Enumerable.Iterator<object>.get_Current
	|
	|-RVA: 0x1F92E48 Offset: 0x1F92E48 VA: 0x1F92E48
	|-Enumerable.Iterator<float>.get_Current
	|
	|-RVA: 0x1F93080 Offset: 0x1F93080 VA: 0x1F93080
	|-Enumerable.Iterator<uint>.get_Current
	*/

	// RVA: -1 Offset: -1 Slot: 11
	public abstract Enumerable.Iterator<TSource> Clone();
	/* GenericInstMethod :
	|
	|-RVA: -1 Offset: -1
	|-Enumerable.Iterator<object>.Clone
	*/

	// RVA: -1 Offset: -1 Slot: 12
	public virtual void Dispose() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1F920B8 Offset: 0x1F920B8 VA: 0x1F920B8
	|-Enumerable.Iterator<U64Id>.Dispose
	|
	|-RVA: 0x1F9230C Offset: 0x1F9230C VA: 0x1F9230C
	|-Enumerable.Iterator<DictionaryEntry>.Dispose
	|
	|-RVA: 0x1F9255C Offset: 0x1F9255C VA: 0x1F9255C
	|-Enumerable.Iterator<KeyValuePair<U64Id, object>>.Dispose
	|
	|-RVA: 0x1F927B4 Offset: 0x1F927B4 VA: 0x1F927B4
	|-Enumerable.Iterator<KeyValuePair<object, object>>.Dispose
	|
	|-RVA: 0x1F92A08 Offset: 0x1F92A08 VA: 0x1F92A08
	|-Enumerable.Iterator<KeyValuePair<uint, object>>.Dispose
	|
	|-RVA: 0x1F92C50 Offset: 0x1F92C50 VA: 0x1F92C50
	|-Enumerable.Iterator<object>.Dispose
	|
	|-RVA: 0x1F92E50 Offset: 0x1F92E50 VA: 0x1F92E50
	|-Enumerable.Iterator<float>.Dispose
	|
	|-RVA: 0x1F93088 Offset: 0x1F93088 VA: 0x1F93088
	|-Enumerable.Iterator<uint>.Dispose
	*/

	// RVA: -1 Offset: -1 Slot: 4
	public IEnumerator<TSource> GetEnumerator() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1F920D0 Offset: 0x1F920D0 VA: 0x1F920D0
	|-Enumerable.Iterator<U64Id>.GetEnumerator
	|
	|-RVA: 0x1F92324 Offset: 0x1F92324 VA: 0x1F92324
	|-Enumerable.Iterator<DictionaryEntry>.GetEnumerator
	|
	|-RVA: 0x1F92574 Offset: 0x1F92574 VA: 0x1F92574
	|-Enumerable.Iterator<KeyValuePair<U64Id, object>>.GetEnumerator
	|
	|-RVA: 0x1F927CC Offset: 0x1F927CC VA: 0x1F927CC
	|-Enumerable.Iterator<KeyValuePair<object, object>>.GetEnumerator
	|
	|-RVA: 0x1F92A20 Offset: 0x1F92A20 VA: 0x1F92A20
	|-Enumerable.Iterator<KeyValuePair<uint, object>>.GetEnumerator
	|
	|-RVA: 0x1F92C64 Offset: 0x1F92C64 VA: 0x1F92C64
	|-Enumerable.Iterator<object>.GetEnumerator
	|
	|-RVA: 0x1F92E64 Offset: 0x1F92E64 VA: 0x1F92E64
	|-Enumerable.Iterator<float>.GetEnumerator
	|
	|-RVA: 0x1F9309C Offset: 0x1F9309C VA: 0x1F9309C
	|-Enumerable.Iterator<uint>.GetEnumerator
	*/

	// RVA: -1 Offset: -1 Slot: 13
	public abstract bool MoveNext();
	/* GenericInstMethod :
	|
	|-RVA: -1 Offset: -1
	|-Enumerable.Iterator<object>.MoveNext
	*/

	// RVA: -1 Offset: -1 Slot: 14
	public abstract IEnumerable<TResult> Select<TResult>(Func<TSource, TResult> selector);
	/* GenericInstMethod :
	|
	|-RVA: -1 Offset: -1
	|-Enumerable.Iterator<object>.Select<object>
	*/

	// RVA: -1 Offset: -1 Slot: 15
	public abstract IEnumerable<TSource> Where(Func<TSource, bool> predicate);
	/* GenericInstMethod :
	|
	|-RVA: -1 Offset: -1
	|-Enumerable.Iterator<object>.Where
	*/

	// RVA: -1 Offset: -1 Slot: 9
	private object System.Collections.IEnumerator.get_Current() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1F9215C Offset: 0x1F9215C VA: 0x1F9215C
	|-Enumerable.Iterator<U64Id>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x1F923B0 Offset: 0x1F923B0 VA: 0x1F923B0
	|-Enumerable.Iterator<DictionaryEntry>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x1F92600 Offset: 0x1F92600 VA: 0x1F92600
	|-Enumerable.Iterator<KeyValuePair<U64Id, object>>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x1F92858 Offset: 0x1F92858 VA: 0x1F92858
	|-Enumerable.Iterator<KeyValuePair<object, object>>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x1F92AAC Offset: 0x1F92AAC VA: 0x1F92AAC
	|-Enumerable.Iterator<KeyValuePair<uint, object>>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x1F92CF0 Offset: 0x1F92CF0 VA: 0x1F92CF0
	|-Enumerable.Iterator<object>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x1F92EF0 Offset: 0x1F92EF0 VA: 0x1F92EF0
	|-Enumerable.Iterator<float>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x1F93128 Offset: 0x1F93128 VA: 0x1F93128
	|-Enumerable.Iterator<uint>.System.Collections.IEnumerator.get_Current
	*/

	// RVA: -1 Offset: -1 Slot: 5
	private IEnumerator System.Collections.IEnumerable.GetEnumerator() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1F921DC Offset: 0x1F921DC VA: 0x1F921DC
	|-Enumerable.Iterator<U64Id>.System.Collections.IEnumerable.GetEnumerator
	|
	|-RVA: 0x1F92430 Offset: 0x1F92430 VA: 0x1F92430
	|-Enumerable.Iterator<DictionaryEntry>.System.Collections.IEnumerable.GetEnumerator
	|
	|-RVA: 0x1F92684 Offset: 0x1F92684 VA: 0x1F92684
	|-Enumerable.Iterator<KeyValuePair<U64Id, object>>.System.Collections.IEnumerable.GetEnumerator
	|
	|-RVA: 0x1F928D8 Offset: 0x1F928D8 VA: 0x1F928D8
	|-Enumerable.Iterator<KeyValuePair<object, object>>.System.Collections.IEnumerable.GetEnumerator
	|
	|-RVA: 0x1F92B2C Offset: 0x1F92B2C VA: 0x1F92B2C
	|-Enumerable.Iterator<KeyValuePair<uint, object>>.System.Collections.IEnumerable.GetEnumerator
	|
	|-RVA: 0x1F92D2C Offset: 0x1F92D2C VA: 0x1F92D2C
	|-Enumerable.Iterator<object>.System.Collections.IEnumerable.GetEnumerator
	|
	|-RVA: 0x1F92F64 Offset: 0x1F92F64 VA: 0x1F92F64
	|-Enumerable.Iterator<float>.System.Collections.IEnumerable.GetEnumerator
	|
	|-RVA: 0x1F9319C Offset: 0x1F9319C VA: 0x1F9319C
	|-Enumerable.Iterator<uint>.System.Collections.IEnumerable.GetEnumerator
	*/

	// RVA: -1 Offset: -1 Slot: 10
	private void System.Collections.IEnumerator.Reset() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1F92218 Offset: 0x1F92218 VA: 0x1F92218
	|-Enumerable.Iterator<U64Id>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x1F9246C Offset: 0x1F9246C VA: 0x1F9246C
	|-Enumerable.Iterator<DictionaryEntry>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x1F926C0 Offset: 0x1F926C0 VA: 0x1F926C0
	|-Enumerable.Iterator<KeyValuePair<U64Id, object>>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x1F92914 Offset: 0x1F92914 VA: 0x1F92914
	|-Enumerable.Iterator<KeyValuePair<object, object>>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x1F92B68 Offset: 0x1F92B68 VA: 0x1F92B68
	|-Enumerable.Iterator<KeyValuePair<uint, object>>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x1F92D68 Offset: 0x1F92D68 VA: 0x1F92D68
	|-Enumerable.Iterator<object>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x1F92FA0 Offset: 0x1F92FA0 VA: 0x1F92FA0
	|-Enumerable.Iterator<float>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x1F931D8 Offset: 0x1F931D8 VA: 0x1F931D8
	|-Enumerable.Iterator<uint>.System.Collections.IEnumerator.Reset
	*/
}
