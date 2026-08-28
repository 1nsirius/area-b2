// Namespace: 
[AddComponentMenu] // RVA: 0x551C24 Offset: 0x551C24 VA: 0x551C24
public class AkSwitch : AkDragDropTriggerHandler // TypeDefIndex: 6091
{
	// Fields
	public Switch data; // 0x18
	[HideInInspector] // RVA: 0x560550 Offset: 0x560550 VA: 0x560550
	[SerializeField] // RVA: 0x560550 Offset: 0x560550 VA: 0x560550
	[FormerlySerializedAsAttribute] // RVA: 0x560550 Offset: 0x560550 VA: 0x560550
	private int valueIdInternal; // 0x1C
	[HideInInspector] // RVA: 0x5605A8 Offset: 0x5605A8 VA: 0x5605A8
	[SerializeField] // RVA: 0x5605A8 Offset: 0x5605A8 VA: 0x5605A8
	[FormerlySerializedAsAttribute] // RVA: 0x5605A8 Offset: 0x5605A8 VA: 0x5605A8
	private int groupIdInternal; // 0x20
	[HideInInspector] // RVA: 0x560600 Offset: 0x560600 VA: 0x560600
	[SerializeField] // RVA: 0x560600 Offset: 0x560600 VA: 0x560600
	[FormerlySerializedAsAttribute] // RVA: 0x560600 Offset: 0x560600 VA: 0x560600
	private byte[] valueGuidInternal; // 0x24
	[HideInInspector] // RVA: 0x560658 Offset: 0x560658 VA: 0x560658
	[SerializeField] // RVA: 0x560658 Offset: 0x560658 VA: 0x560658
	[FormerlySerializedAsAttribute] // RVA: 0x560658 Offset: 0x560658 VA: 0x560658
	private byte[] groupGuidInternal; // 0x28

	// Properties
	protected override BaseType WwiseType { get; }
	[ObsoleteAttribute] // RVA: 0x66E02C Offset: 0x66E02C VA: 0x66E02C
	public int valueID { get; }
	[ObsoleteAttribute] // RVA: 0x66E060 Offset: 0x66E060 VA: 0x66E060
	public int groupID { get; }
	[ObsoleteAttribute] // RVA: 0x66E094 Offset: 0x66E094 VA: 0x66E094
	public byte[] valueGuid { get; }
	[ObsoleteAttribute] // RVA: 0x66E0C8 Offset: 0x66E0C8 VA: 0x66E0C8
	public byte[] groupGuid { get; }

	// Methods

	// RVA: 0xCA5F84 Offset: 0xCA5F84 VA: 0xCA5F84 Slot: 8
	protected override BaseType get_WwiseType() { }

	// RVA: 0xCA5F8C Offset: 0xCA5F8C VA: 0xCA5F8C Slot: 4
	public override void HandleEvent(GameObject in_gameObject) { }

	// RVA: 0xCA6060 Offset: 0xCA6060 VA: 0xCA6060
	public int get_valueID() { }

	// RVA: 0xCA6078 Offset: 0xCA6078 VA: 0xCA6078
	public int get_groupID() { }

	// RVA: 0xCA6090 Offset: 0xCA6090 VA: 0xCA6090
	public byte[] get_valueGuid() { }

	// RVA: 0xCA619C Offset: 0xCA619C VA: 0xCA619C
	public byte[] get_groupGuid() { }

	// RVA: 0xCA6298 Offset: 0xCA6298 VA: 0xCA6298
	public void .ctor() { }
}
