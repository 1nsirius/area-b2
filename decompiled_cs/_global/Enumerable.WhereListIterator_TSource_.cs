// Namespace: 
private class Enumerable.WhereListIterator<TSource> : Enumerable.Iterator<TSource> // TypeDefIndex: 2886
{
	// Fields
	private List<TSource> source; // 0x0
	private Func<TSource, bool> predicate; // 0x0
	private List.Enumerator<TSource> enumerator; // 0x0

	// Methods

	// RVA: -1 Offset: -1
	public void .ctor(List<TSource> source, Func<TSource, bool> predicate) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1F95030 Offset: 0x1F95030 VA: 0x1F95030
	|-Enumerable.WhereListIterator<KeyValuePair<object, object>>..ctor
	|
	|-RVA: 0x1F95290 Offset: 0x1F95290 VA: 0x1F95290
	|-Enumerable.WhereListIterator<object>..ctor
	*/

	// RVA: -1 Offset: -1 Slot: 11
	public override Enumerable.Iterator<TSource> Clone() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1F9507C Offset: 0x1F9507C VA: 0x1F9507C
	|-Enumerable.WhereListIterator<KeyValuePair<object, object>>.Clone
	|
	|-RVA: 0x1F952DC Offset: 0x1F952DC VA: 0x1F952DC
	|-Enumerable.WhereListIterator<object>.Clone
	*/

	// RVA: -1 Offset: -1 Slot: 13
	public override bool MoveNext() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1F950E4 Offset: 0x1F950E4 VA: 0x1F950E4
	|-Enumerable.WhereListIterator<KeyValuePair<object, object>>.MoveNext
	|
	|-RVA: 0x1F95344 Offset: 0x1F95344 VA: 0x1F95344
	|-Enumerable.WhereListIterator<object>.MoveNext
	*/

	// RVA: -1 Offset: -1 Slot: 14
	public override IEnumerable<TResult> Select<TResult>(Func<TSource, TResult> selector) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x9DB9F0 Offset: 0x9DB9F0 VA: 0x9DB9F0
	|-Enumerable.WhereListIterator<KeyValuePair<object, object>>.Select<object>
	|
	|-RVA: 0x9DBA64 Offset: 0x9DBA64 VA: 0x9DBA64
	|-Enumerable.WhereListIterator<object>.Select<U64Id>
	|
	|-RVA: 0x9DBAD8 Offset: 0x9DBAD8 VA: 0x9DBAD8
	|-Enumerable.WhereListIterator<object>.Select<object>
	|
	|-RVA: 0x9DBB4C Offset: 0x9DBB4C VA: 0x9DBB4C
	|-Enumerable.WhereListIterator<object>.Select<float>
	*/

	// RVA: -1 Offset: -1 Slot: 15
	public override IEnumerable<TSource> Where(Func<TSource, bool> predicate) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1F95210 Offset: 0x1F95210 VA: 0x1F95210
	|-Enumerable.WhereListIterator<KeyValuePair<object, object>>.Where
	|
	|-RVA: 0x1F95460 Offset: 0x1F95460 VA: 0x1F95460
	|-Enumerable.WhereListIterator<object>.Where
	*/
}
