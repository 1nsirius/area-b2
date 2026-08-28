// Namespace: 
[AddComponentMenu] // RVA: 0x551750 Offset: 0x551750 VA: 0x551750
[RequireComponent] // RVA: 0x551750 Offset: 0x551750 VA: 0x551750
[DisallowMultipleComponent] // RVA: 0x551750 Offset: 0x551750 VA: 0x551750
public class AkRoomPortal : AkTriggerHandler // TypeDefIndex: 6079
{
	// Fields
	public const int MAX_ROOMS_PER_PORTAL = 2;
	private AkVector extent; // 0x18
	private AkTransform portalTransform; // 0x1C
	private ulong backRoomID; // 0x20
	public List<int> closePortalTriggerList; // 0x28
	private ulong frontRoomID; // 0x30
	public AkRoom[] rooms; // 0x38

	// Properties
	public bool IsValid { get; }

	// Methods

	// RVA: 0x1BC16C8 Offset: 0x1BC16C8 VA: 0x1BC16C8
	public bool get_IsValid() { }

	// RVA: 0x1BC16E4 Offset: 0x1BC16E4 VA: 0x1BC16E4
	public ulong GetID() { }

	// RVA: 0x1BC16FC Offset: 0x1BC16FC VA: 0x1BC16FC Slot: 5
	protected override void Awake() { }

	// RVA: 0x1BC1EB0 Offset: 0x1BC1EB0 VA: 0x1BC1EB0 Slot: 6
	protected override void Start() { }

	// RVA: 0x1BC1F50 Offset: 0x1BC1F50 VA: 0x1BC1F50 Slot: 4
	public override void HandleEvent(GameObject in_gameObject) { }

	// RVA: 0x1BC1EA8 Offset: 0x1BC1EA8 VA: 0x1BC1EA8
	public void ClosePortal(GameObject in_gameObject) { }

	// RVA: 0x1BC1F68 Offset: 0x1BC1F68 VA: 0x1BC1F68 Slot: 7
	protected override void OnDestroy() { }

	// RVA: 0x1BC1F58 Offset: 0x1BC1F58 VA: 0x1BC1F58
	public void Open() { }

	// RVA: 0x1BC1F60 Offset: 0x1BC1F60 VA: 0x1BC1F60
	public void Close() { }

	// RVA: 0x1BC2058 Offset: 0x1BC2058 VA: 0x1BC2058
	private void ActivatePortal(bool active) { }

	// RVA: 0x1BC21DC Offset: 0x1BC21DC VA: 0x1BC21DC
	public void FindOverlappingRooms(AkRoom.PriorityList[] roomList) { }

	// RVA: 0x1BC2528 Offset: 0x1BC2528 VA: 0x1BC2528
	private void FillRoomList(Vector3 center, Vector3 halfExtents, AkRoom.PriorityList list) { }

	// RVA: 0x1BC27A0 Offset: 0x1BC27A0 VA: 0x1BC27A0
	public void SetFrontRoom(AkRoom room) { }

	// RVA: 0x1BC2964 Offset: 0x1BC2964 VA: 0x1BC2964
	public void SetBackRoom(AkRoom room) { }

	// RVA: 0x1BC2B28 Offset: 0x1BC2B28 VA: 0x1BC2B28
	public void UpdateOverlappingRooms() { }

	// RVA: 0x1BC2FD0 Offset: 0x1BC2FD0 VA: 0x1BC2FD0
	public void .ctor() { }
}
