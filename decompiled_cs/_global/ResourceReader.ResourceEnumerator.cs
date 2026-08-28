// Namespace: 
internal sealed class ResourceReader.ResourceEnumerator : IDictionaryEnumerator, IEnumerator // TypeDefIndex: 482
{
	// Fields
	private ResourceReader _reader; // 0x8
	private bool _currentIsValid; // 0xC
	private int _currentName; // 0x10
	private int _dataPosition; // 0x14

	// Properties
	public object Key { get; }
	public object Current { get; }
	internal int DataPosition { get; }
	public DictionaryEntry Entry { get; }
	public object Value { get; }

	// Methods

	// RVA: 0x1A60ABC Offset: 0x1A60ABC VA: 0x1A60ABC
	internal void .ctor(ResourceReader reader) { }

	// RVA: 0x1A65570 Offset: 0x1A65570 VA: 0x1A65570 Slot: 7
	public bool MoveNext() { }

	// RVA: 0x1A655CC Offset: 0x1A655CC VA: 0x1A655CC Slot: 4
	public object get_Key() { }

	// RVA: 0x1A65780 Offset: 0x1A65780 VA: 0x1A65780 Slot: 8
	public object get_Current() { }

	// RVA: 0x1A65C9C Offset: 0x1A65C9C VA: 0x1A65C9C
	internal int get_DataPosition() { }

	// RVA: 0x1A65804 Offset: 0x1A65804 VA: 0x1A65804 Slot: 6
	public DictionaryEntry get_Entry() { }

	// RVA: 0x1A65CA4 Offset: 0x1A65CA4 VA: 0x1A65CA4 Slot: 5
	public object get_Value() { }

	// RVA: 0x1A65E50 Offset: 0x1A65E50 VA: 0x1A65E50 Slot: 9
	public void Reset() { }
}
