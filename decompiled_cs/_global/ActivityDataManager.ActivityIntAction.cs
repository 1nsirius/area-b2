// Namespace: 
[CSharpCallLuaAttribute] // RVA: 0x55B370 Offset: 0x55B370 VA: 0x55B370
public sealed class ActivityDataManager.ActivityIntAction : MulticastDelegate // TypeDefIndex: 9858
{
	// Methods

	// RVA: 0xBE564C Offset: 0xBE564C VA: 0xBE564C
	public void .ctor(object object, IntPtr method) { }

	// RVA: 0xBE5660 Offset: 0xBE5660 VA: 0xBE5660 Slot: 12
	public virtual void Invoke(int type) { }

	// RVA: 0xBE5AC4 Offset: 0xBE5AC4 VA: 0xBE5AC4 Slot: 13
	public virtual IAsyncResult BeginInvoke(int type, AsyncCallback callback, object object) { }

	// RVA: 0xBE5B60 Offset: 0xBE5B60 VA: 0xBE5B60 Slot: 14
	public virtual void EndInvoke(IAsyncResult result) { }
}
