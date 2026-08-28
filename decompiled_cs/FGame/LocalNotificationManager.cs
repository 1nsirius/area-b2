namespace FGame
{

// Namespace: FGame
[LuaCallCSharpAttribute] // RVA: 0x553D7C Offset: 0x553D7C VA: 0x553D7C
public sealed class LocalNotificationManager : BaseSingleton<LocalNotificationManager> // TypeDefIndex: 9830
{
	// Fields
	public const int LUNCH_REWARD_PUSH_ID = 1;
	public const int SUPPER_REWARD_PUSH_ID = 2;
	private bool mReadyToGenAll; // 0x8
	private bool mAllNtfParsed; // 0x9
	private int mWaitTickCount; // 0xC
	private ILuaFunctionWrap mAddNotificationFunc; // 0x10
	private ILuaFunctionWrap mRemoveNotificationFunc; // 0x14
	private ILuaFunctionWrap mRemoveAllNotificationFunc; // 0x18
	private ILuaFunctionWrap mSetLanguageFunc; // 0x1C
	private LocalNotificationManager.LocalNotificationConfig mDefaultConfig; // 0x20

	// Properties
	public bool ReadyToGenAll { get; set; }

	// Methods

	// RVA: 0xF4C718 Offset: 0xF4C718 VA: 0xF4C718
	public void set_ReadyToGenAll(bool value) { }

	// RVA: 0xF4C720 Offset: 0xF4C720 VA: 0xF4C720
	public bool get_ReadyToGenAll() { }

	// RVA: 0xF45BFC Offset: 0xF45BFC VA: 0xF45BFC
	public void Initialize() { }

	// RVA: 0xF42FE4 Offset: 0xF42FE4 VA: 0xF42FE4
	public void Shutdown() { }

	// RVA: 0xF4C728 Offset: 0xF4C728 VA: 0xF4C728
	public void CheckFuncBinding() { }

	// RVA: 0xF4CB78 Offset: 0xF4CB78 VA: 0xF4CB78
	private void OnUpdateServerTick(SprotoTypeBase msg) { }

	// RVA: 0xF4CBD4 Offset: 0xF4CBD4 VA: 0xF4CBD4
	private bool BattleNumEnabled() { }

	// RVA: 0xF4CCCC Offset: 0xF4CCCC VA: 0xF4CCCC
	private void RefreshAllNotification() { }

	// RVA: 0xF4C95C Offset: 0xF4C95C VA: 0xF4C95C
	public void CloseNotificationByConfig() { }

	// RVA: 0xF4D104 Offset: 0xF4D104 VA: 0xF4D104
	private string _GetCountKey(int nType) { }

	// RVA: 0xF4D184 Offset: 0xF4D184 VA: 0xF4D184
	private string _GetKey(int nType, int index) { }

	// RVA: 0xF4D230 Offset: 0xF4D230 VA: 0xF4D230
	private void _AddByRecord(push_table.Record rec) { }

	// RVA: 0xF4D054 Offset: 0xF4D054 VA: 0xF4D054
	private void _RemoveByRecord(push_table.Record rec) { }

	// RVA: 0xF4D714 Offset: 0xF4D714 VA: 0xF4D714
	private int[] _GetDailyNtfTime(string param3) { }

	// RVA: 0xF4CDA8 Offset: 0xF4CDA8 VA: 0xF4CDA8
	private void _RefreshForLunchReward(push_table.Record rec) { }

	// RVA: 0xF4CED8 Offset: 0xF4CED8 VA: 0xF4CED8
	private void _RefreshForSupperReward(push_table.Record rec) { }

	// RVA: 0xF4D008 Offset: 0xF4D008 VA: 0xF4D008
	private void _RefreshRec(push_table.Record rec) { }

	// RVA: 0xF4DBA8 Offset: 0xF4DBA8 VA: 0xF4DBA8
	private void _AddNTF(string key, string title, string text, LocalNotificationManager.LocalNotificationCalendar calendar) { }

	// RVA: 0xF4DFD0 Offset: 0xF4DFD0 VA: 0xF4DFD0
	private void _RemoveNTF(string key) { }

	// RVA: 0xF4E190 Offset: 0xF4E190 VA: 0xF4E190
	private void _RemoveAllNTF() { }

	// RVA: 0xF4E328 Offset: 0xF4E328 VA: 0xF4E328
	public void OnSetEnable(LocalNotificationManager.NotificationType nType, bool isEnable) { }

	// RVA: 0xF4E3FC Offset: 0xF4E3FC VA: 0xF4E3FC
	public void SetLanguage() { }

	// RVA: 0xF4E4EC Offset: 0xF4E4EC VA: 0xF4E4EC
	public void .ctor() { }
}

} // namespace FGame
