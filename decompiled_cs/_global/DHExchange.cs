// Namespace: 
internal class DHExchange // TypeDefIndex: 5262
{
	// Fields
	public static readonly int DH_KEY_LENGTH; // 0x0
	private static readonly DHExchange.UInt128 P; // 0x8
	private static readonly DHExchange.UInt128 INVERT_P; // 0x18
	private static readonly DHExchange.UInt128 G; // 0x28

	// Methods

	// RVA: 0xD0FA38 Offset: 0xD0FA38 VA: 0xD0FA38
	public static void generate_key_pair(byte[] public_key, byte[] private_key) { }

	// RVA: 0xD1008C Offset: 0xD1008C VA: 0xD1008C
	public static byte[] generate_key_secret(byte[] my_private, byte[] another_public) { }

	// RVA: 0xD10260 Offset: 0xD10260 VA: 0xD10260
	public static byte[] generate_publicNums(byte[] my_private) { }

	// RVA: 0xD103F0 Offset: 0xD103F0 VA: 0xD103F0
	public void .ctor() { }

	// RVA: 0xD103F8 Offset: 0xD103F8 VA: 0xD103F8
	private static void .cctor() { }
}
