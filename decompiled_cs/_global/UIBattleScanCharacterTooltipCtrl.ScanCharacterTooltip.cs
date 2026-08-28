// Namespace: 
public class UIBattleScanCharacterTooltipCtrl.ScanCharacterTooltip : UIBattleScanCharacterTooltipCtrl.ICharacterTooltip // TypeDefIndex: 5797
{
	// Fields
	[CompilerGeneratedAttribute] // RVA: 0x56D5F4 Offset: 0x56D5F4 VA: 0x56D5F4
	private GameObject <tooltipGo>k__BackingField; // 0x8
	private RectTransform _tran; // 0xC
	public Text distText; // 0x10
	private ICharacterProxy _characterProxy; // 0x14
	[CompilerGeneratedAttribute] // RVA: 0x56D604 Offset: 0x56D604 VA: 0x56D604
	private float <duration>k__BackingField; // 0x18
	private float _curDist; // 0x1C
	[CompilerGeneratedAttribute] // RVA: 0x56D614 Offset: 0x56D614 VA: 0x56D614
	private Vector3 <characterWorldPos>k__BackingField; // 0x20
	[CompilerGeneratedAttribute] // RVA: 0x56D624 Offset: 0x56D624 VA: 0x56D624
	private byte <CharacterBID>k__BackingField; // 0x2C

	// Properties
	public GameObject tooltipGo { get; set; }
	public float duration { get; set; }
	public Vector3 characterWorldPos { get; set; }
	public byte CharacterBID { get; set; }

	// Methods

	[CompilerGeneratedAttribute] // RVA: 0x653380 Offset: 0x653380 VA: 0x653380
	// RVA: 0xAE92E0 Offset: 0xAE92E0 VA: 0xAE92E0
	private void set_tooltipGo(GameObject value) { }

	[CompilerGeneratedAttribute] // RVA: 0x653390 Offset: 0x653390 VA: 0x653390
	// RVA: 0xAE92E8 Offset: 0xAE92E8 VA: 0xAE92E8
	public GameObject get_tooltipGo() { }

	[CompilerGeneratedAttribute] // RVA: 0x6533A0 Offset: 0x6533A0 VA: 0x6533A0
	// RVA: 0xAE92F0 Offset: 0xAE92F0 VA: 0xAE92F0
	private void set_duration(float value) { }

	[CompilerGeneratedAttribute] // RVA: 0x6533B0 Offset: 0x6533B0 VA: 0x6533B0
	// RVA: 0xAE92F8 Offset: 0xAE92F8 VA: 0xAE92F8
	public float get_duration() { }

	[CompilerGeneratedAttribute] // RVA: 0x6533C0 Offset: 0x6533C0 VA: 0x6533C0
	// RVA: 0xAE9300 Offset: 0xAE9300 VA: 0xAE9300
	private void set_characterWorldPos(Vector3 value) { }

	[CompilerGeneratedAttribute] // RVA: 0x6533D0 Offset: 0x6533D0 VA: 0x6533D0
	// RVA: 0xAE930C Offset: 0xAE930C VA: 0xAE930C
	public Vector3 get_characterWorldPos() { }

	[CompilerGeneratedAttribute] // RVA: 0x6533E0 Offset: 0x6533E0 VA: 0x6533E0
	// RVA: 0xAE9320 Offset: 0xAE9320 VA: 0xAE9320
	private void set_CharacterBID(byte value) { }

	[CompilerGeneratedAttribute] // RVA: 0x6533F0 Offset: 0x6533F0 VA: 0x6533F0
	// RVA: 0xAE9328 Offset: 0xAE9328 VA: 0xAE9328 Slot: 4
	public byte get_CharacterBID() { }

	// RVA: 0xAE83FC Offset: 0xAE83FC VA: 0xAE83FC
	public void .ctor(GameObject go) { }

	// RVA: 0xAE8274 Offset: 0xAE8274 VA: 0xAE8274
	public void Init(ScanEnemyInfo info) { }

	// RVA: 0xAE83DC Offset: 0xAE83DC VA: 0xAE83DC
	public void Refresh(ScanEnemyInfo info) { }

	// RVA: 0xAE9330 Offset: 0xAE9330 VA: 0xAE9330
	private void ParserData(ScanEnemyInfo info) { }

	// RVA: 0xAE94D8 Offset: 0xAE94D8 VA: 0xAE94D8 Slot: 5
	public bool Tick(float deltaTime) { }

	// RVA: 0xAE9964 Offset: 0xAE9964 VA: 0xAE9964
	private void RefreshDistText() { }

	// RVA: 0xAE9A68 Offset: 0xAE9A68 VA: 0xAE9A68 Slot: 6
	public void Destroy() { }

	// RVA: 0xAE6B60 Offset: 0xAE6B60 VA: 0xAE6B60 Slot: 7
	public void Reset() { }

	[CompilerGeneratedAttribute] // RVA: 0x653400 Offset: 0x653400 VA: 0x653400
	// RVA: 0xAE9A6C Offset: 0xAE9A6C VA: 0xAE9A6C
	private bool <ParserData>b__23_0(ICharacterProxy x) { }
}
