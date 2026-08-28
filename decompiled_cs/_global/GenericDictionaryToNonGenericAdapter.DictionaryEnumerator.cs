// Namespace: 
private class GenericDictionaryToNonGenericAdapter.DictionaryEnumerator : IDictionaryEnumerator, IEnumerator // TypeDefIndex: 5099
{
	// Fields
	private readonly IEnumerator enumerator; // 0x8
	private readonly MethodInfo getKeyMethod; // 0xC
	private readonly MethodInfo getValueMethod; // 0x10

	// Properties
	public DictionaryEntry Entry { get; }
	public object Key { get; }
	public object Value { get; }
	public object Current { get; }

	// Methods

	// RVA: 0x1A20728 Offset: 0x1A20728 VA: 0x1A20728
	public void .ctor(object genericDictionary, Type genericDictionaryType) { }

	// RVA: 0x1A212F0 Offset: 0x1A212F0 VA: 0x1A212F0 Slot: 6
	public DictionaryEntry get_Entry() { }

	// RVA: 0x1A21338 Offset: 0x1A21338 VA: 0x1A21338 Slot: 4
	public object get_Key() { }

	// RVA: 0x1A2143C Offset: 0x1A2143C VA: 0x1A2143C Slot: 5
	public object get_Value() { }

	// RVA: 0x1A21540 Offset: 0x1A21540 VA: 0x1A21540 Slot: 8
	public object get_Current() { }

	// RVA: 0x1A215C4 Offset: 0x1A215C4 VA: 0x1A215C4 Slot: 7
	public bool MoveNext() { }

	// RVA: 0x1A2169C Offset: 0x1A2169C VA: 0x1A2169C Slot: 9
	public void Reset() { }
}
