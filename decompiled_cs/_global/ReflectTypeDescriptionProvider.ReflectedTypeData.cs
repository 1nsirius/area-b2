// Namespace: 
private class ReflectTypeDescriptionProvider.ReflectedTypeData // TypeDefIndex: 1785
{
	// Fields
	private Type _type; // 0x8
	private AttributeCollection _attributes; // 0xC
	private EventDescriptorCollection _events; // 0x10
	private PropertyDescriptorCollection _properties; // 0x14
	private TypeConverter _converter; // 0x18
	private object[] _editors; // 0x1C
	private Type[] _editorTypes; // 0x20
	private int _editorCount; // 0x24

	// Properties
	internal bool IsPopulated { get; }

	// Methods

	// RVA: 0x21895E4 Offset: 0x21895E4 VA: 0x21895E4
	internal void .ctor(Type type) { }

	// RVA: 0x21897CC Offset: 0x21897CC VA: 0x21897CC
	internal bool get_IsPopulated() { }

	// RVA: 0x2184AD0 Offset: 0x2184AD0 VA: 0x2184AD0
	internal AttributeCollection GetAttributes() { }

	// RVA: 0x21857B8 Offset: 0x21857B8 VA: 0x21857B8
	internal TypeConverter GetConverter(object instance) { }

	// RVA: 0x2189224 Offset: 0x2189224 VA: 0x2189224
	internal PropertyDescriptorCollection GetProperties() { }

	// RVA: 0x218B8FC Offset: 0x218B8FC VA: 0x218B8FC
	private Type GetTypeFromName(string typeName) { }

	// RVA: 0x218A838 Offset: 0x218A838 VA: 0x218A838
	internal void Refresh() { }
}
