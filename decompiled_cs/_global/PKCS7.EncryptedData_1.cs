// Namespace: 
public class PKCS7.EncryptedData // TypeDefIndex: 2165
{
	// Fields
	private byte _version; // 0x8
	private PKCS7.ContentInfo _content; // 0xC
	private PKCS7.ContentInfo _encryptionAlgorithm; // 0x10
	private byte[] _encrypted; // 0x14

	// Properties
	public PKCS7.ContentInfo EncryptionAlgorithm { get; }
	public byte[] EncryptedContent { get; }

	// Methods

	// RVA: 0x22C1E34 Offset: 0x22C1E34 VA: 0x22C1E34
	public void .ctor() { }

	// RVA: 0x22C1E54 Offset: 0x22C1E54 VA: 0x22C1E54
	public void .ctor(ASN1 asn1) { }

	// RVA: 0x22C22B8 Offset: 0x22C22B8 VA: 0x22C22B8
	public PKCS7.ContentInfo get_EncryptionAlgorithm() { }

	// RVA: 0x22C22C0 Offset: 0x22C22C0 VA: 0x22C22C0
	public byte[] get_EncryptedContent() { }
}
