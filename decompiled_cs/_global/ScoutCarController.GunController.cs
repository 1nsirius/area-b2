// Namespace: 
private class ScoutCarController.GunController // TypeDefIndex: 11974
{
	// Fields
	private readonly ScoutCarController _carCtrlr; // 0x8
	private readonly List<ScanUtils.Result> _targets; // 0xC
	private AimUtil.TargetType _aimTargetType; // 0x10
	private int _lastTargetsCount; // 0x14
	private ScoutCarController.GunController.AimState _state; // 0x18
	private ScoutCarController.GunController.FireDataS fireData; // 0x1C
	[CompilerGeneratedAttribute] // RVA: 0x573CC0 Offset: 0x573CC0 VA: 0x573CC0
	private readonly Gun <gun>k__BackingField; // 0x38

	// Properties
	private Gun gun { get; }
	private IScoutCar ScoutCar { get; }
	private Vector3 BulletLineStart { get; }
	private Vector3 FireStartPosition { get; }
	private float FireDistance { get; }
	private ScoutCarController.GunController.AimState state { get; set; }

	// Methods

	// RVA: 0xB67D7C Offset: 0xB67D7C VA: 0xB67D7C
	public void .ctor(ScoutCarController carCtrlr, Gun gun) { }

	[CompilerGeneratedAttribute] // RVA: 0x667C00 Offset: 0x667C00 VA: 0x667C00
	// RVA: 0xB6AB4C Offset: 0xB6AB4C VA: 0xB6AB4C
	private Gun get_gun() { }

	// RVA: 0xB6AB54 Offset: 0xB6AB54 VA: 0xB6AB54
	private IScoutCar get_ScoutCar() { }

	// RVA: 0xB6AB80 Offset: 0xB6AB80 VA: 0xB6AB80
	private Vector3 get_BulletLineStart() { }

	// RVA: 0xB6AC68 Offset: 0xB6AC68 VA: 0xB6AC68
	private Vector3 get_FireStartPosition() { }

	// RVA: 0xB6AD50 Offset: 0xB6AD50 VA: 0xB6AD50
	private float get_FireDistance() { }

	// RVA: 0xB6AE64 Offset: 0xB6AE64 VA: 0xB6AE64
	private ScoutCarController.GunController.AimState get_state() { }

	// RVA: 0xB6AE6C Offset: 0xB6AE6C VA: 0xB6AE6C
	private void set_state(ScoutCarController.GunController.AimState value) { }

	// RVA: 0xB6B000 Offset: 0xB6B000 VA: 0xB6B000
	private void ClearTargets() { }

	// RVA: 0xB6B080 Offset: 0xB6B080 VA: 0xB6B080
	private void SetAimPoint(ScoutCarController.GunController.Language language, AimUtil.TargetType targetType, string[] paramList) { }

	// RVA: 0xB6B0B8 Offset: 0xB6B0B8 VA: 0xB6B0B8
	private void SetAimPoint(ScoutCarController.GunController.Language language, Nullable<Color> textColor, AimUtil.TargetType targetType, string[] paramList) { }

	// RVA: 0xB6B320 Offset: 0xB6B320 VA: 0xB6B320
	private void UpdateScatterDegree() { }

	// RVA: 0xB6B4B0 Offset: 0xB6B4B0 VA: 0xB6B4B0
	private void UpdateRecoilDegree() { }

	// RVA: 0xB698C0 Offset: 0xB698C0 VA: 0xB698C0
	public bool CounteractPan(float view_delta_y) { }

	// RVA: 0xB6B880 Offset: 0xB6B880 VA: 0xB6B880
	private void DoFire() { }

	// RVA: 0xB690B4 Offset: 0xB690B4 VA: 0xB690B4
	public void Update() { }

	// RVA: 0xB6C130 Offset: 0xB6C130 VA: 0xB6C130
	private void CheckTargets() { }

	// RVA: 0xB68BCC Offset: 0xB68BCC VA: 0xB68BCC
	public void OnActorUpdate() { }

	// RVA: 0xB68570 Offset: 0xB68570 VA: 0xB68570
	public void Active() { }

	// RVA: 0xB6C570 Offset: 0xB6C570 VA: 0xB6C570
	private void UpdateBulletState() { }

	// RVA: 0xB68040 Offset: 0xB68040 VA: 0xB68040
	public void OperatorMode() { }

	// RVA: 0xB6C6F0 Offset: 0xB6C6F0 VA: 0xB6C6F0
	private void ClearText() { }

	// RVA: 0xB6803C Offset: 0xB6803C VA: 0xB6803C
	public void DelegateMode() { }

	// RVA: 0xB69CE4 Offset: 0xB69CE4 VA: 0xB69CE4
	public void Deactivate() { }

	[CompilerGeneratedAttribute] // RVA: 0x667C10 Offset: 0x667C10 VA: 0x667C10
	// RVA: 0xB6C72C Offset: 0xB6C72C VA: 0xB6C72C
	private bool <CheckTargets>b__29_0(ScanUtils.Result result) { }

	[CompilerGeneratedAttribute] // RVA: 0x667C20 Offset: 0x667C20 VA: 0x667C20
	// RVA: 0xB6C860 Offset: 0xB6C860 VA: 0xB6C860
	private List<ScanUtils.Result> <Active>b__31_0() { }
}
