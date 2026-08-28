// Namespace: 
[UnmanagedFunctionPointerAttribute] // RVA: 0x4E52A0 Offset: 0x4E52A0 VA: 0x4E52A0
public sealed class UnityTls.unitytls_interface_struct.unitytls_tlsctx_set_certificate_callback_t : MulticastDelegate // TypeDefIndex: 1571
{
	// Methods

	// RVA: 0x18E88C0 Offset: 0x18E88C0 VA: 0x18E88C0
	public void .ctor(object object, IntPtr method) { }

	// RVA: 0x18E88D4 Offset: 0x18E88D4 VA: 0x18E88D4 Slot: 12
	public virtual void Invoke(UnityTls.unitytls_tlsctx* ctx, UnityTls.unitytls_tlsctx_certificate_callback cb, void* userData, UnityTls.unitytls_errorstate* errorState) { }

	// RVA: 0x18E8D54 Offset: 0x18E8D54 VA: 0x18E8D54 Slot: 13
	public virtual IAsyncResult BeginInvoke(UnityTls.unitytls_tlsctx* ctx, UnityTls.unitytls_tlsctx_certificate_callback cb, void* userData, UnityTls.unitytls_errorstate* errorState, AsyncCallback callback, object object) { }

	// RVA: 0x18E8D98 Offset: 0x18E8D98 VA: 0x18E8D98 Slot: 14
	public virtual void EndInvoke(IAsyncResult result) { }
}
