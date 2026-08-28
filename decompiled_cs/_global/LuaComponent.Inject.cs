// Namespace: 
[CSharpCallLuaAttribute] // RVA: 0x558FC0 Offset: 0x558FC0 VA: 0x558FC0
public sealed class LuaComponent.Inject : MulticastDelegate // TypeDefIndex: 6119
{
	// Methods

	// RVA: 0x13420E4 Offset: 0x13420E4 VA: 0x13420E4
	public void .ctor(object object, IntPtr method) { }

	// RVA: 0x13420F8 Offset: 0x13420F8 VA: 0x13420F8 Slot: 12
	public virtual void Invoke(string name, object comp) { }

	// RVA: 0x1342980 Offset: 0x1342980 VA: 0x1342980 Slot: 13
	public virtual IAsyncResult BeginInvoke(string name, object comp, AsyncCallback callback, object object) { }

	// RVA: 0x13429B8 Offset: 0x13429B8 VA: 0x13429B8 Slot: 14
	public virtual void EndInvoke(IAsyncResult result) { }
}
