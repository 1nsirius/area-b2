// Namespace: 
[Serializable]
private sealed class ConcurrentDictionary.DictionaryEnumerator<TKey, TValue> : IDictionaryEnumerator, IEnumerator // TypeDefIndex: 1405
{
	// Fields
	private IEnumerator<KeyValuePair<TKey, TValue>> _enumerator; // 0x0

	// Properties
	public DictionaryEntry Entry { get; }
	public object Key { get; }
	public object Value { get; }
	public object Current { get; }

	// Methods

	// RVA: -1 Offset: -1
	internal void .ctor(ConcurrentDictionary<TKey, TValue> dictionary) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1459268 Offset: 0x1459268 VA: 0x1459268
	|-ConcurrentDictionary.DictionaryEnumerator<object, object>..ctor
	*/

	// RVA: -1 Offset: -1 Slot: 6
	public DictionaryEntry get_Entry() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x14592C8 Offset: 0x14592C8 VA: 0x14592C8
	|-ConcurrentDictionary.DictionaryEnumerator<object, object>.get_Entry
	*/

	// RVA: -1 Offset: -1 Slot: 4
	public object get_Key() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x145949C Offset: 0x145949C VA: 0x145949C
	|-ConcurrentDictionary.DictionaryEnumerator<object, object>.get_Key
	*/

	// RVA: -1 Offset: -1 Slot: 5
	public object get_Value() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x145957C Offset: 0x145957C VA: 0x145957C
	|-ConcurrentDictionary.DictionaryEnumerator<object, object>.get_Value
	*/

	// RVA: -1 Offset: -1 Slot: 8
	public object get_Current() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x145965C Offset: 0x145965C VA: 0x145965C
	|-ConcurrentDictionary.DictionaryEnumerator<object, object>.get_Current
	*/

	// RVA: -1 Offset: -1 Slot: 7
	public bool MoveNext() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1459704 Offset: 0x1459704 VA: 0x1459704
	|-ConcurrentDictionary.DictionaryEnumerator<object, object>.MoveNext
	*/

	// RVA: -1 Offset: -1 Slot: 9
	public void Reset() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x14597DC Offset: 0x14597DC VA: 0x14597DC
	|-ConcurrentDictionary.DictionaryEnumerator<object, object>.Reset
	*/
}
