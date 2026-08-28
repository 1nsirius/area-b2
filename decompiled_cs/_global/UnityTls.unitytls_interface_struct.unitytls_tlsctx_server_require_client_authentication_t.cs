// Namespace: 
[UnmanagedFunctionPointerAttribute] // RVA: 0x4E528C Offset: 0x4E528C VA: 0x4E528C
public sealed class UnityTls.unitytls_interface_struct.unitytls_tlsctx_server_require_client_authentication_t : MulticastDelegate // TypeDefIndex: 1570
{
	// Methods

	// RVA: 0x18E8374 Offset: 0x18E8374 VA: 0x18E8374
	public void .ctor(object object, IntPtr method) { }

	// RVA: 0x18E8388 Offset: 0x18E8388 VA: 0x18E8388 Slot: 12
	public virtual void Invoke(UnityTls.unitytls_tlsctx* ctx, UnityTls.unitytls_x509list_ref clientAuthCAList, UnityTls.unitytls_errorstate* errorState) { }

	// RVA: 0x18E8810 Offset: 0x18E8810 VA: 0x18E8810 Slot: 13
	public virtual IAsyncResult BeginInvoke(UnityTls.unitytls_tlsctx* ctx, UnityTls.unitytls_x509list_ref clientAuthCAList, UnityTls.unitytls_errorstate* errorState, AsyncCallback callback, object object) { }

	// RVA: 0x18E88B4 Offset: 0x18E88B4 VA: 0x18E88B4 Slot: 14
	public virtual void EndInvoke(IAsyncResult result) { }
}
