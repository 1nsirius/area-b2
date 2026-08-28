// Namespace: 
private sealed class TypeDescriptor.TypeDescriptionNode : TypeDescriptionProvider // TypeDefIndex: 1807
{
	// Fields
	internal TypeDescriptor.TypeDescriptionNode Next; // 0x10
	internal TypeDescriptionProvider Provider; // 0x14

	// Methods

	// RVA: 0x218FB48 Offset: 0x218FB48 VA: 0x218FB48
	internal void .ctor(TypeDescriptionProvider provider) { }

	// RVA: 0x2198E44 Offset: 0x2198E44 VA: 0x2198E44 Slot: 4
	public override IDictionary GetCache(object instance) { }

	// RVA: 0x2198F20 Offset: 0x2198F20 VA: 0x2198F20 Slot: 5
	public override ICustomTypeDescriptor GetExtendedTypeDescriptor(object instance) { }

	// RVA: 0x2199000 Offset: 0x2199000 VA: 0x2199000 Slot: 6
	protected internal override IExtenderProvider[] GetExtenderProviders(object instance) { }

	// RVA: 0x21990DC Offset: 0x21990DC VA: 0x21990DC Slot: 7
	public override Type GetReflectionType(Type objectType, object instance) { }

	// RVA: 0x21991FC Offset: 0x21991FC VA: 0x21991FC Slot: 8
	public override ICustomTypeDescriptor GetTypeDescriptor(Type objectType, object instance) { }
}
