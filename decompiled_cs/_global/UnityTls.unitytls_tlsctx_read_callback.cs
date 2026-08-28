// Namespace: 
[UnmanagedFunctionPointerAttribute] // RVA: 0x4E50E8 Offset: 0x4E50E8 VA: 0x4E50E8
public sealed class UnityTls.unitytls_tlsctx_read_callback : MulticastDelegate // TypeDefIndex: 1547
{
	// Methods

	// RVA: 0x1A936DC Offset: 0x1A936DC VA: 0x1A936DC
	public void .ctor(object object, IntPtr method) { }

	// RVA: 0x1A936F0 Offset: 0x1A936F0 VA: 0x1A936F0 Slot: 12
	public virtual IntPtr Invoke(void* userData, byte* buffer, IntPtr bufferLen, UnityTls.unitytls_errorstate* errorState) { }

	// RVA: 0x1A93C40 Offset: 0x1A93C40 VA: 0x1A93C40 Slot: 13
	public virtual IAsyncResult BeginInvoke(void* userData, byte* buffer, IntPtr bufferLen, UnityTls.unitytls_errorstate* errorState, AsyncCallback callback, object object) { }

	// RVA: 0x1A93CF0 Offset: 0x1A93CF0 VA: 0x1A93CF0 Slot: 14
	public virtual IntPtr EndInvoke(IAsyncResult result) { }
}
