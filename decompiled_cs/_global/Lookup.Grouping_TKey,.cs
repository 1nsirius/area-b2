// Namespace: 
internal class Lookup.Grouping<TKey, TElement> : IGrouping<TKey, TElement>, IEnumerable<TElement>, IEnumerable, IList<TElement>, ICollection<TElement> // TypeDefIndex: 2908
{
	// Fields
	internal TKey key; // 0x0
	internal int hashCode; // 0x0
	internal TElement[] elements; // 0x0
	internal int count; // 0x0
	internal Lookup.Grouping<TKey, TElement> hashNext; // 0x0
	internal Lookup.Grouping<TKey, TElement> next; // 0x0

	// Properties
	public TKey Key { get; }
	private int System.Collections.Generic.ICollection<TElement>.Count { get; }
	private bool System.Collections.Generic.ICollection<TElement>.IsReadOnly { get; }
	private TElement System.Collections.Generic.IList<TElement>.Item { get; set; }

	// Methods

	// RVA: -1 Offset: -1
	internal void Add(TElement element) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1F9F528 Offset: 0x1F9F528 VA: 0x1F9F528
	|-Lookup.Grouping<object, object>.Add
	*/

	[IteratorStateMachineAttribute] // RVA: 0x4EF428 Offset: 0x4EF428 VA: 0x4EF428
	// RVA: -1 Offset: -1 Slot: 5
	public IEnumerator<TElement> GetEnumerator() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1F9F638 Offset: 0x1F9F638 VA: 0x1F9F638
	|-Lookup.Grouping<object, object>.GetEnumerator
	*/

	// RVA: -1 Offset: -1 Slot: 6
	private IEnumerator System.Collections.IEnumerable.GetEnumerator() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1F9F6AC Offset: 0x1F9F6AC VA: 0x1F9F6AC
	|-Lookup.Grouping<object, object>.System.Collections.IEnumerable.GetEnumerator
	*/

	// RVA: -1 Offset: -1 Slot: 4
	public TKey get_Key() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1F9F6E8 Offset: 0x1F9F6E8 VA: 0x1F9F6E8
	|-Lookup.Grouping<object, object>.get_Key
	*/

	// RVA: -1 Offset: -1 Slot: 12
	private int System.Collections.Generic.ICollection<TElement>.get_Count() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1F9F6F0 Offset: 0x1F9F6F0 VA: 0x1F9F6F0
	|-Lookup.Grouping<object, object>.System.Collections.Generic.ICollection<TElement>.get_Count
	*/

	// RVA: -1 Offset: -1 Slot: 13
	private bool System.Collections.Generic.ICollection<TElement>.get_IsReadOnly() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1F9F6F8 Offset: 0x1F9F6F8 VA: 0x1F9F6F8
	|-Lookup.Grouping<object, object>.System.Collections.Generic.ICollection<TElement>.get_IsReadOnly
	*/

	// RVA: -1 Offset: -1 Slot: 14
	private void System.Collections.Generic.ICollection<TElement>.Add(TElement item) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1F9F700 Offset: 0x1F9F700 VA: 0x1F9F700
	|-Lookup.Grouping<object, object>.System.Collections.Generic.ICollection<TElement>.Add
	*/

	// RVA: -1 Offset: -1 Slot: 15
	private void System.Collections.Generic.ICollection<TElement>.Clear() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1F9F76C Offset: 0x1F9F76C VA: 0x1F9F76C
	|-Lookup.Grouping<object, object>.System.Collections.Generic.ICollection<TElement>.Clear
	*/

	// RVA: -1 Offset: -1 Slot: 16
	private bool System.Collections.Generic.ICollection<TElement>.Contains(TElement item) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1F9F7D8 Offset: 0x1F9F7D8 VA: 0x1F9F7D8
	|-Lookup.Grouping<object, object>.System.Collections.Generic.ICollection<TElement>.Contains
	*/

	// RVA: -1 Offset: -1 Slot: 17
	private void System.Collections.Generic.ICollection<TElement>.CopyTo(TElement[] array, int arrayIndex) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1F9F824 Offset: 0x1F9F824 VA: 0x1F9F824
	|-Lookup.Grouping<object, object>.System.Collections.Generic.ICollection<TElement>.CopyTo
	*/

	// RVA: -1 Offset: -1 Slot: 18
	private bool System.Collections.Generic.ICollection<TElement>.Remove(TElement item) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1F9F85C Offset: 0x1F9F85C VA: 0x1F9F85C
	|-Lookup.Grouping<object, object>.System.Collections.Generic.ICollection<TElement>.Remove
	*/

	// RVA: -1 Offset: -1 Slot: 9
	private int System.Collections.Generic.IList<TElement>.IndexOf(TElement item) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1F9F8C8 Offset: 0x1F9F8C8 VA: 0x1F9F8C8
	|-Lookup.Grouping<object, object>.System.Collections.Generic.IList<TElement>.IndexOf
	*/

	// RVA: -1 Offset: -1 Slot: 10
	private void System.Collections.Generic.IList<TElement>.Insert(int index, TElement item) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1F9F904 Offset: 0x1F9F904 VA: 0x1F9F904
	|-Lookup.Grouping<object, object>.System.Collections.Generic.IList<TElement>.Insert
	*/

	// RVA: -1 Offset: -1 Slot: 11
	private void System.Collections.Generic.IList<TElement>.RemoveAt(int index) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1F9F970 Offset: 0x1F9F970 VA: 0x1F9F970
	|-Lookup.Grouping<object, object>.System.Collections.Generic.IList<TElement>.RemoveAt
	*/

	// RVA: -1 Offset: -1 Slot: 7
	private TElement System.Collections.Generic.IList<TElement>.get_Item(int index) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1F9F9DC Offset: 0x1F9F9DC VA: 0x1F9F9DC
	|-Lookup.Grouping<object, object>.System.Collections.Generic.IList<TElement>.get_Item
	*/

	// RVA: -1 Offset: -1 Slot: 8
	private void System.Collections.Generic.IList<TElement>.set_Item(int index, TElement value) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1F9FAAC Offset: 0x1F9FAAC VA: 0x1F9FAAC
	|-Lookup.Grouping<object, object>.System.Collections.Generic.IList<TElement>.set_Item
	*/

	// RVA: -1 Offset: -1
	public void .ctor() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1F9FB18 Offset: 0x1F9FB18 VA: 0x1F9FB18
	|-Lookup.Grouping<object, object>..ctor
	*/
}
