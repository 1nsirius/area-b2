// Namespace: 
public sealed class NativeGallery.MediaPickCallback : MulticastDelegate // TypeDefIndex: 5254
{
	// Methods

	// RVA: 0x2CDFAF8 Offset: 0x2CDFAF8 VA: 0x2CDFAF8
	public void .ctor(object object, IntPtr method) { }

	// RVA: 0x2CDFB0C Offset: 0x2CDFB0C VA: 0x2CDFB0C Slot: 12
	public virtual void Invoke(string path) { }

	// RVA: 0x2CE0334 Offset: 0x2CE0334 VA: 0x2CE0334 Slot: 13
	public virtual IAsyncResult BeginInvoke(string path, AsyncCallback callback, object object) { }

	// RVA: 0x2CE0360 Offset: 0x2CE0360 VA: 0x2CE0360 Slot: 14
	public virtual void EndInvoke(IAsyncResult result) { }
}
