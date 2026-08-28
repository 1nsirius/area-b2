// Namespace: 
private class Enumerable.WhereSelectArrayIterator<TSource, TResult> : Enumerable.Iterator<TResult> // TypeDefIndex: 2888
{
	// Fields
	private TSource[] source; // 0x0
	private Func<TSource, bool> predicate; // 0x0
	private Func<TSource, TResult> selector; // 0x0
	private int index; // 0x0

	// Methods

	// RVA: -1 Offset: -1
	public void .ctor(TSource[] source, Func<TSource, bool> predicate, Func<TSource, TResult> selector) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1F954E0 Offset: 0x1F954E0 VA: 0x1F954E0
	|-Enumerable.WhereSelectArrayIterator<DictionaryEntry, KeyValuePair<object, object>>..ctor
	|
	|-RVA: 0x1F95750 Offset: 0x1F95750 VA: 0x1F95750
	|-Enumerable.WhereSelectArrayIterator<DictionaryEntry, object>..ctor
	|
	|-RVA: 0x1F959A4 Offset: 0x1F959A4 VA: 0x1F959A4
	|-Enumerable.WhereSelectArrayIterator<KeyValuePair<U64Id, object>, U64Id>..ctor
	|
	|-RVA: 0x1F95C24 Offset: 0x1F95C24 VA: 0x1F95C24
	|-Enumerable.WhereSelectArrayIterator<KeyValuePair<U64Id, object>, object>..ctor
	|
	|-RVA: 0x1F95E98 Offset: 0x1F95E98 VA: 0x1F95E98
	|-Enumerable.WhereSelectArrayIterator<KeyValuePair<U64Id, object>, float>..ctor
	|
	|-RVA: 0x1F9610C Offset: 0x1F9610C VA: 0x1F9610C
	|-Enumerable.WhereSelectArrayIterator<KeyValuePair<object, object>, U64Id>..ctor
	|
	|-RVA: 0x1F96378 Offset: 0x1F96378 VA: 0x1F96378
	|-Enumerable.WhereSelectArrayIterator<KeyValuePair<object, object>, object>..ctor
	|
	|-RVA: 0x1F965CC Offset: 0x1F965CC VA: 0x1F965CC
	|-Enumerable.WhereSelectArrayIterator<KeyValuePair<object, object>, float>..ctor
	|
	|-RVA: 0x1F96820 Offset: 0x1F96820 VA: 0x1F96820
	|-Enumerable.WhereSelectArrayIterator<KeyValuePair<uint, object>, uint>..ctor
	|
	|-RVA: 0x1F96A74 Offset: 0x1F96A74 VA: 0x1F96A74
	|-Enumerable.WhereSelectArrayIterator<object, U64Id>..ctor
	|
	|-RVA: 0x1F96CCC Offset: 0x1F96CCC VA: 0x1F96CCC
	|-Enumerable.WhereSelectArrayIterator<object, object>..ctor
	|
	|-RVA: 0x1F96F14 Offset: 0x1F96F14 VA: 0x1F96F14
	|-Enumerable.WhereSelectArrayIterator<object, float>..ctor
	*/

	// RVA: -1 Offset: -1 Slot: 11
	public override Enumerable.Iterator<TResult> Clone() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1F95534 Offset: 0x1F95534 VA: 0x1F95534
	|-Enumerable.WhereSelectArrayIterator<DictionaryEntry, KeyValuePair<object, object>>.Clone
	|
	|-RVA: 0x1F957A4 Offset: 0x1F957A4 VA: 0x1F957A4
	|-Enumerable.WhereSelectArrayIterator<DictionaryEntry, object>.Clone
	|
	|-RVA: 0x1F959F8 Offset: 0x1F959F8 VA: 0x1F959F8
	|-Enumerable.WhereSelectArrayIterator<KeyValuePair<U64Id, object>, U64Id>.Clone
	|
	|-RVA: 0x1F95C78 Offset: 0x1F95C78 VA: 0x1F95C78
	|-Enumerable.WhereSelectArrayIterator<KeyValuePair<U64Id, object>, object>.Clone
	|
	|-RVA: 0x1F95EEC Offset: 0x1F95EEC VA: 0x1F95EEC
	|-Enumerable.WhereSelectArrayIterator<KeyValuePair<U64Id, object>, float>.Clone
	|
	|-RVA: 0x1F96160 Offset: 0x1F96160 VA: 0x1F96160
	|-Enumerable.WhereSelectArrayIterator<KeyValuePair<object, object>, U64Id>.Clone
	|
	|-RVA: 0x1F963CC Offset: 0x1F963CC VA: 0x1F963CC
	|-Enumerable.WhereSelectArrayIterator<KeyValuePair<object, object>, object>.Clone
	|
	|-RVA: 0x1F96620 Offset: 0x1F96620 VA: 0x1F96620
	|-Enumerable.WhereSelectArrayIterator<KeyValuePair<object, object>, float>.Clone
	|
	|-RVA: 0x1F96874 Offset: 0x1F96874 VA: 0x1F96874
	|-Enumerable.WhereSelectArrayIterator<KeyValuePair<uint, object>, uint>.Clone
	|
	|-RVA: 0x1F96AC8 Offset: 0x1F96AC8 VA: 0x1F96AC8
	|-Enumerable.WhereSelectArrayIterator<object, U64Id>.Clone
	|
	|-RVA: 0x1F96D20 Offset: 0x1F96D20 VA: 0x1F96D20
	|-Enumerable.WhereSelectArrayIterator<object, object>.Clone
	|
	|-RVA: 0x1F96F68 Offset: 0x1F96F68 VA: 0x1F96F68
	|-Enumerable.WhereSelectArrayIterator<object, float>.Clone
	*/

