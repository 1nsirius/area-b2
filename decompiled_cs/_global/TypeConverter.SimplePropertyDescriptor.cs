// Namespace: 
protected abstract class TypeConverter.SimplePropertyDescriptor : PropertyDescriptor // TypeDefIndex: 1793
{
	// Fields
	private Type componentType; // 0x44
	private Type propertyType; // 0x48

	// Properties
	public override Type ComponentType { get; }
	public override bool IsReadOnly { get; }
	public override Type PropertyType { get; }

	// Methods

	// RVA: 0x218E27C Offset: 0x218E27C VA: 0x218E27C
	protected void .ctor(Type componentType, string name, Type propertyType, Attribute[] attributes) { }

	// RVA: 0x218E2AC Offset: 0x218E2AC VA: 0x218E2AC Slot: 12
	public override Type get_ComponentType() { }

	// RVA: 0x218E2B4 Offset: 0x218E2B4 VA: 0x218E2B4 Slot: 13
	public override bool get_IsReadOnly() { }

	// RVA: 0x218E37C Offset: 0x218E37C VA: 0x218E37C Slot: 14
	public override Type get_PropertyType() { }
}
