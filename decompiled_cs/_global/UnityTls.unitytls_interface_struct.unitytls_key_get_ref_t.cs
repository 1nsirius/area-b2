// Namespace: 
[UnmanagedFunctionPointerAttribute] // RVA: 0x4E5160 Offset: 0x4E5160 VA: 0x4E5160
public sealed class UnityTls.unitytls_interface_struct.unitytls_key_get_ref_t : MulticastDelegate // TypeDefIndex: 1555
{
	// Methods

	// RVA: 0x18E3D9C Offset: 0x18E3D9C VA: 0x18E3D9C
	public void .ctor(object object, IntPtr method) { }

	// RVA: 0x18E3DB0 Offset: 0x18E3DB0 VA: 0x18E3DB0 Slot: 12
	public virtual UnityTls.unitytls_key_ref Invoke(UnityTls.unitytls_key* key, UnityTls.unitytls_errorstate* errorState) { }

	// RVA: 0x18E425C Offset: 0x18E425C VA: 0x18E425C Slot: 13
	public virtual IAsyncResult BeginInvoke(UnityTls.unitytls_key* key, UnityTls.unitytls_errorstate* errorState, AsyncCallback callback, object object) { }

	// RVA: 0x18E4294 Offset: 0x18E4294 VA: 0x18E4294 Slot: 14
	public virtual UnityTls.unitytls_key_ref EndInvoke(IAsyncResult result) { }
}
