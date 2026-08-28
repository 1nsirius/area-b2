// Namespace: 
[UnmanagedFunctionPointerAttribute] // RVA: 0x4E5174 Offset: 0x4E5174 VA: 0x4E5174
public sealed class UnityTls.unitytls_interface_struct.unitytls_key_parse_der_t : MulticastDelegate // TypeDefIndex: 1556
{
	// Methods

	// RVA: 0x18E42D4 Offset: 0x18E42D4 VA: 0x18E42D4
	public void .ctor(object object, IntPtr method) { }

	// RVA: 0x18E42E8 Offset: 0x18E42E8 VA: 0x18E42E8 Slot: 12
	public virtual UnityTls.unitytls_key* Invoke(byte* buffer, IntPtr bufferLen, byte* password, IntPtr passwordLen, UnityTls.unitytls_errorstate* errorState) { }

	// RVA: 0x18E4874 Offset: 0x18E4874 VA: 0x18E4874 Slot: 13
	public virtual IAsyncResult BeginInvoke(byte* buffer, IntPtr bufferLen, byte* password, IntPtr passwordLen, UnityTls.unitytls_errorstate* errorState, AsyncCallback callback, object object) { }

	// RVA: 0x18E4934 Offset: 0x18E4934 VA: 0x18E4934 Slot: 14
	public virtual UnityTls.unitytls_key* EndInvoke(IAsyncResult result) { }
}
