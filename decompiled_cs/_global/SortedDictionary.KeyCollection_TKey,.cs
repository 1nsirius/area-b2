// Namespace: 
[DebuggerTypeProxyAttribute] // RVA: 0x4E66E0 Offset: 0x4E66E0 VA: 0x4E66E0
[DebuggerDisplayAttribute] // RVA: 0x4E66E0 Offset: 0x4E66E0 VA: 0x4E66E0
[Serializable]
public sealed class SortedDictionary.KeyCollection<TKey, TValue> : ICollection<TKey>, IEnumerable<TKey>, IEnumerable, ICollection, IReadOnlyCollection<TKey> // TypeDefIndex: 2100
{
	// Fields
	private SortedDictionary<TKey, TValue> _dictionary; // 0x0

	// Properties
	public int Count { get; }
	private bool System.Collections.Generic.ICollection<TKey>.IsReadOnly { get; }
	private bool System.Collections.ICollection.IsSynchronized { get; }
	private object System.Collections.ICollection.SyncRoot { get; }

	// Methods

	// RVA: -1 Offset: -1
	public void .ctor(SortedDictionary<TKey, TValue> dictionary) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x24E9FD4 Offset: 0x24E9FD4 VA: 0x24E9FD4
	|-SortedDictionary.KeyCollection<char, char>..ctor
	|
	|-RVA: 0x24EAE04 Offset: 0x24EAE04 VA: 0x24EAE04
	|-SortedDictionary.KeyCollection<object, object>..ctor
	*/

	// RVA: -1 Offset: -1 Slot: 11
	private IEnumerator<TKey> System.Collections.Generic.IEnumerable<TKey>.GetEnumerator() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x24EA0A0 Offset: 0x24EA0A0 VA: 0x24EA0A0
	|-SortedDictionary.KeyCollection<char, char>.System.Collections.Generic.IEnumerable<TKey>.GetEnumerator
	|
	|-RVA: 0x24EAED0 Offset: 0x24EAED0 VA: 0x24EAED0
	|-SortedDictionary.KeyCollection<object, object>.System.Collections.Generic.IEnumerable<TKey>.GetEnumerator
	*/

	// RVA: -1 Offset: -1 Slot: 12
	private IEnumerator System.Collections.IEnumerable.GetEnumerator() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x24EA12C Offset: 0x24EA12C VA: 0x24EA12C
	|-SortedDictionary.KeyCollection<char, char>.System.Collections.IEnumerable.GetEnumerator
	|
	|-RVA: 0x24EAF5C Offset: 0x24EAF5C VA: 0x24EAF5C
	|-SortedDictionary.KeyCollection<object, object>.System.Collections.IEnumerable.GetEnumerator
	*/

	// RVA: -1 Offset: -1 Slot: 9
	public void CopyTo(TKey[] array, int index) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x24EA1B8 Offset: 0x24EA1B8 VA: 0x24EA1B8
	|-SortedDictionary.KeyCollection<char, char>.CopyTo
	|
	|-RVA: 0x24EAFE8 Offset: 0x24EAFE8 VA: 0x24EAFE8
	|-SortedDictionary.KeyCollection<object, object>.CopyTo
	*/

	// RVA: -1 Offset: -1 Slot: 13
	private void System.Collections.ICollection.CopyTo(Array array, int index) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x24EA4E8 Offset: 0x24EA4E8 VA: 0x24EA4E8
	|-SortedDictionary.KeyCollection<char, char>.System.Collections.ICollection.CopyTo
	|
	|-RVA: 0x24EB318 Offset: 0x24EB318 VA: 0x24EB318
	|-SortedDictionary.KeyCollection<object, object>.System.Collections.ICollection.CopyTo
	*/

	// RVA: -1 Offset: -1 Slot: 17
	public int get_Count() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x24EAAC8 Offset: 0x24EAAC8 VA: 0x24EAAC8
	|-SortedDictionary.KeyCollection<char, char>.get_Count
	|
	|-RVA: 0x24EB8F8 Offset: 0x24EB8F8 VA: 0x24EB8F8
	|-SortedDictionary.KeyCollection<object, object>.get_Count
	*/

