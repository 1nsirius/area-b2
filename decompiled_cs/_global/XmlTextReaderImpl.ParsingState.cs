// Namespace: 
private struct XmlTextReaderImpl.ParsingState // TypeDefIndex: 2346
{
	// Fields
	internal char[] chars; // 0x0
	internal int charPos; // 0x4
	internal int charsUsed; // 0x8
	internal Encoding encoding; // 0xC
	internal bool appendMode; // 0x10
	internal Stream stream; // 0x14
	internal Decoder decoder; // 0x18
	internal byte[] bytes; // 0x1C
	internal int bytePos; // 0x20
	internal int bytesUsed; // 0x24
	internal TextReader textReader; // 0x28
	internal int lineNo; // 0x2C
	internal int lineStartPos; // 0x30
	internal string baseUriStr; // 0x34
	internal Uri baseUri; // 0x38
	internal bool isEof; // 0x3C
	internal bool isStreamEof; // 0x3D
	internal IDtdEntityInfo entity; // 0x40
	internal int entityId; // 0x44
	internal bool eolNormalized; // 0x48
	internal bool entityResolvedManually; // 0x49

	// Properties
	internal int LineNo { get; }
	internal int LinePos { get; }

	// Methods

	// RVA: 0x766240 Offset: 0x766240 VA: 0x766240
	internal void Clear() { }

	// RVA: 0x766248 Offset: 0x766248 VA: 0x766248
	internal void Close(bool closeInput) { }

	// RVA: 0x766250 Offset: 0x766250 VA: 0x766250
	internal int get_LineNo() { }

	// RVA: 0x766258 Offset: 0x766258 VA: 0x766258
	internal int get_LinePos() { }
}
