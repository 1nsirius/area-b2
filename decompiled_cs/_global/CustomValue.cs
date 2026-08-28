// Namespace: 
public struct CustomValue : IEquatable<CustomValue> // TypeDefIndex: 5628
{
	// Fields
	public static CustomValue Default; // 0x0
	[CompilerGeneratedAttribute] // RVA: 0x55E104 Offset: 0x55E104 VA: 0x55E104
	private float <Alpha>k__BackingField; // 0x0
	[CompilerGeneratedAttribute] // RVA: 0x55E114 Offset: 0x55E114 VA: 0x55E114
	private float <Scale>k__BackingField; // 0x4
	[CompilerGeneratedAttribute] // RVA: 0x55E124 Offset: 0x55E124 VA: 0x55E124
	private F2Vector2 <Pos>k__BackingField; // 0x8

	// Properties
	public float Alpha { get; set; }
	public float Scale { get; set; }
	public F2Vector2 Pos { get; set; }

	// Methods

	[CompilerGeneratedAttribute] // RVA: 0x57A6BC Offset: 0x57A6BC VA: 0x57A6BC
	// RVA: 0x7480BC Offset: 0x7480BC VA: 0x7480BC
	public float get_Alpha() { }

	[CompilerGeneratedAttribute] // RVA: 0x57A6CC Offset: 0x57A6CC VA: 0x57A6CC
	// RVA: 0x7480C4 Offset: 0x7480C4 VA: 0x7480C4
	public void set_Alpha(float value) { }

	[CompilerGeneratedAttribute] // RVA: 0x57A6DC Offset: 0x57A6DC VA: 0x57A6DC
	// RVA: 0x7480CC Offset: 0x7480CC VA: 0x7480CC
	public float get_Scale() { }

	[CompilerGeneratedAttribute] // RVA: 0x57A6EC Offset: 0x57A6EC VA: 0x57A6EC
	// RVA: 0x7480D4 Offset: 0x7480D4 VA: 0x7480D4
	public void set_Scale(float value) { }

	[CompilerGeneratedAttribute] // RVA: 0x57A6FC Offset: 0x57A6FC VA: 0x57A6FC
	// RVA: 0x7480DC Offset: 0x7480DC VA: 0x7480DC
	public F2Vector2 get_Pos() { }

	[CompilerGeneratedAttribute] // RVA: 0x57A70C Offset: 0x57A70C VA: 0x57A70C
	// RVA: 0x7480F0 Offset: 0x7480F0 VA: 0x7480F0
	public void set_Pos(F2Vector2 value) { }

	// RVA: 0x7480FC Offset: 0x7480FC VA: 0x7480FC Slot: 4
	public bool Equals(CustomValue other) { }

	// RVA: 0x748120 Offset: 0x748120 VA: 0x748120 Slot: 0
	public override bool Equals(object obj) { }

	// RVA: 0x748128 Offset: 0x748128 VA: 0x748128 Slot: 2
	public override int GetHashCode() { }

	// RVA: 0xD64210 Offset: 0xD64210 VA: 0xD64210
	public static bool op_Equality(CustomValue left, CustomValue right) { }

	// RVA: 0xD6425C Offset: 0xD6425C VA: 0xD6425C
	public static bool op_Inequality(CustomValue left, CustomValue right) { }

	// RVA: 0xD642AC Offset: 0xD642AC VA: 0xD642AC
	private static void .cctor() { }
}
