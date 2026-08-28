// Namespace: 
public sealed class HotUpdateUIProxy.ProgressHandler : MulticastDelegate // TypeDefIndex: 8956
{
	// Methods

	// RVA: 0xDA3798 Offset: 0xDA3798 VA: 0xDA3798
	public void .ctor(object object, IntPtr method) { }

	// RVA: 0xD9AC68 Offset: 0xD9AC68 VA: 0xD9AC68 Slot: 12
	public virtual void Invoke(float value) { }

	// RVA: 0xDA37AC Offset: 0xDA37AC VA: 0xDA37AC Slot: 13
	public virtual IAsyncResult BeginInvoke(float value, AsyncCallback callback, object object) { }

	// RVA: 0xDA3848 Offset: 0xDA3848 VA: 0xDA3848 Slot: 14
	public virtual void EndInvoke(IAsyncResult result) { }
}
