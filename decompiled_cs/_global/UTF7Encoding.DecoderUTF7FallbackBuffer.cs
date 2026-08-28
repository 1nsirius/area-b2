// Namespace: 
internal sealed class UTF7Encoding.DecoderUTF7FallbackBuffer : DecoderFallbackBuffer // TypeDefIndex: 462
{
	// Fields
	private char cFallback; // 0x10
	private int iCount; // 0x14
	private int iSize; // 0x18

	// Properties
	public override int Remaining { get; }

	// Methods

	// RVA: 0x12820A4 Offset: 0x12820A4 VA: 0x12820A4
	public void .ctor(UTF7Encoding.DecoderUTF7Fallback fallback) { }

	// RVA: 0x1282140 Offset: 0x1282140 VA: 0x1282140 Slot: 4
	public override bool Fallback(byte[] bytesUnknown, int index) { }

	// RVA: 0x128219C Offset: 0x128219C VA: 0x128219C Slot: 5
	public override char GetNextChar() { }

	// RVA: 0x12821B4 Offset: 0x12821B4 VA: 0x12821B4 Slot: 6
	public override int get_Remaining() { }

	// RVA: 0x12821C4 Offset: 0x12821C4 VA: 0x12821C4 Slot: 7
	public override void Reset() { }

	// RVA: 0x12821D8 Offset: 0x12821D8 VA: 0x12821D8 Slot: 9
	internal override int InternalFallback(byte[] bytes, byte* pBytes) { }
}
