// Namespace: 
private class SelectOccPage2.PlayerOccView : IDisposable // TypeDefIndex: 5659
{
	// Fields
	private List<MaskableGraphic> mNeedRefreshElems; // 0x8
	public Image OccIcon; // 0xC
	public ImageWrapper OccIconWrapper; // 0x10
	public Image OccImg; // 0x14
	public ImageWrapper OccImgWrapper; // 0x18
	public Image OccImgNotSelect; // 0x1C
	public Text OccNameText; // 0x20
	public Text OccSkillNameText; // 0x24
	public MaskableGraphic Outline; // 0x28
	public Image PlayerFlagLoaded; // 0x2C
	public Text PlayerLoadingProgress; // 0x30
	public Text PlayerNameText; // 0x34
	public Text PlayerPosText; // 0x38
	public Text PlayerPosText2; // 0x3C
	public Image TeamBgNotSelectBlue; // 0x40
	public Image TeamBgNotSelectOrange; // 0x44
	public Image TeamBgSelectedBlue; // 0x48
	public Image TeamBgSelectedOrange; // 0x4C
	public Image TeamFgBlue; // 0x50
	public Image TeamFgOrange; // 0x54
	[CompilerGeneratedAttribute] // RVA: 0x56D434 Offset: 0x56D434 VA: 0x56D434
	private Transform <Trans>k__BackingField; // 0x58
	private GameObject mOutLineGo; // 0x5C
	private GameObject mBombIconGo; // 0x60

	// Properties
	public Transform Trans { get; set; }

	// Methods

	[CompilerGeneratedAttribute] // RVA: 0x652E80 Offset: 0x652E80 VA: 0x652E80
	// RVA: 0xF73304 Offset: 0xF73304 VA: 0xF73304
	public Transform get_Trans() { }

	[CompilerGeneratedAttribute] // RVA: 0x652E90 Offset: 0x652E90 VA: 0x652E90
	// RVA: 0xF73658 Offset: 0xF73658 VA: 0xF73658
	protected void set_Trans(Transform value) { }

	// RVA: 0xF7297C Offset: 0xF7297C VA: 0xF7297C Slot: 4
	public void Dispose() { }

	// RVA: 0xF73660 Offset: 0xF73660 VA: 0xF73660
	public SelectOccPage2.PlayerOccView Clone() { }

	// RVA: 0xF7330C Offset: 0xF7330C VA: 0xF7330C
	public void HideAll() { }

	// RVA: 0xF737C0 Offset: 0xF737C0 VA: 0xF737C0
	public void InitView(Transform trans) { }

	// RVA: 0xF73FB8 Offset: 0xF73FB8 VA: 0xF73FB8
	public void PlayInitAnimation() { }

	// RVA: 0xF734E8 Offset: 0xF734E8 VA: 0xF734E8
	public void PlayOpenAnimation(int idx) { }

	// RVA: 0xF73500 Offset: 0xF73500 VA: 0xF73500
	public void PlayCloseAnimation() { }

	// RVA: 0xF73518 Offset: 0xF73518 VA: 0xF73518
	public void PlayChangeBiggerAnimation() { }

	// RVA: 0xF7354C Offset: 0xF7354C VA: 0xF7354C
	public void SetOutLineActive(bool active) { }

	// RVA: 0xF735F4 Offset: 0xF735F4 VA: 0xF735F4
	public void ShowBombIcon(bool active) { }

	// RVA: 0xF73734 Offset: 0xF73734 VA: 0xF73734
	public void .ctor() { }
}
