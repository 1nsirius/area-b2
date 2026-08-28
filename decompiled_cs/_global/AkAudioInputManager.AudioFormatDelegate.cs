// Namespace: 
public sealed class AkAudioInputManager.AudioFormatDelegate : MulticastDelegate // TypeDefIndex: 5965
{
	// Methods

	// RVA: 0xFD83F0 Offset: 0xFD83F0 VA: 0xFD83F0
	public void .ctor(object object, IntPtr method) { }

	// RVA: 0xFD7BBC Offset: 0xFD7BBC VA: 0xFD7BBC Slot: 12
	public virtual void Invoke(uint playingID, AkAudioFormat format) { }

	// RVA: 0xFD8404 Offset: 0xFD8404 VA: 0xFD8404 Slot: 13
	public virtual IAsyncResult BeginInvoke(uint playingID, AkAudioFormat format, AsyncCallback callback, object object) { }

	// RVA: 0xFD84A0 Offset: 0xFD84A0 VA: 0xFD84A0 Slot: 14
	public virtual void EndInvoke(IAsyncResult result) { }
}
