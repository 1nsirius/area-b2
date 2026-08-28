// Namespace: 
private class Enumerable.WhereSelectListIterator<TSource, TResult> : Enumerable.Iterator<TResult> // TypeDefIndex: 2889
{
	// Fields
	private List<TSource> source; // 0x0
	private Func<TSource, bool> predicate; // 0x0
	private Func<TSource, TResult> selector; // 0x0
	private List.Enumerator<TSource> enumerator; // 0x0

	// Methods

	// RVA: -1 Offset: -1
	public void .ctor(List<TSource> source, Func<TSource, bool> predicate, Func<TSource, TResult> selector) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1F9B198 Offset: 0x1F9B198 VA: 0x1F9B198
	|-Enumerable.WhereSelectListIterator<DictionaryEntry, KeyValuePair<object, object>>..ctor
	|
	|-RVA: 0x1F9B438 Offset: 0x1F9B438 VA: 0x1F9B438
	|-Enumerable.WhereSelectListIterator<DictionaryEntry, object>..ctor
	|
	|-RVA: 0x1F9B6C4 Offset: 0x1F9B6C4 VA: 0x1F9B6C4
	|-Enumerable.WhereSelectListIterator<KeyValuePair<U64Id, object>, U64Id>..ctor
	|
	|-RVA: 0x1F9B9A8 Offset: 0x1F9B9A8 VA: 0x1F9B9A8
	|-Enumerable.WhereSelectListIterator<KeyValuePair<U64Id, object>, object>..ctor
	|
	|-RVA: 0x1F9BC70 Offset: 0x1F9BC70 VA: 0x1F9BC70
	|-Enumerable.WhereSelectListIterator<KeyValuePair<U64Id, object>, float>..ctor
	|
	|-RVA: 0x1F9BF38 Offset: 0x1F9BF38 VA: 0x1F9BF38
	|-Enumerable.WhereSelectListIterator<KeyValuePair<object, object>, U64Id>..ctor
	|
	|-RVA: 0x1F9C1D4 Offset: 0x1F9C1D4 VA: 0x1F9C1D4
	|-Enumerable.WhereSelectListIterator<KeyValuePair<object, object>, object>..ctor
	|
	|-RVA: 0x1F9C460 Offset: 0x1F9C460 VA: 0x1F9C460
	|-Enumerable.WhereSelectListIterator<KeyValuePair<object, object>, float>..ctor
	|
	|-RVA: 0x1F9C6EC Offset: 0x1F9C6EC VA: 0x1F9C6EC
	|-Enumerable.WhereSelectListIterator<KeyValuePair<uint, object>, uint>..ctor
	|
	|-RVA: 0x1F9C978 Offset: 0x1F9C978 VA: 0x1F9C978
	|-Enumerable.WhereSelectListIterator<object, U64Id>..ctor
	|
	|-RVA: 0x1F9CBF8 Offset: 0x1F9CBF8 VA: 0x1F9CBF8
	|-Enumerable.WhereSelectListIterator<object, object>..ctor
	|
	|-RVA: 0x1F9CE70 Offset: 0x1F9CE70 VA: 0x1F9CE70
	|-Enumerable.WhereSelectListIterator<object, float>..ctor
	*/

