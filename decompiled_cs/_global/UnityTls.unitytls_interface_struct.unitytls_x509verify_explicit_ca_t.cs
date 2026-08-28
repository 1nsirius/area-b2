// Namespace: 
[UnmanagedFunctionPointerAttribute] // RVA: 0x4E5250 Offset: 0x4E5250 VA: 0x4E5250
public sealed class UnityTls.unitytls_interface_struct.unitytls_x509verify_explicit_ca_t : MulticastDelegate // TypeDefIndex: 1567
{
	// Methods

	// RVA: 0x18EC1A4 Offset: 0x18EC1A4 VA: 0x18EC1A4
	public void .ctor(object object, IntPtr method) { }

	// RVA: 0x18EC1B8 Offset: 0x18EC1B8 VA: 0x18EC1B8 Slot: 12
	public virtual UnityTls.unitytls_x509verify_result Invoke(UnityTls.unitytls_x509list_ref chain, UnityTls.unitytls_x509list_ref trustCA, byte* cn, IntPtr cnLen, UnityTls.unitytls_x509verify_callback cb, void* userData, UnityTls.unitytls_errorstate* errorState) { }

	// RVA: 0x18EC828 Offset: 0x18EC828 VA: 0x18EC828 Slot: 13
	public virtual IAsyncResult BeginInvoke(UnityTls.unitytls_x509list_ref chain, UnityTls.unitytls_x509list_ref trustCA, byte* cn, IntPtr cnLen, UnityTls.unitytls_x509verify_callback cb, void* userData, UnityTls.unitytls_errorstate* errorState, AsyncCallback callback, object object) { }

	// RVA: 0x18EC920 Offset: 0x18EC920 VA: 0x18EC920 Slot: 14
	public virtual UnityTls.unitytls_x509verify_result EndInvoke(IAsyncResult result) { }
}
