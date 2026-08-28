// Namespace: 
public sealed class AkAudioInputManager.AudioSamplesDelegate : MulticastDelegate // TypeDefIndex: 5967
{
	// Methods

	// RVA: 0xFD89F8 Offset: 0xFD89F8 VA: 0xFD89F8
	public void .ctor(object object, IntPtr method) { }

	// RVA: 0xFD7700 Offset: 0xFD7700 VA: 0xFD7700 Slot: 12
	public virtual bool Invoke(uint playingID, uint channelIndex, float[] samples) { }

	// RVA: 0xFD8A0C Offset: 0xFD8A0C VA: 0xFD8A0C Slot: 13
	public virtual IAsyncResult BeginInvoke(uint playingID, uint channelIndex, float[] samples, AsyncCallback callback, object object) { }

	// RVA: 0xFD8AC0 Offset: 0xFD8AC0 VA: 0xFD8AC0 Slot: 14
	public virtual bool EndInvoke(IAsyncResult result) { }
}
