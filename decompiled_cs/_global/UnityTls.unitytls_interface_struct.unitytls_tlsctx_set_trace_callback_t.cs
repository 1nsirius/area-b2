// Namespace: 
[UnmanagedFunctionPointerAttribute] // RVA: 0x4E52B4 Offset: 0x4E52B4 VA: 0x4E52B4
public sealed class UnityTls.unitytls_interface_struct.unitytls_tlsctx_set_trace_callback_t : MulticastDelegate // TypeDefIndex: 1572
{
	// Methods

	// RVA: 0x18E92F4 Offset: 0x18E92F4 VA: 0x18E92F4
	public void .ctor(object object, IntPtr method) { }

	// RVA: 0x18E9308 Offset: 0x18E9308 VA: 0x18E9308 Slot: 12
	public virtual void Invoke(UnityTls.unitytls_tlsctx* ctx, UnityTls.unitytls_tlsctx_trace_callback cb, void* userData, UnityTls.unitytls_errorstate* errorState) { }

	// RVA: 0x18E9788 Offset: 0x18E9788 VA: 0x18E9788 Slot: 13
	public virtual IAsyncResult BeginInvoke(UnityTls.unitytls_tlsctx* ctx, UnityTls.unitytls_tlsctx_trace_callback cb, void* userData, UnityTls.unitytls_errorstate* errorState, AsyncCallback callback, object object) { }

	// RVA: 0x18E97CC Offset: 0x18E97CC VA: 0x18E97CC Slot: 14
	public virtual void EndInvoke(IAsyncResult result) { }
}
