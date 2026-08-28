// Namespace: 
[UnmanagedFunctionPointerAttribute] // RVA: 0x4E5228 Offset: 0x4E5228 VA: 0x4E5228
public sealed class UnityTls.unitytls_interface_struct.unitytls_x509list_free_t : MulticastDelegate // TypeDefIndex: 1565
{
	// Methods

	// RVA: 0x18EAF28 Offset: 0x18EAF28 VA: 0x18EAF28
	public void .ctor(object object, IntPtr method) { }

	// RVA: 0x18EAF3C Offset: 0x18EAF3C VA: 0x18EAF3C Slot: 12
	public virtual void Invoke(UnityTls.unitytls_x509list* list) { }

	// RVA: 0x18EB3A0 Offset: 0x18EB3A0 VA: 0x18EB3A0 Slot: 13
	public virtual IAsyncResult BeginInvoke(UnityTls.unitytls_x509list* list, AsyncCallback callback, object object) { }

	// RVA: 0x18EB3CC Offset: 0x18EB3CC VA: 0x18EB3CC Slot: 14
	public virtual void EndInvoke(IAsyncResult result) { }
}
