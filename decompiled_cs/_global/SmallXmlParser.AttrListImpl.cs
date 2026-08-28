// Namespace: 
private class SmallXmlParser.AttrListImpl : SmallXmlParser.IAttrList // TypeDefIndex: 44
{
	// Fields
	private List<string> attrNames; // 0x8
	private List<string> attrValues; // 0xC

	// Properties
	public int Length { get; }
	public string[] Names { get; }
	public string[] Values { get; }

	// Methods

	// RVA: 0x192CE00 Offset: 0x192CE00 VA: 0x192CE00 Slot: 4
	public int get_Length() { }

	// RVA: 0x192CE78 Offset: 0x192CE78 VA: 0x192CE78 Slot: 5
	public string GetName(int i) { }

	// RVA: 0x192CEF8 Offset: 0x192CEF8 VA: 0x192CEF8 Slot: 6
	public string GetValue(int i) { }

	// RVA: 0x192CF78 Offset: 0x192CF78 VA: 0x192CF78 Slot: 7
	public string GetValue(string name) { }

	// RVA: 0x192D084 Offset: 0x192D084 VA: 0x192D084 Slot: 8
	public string[] get_Names() { }

	// RVA: 0x192D0FC Offset: 0x192D0FC VA: 0x192D0FC Slot: 9
	public string[] get_Values() { }

	// RVA: 0x192C724 Offset: 0x192C724 VA: 0x192C724
	internal void Clear() { }

	// RVA: 0x192CD4C Offset: 0x192CD4C VA: 0x192CD4C
	internal void Add(string name, string value) { }

	// RVA: 0x192AB20 Offset: 0x192AB20 VA: 0x192AB20
	public void .ctor() { }
}
