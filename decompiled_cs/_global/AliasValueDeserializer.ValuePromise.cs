// Namespace: 
private sealed class AliasValueDeserializer.ValuePromise : IValuePromise // TypeDefIndex: 4998
{
	// Fields
	[CompilerGeneratedAttribute] // RVA: 0x54DCBC Offset: 0x54DCBC VA: 0x54DCBC
	private Action<object> ValueAvailable; // 0x8
	[CompilerGeneratedAttribute] // RVA: 0x54DCCC Offset: 0x54DCCC VA: 0x54DCCC
	private bool <HasValue>k__BackingField; // 0xC
	private object value; // 0x10
	public readonly AnchorAlias Alias; // 0x14

	// Properties
	public bool HasValue { get; set; }
	public object Value { get; set; }

	// Methods

	[CompilerGeneratedAttribute] // RVA: 0x54EA6C Offset: 0x54EA6C VA: 0x54EA6C
	// RVA: 0x15ED8E4 Offset: 0x15ED8E4 VA: 0x15ED8E4 Slot: 4
	public void add_ValueAvailable(Action<object> value) { }

	[CompilerGeneratedAttribute] // RVA: 0x54EA7C Offset: 0x54EA7C VA: 0x54EA7C
	// RVA: 0x15ED9F0 Offset: 0x15ED9F0 VA: 0x15ED9F0 Slot: 5
	public void remove_ValueAvailable(Action<object> value) { }

	[CompilerGeneratedAttribute] // RVA: 0x54EA8C Offset: 0x54EA8C VA: 0x54EA8C
	// RVA: 0x15ED44C Offset: 0x15ED44C VA: 0x15ED44C
	public bool get_HasValue() { }

	[CompilerGeneratedAttribute] // RVA: 0x54EA9C Offset: 0x54EA9C VA: 0x54EA9C
	// RVA: 0x15EDAFC Offset: 0x15EDAFC VA: 0x15EDAFC
	private void set_HasValue(bool value) { }

	// RVA: 0x15ED42C Offset: 0x15ED42C VA: 0x15ED42C
	public void .ctor(AnchorAlias alias) { }

	// RVA: 0x15ED504 Offset: 0x15ED504 VA: 0x15ED504
	public void .ctor(object value) { }

	// RVA: 0x15ED454 Offset: 0x15ED454 VA: 0x15ED454
	public object get_Value() { }

	// RVA: 0x15ED52C Offset: 0x15ED52C VA: 0x15ED52C
	public void set_Value(object value) { }
}
