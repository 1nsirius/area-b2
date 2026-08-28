// Namespace: 
[UnmanagedFunctionPointerAttribute] // RVA: 0x4E514C Offset: 0x4E514C VA: 0x4E514C
public sealed class UnityTls.unitytls_interface_struct.unitytls_errorstate_raise_error_t : MulticastDelegate // TypeDefIndex: 1554
{
	// Methods

	// RVA: 0x18E33A8 Offset: 0x18E33A8 VA: 0x18E33A8
	public void .ctor(object object, IntPtr method) { }

	// RVA: 0x18E33BC Offset: 0x18E33BC VA: 0x18E33BC Slot: 12
	public virtual void Invoke(UnityTls.unitytls_errorstate* errorState, UnityTls.unitytls_error_code errorCode) { }

	// RVA: 0x18E3840 Offset: 0x18E3840 VA: 0x18E3840 Slot: 13
	public virtual IAsyncResult BeginInvoke(UnityTls.unitytls_errorstate* errorState, UnityTls.unitytls_error_code errorCode, AsyncCallback callback, object object) { }

	// RVA: 0x18E38E0 Offset: 0x18E38E0 VA: 0x18E38E0 Slot: 14
	public virtual void EndInvoke(IAsyncResult result) { }
}
