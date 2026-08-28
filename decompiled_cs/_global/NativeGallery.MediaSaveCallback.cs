// Namespace: 
public sealed class NativeGallery.MediaSaveCallback : MulticastDelegate // TypeDefIndex: 5253
{
	// Methods

	// RVA: 0x2CE03B8 Offset: 0x2CE03B8 VA: 0x2CE03B8
	public void .ctor(object object, IntPtr method) { }

	// RVA: 0x2CDCDD0 Offset: 0x2CDCDD0 VA: 0x2CDCDD0 Slot: 12
	public virtual void Invoke(string error) { }

	// RVA: 0x2CE03CC Offset: 0x2CE03CC VA: 0x2CE03CC Slot: 13
	public virtual IAsyncResult BeginInvoke(string error, AsyncCallback callback, object object) { }

	// RVA: 0x2CE03F8 Offset: 0x2CE03F8 VA: 0x2CE03F8 Slot: 14
	public virtual void EndInvoke(IAsyncResult result) { }
}
