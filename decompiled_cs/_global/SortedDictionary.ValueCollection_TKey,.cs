// Namespace: 
[DebuggerDisplayAttribute] // RVA: 0x4E67B0 Offset: 0x4E67B0 VA: 0x4E67B0
[DebuggerTypeProxyAttribute] // RVA: 0x4E67B0 Offset: 0x4E67B0 VA: 0x4E67B0
[Serializable]
public sealed class SortedDictionary.ValueCollection<TKey, TValue> : ICollection<TValue>, IEnumerable<TValue>, IEnumerable, ICollection, IReadOnlyCollection<TValue> // TypeDefIndex: 2105
{
	// Fields
	private SortedDictionary<TKey, TValue> _dictionary; // 0x0

	// Properties
	public int Count { get; }
	private bool System.Collections.Generic.ICollection<TValue>.IsReadOnly { get; }
	private bool System.Collections.ICollection.IsSynchronized { get; }
	private object System.Collections.ICollection.SyncRoot { get; }

	// Methods

	// RVA: -1 Offset: -1
	public void .ctor(SortedDictionary<TKey, TValue> dictionary) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x24EC9D0 Offset: 0x24EC9D0 VA: 0x24EC9D0
	|-SortedDictionary.ValueCollection<char, char>..ctor
	|
	|-RVA: 0x24ED800 Offset: 0x24ED800 VA: 0x24ED800
	|-SortedDictionary.ValueCollection<object, object>..ctor
	*/

	// RVA: -1 Offset: -1 Slot: 11
	private IEnumerator<TValue> System.Collections.Generic.IEnumerable<TValue>.GetEnumerator() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x24ECA9C Offset: 0x24ECA9C VA: 0x24ECA9C
	|-SortedDictionary.ValueCollection<char, char>.System.Collections.Generic.IEnumerable<TValue>.GetEnumerator
	|
	|-RVA: 0x24ED8CC Offset: 0x24ED8CC VA: 0x24ED8CC
	|-SortedDictionary.ValueCollection<object, object>.System.Collections.Generic.IEnumerable<TValue>.GetEnumerator
	*/

	// RVA: -1 Offset: -1 Slot: 12
	private IEnumerator System.Collections.IEnumerable.GetEnumerator() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x24ECB28 Offset: 0x24ECB28 VA: 0x24ECB28
	|-SortedDictionary.ValueCollection<char, char>.System.Collections.IEnumerable.GetEnumerator
	|
	|-RVA: 0x24ED958 Offset: 0x24ED958 VA: 0x24ED958
	|-SortedDictionary.ValueCollection<object, object>.System.Collections.IEnumerable.GetEnumerator
	*/

	// RVA: -1 Offset: -1 Slot: 9
	public void CopyTo(TValue[] array, int index) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x24ECBB4 Offset: 0x24ECBB4 VA: 0x24ECBB4
	|-SortedDictionary.ValueCollection<char, char>.CopyTo
	|
	|-RVA: 0x24ED9E4 Offset: 0x24ED9E4 VA: 0x24ED9E4
	|-SortedDictionary.ValueCollection<object, object>.CopyTo
	*/

	// RVA: -1 Offset: -1 Slot: 13
	private void System.Collections.ICollection.CopyTo(Array array, int index) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x24ECEE4 Offset: 0x24ECEE4 VA: 0x24ECEE4
	|-SortedDictionary.ValueCollection<char, char>.System.Collections.ICollection.CopyTo
	|
	|-RVA: 0x24EDD14 Offset: 0x24EDD14 VA: 0x24EDD14
	|-SortedDictionary.ValueCollection<object, object>.System.Collections.ICollection.CopyTo
	*/

	// RVA: -1 Offset: -1 Slot: 17
	public int get_Count() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x24ED4C4 Offset: 0x24ED4C4 VA: 0x24ED4C4
	|-SortedDictionary.ValueCollection<char, char>.get_Count
	|
	|-RVA: 0x24EE2F4 Offset: 0x24EE2F4 VA: 0x24EE2F4
	|-SortedDictionary.ValueCollection<object, object>.get_Count
	*/

