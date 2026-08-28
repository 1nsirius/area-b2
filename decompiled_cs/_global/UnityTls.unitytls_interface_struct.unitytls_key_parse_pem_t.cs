// Namespace: 
[UnmanagedFunctionPointerAttribute] // RVA: 0x4E5188 Offset: 0x4E5188 VA: 0x4E5188
public sealed class UnityTls.unitytls_interface_struct.unitytls_key_parse_pem_t : MulticastDelegate // TypeDefIndex: 1557
{
	// Methods

	// RVA: 0x18E4940 Offset: 0x18E4940 VA: 0x18E4940
	public void .ctor(object object, IntPtr method) { }

	// RVA: 0x18E4954 Offset: 0x18E4954 VA: 0x18E4954 Slot: 12
	public virtual UnityTls.unitytls_key* Invoke(byte* buffer, IntPtr bufferLen, byte* password, IntPtr passwordLen, UnityTls.unitytls_errorstate* errorState) { }

	// RVA: 0x18E4EE0 Offset: 0x18E4EE0 VA: 0x18E4EE0 Slot: 13
	public virtual IAsyncResult BeginInvoke(byte* buffer, IntPtr bufferLen, byte* password, IntPtr passwordLen, UnityTls.unitytls_errorstate* errorState, AsyncCallback callback, object object) { }

	// RVA: 0x18E4FA0 Offset: 0x18E4FA0 VA: 0x18E4FA0 Slot: 14
	public virtual UnityTls.unitytls_key* EndInvoke(IAsyncResult result) { }
}
