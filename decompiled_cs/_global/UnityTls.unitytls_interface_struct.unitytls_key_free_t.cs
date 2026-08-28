// Namespace: 
[UnmanagedFunctionPointerAttribute] // RVA: 0x4E519C Offset: 0x4E519C VA: 0x4E519C
public sealed class UnityTls.unitytls_interface_struct.unitytls_key_free_t : MulticastDelegate // TypeDefIndex: 1558
{
	// Methods

	// RVA: 0x18E38EC Offset: 0x18E38EC VA: 0x18E38EC
	public void .ctor(object object, IntPtr method) { }

	// RVA: 0x18E3900 Offset: 0x18E3900 VA: 0x18E3900 Slot: 12
	public virtual void Invoke(UnityTls.unitytls_key* key) { }

	// RVA: 0x18E3D64 Offset: 0x18E3D64 VA: 0x18E3D64 Slot: 13
	public virtual IAsyncResult BeginInvoke(UnityTls.unitytls_key* key, AsyncCallback callback, object object) { }

	// RVA: 0x18E3D90 Offset: 0x18E3D90 VA: 0x18E3D90 Slot: 14
	public virtual void EndInvoke(IAsyncResult result) { }
}
