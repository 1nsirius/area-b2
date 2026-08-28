// Namespace: 
[RequireComponent] // RVA: 0x5501D0 Offset: 0x5501D0 VA: 0x5501D0
[DisallowMultipleComponent] // RVA: 0x5501D0 Offset: 0x5501D0 VA: 0x5501D0
public class LanguageMono : MonoBehaviour // TypeDefIndex: 5467
{
	// Fields
	private Text TextUI; // 0xC
	[SerializeField] // RVA: 0x55D714 Offset: 0x55D714 VA: 0x55D714
	private uint stringID; // 0x10
	[SerializeField] // RVA: 0x55D724 Offset: 0x55D724 VA: 0x55D724
	private List<string> Params; // 0x14
	[SerializeField] // RVA: 0x55D734 Offset: 0x55D734 VA: 0x55D734
	private List<int> LangParams; // 0x18
	private Color mDefaultColor; // 0x1C
	private bool mInit; // 0x2C
	private int mLangMonoID; // 0x30
	public LanguagePackage currLangPak; // 0x34
	private const string noBreakingSpace = " ";
	public bool EnableNoBreakingSpace; // 0x38
	[CompilerGeneratedAttribute] // RVA: 0x55D744 Offset: 0x55D744 VA: 0x55D744
	private bool <IsActive>k__BackingField; // 0x39

	// Properties
	public uint StringID { get; set; }
	public bool IsActive { get; set; }

	// Methods

	// RVA: 0x2CD3B14 Offset: 0x2CD3B14 VA: 0x2CD3B14
	public uint get_StringID() { }

	// RVA: 0x2CD3B1C Offset: 0x2CD3B1C VA: 0x2CD3B1C
	public void set_StringID(uint value) { }

	// RVA: 0x2CD4218 Offset: 0x2CD4218 VA: 0x2CD4218
	public void SetParams(string[] param) { }

	// RVA: 0x2CD4338 Offset: 0x2CD4338 VA: 0x2CD4338
	public void SetParamsID(int[] paramIds) { }

	// RVA: 0x2CD4518 Offset: 0x2CD4518 VA: 0x2CD4518
	public void SetStringIDAndParams(uint value, string[] params) { }

	// RVA: 0x2CD466C Offset: 0x2CD466C VA: 0x2CD466C
	public void SetStringIDAndLangParams(uint value, int[] params) { }

	// RVA: 0x2CD3BEC Offset: 0x2CD3BEC VA: 0x2CD3BEC
	public void SetText(string text) { }

	// RVA: 0x2CD47C0 Offset: 0x2CD47C0 VA: 0x2CD47C0
	private void ReplaceWithNoBreakingSpace() { }

	// RVA: 0x2CD4898 Offset: 0x2CD4898 VA: 0x2CD4898
	public void SetDefaultFontColor(Color color) { }

	// RVA: 0x2CD48F8 Offset: 0x2CD48F8 VA: 0x2CD48F8
	public void ResetFontColor() { }

	// RVA: 0x2CD4958 Offset: 0x2CD4958 VA: 0x2CD4958
	private void Awake() { }

	[CompilerGeneratedAttribute] // RVA: 0x579BDC Offset: 0x579BDC VA: 0x579BDC
	// RVA: 0x2CD4A78 Offset: 0x2CD4A78 VA: 0x2CD4A78
	public bool get_IsActive() { }

	[CompilerGeneratedAttribute] // RVA: 0x579BEC Offset: 0x579BEC VA: 0x579BEC
	// RVA: 0x2CD4A80 Offset: 0x2CD4A80 VA: 0x2CD4A80
	private void set_IsActive(bool value) { }

	// RVA: 0x2CD4A88 Offset: 0x2CD4A88 VA: 0x2CD4A88
	private void OnEnable() { }

	// RVA: 0x2CD4B60 Offset: 0x2CD4B60 VA: 0x2CD4B60
	private void OnDisable() { }

	// RVA: 0x2CD4B6C Offset: 0x2CD4B6C VA: 0x2CD4B6C
	private void OnDestroy() { }

	// RVA: 0x2CD4C7C Offset: 0x2CD4C7C VA: 0x2CD4C7C
	public void .ctor() { }
}
