// Namespace: 
[UnmanagedFunctionPointerAttribute] // RVA: 0x4E537C Offset: 0x4E537C VA: 0x4E537C
public sealed class UnityTls.unitytls_interface_struct.unitytls_random_generate_bytes_t : MulticastDelegate // TypeDefIndex: 1582
{
	// Methods

	// RVA: 0x18E4FAC Offset: 0x18E4FAC VA: 0x18E4FAC
	public void .ctor(object object, IntPtr method) { }

	// RVA: 0x18E4FC0 Offset: 0x18E4FC0 VA: 0x18E4FC0 Slot: 12
	public virtual void Invoke(byte* buffer, IntPtr bufferLen, UnityTls.unitytls_errorstate* errorState) { }

	// RVA: 0x18E541C Offset: 0x18E541C VA: 0x18E541C Slot: 13
	public virtual IAsyncResult BeginInvoke(byte* buffer, IntPtr bufferLen, UnityTls.unitytls_errorstate* errorState, AsyncCallback callback, object object) { }

	// RVA: 0x18E54C4 Offset: 0x18E54C4 VA: 0x18E54C4 Slot: 14
	public virtual void EndInvoke(IAsyncResult result) { }
}
