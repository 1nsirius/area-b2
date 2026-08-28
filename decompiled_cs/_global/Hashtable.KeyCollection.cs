// Namespace: 
[Serializable]
private class Hashtable.KeyCollection : ICollection, IEnumerable // TypeDefIndex: 1368
{
	// Fields
	private Hashtable _hashtable; // 0x8

	// Properties
	public virtual bool IsSynchronized { get; }
	public virtual object SyncRoot { get; }
	public virtual int Count { get; }

	// Methods

	// RVA: 0x1B7F060 Offset: 0x1B7F060 VA: 0x1B7F060
	internal void .ctor(Hashtable hashtable) { }

	// RVA: 0x1B80F8C Offset: 0x1B80F8C VA: 0x1B80F8C Slot: 9
	public virtual void CopyTo(Array array, int arrayIndex) { }

	// RVA: 0x1B811C0 Offset: 0x1B811C0 VA: 0x1B811C0 Slot: 10
	public virtual IEnumerator GetEnumerator() { }

	// RVA: 0x1B81238 Offset: 0x1B81238 VA: 0x1B81238 Slot: 11
	public virtual bool get_IsSynchronized() { }

	// RVA: 0x1B8126C Offset: 0x1B8126C VA: 0x1B8126C Slot: 12
	public virtual object get_SyncRoot() { }

	// RVA: 0x1B812A0 Offset: 0x1B812A0 VA: 0x1B812A0 Slot: 13
	public virtual int get_Count() { }
}
