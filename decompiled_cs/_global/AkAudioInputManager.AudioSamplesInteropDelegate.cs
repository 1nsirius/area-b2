// Namespace: 
[UnmanagedFunctionPointerAttribute] // RVA: 0x558F68 Offset: 0x558F68 VA: 0x558F68
public sealed class AkAudioInputManager.AudioSamplesInteropDelegate : MulticastDelegate // TypeDefIndex: 5968
{
	// Methods

	// RVA: 0xFD83C8 Offset: 0xFD83C8 VA: 0xFD83C8
	public void .ctor(object object, IntPtr method) { }

	// RVA: 0xFD8AF8 Offset: 0xFD8AF8 VA: 0xFD8AF8 Slot: 12
	public virtual bool Invoke(uint playingID, [In] [Out] float[] samples, uint channelIndex, uint frames) { }

	// RVA: 0xFD9040 Offset: 0xFD9040 VA: 0xFD9040 Slot: 13
	public virtual IAsyncResult BeginInvoke(uint playingID, [In] [Out] float[] samples, uint channelIndex, uint frames, AsyncCallback callback, object object) { }

	// RVA: 0xFD9108 Offset: 0xFD9108 VA: 0xFD9108 Slot: 14
	public virtual bool EndInvoke(IAsyncResult result) { }
}
