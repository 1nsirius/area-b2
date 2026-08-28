// Namespace: 
public class UIBattleSurveillanceCamControl.CicleFlag // TypeDefIndex: 5806
{
	// Fields
	public uint miniCarId; // 0x8
	public UIBattleSurveillanceCamControl.CicleFlagEnum flag; // 0xC
	public GameObject cicleGo; // 0x10
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
	[CompilerGeneratedAttribute] // RVA: 0x56D684 Offset: 0x56D684 VA: 0x56D684
	private ISurveillanceCamProxy <proxy>k__BackingField; // 0x3C

	// Properties
	public ISurveillanceCamProxy proxy { get; set; }

	// Methods

	[CompilerGeneratedAttribute] // RVA: 0x6534B0 Offset: 0x6534B0 VA: 0x6534B0
	// RVA: 0xAF11C4 Offset: 0xAF11C4 VA: 0xAF11C4
	private void set_proxy(ISurveillanceCamProxy value) { }

	[CompilerGeneratedAttribute] // RVA: 0x6534C0 Offset: 0x6534C0 VA: 0x6534C0
	// RVA: 0xAEF1A4 Offset: 0xAEF1A4 VA: 0xAEF1A4
	public ISurveillanceCamProxy get_proxy() { }

	// RVA: 0xAF00A4 Offset: 0xAF00A4 VA: 0xAF00A4
	public void .ctor(ISurveillanceCamProxy proxy, GameObject cicleGo) { }

	// RVA: 0xAF0140 Offset: 0xAF0140 VA: 0xAF0140
	public void Init() { }

	// RVA: 0xAEF554 Offset: 0xAEF554 VA: 0xAEF554
	public void Update(UIBattleSurveillanceCamControl.CicleFlagEnum _flag) { }

	// RVA: 0xAF11CC Offset: 0xAF11CC VA: 0xAF11CC
	public U64Id GetCamId() { }

	// RVA: 0xAEEFF4 Offset: 0xAEEFF4 VA: 0xAEEFF4
	public bool IsDead() { }

	// RVA: 0xAEF0CC Offset: 0xAEF0CC VA: 0xAEF0CC
	public bool IsBeInterferenceWithElectromagnetism() { }
}
