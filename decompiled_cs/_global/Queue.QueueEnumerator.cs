// Namespace: 
[Serializable]
private class Queue.QueueEnumerator : IEnumerator, ICloneable // TypeDefIndex: 1386
{
	// Fields
	private Queue _q; // 0x8
	private int _index; // 0xC
	private int _version; // 0x10
	private object currentElement; // 0x14

	// Properties
	public virtual object Current { get; }

	// Methods

	// RVA: 0x1B83600 Offset: 0x1B83600 VA: 0x1B83600
	internal void .ctor(Queue q) { }

	// RVA: 0x1B83AB4 Offset: 0x1B83AB4 VA: 0x1B83AB4 Slot: 7
	public object Clone() { }

	// RVA: 0x1B83ABC Offset: 0x1B83ABC VA: 0x1B83ABC Slot: 8
	public virtual bool MoveNext() { }

	// RVA: 0x1B83C14 Offset: 0x1B83C14 VA: 0x1B83C14 Slot: 9
	public virtual object get_Current() { }

	// RVA: 0x1B83D44 Offset: 0x1B83D44 VA: 0x1B83D44 Slot: 10
	public virtual void Reset() { }
}
