// Namespace: 
[CSharpCallLuaAttribute] // RVA: 0x55B350 Offset: 0x55B350 VA: 0x55B350
public sealed class ActivityDataManager.ActivityIntBoolAction : MulticastDelegate // TypeDefIndex: 9856
{
	// Methods

	// RVA: 0xBE5B6C Offset: 0xBE5B6C VA: 0xBE5B6C
	public void .ctor(object object, IntPtr method) { }

	// RVA: 0xBE5B80 Offset: 0xBE5B80 VA: 0xBE5B80 Slot: 12
	public virtual void Invoke(int id, bool isSuccess) { }

	// RVA: 0xBE6004 Offset: 0xBE6004 VA: 0xBE6004 Slot: 13
	public virtual IAsyncResult BeginInvoke(int id, bool isSuccess, AsyncCallback callback, object object) { }

	// RVA: 0xBE60C0 Offset: 0xBE60C0 VA: 0xBE60C0 Slot: 14
	public virtual void EndInvoke(IAsyncResult result) { }
}
