// Namespace: 
[UnmanagedFunctionPointerAttribute] // RVA: 0x4E5124 Offset: 0x4E5124 VA: 0x4E5124
public sealed class UnityTls.unitytls_tlsctx_x509verify_callback : MulticastDelegate // TypeDefIndex: 1550
{
	// Methods

	// RVA: 0x1A948C0 Offset: 0x1A948C0 VA: 0x1A948C0
	public void .ctor(object object, IntPtr method) { }

	// RVA: 0x1A948D4 Offset: 0x1A948D4 VA: 0x1A948D4 Slot: 12
	public virtual UnityTls.unitytls_x509verify_result Invoke(void* userData, UnityTls.unitytls_x509list_ref chain, UnityTls.unitytls_errorstate* errorState) { }

	// RVA: 0x1A94E34 Offset: 0x1A94E34 VA: 0x1A94E34 Slot: 13
	public virtual IAsyncResult BeginInvoke(void* userData, UnityTls.unitytls_x509list_ref chain, UnityTls.unitytls_errorstate* errorState, AsyncCallback callback, object object) { }

	// RVA: 0x1A94ED8 Offset: 0x1A94ED8 VA: 0x1A94ED8 Slot: 14
	public virtual UnityTls.unitytls_x509verify_result EndInvoke(IAsyncResult result) { }
}
