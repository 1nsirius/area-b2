// Namespace: 
public sealed class NativeGallery.MediaPickMultipleCallback : MulticastDelegate // TypeDefIndex: 5255
{
	// Methods

	// RVA: 0x2CE036C Offset: 0x2CE036C VA: 0x2CE036C
	public void .ctor(object object, IntPtr method) { }

	// RVA: 0x2CDDB20 Offset: 0x2CDDB20 VA: 0x2CDDB20 Slot: 12
	public virtual void Invoke(string[] paths) { }

	// RVA: 0x2CE0380 Offset: 0x2CE0380 VA: 0x2CE0380 Slot: 13
	public virtual IAsyncResult BeginInvoke(string[] paths, AsyncCallback callback, object object) { }

	// RVA: 0x2CE03AC Offset: 0x2CE03AC VA: 0x2CE03AC Slot: 14
	public virtual void EndInvoke(IAsyncResult result) { }
}
