// Namespace: 
public class UIBattleScanCharacterTooltipCtrl.TraceCharacterTooltip : UIBattleScanCharacterTooltipCtrl.ICharacterTooltip // TypeDefIndex: 5798
{
	// Fields
	[CompilerGeneratedAttribute] // RVA: 0x56D634 Offset: 0x56D634 VA: 0x56D634
	private GameObject <tooltipGo>k__BackingField; // 0x8
	private RectTransform _tran; // 0xC
	public Image flagImg; // 0x10
	public Text distText; // 0x14
	public Text placeText; // 0x18
	[CompilerGeneratedAttribute] // RVA: 0x56D644 Offset: 0x56D644 VA: 0x56D644
	private float <CurTime>k__BackingField; // 0x1C
	private float _curDist; // 0x20
	[CompilerGeneratedAttribute] // RVA: 0x56D654 Offset: 0x56D654 VA: 0x56D654
	private Vector3 <characterWorldPos>k__BackingField; // 0x24
	[CompilerGeneratedAttribute] // RVA: 0x56D664 Offset: 0x56D664 VA: 0x56D664
	private byte <CharacterBID>k__BackingField; // 0x30
	private Func<byte, Vector3> _getCharacterFunc; // 0x34

	// Properties
	public GameObject tooltipGo { get; set; }
	public float CurTime { get; set; }
	public Vector3 characterWorldPos { get; set; }
	public byte CharacterBID { get; set; }

	// Methods

	[CompilerGeneratedAttribute] // RVA: 0x653410 Offset: 0x653410 VA: 0x653410
	// RVA: 0xAE9BB8 Offset: 0xAE9BB8 VA: 0xAE9BB8
	private void set_tooltipGo(GameObject value) { }

	[CompilerGeneratedAttribute] // RVA: 0x653420 Offset: 0x653420 VA: 0x653420
	// RVA: 0xAE9BC0 Offset: 0xAE9BC0 VA: 0xAE9BC0
	public GameObject get_tooltipGo() { }

	[CompilerGeneratedAttribute] // RVA: 0x653430 Offset: 0x653430 VA: 0x653430
	// RVA: 0xAE9BC8 Offset: 0xAE9BC8 VA: 0xAE9BC8
	private void set_CurTime(float value) { }

	[CompilerGeneratedAttribute] // RVA: 0x653440 Offset: 0x653440 VA: 0x653440
	// RVA: 0xAE9BD0 Offset: 0xAE9BD0 VA: 0xAE9BD0
	public float get_CurTime() { }

	[CompilerGeneratedAttribute] // RVA: 0x653450 Offset: 0x653450 VA: 0x653450
	// RVA: 0xAE9BD8 Offset: 0xAE9BD8 VA: 0xAE9BD8
	private void set_characterWorldPos(Vector3 value) { }

	[CompilerGeneratedAttribute] // RVA: 0x653460 Offset: 0x653460 VA: 0x653460
	// RVA: 0xAE9BE4 Offset: 0xAE9BE4 VA: 0xAE9BE4
	public Vector3 get_characterWorldPos() { }

	[CompilerGeneratedAttribute] // RVA: 0x653470 Offset: 0x653470 VA: 0x653470
	// RVA: 0xAE9BF8 Offset: 0xAE9BF8 VA: 0xAE9BF8
	private void set_CharacterBID(byte value) { }

	[CompilerGeneratedAttribute] // RVA: 0x653480 Offset: 0x653480 VA: 0x653480
	// RVA: 0xAE9C00 Offset: 0xAE9C00 VA: 0xAE9C00 Slot: 4
	public byte get_CharacterBID() { }

	// RVA: 0xAE84F4 Offset: 0xAE84F4 VA: 0xAE84F4
	public void .ctor(GameObject go) { }

	// RVA: 0xAE9C08 Offset: 0xAE9C08 VA: 0xAE9C08 Slot: 5
	public bool Tick(float deltaTime) { }

	// RVA: 0xAE7E18 Offset: 0xAE7E18 VA: 0xAE7E18
	public void Init(RspTrackerReport.Data data, Func<byte, Vector3> getCharacterFunc) { }

	// RVA: 0xAE7FC0 Offset: 0xAE7FC0 VA: 0xAE7FC0
	public void Refresh(RspTrackerReport.Data data) { }

	// RVA: 0xAEA0FC Offset: 0xAEA0FC VA: 0xAEA0FC
	private void ParserData(RspTrackerReport.Data data) { }

	// RVA: 0xAEA1A8 Offset: 0xAEA1A8 VA: 0xAEA1A8
	private void SetMapLocation(Vector3 pos) { }

	// RVA: 0xAE9FF8 Offset: 0xAE9FF8 VA: 0xAE9FF8
	private void RefreshDistText() { }

	// RVA: 0xAEA2A8 Offset: 0xAEA2A8 VA: 0xAEA2A8 Slot: 6
	public void Destroy() { }

	// RVA: 0xAE6DFC Offset: 0xAE6DFC VA: 0xAE6DFC Slot: 7
	public void Reset() { }
}
