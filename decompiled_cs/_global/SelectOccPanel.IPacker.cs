// Namespace: 
public interface SelectOccPanel.IPacker // TypeDefIndex: 5718
{
	// Methods

	[CompilerGeneratedAttribute] // RVA: 0x652EC0 Offset: 0x652EC0 VA: 0x652EC0
	// RVA: -1 Offset: -1 Slot: 0
	public abstract void add_OnPlayerChangeOcc(Action<uint, int> value);

	[CompilerGeneratedAttribute] // RVA: 0x652ED0 Offset: 0x652ED0 VA: 0x652ED0
	// RVA: -1 Offset: -1 Slot: 1
	public abstract void remove_OnPlayerChangeOcc(Action<uint, int> value);

	[CompilerGeneratedAttribute] // RVA: 0x652EE0 Offset: 0x652EE0 VA: 0x652EE0
	// RVA: -1 Offset: -1 Slot: 2
	public abstract void add_OnPlayerReady(Action<uint, bool, bool> value);

	[CompilerGeneratedAttribute] // RVA: 0x652EF0 Offset: 0x652EF0 VA: 0x652EF0
	// RVA: -1 Offset: -1 Slot: 3
	public abstract void remove_OnPlayerReady(Action<uint, bool, bool> value);

	[CompilerGeneratedAttribute] // RVA: 0x652F00 Offset: 0x652F00 VA: 0x652F00
	// RVA: -1 Offset: -1 Slot: 4
	public abstract void add_OnLocalReady(Action value);

	[CompilerGeneratedAttribute] // RVA: 0x652F10 Offset: 0x652F10 VA: 0x652F10
	// RVA: -1 Offset: -1 Slot: 5
	public abstract void remove_OnLocalReady(Action value);

	[CompilerGeneratedAttribute] // RVA: 0x652F20 Offset: 0x652F20 VA: 0x652F20
	// RVA: -1 Offset: -1 Slot: 6
	public abstract void add_OnCancleReady(Action value);

	[CompilerGeneratedAttribute] // RVA: 0x652F30 Offset: 0x652F30 VA: 0x652F30
	// RVA: -1 Offset: -1 Slot: 7
	public abstract void remove_OnCancleReady(Action value);

	[CompilerGeneratedAttribute] // RVA: 0x652F40 Offset: 0x652F40 VA: 0x652F40
	// RVA: -1 Offset: -1 Slot: 8
	public abstract void add_OnBeginLoading(Action value);

	[CompilerGeneratedAttribute] // RVA: 0x652F50 Offset: 0x652F50 VA: 0x652F50
	// RVA: -1 Offset: -1 Slot: 9
	public abstract void remove_OnBeginLoading(Action value);

	[CompilerGeneratedAttribute] // RVA: 0x652F60 Offset: 0x652F60 VA: 0x652F60
	// RVA: -1 Offset: -1 Slot: 10
	public abstract void add_OnLoadFinish(Action<uint> value);

	[CompilerGeneratedAttribute] // RVA: 0x652F70 Offset: 0x652F70 VA: 0x652F70
	// RVA: -1 Offset: -1 Slot: 11
	public abstract void remove_OnLoadFinish(Action<uint> value);

	[CompilerGeneratedAttribute] // RVA: 0x652F80 Offset: 0x652F80 VA: 0x652F80
	// RVA: -1 Offset: -1 Slot: 12
	public abstract void add_OnLoadProgressChange(Action<uint, float> value);

	[CompilerGeneratedAttribute] // RVA: 0x652F90 Offset: 0x652F90 VA: 0x652F90
	// RVA: -1 Offset: -1 Slot: 13
	public abstract void remove_OnLoadProgressChange(Action<uint, float> value);

	[CompilerGeneratedAttribute] // RVA: 0x652FA0 Offset: 0x652FA0 VA: 0x652FA0
	// RVA: -1 Offset: -1 Slot: 14
	public abstract void add_OnRegionChange(Action<uint, int> value);

	[CompilerGeneratedAttribute] // RVA: 0x652FB0 Offset: 0x652FB0 VA: 0x652FB0
	// RVA: -1 Offset: -1 Slot: 15
	public abstract void remove_OnRegionChange(Action<uint, int> value);

	// RVA: -1 Offset: -1 Slot: 16
	public abstract bool isSameTeam(uint uid);

	// RVA: -1 Offset: -1 Slot: 17
	public abstract BattleTeam GetSelfTeamInfo();

	// RVA: -1 Offset: -1 Slot: 18
	public abstract BattleTeam GetOtherTeamInfo();

	// RVA: -1 Offset: -1 Slot: 19
	public abstract uint GetSelfUid();

	// RVA: -1 Offset: -1 Slot: 20
	public abstract int GetSelfTeamCamp();

	// RVA: -1 Offset: -1 Slot: 21
	public abstract int GetOtherTeamCamp();

	// RVA: -1 Offset: -1 Slot: 22
	public abstract int GetDefaultOcc();

	// RVA: -1 Offset: -1 Slot: 23
	public abstract int GetCrtSelectedOcc();

	// RVA: -1 Offset: -1 Slot: 24
	public abstract int GetWeaponUid();

	// RVA: -1 Offset: -1 Slot: 25
	public abstract string GetWeaponName(int uid);

	// RVA: -1 Offset: -1 Slot: 26
	public abstract bool IsUnlock(int occUid);

	// RVA: -1 Offset: -1 Slot: 27
	public abstract string GetUnlockDescription(int occUid);

	// RVA: -1 Offset: -1 Slot: 28
	public abstract bool IsSelectedByOther(int occUid);

	// RVA: -1 Offset: -1 Slot: 29
	public abstract IList<game.SelectCharacterInfo> GetOtherOccList();

	// RVA: -1 Offset: -1 Slot: 30
	public abstract void SelectOcc(int occUid);

	// RVA: -1 Offset: -1 Slot: 31
	public abstract bool PopWarnTip(int occUid);

	// RVA: -1 Offset: -1 Slot: 32
	public abstract int GetSlefTeamMemberCnt();

	// RVA: -1 Offset: -1 Slot: 33
	public abstract int GetOtherTeamMemberCnt();

	// RVA: -1 Offset: -1 Slot: 34
	public abstract List<uint> GetSelfTeamSortedList();

	// RVA: -1 Offset: -1 Slot: 35
	public abstract List<uint> GetOtherTeamSortedList();

	// RVA: -1 Offset: -1 Slot: 36
	public abstract void LocalReady();

	// RVA: -1 Offset: -1 Slot: 37
	public abstract void LocalCancleReady();

	// RVA: -1 Offset: -1 Slot: 38
	public abstract DateTime GetEndTime();

	// RVA: -1 Offset: -1 Slot: 39
	public abstract bool IsRemotePlayerReady(uint uid);

	// RVA: -1 Offset: -1 Slot: 40
	public abstract int GetRemotePlayerOcc(uint uid);

	// RVA: -1 Offset: -1 Slot: 41
	public abstract string GetPlayerName(uint uid);

	// RVA: -1 Offset: -1 Slot: 42
	public abstract SelectOccPanel.OccInfo GetOccInfo(int occUid);

	// RVA: -1 Offset: -1 Slot: 43
	public abstract int GetMapCfgId();

	// RVA: -1 Offset: -1 Slot: 44
	public abstract string GetSpawnPosName(uint playerUid, out string secondPosName);

	// RVA: -1 Offset: -1 Slot: 45
	public abstract bool ShouldShowOtherTeamInfo();
}
