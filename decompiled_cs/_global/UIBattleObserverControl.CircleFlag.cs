// Namespace: 
public class UIBattleObserverControl.CircleFlag // TypeDefIndex: 5788
{
	// Fields
	public byte CharacterBID; // 0x8
	public UIBattleObserverControl.CircleFlagEnum Flag; // 0xC
	private GameObject mGo; // 0x10
	private RectTransform mRt; // 0x14
	private Image mRtImg; // 0x18
	private GameObject mImgLiveGo; // 0x1C
	private RectTransform mImgLiveTran; // 0x20
	private GameObject mImgDeadGo; // 0x24
	private RectTransform mImgDeadTran; // 0x28
	private GameObject mImgObserverGo; // 0x2C
	private RectTransform mImgObserverTran; // 0x30
	public bool IsRobot; // 0x34
	[CompilerGeneratedAttribute] // RVA: 0x56D5E4 Offset: 0x56D5E4 VA: 0x56D5E4
	private ICharacterProxy <Proxy>k__BackingField; // 0x38

	// Properties
	public ICharacterProxy Proxy { get; set; }
	public Character.HealthPoint Hp { get; }
	public ushort MaxHp { get; }

	// Methods

	[CompilerGeneratedAttribute] // RVA: 0x653360 Offset: 0x653360 VA: 0x653360
	// RVA: 0xADF2A0 Offset: 0xADF2A0 VA: 0xADF2A0
	public void set_Proxy(ICharacterProxy value) { }

	[CompilerGeneratedAttribute] // RVA: 0x653370 Offset: 0x653370 VA: 0x653370
	// RVA: 0xAE001C Offset: 0xAE001C VA: 0xAE001C
	public ICharacterProxy get_Proxy() { }

	// RVA: 0xADF368 Offset: 0xADF368 VA: 0xADF368
	public Character.HealthPoint get_Hp() { }

	// RVA: 0xADF48C Offset: 0xADF48C VA: 0xADF48C
	public ushort get_MaxHp() { }

	// RVA: 0xADD0E4 Offset: 0xADD0E4 VA: 0xADD0E4
	public void Init(RectTransform rt) { }

	// RVA: 0xAE0024 Offset: 0xAE0024 VA: 0xAE0024
	public void Hide() { }

	// RVA: 0xADF2A8 Offset: 0xADF2A8 VA: 0xADF2A8
	public void Update(UIBattleObserverControl.CircleFlagEnum flag) { }

	// RVA: 0xADF28C Offset: 0xADF28C VA: 0xADF28C
	public void Reset() { }

	// RVA: 0xADD0DC Offset: 0xADD0DC VA: 0xADD0DC
	public void .ctor() { }
}
