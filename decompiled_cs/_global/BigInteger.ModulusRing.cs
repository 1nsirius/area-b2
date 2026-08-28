// Namespace: 
internal sealed class BigInteger.ModulusRing // TypeDefIndex: 100
{
	// Fields
	private BigInteger mod; // 0x8
	private BigInteger constant; // 0xC

	// Methods

	// RVA: 0x1B712B8 Offset: 0x1B712B8 VA: 0x1B712B8
	public void .ctor(BigInteger modulus) { }

	// RVA: 0x1B72768 Offset: 0x1B72768 VA: 0x1B72768
	public void BarrettReduction(BigInteger x) { }

	// RVA: 0x1B72B40 Offset: 0x1B72B40 VA: 0x1B72B40
	public BigInteger Multiply(BigInteger a, BigInteger b) { }

	// RVA: 0x1B724EC Offset: 0x1B724EC VA: 0x1B724EC
	public BigInteger Difference(BigInteger a, BigInteger b) { }

	// RVA: 0x1B713EC Offset: 0x1B713EC VA: 0x1B713EC
	public BigInteger Pow(BigInteger a, BigInteger k) { }

	// RVA: 0x1B72DA0 Offset: 0x1B72DA0 VA: 0x1B72DA0
	public BigInteger Pow(uint b, BigInteger exp) { }
}
