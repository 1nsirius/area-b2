// Namespace: 
public sealed class EntityChildrenExtension.GenChildData<TData> : MulticastDelegate // TypeDefIndex: 9661
{
	// Methods

	// RVA: -1 Offset: -1
	public void .ctor(object object, IntPtr method) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x14AE304 Offset: 0x14AE304 VA: 0x14AE304
	|-EntityChildrenExtension.GenChildData<object>..ctor
	*/

	// RVA: -1 Offset: -1 Slot: 12
	public virtual TData Invoke(in TData parentData, int childIndex) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x14AE318 Offset: 0x14AE318 VA: 0x14AE318
	|-EntityChildrenExtension.GenChildData<object>.Invoke
	*/

	// RVA: -1 Offset: -1 Slot: 13
	public virtual IAsyncResult BeginInvoke(in TData parentData, int childIndex, AsyncCallback callback, object object) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x14AE7BC Offset: 0x14AE7BC VA: 0x14AE7BC
	|-EntityChildrenExtension.GenChildData<object>.BeginInvoke
	*/

	// RVA: -1 Offset: -1 Slot: 14
	public virtual TData EndInvoke(in TData parentData, IAsyncResult result) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x14AE860 Offset: 0x14AE860 VA: 0x14AE860
	|-EntityChildrenExtension.GenChildData<object>.EndInvoke
	*/
}
