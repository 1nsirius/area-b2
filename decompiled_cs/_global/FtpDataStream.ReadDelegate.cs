// Namespace: 
private sealed class FtpDataStream.ReadDelegate : MulticastDelegate // TypeDefIndex: 1981
{
	// Methods

	// RVA: 0x14C5570 Offset: 0x14C5570 VA: 0x14C5570
	public void .ctor(object object, IntPtr method) { }

	// RVA: 0x14C6544 Offset: 0x14C6544 VA: 0x14C6544 Slot: 12
	public virtual int Invoke(byte[] buffer, int offset, int size) { }

	// RVA: 0x14C5584 Offset: 0x14C5584 VA: 0x14C5584 Slot: 13
	public virtual IAsyncResult BeginInvoke(byte[] buffer, int offset, int size, AsyncCallback callback, object object) { }

	// RVA: 0x14C5804 Offset: 0x14C5804 VA: 0x14C5804 Slot: 14
	public virtual int EndInvoke(IAsyncResult result) { }
}
