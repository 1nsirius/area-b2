// Namespace: 
public sealed class VideoPlayer.TimeEventHandler : MulticastDelegate // TypeDefIndex: 3944
{
	// Methods

	// RVA: 0x2CAFFA0 Offset: 0x2CAFFA0 VA: 0x2CAFFA0
	public void .ctor(object object, IntPtr method) { }

	// RVA: 0x2CAF630 Offset: 0x2CAF630 VA: 0x2CAF630 Slot: 12
	public virtual void Invoke(VideoPlayer source, double seconds) { }

	// RVA: 0x2CAFFB4 Offset: 0x2CAFFB4 VA: 0x2CAFFB4 Slot: 13
	public virtual IAsyncResult BeginInvoke(VideoPlayer source, double seconds, AsyncCallback callback, object object) { }

	// RVA: 0x2CB0058 Offset: 0x2CB0058 VA: 0x2CB0058 Slot: 14
	public virtual void EndInvoke(IAsyncResult result) { }
}