	// RVA: -1 Offset: -1 Slot: 13
	public override bool MoveNext() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1F955B0 Offset: 0x1F955B0 VA: 0x1F955B0
	|-Enumerable.WhereSelectArrayIterator<DictionaryEntry, KeyValuePair<object, object>>.MoveNext
	|
	|-RVA: 0x1F95820 Offset: 0x1F95820 VA: 0x1F95820
	|-Enumerable.WhereSelectArrayIterator<DictionaryEntry, object>.MoveNext
	|
	|-RVA: 0x1F95A74 Offset: 0x1F95A74 VA: 0x1F95A74
	|-Enumerable.WhereSelectArrayIterator<KeyValuePair<U64Id, object>, U64Id>.MoveNext
	|
	|-RVA: 0x1F95CF4 Offset: 0x1F95CF4 VA: 0x1F95CF4
	|-Enumerable.WhereSelectArrayIterator<KeyValuePair<U64Id, object>, object>.MoveNext
	|
	|-RVA: 0x1F95F68 Offset: 0x1F95F68 VA: 0x1F95F68
	|-Enumerable.WhereSelectArrayIterator<KeyValuePair<U64Id, object>, float>.MoveNext
	|
	|-RVA: 0x1F961DC Offset: 0x1F961DC VA: 0x1F961DC
	|-Enumerable.WhereSelectArrayIterator<KeyValuePair<object, object>, U64Id>.MoveNext
	|
	|-RVA: 0x1F96448 Offset: 0x1F96448 VA: 0x1F96448
	|-Enumerable.WhereSelectArrayIterator<KeyValuePair<object, object>, object>.MoveNext
	|
	|-RVA: 0x1F9669C Offset: 0x1F9669C VA: 0x1F9669C
	|-Enumerable.WhereSelectArrayIterator<KeyValuePair<object, object>, float>.MoveNext
	|
	|-RVA: 0x1F968F0 Offset: 0x1F968F0 VA: 0x1F968F0
	|-Enumerable.WhereSelectArrayIterator<KeyValuePair<uint, object>, uint>.MoveNext
	|
	|-RVA: 0x1F96B44 Offset: 0x1F96B44 VA: 0x1F96B44
	|-Enumerable.WhereSelectArrayIterator<object, U64Id>.MoveNext
	|
	|-RVA: 0x1F96D9C Offset: 0x1F96D9C VA: 0x1F96D9C
	|-Enumerable.WhereSelectArrayIterator<object, object>.MoveNext
	|
	|-RVA: 0x1F96FE4 Offset: 0x1F96FE4 VA: 0x1F96FE4
	|-Enumerable.WhereSelectArrayIterator<object, float>.MoveNext
	*/

