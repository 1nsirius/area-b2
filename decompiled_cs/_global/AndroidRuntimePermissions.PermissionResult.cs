// Namespace: 
public sealed class AndroidRuntimePermissions.PermissionResult : MulticastDelegate // TypeDefIndex: 5220
{
	// Methods

	// RVA: 0xCC00C8 Offset: 0xCC00C8 VA: 0xCC00C8
	public void .ctor(object object, IntPtr method) { }

	// RVA: 0xCBF840 Offset: 0xCBF840 VA: 0xCBF840 Slot: 12
	public virtual void Invoke(string permission, AndroidRuntimePermissions.Permission result) { }

	// RVA: 0xCC00DC Offset: 0xCC00DC VA: 0xCC00DC Slot: 13
	public virtual IAsyncResult BeginInvoke(string permission, AndroidRuntimePermissions.Permission result, AsyncCallback callback, object object) { }

	// RVA: 0xCC017C Offset: 0xCC017C VA: 0xCC017C Slot: 14
	public virtual void EndInvoke(IAsyncResult result) { }
}
