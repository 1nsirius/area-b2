// Namespace: 
[UnmanagedFunctionPointerAttribute] // RVA: 0x4E5200 Offset: 0x4E5200 VA: 0x4E5200
public sealed class UnityTls.unitytls_interface_struct.unitytls_x509list_append_t : MulticastDelegate // TypeDefIndex: 1563
{
	// Methods

	// RVA: 0x18EA4EC Offset: 0x18EA4EC VA: 0x18EA4EC
	public void .ctor(object object, IntPtr method) { }

	// RVA: 0x18EA500 Offset: 0x18EA500 VA: 0x18EA500 Slot: 12
	public virtual void Invoke(UnityTls.unitytls_x509list* list, UnityTls.unitytls_x509_ref cert, UnityTls.unitytls_errorstate* errorState) { }

	// RVA: 0x18EA988 Offset: 0x18EA988 VA: 0x18EA988 Slot: 13
	public virtual IAsyncResult BeginInvoke(UnityTls.unitytls_x509list* list, UnityTls.unitytls_x509_ref cert, UnityTls.unitytls_errorstate* errorState, AsyncCallback callback, object object) { }

	// RVA: 0x18EAA2C Offset: 0x18EAA2C VA: 0x18EAA2C Slot: 14
	public virtual void EndInvoke(IAsyncResult result) { }
}
