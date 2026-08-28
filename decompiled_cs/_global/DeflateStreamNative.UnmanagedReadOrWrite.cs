// Namespace: 
[UnmanagedFunctionPointerAttribute] // RVA: 0x4E6118 Offset: 0x4E6118 VA: 0x4E6118
private sealed class DeflateStreamNative.UnmanagedReadOrWrite : MulticastDelegate // TypeDefIndex: 1877
{
	// Methods

	// RVA: 0x1ADDC14 Offset: 0x1ADDC14 VA: 0x1ADDC14
	public void .ctor(object object, IntPtr method) { }

	// RVA: 0x1ADE3D8 Offset: 0x1ADE3D8 VA: 0x1ADE3D8 Slot: 12
	public virtual int Invoke(IntPtr buffer, int length, IntPtr data) { }

	// RVA: 0x1ADE8EC Offset: 0x1ADE8EC VA: 0x1ADE8EC Slot: 13
	public virtual IAsyncResult BeginInvoke(IntPtr buffer, int length, IntPtr data, AsyncCallback callback, object object) { }

	// RVA: 0x1ADE9C0 Offset: 0x1ADE9C0 VA: 0x1ADE9C0 Slot: 14
	public virtual int EndInvoke(IAsyncResult result) { }
}
