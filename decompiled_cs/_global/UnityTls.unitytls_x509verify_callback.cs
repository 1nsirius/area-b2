// Namespace: 
[UnmanagedFunctionPointerAttribute] // RVA: 0x4E50C0 Offset: 0x4E50C0 VA: 0x4E50C0
public sealed class UnityTls.unitytls_x509verify_callback : MulticastDelegate // TypeDefIndex: 1540
{
	// Methods

	// RVA: 0x1A94F10 Offset: 0x1A94F10 VA: 0x1A94F10
	public void .ctor(object object, IntPtr method) { }

	// RVA: 0x1A94F24 Offset: 0x1A94F24 VA: 0x1A94F24 Slot: 12
	public virtual UnityTls.unitytls_x509verify_result Invoke(void* userData, UnityTls.unitytls_x509_ref cert, UnityTls.unitytls_x509verify_result result, UnityTls.unitytls_errorstate* errorState) { }

	// RVA: 0x1A954CC Offset: 0x1A954CC VA: 0x1A954CC Slot: 13
	public virtual IAsyncResult BeginInvoke(void* userData, UnityTls.unitytls_x509_ref cert, UnityTls.unitytls_x509verify_result result, UnityTls.unitytls_errorstate* errorState, AsyncCallback callback, object object) { }

	// RVA: 0x1A95594 Offset: 0x1A95594 VA: 0x1A95594 Slot: 14
	public virtual UnityTls.unitytls_x509verify_result EndInvoke(IAsyncResult result) { }
}
