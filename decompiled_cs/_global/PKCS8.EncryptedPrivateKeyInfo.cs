// Namespace: 
public class PKCS8.EncryptedPrivateKeyInfo // TypeDefIndex: 91
{
	// Fields
	private string _algorithm; // 0x8
	private byte[] _salt; // 0xC
	private int _iterations; // 0x10
	private byte[] _data; // 0x14

	// Properties
	public string Algorithm { get; }
	public byte[] EncryptedData { get; }
	public byte[] Salt { get; }
	public int IterationCount { get; }

	// Methods

	// RVA: 0x1C98B84 Offset: 0x1C98B84 VA: 0x1C98B84
	public void .ctor() { }

	// RVA: 0x1C98B8C Offset: 0x1C98B8C VA: 0x1C98B8C
	public void .ctor(byte[] data) { }

	// RVA: 0x1C99094 Offset: 0x1C99094 VA: 0x1C99094
	public string get_Algorithm() { }

	// RVA: 0x1C9909C Offset: 0x1C9909C VA: 0x1C9909C
	public byte[] get_EncryptedData() { }

	// RVA: 0x1C99198 Offset: 0x1C99198 VA: 0x1C99198
	public byte[] get_Salt() { }

	// RVA: 0x1C99300 Offset: 0x1C99300 VA: 0x1C99300
	public int get_IterationCount() { }

	// RVA: 0x1C98BB4 Offset: 0x1C98BB4 VA: 0x1C98BB4
	private void Decode(byte[] data) { }
}
