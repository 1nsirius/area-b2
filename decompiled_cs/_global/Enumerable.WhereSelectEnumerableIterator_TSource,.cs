// Namespace: 
private class Enumerable.WhereSelectEnumerableIterator<TSource, TResult> : Enumerable.Iterator<TResult> // TypeDefIndex: 2887
{
	// Fields
	private IEnumerable<TSource> source; // 0x0
	private Func<TSource, bool> predicate; // 0x0
	private Func<TSource, TResult> selector; // 0x0
	private IEnumerator<TSource> enumerator; // 0x0

	// Methods

	// RVA: -1 Offset: -1
	public void .ctor(IEnumerable<TSource> source, Func<TSource, bool> predicate, Func<TSource, TResult> selector) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1F9715C Offset: 0x1F9715C VA: 0x1F9715C
	|-Enumerable.WhereSelectEnumerableIterator<DictionaryEntry, KeyValuePair<object, object>>..ctor
	|
	|-RVA: 0x1F976B8 Offset: 0x1F976B8 VA: 0x1F976B8
	|-Enumerable.WhereSelectEnumerableIterator<DictionaryEntry, object>..ctor
	|
	|-RVA: 0x1F97C04 Offset: 0x1F97C04 VA: 0x1F97C04
	|-Enumerable.WhereSelectEnumerableIterator<KeyValuePair<U64Id, object>, U64Id>..ctor
	|
	|-RVA: 0x1F98194 Offset: 0x1F98194 VA: 0x1F98194
	|-Enumerable.WhereSelectEnumerableIterator<KeyValuePair<U64Id, object>, object>..ctor
	|
	|-RVA: 0x1F98718 Offset: 0x1F98718 VA: 0x1F98718
	|-Enumerable.WhereSelectEnumerableIterator<KeyValuePair<U64Id, object>, float>..ctor
	|
	|-RVA: 0x1F98C9C Offset: 0x1F98C9C VA: 0x1F98C9C
	|-Enumerable.WhereSelectEnumerableIterator<KeyValuePair<object, object>, U64Id>..ctor
	|
	|-RVA: 0x1F991F8 Offset: 0x1F991F8 VA: 0x1F991F8
	|-Enumerable.WhereSelectEnumerableIterator<KeyValuePair<object, object>, object>..ctor
	|
	|-RVA: 0x1F99744 Offset: 0x1F99744 VA: 0x1F99744
	|-Enumerable.WhereSelectEnumerableIterator<KeyValuePair<object, object>, float>..ctor
	|
	|-RVA: 0x1F99C90 Offset: 0x1F99C90 VA: 0x1F99C90
	|-Enumerable.WhereSelectEnumerableIterator<KeyValuePair<uint, object>, uint>..ctor
	|
	|-RVA: 0x1F9A1DC Offset: 0x1F9A1DC VA: 0x1F9A1DC
	|-Enumerable.WhereSelectEnumerableIterator<object, U64Id>..ctor
	|
	|-RVA: 0x1F9A720 Offset: 0x1F9A720 VA: 0x1F9A720
	|-Enumerable.WhereSelectEnumerableIterator<object, object>..ctor
	|
	|-RVA: 0x1F9AC5C Offset: 0x1F9AC5C VA: 0x1F9AC5C
	|-Enumerable.WhereSelectEnumerableIterator<object, float>..ctor
	*/

