// Namespace: 
[UnmanagedFunctionPointerAttribute] // RVA: 0x4E52DC Offset: 0x4E52DC VA: 0x4E52DC
public sealed class UnityTls.unitytls_interface_struct.unitytls_tlsctx_set_supported_ciphersuites_t : MulticastDelegate // TypeDefIndex: 1574
{
	// Methods

	// RVA: 0x18E8DA4 Offset: 0x18E8DA4 VA: 0x18E8DA4
	public void .ctor(object object, IntPtr method) { }

	// RVA: 0x18E8DB8 Offset: 0x18E8DB8 VA: 0x18E8DB8 Slot: 12
	public virtual void Invoke(UnityTls.unitytls_tlsctx* ctx, UnityTls.unitytls_ciphersuite* supportedCiphersuites, IntPtr supportedCiphersuitesLen, UnityTls.unitytls_errorstate* errorState) { }

	// RVA: 0x18E9238 Offset: 0x18E9238 VA: 0x18E9238 Slot: 13
	public virtual IAsyncResult BeginInvoke(UnityTls.unitytls_tlsctx* ctx, UnityTls.unitytls_ciphersuite* supportedCiphersuites, IntPtr supportedCiphersuitesLen, UnityTls.unitytls_errorstate* errorState, AsyncCallback callback, object object) { }

	// RVA: 0x18E92E8 Offset: 0x18E92E8 VA: 0x18E92E8 Slot: 14
	public virtual void EndInvoke(IAsyncResult result) { }
}
