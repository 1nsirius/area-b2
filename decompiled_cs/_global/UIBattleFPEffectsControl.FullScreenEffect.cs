// Namespace: 
public class UIBattleFPEffectsControl.FullScreenEffect // TypeDefIndex: 5763
{
	// Fields
	[CompilerGeneratedAttribute] // RVA: 0x56D544 Offset: 0x56D544 VA: 0x56D544
	private Animator <Animator>k__BackingField; // 0x8
	[CompilerGeneratedAttribute] // RVA: 0x56D554 Offset: 0x56D554 VA: 0x56D554
	private GameObject <Content>k__BackingField; // 0xC
	public RectTransform mTran; // 0x10
	[CompilerGeneratedAttribute] // RVA: 0x56D564 Offset: 0x56D564 VA: 0x56D564
	private float <ElapsedTime>k__BackingField; // 0x14
	[CompilerGeneratedAttribute] // RVA: 0x56D574 Offset: 0x56D574 VA: 0x56D574
	private bool <active>k__BackingField; // 0x18
	[CompilerGeneratedAttribute] // RVA: 0x56D584 Offset: 0x56D584 VA: 0x56D584
	private Image <bloodImg>k__BackingField; // 0x1C
	private IDisposable _curTask; // 0x20
	private float _curAlpha; // 0x24

	// Properties
	public Animator Animator { get; set; }
	public GameObject Content { get; set; }
	public float ElapsedTime { get; set; }
	public bool active { get; set; }
	public Image bloodImg { get; set; }

	// Methods

	[CompilerGeneratedAttribute] // RVA: 0x653220 Offset: 0x653220 VA: 0x653220
	// RVA: 0xB39EDC Offset: 0xB39EDC VA: 0xB39EDC
	private void set_Animator(Animator value) { }

	[CompilerGeneratedAttribute] // RVA: 0x653230 Offset: 0x653230 VA: 0x653230
	// RVA: 0xB39EE4 Offset: 0xB39EE4 VA: 0xB39EE4
	public Animator get_Animator() { }

	[CompilerGeneratedAttribute] // RVA: 0x653240 Offset: 0x653240 VA: 0x653240
	// RVA: 0xB39EEC Offset: 0xB39EEC VA: 0xB39EEC
	private void set_Content(GameObject value) { }

	[CompilerGeneratedAttribute] // RVA: 0x653250 Offset: 0x653250 VA: 0x653250
	// RVA: 0xB39EF4 Offset: 0xB39EF4 VA: 0xB39EF4
	public GameObject get_Content() { }

	[CompilerGeneratedAttribute] // RVA: 0x653260 Offset: 0x653260 VA: 0x653260
	// RVA: 0xB39EFC Offset: 0xB39EFC VA: 0xB39EFC
	private void set_ElapsedTime(float value) { }

	[CompilerGeneratedAttribute] // RVA: 0x653270 Offset: 0x653270 VA: 0x653270
	// RVA: 0xB39F04 Offset: 0xB39F04 VA: 0xB39F04
	public float get_ElapsedTime() { }

	[CompilerGeneratedAttribute] // RVA: 0x653280 Offset: 0x653280 VA: 0x653280
	// RVA: 0xB39F0C Offset: 0xB39F0C VA: 0xB39F0C
	private void set_active(bool value) { }

	[CompilerGeneratedAttribute] // RVA: 0x653290 Offset: 0x653290 VA: 0x653290
	// RVA: 0xB39F14 Offset: 0xB39F14 VA: 0xB39F14
	public bool get_active() { }

	[CompilerGeneratedAttribute] // RVA: 0x6532A0 Offset: 0x6532A0 VA: 0x6532A0
	// RVA: 0xB39F1C Offset: 0xB39F1C VA: 0xB39F1C
	private void set_bloodImg(Image value) { }

	[CompilerGeneratedAttribute] // RVA: 0x6532B0 Offset: 0x6532B0 VA: 0x6532B0
	// RVA: 0xB39F24 Offset: 0xB39F24 VA: 0xB39F24
	public Image get_bloodImg() { }

	// RVA: 0xB385D0 Offset: 0xB385D0 VA: 0xB385D0
	public void .ctor(GameObject go) { }

	// RVA: 0xB37894 Offset: 0xB37894 VA: 0xB37894
	public void Active(bool active) { }

	// RVA: 0xB39F2C Offset: 0xB39F2C VA: 0xB39F2C
	public void Tick(float deltaTime) { }

	// RVA: 0xB378D8 Offset: 0xB378D8 VA: 0xB378D8
	public void ShowFullScreenEffect() { }

	// RVA: 0xB39F38 Offset: 0xB39F38 VA: 0xB39F38
	private void Reset() { }

	// RVA: 0xB39F3C Offset: 0xB39F3C VA: 0xB39F3C
	private void SetAlpha(float alpha) { }

	// RVA: 0xB3A0A8 Offset: 0xB3A0A8 VA: 0xB3A0A8
	private void Stop() { }
}
