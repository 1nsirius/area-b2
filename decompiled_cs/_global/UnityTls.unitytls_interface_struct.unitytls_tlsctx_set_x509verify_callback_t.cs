// Namespace: 
[UnmanagedFunctionPointerAttribute] // RVA: 0x4E52C8 Offset: 0x4E52C8 VA: 0x4E52C8
public sealed class UnityTls.unitytls_interface_struct.unitytls_tlsctx_set_x509verify_callback_t : MulticastDelegate // TypeDefIndex: 1573
{
	// Methods

	// RVA: 0x18E97D8 Offset: 0x18E97D8 VA: 0x18E97D8
	public void .ctor(object object, IntPtr method) { }

	// RVA: 0x18E97EC Offset: 0x18E97EC VA: 0x18E97EC Slot: 12
	public virtual void Invoke(UnityTls.unitytls_tlsctx* ctx, UnityTls.unitytls_tlsctx_x509verify_callback cb, void* userData, UnityTls.unitytls_errorstate* errorState) { }

	// RVA: 0x18E9C6C Offset: 0x18E9C6C VA: 0x18E9C6C Slot: 13
	public virtual IAsyncResult BeginInvoke(UnityTls.unitytls_tlsctx* ctx, UnityTls.unitytls_tlsctx_x509verify_callback cb, void* userData, UnityTls.unitytls_errorstate* errorState, AsyncCallback callback, object object) { }

	// RVA: 0x18E9CB0 Offset: 0x18E9CB0 VA: 0x18E9CB0 Slot: 14
	public virtual void EndInvoke(IAsyncResult result) { }
}
