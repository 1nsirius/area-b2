// Namespace: 
[UnmanagedFunctionPointerAttribute] // RVA: 0x4E52F0 Offset: 0x4E52F0 VA: 0x4E52F0
public sealed class UnityTls.unitytls_interface_struct.unitytls_tlsctx_get_ciphersuite_t : MulticastDelegate // TypeDefIndex: 1575
{
	// Methods

	// RVA: 0x18E68D4 Offset: 0x18E68D4 VA: 0x18E68D4
	public void .ctor(object object, IntPtr method) { }

	// RVA: 0x18E68E8 Offset: 0x18E68E8 VA: 0x18E68E8 Slot: 12
	public virtual UnityTls.unitytls_ciphersuite Invoke(UnityTls.unitytls_tlsctx* ctx, UnityTls.unitytls_errorstate* errorState) { }

	// RVA: 0x18E6D8C Offset: 0x18E6D8C VA: 0x18E6D8C Slot: 13
	public virtual IAsyncResult BeginInvoke(UnityTls.unitytls_tlsctx* ctx, UnityTls.unitytls_errorstate* errorState, AsyncCallback callback, object object) { }

	// RVA: 0x18E6DC4 Offset: 0x18E6DC4 VA: 0x18E6DC4 Slot: 14
	public virtual UnityTls.unitytls_ciphersuite EndInvoke(IAsyncResult result) { }
}
