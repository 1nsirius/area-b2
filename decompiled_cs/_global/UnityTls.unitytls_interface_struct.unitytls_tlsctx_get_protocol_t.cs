// Namespace: 
[UnmanagedFunctionPointerAttribute] // RVA: 0x4E5304 Offset: 0x4E5304 VA: 0x4E5304
public sealed class UnityTls.unitytls_interface_struct.unitytls_tlsctx_get_protocol_t : MulticastDelegate // TypeDefIndex: 1576
{
	// Methods

	// RVA: 0x18E6DFC Offset: 0x18E6DFC VA: 0x18E6DFC
	public void .ctor(object object, IntPtr method) { }

	// RVA: 0x18E6E10 Offset: 0x18E6E10 VA: 0x18E6E10 Slot: 12
	public virtual UnityTls.unitytls_protocol Invoke(UnityTls.unitytls_tlsctx* ctx, UnityTls.unitytls_errorstate* errorState) { }

	// RVA: 0x18E72B4 Offset: 0x18E72B4 VA: 0x18E72B4 Slot: 13
	public virtual IAsyncResult BeginInvoke(UnityTls.unitytls_tlsctx* ctx, UnityTls.unitytls_errorstate* errorState, AsyncCallback callback, object object) { }

	// RVA: 0x18E72EC Offset: 0x18E72EC VA: 0x18E72EC Slot: 14
	public virtual UnityTls.unitytls_protocol EndInvoke(IAsyncResult result) { }
}
