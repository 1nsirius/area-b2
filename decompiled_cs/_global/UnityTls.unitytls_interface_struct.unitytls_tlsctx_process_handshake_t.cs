// Namespace: 
[UnmanagedFunctionPointerAttribute] // RVA: 0x4E5318 Offset: 0x4E5318 VA: 0x4E5318
public sealed class UnityTls.unitytls_interface_struct.unitytls_tlsctx_process_handshake_t : MulticastDelegate // TypeDefIndex: 1577
{
	// Methods

	// RVA: 0x18E7800 Offset: 0x18E7800 VA: 0x18E7800
	public void .ctor(object object, IntPtr method) { }

	// RVA: 0x18E7814 Offset: 0x18E7814 VA: 0x18E7814 Slot: 12
	public virtual UnityTls.unitytls_x509verify_result Invoke(UnityTls.unitytls_tlsctx* ctx, UnityTls.unitytls_errorstate* errorState) { }

	// RVA: 0x18E7CB8 Offset: 0x18E7CB8 VA: 0x18E7CB8 Slot: 13
	public virtual IAsyncResult BeginInvoke(UnityTls.unitytls_tlsctx* ctx, UnityTls.unitytls_errorstate* errorState, AsyncCallback callback, object object) { }

	// RVA: 0x18E7CF0 Offset: 0x18E7CF0 VA: 0x18E7CF0 Slot: 14
	public virtual UnityTls.unitytls_x509verify_result EndInvoke(IAsyncResult result) { }
}