	// RVA: -1 Offset: -1 Slot: 11
	public override Enumerable.Iterator<TResult> Clone() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1F9B1EC Offset: 0x1F9B1EC VA: 0x1F9B1EC
	|-Enumerable.WhereSelectListIterator<DictionaryEntry, KeyValuePair<object, object>>.Clone
	|
	|-RVA: 0x1F9B48C Offset: 0x1F9B48C VA: 0x1F9B48C
	|-Enumerable.WhereSelectListIterator<DictionaryEntry, object>.Clone
	|
	|-RVA: 0x1F9B718 Offset: 0x1F9B718 VA: 0x1F9B718
	|-Enumerable.WhereSelectListIterator<KeyValuePair<U64Id, object>, U64Id>.Clone
	|
	|-RVA: 0x1F9B9FC Offset: 0x1F9B9FC VA: 0x1F9B9FC
	|-Enumerable.WhereSelectListIterator<KeyValuePair<U64Id, object>, object>.Clone
	|
	|-RVA: 0x1F9BCC4 Offset: 0x1F9BCC4 VA: 0x1F9BCC4
	|-Enumerable.WhereSelectListIterator<KeyValuePair<U64Id, object>, float>.Clone
	|
	|-RVA: 0x1F9BF8C Offset: 0x1F9BF8C VA: 0x1F9BF8C
	|-Enumerable.WhereSelectListIterator<KeyValuePair<object, object>, U64Id>.Clone
	|
	|-RVA: 0x1F9C228 Offset: 0x1F9C228 VA: 0x1F9C228
	|-Enumerable.WhereSelectListIterator<KeyValuePair<object, object>, object>.Clone
	|
	|-RVA: 0x1F9C4B4 Offset: 0x1F9C4B4 VA: 0x1F9C4B4
	|-Enumerable.WhereSelectListIterator<KeyValuePair<object, object>, float>.Clone
	|
	|-RVA: 0x1F9C740 Offset: 0x1F9C740 VA: 0x1F9C740
	|-Enumerable.WhereSelectListIterator<KeyValuePair<uint, object>, uint>.Clone
	|
	|-RVA: 0x1F9C9CC Offset: 0x1F9C9CC VA: 0x1F9C9CC
	|-Enumerable.WhereSelectListIterator<object, U64Id>.Clone
	|
	|-RVA: 0x1F9CC4C Offset: 0x1F9CC4C VA: 0x1F9CC4C
	|-Enumerable.WhereSelectListIterator<object, object>.Clone
	|
	|-RVA: 0x1F9CEC4 Offset: 0x1F9CEC4 VA: 0x1F9CEC4
	|-Enumerable.WhereSelectListIterator<object, float>.Clone
	*/

	// RVA: -1 Offset: -1 Slot: 13
	public override bool MoveNext() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1F9B268 Offset: 0x1F9B268 VA: 0x1F9B268
	|-Enumerable.WhereSelectListIterator<DictionaryEntry, KeyValuePair<object, object>>.MoveNext
	|
	|-RVA: 0x1F9B508 Offset: 0x1F9B508 VA: 0x1F9B508
	|-Enumerable.WhereSelectListIterator<DictionaryEntry, object>.MoveNext
	|
	|-RVA: 0x1F9B794 Offset: 0x1F9B794 VA: 0x1F9B794
	|-Enumerable.WhereSelectListIterator<KeyValuePair<U64Id, object>, U64Id>.MoveNext
	|
	|-RVA: 0x1F9BA78 Offset: 0x1F9BA78 VA: 0x1F9BA78
	|-Enumerable.WhereSelectListIterator<KeyValuePair<U64Id, object>, object>.MoveNext
	|
	|-RVA: 0x1F9BD40 Offset: 0x1F9BD40 VA: 0x1F9BD40
	|-Enumerable.WhereSelectListIterator<KeyValuePair<U64Id, object>, float>.MoveNext
	|
	|-RVA: 0x1F9C008 Offset: 0x1F9C008 VA: 0x1F9C008
	|-Enumerable.WhereSelectListIterator<KeyValuePair<object, object>, U64Id>.MoveNext
	|
	|-RVA: 0x1F9C2A4 Offset: 0x1F9C2A4 VA: 0x1F9C2A4
	|-Enumerable.WhereSelectListIterator<KeyValuePair<object, object>, object>.MoveNext
	|
	|-RVA: 0x1F9C530 Offset: 0x1F9C530 VA: 0x1F9C530
	|-Enumerable.WhereSelectListIterator<KeyValuePair<object, object>, float>.MoveNext
	|
	|-RVA: 0x1F9C7BC Offset: 0x1F9C7BC VA: 0x1F9C7BC
	|-Enumerable.WhereSelectListIterator<KeyValuePair<uint, object>, uint>.MoveNext
	|
	|-RVA: 0x1F9CA48 Offset: 0x1F9CA48 VA: 0x1F9CA48
	|-Enumerable.WhereSelectListIterator<object, U64Id>.MoveNext
	|
	|-RVA: 0x1F9CCC8 Offset: 0x1F9CCC8 VA: 0x1F9CCC8
	|-Enumerable.WhereSelectListIterator<object, object>.MoveNext
	|
	|-RVA: 0x1F9CF40 Offset: 0x1F9CF40 VA: 0x1F9CF40
	|-Enumerable.WhereSelectListIterator<object, float>.MoveNext
	*/

