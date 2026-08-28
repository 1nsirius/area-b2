// Namespace: 
public class PKCS12.DeriveBytes // TypeDefIndex: 73
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

	// RVA: 0x1CA79C8 Offset: 0x1CA79C8 VA: 0x1CA79C8
	public void .ctor() { }

	// RVA: 0x1CA7BF8 Offset: 0x1CA7BF8 VA: 0x1CA7BF8
	public void set_HashName(string value) { }

	// RVA: 0x1CA7BF0 Offset: 0x1CA7BF0 VA: 0x1CA7BF0
	public void set_IterationCount(int value) { }

	// RVA: 0x1CA79D0 Offset: 0x1CA79D0 VA: 0x1CA79D0
	public void set_Password(byte[] value) { }

	// RVA: 0x1CA7AF0 Offset: 0x1CA7AF0 VA: 0x1CA7AF0
	public void set_Salt(byte[] value) { }

	// RVA: 0x1CAD714 Offset: 0x1CAD714 VA: 0x1CAD714
	private void Adjust(byte[] a, int aOff, byte[] b) { }

	// RVA: 0x1CAD8A8 Offset: 0x1CAD8A8 VA: 0x1CAD8A8
	private byte[] Derive(byte[] diversifier, int n) { }

	// RVA: 0x1CA7C00 Offset: 0x1CA7C00 VA: 0x1CA7C00
	public byte[] DeriveKey(int size) { }

	// RVA: 0x1CA7CA0 Offset: 0x1CA7CA0 VA: 0x1CA7CA0
	public byte[] DeriveIV(int size) { }

	// RVA: 0x1CA9B88 Offset: 0x1CA9B88 VA: 0x1CA9B88
	public byte[] DeriveMAC(int size) { }

	// RVA: 0x1CADF84 Offset: 0x1CADF84 VA: 0x1CADF84
	private static void .cctor() { }
}
