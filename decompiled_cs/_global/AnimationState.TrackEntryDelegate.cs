// Namespace: 
public sealed class AnimationState.TrackEntryDelegate : MulticastDelegate // TypeDefIndex: 7146
{
	// Methods

	// RVA: 0xF86E18 Offset: 0xF86E18 VA: 0xF86E18
	public void .ctor(object object, IntPtr method) { }

	// RVA: 0xF85C3C Offset: 0xF85C3C VA: 0xF85C3C Slot: 12
	public virtual void Invoke(TrackEntry trackEntry) { }

	// RVA: 0xF86E2C Offset: 0xF86E2C VA: 0xF86E2C Slot: 13
	public virtual IAsyncResult BeginInvoke(TrackEntry trackEntry, AsyncCallback callback, object object) { }

	// RVA: 0xF86E58 Offset: 0xF86E58 VA: 0xF86E58 Slot: 14
	public virtual void EndInvoke(IAsyncResult result) { }
}
