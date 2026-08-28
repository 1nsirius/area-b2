// Namespace: 
private sealed class Console.WindowsConsole.WindowsCancelHandler : MulticastDelegate // TypeDefIndex: 342
{
	// Methods

	// RVA: 0x1B8BBB8 Offset: 0x1B8BBB8 VA: 0x1B8BBB8
	public void .ctor(object object, IntPtr method) { }

	// RVA: 0x1B8BBCC Offset: 0x1B8BBCC VA: 0x1B8BBCC Slot: 12
	public virtual bool Invoke(int keyCode) { }

	// RVA: 0x1B8C070 Offset: 0x1B8C070 VA: 0x1B8C070 Slot: 13
	public virtual IAsyncResult BeginInvoke(int keyCode, AsyncCallback callback, object object) { }

	// RVA: 0x1B8C10C Offset: 0x1B8C10C VA: 0x1B8C10C Slot: 14
	public virtual bool EndInvoke(IAsyncResult result) { }
}
