// Namespace: 
[UnmanagedFunctionPointerAttribute] // RVA: 0x4E5340 Offset: 0x4E5340 VA: 0x4E5340
public sealed class UnityTls.unitytls_interface_struct.unitytls_tlsctx_write_t : MulticastDelegate // TypeDefIndex: 1579
{
	// Methods

	// RVA: 0x18E9CBC Offset: 0x18E9CBC VA: 0x18E9CBC
	public void .ctor(object object, IntPtr method) { }

	// RVA: 0x18E9CD0 Offset: 0x18E9CD0 VA: 0x18E9CD0 Slot: 12
	public virtual IntPtr Invoke(UnityTls.unitytls_tlsctx* ctx, byte* data, IntPtr bufferLen, UnityTls.unitytls_errorstate* errorState) { }

	// RVA: 0x18EA220 Offset: 0x18EA220 VA: 0x18EA220 Slot: 13
	public virtual IAsyncResult BeginInvoke(UnityTls.unitytls_tlsctx* ctx, byte* data, IntPtr bufferLen, UnityTls.unitytls_errorstate* errorState, AsyncCallback callback, object object) { }

	// RVA: 0x18EA2D0 Offset: 0x18EA2D0 VA: 0x18EA2D0 Slot: 14
	public virtual IntPtr EndInvoke(IAsyncResult result) { }
}
