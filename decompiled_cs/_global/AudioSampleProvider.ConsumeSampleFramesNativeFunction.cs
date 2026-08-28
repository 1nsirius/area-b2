// Namespace: 
[UnmanagedFunctionPointerAttribute] // RVA: 0x5104C4 Offset: 0x5104C4 VA: 0x5104C4
public sealed class AudioSampleProvider.ConsumeSampleFramesNativeFunction : MulticastDelegate // TypeDefIndex: 3646
{
	// Methods

	// RVA: 0x2C7D9E8 Offset: 0x2C7D9E8 VA: 0x2C7D9E8
	public void .ctor(object object, IntPtr method) { }

	// RVA: 0x2C7D9FC Offset: 0x2C7D9FC VA: 0x2C7D9FC Slot: 12
	public virtual uint Invoke(uint providerId, IntPtr interleavedSampleFrames, uint sampleFrameCount) { }

	// RVA: 0x2C7DF10 Offset: 0x2C7DF10 VA: 0x2C7DF10 Slot: 13
	public virtual IAsyncResult BeginInvoke(uint providerId, IntPtr interleavedSampleFrames, uint sampleFrameCount, AsyncCallback callback, object object) { }

	// RVA: 0x2C7DFE4 Offset: 0x2C7DFE4 VA: 0x2C7DFE4 Slot: 14
	public virtual uint EndInvoke(IAsyncResult result) { }
}
