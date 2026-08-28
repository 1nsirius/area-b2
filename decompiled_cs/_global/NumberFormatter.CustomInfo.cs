// Namespace: 
private class NumberFormatter.CustomInfo // TypeDefIndex: 372
{
	// Fields
	public bool UseGroup; // 0x8
	public int DecimalDigits; // 0xC
	public int DecimalPointPos; // 0x10
	public int DecimalTailSharpDigits; // 0x14
	public int IntegerDigits; // 0x18
	public int IntegerHeadSharpDigits; // 0x1C
	public int IntegerHeadPos; // 0x20
	public bool UseExponent; // 0x24
	public int ExponentDigits; // 0x28
	public int ExponentTailSharpDigits; // 0x2C
	public bool ExponentNegativeSignOnly; // 0x30
	public int DividePlaces; // 0x34
	public int Percents; // 0x38
	public int Permilles; // 0x3C

	// Methods

	// RVA: 0x204A948 Offset: 0x204A948 VA: 0x204A948
	public static void GetActiveSection(string format, ref bool positive, bool zero, ref int offset, ref int length) { }

	// RVA: 0x204AF20 Offset: 0x204AF20 VA: 0x204AF20
	public static NumberFormatter.CustomInfo Parse(string format, int offset, int length, NumberFormatInfo nfi) { }

	// RVA: 0x204BA18 Offset: 0x204BA18 VA: 0x204BA18
	public string Format(string format, int offset, int length, NumberFormatInfo nfi, bool positive, StringBuilder sb_int, StringBuilder sb_dec, StringBuilder sb_exp) { }

	// RVA: 0x204C928 Offset: 0x204C928 VA: 0x204C928
	public void .ctor() { }
}
