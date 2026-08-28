// Namespace: 
public struct Character.HealthPoint : IComparable<Character.HealthPoint>, IComparable, IEquatable<Character.HealthPoint> // TypeDefIndex: 13250
{
	// Fields
	public static readonly Character.HealthPoint Zero; // 0x0
	public readonly XorInt BaseHP; // 0x0
	public readonly XorInt ExtraHP; // 0x8

	// Methods

	// RVA: 0x744FA4 Offset: 0x744FA4 VA: 0x744FA4
	public void .ctor(ushort baseHP, ushort extraHP = 0) { }

	// RVA: 0x96B1DC Offset: 0x96B1DC VA: 0x96B1DC
	public static Character.HealthPoint op_Implicit(CharacterHP characterHP) { }

	// RVA: 0x744FAC Offset: 0x744FAC VA: 0x744FAC Slot: 6
	public bool Equals(Character.HealthPoint other) { }

	// RVA: 0x744FD0 Offset: 0x744FD0 VA: 0x744FD0 Slot: 0
	public override bool Equals(object obj) { }

	// RVA: 0x744FD8 Offset: 0x744FD8 VA: 0x744FD8 Slot: 2
	public override int GetHashCode() { }

	// RVA: 0x96B454 Offset: 0x96B454 VA: 0x96B454
	public static bool op_Equality(Character.HealthPoint left, Character.HealthPoint right) { }

	// RVA: 0x96B4A0 Offset: 0x96B4A0 VA: 0x96B4A0
	public static bool op_Inequality(Character.HealthPoint left, Character.HealthPoint right) { }

	// RVA: 0x744FE0 Offset: 0x744FE0 VA: 0x744FE0 Slot: 5
	public int CompareTo(object obj) { }

	// RVA: 0x96B6E8 Offset: 0x96B6E8 VA: 0x96B6E8
	public static bool op_LessThan(Character.HealthPoint left, Character.HealthPoint right) { }

	// RVA: 0x96B738 Offset: 0x96B738 VA: 0x96B738
	public static bool op_GreaterThan(Character.HealthPoint left, Character.HealthPoint right) { }

	// RVA: 0x96B794 Offset: 0x96B794 VA: 0x96B794
	public static bool op_LessThanOrEqual(Character.HealthPoint left, Character.HealthPoint right) { }

	// RVA: 0x96B7F0 Offset: 0x96B7F0 VA: 0x96B7F0
	public static bool op_GreaterThanOrEqual(Character.HealthPoint left, Character.HealthPoint right) { }

	// RVA: 0x744FE8 Offset: 0x744FE8 VA: 0x744FE8 Slot: 4
	public int CompareTo(Character.HealthPoint other) { }

	// RVA: 0x96B84C Offset: 0x96B84C VA: 0x96B84C
	private static void .cctor() { }
}
