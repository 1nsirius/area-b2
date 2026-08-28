// Namespace: 
public class PKCS12.DeriveBytes // TypeDefIndex: 2168
{
	// Fields
	private static byte[] keyDiversifier; // 0x0
	private static byte[] ivDiversifier; // 0x4
	private static byte[] macDiversifier; // 0x8
	private string _hashName; // 0x8
	private int _iterations; // 0xC
	private byte[] _password; // 0x10
	private byte[] _salt; // 0x14

	// Properties
	public string HashName { set; }
	public int IterationCount { set; }
	public byte[] Password { set; }
	public byte[] Salt { set; }

	// Methods

	// RVA: 0x22CB03C Offset: 0x22CB03C VA: 0x22CB03C
	public void .ctor() { }

	// RVA: 0x22CB26C Offset: 0x22CB26C VA: 0x22CB26C
	public void set_HashName(string value) { }

	// RVA: 0x22CB264 Offset: 0x22CB264 VA: 0x22CB264
	public void set_IterationCount(int value) { }

	// RVA: 0x22CB044 Offset: 0x22CB044 VA: 0x22CB044
	public void set_Password(byte[] value) { }

	// RVA: 0x22CB164 Offset: 0x22CB164 VA: 0x22CB164
	public void set_Salt(byte[] value) { }

	// RVA: 0x22D08F4 Offset: 0x22D08F4 VA: 0x22D08F4
	private void Adjust(byte[] a, int aOff, byte[] b) { }

	// RVA: 0x22D0A88 Offset: 0x22D0A88 VA: 0x22D0A88
	private byte[] Derive(byte[] diversifier, int n) { }

	// RVA: 0x22CB274 Offset: 0x22CB274 VA: 0x22CB274
	public byte[] DeriveKey(int size) { }

	// RVA: 0x22CB314 Offset: 0x22CB314 VA: 0x22CB314
	public byte[] DeriveIV(int size) { }

	// RVA: 0x22CCB7C Offset: 0x22CCB7C VA: 0x22CCB7C
	public byte[] DeriveMAC(int size) { }

	// RVA: 0x22D1164 Offset: 0x22D1164 VA: 0x22D1164
	private static void .cctor() { }
}
