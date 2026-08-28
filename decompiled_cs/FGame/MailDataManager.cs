namespace FGame
{

// Namespace: FGame
[LuaCallCSharpAttribute] // RVA: 0x553F08 Offset: 0x553F08 VA: 0x553F08
public sealed class MailDataManager : BaseSingleton<MailDataManager> // TypeDefIndex: 9919
{
	// Fields
	[CompilerGeneratedAttribute] // RVA: 0x563574 Offset: 0x563574 VA: 0x563574
	private List<mail.Mail> <MailList>k__BackingField; // 0x8
	public Action OnMailListChange; // 0xC
	public Action<long, long> OnOperateMail; // 0x10
	public Action<List<long>> OnGetAllReward; // 0x14
	public Action OnDeleteAllReadMail; // 0x18
	public Action<long> OnNewMail; // 0x1C
	public Action<long> OnDeleteMail; // 0x20
	private List<long> mTempLongList; // 0x24
	private List<mail.Mail> mTempMailList; // 0x28

	// Properties
	public List<mail.Mail> MailList { get; set; }

	// Methods

	[CompilerGeneratedAttribute] // RVA: 0x646ED0 Offset: 0x646ED0 VA: 0x646ED0
	// RVA: 0xF58464 Offset: 0xF58464 VA: 0xF58464
	public List<mail.Mail> get_MailList() { }

	[CompilerGeneratedAttribute] // RVA: 0x646EE0 Offset: 0x646EE0 VA: 0x646EE0
	// RVA: 0xF5846C Offset: 0xF5846C VA: 0xF5846C
	private void set_MailList(List<mail.Mail> value) { }

	// RVA: 0xF45864 Offset: 0xF45864 VA: 0xF45864
	public void Initialize() { }

	// RVA: 0xF58474 Offset: 0xF58474 VA: 0xF58474
	public void Clear() { }

	// RVA: 0xF42C4C Offset: 0xF42C4C VA: 0xF42C4C
	public void Shutdown() { }

	// RVA: 0xF58544 Offset: 0xF58544 VA: 0xF58544
	public mail.Mail GetMail(long id) { }

	// RVA: 0xF58678 Offset: 0xF58678 VA: 0xF58678
	private void OnMailListResponse(SprotoTypeBase msg) { }

	// RVA: 0xF58BDC Offset: 0xF58BDC VA: 0xF58BDC
	private void OnOperateMailResponse(SprotoTypeBase msg) { }

	// RVA: 0xF59060 Offset: 0xF59060 VA: 0xF59060
	private void OnDeleteAllReadMailResponse(SprotoTypeBase msg) { }

	// RVA: 0xF5930C Offset: 0xF5930C VA: 0xF5930C
	private void OnGetAllRewardResponse(SprotoTypeBase msg) { }

	// RVA: 0xF5974C Offset: 0xF5974C VA: 0xF5974C
	private void OnNewMailNotify(SprotoTypeBase msg) { }

	// RVA: 0xF598DC Offset: 0xF598DC VA: 0xF598DC
	private void OnDeleteMailNotify(SprotoTypeBase msg) { }

	// RVA: 0xF588E4 Offset: 0xF588E4 VA: 0xF588E4
	private void RefreshReddot() { }

	// RVA: 0xF59AEC Offset: 0xF59AEC VA: 0xF59AEC
	public void .ctor() { }
}

} // namespace FGame