	// RVA: -1 Offset: -1 Slot: 5
	private bool System.Collections.Generic.ICollection<TKey>.get_IsReadOnly() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x24EAB04 Offset: 0x24EAB04 VA: 0x24EAB04
	|-SortedDictionary.KeyCollection<char, char>.System.Collections.Generic.ICollection<TKey>.get_IsReadOnly
	|
	|-RVA: 0x24EB934 Offset: 0x24EB934 VA: 0x24EB934
	|-SortedDictionary.KeyCollection<object, object>.System.Collections.Generic.ICollection<TKey>.get_IsReadOnly
	*/

	// RVA: -1 Offset: -1 Slot: 6
	private void System.Collections.Generic.ICollection<TKey>.Add(TKey item) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x24EAB0C Offset: 0x24EAB0C VA: 0x24EAB0C
	|-SortedDictionary.KeyCollection<char, char>.System.Collections.Generic.ICollection<TKey>.Add
	|
	|-RVA: 0x24EB93C Offset: 0x24EB93C VA: 0x24EB93C
	|-SortedDictionary.KeyCollection<object, object>.System.Collections.Generic.ICollection<TKey>.Add
	*/

	// RVA: -1 Offset: -1 Slot: 7
	private void System.Collections.Generic.ICollection<TKey>.Clear() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x24EABA8 Offset: 0x24EABA8 VA: 0x24EABA8
	|-SortedDictionary.KeyCollection<char, char>.System.Collections.Generic.ICollection<TKey>.Clear
	|
	|-RVA: 0x24EB9D8 Offset: 0x24EB9D8 VA: 0x24EB9D8
	|-SortedDictionary.KeyCollection<object, object>.System.Collections.Generic.ICollection<TKey>.Clear
	*/

	// RVA: -1 Offset: -1 Slot: 8
	private bool System.Collections.Generic.ICollection<TKey>.Contains(TKey item) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x24EAC44 Offset: 0x24EAC44 VA: 0x24EAC44
	|-SortedDictionary.KeyCollection<char, char>.System.Collections.Generic.ICollection<TKey>.Contains
	|
	|-RVA: 0x24EBA74 Offset: 0x24EBA74 VA: 0x24EBA74
	|-SortedDictionary.KeyCollection<object, object>.System.Collections.Generic.ICollection<TKey>.Contains
	*/

	// RVA: -1 Offset: -1 Slot: 10
	private bool System.Collections.Generic.ICollection<TKey>.Remove(TKey item) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x24EAC88 Offset: 0x24EAC88 VA: 0x24EAC88
	|-SortedDictionary.KeyCollection<char, char>.System.Collections.Generic.ICollection<TKey>.Remove
	|
	|-RVA: 0x24EBAB8 Offset: 0x24EBAB8 VA: 0x24EBAB8
	|-SortedDictionary.KeyCollection<object, object>.System.Collections.Generic.ICollection<TKey>.Remove
	*/

	// RVA: -1 Offset: -1 Slot: 16
	private bool System.Collections.ICollection.get_IsSynchronized() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x24EAD24 Offset: 0x24EAD24 VA: 0x24EAD24
	|-SortedDictionary.KeyCollection<char, char>.System.Collections.ICollection.get_IsSynchronized
	|
	|-RVA: 0x24EBB54 Offset: 0x24EBB54 VA: 0x24EBB54
	|-SortedDictionary.KeyCollection<object, object>.System.Collections.ICollection.get_IsSynchronized
	*/

	// RVA: -1 Offset: -1 Slot: 15
	private object System.Collections.ICollection.get_SyncRoot() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x24EAD2C Offset: 0x24EAD2C VA: 0x24EAD2C
	|-SortedDictionary.KeyCollection<char, char>.System.Collections.ICollection.get_SyncRoot
	|
	|-RVA: 0x24EBB5C Offset: 0x24EBB5C VA: 0x24EBB5C
	|-SortedDictionary.KeyCollection<object, object>.System.Collections.ICollection.get_SyncRoot
	*/
}
