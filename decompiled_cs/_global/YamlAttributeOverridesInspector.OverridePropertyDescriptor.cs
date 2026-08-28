// Namespace: 
public sealed class YamlAttributeOverridesInspector.OverridePropertyDescriptor : IPropertyDescriptor // TypeDefIndex: 4989
{
	// Fields
	private readonly IPropertyDescriptor baseDescriptor; // 0x8
	private readonly YamlAttributeOverrides overrides; // 0xC
	private readonly Type classType; // 0x10

	// Properties
	public string Name { get; }
	public bool CanWrite { get; }
	public Type Type { get; }
	public Type TypeOverride { get; set; }
	public int Order { get; set; }
	public ScalarStyle ScalarStyle { get; set; }

	// Methods

	// RVA: 0x2C95408 Offset: 0x2C95408 VA: 0x2C95408
	public void .ctor(IPropertyDescriptor baseDescriptor, YamlAttributeOverrides overrides, Type classType) { }

	// RVA: 0x2C95438 Offset: 0x2C95438 VA: 0x2C95438 Slot: 4
	public string get_Name() { }

	// RVA: 0x2C95510 Offset: 0x2C95510 VA: 0x2C95510 Slot: 5
	public bool get_CanWrite() { }

	// RVA: 0x2C955E8 Offset: 0x2C955E8 VA: 0x2C955E8 Slot: 6
	public Type get_Type() { }

	// RVA: 0x2C956C0 Offset: 0x2C956C0 VA: 0x2C956C0 Slot: 7
	public Type get_TypeOverride() { }

	// RVA: 0x2C95798 Offset: 0x2C95798 VA: 0x2C95798 Slot: 8
	public void set_TypeOverride(Type value) { }

	// RVA: 0x2C95878 Offset: 0x2C95878 VA: 0x2C95878 Slot: 9
	public int get_Order() { }

	// RVA: 0x2C95950 Offset: 0x2C95950 VA: 0x2C95950 Slot: 10
	public void set_Order(int value) { }

	// RVA: 0x2C95A30 Offset: 0x2C95A30 VA: 0x2C95A30 Slot: 11
	public ScalarStyle get_ScalarStyle() { }

	// RVA: 0x2C95B08 Offset: 0x2C95B08 VA: 0x2C95B08 Slot: 12
	public void set_ScalarStyle(ScalarStyle value) { }

	// RVA: 0x2C95BE8 Offset: 0x2C95BE8 VA: 0x2C95BE8 Slot: 15
	public void Write(object target, object value) { }

	// RVA: -1 Offset: -1 Slot: 13
	public T GetCustomAttribute<T>() { }
	/* GenericInstMethod :
	|
	|-RVA: 0xDF5390 Offset: 0xDF5390 VA: 0xDF5390
	|-YamlAttributeOverridesInspector.OverridePropertyDescriptor.GetCustomAttribute<object>
	*/

	// RVA: 0x2C95CD0 Offset: 0x2C95CD0 VA: 0x2C95CD0 Slot: 14
	public IObjectDescriptor Read(object target) { }
}
