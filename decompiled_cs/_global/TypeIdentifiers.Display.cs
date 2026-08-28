// Namespace: 
private class TypeIdentifiers.Display : TypeNames.ATypeName, TypeIdentifier, TypeName, IEquatable<TypeName> // TypeDefIndex: 400
{
	// Fields
	private string displayName; // 0x8
	private string internal_name; // 0xC

	// Properties
	public override string DisplayName { get; }
	public string InternalName { get; }

	// Methods

	// RVA: 0x2BE64D4 Offset: 0x2BE64D4 VA: 0x2BE64D4
	internal void .ctor(string displayName) { }

	// RVA: 0x2BE6504 Offset: 0x2BE6504 VA: 0x2BE6504 Slot: 6
	public override string get_DisplayName() { }

	// RVA: 0x2BE650C Offset: 0x2BE650C VA: 0x2BE650C Slot: 7
	public string get_InternalName() { }

	// RVA: 0x2BE6534 Offset: 0x2BE6534 VA: 0x2BE6534
	private string GetInternalName() { }
}
