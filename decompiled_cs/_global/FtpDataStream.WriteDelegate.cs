// Namespace: 
private sealed class FtpDataStream.WriteDelegate : MulticastDelegate // TypeDefIndex: 1980
{
	// Methods

	// RVA: 0x14C5E6C Offset: 0x14C5E6C VA: 0x14C5E6C
	public void .ctor(object object, IntPtr method) { }

	// RVA: 0x14C6E38 Offset: 0x14C6E38 VA: 0x14C6E38 Slot: 12
	public virtual void Invoke(byte[] buffer, int offset, int size) { }

	// RVA: 0x14C5E80 Offset: 0x14C5E80 VA: 0x14C5E80 Slot: 13
	public virtual IAsyncResult BeginInvoke(byte[] buffer, int offset, int size, AsyncCallback callback, object object) { }

	// RVA: 0x14C6104 Offset: 0x14C6104 VA: 0x14C6104 Slot: 14
	public virtual void EndInvoke(IAsyncResult result) { }
}
