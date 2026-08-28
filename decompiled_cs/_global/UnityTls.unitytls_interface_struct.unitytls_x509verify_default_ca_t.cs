// Namespace: 
[UnmanagedFunctionPointerAttribute] // RVA: 0x4E523C Offset: 0x4E523C VA: 0x4E523C
public sealed class UnityTls.unitytls_interface_struct.unitytls_x509verify_default_ca_t : MulticastDelegate // TypeDefIndex: 1566
{
	// Methods

	// RVA: 0x18EBA24 Offset: 0x18EBA24 VA: 0x18EBA24
	public void .ctor(object object, IntPtr method) { }

	// RVA: 0x18EBA38 Offset: 0x18EBA38 VA: 0x18EBA38 Slot: 12
	public virtual UnityTls.unitytls_x509verify_result Invoke(UnityTls.unitytls_x509list_ref chain, byte* cn, IntPtr cnLen, UnityTls.unitytls_x509verify_callback cb, void* userData, UnityTls.unitytls_errorstate* errorState) { }

	// RVA: 0x18EC094 Offset: 0x18EC094 VA: 0x18EC094 Slot: 13
	public virtual IAsyncResult BeginInvoke(UnityTls.unitytls_x509list_ref chain, byte* cn, IntPtr cnLen, UnityTls.unitytls_x509verify_callback cb, void* userData, UnityTls.unitytls_errorstate* errorState, AsyncCallback callback, object object) { }

	// RVA: 0x18EC16C Offset: 0x18EC16C VA: 0x18EC16C Slot: 14
	public virtual UnityTls.unitytls_x509verify_result EndInvoke(IAsyncResult result) { }
}
