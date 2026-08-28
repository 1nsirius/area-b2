// Namespace: 
public sealed class VideoPlayer.FrameReadyEventHandler : MulticastDelegate // TypeDefIndex: 3943
{
	// Methods

	// RVA: 0x2CAFEDC Offset: 0x2CAFEDC VA: 0x2CAFEDC
	public void .ctor(object object, IntPtr method) { }

	// RVA: 0x2CAE448 Offset: 0x2CAE448 VA: 0x2CAE448 Slot: 12
	public virtual void Invoke(VideoPlayer source, long frameIdx) { }

	// RVA: 0x2CAFEF0 Offset: 0x2CAFEF0 VA: 0x2CAFEF0 Slot: 13
	public virtual IAsyncResult BeginInvoke(VideoPlayer source, long frameIdx, AsyncCallback callback, object object) { }

	// RVA: 0x2CAFF94 Offset: 0x2CAFF94 VA: 0x2CAFF94 Slot: 14
	public virtual void EndInvoke(IAsyncResult result) { }
}
