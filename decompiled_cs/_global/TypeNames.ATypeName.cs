// Namespace: 
internal abstract class TypeNames.ATypeName : TypeName, IEquatable<TypeName> // TypeDefIndex: 398
{
	// Properties
	public abstract string DisplayName { get; }

	// Methods

	// RVA: -1 Offset: -1 Slot: 6
	public abstract string get_DisplayName();

	// RVA: 0x2BE7CB0 Offset: 0x2BE7CB0 VA: 0x2BE7CB0 Slot: 5
	public bool Equals(TypeName other) { }

	// RVA: 0x2BE7DB0 Offset: 0x2BE7DB0 VA: 0x2BE7DB0 Slot: 2
	public override int GetHashCode() { }

	// RVA: 0x2BE7DF4 Offset: 0x2BE7DF4 VA: 0x2BE7DF4 Slot: 0
	public override bool Equals(object other) { }

	// RVA: 0x2BE64FC Offset: 0x2BE64FC VA: 0x2BE64FC
	protected void .ctor() { }
}
