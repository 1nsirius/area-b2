// Namespace: 
private class Enumerable.WhereEnumerableIterator<TSource> : Enumerable.Iterator<TSource> // TypeDefIndex: 2884
{
	// Fields
	private IEnumerable<TSource> source; // 0x0
	private Func<TSource, bool> predicate; // 0x0
	private IEnumerator<TSource> enumerator; // 0x0

	// Methods

	// RVA: -1 Offset: -1
	public void .ctor(IEnumerable<TSource> source, Func<TSource, bool> predicate) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1F936AC Offset: 0x1F936AC VA: 0x1F936AC
	|-Enumerable.WhereEnumerableIterator<U64Id>..ctor
	|
	|-RVA: 0x1F93BC8 Offset: 0x1F93BC8 VA: 0x1F93BC8
	|-Enumerable.WhereEnumerableIterator<KeyValuePair<object, object>>..ctor
	|
	|-RVA: 0x1F940E8 Offset: 0x1F940E8 VA: 0x1F940E8
	|-Enumerable.WhereEnumerableIterator<object>..ctor
	|
	|-RVA: 0x1F945FC Offset: 0x1F945FC VA: 0x1F945FC
	|-Enumerable.WhereEnumerableIterator<float>..ctor
	|
	|-RVA: 0x1F94B1C Offset: 0x1F94B1C VA: 0x1F94B1C
	|-Enumerable.WhereEnumerableIterator<uint>..ctor
	*/

	// RVA: -1 Offset: -1 Slot: 11
	public override Enumerable.Iterator<TSource> Clone() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1F936F4 Offset: 0x1F936F4 VA: 0x1F936F4
	|-Enumerable.WhereEnumerableIterator<U64Id>.Clone
	|
	|-RVA: 0x1F93C14 Offset: 0x1F93C14 VA: 0x1F93C14
	|-Enumerable.WhereEnumerableIterator<KeyValuePair<object, object>>.Clone
	|
	|-RVA: 0x1F94134 Offset: 0x1F94134 VA: 0x1F94134
	|-Enumerable.WhereEnumerableIterator<object>.Clone
	|
	|-RVA: 0x1F94648 Offset: 0x1F94648 VA: 0x1F94648
	|-Enumerable.WhereEnumerableIterator<float>.Clone
	|
	|-RVA: 0x1F94B68 Offset: 0x1F94B68 VA: 0x1F94B68
	|-Enumerable.WhereEnumerableIterator<uint>.Clone
	*/

	// RVA: -1 Offset: -1 Slot: 12
	public override void Dispose() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1F93758 Offset: 0x1F93758 VA: 0x1F93758
	|-Enumerable.WhereEnumerableIterator<U64Id>.Dispose
	|
	|-RVA: 0x1F93C7C Offset: 0x1F93C7C VA: 0x1F93C7C
	|-Enumerable.WhereEnumerableIterator<KeyValuePair<object, object>>.Dispose
	|
	|-RVA: 0x1F9419C Offset: 0x1F9419C VA: 0x1F9419C
	|-Enumerable.WhereEnumerableIterator<object>.Dispose
	|
	|-RVA: 0x1F946B0 Offset: 0x1F946B0 VA: 0x1F946B0
	|-Enumerable.WhereEnumerableIterator<float>.Dispose
	|
	|-RVA: 0x1F94BD0 Offset: 0x1F94BD0 VA: 0x1F94BD0
	|-Enumerable.WhereEnumerableIterator<uint>.Dispose
	*/

	// RVA: -1 Offset: -1 Slot: 13
	public override bool MoveNext() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1F93868 Offset: 0x1F93868 VA: 0x1F93868
	|-Enumerable.WhereEnumerableIterator<U64Id>.MoveNext
	|
	|-RVA: 0x1F93D8C Offset: 0x1F93D8C VA: 0x1F93D8C
	|-Enumerable.WhereEnumerableIterator<KeyValuePair<object, object>>.MoveNext
	|
	|-RVA: 0x1F942AC Offset: 0x1F942AC VA: 0x1F942AC
	|-Enumerable.WhereEnumerableIterator<object>.MoveNext
	|
	|-RVA: 0x1F947C0 Offset: 0x1F947C0 VA: 0x1F947C0
	|-Enumerable.WhereEnumerableIterator<float>.MoveNext
	|
	|-RVA: 0x1F94CE0 Offset: 0x1F94CE0 VA: 0x1F94CE0
	|-Enumerable.WhereEnumerableIterator<uint>.MoveNext
	*/

	// RVA: -1 Offset: -1 Slot: 14
	public override IEnumerable<TResult> Select<TResult>(Func<TSource, TResult> selector) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x9DB820 Offset: 0x9DB820 VA: 0x9DB820
	|-Enumerable.WhereEnumerableIterator<KeyValuePair<object, object>>.Select<object>
	|
	|-RVA: 0x9DB894 Offset: 0x9DB894 VA: 0x9DB894
	|-Enumerable.WhereEnumerableIterator<object>.Select<U64Id>
	|
	|-RVA: 0x9DB908 Offset: 0x9DB908 VA: 0x9DB908
	|-Enumerable.WhereEnumerableIterator<object>.Select<object>
	|
	|-RVA: 0x9DB97C Offset: 0x9DB97C VA: 0x9DB97C
	|-Enumerable.WhereEnumerableIterator<object>.Select<float>
	*/

	// RVA: -1 Offset: -1 Slot: 15
	public override IEnumerable<TSource> Where(Func<TSource, bool> predicate) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1F93B48 Offset: 0x1F93B48 VA: 0x1F93B48
	|-Enumerable.WhereEnumerableIterator<U64Id>.Where
	|
	|-RVA: 0x1F94068 Offset: 0x1F94068 VA: 0x1F94068
	|-Enumerable.WhereEnumerableIterator<KeyValuePair<object, object>>.Where
	|
	|-RVA: 0x1F9457C Offset: 0x1F9457C VA: 0x1F9457C
	|-Enumerable.WhereEnumerableIterator<object>.Where
	|
	|-RVA: 0x1F94A9C Offset: 0x1F94A9C VA: 0x1F94A9C
	|-Enumerable.WhereEnumerableIterator<float>.Where
	|
	|-RVA: 0x1F94FB0 Offset: 0x1F94FB0 VA: 0x1F94FB0
	|-Enumerable.WhereEnumerableIterator<uint>.Where
	*/
}