	// RVA: -1 Offset: -1 Slot: 11
	public override Enumerable.Iterator<TResult> Clone() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1F971B0 Offset: 0x1F971B0 VA: 0x1F971B0
	|-Enumerable.WhereSelectEnumerableIterator<DictionaryEntry, KeyValuePair<object, object>>.Clone
	|
	|-RVA: 0x1F9770C Offset: 0x1F9770C VA: 0x1F9770C
	|-Enumerable.WhereSelectEnumerableIterator<DictionaryEntry, object>.Clone
	|
	|-RVA: 0x1F97C58 Offset: 0x1F97C58 VA: 0x1F97C58
	|-Enumerable.WhereSelectEnumerableIterator<KeyValuePair<U64Id, object>, U64Id>.Clone
	|
	|-RVA: 0x1F981E8 Offset: 0x1F981E8 VA: 0x1F981E8
	|-Enumerable.WhereSelectEnumerableIterator<KeyValuePair<U64Id, object>, object>.Clone
	|
	|-RVA: 0x1F9876C Offset: 0x1F9876C VA: 0x1F9876C
	|-Enumerable.WhereSelectEnumerableIterator<KeyValuePair<U64Id, object>, float>.Clone
	|
	|-RVA: 0x1F98CF0 Offset: 0x1F98CF0 VA: 0x1F98CF0
	|-Enumerable.WhereSelectEnumerableIterator<KeyValuePair<object, object>, U64Id>.Clone
	|
	|-RVA: 0x1F9924C Offset: 0x1F9924C VA: 0x1F9924C
	|-Enumerable.WhereSelectEnumerableIterator<KeyValuePair<object, object>, object>.Clone
	|
	|-RVA: 0x1F99798 Offset: 0x1F99798 VA: 0x1F99798
	|-Enumerable.WhereSelectEnumerableIterator<KeyValuePair<object, object>, float>.Clone
	|
	|-RVA: 0x1F99CE4 Offset: 0x1F99CE4 VA: 0x1F99CE4
	|-Enumerable.WhereSelectEnumerableIterator<KeyValuePair<uint, object>, uint>.Clone
	|
	|-RVA: 0x1F9A230 Offset: 0x1F9A230 VA: 0x1F9A230
	|-Enumerable.WhereSelectEnumerableIterator<object, U64Id>.Clone
	|
	|-RVA: 0x1F9A774 Offset: 0x1F9A774 VA: 0x1F9A774
	|-Enumerable.WhereSelectEnumerableIterator<object, object>.Clone
	|
	|-RVA: 0x1F9ACB0 Offset: 0x1F9ACB0 VA: 0x1F9ACB0
	|-Enumerable.WhereSelectEnumerableIterator<object, float>.Clone
	*/

	// RVA: -1 Offset: -1 Slot: 12
	public override void Dispose() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1F9722C Offset: 0x1F9722C VA: 0x1F9722C
	|-Enumerable.WhereSelectEnumerableIterator<DictionaryEntry, KeyValuePair<object, object>>.Dispose
	|
	|-RVA: 0x1F97788 Offset: 0x1F97788 VA: 0x1F97788
	|-Enumerable.WhereSelectEnumerableIterator<DictionaryEntry, object>.Dispose
	|
	|-RVA: 0x1F97CD4 Offset: 0x1F97CD4 VA: 0x1F97CD4
	|-Enumerable.WhereSelectEnumerableIterator<KeyValuePair<U64Id, object>, U64Id>.Dispose
	|
	|-RVA: 0x1F98264 Offset: 0x1F98264 VA: 0x1F98264
	|-Enumerable.WhereSelectEnumerableIterator<KeyValuePair<U64Id, object>, object>.Dispose
	|
	|-RVA: 0x1F987E8 Offset: 0x1F987E8 VA: 0x1F987E8
	|-Enumerable.WhereSelectEnumerableIterator<KeyValuePair<U64Id, object>, float>.Dispose
	|
	|-RVA: 0x1F98D6C Offset: 0x1F98D6C VA: 0x1F98D6C
	|-Enumerable.WhereSelectEnumerableIterator<KeyValuePair<object, object>, U64Id>.Dispose
	|
	|-RVA: 0x1F992C8 Offset: 0x1F992C8 VA: 0x1F992C8
	|-Enumerable.WhereSelectEnumerableIterator<KeyValuePair<object, object>, object>.Dispose
	|
	|-RVA: 0x1F99814 Offset: 0x1F99814 VA: 0x1F99814
	|-Enumerable.WhereSelectEnumerableIterator<KeyValuePair<object, object>, float>.Dispose
	|
	|-RVA: 0x1F99D60 Offset: 0x1F99D60 VA: 0x1F99D60
	|-Enumerable.WhereSelectEnumerableIterator<KeyValuePair<uint, object>, uint>.Dispose
	|
	|-RVA: 0x1F9A2AC Offset: 0x1F9A2AC VA: 0x1F9A2AC
	|-Enumerable.WhereSelectEnumerableIterator<object, U64Id>.Dispose
	|
	|-RVA: 0x1F9A7F0 Offset: 0x1F9A7F0 VA: 0x1F9A7F0
	|-Enumerable.WhereSelectEnumerableIterator<object, object>.Dispose
	|
	|-RVA: 0x1F9AD2C Offset: 0x1F9AD2C VA: 0x1F9AD2C
	|-Enumerable.WhereSelectEnumerableIterator<object, float>.Dispose
	*/

