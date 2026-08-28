// Namespace: 
private struct DictionaryWrapper.DictionaryEnumerator<TKey, TValue, TEnumeratorKey, TEnumeratorValue> : IDictionaryEnumerator, IEnumerator // TypeDefIndex: 4403
{
	// Fields
	private readonly IEnumerator<KeyValuePair<TEnumeratorKey, TEnumeratorValue>> _e; // 0x0

	// Properties
	public DictionaryEntry Entry { get; }
	public object Key { get; }
	public object Value { get; }
	public object Current { get; }

	// Methods

	// RVA: -1 Offset: -1
	public void .ctor(IEnumerator<KeyValuePair<TEnumeratorKey, TEnumeratorValue>> e) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x78BD34 Offset: 0x78BD34 VA: 0x78BD34
	|-DictionaryWrapper.DictionaryEnumerator<object, object, object, object>..ctor
	*/

	// RVA: -1 Offset: -1 Slot: 6
	public DictionaryEntry get_Entry() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x78BD3C Offset: 0x78BD3C VA: 0x78BD3C
	|-DictionaryWrapper.DictionaryEnumerator<object, object, object, object>.get_Entry
	*/

	// RVA: -1 Offset: -1 Slot: 4
	public object get_Key() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x78BD50 Offset: 0x78BD50 VA: 0x78BD50
	|-DictionaryWrapper.DictionaryEnumerator<object, object, object, object>.get_Key
	*/

	// RVA: -1 Offset: -1 Slot: 5
	public object get_Value() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x78BD58 Offset: 0x78BD58 VA: 0x78BD58
	|-DictionaryWrapper.DictionaryEnumerator<object, object, object, object>.get_Value
	*/

	// RVA: -1 Offset: -1 Slot: 8
	public object get_Current() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x78BD60 Offset: 0x78BD60 VA: 0x78BD60
	|-DictionaryWrapper.DictionaryEnumerator<object, object, object, object>.get_Current
	*/

	// RVA: -1 Offset: -1 Slot: 7
	public bool MoveNext() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x78BD68 Offset: 0x78BD68 VA: 0x78BD68
	|-DictionaryWrapper.DictionaryEnumerator<object, object, object, object>.MoveNext
	*/

	// RVA: -1 Offset: -1 Slot: 9
	public void Reset() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x78BD70 Offset: 0x78BD70 VA: 0x78BD70
	|-DictionaryWrapper.DictionaryEnumerator<object, object, object, object>.Reset
	*/
}
