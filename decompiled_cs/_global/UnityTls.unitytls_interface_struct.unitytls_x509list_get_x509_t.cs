// Namespace: 
[UnmanagedFunctionPointerAttribute] // RVA: 0x4E51D8 Offset: 0x4E51D8 VA: 0x4E51D8
public sealed class UnityTls.unitytls_interface_struct.unitytls_x509list_get_x509_t : MulticastDelegate // TypeDefIndex: 1561
{
	// Methods

	// RVA: 0x18EB910 Offset: 0x18EB910 VA: 0x18EB910
	public void .ctor(object object, IntPtr method) { }

	// RVA: 0x18E2154 Offset: 0x18E2154 VA: 0x18E2154 Slot: 12
	public virtual UnityTls.unitytls_x509_ref Invoke(UnityTls.unitytls_x509list_ref list, IntPtr index, UnityTls.unitytls_errorstate* errorState) { }

	// RVA: 0x18EB924 Offset: 0x18EB924 VA: 0x18EB924 Slot: 13
	public virtual IAsyncResult BeginInvoke(UnityTls.unitytls_x509list_ref list, IntPtr index, UnityTls.unitytls_errorstate* errorState, AsyncCallback callback, object object) { }

	// RVA: 0x18EB9E4 Offset: 0x18EB9E4 VA: 0x18EB9E4 Slot: 14
	public virtual UnityTls.unitytls_x509_ref EndInvoke(IAsyncResult result) { }
}
