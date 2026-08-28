// Namespace: 
[UnmanagedFunctionPointerAttribute] // RVA: 0x4E50D4 Offset: 0x4E50D4 VA: 0x4E50D4
public sealed class UnityTls.unitytls_tlsctx_write_callback : MulticastDelegate // TypeDefIndex: 1546
{
	// Methods

	// RVA: 0x1A94274 Offset: 0x1A94274 VA: 0x1A94274
	public void .ctor(object object, IntPtr method) { }

	// RVA: 0x1A94288 Offset: 0x1A94288 VA: 0x1A94288 Slot: 12
	public virtual IntPtr Invoke(void* userData, byte* data, IntPtr bufferLen, UnityTls.unitytls_errorstate* errorState) { }

	// RVA: 0x1A947D8 Offset: 0x1A947D8 VA: 0x1A947D8 Slot: 13
	public virtual IAsyncResult BeginInvoke(void* userData, byte* data, IntPtr bufferLen, UnityTls.unitytls_errorstate* errorState, AsyncCallback callback, object object) { }

	// RVA: 0x1A94888 Offset: 0x1A94888 VA: 0x1A94888 Slot: 14
	public virtual IntPtr EndInvoke(IAsyncResult result) { }
}
