// Namespace: 
[CSharpCallLuaAttribute] // RVA: 0x55B340 Offset: 0x55B340 VA: 0x55B340
public sealed class ActivityDataManager.ActivityAction : MulticastDelegate // TypeDefIndex: 9855
{
	// Methods

	// RVA: 0xBE4B1C Offset: 0xBE4B1C VA: 0xBE4B1C
	public void .ctor(object object, IntPtr method) { }

	// RVA: 0xBE4B30 Offset: 0xBE4B30 VA: 0xBE4B30 Slot: 12
	public virtual void Invoke() { }

	// RVA: 0xBE4F6C Offset: 0xBE4F6C VA: 0xBE4F6C Slot: 13
	public virtual IAsyncResult BeginInvoke(AsyncCallback callback, object object) { }

	// RVA: 0xBE4F98 Offset: 0xBE4F98 VA: 0xBE4F98 Slot: 14
	public virtual void EndInvoke(IAsyncResult result) { }
}
