// Namespace: 
public class AkUtilities.ShortIDGenerator // TypeDefIndex: 6003
{
	// Fields
	private const uint s_prime32 = 16777619;
	private const uint s_offsetBasis32 = 2166136261;
	private static byte s_hashSize; // 0x0
	private static uint s_mask; // 0x4

	// Properties
	public static byte HashSize { get; set; }

	// Methods

	// RVA: 0xCAACB0 Offset: 0xCAACB0 VA: 0xCAACB0
	private static void .cctor() { }

	// RVA: 0xCAAD74 Offset: 0xCAAD74 VA: 0xCAAD74
	public static byte get_HashSize() { }

	// RVA: 0xCAACB8 Offset: 0xCAACB8 VA: 0xCAACB8
	public static void set_HashSize(byte value) { }

	// RVA: 0xCA890C Offset: 0xCA890C VA: 0xCA890C
	public static uint Compute(string in_name) { }

	// RVA: 0xCAAE00 Offset: 0xCAAE00 VA: 0xCAAE00
	public void .ctor() { }
}
