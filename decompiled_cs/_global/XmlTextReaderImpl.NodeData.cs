// Namespace: 
private class XmlTextReaderImpl.NodeData : IComparable // TypeDefIndex: 2350
{
	// Fields
	private static XmlTextReaderImpl.NodeData s_None; // 0x0
	internal XmlNodeType type; // 0x8
	internal string localName; // 0xC
	internal string prefix; // 0x10
	internal string ns; // 0x14
	internal string nameWPrefix; // 0x18
	private string value; // 0x1C
	private char[] chars; // 0x20
	private int valueStartPos; // 0x24
	private int valueLength; // 0x28
	internal LineInfo lineInfo; // 0x2C
	internal LineInfo lineInfo2; // 0x34
	internal char quoteChar; // 0x3C
	internal int depth; // 0x40
	private bool isEmptyOrDefault; // 0x44
	internal int entityId; // 0x48
	internal bool xmlContextPushed; // 0x4C
	internal XmlTextReaderImpl.NodeData nextAttrValueChunk; // 0x50
	internal object schemaType; // 0x54
	internal object typedValue; // 0x58

	// Properties
	internal static XmlTextReaderImpl.NodeData None { get; }
	internal int LineNo { get; }
	internal int LinePos { get; }
	internal bool IsEmptyElement { get; set; }
	internal bool IsDefaultAttribute { get; set; }
	internal bool ValueBuffered { get; }
	internal string StringValue { get; }

	// Methods

	// RVA: 0x1412100 Offset: 0x1412100 VA: 0x1412100
	internal static XmlTextReaderImpl.NodeData get_None() { }

	// RVA: 0x14121D0 Offset: 0x14121D0 VA: 0x14121D0
	internal void .ctor() { }

	// RVA: 0x1412294 Offset: 0x1412294 VA: 0x1412294
	internal int get_LineNo() { }

	// RVA: 0x141229C Offset: 0x141229C VA: 0x141229C
	internal int get_LinePos() { }

	// RVA: 0x14122A4 Offset: 0x14122A4 VA: 0x14122A4
	internal bool get_IsEmptyElement() { }

	// RVA: 0x14122C8 Offset: 0x14122C8 VA: 0x14122C8
	internal void set_IsEmptyElement(bool value) { }

	// RVA: 0x14122D0 Offset: 0x14122D0 VA: 0x14122D0
	internal bool get_IsDefaultAttribute() { }

	// RVA: 0x14122F4 Offset: 0x14122F4 VA: 0x14122F4
	internal void set_IsDefaultAttribute(bool value) { }

	// RVA: 0x14122FC Offset: 0x14122FC VA: 0x14122FC
	internal bool get_ValueBuffered() { }

	// RVA: 0x1412310 Offset: 0x1412310 VA: 0x1412310
	internal string get_StringValue() { }

	// RVA: 0x1412350 Offset: 0x1412350 VA: 0x1412350
	internal void TrimSpacesInValue() { }

	// RVA: 0x14121FC Offset: 0x14121FC VA: 0x14121FC
	internal void Clear(XmlNodeType type) { }

	// RVA: 0x1412390 Offset: 0x1412390 VA: 0x1412390
	internal void ClearName() { }

	// RVA: 0x141241C Offset: 0x141241C VA: 0x141241C
	internal void SetLineInfo(int lineNo, int linePos) { }

	// RVA: 0x1412428 Offset: 0x1412428 VA: 0x1412428
	internal void SetLineInfo2(int lineNo, int linePos) { }

	// RVA: 0x1412434 Offset: 0x1412434 VA: 0x1412434
	internal void SetValueNode(XmlNodeType type, string value) { }

	// RVA: 0x141245C Offset: 0x141245C VA: 0x141245C
	internal void SetValueNode(XmlNodeType type, char[] chars, int startPos, int len) { }

	// RVA: 0x1412494 Offset: 0x1412494 VA: 0x1412494
	internal void SetNamedNode(XmlNodeType type, string localName) { }

	// RVA: 0x141251C Offset: 0x141251C VA: 0x141251C
	internal void SetNamedNode(XmlNodeType type, string localName, string prefix, string nameWPrefix) { }

	// RVA: 0x14125B8 Offset: 0x14125B8 VA: 0x14125B8
	internal void SetValue(string value) { }

	// RVA: 0x14125C8 Offset: 0x14125C8 VA: 0x14125C8
	internal void SetValue(char[] chars, int startPos, int len) { }

	// RVA: 0x14125DC Offset: 0x14125DC VA: 0x14125DC
	internal void OnBufferInvalidated() { }

	// RVA: 0x1412630 Offset: 0x1412630 VA: 0x1412630
	internal void CopyTo(int valueOffset, StringBuilder sb) { }

	// RVA: 0x1412704 Offset: 0x1412704 VA: 0x1412704
	internal string GetNameWPrefix(XmlNameTable nt) { }

	// RVA: 0x1412718 Offset: 0x1412718 VA: 0x1412718
	internal string CreateNameWPrefix(XmlNameTable nt) { }

	// RVA: 0x14127E8 Offset: 0x14127E8 VA: 0x14127E8 Slot: 4
	private int System.IComparable.CompareTo(object obj) { }
}
