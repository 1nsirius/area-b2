// Namespace: 
public sealed class ReflectionMethodsCache.GetRayIntersectionAllCallback : MulticastDelegate // TypeDefIndex: 4143
{
	// Methods

	// RVA: 0x1DBB0E4 Offset: 0x1DBB0E4 VA: 0x1DBB0E4
	public void .ctor(object object, IntPtr method) { }

	// RVA: 0x1DBB0F8 Offset: 0x1DBB0F8 VA: 0x1DBB0F8 Slot: 12
	public virtual RaycastHit2D[] Invoke(Ray r, float f, int i) { }

	// RVA: 0x1DBB790 Offset: 0x1DBB790 VA: 0x1DBB790 Slot: 13
	public virtual IAsyncResult BeginInvoke(Ray r, float f, int i, AsyncCallback callback, object object) { }

	// RVA: 0x1DBB888 Offset: 0x1DBB888 VA: 0x1DBB888 Slot: 14
	public virtual RaycastHit2D[] EndInvoke(IAsyncResult result) { }
}
