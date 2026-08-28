// Namespace: 
public class PKCS7.EncryptedData // TypeDefIndex: 67
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

	// RVA: 0x1C9F5B0 Offset: 0x1C9F5B0 VA: 0x1C9F5B0
	public void .ctor() { }

	// RVA: 0x1C9F5D0 Offset: 0x1C9F5D0 VA: 0x1C9F5D0
	public void .ctor(ASN1 asn1) { }

	// RVA: 0x1C9FAFC Offset: 0x1C9FAFC VA: 0x1C9FAFC
	public PKCS7.ContentInfo get_EncryptionAlgorithm() { }

	// RVA: 0x1C9FB04 Offset: 0x1C9FB04 VA: 0x1C9FB04
	public byte[] get_EncryptedContent() { }
}
