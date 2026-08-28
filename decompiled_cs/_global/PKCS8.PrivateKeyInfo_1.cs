// Namespace: 
public class PKCS8.PrivateKeyInfo // TypeDefIndex: 2208
{
	// Fields
	private int _version; // 0x8
	private string _algorithm; // 0xC
	private byte[] _key; // 0x10
	private ArrayList _list; // 0x14

	// Properties
	public byte[] PrivateKey { get; }

	// Methods

	// RVA: 0x22BC174 Offset: 0x22BC174 VA: 0x22BC174
	public void .ctor() { }

	// RVA: 0x22BC1F8 Offset: 0x22BC1F8 VA: 0x22BC1F8
	public void .ctor(byte[] data) { }

	// RVA: 0x22BC594 Offset: 0x22BC594 VA: 0x22BC594
	public byte[] get_PrivateKey() { }

	// RVA: 0x22BC21C Offset: 0x22BC21C VA: 0x22BC21C
	private void Decode(byte[] data) { }

	// RVA: 0x22BC690 Offset: 0x22BC690 VA: 0x22BC690
	private static byte[] RemoveLeadingZero(byte[] bigInt) { }

	// RVA: 0x22BC77C Offset: 0x22BC77C VA: 0x22BC77C
	private static byte[] Normalize(byte[] bigInt, int length) { }

	// RVA: 0x22BC84C Offset: 0x22BC84C VA: 0x22BC84C
	public static RSA DecodeRSA(byte[] keypair) { }

	// RVA: 0x22BCD64 Offset: 0x22BCD64 VA: 0x22BCD64
	public static byte[] Encode(RSA rsa) { }

	// RVA: 0x22BD00C Offset: 0x22BD00C VA: 0x22BD00C
	public static DSA DecodeDSA(byte[] privateKey, DSAParameters dsaParameters) { }

	// RVA: 0x22BD178 Offset: 0x22BD178 VA: 0x22BD178
	public static byte[] Encode(DSA dsa) { }

	// RVA: 0x22BD1EC Offset: 0x22BD1EC VA: 0x22BD1EC
	public static byte[] Encode(AsymmetricAlgorithm aa) { }
}
