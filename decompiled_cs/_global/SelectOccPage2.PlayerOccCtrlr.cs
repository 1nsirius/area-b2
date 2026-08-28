// Namespace: 
private class SelectOccPage2.PlayerOccCtrlr : IDisposable // TypeDefIndex: 5662
{
	// Fields
	private bool mIsSelf; // 0x8
	private byte mLoadProgress; // 0x9
	private SelectOccPage2.ELoadState mLoadState; // 0xC
	private string mPlayerName; // 0x10
	private SelectOccPage2.EState mState; // 0x14
	private int mTeam; // 0x18
	private SelectOccPage2.PlayerOccView mView; // 0x1C
	[CompilerGeneratedAttribute] // RVA: 0x56D444 Offset: 0x56D444 VA: 0x56D444
	private uint <PlayerUid>k__BackingField; // 0x20

	// Properties
	private static string DefaultSkillName { get; }
	public uint PlayerUid { get; set; }

	// Methods

	// RVA: 0xF727E0 Offset: 0xF727E0 VA: 0xF727E0
	private static string get_DefaultSkillName() { }

	// RVA: 0xF7288C Offset: 0xF7288C VA: 0xF7288C
	public void .ctor(uint playerUid, string playerName, int team, SelectOccPage2.PlayerOccView view, bool isSelf, SelectOccPage2.EState state) { }

	[CompilerGeneratedAttribute] // RVA: 0x652EA0 Offset: 0x652EA0 VA: 0x652EA0
	// RVA: 0xF72964 Offset: 0xF72964 VA: 0xF72964
	public uint get_PlayerUid() { }

	[CompilerGeneratedAttribute] // RVA: 0x652EB0 Offset: 0x652EB0 VA: 0x652EB0
	// RVA: 0xF728F0 Offset: 0xF728F0 VA: 0xF728F0
	private void set_PlayerUid(uint value) { }

	// RVA: 0xF7296C Offset: 0xF7296C VA: 0xF7296C Slot: 4
	public void Dispose() { }

	// RVA: 0xF729F4 Offset: 0xF729F4 VA: 0xF729F4
	public void SetLoadState(SelectOccPage2.ELoadState loadState) { }

	// RVA: 0xF72BC8 Offset: 0xF72BC8 VA: 0xF72BC8
	public void SetOccInfo(string name, string skillName, string iconPath, string bigImgPath, string pos, string pos2) { }

	// RVA: 0xF72D8C Offset: 0xF72D8C VA: 0xF72D8C
	public void SetProgress(byte progress) { }

	// RVA: 0xF72EA8 Offset: 0xF72EA8 VA: 0xF72EA8
	public void SetSpawnName(string spawnName, string secondSpawnName) { }

	// RVA: 0xF72F40 Offset: 0xF72F40 VA: 0xF72F40
	public void SetState(SelectOccPage2.EState state) { }

	// RVA: 0xF728F8 Offset: 0xF728F8 VA: 0xF728F8
	private void InitView() { }

	// RVA: 0xF72A08 Offset: 0xF72A08 VA: 0xF72A08
	private void RefreshLoadState() { }

	// RVA: 0xF732B0 Offset: 0xF732B0 VA: 0xF732B0
	private void RefreshOutLine() { }

	// RVA: 0xF72F54 Offset: 0xF72F54 VA: 0xF72F54
	private void RefreshPlayerState() { }

	// RVA: 0xF733E0 Offset: 0xF733E0 VA: 0xF733E0
	private void RefreshTeamBgSelected() { }

	// RVA: 0xF734D4 Offset: 0xF734D4 VA: 0xF734D4
	public void PlayOpenAnimation(int idx) { }

	// RVA: 0xF734EC Offset: 0xF734EC VA: 0xF734EC
	public void PlayCloseAnimation() { }

	// RVA: 0xF73504 Offset: 0xF73504 VA: 0xF73504
	public void PlayChangeBiggerAnimation() { }

	// RVA: 0xF7351C Offset: 0xF7351C VA: 0xF7351C
	public void SetOutLineActive(bool active) { }

	// RVA: 0xF735B0 Offset: 0xF735B0 VA: 0xF735B0
	public void RefreshBombModePresentation(long pickUpedBombPlayerId) { }
}
