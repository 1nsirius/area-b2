// Namespace: 
public class PlayerFightInfoUI.WeaponUI // TypeDefIndex: 10445
{
	// Fields
	private PlayerFightInfoModel.WeaponInfoModel mModel; // 0x8
	private ImageWrapper mImg; // 0xC
	private Text mName; // 0x10
	private Text mNum; // 0x14
	private RectTransform mNumRt; // 0x18
	private Text mRightNum; // 0x1C
	private RectTransform mRightNumRt; // 0x20
	private RectTransform mRt; // 0x24
	private CanvasGroup mCanvasGroup; // 0x28
	private bool mShouldHideNum; // 0x2C

	// Methods

	// RVA: 0xC9BABC Offset: 0xC9BABC VA: 0xC9BABC
	public void .ctor(RectTransform rt, bool shouldHideNum) { }

	// RVA: 0xC9BF14 Offset: 0xC9BF14 VA: 0xC9BF14
	public void Accept(PlayerFightInfoModel.WeaponInfoModel model) { }

	// RVA: 0xC9C2A0 Offset: 0xC9C2A0 VA: 0xC9C2A0
	public void Refresh() { }

	// RVA: 0xC9C764 Offset: 0xC9C764 VA: 0xC9C764
	private void RefreshBaseInfo() { }

	// RVA: 0xC9C950 Offset: 0xC9C950 VA: 0xC9C950
	private void RefreshNumTexts() { }

	// RVA: 0xC9CDF8 Offset: 0xC9CDF8 VA: 0xC9CDF8
	private void LoadItemIcon(string itemType, string iconName) { }
}