	// RVA: -1 Offset: -1 Slot: 14
	public override IEnumerable<TResult2> Select<TResult2>(Func<TResult, TResult2> selector) { }
	/* GenericInstMethod :
	|
	|-RVA: 0xD4A3F0 Offset: 0xD4A3F0 VA: 0xD4A3F0
	|-Enumerable.WhereSelectArrayIterator<DictionaryEntry, KeyValuePair<object, object>>.Select<object>
	|
	|-RVA: 0xD4A478 Offset: 0xD4A478 VA: 0xD4A478
	|-Enumerable.WhereSelectArrayIterator<KeyValuePair<U64Id, object>, object>.Select<U64Id>
	|
	|-RVA: 0xD4A500 Offset: 0xD4A500 VA: 0xD4A500
	|-Enumerable.WhereSelectArrayIterator<KeyValuePair<U64Id, object>, object>.Select<object>
	|
	|-RVA: 0xD4A588 Offset: 0xD4A588 VA: 0xD4A588
	|-Enumerable.WhereSelectArrayIterator<KeyValuePair<U64Id, object>, object>.Select<float>
	|
	|-RVA: 0xD4A610 Offset: 0xD4A610 VA: 0xD4A610
	|-Enumerable.WhereSelectArrayIterator<KeyValuePair<object, object>, object>.Select<U64Id>
	|
	|-RVA: 0xD4A698 Offset: 0xD4A698 VA: 0xD4A698
	|-Enumerable.WhereSelectArrayIterator<KeyValuePair<object, object>, object>.Select<object>
	|
	|-RVA: 0xD4A720 Offset: 0xD4A720 VA: 0xD4A720
	|-Enumerable.WhereSelectArrayIterator<KeyValuePair<object, object>, object>.Select<float>
	|
	|-RVA: 0xD4A7A8 Offset: 0xD4A7A8 VA: 0xD4A7A8
	|-Enumerable.WhereSelectArrayIterator<object, object>.Select<U64Id>
	|
	|-RVA: 0xD4A830 Offset: 0xD4A830 VA: 0xD4A830
	|-Enumerable.WhereSelectArrayIterator<object, object>.Select<object>
	|
	|-RVA: 0xD4A8B8 Offset: 0xD4A8B8 VA: 0xD4A8B8
	|-Enumerable.WhereSelectArrayIterator<object, object>.Select<float>
	*/

	// RVA: -1 Offset: -1 Slot: 15
	public override IEnumerable<TResult> Where(Func<TResult, bool> predicate) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1F956E8 Offset: 0x1F956E8 VA: 0x1F956E8
	|-Enumerable.WhereSelectArrayIterator<DictionaryEntry, KeyValuePair<object, object>>.Where
	|
	|-RVA: 0x1F9593C Offset: 0x1F9593C VA: 0x1F9593C
	|-Enumerable.WhereSelectArrayIterator<DictionaryEntry, object>.Where
	|
	|-RVA: 0x1F95BBC Offset: 0x1F95BBC VA: 0x1F95BBC
	|-Enumerable.WhereSelectArrayIterator<KeyValuePair<U64Id, object>, U64Id>.Where
	|
	|-RVA: 0x1F95E30 Offset: 0x1F95E30 VA: 0x1F95E30
	|-Enumerable.WhereSelectArrayIterator<KeyValuePair<U64Id, object>, object>.Where
	|
	|-RVA: 0x1F960A4 Offset: 0x1F960A4 VA: 0x1F960A4
	|-Enumerable.WhereSelectArrayIterator<KeyValuePair<U64Id, object>, float>.Where
	|
	|-RVA: 0x1F96310 Offset: 0x1F96310 VA: 0x1F96310
	|-Enumerable.WhereSelectArrayIterator<KeyValuePair<object, object>, U64Id>.Where
	|
	|-RVA: 0x1F96564 Offset: 0x1F96564 VA: 0x1F96564
	|-Enumerable.WhereSelectArrayIterator<KeyValuePair<object, object>, object>.Where
	|
	|-RVA: 0x1F967B8 Offset: 0x1F967B8 VA: 0x1F967B8
	|-Enumerable.WhereSelectArrayIterator<KeyValuePair<object, object>, float>.Where
	|
	|-RVA: 0x1F96A0C Offset: 0x1F96A0C VA: 0x1F96A0C
	|-Enumerable.WhereSelectArrayIterator<KeyValuePair<uint, object>, uint>.Where
	|
	|-RVA: 0x1F96C64 Offset: 0x1F96C64 VA: 0x1F96C64
	|-Enumerable.WhereSelectArrayIterator<object, U64Id>.Where
	|
	|-RVA: 0x1F96EAC Offset: 0x1F96EAC VA: 0x1F96EAC
	|-Enumerable.WhereSelectArrayIterator<object, object>.Where
	|
	|-RVA: 0x1F970F4 Offset: 0x1F970F4 VA: 0x1F970F4
	|-Enumerable.WhereSelectArrayIterator<object, float>.Where
	*/
}
