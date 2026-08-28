// Namespace: 
private class Enumerable.WhereArrayIterator<TSource> : Enumerable.Iterator<TSource> // TypeDefIndex: 2885
{
	// Fields
	private TSource[] source; // 0x0
	private Func<TSource, bool> predicate; // 0x0
	private int index; // 0x0

	// Methods

	// RVA: -1 Offset: -1
	public void .ctor(TSource[] source, Func<TSource, bool> predicate) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1F93260 Offset: 0x1F93260 VA: 0x1F93260
	|-Enumerable.WhereArrayIterator<KeyValuePair<object, object>>..ctor
	|
	|-RVA: 0x1F9348C Offset: 0x1F9348C VA: 0x1F9348C
	|-Enumerable.WhereArrayIterator<object>..ctor
	*/

	// RVA: -1 Offset: -1 Slot: 11
	public override Enumerable.Iterator<TSource> Clone() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1F932AC Offset: 0x1F932AC VA: 0x1F932AC
	|-Enumerable.WhereArrayIterator<KeyValuePair<object, object>>.Clone
	|
	|-RVA: 0x1F934D8 Offset: 0x1F934D8 VA: 0x1F934D8
	|-Enumerable.WhereArrayIterator<object>.Clone
	*/

	// RVA: -1 Offset: -1 Slot: 13
	public override bool MoveNext() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1F93314 Offset: 0x1F93314 VA: 0x1F93314
	|-Enumerable.WhereArrayIterator<KeyValuePair<object, object>>.MoveNext
	|
	|-RVA: 0x1F93540 Offset: 0x1F93540 VA: 0x1F93540
	|-Enumerable.WhereArrayIterator<object>.MoveNext
	*/

	// RVA: -1 Offset: -1 Slot: 14
	public override IEnumerable<TResult> Select<TResult>(Func<TSource, TResult> selector) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x9DB650 Offset: 0x9DB650 VA: 0x9DB650
	|-Enumerable.WhereArrayIterator<KeyValuePair<object, object>>.Select<object>
	|
	|-RVA: 0x9DB6C4 Offset: 0x9DB6C4 VA: 0x9DB6C4
	|-Enumerable.WhereArrayIterator<object>.Select<U64Id>
	|
	|-RVA: 0x9DB738 Offset: 0x9DB738 VA: 0x9DB738
	|-Enumerable.WhereArrayIterator<object>.Select<object>
	|
	|-RVA: 0x9DB7AC Offset: 0x9DB7AC VA: 0x9DB7AC
	|-Enumerable.WhereArrayIterator<object>.Select<float>
	*/

	// RVA: -1 Offset: -1 Slot: 15
	public override IEnumerable<TSource> Where(Func<TSource, bool> predicate) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1F9340C Offset: 0x1F9340C VA: 0x1F9340C
	|-Enumerable.WhereArrayIterator<KeyValuePair<object, object>>.Where
	|
	|-RVA: 0x1F9362C Offset: 0x1F9362C VA: 0x1F9362C
	|-Enumerable.WhereArrayIterator<object>.Where
	*/
}
