// Namespace: 
[Serializable]
private class SortedList.SortedListEnumerator : IDictionaryEnumerator, IEnumerator, ICloneable // TypeDefIndex: 1391
{
	// Fields
	private SortedList sortedList; // 0x8
	private object key; // 0xC
	private object value; // 0x10
	private int index; // 0x14
	private int startIndex; // 0x18
	private int endIndex; // 0x1C
	private int version; // 0x20
	private bool current; // 0x24
	private int getObjectRetType; // 0x28

	// Properties
	public virtual object Key { get; }
	public virtual DictionaryEntry Entry { get; }
	public virtual object Current { get; }
	public virtual object Value { get; }

	// Methods

	// RVA: 0x1B8509C Offset: 0x1B8509C VA: 0x1B8509C
	internal void .ctor(SortedList sortedList, int index, int count, int getObjRetType) { }

	// RVA: 0x1B86420 Offset: 0x1B86420 VA: 0x1B86420 Slot: 10
	public object Clone() { }

	// RVA: 0x1B86428 Offset: 0x1B86428 VA: 0x1B86428 Slot: 11
	public virtual object get_Key() { }

	// RVA: 0x1B86558 Offset: 0x1B86558 VA: 0x1B86558 Slot: 12
	public virtual bool MoveNext() { }

	// RVA: 0x1B86708 Offset: 0x1B86708 VA: 0x1B86708 Slot: 13
	public virtual DictionaryEntry get_Entry() { }

	// RVA: 0x1B86844 Offset: 0x1B86844 VA: 0x1B86844 Slot: 14
	public virtual object get_Current() { }

	// RVA: 0x1B86950 Offset: 0x1B86950 VA: 0x1B86950 Slot: 15
	public virtual object get_Value() { }

	// RVA: 0x1B86A80 Offset: 0x1B86A80 VA: 0x1B86A80 Slot: 16
	public virtual void Reset() { }
}
