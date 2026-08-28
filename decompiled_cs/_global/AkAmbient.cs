// Namespace: 
[AddComponentMenu] // RVA: 0x5510CC Offset: 0x5510CC VA: 0x5510CC
public class AkAmbient : AkEvent // TypeDefIndex: 6046
{
	// Fields
	public static Dictionary<uint, AkMultiPosEvent> multiPosEventTree; // 0x0
	public List<Vector3> multiPositionArray; // 0x4C
	public AkMultiPositionType MultiPositionType; // 0x50
	public MultiPositionTypeLabel multiPositionTypeLabel; // 0x54
	[CompilerGeneratedAttribute] // RVA: 0x55FA60 Offset: 0x55FA60 VA: 0x55FA60
	private AkAmbient <ParentAkAmbience>k__BackingField; // 0x58

	// Properties
	public AkAmbient ParentAkAmbience { get; set; }

	// Methods

	[CompilerGeneratedAttribute] // RVA: 0x57B344 Offset: 0x57B344 VA: 0x57B344
	// RVA: 0xFD4480 Offset: 0xFD4480 VA: 0xFD4480
	public AkAmbient get_ParentAkAmbience() { }

	[CompilerGeneratedAttribute] // RVA: 0x57B354 Offset: 0x57B354 VA: 0x57B354
	// RVA: 0xFD4488 Offset: 0xFD4488 VA: 0xFD4488
	public void set_ParentAkAmbience(AkAmbient value) { }

	// RVA: 0xFD4490 Offset: 0xFD4490 VA: 0xFD4490
	private void OnEnable() { }

	// RVA: 0xFD4F94 Offset: 0xFD4F94 VA: 0xFD4F94
	private void OnDisable() { }

	// RVA: 0xFD525C Offset: 0xFD525C VA: 0xFD525C Slot: 4
	public override void HandleEvent(GameObject in_gameObject) { }

	// RVA: 0xFD5820 Offset: 0xFD5820 VA: 0xFD5820
	public void OnDrawGizmosSelected() { }

	// RVA: 0xFD4CD0 Offset: 0xFD4CD0 VA: 0xFD4CD0
	public AkPositionArray BuildMultiDirectionArray(AkMultiPosEvent eventPosList) { }

	// RVA: 0xFD4A54 Offset: 0xFD4A54 VA: 0xFD4A54
	private AkPositionArray BuildAkPositionArray() { }

	// RVA: 0xFD58CC Offset: 0xFD58CC VA: 0xFD58CC
	public void .ctor() { }

	// RVA: 0xFD5A10 Offset: 0xFD5A10 VA: 0xFD5A10
	private static void .cctor() { }
}