	// RVA: -1 Offset: -1 Slot: 14
	public override IEnumerable<TResult2> Select<TResult2>(Func<TResult, TResult2> selector) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x9DB060 Offset: 0x9DB060 VA: 0x9DB060
	|-Enumerable.WhereSelectListIterator<DictionaryEntry, KeyValuePair<object, object>>.Select<object>
	|
	|-RVA: 0x9DB0E8 Offset: 0x9DB0E8 VA: 0x9DB0E8
	|-Enumerable.WhereSelectListIterator<KeyValuePair<U64Id, object>, object>.Select<U64Id>
	|
	|-RVA: 0x9DB170 Offset: 0x9DB170 VA: 0x9DB170
	|-Enumerable.WhereSelectListIterator<KeyValuePair<U64Id, object>, object>.Select<object>
	|
	|-RVA: 0x9DB1F8 Offset: 0x9DB1F8 VA: 0x9DB1F8
	|-Enumerable.WhereSelectListIterator<KeyValuePair<U64Id, object>, object>.Select<float>
	|
	|-RVA: 0x9DB280 Offset: 0x9DB280 VA: 0x9DB280
	|-Enumerable.WhereSelectListIterator<KeyValuePair<object, object>, object>.Select<U64Id>
	|
	|-RVA: 0x9DB308 Offset: 0x9DB308 VA: 0x9DB308
	|-Enumerable.WhereSelectListIterator<KeyValuePair<object, object>, object>.Select<object>
	|
	|-RVA: 0x9DB390 Offset: 0x9DB390 VA: 0x9DB390
	|-Enumerable.WhereSelectListIterator<KeyValuePair<object, object>, object>.Select<float>
	|
	|-RVA: 0x9DB418 Offset: 0x9DB418 VA: 0x9DB418
	|-Enumerable.WhereSelectListIterator<object, object>.Select<U64Id>
	|
	|-RVA: 0x9DB4A0 Offset: 0x9DB4A0 VA: 0x9DB4A0
	|-Enumerable.WhereSelectListIterator<object, object>.Select<object>
	|
	|-RVA: 0x9DB528 Offset: 0x9DB528 VA: 0x9DB528
	|-Enumerable.WhereSelectListIterator<object, object>.Select<float>
	*/

	// RVA: -1 Offset: -1 Slot: 15
	public override IEnumerable<TResult> Where(Func<TResult, bool> predicate) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1F9B3D0 Offset: 0x1F9B3D0 VA: 0x1F9B3D0
	|-Enumerable.WhereSelectListIterator<DictionaryEntry, KeyValuePair<object, object>>.Where
	|
	|-RVA: 0x1F9B65C Offset: 0x1F9B65C VA: 0x1F9B65C
	|-Enumerable.WhereSelectListIterator<DictionaryEntry, object>.Where
	|
	|-RVA: 0x1F9B940 Offset: 0x1F9B940 VA: 0x1F9B940
	|-Enumerable.WhereSelectListIterator<KeyValuePair<U64Id, object>, U64Id>.Where
	|
	|-RVA: 0x1F9BC08 Offset: 0x1F9BC08 VA: 0x1F9BC08
	|-Enumerable.WhereSelectListIterator<KeyValuePair<U64Id, object>, object>.Where
	|
	|-RVA: 0x1F9BED0 Offset: 0x1F9BED0 VA: 0x1F9BED0
	|-Enumerable.WhereSelectListIterator<KeyValuePair<U64Id, object>, float>.Where
	|
	|-RVA: 0x1F9C16C Offset: 0x1F9C16C VA: 0x1F9C16C
	|-Enumerable.WhereSelectListIterator<KeyValuePair<object, object>, U64Id>.Where
	|
	|-RVA: 0x1F9C3F8 Offset: 0x1F9C3F8 VA: 0x1F9C3F8
	|-Enumerable.WhereSelectListIterator<KeyValuePair<object, object>, object>.Where
	|
	|-RVA: 0x1F9C684 Offset: 0x1F9C684 VA: 0x1F9C684
	|-Enumerable.WhereSelectListIterator<KeyValuePair<object, object>, float>.Where
	|
	|-RVA: 0x1F9C910 Offset: 0x1F9C910 VA: 0x1F9C910
	|-Enumerable.WhereSelectListIterator<KeyValuePair<uint, object>, uint>.Where
	|
	|-RVA: 0x1F9CB90 Offset: 0x1F9CB90 VA: 0x1F9CB90
	|-Enumerable.WhereSelectListIterator<object, U64Id>.Where
	|
	|-RVA: 0x1F9CE08 Offset: 0x1F9CE08 VA: 0x1F9CE08
	|-Enumerable.WhereSelectListIterator<object, object>.Where
	|
	|-RVA: 0x1F9D080 Offset: 0x1F9D080 VA: 0x1F9D080
	|-Enumerable.WhereSelectListIterator<object, float>.Where
	*/
}
