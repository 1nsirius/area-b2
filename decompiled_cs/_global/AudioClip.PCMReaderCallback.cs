// Namespace: 
public sealed class AudioClip.PCMReaderCallback : MulticastDelegate // TypeDefIndex: 3652
{
	// Methods

	// RVA: 0x2C79290 Offset: 0x2C79290 VA: 0x2C79290
	public void .ctor(object object, IntPtr method) { }

	// RVA: 0x2C785F4 Offset: 0x2C785F4 VA: 0x2C785F4 Slot: 12
	public virtual void Invoke(float[] data) { }

	// RVA: 0x2C792A4 Offset: 0x2C792A4 VA: 0x2C792A4 Slot: 13
	public virtual IAsyncResult BeginInvoke(float[] data, AsyncCallback callback, object object) { }

	// RVA: 0x2C792D0 Offset: 0x2C792D0 VA: 0x2C792D0 Slot: 14
	public virtual void EndInvoke(IAsyncResult result) { }
}
