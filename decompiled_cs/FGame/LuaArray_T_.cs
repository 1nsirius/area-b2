namespace FGame
{

// Namespace: FGame
[DefaultMemberAttribute] // RVA: 0x553F30 Offset: 0x553F30 VA: 0x553F30
public class LuaArray<T> : IDisposable // TypeDefIndex: 9924
{
	// Fields
	[CompilerGeneratedAttribute] // RVA: 0x5635A4 Offset: 0x5635A4 VA: 0x5635A4
	private T[] <Arr>k__BackingField; // 0x0

	// Properties
	public int Length { get; }
	public T[] Arr { get; set; }
	public T Item { get; set; }

	// Methods

	// RVA: -1 Offset: -1
	public void .ctor(int capacity) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x14B2B4C Offset: 0x14B2B4C VA: 0x14B2B4C
	|-LuaArray<RoomSlot>..ctor
	|-LuaArray<object>..ctor
	*/

	// RVA: -1 Offset: -1
	public int get_Length() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x14B2BDC Offset: 0x14B2BDC VA: 0x14B2BDC
	|-LuaArray<RoomSlot>.get_Length
	|-LuaArray<object>.get_Length
	*/

	[CompilerGeneratedAttribute] // RVA: 0x646F30 Offset: 0x646F30 VA: 0x646F30
	// RVA: -1 Offset: -1
	public T[] get_Arr() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x14B2C24 Offset: 0x14B2C24 VA: 0x14B2C24
	|-LuaArray<object>.get_Arr
	*/

	[CompilerGeneratedAttribute] // RVA: 0x646F40 Offset: 0x646F40 VA: 0x646F40
	// RVA: -1 Offset: -1
	private void set_Arr(T[] value) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x14B2C2C Offset: 0x14B2C2C VA: 0x14B2C2C
	|-LuaArray<object>.set_Arr
	*/

	// RVA: -1 Offset: -1
	public T get_Item(int index) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x14B2C34 Offset: 0x14B2C34 VA: 0x14B2C34
	|-LuaArray<RoomSlot>.get_Item
	|-LuaArray<object>.get_Item
	*/

	// RVA: -1 Offset: -1
	public void set_Item(int index, T value) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x14B2CB0 Offset: 0x14B2CB0 VA: 0x14B2CB0
	|-LuaArray<RoomSlot>.set_Item
	|-LuaArray<object>.set_Item
	*/

	// RVA: -1 Offset: -1 Slot: 4
	public void Dispose() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x14B2D30 Offset: 0x14B2D30 VA: 0x14B2D30
	|-LuaArray<RoomSlot>.Dispose
	|-LuaArray<object>.Dispose
	*/

	// RVA: -1 Offset: -1
	public int IndexOf(Predicate<T> match) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x14B2D70 Offset: 0x14B2D70 VA: 0x14B2D70
	|-LuaArray<RoomSlot>.IndexOf
	|-LuaArray<object>.IndexOf
	*/

	// RVA: -1 Offset: -1
	public void ForEach(Action<T> action) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x14B2EEC Offset: 0x14B2EEC VA: 0x14B2EEC
	|-LuaArray<object>.ForEach
	*/
}

} // namespace FGame
