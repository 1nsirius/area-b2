// Namespace: 
public sealed class AkCallbackManager.BGMCallback : MulticastDelegate // TypeDefIndex: 5980
{
	// Methods

	// RVA: 0xFE3228 Offset: 0xFE3228 VA: 0xFE3228
	public void .ctor(object object, IntPtr method) { }

	// RVA: 0xFE1B50 Offset: 0xFE1B50 VA: 0xFE1B50 Slot: 12
	public virtual AKRESULT Invoke(bool in_bOtherAudioPlaying, object in_Cookie) { }

	// RVA: 0xFE323C Offset: 0xFE323C VA: 0xFE323C Slot: 13
	public virtual IAsyncResult BeginInvoke(bool in_bOtherAudioPlaying, object in_Cookie, AsyncCallback callback, object object) { }

	// RVA: 0xFE32D8 Offset: 0xFE32D8 VA: 0xFE32D8 Slot: 14
	public virtual AKRESULT EndInvoke(IAsyncResult result) { }
}
