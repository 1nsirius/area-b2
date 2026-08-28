// Namespace: 
[DefaultMemberAttribute] // RVA: 0x54D798 Offset: 0x54D798 VA: 0x54D798
private sealed class ArrayNodeDeserializer.ArrayList : IList, ICollection, IEnumerable // TypeDefIndex: 5044
{
	// Fields
	private object[] data; // 0x8
	private int count; // 0xC

	// Properties
	public bool IsFixedSize { get; }
	public bool IsReadOnly { get; }
	public object Item { get; set; }
	public int Count { get; }
	public bool IsSynchronized { get; }
	public object SyncRoot { get; }

	// Methods

	// RVA: 0x15D9C80 Offset: 0x15D9C80 VA: 0x15D9C80
	public void .ctor() { }

	// RVA: 0x15DA3EC Offset: 0x15DA3EC VA: 0x15DA3EC Slot: 6
	public int Add(object value) { }

	// RVA: 0x15DA37C Offset: 0x15DA37C VA: 0x15DA37C Slot: 8
	public void Clear() { }

	// RVA: 0x15DA510 Offset: 0x15DA510 VA: 0x15DA510 Slot: 7
	public bool Contains(object value) { }

	// RVA: 0x15DA598 Offset: 0x15DA598 VA: 0x15DA598 Slot: 11
	public int IndexOf(object value) { }

	// RVA: 0x15DA620 Offset: 0x15DA620 VA: 0x15DA620 Slot: 12
	public void Insert(int index, object value) { }

	// RVA: 0x15DA6A8 Offset: 0x15DA6A8 VA: 0x15DA6A8 Slot: 10
	public bool get_IsFixedSize() { }

	// RVA: 0x15DA6B0 Offset: 0x15DA6B0 VA: 0x15DA6B0 Slot: 9
	public bool get_IsReadOnly() { }

	// RVA: 0x15DA6B8 Offset: 0x15DA6B8 VA: 0x15DA6B8 Slot: 13
	public void Remove(object value) { }

	// RVA: 0x15DA740 Offset: 0x15DA740 VA: 0x15DA740 Slot: 14
	public void RemoveAt(int index) { }

	// RVA: 0x15DA7C8 Offset: 0x15DA7C8 VA: 0x15DA7C8 Slot: 4
	public object get_Item(int index) { }

	// RVA: 0x15DA810 Offset: 0x15DA810 VA: 0x15DA810 Slot: 5
	public void set_Item(int index, object value) { }

	// RVA: 0x15DA344 Offset: 0x15DA344 VA: 0x15DA344 Slot: 15
	public void CopyTo(Array array, int index) { }

	// RVA: 0x15DA33C Offset: 0x15DA33C VA: 0x15DA33C Slot: 16
	public int get_Count() { }

	// RVA: 0x15DA88C Offset: 0x15DA88C VA: 0x15DA88C Slot: 18
	public bool get_IsSynchronized() { }

	// RVA: 0x15DA894 Offset: 0x15DA894 VA: 0x15DA894 Slot: 17
	public object get_SyncRoot() { }

	[IteratorStateMachineAttribute] // RVA: 0x54EB7C Offset: 0x54EB7C VA: 0x54EB7C
	// RVA: 0x15DA89C Offset: 0x15DA89C VA: 0x15DA89C Slot: 19
	public IEnumerator GetEnumerator() { }
}
