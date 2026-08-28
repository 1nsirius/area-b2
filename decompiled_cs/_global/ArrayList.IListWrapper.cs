// Namespace: 
[DefaultMemberAttribute] // RVA: 0x4DDDD4 Offset: 0x4DDDD4 VA: 0x4DDDD4
[Serializable]
private class ArrayList.IListWrapper : ArrayList // TypeDefIndex: 1355
{
	// Fields
	private IList _list; // 0x18

	// Properties
	public override int Capacity { set; }
	public override int Count { get; }
	public override bool IsReadOnly { get; }
	public override bool IsFixedSize { get; }
	public override bool IsSynchronized { get; }
	public override object Item { get; set; }
	public override object SyncRoot { get; }

	// Methods

	// RVA: 0x1947A30 Offset: 0x1947A30 VA: 0x1947A30
	internal void .ctor(IList list) { }

	// RVA: 0x194969C Offset: 0x194969C VA: 0x194969C Slot: 21
	public override void set_Capacity(int value) { }

	// RVA: 0x1949778 Offset: 0x1949778 VA: 0x1949778 Slot: 22
	public override int get_Count() { }

	// RVA: 0x1949850 Offset: 0x1949850 VA: 0x1949850 Slot: 24
	public override bool get_IsReadOnly() { }

	// RVA: 0x1949928 Offset: 0x1949928 VA: 0x1949928 Slot: 23
	public override bool get_IsFixedSize() { }

	// RVA: 0x1949A00 Offset: 0x1949A00 VA: 0x1949A00 Slot: 25
	public override bool get_IsSynchronized() { }

	// RVA: 0x1949AD8 Offset: 0x1949AD8 VA: 0x1949AD8 Slot: 27
	public override object get_Item(int index) { }

	// RVA: 0x1949BB8 Offset: 0x1949BB8 VA: 0x1949BB8 Slot: 28
	public override void set_Item(int index, object value) { }

	// RVA: 0x1949CB4 Offset: 0x1949CB4 VA: 0x1949CB4 Slot: 26
	public override object get_SyncRoot() { }

	// RVA: 0x1949D8C Offset: 0x1949D8C VA: 0x1949D8C Slot: 29
	public override int Add(object obj) { }

	// RVA: 0x1949E78 Offset: 0x1949E78 VA: 0x1949E78 Slot: 30
	public override void AddRange(ICollection c) { }

	// RVA: 0x1949EBC Offset: 0x1949EBC VA: 0x1949EBC Slot: 31
	public override void Clear() { }

	// RVA: 0x194A098 Offset: 0x194A098 VA: 0x194A098 Slot: 32
	public override object Clone() { }

	// RVA: 0x194A10C Offset: 0x194A10C VA: 0x194A10C Slot: 33
	public override bool Contains(object obj) { }

	// RVA: 0x194A1EC Offset: 0x194A1EC VA: 0x194A1EC Slot: 35
	public override void CopyTo(Array array, int index) { }

	// RVA: 0x194A2D4 Offset: 0x194A2D4 VA: 0x194A2D4 Slot: 36
	public override void CopyTo(int index, Array array, int arrayIndex, int count) { }

	// RVA: 0x194A6F8 Offset: 0x194A6F8 VA: 0x194A6F8 Slot: 37
	public override IEnumerator GetEnumerator() { }

	// RVA: 0x194A7D0 Offset: 0x194A7D0 VA: 0x194A7D0 Slot: 38
	public override int IndexOf(object value) { }

	// RVA: 0x194A8B0 Offset: 0x194A8B0 VA: 0x194A8B0 Slot: 39
	public override void Insert(int index, object obj) { }

	// RVA: 0x194A9AC Offset: 0x194A9AC VA: 0x194A9AC Slot: 40
	public override void InsertRange(int index, ICollection c) { }

	// RVA: 0x194AE4C Offset: 0x194AE4C VA: 0x194AE4C Slot: 41
	public override void Remove(object value) { }

	// RVA: 0x194AE90 Offset: 0x194AE90 VA: 0x194AE90 Slot: 42
	public override void RemoveAt(int index) { }

	// RVA: 0x194AF7C Offset: 0x194AF7C VA: 0x194AF7C Slot: 43
	public override void RemoveRange(int index, int count) { }

	// RVA: 0x194B20C Offset: 0x194B20C VA: 0x194B20C Slot: 45
	public override void Sort(int index, int count, IComparer comparer) { }

	// RVA: 0x194B568 Offset: 0x194B568 VA: 0x194B568 Slot: 46
	public override object[] ToArray() { }

	// RVA: 0x194B67C Offset: 0x194B67C VA: 0x194B67C Slot: 47
	public override Array ToArray(Type type) { }
}
