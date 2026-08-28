// Namespace: 
private sealed class ReadablePropertiesTypeInspector.ReflectionPropertyDescriptor : IPropertyDescriptor // TypeDefIndex: 5018
{
	// Fields
	private readonly PropertyInfo _propertyInfo; // 0x8
	private readonly ITypeResolver _typeResolver; // 0xC
	[CompilerGeneratedAttribute] // RVA: 0x54DCDC Offset: 0x54DCDC VA: 0x54DCDC
	private Type <TypeOverride>k__BackingField; // 0x10
	[CompilerGeneratedAttribute] // RVA: 0x54DCEC Offset: 0x54DCEC VA: 0x54DCEC
	private int <Order>k__BackingField; // 0x14
	[CompilerGeneratedAttribute] // RVA: 0x54DCFC Offset: 0x54DCFC VA: 0x54DCFC
	private ScalarStyle <ScalarStyle>k__BackingField; // 0x18

	// Properties
	public string Name { get; }
	public Type Type { get; }
	public Type TypeOverride { get; set; }
	public int Order { get; set; }
	public bool CanWrite { get; }
	public ScalarStyle ScalarStyle { get; set; }

	// Methods

	// RVA: 0x15E9A64 Offset: 0x15E9A64 VA: 0x15E9A64
	public void .ctor(PropertyInfo propertyInfo, ITypeResolver typeResolver) { }

	// RVA: 0x15E9A9C Offset: 0x15E9A9C VA: 0x15E9A9C Slot: 4
	public string get_Name() { }

	// RVA: 0x15E9AD0 Offset: 0x15E9AD0 VA: 0x15E9AD0 Slot: 6
	public Type get_Type() { }

	[CompilerGeneratedAttribute] // RVA: 0x54EB1C Offset: 0x54EB1C VA: 0x54EB1C
	// RVA: 0x15E9B04 Offset: 0x15E9B04 VA: 0x15E9B04 Slot: 7
	public Type get_TypeOverride() { }

	[CompilerGeneratedAttribute] // RVA: 0x54EB2C Offset: 0x54EB2C VA: 0x54EB2C
	// RVA: 0x15E9B0C Offset: 0x15E9B0C VA: 0x15E9B0C Slot: 8
	public void set_TypeOverride(Type value) { }

	[CompilerGeneratedAttribute] // RVA: 0x54EB3C Offset: 0x54EB3C VA: 0x54EB3C
	// RVA: 0x15E9B14 Offset: 0x15E9B14 VA: 0x15E9B14 Slot: 9
	public int get_Order() { }

	[CompilerGeneratedAttribute] // RVA: 0x54EB4C Offset: 0x54EB4C VA: 0x54EB4C
	// RVA: 0x15E9B1C Offset: 0x15E9B1C VA: 0x15E9B1C Slot: 10
	public void set_Order(int value) { }

	// RVA: 0x15E9B24 Offset: 0x15E9B24 VA: 0x15E9B24 Slot: 5
	public bool get_CanWrite() { }

	[CompilerGeneratedAttribute] // RVA: 0x54EB5C Offset: 0x54EB5C VA: 0x54EB5C
	// RVA: 0x15E9B58 Offset: 0x15E9B58 VA: 0x15E9B58 Slot: 11
	public ScalarStyle get_ScalarStyle() { }

	[CompilerGeneratedAttribute] // RVA: 0x54EB6C Offset: 0x54EB6C VA: 0x54EB6C
	// RVA: 0x15E9A94 Offset: 0x15E9A94 VA: 0x15E9A94 Slot: 12
	public void set_ScalarStyle(ScalarStyle value) { }

	// RVA: 0x15E9B60 Offset: 0x15E9B60 VA: 0x15E9B60 Slot: 15
	public void Write(object target, object value) { }

	// RVA: -1 Offset: -1 Slot: 13
	public T GetCustomAttribute<T>() { }
	/* GenericInstMethod :
	|
	|-RVA: 0xDF47C0 Offset: 0xDF47C0 VA: 0xDF47C0
	|-ReadablePropertiesTypeInspector.ReflectionPropertyDescriptor.GetCustomAttribute<object>
	*/

	// RVA: 0x15E9BB4 Offset: 0x15E9BB4 VA: 0x15E9BB4 Slot: 14
	public IObjectDescriptor Read(object target) { }
}
