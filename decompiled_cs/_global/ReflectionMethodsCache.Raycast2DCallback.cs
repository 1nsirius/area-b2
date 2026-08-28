// Namespace: 
public sealed class ReflectionMethodsCache.Raycast2DCallback : MulticastDelegate // TypeDefIndex: 4141
{
	// Methods

	// RVA: 0x1DBC7DC Offset: 0x1DBC7DC VA: 0x1DBC7DC
	public void .ctor(object object, IntPtr method) { }

	// RVA: 0x1DBC7F0 Offset: 0x1DBC7F0 VA: 0x1DBC7F0 Slot: 12
	public virtual RaycastHit2D Invoke(Vector2 p1, Vector2 p2, float f, int i) { }

	// RVA: 0x1DBCD64 Offset: 0x1DBCD64 VA: 0x1DBCD64 Slot: 13
	public virtual IAsyncResult BeginInvoke(Vector2 p1, Vector2 p2, float f, int i, AsyncCallback callback, object object) { }

	// RVA: 0x1DBCE60 Offset: 0x1DBCE60 VA: 0x1DBCE60 Slot: 14
	public virtual RaycastHit2D EndInvoke(IAsyncResult result) { }
}
