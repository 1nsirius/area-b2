// Namespace: 
private sealed class FileStream.WriteDelegate : MulticastDelegate // TypeDefIndex: 653
{
	// Methods

	// RVA: 0x1909944 Offset: 0x1909944 VA: 0x1909944
	public void .ctor(object object, IntPtr method) { }

	// RVA: 0x190B51C Offset: 0x190B51C VA: 0x190B51C Slot: 12
	public virtual void Invoke(byte[] buffer, int offset, int count) { }

	// RVA: 0x1909958 Offset: 0x1909958 VA: 0x1909958 Slot: 13
	public virtual IAsyncResult BeginInvoke(byte[] buffer, int offset, int count, AsyncCallback callback, object object) { }

	// RVA: 0x1909C00 Offset: 0x1909C00 VA: 0x1909C00 Slot: 14
	public virtual void EndInvoke(IAsyncResult result) { }
}
