// Namespace: 
public sealed class AkCallbackManager.EventCallback : MulticastDelegate // TypeDefIndex: 5975
{
	// Methods

	// RVA: 0xFD580C Offset: 0xFD580C VA: 0xFD580C
	public void .ctor(object object, IntPtr method) { }

	// RVA: 0xFE24EC Offset: 0xFE24EC VA: 0xFE24EC Slot: 12
	public virtual void Invoke(object in_cookie, AkCallbackType in_type, AkCallbackInfo in_info) { }

	// RVA: 0xFE350C Offset: 0xFE350C VA: 0xFE350C Slot: 13
	public virtual IAsyncResult BeginInvoke(object in_cookie, AkCallbackType in_type, AkCallbackInfo in_info, AsyncCallback callback, object object) { }

	// RVA: 0xFE35B4 Offset: 0xFE35B4 VA: 0xFE35B4 Slot: 14
	public virtual void EndInvoke(IAsyncResult result) { }
}
