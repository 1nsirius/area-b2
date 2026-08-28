// Namespace: 
private static class BufferPoolThreadSafe.Inner<T> // TypeDefIndex: 8867
{
	// Fields
	private static readonly SafeQueue<T[]> mPool; // 0x0

	// Methods

	// RVA: -1 Offset: -1
	public static T[] Pop(int minLength) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x14B727C Offset: 0x14B727C VA: 0x14B727C
	|-BufferPoolThreadSafe.Inner<byte>.Pop
	|
	|-RVA: 0x14B76C4 Offset: 0x14B76C4 VA: 0x14B76C4
	|-BufferPoolThreadSafe.Inner<object>.Pop
	*/

	// RVA: -1 Offset: -1
	public static void Push(T[] buffer) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x14B7470 Offset: 0x14B7470 VA: 0x14B7470
	|-BufferPoolThreadSafe.Inner<byte>.Push
	|
	|-RVA: 0x14B78B8 Offset: 0x14B78B8 VA: 0x14B78B8
	|-BufferPoolThreadSafe.Inner<object>.Push
	*/

	// RVA: -1 Offset: -1
	private static void .cctor() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x14B75E8 Offset: 0x14B75E8 VA: 0x14B75E8
	|-BufferPoolThreadSafe.Inner<byte>..cctor
	|
	|-RVA: 0x14B7A30 Offset: 0x14B7A30 VA: 0x14B7A30
	|-BufferPoolThreadSafe.Inner<object>..cctor
	*/
}
