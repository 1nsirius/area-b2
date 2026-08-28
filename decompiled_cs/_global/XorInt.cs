// Namespace: 
public struct XorInt : IEquatable<XorInt> // TypeDefIndex: 5269
{
	// Fields
	private static int cryptoKey; // 0x0
	private int currentCryptoKey; // 0x0
	private int hiddenValue; // 0x4

	// Properties
	public int v { get; set; }

	// Methods

	// RVA: 0x765028 Offset: 0x765028 VA: 0x765028
	public int get_v() { }

	// RVA: 0x765030 Offset: 0x765030 VA: 0x765030
	public void set_v(int value) { }

	// RVA: 0x765038 Offset: 0x765038 VA: 0x765038
	public void .ctor(int value) { }

	// RVA: 0x13443F0 Offset: 0x13443F0 VA: 0x13443F0
	public static void SetNewCryptoKey(int newKey) { }

	// RVA: 0x765040 Offset: 0x765040 VA: 0x765040
	public int GetEncrypted() { }

	// RVA: 0x765048 Offset: 0x765048 VA: 0x765048
	public void SetEncrypted(int encrypted) { }

	// RVA: 0x13442C8 Offset: 0x13442C8 VA: 0x13442C8
	public static int EncryptDecrypt(int value) { }

	// RVA: 0x134459C Offset: 0x134459C VA: 0x134459C
	public static int EncryptDecrypt(int value, int key) { }

	// RVA: 0x765050 Offset: 0x765050 VA: 0x765050
	private int InternalEncryptDecrypt() { }

	// RVA: 0x1344644 Offset: 0x1344644 VA: 0x1344644
	public static XorInt op_Implicit(int value) { }

	// RVA: 0x1344660 Offset: 0x1344660 VA: 0x1344660
	public static XorInt op_Implicit(uint value) { }

	// RVA: 0x134467C Offset: 0x134467C VA: 0x134467C
	public static int op_Implicit(XorInt value) { }

	// RVA: 0x1344698 Offset: 0x1344698 VA: 0x1344698
	public static uint op_Implicit(XorInt value) { }

	// RVA: 0x13446B4 Offset: 0x13446B4 VA: 0x13446B4
	public static float op_Implicit(XorInt value) { }

	// RVA: 0x13446DC Offset: 0x13446DC VA: 0x13446DC
	public static XorInt op_Increment(XorInt input) { }

	// RVA: 0x1344788 Offset: 0x1344788 VA: 0x1344788
	public static XorInt op_Decrement(XorInt input) { }

	// RVA: 0x1344834 Offset: 0x1344834 VA: 0x1344834
	public static XorInt op_Addition(XorInt a, XorInt b) { }

	// RVA: 0x1344884 Offset: 0x1344884 VA: 0x1344884
	public static XorInt op_Subtraction(XorInt a, XorInt b) { }

	// RVA: 0x13448D4 Offset: 0x13448D4 VA: 0x13448D4
	public static XorInt op_Multiply(XorInt a, XorInt b) { }

	// RVA: 0x1344924 Offset: 0x1344924 VA: 0x1344924
	public static XorInt op_Division(XorInt a, XorInt b) { }

	// RVA: 0x1344980 Offset: 0x1344980 VA: 0x1344980
	public static XorInt op_Addition(XorInt a, int b) { }

	// RVA: 0x13449C0 Offset: 0x13449C0 VA: 0x13449C0
	public static XorInt op_Subtraction(XorInt a, int b) { }

	// RVA: 0x1344A00 Offset: 0x1344A00 VA: 0x1344A00
	public static XorInt op_Multiply(XorInt a, int b) { }

	// RVA: 0x1344A40 Offset: 0x1344A40 VA: 0x1344A40
	public static XorInt op_Division(XorInt a, int b) { }

	// RVA: 0x1344A88 Offset: 0x1344A88 VA: 0x1344A88
	public static XorInt op_Addition(int a, XorInt b) { }

	// RVA: 0x1344AC8 Offset: 0x1344AC8 VA: 0x1344AC8
	public static XorInt op_Subtraction(int a, XorInt b) { }

	// RVA: 0x1344B08 Offset: 0x1344B08 VA: 0x1344B08
	public static XorInt op_Multiply(int a, XorInt b) { }

	// RVA: 0x1344B48 Offset: 0x1344B48 VA: 0x1344B48
	public static XorInt op_Division(int a, XorInt b) { }

	// RVA: 0x1344B94 Offset: 0x1344B94 VA: 0x1344B94
	public static int op_Multiply(XorInt a, float b) { }

	// RVA: 0x1344BD0 Offset: 0x1344BD0 VA: 0x1344BD0
	public static bool op_LessThan(XorInt a, XorInt b) { }

	// RVA: 0x1344C14 Offset: 0x1344C14 VA: 0x1344C14
	public static bool op_LessThanOrEqual(XorInt a, XorInt b) { }

	// RVA: 0x1344C58 Offset: 0x1344C58 VA: 0x1344C58
	public static bool op_GreaterThan(XorInt a, XorInt b) { }

	// RVA: 0x1344C9C Offset: 0x1344C9C VA: 0x1344C9C
	public static bool op_GreaterThanOrEqual(XorInt a, XorInt b) { }

	// RVA: 0x1344CE0 Offset: 0x1344CE0 VA: 0x1344CE0
	public static bool op_LessThan(XorInt a, int b) { }

	// RVA: 0x1344D14 Offset: 0x1344D14 VA: 0x1344D14
	public static bool op_LessThanOrEqual(XorInt a, int b) { }

	// RVA: 0x1344D48 Offset: 0x1344D48 VA: 0x1344D48
	public static bool op_GreaterThan(XorInt a, int b) { }

	// RVA: 0x1344D7C Offset: 0x1344D7C VA: 0x1344D7C
	public static bool op_GreaterThanOrEqual(XorInt a, int b) { }

	// RVA: 0x765058 Offset: 0x765058 VA: 0x765058 Slot: 4
	public bool Equals(XorInt other) { }

	// RVA: 0x765060 Offset: 0x765060 VA: 0x765060 Slot: 0
	public override bool Equals(object obj) { }

	// RVA: 0x1344E7C Offset: 0x1344E7C VA: 0x1344E7C
	public static bool op_Equality(XorInt left, XorInt right) { }

	// RVA: 0x1344EA0 Offset: 0x1344EA0 VA: 0x1344EA0
	public static bool op_Inequality(XorInt left, XorInt right) { }

	// RVA: 0x765068 Offset: 0x765068 VA: 0x765068 Slot: 2
	public override int GetHashCode() { }

	// RVA: 0x765094 Offset: 0x765094 VA: 0x765094 Slot: 3
	public override string ToString() { }

	// RVA: 0x7650C0 Offset: 0x7650C0 VA: 0x7650C0
	public string ToString(string format) { }

	// RVA: 0x7650F4 Offset: 0x7650F4 VA: 0x7650F4
	public string ToString(IFormatProvider provider) { }

	// RVA: 0x765128 Offset: 0x765128 VA: 0x765128
	public string ToString(string format, IFormatProvider provider) { }

	// RVA: 0x1344FB0 Offset: 0x1344FB0 VA: 0x1344FB0
	private static void .cctor() { }
}