	// RVA: -1 Offset: -1 Slot: 5
	private bool System.Collections.Generic.ICollection<TValue>.get_IsReadOnly() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x24ED500 Offset: 0x24ED500 VA: 0x24ED500
	|-SortedDictionary.ValueCollection<char, char>.System.Collections.Generic.ICollection<TValue>.get_IsReadOnly
	|
	|-RVA: 0x24EE330 Offset: 0x24EE330 VA: 0x24EE330
	|-SortedDictionary.ValueCollection<object, object>.System.Collections.Generic.ICollection<TValue>.get_IsReadOnly
	*/

	// RVA: -1 Offset: -1 Slot: 6
	private void System.Collections.Generic.ICollection<TValue>.Add(TValue item) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x24ED508 Offset: 0x24ED508 VA: 0x24ED508
	|-SortedDictionary.ValueCollection<char, char>.System.Collections.Generic.ICollection<TValue>.Add
	|
	|-RVA: 0x24EE338 Offset: 0x24EE338 VA: 0x24EE338
	|-SortedDictionary.ValueCollection<object, object>.System.Collections.Generic.ICollection<TValue>.Add
	*/

	// RVA: -1 Offset: -1 Slot: 7
	private void System.Collections.Generic.ICollection<TValue>.Clear() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x24ED5A4 Offset: 0x24ED5A4 VA: 0x24ED5A4
	|-SortedDictionary.ValueCollection<char, char>.System.Collections.Generic.ICollection<TValue>.Clear
	|
	|-RVA: 0x24EE3D4 Offset: 0x24EE3D4 VA: 0x24EE3D4
	|-SortedDictionary.ValueCollection<object, object>.System.Collections.Generic.ICollection<TValue>.Clear
	*/

	// RVA: -1 Offset: -1 Slot: 8
	private bool System.Collections.Generic.ICollection<TValue>.Contains(TValue item) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x24ED640 Offset: 0x24ED640 VA: 0x24ED640
	|-SortedDictionary.ValueCollection<char, char>.System.Collections.Generic.ICollection<TValue>.Contains
	|
	|-RVA: 0x24EE470 Offset: 0x24EE470 VA: 0x24EE470
	|-SortedDictionary.ValueCollection<object, object>.System.Collections.Generic.ICollection<TValue>.Contains
	*/

	// RVA: -1 Offset: -1 Slot: 10
	private bool System.Collections.Generic.ICollection<TValue>.Remove(TValue item) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x24ED684 Offset: 0x24ED684 VA: 0x24ED684
	|-SortedDictionary.ValueCollection<char, char>.System.Collections.Generic.ICollection<TValue>.Remove
	|
	|-RVA: 0x24EE4B4 Offset: 0x24EE4B4 VA: 0x24EE4B4
	|-SortedDictionary.ValueCollection<object, object>.System.Collections.Generic.ICollection<TValue>.Remove
	*/

	// RVA: -1 Offset: -1 Slot: 16
	private bool System.Collections.ICollection.get_IsSynchronized() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x24ED720 Offset: 0x24ED720 VA: 0x24ED720
	|-SortedDictionary.ValueCollection<char, char>.System.Collections.ICollection.get_IsSynchronized
	|
	|-RVA: 0x24EE550 Offset: 0x24EE550 VA: 0x24EE550
	|-SortedDictionary.ValueCollection<object, object>.System.Collections.ICollection.get_IsSynchronized
	*/

	// RVA: -1 Offset: -1 Slot: 15
	private object System.Collections.ICollection.get_SyncRoot() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x24ED728 Offset: 0x24ED728 VA: 0x24ED728
	|-SortedDictionary.ValueCollection<char, char>.System.Collections.ICollection.get_SyncRoot
	|
	|-RVA: 0x24EE558 Offset: 0x24EE558 VA: 0x24EE558
	|-SortedDictionary.ValueCollection<object, object>.System.Collections.ICollection.get_SyncRoot
	*/
}
