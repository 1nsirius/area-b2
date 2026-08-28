// Namespace: 
public sealed class PacketFactory.PacketHandler<T> : MulticastDelegate // TypeDefIndex: 8801
{
	// Methods

	// RVA: -1 Offset: -1
	public void .ctor(object object, IntPtr method) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x2C6CB34 Offset: 0x2C6CB34 VA: 0x2C6CB34
	|-PacketFactory.PacketHandler<object>..ctor
	*/

	// RVA: -1 Offset: -1 Slot: 12
	public virtual void Invoke(object obj, T pkt) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x2C6CB48 Offset: 0x2C6CB48 VA: 0x2C6CB48
	|-PacketFactory.PacketHandler<object>.Invoke
	*/

	// RVA: -1 Offset: -1 Slot: 13
	public virtual IAsyncResult BeginInvoke(object obj, T pkt, AsyncCallback callback, object object) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x2C6D3D0 Offset: 0x2C6D3D0 VA: 0x2C6D3D0
	|-PacketFactory.PacketHandler<object>.BeginInvoke
	*/

	// RVA: -1 Offset: -1 Slot: 14
	public virtual void EndInvoke(IAsyncResult result) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x2C6D408 Offset: 0x2C6D408 VA: 0x2C6D408
	|-PacketFactory.PacketHandler<object>.EndInvoke
	*/
}
