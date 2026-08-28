// Namespace: 
public class PKCS8.EncryptedPrivateKeyInfo // TypeDefIndex: 2209
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

	// RVA: 0x22BBA90 Offset: 0x22BBA90 VA: 0x22BBA90
	public void .ctor() { }

	// RVA: 0x22BBA98 Offset: 0x22BBA98 VA: 0x22BBA98
	public void .ctor(byte[] data) { }

	// RVA: 0x22BBF00 Offset: 0x22BBF00 VA: 0x22BBF00
	public string get_Algorithm() { }

	// RVA: 0x22BBF08 Offset: 0x22BBF08 VA: 0x22BBF08
	public byte[] get_EncryptedData() { }

	// RVA: 0x22BC004 Offset: 0x22BC004 VA: 0x22BC004
	public byte[] get_Salt() { }

	// RVA: 0x22BC16C Offset: 0x22BC16C VA: 0x22BC16C
	public int get_IterationCount() { }

	// RVA: 0x22BBAC0 Offset: 0x22BBAC0 VA: 0x22BBAC0
	private void Decode(byte[] data) { }
}
