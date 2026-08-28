// Namespace: 
public sealed class BigInteger.ModulusRing // TypeDefIndex: 2214
{
	// Fields
	private BigInteger mod; // 0x8
	private BigInteger constant; // 0xC

	// Methods

	// RVA: 0x22B2E30 Offset: 0x22B2E30 VA: 0x22B2E30
	public void .ctor(BigInteger modulus) { }

	// RVA: 0x22B3FA0 Offset: 0x22B3FA0 VA: 0x22B3FA0
	public void BarrettReduction(BigInteger x) { }

	// RVA: 0x22B4378 Offset: 0x22B4378 VA: 0x22B4378
	public BigInteger Multiply(BigInteger a, BigInteger b) { }

	// RVA: 0x22B3D24 Offset: 0x22B3D24 VA: 0x22B3D24
	public BigInteger Difference(BigInteger a, BigInteger b) { }

	// RVA: 0x22B2F64 Offset: 0x22B2F64 VA: 0x22B2F64
	public BigInteger Pow(BigInteger a, BigInteger k) { }

	[CLSCompliantAttribute] // RVA: 0x4E8688 Offset: 0x4E8688 VA: 0x4E8688
	// RVA: 0x22B45D8 Offset: 0x22B45D8 VA: 0x22B45D8
	public BigInteger Pow(uint b, BigInteger exp) { }
}
