// Namespace: 
[UnmanagedFunctionPointerAttribute] // RVA: 0x4E5264 Offset: 0x4E5264 VA: 0x4E5264
public sealed class UnityTls.unitytls_interface_struct.unitytls_tlsctx_create_server_t : MulticastDelegate // TypeDefIndex: 1568
{
	// Methods

	// RVA: 0x18E5C64 Offset: 0x18E5C64 VA: 0x18E5C64
	public void .ctor(object object, IntPtr method) { }

	// RVA: 0x18E5C78 Offset: 0x18E5C78 VA: 0x18E5C78 Slot: 12
	public virtual UnityTls.unitytls_tlsctx* Invoke(UnityTls.unitytls_tlsctx_protocolrange supportedProtocols, UnityTls.unitytls_tlsctx_callbacks callbacks, ulong certChain, ulong leafCertificateKey, UnityTls.unitytls_errorstate* errorState) { }

	// RVA: 0x18E62F4 Offset: 0x18E62F4 VA: 0x18E62F4 Slot: 13
	public virtual IAsyncResult BeginInvoke(UnityTls.unitytls_tlsctx_protocolrange supportedProtocols, UnityTls.unitytls_tlsctx_callbacks callbacks, ulong certChain, ulong leafCertificateKey, UnityTls.unitytls_errorstate* errorState, AsyncCallback callback, object object) { }

	// RVA: 0x18E6418 Offset: 0x18E6418 VA: 0x18E6418 Slot: 14
	public virtual UnityTls.unitytls_tlsctx* EndInvoke(IAsyncResult result) { }
}
