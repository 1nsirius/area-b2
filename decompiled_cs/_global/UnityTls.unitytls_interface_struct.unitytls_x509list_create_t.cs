// Namespace: 
[UnmanagedFunctionPointerAttribute] // RVA: 0x4E51EC Offset: 0x4E51EC VA: 0x4E51EC
public sealed class UnityTls.unitytls_interface_struct.unitytls_x509list_create_t : MulticastDelegate // TypeDefIndex: 1562
{
	// Methods

	// RVA: 0x18EAA38 Offset: 0x18EAA38 VA: 0x18EAA38
	public void .ctor(object object, IntPtr method) { }

	// RVA: 0x18EAA4C Offset: 0x18EAA4C VA: 0x18EAA4C Slot: 12
	public virtual UnityTls.unitytls_x509list* Invoke(UnityTls.unitytls_errorstate* errorState) { }

	// RVA: 0x18EAEF0 Offset: 0x18EAEF0 VA: 0x18EAEF0 Slot: 13
	public virtual IAsyncResult BeginInvoke(UnityTls.unitytls_errorstate* errorState, AsyncCallback callback, object object) { }

	// RVA: 0x18EAF1C Offset: 0x18EAF1C VA: 0x18EAF1C Slot: 14
	public virtual UnityTls.unitytls_x509list* EndInvoke(IAsyncResult result) { }
}
