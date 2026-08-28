// Namespace: 
[AddComponentMenu] // RVA: 0x551B14 Offset: 0x551B14 VA: 0x551B14
public class AkState : AkDragDropTriggerHandler // TypeDefIndex: 6089
{
	// Fields
	public State data; // 0x18
	[HideInInspector] // RVA: 0x5602F8 Offset: 0x5602F8 VA: 0x5602F8
	[SerializeField] // RVA: 0x5602F8 Offset: 0x5602F8 VA: 0x5602F8
	[FormerlySerializedAsAttribute] // RVA: 0x5602F8 Offset: 0x5602F8 VA: 0x5602F8
	private int valueIdInternal; // 0x1C
	[HideInInspector] // RVA: 0x560350 Offset: 0x560350 VA: 0x560350
	[SerializeField] // RVA: 0x560350 Offset: 0x560350 VA: 0x560350
	[FormerlySerializedAsAttribute] // RVA: 0x560350 Offset: 0x560350 VA: 0x560350
	private int groupIdInternal; // 0x20
	[HideInInspector] // RVA: 0x5603A8 Offset: 0x5603A8 VA: 0x5603A8
	[SerializeField] // RVA: 0x5603A8 Offset: 0x5603A8 VA: 0x5603A8
	[FormerlySerializedAsAttribute] // RVA: 0x5603A8 Offset: 0x5603A8 VA: 0x5603A8
	private byte[] valueGuidInternal; // 0x24
	[HideInInspector] // RVA: 0x560400 Offset: 0x560400 VA: 0x560400
	[SerializeField] // RVA: 0x560400 Offset: 0x560400 VA: 0x560400
	[FormerlySerializedAsAttribute] // RVA: 0x560400 Offset: 0x560400 VA: 0x560400
	private byte[] groupGuidInternal; // 0x28

	// Properties
	protected override BaseType WwiseType { get; }
	[ObsoleteAttribute] // RVA: 0x66DF5C Offset: 0x66DF5C VA: 0x66DF5C
	public int valueID { get; }
	[ObsoleteAttribute] // RVA: 0x66DF90 Offset: 0x66DF90 VA: 0x66DF90
	public int groupID { get; }
	[ObsoleteAttribute] // RVA: 0x66DFC4 Offset: 0x66DFC4 VA: 0x66DFC4
	public byte[] valueGuid { get; }
	[ObsoleteAttribute] // RVA: 0x66DFF8 Offset: 0x66DFF8 VA: 0x66DFF8
	public byte[] groupGuid { get; }

	// Methods

	// RVA: 0xCA407C Offset: 0xCA407C VA: 0xCA407C Slot: 8
	protected override BaseType get_WwiseType() { }

	// RVA: 0xCA4084 Offset: 0xCA4084 VA: 0xCA4084 Slot: 4
	public override void HandleEvent(GameObject in_gameObject) { }

	// RVA: 0xCA40B0 Offset: 0xCA40B0 VA: 0xCA40B0
	public int get_valueID() { }

	// RVA: 0xCA40C8 Offset: 0xCA40C8 VA: 0xCA40C8
	public int get_groupID() { }

	// RVA: 0xCA40E0 Offset: 0xCA40E0 VA: 0xCA40E0
	public byte[] get_valueGuid() { }

	// RVA: 0xCA41EC Offset: 0xCA41EC VA: 0xCA41EC
	public byte[] get_groupGuid() { }

	// RVA: 0xCA42E8 Offset: 0xCA42E8 VA: 0xCA42E8
	public void .ctor() { }
}
