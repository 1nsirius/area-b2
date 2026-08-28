// Namespace: 
private sealed class BigInteger.Kernel // TypeDefIndex: 101
{
	// Methods

	// RVA: 0x1B6D8F4 Offset: 0x1B6D8F4 VA: 0x1B6D8F4
	public static BigInteger Subtract(BigInteger big, BigInteger small) { }

	// RVA: 0x1B71B14 Offset: 0x1B71B14 VA: 0x1B71B14
	public static void MinusEq(BigInteger big, BigInteger small) { }

	// RVA: 0x1B71D24 Offset: 0x1B71D24 VA: 0x1B71D24
	public static void PlusEq(BigInteger bi1, BigInteger bi2) { }

	// RVA: 0x1B6D60C Offset: 0x1B6D60C VA: 0x1B6D60C
	public static BigInteger.Sign Compare(BigInteger bi1, BigInteger bi2) { }

	// RVA: 0x1B705E8 Offset: 0x1B705E8 VA: 0x1B705E8
	public static uint SingleByteDivideInPlace(BigInteger n, uint d) { }

	// RVA: 0x1B6DC08 Offset: 0x1B6DC08 VA: 0x1B6DC08
	public static uint DwordMod(BigInteger n, uint d) { }

	// RVA: 0x1B7202C Offset: 0x1B7202C VA: 0x1B7202C
	public static BigInteger[] DwordDivMod(BigInteger n, uint d) { }

	// RVA: 0x1B6DCE8 Offset: 0x1B6DCE8 VA: 0x1B6DCE8
	public static BigInteger[] multiByteDivide(BigInteger bi1, BigInteger bi2) { }

	// RVA: 0x1B6EE10 Offset: 0x1B6EE10 VA: 0x1B6EE10
	public static BigInteger LeftShift(BigInteger bi, int n) { }

	// RVA: 0x1B6F19C Offset: 0x1B6F19C VA: 0x1B6F19C
	public static BigInteger RightShift(BigInteger bi, int n) { }

	// RVA: 0x1B6EC78 Offset: 0x1B6EC78 VA: 0x1B6EC78
	public static BigInteger MultiplyByDword(BigInteger n, uint f) { }

	// RVA: 0x1B6EA18 Offset: 0x1B6EA18 VA: 0x1B6EA18
	public static void Multiply(uint[] x, uint xOffset, uint xLen, uint[] y, uint yOffset, uint yLen, uint[] d, uint dOffset) { }

	// RVA: 0x1B722D4 Offset: 0x1B722D4 VA: 0x1B722D4
	public static void MultiplyMod2p32pmod(uint[] x, int xOffset, int xLen, uint[] y, int yOffest, int yLen, uint[] d, int dOffset, int mod) { }

	// RVA: 0x1B723F8 Offset: 0x1B723F8 VA: 0x1B723F8
	public static uint modInverse(BigInteger bi, uint modulus) { }

	// RVA: 0x1B70940 Offset: 0x1B70940 VA: 0x1B70940
	public static BigInteger modInverse(BigInteger bi, BigInteger modulus) { }
}
