// Namespace: 
public sealed class VideoPlayer.ErrorEventHandler : MulticastDelegate // TypeDefIndex: 3942
{
	// Methods

	// RVA: 0x2CAFE38 Offset: 0x2CAFE38 VA: 0x2CAFE38
	public void .ctor(object object, IntPtr method) { }

	// RVA: 0x2CAED28 Offset: 0x2CAED28 VA: 0x2CAED28 Slot: 12
	public virtual void Invoke(VideoPlayer source, string message) { }

	// RVA: 0x2CAFE4C Offset: 0x2CAFE4C VA: 0x2CAFE4C Slot: 13
	public virtual IAsyncResult BeginInvoke(VideoPlayer source, string message, AsyncCallback callback, object object) { }

	// RVA: 0x2CAFE84 Offset: 0x2CAFE84 VA: 0x2CAFE84 Slot: 14
	public virtual void EndInvoke(IAsyncResult result) { }
}
