// Namespace: 
[AddComponentMenu] // RVA: 0x5512D4 Offset: 0x5512D4 VA: 0x5512D4
[RequireComponent] // RVA: 0x5512D4 Offset: 0x5512D4 VA: 0x5512D4
[ExecuteInEditMode] // RVA: 0x5512D4 Offset: 0x5512D4 VA: 0x5512D4
public class AkEnvironment : MonoBehaviour // TypeDefIndex: 6052
{
	// Fields
	public const int MAX_NB_ENVIRONMENTS = 4;
	public static AkEnvironment.AkEnvironment_CompareByPriority s_compareByPriority; // 0x0
	public static AkEnvironment.AkEnvironment_CompareBySelectionAlgorithm s_compareBySelectionAlgorithm; // 0x4
	public bool excludeOthers; // 0xC
	public bool isDefault; // 0xD
	public AuxBus data; // 0x10
	[CompilerGeneratedAttribute] // RVA: 0x55FB34 Offset: 0x55FB34 VA: 0x55FB34
	private Collider <Collider>k__BackingField; // 0x14
	public int priority; // 0x18
	[HideInInspector] // RVA: 0x55FB44 Offset: 0x55FB44 VA: 0x55FB44
	[SerializeField] // RVA: 0x55FB44 Offset: 0x55FB44 VA: 0x55FB44
	[FormerlySerializedAsAttribute] // RVA: 0x55FB44 Offset: 0x55FB44 VA: 0x55FB44
	private int auxBusIdInternal; // 0x1C
	[HideInInspector] // RVA: 0x55FBA0 Offset: 0x55FBA0 VA: 0x55FBA0
	[SerializeField] // RVA: 0x55FBA0 Offset: 0x55FBA0 VA: 0x55FBA0
	[FormerlySerializedAsAttribute] // RVA: 0x55FBA0 Offset: 0x55FBA0 VA: 0x55FBA0
	private byte[] valueGuidInternal; // 0x20

	// Properties
	public Collider Collider { get; set; }
	[ObsoleteAttribute] // RVA: 0x66DE58 Offset: 0x66DE58 VA: 0x66DE58
	public int m_auxBusID { get; }
	[ObsoleteAttribute] // RVA: 0x66DE8C Offset: 0x66DE8C VA: 0x66DE8C
	public byte[] valueGuid { get; }

	// Methods

	[CompilerGeneratedAttribute] // RVA: 0x57B364 Offset: 0x57B364 VA: 0x57B364
	// RVA: 0xFEAFB0 Offset: 0xFEAFB0 VA: 0xFEAFB0
	public Collider get_Collider() { }

	[CompilerGeneratedAttribute] // RVA: 0x57B374 Offset: 0x57B374 VA: 0x57B374
	// RVA: 0xFEAFB8 Offset: 0xFEAFB8 VA: 0xFEAFB8
	private void set_Collider(Collider value) { }

	// RVA: 0xFEAFC0 Offset: 0xFEAFC0 VA: 0xFEAFC0
	public float GetAuxSendValueForPosition(Vector3 in_position) { }

	// RVA: 0xFEAFC8 Offset: 0xFEAFC8 VA: 0xFEAFC8
	public void Awake() { }

	// RVA: 0xFEB030 Offset: 0xFEB030 VA: 0xFEB030
	public int get_m_auxBusID() { }

	// RVA: 0xFEB044 Offset: 0xFEB044 VA: 0xFEB044
	public byte[] get_valueGuid() { }

	[ObsoleteAttribute] // RVA: 0x57B384 Offset: 0x57B384 VA: 0x57B384
	// RVA: 0xFEB150 Offset: 0xFEB150 VA: 0xFEB150
	public uint GetAuxBusID() { }

	[ObsoleteAttribute] // RVA: 0x57B3B8 Offset: 0x57B3B8 VA: 0x57B3B8
	// RVA: 0xFEB178 Offset: 0xFEB178 VA: 0xFEB178
	public Collider GetCollider() { }

	// RVA: 0xFEB180 Offset: 0xFEB180 VA: 0xFEB180
	public void .ctor() { }

	// RVA: 0xFEB1FC Offset: 0xFEB1FC VA: 0xFEB1FC
	private static void .cctor() { }
}
