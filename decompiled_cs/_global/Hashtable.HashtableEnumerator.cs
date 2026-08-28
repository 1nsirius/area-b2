// Namespace: 
[Serializable]
private class Hashtable.HashtableEnumerator : IDictionaryEnumerator, IEnumerator, ICloneable // TypeDefIndex: 1371
{
	// Fields
	private Hashtable hashtable; // 0x8
	private int bucket; // 0xC
	private int version; // 0x10
	private bool current; // 0x14
	private int getObjectRetType; // 0x18
	private object currentKey; // 0x1C
	private object currentValue; // 0x20

	// Properties
	public virtual object Key { get; }
	public virtual DictionaryEntry Entry { get; }
	public virtual object Current { get; }
	public virtual object Value { get; }

	// Methods

	// RVA: 0x1B7ECC4 Offset: 0x1B7ECC4 VA: 0x1B7ECC4
	internal void .ctor(Hashtable hashtable, int getObjRetType) { }

	// RVA: 0x1B80948 Offset: 0x1B80948 VA: 0x1B80948 Slot: 10
	public object Clone() { }

	// RVA: 0x1B80950 Offset: 0x1B80950 VA: 0x1B80950 Slot: 11
	public virtual object get_Key() { }

	// RVA: 0x1B80A0C Offset: 0x1B80A0C VA: 0x1B80A0C Slot: 12
	public virtual bool MoveNext() { }

	// RVA: 0x1B80BE0 Offset: 0x1B80BE0 VA: 0x1B80BE0 Slot: 13
	public virtual DictionaryEntry get_Entry() { }

	// RVA: 0x1B80CA8 Offset: 0x1B80CA8 VA: 0x1B80CA8 Slot: 14
	public virtual object get_Current() { }

	// RVA: 0x1B80DB4 Offset: 0x1B80DB4 VA: 0x1B80DB4 Slot: 15
	public virtual object get_Value() { }

	// RVA: 0x1B80E70 Offset: 0x1B80E70 VA: 0x1B80E70 Slot: 16
	public virtual void Reset() { }
}