	// RVA: -1 Offset: -1 Slot: 13
	public override bool MoveNext() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1F9733C Offset: 0x1F9733C VA: 0x1F9733C
	|-Enumerable.WhereSelectEnumerableIterator<DictionaryEntry, KeyValuePair<object, object>>.MoveNext
	|
	|-RVA: 0x1F97898 Offset: 0x1F97898 VA: 0x1F97898
	|-Enumerable.WhereSelectEnumerableIterator<DictionaryEntry, object>.MoveNext
	|
	|-RVA: 0x1F97DE4 Offset: 0x1F97DE4 VA: 0x1F97DE4
	|-Enumerable.WhereSelectEnumerableIterator<KeyValuePair<U64Id, object>, U64Id>.MoveNext
	|
	|-RVA: 0x1F98374 Offset: 0x1F98374 VA: 0x1F98374
	|-Enumerable.WhereSelectEnumerableIterator<KeyValuePair<U64Id, object>, object>.MoveNext
	|
	|-RVA: 0x1F988F8 Offset: 0x1F988F8 VA: 0x1F988F8
	|-Enumerable.WhereSelectEnumerableIterator<KeyValuePair<U64Id, object>, float>.MoveNext
	|
	|-RVA: 0x1F98E7C Offset: 0x1F98E7C VA: 0x1F98E7C
	|-Enumerable.WhereSelectEnumerableIterator<KeyValuePair<object, object>, U64Id>.MoveNext
	|
	|-RVA: 0x1F993D8 Offset: 0x1F993D8 VA: 0x1F993D8
	|-Enumerable.WhereSelectEnumerableIterator<KeyValuePair<object, object>, object>.MoveNext
	|
	|-RVA: 0x1F99924 Offset: 0x1F99924 VA: 0x1F99924
	|-Enumerable.WhereSelectEnumerableIterator<KeyValuePair<object, object>, float>.MoveNext
	|
	|-RVA: 0x1F99E70 Offset: 0x1F99E70 VA: 0x1F99E70
	|-Enumerable.WhereSelectEnumerableIterator<KeyValuePair<uint, object>, uint>.MoveNext
	|
	|-RVA: 0x1F9A3BC Offset: 0x1F9A3BC VA: 0x1F9A3BC
	|-Enumerable.WhereSelectEnumerableIterator<object, U64Id>.MoveNext
	|
	|-RVA: 0x1F9A900 Offset: 0x1F9A900 VA: 0x1F9A900
	|-Enumerable.WhereSelectEnumerableIterator<object, object>.MoveNext
	|
	|-RVA: 0x1F9AE3C Offset: 0x1F9AE3C VA: 0x1F9AE3C
	|-Enumerable.WhereSelectEnumerableIterator<object, float>.MoveNext
	*/

