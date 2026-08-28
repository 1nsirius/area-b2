// Namespace: 
[UnmanagedFunctionPointerAttribute] // RVA: 0x4E51B0 Offset: 0x4E51B0 VA: 0x4E51B0
public sealed class UnityTls.unitytls_interface_struct.unitytls_x509_export_der_t : MulticastDelegate // TypeDefIndex: 1559
{
	// Methods

	// RVA: 0x18EA308 Offset: 0x18EA308 VA: 0x18EA308
	public void .ctor(object object, IntPtr method) { }

	// RVA: 0x18E2658 Offset: 0x18E2658 VA: 0x18E2658 Slot: 12
	public virtual IntPtr Invoke(UnityTls.unitytls_x509_ref cert, byte* buffer, IntPtr bufferLen, UnityTls.unitytls_errorstate* errorState) { }

	// RVA: 0x18EA31C Offset: 0x18EA31C VA: 0x18EA31C Slot: 13
	public virtual IAsyncResult BeginInvoke(UnityTls.unitytls_x509_ref cert, byte* buffer, IntPtr bufferLen, UnityTls.unitytls_errorstate* errorState, AsyncCallback callback, object object) { }

	// RVA: 0x18EA3E4 Offset: 0x18EA3E4 VA: 0x18EA3E4 Slot: 14
	public virtual IntPtr EndInvoke(IAsyncResult result) { }
}
