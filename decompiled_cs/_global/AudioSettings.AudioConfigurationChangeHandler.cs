// Namespace: 
public sealed class AudioSettings.AudioConfigurationChangeHandler : MulticastDelegate // TypeDefIndex: 3650
{
	// Methods

	// RVA: 0x2C7C6F4 Offset: 0x2C7C6F4 VA: 0x2C7C6F4
	public void .ctor(object object, IntPtr method) { }

	// RVA: 0x2C7BF40 Offset: 0x2C7BF40 VA: 0x2C7BF40 Slot: 12
	public virtual void Invoke(bool deviceWasChanged) { }

	// RVA: 0x2C7C708 Offset: 0x2C7C708 VA: 0x2C7C708 Slot: 13
	public virtual IAsyncResult BeginInvoke(bool deviceWasChanged, AsyncCallback callback, object object) { }

	// RVA: 0x2C7C7A4 Offset: 0x2C7C7A4 VA: 0x2C7C7A4 Slot: 14
	public virtual void EndInvoke(IAsyncResult result) { }
}
