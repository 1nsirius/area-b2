// Namespace: 
public sealed class AnimationState.TrackEntryEventDelegate : MulticastDelegate // TypeDefIndex: 7147
{
	// Methods

	// RVA: 0xF86E64 Offset: 0xF86E64 VA: 0xF86E64
	public void .ctor(object object, IntPtr method) { }

	// RVA: 0xF864B4 Offset: 0xF864B4 VA: 0xF864B4 Slot: 12
	public virtual void Invoke(TrackEntry trackEntry, Event e) { }

	// RVA: 0xF86E78 Offset: 0xF86E78 VA: 0xF86E78 Slot: 13
	public virtual IAsyncResult BeginInvoke(TrackEntry trackEntry, Event e, AsyncCallback callback, object object) { }

	// RVA: 0xF86EB0 Offset: 0xF86EB0 VA: 0xF86EB0 Slot: 14
	public virtual void EndInvoke(IAsyncResult result) { }
}
