// Namespace: 
internal class Encoding.EncodingByteBuffer // TypeDefIndex: 448
{
	// Fields
	private byte* bytes; // 0x8
	private byte* byteStart; // 0xC
	private byte* byteEnd; // 0x10
	private char* chars; // 0x14
	private char* charStart; // 0x18
	private char* charEnd; // 0x1C
	private int byteCountResult; // 0x20
	private Encoding enc; // 0x24
	private EncoderNLS encoder; // 0x28
	internal EncoderFallbackBuffer fallbackBuffer; // 0x2C

	// Properties
	internal bool MoreData { get; }
	internal int CharsUsed { get; }
	internal int Count { get; }

	// Methods

	// RVA: 0x20AFC28 Offset: 0x20AFC28 VA: 0x20AFC28
	internal void .ctor(Encoding inEncoding, EncoderNLS inEncoder, byte* inByteStart, int inByteCount, char* inCharStart, int inCharCount) { }

	// RVA: 0x20AFF14 Offset: 0x20AFF14 VA: 0x20AFF14
	internal bool AddByte(byte b, int moreBytesExpected) { }

	// RVA: 0x20B001C Offset: 0x20B001C VA: 0x20B001C
	internal bool AddByte(byte b1) { }

	// RVA: 0x20B0024 Offset: 0x20B0024 VA: 0x20B0024
	internal bool AddByte(byte b1, byte b2) { }

	// RVA: 0x20B0040 Offset: 0x20B0040 VA: 0x20B0040
	internal bool AddByte(byte b1, byte b2, int moreBytesExpected) { }

	// RVA: 0x20AFF68 Offset: 0x20AFF68 VA: 0x20AFF68
	internal void MovePrevious(bool bThrow) { }

	// RVA: 0x20B0080 Offset: 0x20B0080 VA: 0x20B0080
	internal bool get_MoreData() { }

	// RVA: 0x20B00DC Offset: 0x20B00DC VA: 0x20B00DC
	internal char GetNextChar() { }

	// RVA: 0x20B0148 Offset: 0x20B0148 VA: 0x20B0148
	internal int get_CharsUsed() { }

	// RVA: 0x20B0160 Offset: 0x20B0160 VA: 0x20B0160
	internal int get_Count() { }
}
