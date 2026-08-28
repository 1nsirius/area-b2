// Namespace: 
[FriendAccessAllowedAttribute] // RVA: 0x4D7F84 Offset: 0x4D7F84 VA: 0x4D7F84
internal struct Number.NumberBuffer // TypeDefIndex: 269
{
	// Fields
	public static readonly int NumberBufferBytes; // 0x0
	private byte* baseAddress; // 0x0
	public char* digits; // 0x4
	public int precision; // 0x8
	public int scale; // 0xC
	public bool sign; // 0x10

	// Methods

	// RVA: 0x7A2D78 Offset: 0x7A2D78 VA: 0x7A2D78
	public void .ctor(byte* stackBuffer) { }

	// RVA: 0x7A2D94 Offset: 0x7A2D94 VA: 0x7A2D94
	public byte* PackForNative() { }

	// RVA: 0x2045A20 Offset: 0x2045A20 VA: 0x2045A20
	private static void .cctor() { }
}
