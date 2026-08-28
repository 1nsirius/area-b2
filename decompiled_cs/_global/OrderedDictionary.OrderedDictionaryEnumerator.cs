// Namespace: 
private class OrderedDictionary.OrderedDictionaryEnumerator : IDictionaryEnumerator, IEnumerator // TypeDefIndex: 2085
{
	// Fields
	private int _objectReturnType; // 0x8
	private IEnumerator arrayEnumerator; // 0xC

	// Properties
	public object Current { get; }
	public DictionaryEntry Entry { get; }
	public object Key { get; }
	public object Value { get; }

	// Methods

	// RVA: 0x1AA18E4 Offset: 0x1AA18E4 VA: 0x1AA18E4
	internal void .ctor(ArrayList array, int objectReturnType) { }

	// RVA: 0x1AA1B9C Offset: 0x1AA1B9C VA: 0x1AA1B9C Slot: 8
	public object get_Current() { }

	// RVA: 0x1AA1DC0 Offset: 0x1AA1DC0 VA: 0x1AA1DC0 Slot: 6
	public DictionaryEntry get_Entry() { }

	// RVA: 0x1AA1FC0 Offset: 0x1AA1FC0 VA: 0x1AA1FC0 Slot: 4
	public object get_Key() { }

	// RVA: 0x1AA20DC Offset: 0x1AA20DC VA: 0x1AA20DC Slot: 5
	public object get_Value() { }

	// RVA: 0x1AA21F8 Offset: 0x1AA21F8 VA: 0x1AA21F8 Slot: 7
	public bool MoveNext() { }

	// RVA: 0x1AA22D0 Offset: 0x1AA22D0 VA: 0x1AA22D0 Slot: 9
	public void Reset() { }
}
