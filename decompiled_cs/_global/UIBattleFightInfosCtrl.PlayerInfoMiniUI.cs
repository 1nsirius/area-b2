// Namespace: 
private class UIBattleFightInfosCtrl.PlayerInfoMiniUI // TypeDefIndex: 5746
{
	// Fields
	private readonly RectTransform mTran; // 0x8
	private RectTransform mCareerRt; // 0xC
	private Image mCareer; // 0x10
	private RectTransform mDefuserRt; // 0x14
	private RectTransform mQmRt; // 0x18
	private Image mQm; // 0x1C
	private GameObject mDeadIconGo; // 0x20
	private RectTransform mDeadIconRt; // 0x24
	private RectTransform mOfflineIconRt; // 0x28
	private Scrollbar mBloodProgress; // 0x2C
	private Scrollbar mExtraBloodProgress; // 0x30
	private RectTransform mExtraBloodRt; // 0x34
	private ICharacterProxy mCProxy; // 0x38
	private readonly bool mIsTeammate; // 0x3C
	private bool mTraceBufferGoIsActive; // 0x3D
	private GameObject mTraceBuffGo; // 0x40
	private RectTransform mTraceBuffRect; // 0x44
	private RectTransform mVoiceTran; // 0x48
	private Animator mVoiceAnimator; // 0x4C
	private static readonly int mVoicePlayAnimationName; // 0x0
	private static readonly int mVoiceStopAnimationName; // 0x4
	private bool mCareerIsActive; // 0x50
	private u64 mCProxyId; // 0x54
	private Character.HealthPoint mOldHP; // 0x58

	// Properties
	public bool IsBeMarkedByTracker { get; }

	// Methods

	// RVA: 0xB3E490 Offset: 0xB3E490 VA: 0xB3E490
	public bool get_IsBeMarkedByTracker() { }

	// RVA: 0xB3B664 Offset: 0xB3B664 VA: 0xB3B664
	public void .ctor(GameObject content, bool isTeammate = True) { }

	// RVA: 0xB3B750 Offset: 0xB3B750 VA: 0xB3B750
	public void Init() { }

	// RVA: 0xB3BD6C Offset: 0xB3BD6C VA: 0xB3BD6C
	public void ActiveCarrer(bool active) { }

	// RVA: 0xB3D050 Offset: 0xB3D050 VA: 0xB3D050
	public void Accept(ICharacterProxy proxy) { }

	// RVA: 0xB3C7F8 Offset: 0xB3C7F8 VA: 0xB3C7F8
	public int GetRealCharacterId() { }

	// RVA: 0xB3D898 Offset: 0xB3D898 VA: 0xB3D898
	public void Update() { }

	// RVA: 0xB3E568 Offset: 0xB3E568 VA: 0xB3E568
	private void UpdateBlood() { }

	// RVA: 0xB3EA4C Offset: 0xB3EA4C VA: 0xB3EA4C
	private void CheckDeadState() { }

	// RVA: 0xB3EB74 Offset: 0xB3EB74 VA: 0xB3EB74
	private void CheckOnlineState() { }

	// RVA: 0xB3C5F0 Offset: 0xB3C5F0 VA: 0xB3C5F0
	public U64Id GetPlayerUID() { }

	// RVA: 0xB3C71C Offset: 0xB3C71C VA: 0xB3C71C
	public long GetAccountID() { }

	// RVA: 0xB3EDC8 Offset: 0xB3EDC8 VA: 0xB3EDC8
	public void ShowTraceBuff(bool show = True) { }

	// RVA: 0xB3D9C4 Offset: 0xB3D9C4 VA: 0xB3D9C4
	public void UpdateTraceState() { }

	// RVA: 0xB3DD90 Offset: 0xB3DD90 VA: 0xB3DD90
	public void ShowVoiceUI(bool show) { }

	// RVA: 0xB3EE04 Offset: 0xB3EE04 VA: 0xB3EE04
	private static void .cctor() { }
}
