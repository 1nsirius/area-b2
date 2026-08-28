// Namespace: 
public sealed class ReflectionMethodsCache.GetRaycastNonAllocCallback : MulticastDelegate // TypeDefIndex: 4145
{
	// Methods

	// RVA: 0x1DBC038 Offset: 0x1DBC038 VA: 0x1DBC038
	public void .ctor(object object, IntPtr method) { }

	// RVA: 0x1DBC04C Offset: 0x1DBC04C VA: 0x1DBC04C Slot: 12
	public virtual int Invoke(Ray r, RaycastHit[] results, float f, int i) { }

	// RVA: 0x1DBC6A8 Offset: 0x1DBC6A8 VA: 0x1DBC6A8 Slot: 13
	public virtual IAsyncResult BeginInvoke(Ray r, RaycastHit[] results, float f, int i, AsyncCallback callback, object object) { }

	// RVA: 0x1DBC7A4 Offset: 0x1DBC7A4 VA: 0x1DBC7A4 Slot: 14
	public virtual int EndInvoke(IAsyncResult result) { }
}
