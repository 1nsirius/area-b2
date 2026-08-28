// Namespace: 
[DefaultMemberAttribute] // RVA: 0x4DE008 Offset: 0x4DE008 VA: 0x4DE008
[Serializable]
private class Hashtable.SyncHashtable : Hashtable, IEnumerable // TypeDefIndex: 1370
{
	// Fields
	protected Hashtable _table; // 0x34

	// Properties
	public override int Count { get; }
	public override bool IsReadOnly { get; }
	public override bool IsFixedSize { get; }
	public override bool IsSynchronized { get; }
	public override object Item { get; set; }
	public override object SyncRoot { get; }
	public override ICollection Keys { get; }
	public override ICollection Values { get; }

	// Methods

	// RVA: 0x1B7F60C Offset: 0x1B7F60C VA: 0x1B7F60C
	internal void .ctor(Hashtable table) { }

	// RVA: 0x1B812C4 Offset: 0x1B812C4 VA: 0x1B812C4
	internal void .ctor(SerializationInfo info, StreamingContext context) { }

	// RVA: 0x1B8149C Offset: 0x1B8149C VA: 0x1B8149C Slot: 42
	public override void GetObjectData(SerializationInfo info, StreamingContext context) { }

	// RVA: 0x1B81684 Offset: 0x1B81684 VA: 0x1B81684 Slot: 41
	public override int get_Count() { }

	// RVA: 0x1B816B8 Offset: 0x1B816B8 VA: 0x1B816B8 Slot: 33
	public override bool get_IsReadOnly() { }

	// RVA: 0x1B816EC Offset: 0x1B816EC VA: 0x1B816EC Slot: 34
	public override bool get_IsFixedSize() { }

	// RVA: 0x1B81720 Offset: 0x1B81720 VA: 0x1B81720 Slot: 35
	public override bool get_IsSynchronized() { }

	// RVA: 0x1B81728 Offset: 0x1B81728 VA: 0x1B81728 Slot: 29
	public override object get_Item(object key) { }

	// RVA: 0x1B81764 Offset: 0x1B81764 VA: 0x1B81764 Slot: 30
	public override void set_Item(object key, object value) { }

	// RVA: 0x1B81868 Offset: 0x1B81868 VA: 0x1B81868 Slot: 40
	public override object get_SyncRoot() { }

	// RVA: 0x1B8189C Offset: 0x1B8189C VA: 0x1B8189C Slot: 23
	public override void Add(object key, object value) { }

	// RVA: 0x1B819A0 Offset: 0x1B819A0 VA: 0x1B819A0 Slot: 24
	public override void Clear() { }

	// RVA: 0x1B81A94 Offset: 0x1B81A94 VA: 0x1B81A94 Slot: 26
	public override bool Contains(object key) { }

	// RVA: 0x1B81AD0 Offset: 0x1B81AD0 VA: 0x1B81AD0 Slot: 27
	public override bool ContainsKey(object key) { }

	// RVA: 0x1B81BCC Offset: 0x1B81BCC VA: 0x1B81BCC Slot: 28
	public override void CopyTo(Array array, int arrayIndex) { }

	// RVA: 0x1B81CD0 Offset: 0x1B81CD0 VA: 0x1B81CD0 Slot: 25
	public override object Clone() { }

	// RVA: 0x1B81EAC Offset: 0x1B81EAC VA: 0x1B81EAC Slot: 19
	private IEnumerator System.Collections.IEnumerable.GetEnumerator() { }

	// RVA: 0x1B81EE0 Offset: 0x1B81EE0 VA: 0x1B81EE0 Slot: 31
	public override IDictionaryEnumerator GetEnumerator() { }

	// RVA: 0x1B81F14 Offset: 0x1B81F14 VA: 0x1B81F14 Slot: 37
	public override ICollection get_Keys() { }

	// RVA: 0x1B82014 Offset: 0x1B82014 VA: 0x1B82014 Slot: 38
	public override ICollection get_Values() { }

	// RVA: 0x1B82114 Offset: 0x1B82114 VA: 0x1B82114 Slot: 39
	public override void Remove(object key) { }

	// RVA: 0x1B82210 Offset: 0x1B82210 VA: 0x1B82210 Slot: 43
	public override void OnDeserialization(object sender) { }
}
