// Namespace: 
[UnmanagedFunctionPointerAttribute] // RVA: 0x4E5368 Offset: 0x4E5368 VA: 0x4E5368
public sealed class UnityTls.unitytls_interface_struct.unitytls_tlsctx_free_t : MulticastDelegate // TypeDefIndex: 1581
{
	// Methods

	// RVA: 0x18E6424 Offset: 0x18E6424 VA: 0x18E6424
	public void .ctor(object object, IntPtr method) { }

	// RVA: 0x18E6438 Offset: 0x18E6438 VA: 0x18E6438 Slot: 12
	public virtual void Invoke(UnityTls.unitytls_tlsctx* ctx) { }

	// RVA: 0x18E689C Offset: 0x18E689C VA: 0x18E689C Slot: 13
	public virtual IAsyncResult BeginInvoke(UnityTls.unitytls_tlsctx* ctx, AsyncCallback callback, object object) { }

	// RVA: 0x18E68C8 Offset: 0x18E68C8 VA: 0x18E68C8 Slot: 14
	public virtual void EndInvoke(IAsyncResult result) { }
}
