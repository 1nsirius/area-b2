// Namespace: 
private class SimpleObjectPool.Inner<TU> : IClearablePool // TypeDefIndex: 8871
{
	// Fields
	private readonly Stack<TU> mPool; // 0x0
	private static SimpleObjectPool.Inner<TU> mInstance; // 0x0

	// Properties
	public static SimpleObjectPool.Inner<TU> Instance { get; }

	// Methods

	// RVA: -1 Offset: -1
	public static SimpleObjectPool.Inner<TU> get_Instance() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x14C1B78 Offset: 0x14C1B78 VA: 0x14C1B78
	|-SimpleObjectPool.Inner<object>.get_Instance
	*/

	// RVA: -1 Offset: -1
	public void PreCreate(int num) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x14C1FF0 Offset: 0x14C1FF0 VA: 0x14C1FF0
	|-SimpleObjectPool.Inner<object>.PreCreate
	*/

	// RVA: -1 Offset: -1
	public TU Pop() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x14C2060 Offset: 0x14C2060 VA: 0x14C2060
	|-SimpleObjectPool.Inner<object>.Pop
	*/

	// RVA: -1 Offset: -1
	public void Push(TU obj) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x14C20EC Offset: 0x14C20EC VA: 0x14C20EC
	|-SimpleObjectPool.Inner<object>.Push
	*/

	// RVA: -1 Offset: -1 Slot: 4
	public void Clear() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x14C2130 Offset: 0x14C2130 VA: 0x14C2130
	|-SimpleObjectPool.Inner<object>.Clear
	*/

	// RVA: -1 Offset: -1
	public void .ctor() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x14C2218 Offset: 0x14C2218 VA: 0x14C2218
	|-SimpleObjectPool.Inner<object>..ctor
	*/

	// RVA: -1 Offset: -1
	private static void .cctor() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x14C2294 Offset: 0x14C2294 VA: 0x14C2294
	|-SimpleObjectPool.Inner<object>..cctor
	*/
}
