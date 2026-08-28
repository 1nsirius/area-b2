// Namespace: 
public sealed class ReflectionMethodsCache.GetRayIntersectionAllNonAllocCallback : MulticastDelegate // TypeDefIndex: 4144
{
	// Methods

	// RVA: 0x1DBB894 Offset: 0x1DBB894 VA: 0x1DBB894
	public void .ctor(object object, IntPtr method) { }

	// RVA: 0x1DBB8A8 Offset: 0x1DBB8A8 VA: 0x1DBB8A8 Slot: 12
	public virtual int Invoke(Ray r, RaycastHit2D[] results, float f, int i) { }

	// RVA: 0x1DBBF04 Offset: 0x1DBBF04 VA: 0x1DBBF04 Slot: 13
	public virtual IAsyncResult BeginInvoke(Ray r, RaycastHit2D[] results, float f, int i, AsyncCallback callback, object object) { }

	// RVA: 0x1DBC000 Offset: 0x1DBC000 VA: 0x1DBC000 Slot: 14
	public virtual int EndInvoke(IAsyncResult result) { }
}
