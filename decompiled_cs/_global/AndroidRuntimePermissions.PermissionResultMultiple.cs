// Namespace: 
public sealed class AndroidRuntimePermissions.PermissionResultMultiple : MulticastDelegate // TypeDefIndex: 5221
{
	// Methods

	// RVA: 0xCBF2BC Offset: 0xCBF2BC VA: 0xCBF2BC
	public void .ctor(object object, IntPtr method) { }

	// RVA: 0xCC0188 Offset: 0xCC0188 VA: 0xCC0188 Slot: 12
	public virtual void Invoke(string[] permissions, AndroidRuntimePermissions.Permission[] result) { }

	// RVA: 0xCC0A10 Offset: 0xCC0A10 VA: 0xCC0A10 Slot: 13
	public virtual IAsyncResult BeginInvoke(string[] permissions, AndroidRuntimePermissions.Permission[] result, AsyncCallback callback, object object) { }

	// RVA: 0xCC0A48 Offset: 0xCC0A48 VA: 0xCC0A48 Slot: 14
	public virtual void EndInvoke(IAsyncResult result) { }
}
