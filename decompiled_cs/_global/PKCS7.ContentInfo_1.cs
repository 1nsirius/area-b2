// Namespace: 
public class PKCS7.ContentInfo // TypeDefIndex: 2164
{
	// Fields
	private string contentType; // 0x8
	private ASN1 content; // 0xC

	// Properties
	public ASN1 ASN1 { get; }
	public ASN1 Content { get; set; }
	public string ContentType { get; set; }

	// Methods

	// RVA: 0x22C19B8 Offset: 0x22C19B8 VA: 0x22C19B8
	public void .ctor() { }

	// RVA: 0x22C1A44 Offset: 0x22C1A44 VA: 0x22C1A44
	public void .ctor(string oid) { }

	// RVA: 0x22C1A60 Offset: 0x22C1A60 VA: 0x22C1A60
	public void .ctor(byte[] data) { }

	// RVA: 0x22C1ADC Offset: 0x22C1ADC VA: 0x22C1ADC
	public void .ctor(ASN1 asn1) { }

	// RVA: 0x22C1D1C Offset: 0x22C1D1C VA: 0x22C1D1C
	public ASN1 get_ASN1() { }

	// RVA: 0x22C1E14 Offset: 0x22C1E14 VA: 0x22C1E14
	public ASN1 get_Content() { }

	// RVA: 0x22C1E1C Offset: 0x22C1E1C VA: 0x22C1E1C
	public void set_Content(ASN1 value) { }

	// RVA: 0x22C1E24 Offset: 0x22C1E24 VA: 0x22C1E24
	public string get_ContentType() { }

	// RVA: 0x22C1E2C Offset: 0x22C1E2C VA: 0x22C1E2C
	public void set_ContentType(string value) { }

	// RVA: 0x22C1D20 Offset: 0x22C1D20 VA: 0x22C1D20
	internal ASN1 GetASN1() { }
}
