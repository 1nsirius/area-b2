// Namespace: 
[DefaultMemberAttribute] // RVA: 0x4DE41C Offset: 0x4DE41C VA: 0x4DE41C
[Serializable]
private class SortedList.SyncSortedList : SortedList // TypeDefIndex: 1390
{
	// Fields
	private SortedList _list; // 0x28
	private object _root; // 0x2C

	// Properties
	public override int Count { get; }
	public override object SyncRoot { get; }
	public override bool IsReadOnly { get; }
	public override bool IsFixedSize { get; }
	public override bool IsSynchronized { get; }
	public override object Item { get; set; }
	public override int Capacity { get; }

	// Methods

	// RVA: 0x1B85A6C Offset: 0x1B85A6C VA: 0x1B85A6C
	internal void .ctor(SortedList list) { }

	// RVA: 0x1B86B68 Offset: 0x1B86B68 VA: 0x1B86B68 Slot: 24
	public override int get_Count() { }

	// RVA: 0x1B86C40 Offset: 0x1B86C40 VA: 0x1B86C40 Slot: 30
	public override object get_SyncRoot() { }

	// RVA: 0x1B86C48 Offset: 0x1B86C48 VA: 0x1B86C48 Slot: 27
	public override bool get_IsReadOnly() { }

	// RVA: 0x1B86C7C Offset: 0x1B86C7C VA: 0x1B86C7C Slot: 28
	public override bool get_IsFixedSize() { }

	// RVA: 0x1B86CB0 Offset: 0x1B86CB0 VA: 0x1B86CB0 Slot: 29
	public override bool get_IsSynchronized() { }

	// RVA: 0x1B86CB8 Offset: 0x1B86CB8 VA: 0x1B86CB8 Slot: 42
	public override object get_Item(object key) { }

	// RVA: 0x1B86D98 Offset: 0x1B86D98 VA: 0x1B86D98 Slot: 43
	public override void set_Item(object key, object value) { }

	// RVA: 0x1B86E74 Offset: 0x1B86E74 VA: 0x1B86E74 Slot: 21
	public override void Add(object key, object value) { }

	// RVA: 0x1B86F50 Offset: 0x1B86F50 VA: 0x1B86F50 Slot: 22
	public override int get_Capacity() { }

	// RVA: 0x1B87028 Offset: 0x1B87028 VA: 0x1B87028 Slot: 31
	public override void Clear() { }

	// RVA: 0x1B870F4 Offset: 0x1B870F4 VA: 0x1B870F4 Slot: 32
	public override object Clone() { }

	// RVA: 0x1B871CC Offset: 0x1B871CC VA: 0x1B871CC Slot: 33
	public override bool Contains(object key) { }

	// RVA: 0x1B872AC Offset: 0x1B872AC VA: 0x1B872AC Slot: 34
	public override bool ContainsKey(object key) { }

	// RVA: 0x1B8738C Offset: 0x1B8738C VA: 0x1B8738C Slot: 35
	public override bool ContainsValue(object key) { }

	// RVA: 0x1B8746C Offset: 0x1B8746C VA: 0x1B8746C Slot: 36
	public override void CopyTo(Array array, int index) { }

	// RVA: 0x1B87548 Offset: 0x1B87548 VA: 0x1B87548 Slot: 37
	public override object GetByIndex(int index) { }

	// RVA: 0x1B87628 Offset: 0x1B87628 VA: 0x1B87628 Slot: 38
	public override IDictionaryEnumerator GetEnumerator() { }

	// RVA: 0x1B87700 Offset: 0x1B87700 VA: 0x1B87700 Slot: 39
	public override object GetKey(int index) { }

	// RVA: 0x1B877E0 Offset: 0x1B877E0 VA: 0x1B877E0 Slot: 40
	public override IList GetKeyList() { }

	// RVA: 0x1B878B8 Offset: 0x1B878B8 VA: 0x1B878B8 Slot: 41
	public override IList GetValueList() { }

	// RVA: 0x1B87990 Offset: 0x1B87990 VA: 0x1B87990 Slot: 44
	public override int IndexOfKey(object key) { }

	// RVA: 0x1B87B30 Offset: 0x1B87B30 VA: 0x1B87B30 Slot: 45
	public override int IndexOfValue(object value) { }

	// RVA: 0x1B87C10 Offset: 0x1B87C10 VA: 0x1B87C10 Slot: 46
	public override void RemoveAt(int index) { }

	// RVA: 0x1B87CE4 Offset: 0x1B87CE4 VA: 0x1B87CE4 Slot: 47
	public override void Remove(object key) { }
}
