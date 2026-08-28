// Namespace: 
public sealed class MemoryOutputStream.flusher : MulticastDelegate // TypeDefIndex: 8760
{
	// Methods

	// RVA: 0x10D9D00 Offset: 0x10D9D00 VA: 0x10D9D00
	public void .ctor(object object, IntPtr method) { }

	// RVA: 0x10D8EA8 Offset: 0x10D8EA8 VA: 0x10D8EA8 Slot: 12
	public virtual void Invoke(IBuffer buffer, int length) { }

	// RVA: 0x10D9D14 Offset: 0x10D9D14 VA: 0x10D9D14 Slot: 13
	public virtual IAsyncResult BeginInvoke(IBuffer buffer, int length, AsyncCallback callback, object object) { }

	// RVA: 0x10D9DB4 Offset: 0x10D9DB4 VA: 0x10D9DB4 Slot: 14
	public virtual void EndInvoke(IAsyncResult result) { }
}
