// Namespace: 
[Serializable]
private sealed class ArrayList.ArrayListEnumeratorSimple : IEnumerator, ICloneable // TypeDefIndex: 1357
{
	// Fields
	private ArrayList list; // 0x8
	private int index; // 0xC
	private int version; // 0x10
	private object currentElement; // 0x14
	private bool isArrayList; // 0x18
	private static object dummyObject; // 0x0

	// Properties
	public object Current { get; }

	// Methods

	// RVA: 0x1948188 Offset: 0x1948188 VA: 0x1948188
	internal void .ctor(ArrayList list) { }

	// RVA: 0x19490F0 Offset: 0x19490F0 VA: 0x19490F0 Slot: 7
	public object Clone() { }

	// RVA: 0x19490F8 Offset: 0x19490F8 VA: 0x19490F8 Slot: 4
	public bool MoveNext() { }

	// RVA: 0x194939C Offset: 0x194939C VA: 0x194939C Slot: 5
	public object get_Current() { }

	// RVA: 0x19494F8 Offset: 0x19494F8 VA: 0x19494F8 Slot: 6
	public void Reset() { }

	// RVA: 0x194961C Offset: 0x194961C VA: 0x194961C
	private static void .cctor() { }
}
