// Namespace: 
private class XmlWellFormedWriter.AttributeValueCache // TypeDefIndex: 2367
{
	// Fields
	private StringBuilder stringValue; // 0x8
	private string singleStringValue; // 0xC
	private XmlWellFormedWriter.AttributeValueCache.Item[] items; // 0x10
	private int firstItem; // 0x14
	private int lastItem; // 0x18

	// Properties
	internal string StringValue { get; }

	// Methods

	// RVA: 0x141EBF8 Offset: 0x141EBF8 VA: 0x141EBF8
	internal string get_StringValue() { }

	// RVA: 0x1420CA4 Offset: 0x1420CA4 VA: 0x1420CA4
	internal void WriteEntityRef(string name) { }

	// RVA: 0x14210DC Offset: 0x14210DC VA: 0x14210DC
	internal void WriteCharEntity(char ch) { }

	// RVA: 0x14213BC Offset: 0x14213BC VA: 0x14213BC
	internal void WriteSurrogateCharEntity(char lowChar, char highChar) { }

	// RVA: 0x142171C Offset: 0x142171C VA: 0x142171C
	internal void WriteWhitespace(string ws) { }

	// RVA: 0x14218EC Offset: 0x14218EC VA: 0x14218EC
	internal void WriteString(string text) { }

	// RVA: 0x1421C8C Offset: 0x1421C8C VA: 0x1421C8C
	internal void WriteChars(char[] buffer, int index, int count) { }

	// RVA: 0x1422094 Offset: 0x1422094 VA: 0x1422094
	internal void WriteRaw(char[] buffer, int index, int count) { }

	// RVA: 0x14222E8 Offset: 0x14222E8 VA: 0x14222E8
	internal void WriteRaw(string data) { }

	// RVA: 0x1422F54 Offset: 0x1422F54 VA: 0x1422F54
	internal void WriteValue(string value) { }

	// RVA: 0x141F328 Offset: 0x141F328 VA: 0x141F328
	internal void Replay(XmlWriter writer) { }

	// RVA: 0x141FAD4 Offset: 0x141FAD4 VA: 0x141FAD4
	internal void Trim() { }

	// RVA: 0x142043C Offset: 0x142043C VA: 0x142043C
	internal void Clear() { }

	// RVA: 0x1425158 Offset: 0x1425158 VA: 0x1425158
	private void StartComplexValue() { }

	// RVA: 0x14251A8 Offset: 0x14251A8 VA: 0x14251A8
	private void AddItem(XmlWellFormedWriter.AttributeValueCache.ItemType type, object data) { }

	// RVA: 0x1423194 Offset: 0x1423194 VA: 0x1423194
	public void .ctor() { }
}
