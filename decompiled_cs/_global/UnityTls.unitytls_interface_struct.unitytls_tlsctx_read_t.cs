// Namespace: 
[UnmanagedFunctionPointerAttribute] // RVA: 0x4E532C Offset: 0x4E532C VA: 0x4E532C
public sealed class UnityTls.unitytls_interface_struct.unitytls_tlsctx_read_t : MulticastDelegate // TypeDefIndex: 1578
{
	// Methods

	// RVA: 0x18E7D28 Offset: 0x18E7D28 VA: 0x18E7D28
	public void .ctor(object object, IntPtr method) { }

	// RVA: 0x18E7D3C Offset: 0x18E7D3C VA: 0x18E7D3C Slot: 12
	public virtual IntPtr Invoke(UnityTls.unitytls_tlsctx* ctx, byte* buffer, IntPtr bufferLen, UnityTls.unitytls_errorstate* errorState) { }

	// RVA: 0x18E828C Offset: 0x18E828C VA: 0x18E828C Slot: 13
	public virtual IAsyncResult BeginInvoke(UnityTls.unitytls_tlsctx* ctx, byte* buffer, IntPtr bufferLen, UnityTls.unitytls_errorstate* errorState, AsyncCallback callback, object object) { }

	// RVA: 0x18E833C Offset: 0x18E833C VA: 0x18E833C Slot: 14
	public virtual IntPtr EndInvoke(IAsyncResult result) { }
}
