// Namespace: 
public class PKCS8.PrivateKeyInfo // TypeDefIndex: 90
{
	// Fields
	private int _version; // 0x8
	private string _algorithm; // 0xC
	private byte[] _key; // 0x10
	private ArrayList _list; // 0x14

	// Properties
	public byte[] PrivateKey { get; }

	// Methods

	// RVA: 0x1C99308 Offset: 0x1C99308 VA: 0x1C99308
	public void .ctor() { }

	// RVA: 0x1C9938C Offset: 0x1C9938C VA: 0x1C9938C
	public void .ctor(byte[] data) { }

	// RVA: 0x1C997BC Offset: 0x1C997BC VA: 0x1C997BC
	public byte[] get_PrivateKey() { }

	// RVA: 0x1C993B0 Offset: 0x1C993B0 VA: 0x1C993B0
	private void Decode(byte[] data) { }

	// RVA: 0x1C998B8 Offset: 0x1C998B8 VA: 0x1C998B8
	private static byte[] RemoveLeadingZero(byte[] bigInt) { }

	// RVA: 0x1C999A4 Offset: 0x1C999A4 VA: 0x1C999A4
	private static byte[] Normalize(byte[] bigInt, int length) { }

	// RVA: 0x1C99A74 Offset: 0x1C99A74 VA: 0x1C99A74
	public static RSA DecodeRSA(byte[] keypair) { }

	// RVA: 0x1C9A074 Offset: 0x1C9A074 VA: 0x1C9A074
	public static DSA DecodeDSA(byte[] privateKey, DSAParameters dsaParameters) { }
}
