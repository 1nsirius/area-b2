// Namespace: 
public sealed class AudioClip.PCMSetPositionCallback : MulticastDelegate // TypeDefIndex: 3653
{
	// Methods

	// RVA: 0x2C792DC Offset: 0x2C792DC VA: 0x2C792DC
	public void .ctor(object object, IntPtr method) { }

	// RVA: 0x2C78E2C Offset: 0x2C78E2C VA: 0x2C78E2C Slot: 12
	public virtual void Invoke(int position) { }

	// RVA: 0x2C792F0 Offset: 0x2C792F0 VA: 0x2C792F0 Slot: 13
	public virtual IAsyncResult BeginInvoke(int position, AsyncCallback callback, object object) { }

	// RVA: 0x2C7938C Offset: 0x2C7938C VA: 0x2C7938C Slot: 14
	public virtual void EndInvoke(IAsyncResult result) { }
}
