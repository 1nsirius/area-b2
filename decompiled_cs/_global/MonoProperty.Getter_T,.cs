// Namespace: 
private sealed class MonoProperty.Getter<T, R> : MulticastDelegate // TypeDefIndex: 578
{
	// Methods

	// RVA: -1 Offset: -1
	public void .ctor(object object, IntPtr method) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x20966EC Offset: 0x20966EC VA: 0x20966EC
	|-MonoProperty.Getter<object, object>..ctor
	*/

	// RVA: -1 Offset: -1 Slot: 12
	public virtual R Invoke(T _this) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x2096700 Offset: 0x2096700 VA: 0x2096700
	|-MonoProperty.Getter<object, object>.Invoke
	*/

	// RVA: -1 Offset: -1 Slot: 13
	public virtual IAsyncResult BeginInvoke(T _this, AsyncCallback callback, object object) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x2096F50 Offset: 0x2096F50 VA: 0x2096F50
	|-MonoProperty.Getter<object, object>.BeginInvoke
	*/

	// RVA: -1 Offset: -1 Slot: 14
	public virtual R EndInvoke(IAsyncResult result) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x2096F7C Offset: 0x2096F7C VA: 0x2096F7C
	|-MonoProperty.Getter<object, object>.EndInvoke
	*/
}
