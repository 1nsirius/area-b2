// Namespace: 
private abstract class UIBattleScoreResultControll.RankNode.ProgressController // TypeDefIndex: 10248
{
	// Fields
	[CompilerGeneratedAttribute] // RVA: 0x5796BC Offset: 0x5796BC VA: 0x5796BC
	private Action OnPlayComplete; // 0x8
	public UIBattleScoreResultControll.RankNode Target; // 0xC
	protected float mTimeCount; // 0x10
	protected bool mIsStart; // 0x14

	// Methods

	[CompilerGeneratedAttribute] // RVA: 0x668890 Offset: 0x668890 VA: 0x668890
	// RVA: 0xC06814 Offset: 0xC06814 VA: 0xC06814
	public void add_OnPlayComplete(Action value) { }

	[CompilerGeneratedAttribute] // RVA: 0x6688A0 Offset: 0x6688A0 VA: 0x6688A0
	// RVA: 0xC07B7C Offset: 0xC07B7C VA: 0xC07B7C
	public void remove_OnPlayComplete(Action value) { }

	// RVA: 0xC07C88 Offset: 0xC07C88 VA: 0xC07C88 Slot: 4
	public virtual void Start() { }

	// RVA: 0xC07C9C Offset: 0xC07C9C VA: 0xC07C9C Slot: 5
	public virtual void Update(float timeDelta) { }

	// RVA: 0xC07CB0 Offset: 0xC07CB0 VA: 0xC07CB0 Slot: 6
	public virtual void Stop() { }

	// RVA: 0xC05B70 Offset: 0xC05B70 VA: 0xC05B70
	public void Clear() { }

	// RVA: 0xC074C4 Offset: 0xC074C4 VA: 0xC074C4
	public bool Completed() { }

	// RVA: 0xC07CD4 Offset: 0xC07CD4 VA: 0xC07CD4
	protected void .ctor() { }
}
