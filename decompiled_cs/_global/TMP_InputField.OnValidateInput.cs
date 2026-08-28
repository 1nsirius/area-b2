// Namespace: 
public sealed class TMP_InputField.OnValidateInput : MulticastDelegate // TypeDefIndex: 4721
{
	// Methods

	// RVA: 0xE9C4E0 Offset: 0xE9C4E0 VA: 0xE9C4E0
	public void .ctor(object object, IntPtr method) { }

	// RVA: 0xE9C4F4 Offset: 0xE9C4F4 VA: 0xE9C4F4 Slot: 12
	public virtual char Invoke(string text, int charIndex, char addedChar) { }

	// RVA: 0xE9CDE8 Offset: 0xE9CDE8 VA: 0xE9CDE8 Slot: 13
	public virtual IAsyncResult BeginInvoke(string text, int charIndex, char addedChar, AsyncCallback callback, object object) { }

	// RVA: 0xE9CEAC Offset: 0xE9CEAC VA: 0xE9CEAC Slot: 14
	public virtual char EndInvoke(IAsyncResult result) { }
}
