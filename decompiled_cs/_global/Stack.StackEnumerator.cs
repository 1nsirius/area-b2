// Namespace: 
[Serializable]
private class Stack.StackEnumerator : IEnumerator, ICloneable // TypeDefIndex: 1396
{
	// Fields
	private Stack _stack; // 0x8
	private int _index; // 0xC
	private int _version; // 0x10
	private object currentElement; // 0x14

	// Properties
	public virtual object Current { get; }

	// Methods

	// RVA: 0x1B88D24 Offset: 0x1B88D24 VA: 0x1B88D24
	internal void .ctor(Stack stack) { }

	// RVA: 0x1B890FC Offset: 0x1B890FC VA: 0x1B890FC Slot: 7
	public object Clone() { }

	// RVA: 0x1B89104 Offset: 0x1B89104 VA: 0x1B89104 Slot: 8
	public virtual bool MoveNext() { }

	// RVA: 0x1B892E0 Offset: 0x1B892E0 VA: 0x1B892E0 Slot: 9
	public virtual object get_Current() { }

	// RVA: 0x1B893F4 Offset: 0x1B893F4 VA: 0x1B893F4 Slot: 10
	public virtual void Reset() { }
}
