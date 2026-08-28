// Namespace: 
private class ListDictionary.NodeEnumerator : IDictionaryEnumerator, IEnumerator // TypeDefIndex: 2075
{
	// Fields
	private ListDictionary list; // 0x8
	private ListDictionary.DictionaryNode current; // 0xC
	private int version; // 0x10
	private bool start; // 0x14

	// Properties
	public object Current { get; }
	public DictionaryEntry Entry { get; }
	public object Key { get; }
	public object Value { get; }

	// Methods

	// RVA: 0x1A9C7D8 Offset: 0x1A9C7D8 VA: 0x1A9C7D8
	public void .ctor(ListDictionary list) { }

	// RVA: 0x1A9C890 Offset: 0x1A9C890 VA: 0x1A9C890 Slot: 8
	public object get_Current() { }

	// RVA: 0x1A9C914 Offset: 0x1A9C914 VA: 0x1A9C914 Slot: 6
	public DictionaryEntry get_Entry() { }

	// RVA: 0x1A9C9E8 Offset: 0x1A9C9E8 VA: 0x1A9C9E8 Slot: 4
	public object get_Key() { }

	// RVA: 0x1A9CA98 Offset: 0x1A9CA98 VA: 0x1A9CA98 Slot: 5
	public object get_Value() { }

	// RVA: 0x1A9CB48 Offset: 0x1A9CB48 VA: 0x1A9CB48 Slot: 7
	public bool MoveNext() { }

	// RVA: 0x1A9CC64 Offset: 0x1A9CC64 VA: 0x1A9CC64 Slot: 9
	public void Reset() { }
}
