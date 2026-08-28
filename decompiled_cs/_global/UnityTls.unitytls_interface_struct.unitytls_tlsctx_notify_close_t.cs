// Namespace: 
[UnmanagedFunctionPointerAttribute] // RVA: 0x4E5354 Offset: 0x4E5354 VA: 0x4E5354
public sealed class UnityTls.unitytls_interface_struct.unitytls_tlsctx_notify_close_t : MulticastDelegate // TypeDefIndex: 1580
{
	// Methods

	// RVA: 0x18E7324 Offset: 0x18E7324 VA: 0x18E7324
	public void .ctor(object object, IntPtr method) { }

	// RVA: 0x18E7338 Offset: 0x18E7338 VA: 0x18E7338 Slot: 12
	public virtual void Invoke(UnityTls.unitytls_tlsctx* ctx, UnityTls.unitytls_errorstate* errorState) { }

	// RVA: 0x18E77BC Offset: 0x18E77BC VA: 0x18E77BC Slot: 13
	public virtual IAsyncResult BeginInvoke(UnityTls.unitytls_tlsctx* ctx, UnityTls.unitytls_errorstate* errorState, AsyncCallback callback, object object) { }

	// RVA: 0x18E77F4 Offset: 0x18E77F4 VA: 0x18E77F4 Slot: 14
	public virtual void EndInvoke(IAsyncResult result) { }
}
