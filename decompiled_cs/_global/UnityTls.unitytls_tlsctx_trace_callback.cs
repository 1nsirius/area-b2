// Namespace: 
[UnmanagedFunctionPointerAttribute] // RVA: 0x4E50FC Offset: 0x4E50FC VA: 0x4E50FC
public sealed class UnityTls.unitytls_tlsctx_trace_callback : MulticastDelegate // TypeDefIndex: 1548
{
	// Methods

	// RVA: 0x1A93D28 Offset: 0x1A93D28 VA: 0x1A93D28
	public void .ctor(object object, IntPtr method) { }

	// RVA: 0x1A93D3C Offset: 0x1A93D3C VA: 0x1A93D3C Slot: 12
	public virtual void Invoke(void* userData, UnityTls.unitytls_tlsctx* ctx, byte* traceMessage, IntPtr traceMessageLen) { }

	// RVA: 0x1A941BC Offset: 0x1A941BC VA: 0x1A941BC Slot: 13
	public virtual IAsyncResult BeginInvoke(void* userData, UnityTls.unitytls_tlsctx* ctx, byte* traceMessage, IntPtr traceMessageLen, AsyncCallback callback, object object) { }

	// RVA: 0x1A94268 Offset: 0x1A94268 VA: 0x1A94268 Slot: 14
	public virtual void EndInvoke(IAsyncResult result) { }
}
