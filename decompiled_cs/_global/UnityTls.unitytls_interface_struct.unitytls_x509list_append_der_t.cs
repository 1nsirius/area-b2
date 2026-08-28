// Namespace: 
[UnmanagedFunctionPointerAttribute] // RVA: 0x4E5214 Offset: 0x4E5214 VA: 0x4E5214
public sealed class UnityTls.unitytls_interface_struct.unitytls_x509list_append_der_t : MulticastDelegate // TypeDefIndex: 1564
{
	// Methods

	// RVA: 0x18EA41C Offset: 0x18EA41C VA: 0x18EA41C
	public void .ctor(object object, IntPtr method) { }

	// RVA: 0x18E194C Offset: 0x18E194C VA: 0x18E194C Slot: 12
	public virtual void Invoke(UnityTls.unitytls_x509list* list, byte* buffer, IntPtr bufferLen, UnityTls.unitytls_errorstate* errorState) { }

	// RVA: 0x18EA430 Offset: 0x18EA430 VA: 0x18EA430 Slot: 13
	public virtual IAsyncResult BeginInvoke(UnityTls.unitytls_x509list* list, byte* buffer, IntPtr bufferLen, UnityTls.unitytls_errorstate* errorState, AsyncCallback callback, object object) { }

	// RVA: 0x18EA4E0 Offset: 0x18EA4E0 VA: 0x18EA4E0 Slot: 14
	public virtual void EndInvoke(IAsyncResult result) { }
}
