// Namespace: 
public class PreBattleSpawnRegionSelectView.RegionUI // TypeDefIndex: 10485
{
	// Fields
	private SpawnRegionViewData.RegionData mModel; // 0x8
	private RectTransform mContentRt; // 0xC
	private GameObject mContent; // 0x10
	private RectTransform mPlayerIconsRt; // 0x14
	private Image mSelecterImg; // 0x18
	private Image mSelecterFgImg; // 0x1C
	private Text mName; // 0x20
	private List<PreBattleSpawnRegionSelectView.PlayerUI> playerUis; // 0x24
	private GameObject mArrowGo; // 0x28
	[CompilerGeneratedAttribute] // RVA: 0x56E744 Offset: 0x56E744 VA: 0x56E744
	private Action<uint> mOnClickEvent; // 0x2C
	private bool mSelected; // 0x30
	private Image mSelecterAdditionalImg; // 0x34
	private Image mSelecterFgAdditionalImg; // 0x38
	private Text mNameAdditional; // 0x3C
	private bool mNeedPerfromBattleMode; // 0x40

	// Methods

	[CompilerGeneratedAttribute] // RVA: 0x65D9E0 Offset: 0x65D9E0 VA: 0x65D9E0
	// RVA: 0xC90740 Offset: 0xC90740 VA: 0xC90740
	public void add_mOnClickEvent(Action<uint> value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65D9F0 Offset: 0x65D9F0 VA: 0x65D9F0
	// RVA: 0xC90BAC Offset: 0xC90BAC VA: 0xC90BAC
	public void remove_mOnClickEvent(Action<uint> value) { }

	// RVA: 0xC8FDFC Offset: 0xC8FDFC VA: 0xC8FDFC
	public void .ctor(SpawnRegionViewData.RegionData data, RectTransform rt, int battleMode, BattleCamp camp) { }

	// RVA: 0xC9084C Offset: 0xC9084C VA: 0xC9084C
	public void Active(bool active) { }

	// RVA: 0xC90CB8 Offset: 0xC90CB8 VA: 0xC90CB8
	public void SetSelected(bool selected) { }

	// RVA: 0xC90E9C Offset: 0xC90E9C VA: 0xC90E9C
	public void Refresh() { }

	// RVA: 0xC90EAC Offset: 0xC90EAC VA: 0xC90EAC
	private void RefreshPlayerIcons() { }

	// RVA: 0xC9131C Offset: 0xC9131C VA: 0xC9131C
	public uint GetRegionId() { }

	// RVA: 0xC90A1C Offset: 0xC90A1C VA: 0xC90A1C
	public void OnSelfRegionIdChange(uint selfRegionId) { }

	[CompilerGeneratedAttribute] // RVA: 0x65DA00 Offset: 0x65DA00 VA: 0x65DA00
	// RVA: 0xC91340 Offset: 0xC91340 VA: 0xC91340
	private void <.ctor>b__17_0(PointerEventData _) { }
}
