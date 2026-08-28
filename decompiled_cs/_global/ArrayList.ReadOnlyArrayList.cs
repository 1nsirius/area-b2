// Namespace: 
[DefaultMemberAttribute] // RVA: 0x4DDE08 Offset: 0x4DDE08 VA: 0x4DDE08
[Serializable]
private class ArrayList.ReadOnlyArrayList : ArrayList // TypeDefIndex: 1356
{
	// Fields
	private ArrayList _list; // 0x18

	// Properties
	public override int Count { get; }
	public override bool IsReadOnly { get; }
	public override bool IsFixedSize { get; }
	public override bool IsSynchronized { get; }
	public override object Item { get; set; }
	public override object SyncRoot { get; }
	public override int Capacity { set; }

	// Methods

	// RVA: 0x1B77B40 Offset: 0x1B77B40 VA: 0x1B77B40
	internal void .ctor(ArrayList l) { }

	// RVA: 0x1B77BCC Offset: 0x1B77BCC VA: 0x1B77BCC Slot: 22
	public override int get_Count() { }

	// RVA: 0x1B77C00 Offset: 0x1B77C00 VA: 0x1B77C00 Slot: 24
	public override bool get_IsReadOnly() { }

	// RVA: 0x1B77C08 Offset: 0x1B77C08 VA: 0x1B77C08 Slot: 23
	public override bool get_IsFixedSize() { }

	// RVA: 0x1B77C10 Offset: 0x1B77C10 VA: 0x1B77C10 Slot: 25
	public override bool get_IsSynchronized() { }

	// RVA: 0x1B77C44 Offset: 0x1B77C44 VA: 0x1B77C44 Slot: 27
	public override object get_Item(int index) { }

	// RVA: 0x1B77C80 Offset: 0x1B77C80 VA: 0x1B77C80 Slot: 28
	public override void set_Item(int index, object value) { }

	// RVA: 0x1B77D28 Offset: 0x1B77D28 VA: 0x1B77D28 Slot: 26
	public override object get_SyncRoot() { }

	// RVA: 0x1B77D5C Offset: 0x1B77D5C VA: 0x1B77D5C Slot: 29
	public override int Add(object obj) { }

	// RVA: 0x1B77E04 Offset: 0x1B77E04 VA: 0x1B77E04 Slot: 30
	public override void AddRange(ICollection c) { }

	// RVA: 0x1B77EAC Offset: 0x1B77EAC VA: 0x1B77EAC Slot: 21
	public override void set_Capacity(int value) { }

	// RVA: 0x1B77F54 Offset: 0x1B77F54 VA: 0x1B77F54 Slot: 31
	public override void Clear() { }

	// RVA: 0x1B77FFC Offset: 0x1B77FFC VA: 0x1B77FFC Slot: 32
	public override object Clone() { }

	// RVA: 0x1B78150 Offset: 0x1B78150 VA: 0x1B78150 Slot: 33
	public override bool Contains(object obj) { }

	// RVA: 0x1B7818C Offset: 0x1B7818C VA: 0x1B7818C Slot: 35
	public override void CopyTo(Array array, int index) { }

	// RVA: 0x1B781D0 Offset: 0x1B781D0 VA: 0x1B781D0 Slot: 36
	public override void CopyTo(int index, Array array, int arrayIndex, int count) { }

	// RVA: 0x1B78230 Offset: 0x1B78230 VA: 0x1B78230 Slot: 37
	public override IEnumerator GetEnumerator() { }

	// RVA: 0x1B78264 Offset: 0x1B78264 VA: 0x1B78264 Slot: 38
	public override int IndexOf(object value) { }

	// RVA: 0x1B782A0 Offset: 0x1B782A0 VA: 0x1B782A0 Slot: 39
	public override void Insert(int index, object obj) { }

	// RVA: 0x1B78348 Offset: 0x1B78348 VA: 0x1B78348 Slot: 40
	public override void InsertRange(int index, ICollection c) { }

	// RVA: 0x1B783F0 Offset: 0x1B783F0 VA: 0x1B783F0 Slot: 41
	public override void Remove(object value) { }

	// RVA: 0x1B78498 Offset: 0x1B78498 VA: 0x1B78498 Slot: 42
	public override void RemoveAt(int index) { }

	// RVA: 0x1B78540 Offset: 0x1B78540 VA: 0x1B78540 Slot: 43
	public override void RemoveRange(int index, int count) { }

	// RVA: 0x1B785E8 Offset: 0x1B785E8 VA: 0x1B785E8 Slot: 45
	public override void Sort(int index, int count, IComparer comparer) { }

	// RVA: 0x1B78690 Offset: 0x1B78690 VA: 0x1B78690 Slot: 46
	public override object[] ToArray() { }

	// RVA: 0x1B786C4 Offset: 0x1B786C4 VA: 0x1B786C4 Slot: 47
	public override Array ToArray(Type type) { }
}
