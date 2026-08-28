// Namespace: 
[UnmanagedFunctionPointerAttribute] // RVA: 0x4E5278 Offset: 0x4E5278 VA: 0x4E5278
public sealed class UnityTls.unitytls_interface_struct.unitytls_tlsctx_create_client_t : MulticastDelegate // TypeDefIndex: 1569
{
	// Methods

	// RVA: 0x18E54D0 Offset: 0x18E54D0 VA: 0x18E54D0
	public void .ctor(object object, IntPtr method) { }

	// RVA: 0x18E54E4 Offset: 0x18E54E4 VA: 0x18E54E4 Slot: 12
	public virtual UnityTls.unitytls_tlsctx* Invoke(UnityTls.unitytls_tlsctx_protocolrange supportedProtocols, UnityTls.unitytls_tlsctx_callbacks callbacks, byte* cn, IntPtr cnLen, UnityTls.unitytls_errorstate* errorState) { }

	// RVA: 0x18E5B60 Offset: 0x18E5B60 VA: 0x18E5B60 Slot: 13
	public virtual IAsyncResult BeginInvoke(UnityTls.unitytls_tlsctx_protocolrange supportedProtocols, UnityTls.unitytls_tlsctx_callbacks callbacks, byte* cn, IntPtr cnLen, UnityTls.unitytls_errorstate* errorState, AsyncCallback callback, object object) { }

	// RVA: 0x18E5C58 Offset: 0x18E5C58 VA: 0x18E5C58 Slot: 14
	public virtual UnityTls.unitytls_tlsctx* EndInvoke(IAsyncResult result) { }
}
