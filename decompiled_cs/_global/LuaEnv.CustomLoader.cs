// Namespace: 
public sealed class LuaEnv.CustomLoader : MulticastDelegate // TypeDefIndex: 6319
{
	// Methods

	// RVA: 0x174CA90 Offset: 0x174CA90 VA: 0x174CA90
	public void .ctor(object object, IntPtr method) { }

	// RVA: 0x174CAA4 Offset: 0x174CAA4 VA: 0x174CAA4 Slot: 12
	public virtual byte[] Invoke(ref string filepath) { }

	// RVA: 0x174CF48 Offset: 0x174CF48 VA: 0x174CF48 Slot: 13
	public virtual IAsyncResult BeginInvoke(ref string filepath, AsyncCallback callback, object object) { }

	// RVA: 0x174CF78 Offset: 0x174CF78 VA: 0x174CF78 Slot: 14
	public virtual byte[] EndInvoke(ref string filepath, IAsyncResult result) { }
}
