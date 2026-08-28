// Namespace: 
private class BufferPool.Inner<T> : IClearablePool // TypeDefIndex: 8865
{
	// Fields
	private static BufferPool.Inner<T> mInstance; // 0x0
	private readonly Stack<T[]> mPool; // 0x0

	// Properties
	public static BufferPool.Inner<T> Instance { get; }

	// Methods

	// RVA: -1 Offset: -1
	public static BufferPool.Inner<T> get_Instance() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x14B371C Offset: 0x14B371C VA: 0x14B371C
	|-BufferPool.Inner<bool>.get_Instance
	|
	|-RVA: 0x14B3E88 Offset: 0x14B3E88 VA: 0x14B3E88
	|-BufferPool.Inner<byte>.get_Instance
	|
	|-RVA: 0x14B45F4 Offset: 0x14B45F4 VA: 0x14B45F4
	|-BufferPool.Inner<char>.get_Instance
	|
	|-RVA: 0x14B4D60 Offset: 0x14B4D60 VA: 0x14B4D60
	|-BufferPool.Inner<int>.get_Instance
	|
	|-RVA: 0x14B54CC Offset: 0x14B54CC VA: 0x14B54CC
	|-BufferPool.Inner<object>.get_Instance
	|
	|-RVA: 0x14B5C38 Offset: 0x14B5C38 VA: 0x14B5C38
	|-BufferPool.Inner<float>.get_Instance
	|
	|-RVA: 0x14B63A4 Offset: 0x14B63A4 VA: 0x14B63A4
	|-BufferPool.Inner<RaycastHit>.get_Instance
	|
	|-RVA: 0x14B6B10 Offset: 0x14B6B10 VA: 0x14B6B10
	|-BufferPool.Inner<Vector3>.get_Instance
	*/

	// RVA: -1 Offset: -1
	public T[] Pop(int minLength) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x14B3B94 Offset: 0x14B3B94 VA: 0x14B3B94
	|-BufferPool.Inner<bool>.Pop
	|
	|-RVA: 0x14B4300 Offset: 0x14B4300 VA: 0x14B4300
	|-BufferPool.Inner<byte>.Pop
	|
	|-RVA: 0x14B4A6C Offset: 0x14B4A6C VA: 0x14B4A6C
	|-BufferPool.Inner<char>.Pop
	|
	|-RVA: 0x14B51D8 Offset: 0x14B51D8 VA: 0x14B51D8
	|-BufferPool.Inner<int>.Pop
	|
	|-RVA: 0x14B5944 Offset: 0x14B5944 VA: 0x14B5944
	|-BufferPool.Inner<object>.Pop
	|
	|-RVA: 0x14B60B0 Offset: 0x14B60B0 VA: 0x14B60B0
	|-BufferPool.Inner<float>.Pop
	|
	|-RVA: 0x14B681C Offset: 0x14B681C VA: 0x14B681C
	|-BufferPool.Inner<RaycastHit>.Pop
	|
	|-RVA: 0x14B6F88 Offset: 0x14B6F88 VA: 0x14B6F88
	|-BufferPool.Inner<Vector3>.Pop
	*/

	// RVA: -1 Offset: -1
	public void Push(T[] buffer) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x14B3CDC Offset: 0x14B3CDC VA: 0x14B3CDC
	|-BufferPool.Inner<bool>.Push
	|
	|-RVA: 0x14B4448 Offset: 0x14B4448 VA: 0x14B4448
	|-BufferPool.Inner<byte>.Push
	|
	|-RVA: 0x14B4BB4 Offset: 0x14B4BB4 VA: 0x14B4BB4
	|-BufferPool.Inner<char>.Push
	|
	|-RVA: 0x14B5320 Offset: 0x14B5320 VA: 0x14B5320
	|-BufferPool.Inner<int>.Push
	|
	|-RVA: 0x14B5A8C Offset: 0x14B5A8C VA: 0x14B5A8C
	|-BufferPool.Inner<object>.Push
	|
	|-RVA: 0x14B61F8 Offset: 0x14B61F8 VA: 0x14B61F8
	|-BufferPool.Inner<float>.Push
	|
	|-RVA: 0x14B6964 Offset: 0x14B6964 VA: 0x14B6964
	|-BufferPool.Inner<RaycastHit>.Push
	|
	|-RVA: 0x14B70D0 Offset: 0x14B70D0 VA: 0x14B70D0
	|-BufferPool.Inner<Vector3>.Push
	*/

