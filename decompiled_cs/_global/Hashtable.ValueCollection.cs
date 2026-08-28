// Namespace: 
[Serializable]
private class Hashtable.ValueCollection : ICollection, IEnumerable // TypeDefIndex: 1369
{
	// Fields
	private Hashtable _hashtable; // 0x8

	// Properties
	public virtual bool IsSynchronized { get; }
	public virtual object SyncRoot { get; }
	public virtual int Count { get; }

	// Methods

	// RVA: 0x1B7F104 Offset: 0x1B7F104 VA: 0x1B7F104
	internal void .ctor(Hashtable hashtable) { }

	// RVA: 0x1B82214 Offset: 0x1B82214 VA: 0x1B82214 Slot: 9
	public virtual void CopyTo(Array array, int arrayIndex) { }

	// RVA: 0x1B82448 Offset: 0x1B82448 VA: 0x1B82448 Slot: 10
	public virtual IEnumerator GetEnumerator() { }

	// RVA: 0x1B824C0 Offset: 0x1B824C0 VA: 0x1B824C0 Slot: 11
	public virtual bool get_IsSynchronized() { }

	// RVA: 0x1B824F4 Offset: 0x1B824F4 VA: 0x1B824F4 Slot: 12
	public virtual object get_SyncRoot() { }

	// RVA: 0x1B82528 Offset: 0x1B82528 VA: 0x1B82528 Slot: 13
	public virtual int get_Count() { }
}
