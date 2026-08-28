// Namespace: 
public sealed class AudioSampleProvider.SampleFramesHandler : MulticastDelegate // TypeDefIndex: 3647
{
	// Methods

	// RVA: 0x2C7E01C Offset: 0x2C7E01C VA: 0x2C7E01C
	public void .ctor(object object, IntPtr method) { }

	// RVA: 0x2C7D148 Offset: 0x2C7D148 VA: 0x2C7D148 Slot: 12
	public virtual void Invoke(AudioSampleProvider provider, uint sampleFrameCount) { }

	// RVA: 0x2C7E030 Offset: 0x2C7E030 VA: 0x2C7E030 Slot: 13
	public virtual IAsyncResult BeginInvoke(AudioSampleProvider provider, uint sampleFrameCount, AsyncCallback callback, object object) { }

	// RVA: 0x2C7E0D0 Offset: 0x2C7E0D0 VA: 0x2C7E0D0 Slot: 14
	public virtual void EndInvoke(IAsyncResult result) { }
}
