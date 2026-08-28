// Namespace: 
[UnmanagedFunctionPointerAttribute] // RVA: 0x4E51C4 Offset: 0x4E51C4 VA: 0x4E51C4
public sealed class UnityTls.unitytls_interface_struct.unitytls_x509list_get_ref_t : MulticastDelegate // TypeDefIndex: 1560
{
	// Methods

	// RVA: 0x18EB3D8 Offset: 0x18EB3D8 VA: 0x18EB3D8
	public void .ctor(object object, IntPtr method) { }

	// RVA: 0x18EB3EC Offset: 0x18EB3EC VA: 0x18EB3EC Slot: 12
	public virtual UnityTls.unitytls_x509list_ref Invoke(UnityTls.unitytls_x509list* list, UnityTls.unitytls_errorstate* errorState) { }

	// RVA: 0x18EB898 Offset: 0x18EB898 VA: 0x18EB898 Slot: 13
	public virtual IAsyncResult BeginInvoke(UnityTls.unitytls_x509list* list, UnityTls.unitytls_errorstate* errorState, AsyncCallback callback, object object) { }

	// RVA: 0x18EB8D0 Offset: 0x18EB8D0 VA: 0x18EB8D0 Slot: 14
	public virtual UnityTls.unitytls_x509list_ref EndInvoke(IAsyncResult result) { }
}