	// RVA: -1 Offset: -1 Slot: 4
	public void Clear() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x14B3D20 Offset: 0x14B3D20 VA: 0x14B3D20
	|-BufferPool.Inner<bool>.Clear
	|
	|-RVA: 0x14B448C Offset: 0x14B448C VA: 0x14B448C
	|-BufferPool.Inner<byte>.Clear
	|
	|-RVA: 0x14B4BF8 Offset: 0x14B4BF8 VA: 0x14B4BF8
	|-BufferPool.Inner<char>.Clear
	|
	|-RVA: 0x14B5364 Offset: 0x14B5364 VA: 0x14B5364
	|-BufferPool.Inner<int>.Clear
	|
	|-RVA: 0x14B5AD0 Offset: 0x14B5AD0 VA: 0x14B5AD0
	|-BufferPool.Inner<object>.Clear
	|
	|-RVA: 0x14B623C Offset: 0x14B623C VA: 0x14B623C
	|-BufferPool.Inner<float>.Clear
	|
	|-RVA: 0x14B69A8 Offset: 0x14B69A8 VA: 0x14B69A8
	|-BufferPool.Inner<RaycastHit>.Clear
	|
	|-RVA: 0x14B7114 Offset: 0x14B7114 VA: 0x14B7114
	|-BufferPool.Inner<Vector3>.Clear
	*/

	// RVA: -1 Offset: -1
	public void .ctor() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x14B3E08 Offset: 0x14B3E08 VA: 0x14B3E08
	|-BufferPool.Inner<bool>..ctor
	|
	|-RVA: 0x14B4574 Offset: 0x14B4574 VA: 0x14B4574
	|-BufferPool.Inner<byte>..ctor
	|
	|-RVA: 0x14B4CE0 Offset: 0x14B4CE0 VA: 0x14B4CE0
	|-BufferPool.Inner<char>..ctor
	|
	|-RVA: 0x14B544C Offset: 0x14B544C VA: 0x14B544C
	|-BufferPool.Inner<int>..ctor
	|
	|-RVA: 0x14B5BB8 Offset: 0x14B5BB8 VA: 0x14B5BB8
	|-BufferPool.Inner<object>..ctor
	|
	|-RVA: 0x14B6324 Offset: 0x14B6324 VA: 0x14B6324
	|-BufferPool.Inner<float>..ctor
	|
	|-RVA: 0x14B6A90 Offset: 0x14B6A90 VA: 0x14B6A90
	|-BufferPool.Inner<RaycastHit>..ctor
	|
	|-RVA: 0x14B71FC Offset: 0x14B71FC VA: 0x14B71FC
	|-BufferPool.Inner<Vector3>..ctor
	*/

	// RVA: -1 Offset: -1
	private static void .cctor() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x14B3E84 Offset: 0x14B3E84 VA: 0x14B3E84
	|-BufferPool.Inner<bool>..cctor
	|
	|-RVA: 0x14B45F0 Offset: 0x14B45F0 VA: 0x14B45F0
	|-BufferPool.Inner<byte>..cctor
	|
	|-RVA: 0x14B4D5C Offset: 0x14B4D5C VA: 0x14B4D5C
	|-BufferPool.Inner<char>..cctor
	|
	|-RVA: 0x14B54C8 Offset: 0x14B54C8 VA: 0x14B54C8
	|-BufferPool.Inner<int>..cctor
	|
	|-RVA: 0x14B5C34 Offset: 0x14B5C34 VA: 0x14B5C34
	|-BufferPool.Inner<object>..cctor
	|
	|-RVA: 0x14B63A0 Offset: 0x14B63A0 VA: 0x14B63A0
	|-BufferPool.Inner<float>..cctor
	|
	|-RVA: 0x14B6B0C Offset: 0x14B6B0C VA: 0x14B6B0C
	|-BufferPool.Inner<RaycastHit>..cctor
	|
	|-RVA: 0x14B7278 Offset: 0x14B7278 VA: 0x14B7278
	|-BufferPool.Inner<Vector3>..cctor
	*/
}
