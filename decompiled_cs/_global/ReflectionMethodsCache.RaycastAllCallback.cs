// Namespace: 
public sealed class ReflectionMethodsCache.RaycastAllCallback : MulticastDelegate // TypeDefIndex: 4142
{
	// Methods

	// RVA: 0x1DBD678 Offset: 0x1DBD678 VA: 0x1DBD678
	public void .ctor(object object, IntPtr method) { }

	// RVA: 0x1DBD68C Offset: 0x1DBD68C VA: 0x1DBD68C Slot: 12
	public virtual RaycastHit[] Invoke(Ray r, float f, int i) { }

	// RVA: 0x1DBDD24 Offset: 0x1DBDD24 VA: 0x1DBDD24 Slot: 13
	public virtual IAsyncResult BeginInvoke(Ray r, float f, int i, AsyncCallback callback, object object) { }

	// RVA: 0x1DBDE1C Offset: 0x1DBDE1C VA: 0x1DBDE1C Slot: 14
	public virtual RaycastHit[] EndInvoke(IAsyncResult result) { }
}
