// Namespace: 
[AddComponentMenu] // RVA: 0x551698 Offset: 0x551698 VA: 0x551698
[RequireComponent] // RVA: 0x551698 Offset: 0x551698 VA: 0x551698
[DisallowMultipleComponent] // RVA: 0x551698 Offset: 0x551698 VA: 0x551698
public class AkRoom : AkTriggerHandler // TypeDefIndex: 6076
{
	// Fields
	public static ulong INVALID_ROOM_ID; // 0x0
	private static int RoomCount; // 0x8
	[TooltipAttribute] // RVA: 0x55FEF0 Offset: 0x55FEF0 VA: 0x55FEF0
	public int priority; // 0x18
	public AuxBus reverbAuxBus; // 0x1C
	[RangeAttribute] // RVA: 0x55FF40 Offset: 0x55FF40 VA: 0x55FF40
	public float reverbLevel; // 0x20
	[RangeAttribute] // RVA: 0x55FF58 Offset: 0x55FF58 VA: 0x55FF58
	public float wallOcclusion; // 0x24
	public Event roomToneEvent; // 0x28
	[RangeAttribute] // RVA: 0x55FF70 Offset: 0x55FF70 VA: 0x55FF70
	[TooltipAttribute] // RVA: 0x55FF70 Offset: 0x55FF70 VA: 0x55FF70
	public float roomToneAuxSend; // 0x2C

	// Properties
	public static bool IsSpatialAudioEnabled { get; }

	// Methods

	// RVA: 0x1BBFA04 Offset: 0x1BBFA04 VA: 0x1BBFA04
	public static bool get_IsSpatialAudioEnabled() { }

	// RVA: 0x1BBFB20 Offset: 0x1BBFB20 VA: 0x1BBFB20
	public ulong GetID() { }

	// RVA: 0x1BBFBB4 Offset: 0x1BBFBB4 VA: 0x1BBFBB4
	private void OnEnable() { }

	// RVA: 0x1BC0588 Offset: 0x1BC0588 VA: 0x1BC0588 Slot: 6
	protected override void Start() { }

	// RVA: 0x1BC0590 Offset: 0x1BC0590 VA: 0x1BC0590 Slot: 4
	public override void HandleEvent(GameObject in_gameObject) { }

	// RVA: 0x1BC05CC Offset: 0x1BC05CC VA: 0x1BC05CC
	private void OnDisable() { }

	// RVA: 0x1BC06B0 Offset: 0x1BC06B0 VA: 0x1BC06B0
	private void OnTriggerEnter(Collider in_other) { }

	// RVA: 0x1BC07D8 Offset: 0x1BC07D8 VA: 0x1BC07D8
	private void OnTriggerExit(Collider in_other) { }

	// RVA: 0x1BC0900 Offset: 0x1BC0900 VA: 0x1BC0900
	public void .ctor() { }

	// RVA: 0x1BC09D8 Offset: 0x1BC09D8 VA: 0x1BC09D8
	private static void .cctor() { }
}
