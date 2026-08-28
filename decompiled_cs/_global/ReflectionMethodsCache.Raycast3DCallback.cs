// Namespace: 
public sealed class ReflectionMethodsCache.Raycast3DCallback : MulticastDelegate // TypeDefIndex: 4140
{
	// Methods

	// RVA: 0x1DBCEA8 Offset: 0x1DBCEA8 VA: 0x1DBCEA8
	public void .ctor(object object, IntPtr method) { }

	// RVA: 0x1DBCEBC Offset: 0x1DBCEBC VA: 0x1DBCEBC Slot: 12
	public virtual bool Invoke(Ray r, out RaycastHit hit, float f, int i) { }

	// RVA: 0x1DBD518 Offset: 0x1DBD518 VA: 0x1DBD518 Slot: 13
	public virtual IAsyncResult BeginInvoke(Ray r, out RaycastHit hit, float f, int i, AsyncCallback callback, object object) { }

	// RVA: 0x1DBD634 Offset: 0x1DBD634 VA: 0x1DBD634 Slot: 14
	public virtual bool EndInvoke(out RaycastHit hit, IAsyncResult result) { }
}
