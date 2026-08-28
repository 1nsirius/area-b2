// Namespace: 
private sealed class FileStream.ReadDelegate : MulticastDelegate // TypeDefIndex: 652
{
	// Methods

	// RVA: 0x1908A44 Offset: 0x1908A44 VA: 0x1908A44
	public void .ctor(object object, IntPtr method) { }

	// RVA: 0x190AC28 Offset: 0x190AC28 VA: 0x190AC28 Slot: 12
	public virtual int Invoke(byte[] buffer, int offset, int count) { }

	// RVA: 0x1908A58 Offset: 0x1908A58 VA: 0x1908A58 Slot: 13
	public virtual IAsyncResult BeginInvoke(byte[] buffer, int offset, int count, AsyncCallback callback, object object) { }

	// RVA: 0x1908CFC Offset: 0x1908CFC VA: 0x1908CFC Slot: 14
	public virtual int EndInvoke(IAsyncResult result) { }
}
