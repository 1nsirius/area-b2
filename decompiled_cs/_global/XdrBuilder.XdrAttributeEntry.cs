// Namespace: 
private sealed class XdrBuilder.XdrAttributeEntry // TypeDefIndex: 2727
{
	// Fields
	internal SchemaNames.Token _Attribute; // 0x8
	internal int _SchemaFlags; // 0xC
	internal XmlSchemaDatatype _Datatype; // 0x10
	internal XdrBuilder.XdrBuildFunction _BuildFunc; // 0x14

	// Methods

	// RVA: 0x183E5B4 Offset: 0x183E5B4 VA: 0x183E5B4
	internal void .ctor(SchemaNames.Token a, XmlTokenizedType ttype, XdrBuilder.XdrBuildFunction build) { }

	// RVA: 0x183E5F8 Offset: 0x183E5F8 VA: 0x183E5F8
	internal void .ctor(SchemaNames.Token a, XmlTokenizedType ttype, int schemaFlags, XdrBuilder.XdrBuildFunction build) { }
}
