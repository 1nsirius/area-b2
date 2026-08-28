// Namespace: 
internal class Encoding.EncodingCharBuffer // TypeDefIndex: 447
{
	// Fields
	private char* chars; // 0x8
	private char* charStart; // 0xC
	private char* charEnd; // 0x10
	private int charCountResult; // 0x14
	private Encoding enc; // 0x18
	private DecoderNLS decoder; // 0x1C
	private byte* byteStart; // 0x20
	private byte* byteEnd; // 0x24
	private byte* bytes; // 0x28
	private DecoderFallbackBuffer fallbackBuffer; // 0x2C

	// Properties
	internal bool MoreData { get; }
	internal int BytesUsed { get; }
	internal int Count { get; }

	// Methods

	// RVA: 0x20B0168 Offset: 0x20B0168 VA: 0x20B0168
	internal void .ctor(Encoding enc, DecoderNLS decoder, char* charStart, int charCount, byte* byteStart, int byteCount) { }

	// RVA: 0x20B0234 Offset: 0x20B0234 VA: 0x20B0234
	internal bool AddChar(char ch, int numBytes) { }

	// RVA: 0x20B02C0 Offset: 0x20B02C0 VA: 0x20B02C0
	internal bool AddChar(char ch) { }

	// RVA: 0x20B02C8 Offset: 0x20B02C8 VA: 0x20B02C8
	internal void AdjustBytes(int count) { }

	// RVA: 0x20B02D8 Offset: 0x20B02D8 VA: 0x20B02D8
	internal bool get_MoreData() { }

	// RVA: 0x20B02F0 Offset: 0x20B02F0 VA: 0x20B02F0
	internal byte GetNextByte() { }

	// RVA: 0x20B0314 Offset: 0x20B0314 VA: 0x20B0314
	internal int get_BytesUsed() { }

	// RVA: 0x20B0324 Offset: 0x20B0324 VA: 0x20B0324
	internal bool Fallback(byte fallbackByte) { }

	// RVA: 0x20B03CC Offset: 0x20B03CC VA: 0x20B03CC
	internal bool Fallback(byte[] byteBuffer) { }

	// RVA: 0x20B0528 Offset: 0x20B0528 VA: 0x20B0528
	internal int get_Count() { }
}
