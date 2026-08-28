// Namespace: 
private class MessageDictionary.DictionaryEnumerator : IDictionaryEnumerator, IEnumerator // TypeDefIndex: 1232
{
	// Fields
	private MessageDictionary _methodDictionary; // 0x8
	private IDictionaryEnumerator _hashtableEnum; // 0xC
	private int _posMethod; // 0x10

	// Properties
	public object Current { get; }
	public DictionaryEntry Entry { get; }
	public object Key { get; }
	public object Value { get; }

	// Methods

	// RVA: 0x172F99C Offset: 0x172F99C VA: 0x172F99C
	public void .ctor(MessageDictionary methodDictionary) { }

	// RVA: 0x172FB5C Offset: 0x172FB5C VA: 0x172FB5C Slot: 8
	public object get_Current() { }

	// RVA: 0x172FDF8 Offset: 0x172FDF8 VA: 0x172FDF8 Slot: 7
	public bool MoveNext() { }

	// RVA: 0x173008C Offset: 0x173008C VA: 0x173008C Slot: 9
	public void Reset() { }

	// RVA: 0x172FBE0 Offset: 0x172FBE0 VA: 0x172FBE0 Slot: 6
	public DictionaryEntry get_Entry() { }

	// RVA: 0x173016C Offset: 0x173016C VA: 0x173016C Slot: 4
	public object get_Key() { }

	// RVA: 0x17301A8 Offset: 0x17301A8 VA: 0x17301A8 Slot: 5
	public object get_Value() { }
}
