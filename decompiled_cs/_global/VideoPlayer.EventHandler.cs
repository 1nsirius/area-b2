// Namespace: 
public sealed class VideoPlayer.EventHandler : MulticastDelegate // TypeDefIndex: 3941
{
	// Methods

	// RVA: 0x2CAFE90 Offset: 0x2CAFE90 VA: 0x2CAFE90
	public void .ctor(object object, IntPtr method) { }

	// RVA: 0x2CADBD4 Offset: 0x2CADBD4 VA: 0x2CADBD4 Slot: 12
	public virtual void Invoke(VideoPlayer source) { }

	// RVA: 0x2CAFEA4 Offset: 0x2CAFEA4 VA: 0x2CAFEA4 Slot: 13
	public virtual IAsyncResult BeginInvoke(VideoPlayer source, AsyncCallback callback, object object) { }

	// RVA: 0x2CAFED0 Offset: 0x2CAFED0 VA: 0x2CAFED0 Slot: 14
	public virtual void EndInvoke(IAsyncResult result) { }
}
