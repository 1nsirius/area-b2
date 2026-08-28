// Namespace: 
private sealed class BigInteger.Kernel // TypeDefIndex: 2215
{
	// Methods

	// RVA: 0x22AF9C4 Offset: 0x22AF9C4 VA: 0x22AF9C4
	public static BigInteger Subtract(BigInteger big, BigInteger small) { }

	// RVA: 0x22B334C Offset: 0x22B334C VA: 0x22B334C
	public static void MinusEq(BigInteger big, BigInteger small) { }

	// RVA: 0x22B355C Offset: 0x22B355C VA: 0x22B355C
	public static void PlusEq(BigInteger bi1, BigInteger bi2) { }

	// RVA: 0x22AF6DC Offset: 0x22AF6DC VA: 0x22AF6DC
	public static BigInteger.Sign Compare(BigInteger bi1, BigInteger bi2) { }

	// RVA: 0x22B20F8 Offset: 0x22B20F8 VA: 0x22B20F8
	public static uint SingleByteDivideInPlace(BigInteger n, uint d) { }

	// RVA: 0x22AFCD8 Offset: 0x22AFCD8 VA: 0x22AFCD8
	public static uint DwordMod(BigInteger n, uint d) { }

	// RVA: 0x22B3864 Offset: 0x22B3864 VA: 0x22B3864
	public static BigInteger[] DwordDivMod(BigInteger n, uint d) { }

	// RVA: 0x22AFDB8 Offset: 0x22AFDB8 VA: 0x22AFDB8
	public static BigInteger[] multiByteDivide(BigInteger bi1, BigInteger bi2) { }

	// RVA: 0x22B0C20 Offset: 0x22B0C20 VA: 0x22B0C20
	public static BigInteger LeftShift(BigInteger bi, int n) { }

	// RVA: 0x22B0FAC Offset: 0x22B0FAC VA: 0x22B0FAC
	public static BigInteger RightShift(BigInteger bi, int n) { }

	// RVA: 0x22B0AE8 Offset: 0x22B0AE8 VA: 0x22B0AE8
	public static void Multiply(uint[] x, uint xOffset, uint xLen, uint[] y, uint yOffset, uint yLen, uint[] d, uint dOffset) { }

	// RVA: 0x22B3B0C Offset: 0x22B3B0C VA: 0x22B3B0C
	public static void MultiplyMod2p32pmod(uint[] x, int xOffset, int xLen, uint[] y, int yOffest, int yLen, uint[] d, int dOffset, int mod) { }

	// RVA: 0x22B3C30 Offset: 0x22B3C30 VA: 0x22B3C30
	public static uint modInverse(BigInteger bi, uint modulus) { }

	// RVA: 0x22B24B8 Offset: 0x22B24B8 VA: 0x22B24B8
	public static BigInteger modInverse(BigInteger bi, BigInteger modulus) { }
}
