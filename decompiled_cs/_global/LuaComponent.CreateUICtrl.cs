// Namespace: 
[CSharpCallLuaAttribute] // RVA: 0x558FB0 Offset: 0x558FB0 VA: 0x558FB0
public sealed class LuaComponent.CreateUICtrl : MulticastDelegate // TypeDefIndex: 6118
{
	// Methods

	// RVA: 0x1341848 Offset: 0x1341848 VA: 0x1341848
	public void .ctor(object object, IntPtr method) { }

	// RVA: 0x134185C Offset: 0x134185C VA: 0x134185C Slot: 12
	public virtual LuaTable Invoke(LuaComponent luaBehaviour) { }

	// RVA: 0x13420AC Offset: 0x13420AC VA: 0x13420AC Slot: 13
	public virtual IAsyncResult BeginInvoke(LuaComponent luaBehaviour, AsyncCallback callback, object object) { }

	// RVA: 0x13420D8 Offset: 0x13420D8 VA: 0x13420D8 Slot: 14
	public virtual LuaTable EndInvoke(IAsyncResult result) { }
}
