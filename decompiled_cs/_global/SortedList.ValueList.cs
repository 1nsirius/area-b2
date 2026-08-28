// Namespace: 
[DefaultMemberAttribute] // RVA: 0x4DE484 Offset: 0x4DE484 VA: 0x4DE484
[Serializable]
private class SortedList.ValueList : IList, ICollection, IEnumerable // TypeDefIndex: 1393
{
	// Fields
	private SortedList sortedList; // 0x8

	// Properties
	public virtual int Count { get; }
	public virtual bool IsReadOnly { get; }
	public virtual bool IsFixedSize { get; }
	public virtual bool IsSynchronized { get; }
	public virtual object SyncRoot { get; }
	public virtual object Item { get; set; }

	// Methods

	// RVA: 0x1B853D8 Offset: 0x1B853D8 VA: 0x1B853D8
	internal void .ctor(SortedList sortedList) { }

	// RVA: 0x1B87DB8 Offset: 0x1B87DB8 VA: 0x1B87DB8 Slot: 20
	public virtual int get_Count() { }

	// RVA: 0x1B87DDC Offset: 0x1B87DDC VA: 0x1B87DDC Slot: 21
	public virtual bool get_IsReadOnly() { }

	// RVA: 0x1B87DE4 Offset: 0x1B87DE4 VA: 0x1B87DE4 Slot: 22
	public virtual bool get_IsFixedSize() { }

	// RVA: 0x1B87DEC Offset: 0x1B87DEC VA: 0x1B87DEC Slot: 23
	public virtual bool get_IsSynchronized() { }

	// RVA: 0x1B87E20 Offset: 0x1B87E20 VA: 0x1B87E20 Slot: 24
	public virtual object get_SyncRoot() { }

	// RVA: 0x1B87E54 Offset: 0x1B87E54 VA: 0x1B87E54 Slot: 25
	public virtual int Add(object key) { }

	// RVA: 0x1B87EFC Offset: 0x1B87EFC VA: 0x1B87EFC Slot: 26
	public virtual void Clear() { }

	// RVA: 0x1B87FA4 Offset: 0x1B87FA4 VA: 0x1B87FA4 Slot: 27
	public virtual bool Contains(object value) { }

	// RVA: 0x1B87FE0 Offset: 0x1B87FE0 VA: 0x1B87FE0 Slot: 28
	public virtual void CopyTo(Array array, int arrayIndex) { }

	// RVA: 0x1B8811C Offset: 0x1B8811C VA: 0x1B8811C Slot: 29
	public virtual void Insert(int index, object value) { }

	// RVA: 0x1B881C4 Offset: 0x1B881C4 VA: 0x1B881C4 Slot: 30
	public virtual object get_Item(int index) { }

	// RVA: 0x1B88200 Offset: 0x1B88200 VA: 0x1B88200 Slot: 31
	public virtual void set_Item(int index, object value) { }

	// RVA: 0x1B882A8 Offset: 0x1B882A8 VA: 0x1B882A8 Slot: 32
	public virtual IEnumerator GetEnumerator() { }

	// RVA: 0x1B88360 Offset: 0x1B88360 VA: 0x1B88360 Slot: 33
	public virtual int IndexOf(object value) { }

	// RVA: 0x1B88424 Offset: 0x1B88424 VA: 0x1B88424 Slot: 34
	public virtual void Remove(object value) { }

	// RVA: 0x1B884CC Offset: 0x1B884CC VA: 0x1B884CC Slot: 35
	public virtual void RemoveAt(int index) { }
}
