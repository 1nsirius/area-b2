// Namespace: 
public class PKCS7.ContentInfo // TypeDefIndex: 66
{
	// Fields
	private string contentType; // 0x8
	private ASN1 content; // 0xC

	// Properties
	public ASN1 ASN1 { get; }
	public ASN1 Content { get; set; }
	public string ContentType { get; set; }

	// Methods

	// RVA: 0x1C9F0C8 Offset: 0x1C9F0C8 VA: 0x1C9F0C8
	public void .ctor() { }

	// RVA: 0x1C9F148 Offset: 0x1C9F148 VA: 0x1C9F148
	public void .ctor(string oid) { }

	// RVA: 0x1C9F164 Offset: 0x1C9F164 VA: 0x1C9F164
	public void .ctor(byte[] data) { }

	// RVA: 0x1C9F1E4 Offset: 0x1C9F1E4 VA: 0x1C9F1E4
	public void .ctor(ASN1 asn1) { }

	// RVA: 0x1C9F4A8 Offset: 0x1C9F4A8 VA: 0x1C9F4A8
	public ASN1 get_ASN1() { }

	// RVA: 0x1C9F590 Offset: 0x1C9F590 VA: 0x1C9F590
	public ASN1 get_Content() { }

	// RVA: 0x1C9F598 Offset: 0x1C9F598 VA: 0x1C9F598
	public void set_Content(ASN1 value) { }

	// RVA: 0x1C9F5A0 Offset: 0x1C9F5A0 VA: 0x1C9F5A0
	public string get_ContentType() { }

	// RVA: 0x1C9F5A8 Offset: 0x1C9F5A8 VA: 0x1C9F5A8
	public void set_ContentType(string value) { }

	// RVA: 0x1C9F4AC Offset: 0x1C9F4AC VA: 0x1C9F4AC
	internal ASN1 GetASN1() { }
}
