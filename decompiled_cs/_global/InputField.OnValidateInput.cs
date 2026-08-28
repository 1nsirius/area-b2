// Namespace: 
public sealed class InputField.OnValidateInput : MulticastDelegate // TypeDefIndex: 4065
{
	// Methods

	// RVA: 0x1B2D8C8 Offset: 0x1B2D8C8 VA: 0x1B2D8C8
	public void .ctor(object object, IntPtr method) { }

	// RVA: 0x1B2D8E4 Offset: 0x1B2D8E4 VA: 0x1B2D8E4 Slot: 12
	public virtual char Invoke(string text, int charIndex, char addedChar) { }

	// RVA: 0x1B39D08 Offset: 0x1B39D08 VA: 0x1B39D08 Slot: 13
	public virtual IAsyncResult BeginInvoke(string text, int charIndex, char addedChar, AsyncCallback callback, object object) { }

	// RVA: 0x1B39DCC Offset: 0x1B39DCC VA: 0x1B39DCC Slot: 14
	public virtual char EndInvoke(IAsyncResult result) { }
}
