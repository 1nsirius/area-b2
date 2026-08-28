// Namespace: 
public class AndroidPermissionWindow : MonoBehaviour // TypeDefIndex: 5216
{
	// Fields
	public Transform mRequestPermissions; // 0xC
	public Text mTxtTitle; // 0x10
	public Text mTxtContent; // 0x14
	public Text mTxtOK; // 0x18
	public Text mTxtCancel; // 0x1C
	public Button mBtnOK; // 0x20
	public Button mBtnCancel; // 0x24
	public Transform mGuide; // 0x28
	public Text mGuide_TxtContent; // 0x2C
	public Button mGuide_BtnOK; // 0x30
	public Text mGuide_TxtOK; // 0x34
	private string mLangId; // 0x38
	private AndroidPermissionTask mTask; // 0x3C

	// Methods

	// RVA: 0xCBDE30 Offset: 0xCBDE30 VA: 0xCBDE30
	public static string GetText(EPermissionsTextId msgId, string languageId) { }

	// RVA: 0xCBDED4 Offset: 0xCBDED4 VA: 0xCBDED4
	private static string GetTextLang1(EPermissionsTextId msgId) { }

	// RVA: 0xCBDF58 Offset: 0xCBDF58 VA: 0xCBDF58
	private static string GetTextLang2(EPermissionsTextId msgId) { }

	// RVA: 0xCBCFD4 Offset: 0xCBCFD4 VA: 0xCBCFD4
	public void Initialize(AndroidPermissionTask task) { }

	// RVA: 0xCBDFDC Offset: 0xCBDFDC VA: 0xCBDFDC
	private void OnApplicationFocus(bool focus) { }

	// RVA: 0xCBD3F0 Offset: 0xCBD3F0 VA: 0xCBD3F0
	public void Show(EPermissionsTextId contentId, UnityAction okHandler) { }

	// RVA: 0xCBD710 Offset: 0xCBD710 VA: 0xCBD710
	public void Hide() { }

	// RVA: 0xCBDFEC Offset: 0xCBDFEC VA: 0xCBDFEC
	public void .ctor() { }
}
