// Namespace: 
public class UIBattleMiniCarControl.CicleFlag // TypeDefIndex: 5778
{
	// Fields
	public uint miniCarId; // 0x8
	public UIBattleMiniCarControl.CicleFlagEnum flag; // 0xC
	private GameObject _cicleGo; // 0x10
	private RectTransform mTran; // 0x14
	private GameObject _imgFlagGo; // 0x18
	private RectTransform mImgFlagRt; // 0x1C
	private Image _imgFlag; // 0x20
	private GameObject _imgDeadGo; // 0x24
	private RectTransform mImgDeadRt; // 0x28
	private Image _imgDead; // 0x2C
	private GameObject _imgSelectRingGo; // 0x30
	private RectTransform mImgSelectRingRt; // 0x34
	private Image _imgSelectRing; // 0x38
	[CompilerGeneratedAttribute] // RVA: 0x56D5A4 Offset: 0x56D5A4 VA: 0x56D5A4
	private IMiniCarProxy <proxy>k__BackingField; // 0x3C
	[CompilerGeneratedAttribute] // RVA: 0x56D5B4 Offset: 0x56D5B4 VA: 0x56D5B4
	private bool <IsDead>k__BackingField; // 0x40
	[CompilerGeneratedAttribute] // RVA: 0x56D5C4 Offset: 0x56D5C4 VA: 0x56D5C4
	private bool <IsVisiable>k__BackingField; // 0x41

	// Properties
	public IMiniCarProxy proxy { get; set; }
	public XorInt GunBulletNum { get; }
	public XorFloat GunCDTime { get; }
	public bool IsDead { get; set; }
	public bool IsVisiable { get; set; }

	// Methods

	[CompilerGeneratedAttribute] // RVA: 0x6532E0 Offset: 0x6532E0 VA: 0x6532E0
	// RVA: 0xAD90A8 Offset: 0xAD90A8 VA: 0xAD90A8
	private void set_proxy(IMiniCarProxy value) { }

	[CompilerGeneratedAttribute] // RVA: 0x6532F0 Offset: 0x6532F0 VA: 0x6532F0
	// RVA: 0xAD90B0 Offset: 0xAD90B0 VA: 0xAD90B0
	public IMiniCarProxy get_proxy() { }

	// RVA: 0xAD8E98 Offset: 0xAD8E98 VA: 0xAD8E98
	public XorInt get_GunBulletNum() { }

	// RVA: 0xAD8F78 Offset: 0xAD8F78 VA: 0xAD8F78
	public XorFloat get_GunCDTime() { }

	// RVA: 0xAD90B8 Offset: 0xAD90B8 VA: 0xAD90B8
	public void .ctor(IMiniCarProxy proxy, GameObject cicleGo) { }

	[CompilerGeneratedAttribute] // RVA: 0x653300 Offset: 0x653300 VA: 0x653300
	// RVA: 0xAD9154 Offset: 0xAD9154 VA: 0xAD9154
	private void set_IsDead(bool value) { }

	[CompilerGeneratedAttribute] // RVA: 0x653310 Offset: 0x653310 VA: 0x653310
	// RVA: 0xAD915C Offset: 0xAD915C VA: 0xAD915C
	public bool get_IsDead() { }

	[CompilerGeneratedAttribute] // RVA: 0x653320 Offset: 0x653320 VA: 0x653320
	// RVA: 0xAD9164 Offset: 0xAD9164 VA: 0xAD9164
	private void set_IsVisiable(bool value) { }

	[CompilerGeneratedAttribute] // RVA: 0x653330 Offset: 0x653330 VA: 0x653330
	// RVA: 0xAD916C Offset: 0xAD916C VA: 0xAD916C
	public bool get_IsVisiable() { }

	// RVA: 0xAD9174 Offset: 0xAD9174 VA: 0xAD9174
	public void Init() { }

	// RVA: 0xAD94CC Offset: 0xAD94CC VA: 0xAD94CC
	public void Update(UIBattleMiniCarControl.CicleFlagEnum _flag) { }

	// RVA: 0xAD9850 Offset: 0xAD9850 VA: 0xAD9850
	public byte GetOwnerCharacterUid() { }

	// RVA: 0xAD9928 Offset: 0xAD9928 VA: 0xAD9928
	public int GetOwnerCareerId() { }

	// RVA: 0xAD9A00 Offset: 0xAD9A00 VA: 0xAD9A00
	public void Destroy() { }

	// RVA: 0xAD9A18 Offset: 0xAD9A18 VA: 0xAD9A18
	public bool IsCanJump() { }

	// RVA: 0xAD9AF0 Offset: 0xAD9AF0 VA: 0xAD9AF0
	public bool IsAllowJump() { }

	// RVA: 0xAD9BC8 Offset: 0xAD9BC8 VA: 0xAD9BC8
	public bool IsAllowShoot() { }

	// RVA: 0xAD9CA0 Offset: 0xAD9CA0 VA: 0xAD9CA0
	public void SetPosX(float x) { }

	// RVA: 0xAD9D00 Offset: 0xAD9D00 VA: 0xAD9D00
	public bool IsBeInterferenceWithElectromagnetism() { }
}
