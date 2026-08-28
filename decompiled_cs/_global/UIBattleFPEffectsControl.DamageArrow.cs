// Namespace: 
public class UIBattleFPEffectsControl.DamageArrow // TypeDefIndex: 5762
{
	// Fields
	[CompilerGeneratedAttribute] // RVA: 0x56D4D4 Offset: 0x56D4D4 VA: 0x56D4D4
	private float <elapsedTime>k__BackingField; // 0x8
	[CompilerGeneratedAttribute] // RVA: 0x56D4E4 Offset: 0x56D4E4 VA: 0x56D4E4
	private GameObject <arrowGo>k__BackingField; // 0xC
	[CompilerGeneratedAttribute] // RVA: 0x56D4F4 Offset: 0x56D4F4 VA: 0x56D4F4
	private Animator <animator>k__BackingField; // 0x10
	[CompilerGeneratedAttribute] // RVA: 0x56D504 Offset: 0x56D504 VA: 0x56D504
	private bool <active>k__BackingField; // 0x14
	[CompilerGeneratedAttribute] // RVA: 0x56D514 Offset: 0x56D514 VA: 0x56D514
	private Transform <tran>k__BackingField; // 0x18
	[CompilerGeneratedAttribute] // RVA: 0x56D524 Offset: 0x56D524 VA: 0x56D524
	private BattleSceneRoot.IVictimInfo <pTranData>k__BackingField; // 0x1C
	[CompilerGeneratedAttribute] // RVA: 0x56D534 Offset: 0x56D534 VA: 0x56D534
	private Vector3 <damagePoss>k__BackingField; // 0x20
	private int _arrowType; // 0x2C

	// Properties
	public float elapsedTime { get; set; }
	public GameObject arrowGo { get; set; }
	public Animator animator { get; set; }
	public bool active { get; set; }
	public Transform tran { get; set; }
	public BattleSceneRoot.IVictimInfo pTranData { get; set; }
	public Vector3 damagePoss { get; set; }
	public int arrowType { get; }

	// Methods

	[CompilerGeneratedAttribute] // RVA: 0x653140 Offset: 0x653140 VA: 0x653140
	// RVA: 0xB39A2C Offset: 0xB39A2C VA: 0xB39A2C
	private void set_elapsedTime(float value) { }

	[CompilerGeneratedAttribute] // RVA: 0x653150 Offset: 0x653150 VA: 0x653150
	// RVA: 0xB39A34 Offset: 0xB39A34 VA: 0xB39A34
	public float get_elapsedTime() { }

	[CompilerGeneratedAttribute] // RVA: 0x653160 Offset: 0x653160 VA: 0x653160
	// RVA: 0xB39A3C Offset: 0xB39A3C VA: 0xB39A3C
	private void set_arrowGo(GameObject value) { }

	[CompilerGeneratedAttribute] // RVA: 0x653170 Offset: 0x653170 VA: 0x653170
	// RVA: 0xB39A44 Offset: 0xB39A44 VA: 0xB39A44
	public GameObject get_arrowGo() { }

	[CompilerGeneratedAttribute] // RVA: 0x653180 Offset: 0x653180 VA: 0x653180
	// RVA: 0xB39A4C Offset: 0xB39A4C VA: 0xB39A4C
	private void set_animator(Animator value) { }

	[CompilerGeneratedAttribute] // RVA: 0x653190 Offset: 0x653190 VA: 0x653190
	// RVA: 0xB39A54 Offset: 0xB39A54 VA: 0xB39A54
	public Animator get_animator() { }

	[CompilerGeneratedAttribute] // RVA: 0x6531A0 Offset: 0x6531A0 VA: 0x6531A0
	// RVA: 0xB39A5C Offset: 0xB39A5C VA: 0xB39A5C
	private void set_active(bool value) { }

	[CompilerGeneratedAttribute] // RVA: 0x6531B0 Offset: 0x6531B0 VA: 0x6531B0
	// RVA: 0xB39620 Offset: 0xB39620 VA: 0xB39620
	public bool get_active() { }

	[CompilerGeneratedAttribute] // RVA: 0x6531C0 Offset: 0x6531C0 VA: 0x6531C0
	// RVA: 0xB39A64 Offset: 0xB39A64 VA: 0xB39A64
	private void set_tran(Transform value) { }

	[CompilerGeneratedAttribute] // RVA: 0x6531D0 Offset: 0x6531D0 VA: 0x6531D0
	// RVA: 0xB39A6C Offset: 0xB39A6C VA: 0xB39A6C
	public Transform get_tran() { }

	[CompilerGeneratedAttribute] // RVA: 0x6531E0 Offset: 0x6531E0 VA: 0x6531E0
	// RVA: 0xB377CC Offset: 0xB377CC VA: 0xB377CC
	public void set_pTranData(BattleSceneRoot.IVictimInfo value) { }

	[CompilerGeneratedAttribute] // RVA: 0x6531F0 Offset: 0x6531F0 VA: 0x6531F0
	// RVA: 0xB39A74 Offset: 0xB39A74 VA: 0xB39A74
	public BattleSceneRoot.IVictimInfo get_pTranData() { }

	[CompilerGeneratedAttribute] // RVA: 0x653200 Offset: 0x653200 VA: 0x653200
	// RVA: 0xB377D4 Offset: 0xB377D4 VA: 0xB377D4
	public void set_damagePoss(Vector3 value) { }

	[CompilerGeneratedAttribute] // RVA: 0x653210 Offset: 0x653210 VA: 0x653210
	// RVA: 0xB372C4 Offset: 0xB372C4 VA: 0xB372C4
	public Vector3 get_damagePoss() { }

	// RVA: 0xB372BC Offset: 0xB372BC VA: 0xB372BC
	public int get_arrowType() { }

	// RVA: 0xB38438 Offset: 0xB38438 VA: 0xB38438
	public void .ctor(GameObject arrow, int arrowType = 0) { }

	// RVA: 0xB3848C Offset: 0xB3848C VA: 0xB3848C
	public void Active(bool active) { }

	// RVA: 0xB39450 Offset: 0xB39450 VA: 0xB39450
	public void Tick(float deltaTime) { }

	// RVA: 0xB37884 Offset: 0xB37884 VA: 0xB37884
	public void ResetElapsedTime() { }

	// RVA: 0xB39A7C Offset: 0xB39A7C VA: 0xB39A7C
	public void UpdateTran() { }

	// RVA: 0xB39930 Offset: 0xB39930 VA: 0xB39930
	public void OnDestroy() { }
}