	// RVA: -1 Offset: -1 Slot: 14
	public override IEnumerable<TResult2> Select<TResult2>(Func<TResult, TResult2> selector) { }
	/* GenericInstMethod :
	|
	|-RVA: 0xD4A940 Offset: 0xD4A940 VA: 0xD4A940
	|-Enumerable.WhereSelectEnumerableIterator<DictionaryEntry, KeyValuePair<object, object>>.Select<object>
	|
	|-RVA: 0xD4A9C8 Offset: 0xD4A9C8 VA: 0xD4A9C8
	|-Enumerable.WhereSelectEnumerableIterator<KeyValuePair<U64Id, object>, object>.Select<U64Id>
	|
	|-RVA: 0xD4AA50 Offset: 0xD4AA50 VA: 0xD4AA50
	|-Enumerable.WhereSelectEnumerableIterator<KeyValuePair<U64Id, object>, object>.Select<object>
	|
	|-RVA: 0xD4AAD8 Offset: 0xD4AAD8 VA: 0xD4AAD8
	|-Enumerable.WhereSelectEnumerableIterator<KeyValuePair<U64Id, object>, object>.Select<float>
	|
	|-RVA: 0xD4AB60 Offset: 0xD4AB60 VA: 0xD4AB60
	|-Enumerable.WhereSelectEnumerableIterator<KeyValuePair<object, object>, object>.Select<U64Id>
	|
	|-RVA: 0xD4ABE8 Offset: 0xD4ABE8 VA: 0xD4ABE8
	|-Enumerable.WhereSelectEnumerableIterator<KeyValuePair<object, object>, object>.Select<object>
	|
	|-RVA: 0xD4AC70 Offset: 0xD4AC70 VA: 0xD4AC70
	|-Enumerable.WhereSelectEnumerableIterator<KeyValuePair<object, object>, object>.Select<float>
	|
	|-RVA: 0xD4ACF8 Offset: 0xD4ACF8 VA: 0xD4ACF8
	|-Enumerable.WhereSelectEnumerableIterator<object, object>.Select<U64Id>
	|
	|-RVA: 0xD4AD80 Offset: 0xD4AD80 VA: 0xD4AD80
	|-Enumerable.WhereSelectEnumerableIterator<object, object>.Select<object>
	|
	|-RVA: 0x9DAFD8 Offset: 0x9DAFD8 VA: 0x9DAFD8
	|-Enumerable.WhereSelectEnumerableIterator<object, object>.Select<float>
	*/

	// RVA: -1 Offset: -1 Slot: 15
	public override IEnumerable<TResult> Where(Func<TResult, bool> predicate) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1F97650 Offset: 0x1F97650 VA: 0x1F97650
	|-Enumerable.WhereSelectEnumerableIterator<DictionaryEntry, KeyValuePair<object, object>>.Where
	|
	|-RVA: 0x1F97B9C Offset: 0x1F97B9C VA: 0x1F97B9C
	|-Enumerable.WhereSelectEnumerableIterator<DictionaryEntry, object>.Where
	|
	|-RVA: 0x1F9812C Offset: 0x1F9812C VA: 0x1F9812C
	|-Enumerable.WhereSelectEnumerableIterator<KeyValuePair<U64Id, object>, U64Id>.Where
	|
	|-RVA: 0x1F986B0 Offset: 0x1F986B0 VA: 0x1F986B0
	|-Enumerable.WhereSelectEnumerableIterator<KeyValuePair<U64Id, object>, object>.Where
	|
	|-RVA: 0x1F98C34 Offset: 0x1F98C34 VA: 0x1F98C34
	|-Enumerable.WhereSelectEnumerableIterator<KeyValuePair<U64Id, object>, float>.Where
	|
	|-RVA: 0x1F99190 Offset: 0x1F99190 VA: 0x1F99190
	|-Enumerable.WhereSelectEnumerableIterator<KeyValuePair<object, object>, U64Id>.Where
	|
	|-RVA: 0x1F996DC Offset: 0x1F996DC VA: 0x1F996DC
	|-Enumerable.WhereSelectEnumerableIterator<KeyValuePair<object, object>, object>.Where
	|
	|-RVA: 0x1F99C28 Offset: 0x1F99C28 VA: 0x1F99C28
	|-Enumerable.WhereSelectEnumerableIterator<KeyValuePair<object, object>, float>.Where
	|
	|-RVA: 0x1F9A174 Offset: 0x1F9A174 VA: 0x1F9A174
	|-Enumerable.WhereSelectEnumerableIterator<KeyValuePair<uint, object>, uint>.Where
	|
	|-RVA: 0x1F9A6B8 Offset: 0x1F9A6B8 VA: 0x1F9A6B8
	|-Enumerable.WhereSelectEnumerableIterator<object, U64Id>.Where
	|
	|-RVA: 0x1F9ABF4 Offset: 0x1F9ABF4 VA: 0x1F9ABF4
	|-Enumerable.WhereSelectEnumerableIterator<object, object>.Where
	|
	|-RVA: 0x1F9B130 Offset: 0x1F9B130 VA: 0x1F9B130
	|-Enumerable.WhereSelectEnumerableIterator<object, float>.Where
	*/
}
