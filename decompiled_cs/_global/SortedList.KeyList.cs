// Namespace: 
[DefaultMemberAttribute] // RVA: 0x4DE450 Offset: 0x4DE450 VA: 0x4DE450
[Serializable]
private class SortedList.KeyList : IList, ICollection, IEnumerable // TypeDefIndex: 1392
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

	// RVA: 0x1B85334 Offset: 0x1B85334 VA: 0x1B85334
	internal void .ctor(SortedList sortedList) { }

	// RVA: 0x1B85BCC Offset: 0x1B85BCC VA: 0x1B85BCC Slot: 20
	public virtual int get_Count() { }

	// RVA: 0x1B85BF0 Offset: 0x1B85BF0 VA: 0x1B85BF0 Slot: 21
	public virtual bool get_IsReadOnly() { }

	// RVA: 0x1B85BF8 Offset: 0x1B85BF8 VA: 0x1B85BF8 Slot: 22
	public virtual bool get_IsFixedSize() { }

	// RVA: 0x1B85C00 Offset: 0x1B85C00 VA: 0x1B85C00 Slot: 23
	public virtual bool get_IsSynchronized() { }

	// RVA: 0x1B85C34 Offset: 0x1B85C34 VA: 0x1B85C34 Slot: 24
	public virtual object get_SyncRoot() { }

	// RVA: 0x1B85C68 Offset: 0x1B85C68 VA: 0x1B85C68 Slot: 25
	public virtual int Add(object key) { }

	// RVA: 0x1B85D10 Offset: 0x1B85D10 VA: 0x1B85D10 Slot: 26
	public virtual void Clear() { }

	// RVA: 0x1B85DB8 Offset: 0x1B85DB8 VA: 0x1B85DB8 Slot: 27
	public virtual bool Contains(object key) { }

	// RVA: 0x1B85DF4 Offset: 0x1B85DF4 VA: 0x1B85DF4 Slot: 28
	public virtual void CopyTo(Array array, int arrayIndex) { }

	// RVA: 0x1B85F30 Offset: 0x1B85F30 VA: 0x1B85F30 Slot: 29
	public virtual void Insert(int index, object value) { }

	// RVA: 0x1B85FD8 Offset: 0x1B85FD8 VA: 0x1B85FD8 Slot: 30
	public virtual object get_Item(int index) { }

	// RVA: 0x1B86014 Offset: 0x1B86014 VA: 0x1B86014 Slot: 31
	public virtual void set_Item(int index, object value) { }

	// RVA: 0x1B860BC Offset: 0x1B860BC VA: 0x1B860BC Slot: 32
	public virtual IEnumerator GetEnumerator() { }

	// RVA: 0x1B86174 Offset: 0x1B86174 VA: 0x1B86174 Slot: 33
	public virtual int IndexOf(object key) { }

	// RVA: 0x1B862D0 Offset: 0x1B862D0 VA: 0x1B862D0 Slot: 34
	public virtual void Remove(object key) { }

	// RVA: 0x1B86378 Offset: 0x1B86378 VA: 0x1B86378 Slot: 35
	public virtual void RemoveAt(int index) { }
}
