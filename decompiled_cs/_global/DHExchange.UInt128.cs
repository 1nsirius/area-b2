// Namespace: 
private struct DHExchange.UInt128 // TypeDefIndex: 5263
{
	// Fields
	private ulong _low; // 0x0
	private ulong _high; // 0x8

	// Methods

	// RVA: 0x74790C Offset: 0x74790C VA: 0x74790C
	public void .ctor(ulong l, ulong h) { }

	// RVA: 0x747924 Offset: 0x747924 VA: 0x747924
	public void .ctor(DHExchange.UInt128 other) { }

	// RVA: 0x74793C Offset: 0x74793C VA: 0x74793C
	public void .ctor(byte[] bytes) { }

	// RVA: 0x747944 Offset: 0x747944 VA: 0x747944
	public void to_bytes(byte[] bytes) { }

	// RVA: 0x74794C Offset: 0x74794C VA: 0x74794C
	public bool is_zero() { }

	// RVA: 0x747978 Offset: 0x747978 VA: 0x747978
	public bool is_odd() { }

	// RVA: 0x747984 Offset: 0x747984 VA: 0x747984
	public void lshift() { }

	// RVA: 0x7479C8 Offset: 0x7479C8 VA: 0x7479C8
	public void rshift() { }

	// RVA: 0xD10598 Offset: 0xD10598 VA: 0xD10598
	public static int compare(DHExchange.UInt128 a, DHExchange.UInt128 b) { }

	// RVA: 0xD10600 Offset: 0xD10600 VA: 0xD10600
	public static DHExchange.UInt128 add(DHExchange.UInt128 a, DHExchange.UInt128 b) { }

	// RVA: 0xD1065C Offset: 0xD1065C VA: 0xD1065C
	public static DHExchange.UInt128 add_i(DHExchange.UInt128 a, ulong b) { }

	// RVA: 0xD106B8 Offset: 0xD106B8 VA: 0xD106B8
	public static DHExchange.UInt128 sub(DHExchange.UInt128 a, DHExchange.UInt128 b) { }

	// RVA: 0xD1076C Offset: 0xD1076C VA: 0xD1076C
	public static DHExchange.UInt128 _mulmodp(DHExchange.UInt128 _a, DHExchange.UInt128 _b) { }

	// RVA: 0xD10CE4 Offset: 0xD10CE4 VA: 0xD10CE4
	public static DHExchange.UInt128 _powmodp_r(DHExchange.UInt128 a, DHExchange.UInt128 b) { }

	// RVA: 0xD0FDB0 Offset: 0xD0FDB0 VA: 0xD0FDB0
	public static DHExchange.UInt128 _powmodp(DHExchange.UInt128 _a, DHExchange.UInt128 b) { }
}
