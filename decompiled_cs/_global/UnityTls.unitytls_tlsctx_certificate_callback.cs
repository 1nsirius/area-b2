// Namespace: 
[UnmanagedFunctionPointerAttribute] // RVA: 0x4E5110 Offset: 0x4E5110 VA: 0x4E5110
public sealed class UnityTls.unitytls_tlsctx_certificate_callback : MulticastDelegate // TypeDefIndex: 1549
{
	// Methods

	// RVA: 0x1A93058 Offset: 0x1A93058 VA: 0x1A93058
	public void .ctor(object object, IntPtr method) { }

	// RVA: 0x1A9306C Offset: 0x1A9306C VA: 0x1A9306C Slot: 12
	public virtual void Invoke(void* userData, UnityTls.unitytls_tlsctx* ctx, byte* cn, IntPtr cnLen, UnityTls.unitytls_x509name* caList, IntPtr caListLen, UnityTls.unitytls_x509list_ref* chain, UnityTls.unitytls_key_ref* key, UnityTls.unitytls_errorstate* errorState) { }

	// RVA: 0x1A935FC Offset: 0x1A935FC VA: 0x1A935FC Slot: 13
	public virtual IAsyncResult BeginInvoke(void* userData, UnityTls.unitytls_tlsctx* ctx, byte* cn, IntPtr cnLen, UnityTls.unitytls_x509name* caList, IntPtr caListLen, UnityTls.unitytls_x509list_ref* chain, UnityTls.unitytls_key_ref* key, UnityTls.unitytls_errorstate* errorState, AsyncCallback callback, object object) { }

	// RVA: 0x1A936D0 Offset: 0x1A936D0 VA: 0x1A936D0 Slot: 14
	public virtual void EndInvoke(IAsyncResult result) { }
}
