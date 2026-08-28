// Namespace: 
public sealed class Camera.CameraCallback : MulticastDelegate // TypeDefIndex: 3089
{
	// Methods

	// RVA: 0x2231214 Offset: 0x2231214 VA: 0x2231214
	public void .ctor(object object, IntPtr method) { }

	// RVA: 0x2230904 Offset: 0x2230904 VA: 0x2230904 Slot: 12
	public virtual void Invoke(Camera cam) { }

	// RVA: 0x2231228 Offset: 0x2231228 VA: 0x2231228 Slot: 13
	public virtual IAsyncResult BeginInvoke(Camera cam, AsyncCallback callback, object object) { }

	// RVA: 0x2231254 Offset: 0x2231254 VA: 0x2231254 Slot: 14
	public virtual void EndInvoke(IAsyncResult result) { }
}
