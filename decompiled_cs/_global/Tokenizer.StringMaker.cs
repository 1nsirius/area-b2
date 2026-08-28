// Namespace: 
[Serializable]
internal sealed class Tokenizer.StringMaker // TypeDefIndex: 907
{
	// Fields
	private string[] aStrings; // 0x8
	private uint cStringsMax; // 0xC
	private uint cStringsUsed; // 0x10
	public StringBuilder _outStringBuilder; // 0x14
	public char[] _outChars; // 0x18
	public int _outIndex; // 0x1C

	// Methods

	// RVA: 0x19EF82C Offset: 0x19EF82C VA: 0x19EF82C
	private static uint HashString(string str) { }

	// RVA: 0x19EF890 Offset: 0x19EF890 VA: 0x19EF890
	private static uint HashCharArray(char[] a, int l) { }

	// RVA: 0x19EF904 Offset: 0x19EF904 VA: 0x19EF904
	public void .ctor() { }

	// RVA: 0x19EF9A4 Offset: 0x19EF9A4 VA: 0x19EF9A4
	private bool CompareStringAndChars(string str, char[] a, int l) { }

	// RVA: 0x19E81AC Offset: 0x19E81AC VA: 0x19E81AC
	public string MakeString() { }
}
