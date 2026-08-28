// Namespace: 
[UnmanagedFunctionPointerAttribute] // RVA: 0x558F54 Offset: 0x558F54 VA: 0x558F54
public sealed class AkAudioInputManager.AudioFormatInteropDelegate : MulticastDelegate // TypeDefIndex: 5966
{
	// Methods

	// RVA: 0xFD83DC Offset: 0xFD83DC VA: 0xFD83DC
	public void .ctor(object object, IntPtr method) { }

	// RVA: 0xFD84AC Offset: 0xFD84AC VA: 0xFD84AC Slot: 12
	public virtual void Invoke(uint playingID, IntPtr format) { }

	// RVA: 0xFD8930 Offset: 0xFD8930 VA: 0xFD8930 Slot: 13
	public virtual IAsyncResult BeginInvoke(uint playingID, IntPtr format, AsyncCallback callback, object object) { }

	// RVA: 0xFD89EC Offset: 0xFD89EC VA: 0xFD89EC Slot: 14
	public virtual void EndInvoke(IAsyncResult result) { }
}
