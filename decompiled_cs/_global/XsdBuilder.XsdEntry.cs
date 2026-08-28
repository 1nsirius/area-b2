// Namespace: 
private sealed class XsdBuilder.XsdEntry // TypeDefIndex: 2844
{
	// Fields
	public SchemaNames.Token Name; // 0x8
	public XsdBuilder.State CurrentState; // 0xC
	public XsdBuilder.State[] NextStates; // 0x10
	public XsdBuilder.XsdAttributeEntry[] Attributes; // 0x14
	public XsdBuilder.XsdInitFunction InitFunc; // 0x18
	public XsdBuilder.XsdEndChildFunction EndChildFunc; // 0x1C
	public bool ParseContent; // 0x20

	// Methods

	// RVA: 0x18A6928 Offset: 0x18A6928 VA: 0x18A6928
	public void .ctor(SchemaNames.Token n, XsdBuilder.State state, XsdBuilder.State[] nextStates, XsdBuilder.XsdAttributeEntry[] attributes, XsdBuilder.XsdInitFunction init, XsdBuilder.XsdEndChildFunction end, bool parseContent) { }
}
