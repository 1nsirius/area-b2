// Namespace: 
public class SelectOccPanel.Packer : SelectOccPanel.IPacker // TypeDefIndex: 5721
{
	// Fields
	private RoundInfo mRoundInfo; // 0x8
	private OccSelectPool occPool; // 0xC
	private PreBattleData mPreBattleData; // 0x10
	[CompilerGeneratedAttribute] // RVA: 0x56D454 Offset: 0x56D454 VA: 0x56D454
	private Action<uint, int> OnPlayerChangeOcc; // 0x14
	[CompilerGeneratedAttribute] // RVA: 0x56D464 Offset: 0x56D464 VA: 0x56D464
	private Action<uint, bool, bool> OnPlayerReady; // 0x18
	[CompilerGeneratedAttribute] // RVA: 0x56D474 Offset: 0x56D474 VA: 0x56D474
	private Action OnLocalReady; // 0x1C
	[CompilerGeneratedAttribute] // RVA: 0x56D484 Offset: 0x56D484 VA: 0x56D484
	private Action OnCancleReady; // 0x20
	[CompilerGeneratedAttribute] // RVA: 0x56D494 Offset: 0x56D494 VA: 0x56D494
	private Action OnBeginLoading; // 0x24
	[CompilerGeneratedAttribute] // RVA: 0x56D4A4 Offset: 0x56D4A4 VA: 0x56D4A4
	private Action<uint> OnLoadFinish; // 0x28
	[CompilerGeneratedAttribute] // RVA: 0x56D4B4 Offset: 0x56D4B4 VA: 0x56D4B4
	private Action<uint, float> OnLoadProgressChange; // 0x2C
	[CompilerGeneratedAttribute] // RVA: 0x56D4C4 Offset: 0x56D4C4 VA: 0x56D4C4
	private Action<uint, int> OnRegionChange; // 0x30

	// Methods

	[CompilerGeneratedAttribute] // RVA: 0x652FC0 Offset: 0x652FC0 VA: 0x652FC0
	// RVA: 0xF7521C Offset: 0xF7521C VA: 0xF7521C Slot: 4
	public void add_OnPlayerChangeOcc(Action<uint, int> value) { }

	[CompilerGeneratedAttribute] // RVA: 0x652FD0 Offset: 0x652FD0 VA: 0x652FD0
	// RVA: 0xF75328 Offset: 0xF75328 VA: 0xF75328 Slot: 5
	public void remove_OnPlayerChangeOcc(Action<uint, int> value) { }

	[CompilerGeneratedAttribute] // RVA: 0x652FE0 Offset: 0x652FE0 VA: 0x652FE0
	// RVA: 0xF75434 Offset: 0xF75434 VA: 0xF75434 Slot: 6
	public void add_OnPlayerReady(Action<uint, bool, bool> value) { }

	[CompilerGeneratedAttribute] // RVA: 0x652FF0 Offset: 0x652FF0 VA: 0x652FF0
	// RVA: 0xF75540 Offset: 0xF75540 VA: 0xF75540 Slot: 7
	public void remove_OnPlayerReady(Action<uint, bool, bool> value) { }

	[CompilerGeneratedAttribute] // RVA: 0x653000 Offset: 0x653000 VA: 0x653000
	// RVA: 0xF7564C Offset: 0xF7564C VA: 0xF7564C Slot: 8
	public void add_OnLocalReady(Action value) { }

	[CompilerGeneratedAttribute] // RVA: 0x653010 Offset: 0x653010 VA: 0x653010
	// RVA: 0xF75758 Offset: 0xF75758 VA: 0xF75758 Slot: 9
	public void remove_OnLocalReady(Action value) { }

	[CompilerGeneratedAttribute] // RVA: 0x653020 Offset: 0x653020 VA: 0x653020
	// RVA: 0xF75864 Offset: 0xF75864 VA: 0xF75864 Slot: 10
	public void add_OnCancleReady(Action value) { }

	[CompilerGeneratedAttribute] // RVA: 0x653030 Offset: 0x653030 VA: 0x653030
	// RVA: 0xF75970 Offset: 0xF75970 VA: 0xF75970 Slot: 11
	public void remove_OnCancleReady(Action value) { }

	[CompilerGeneratedAttribute] // RVA: 0x653040 Offset: 0x653040 VA: 0x653040
	// RVA: 0xF75A7C Offset: 0xF75A7C VA: 0xF75A7C Slot: 12
	public void add_OnBeginLoading(Action value) { }

	[CompilerGeneratedAttribute] // RVA: 0x653050 Offset: 0x653050 VA: 0x653050
	// RVA: 0xF75B88 Offset: 0xF75B88 VA: 0xF75B88 Slot: 13
	public void remove_OnBeginLoading(Action value) { }

	[CompilerGeneratedAttribute] // RVA: 0x653060 Offset: 0x653060 VA: 0x653060
	// RVA: 0xF75C94 Offset: 0xF75C94 VA: 0xF75C94 Slot: 14
	public void add_OnLoadFinish(Action<uint> value) { }

	[CompilerGeneratedAttribute] // RVA: 0x653070 Offset: 0x653070 VA: 0x653070
	// RVA: 0xF75DA0 Offset: 0xF75DA0 VA: 0xF75DA0 Slot: 15
	public void remove_OnLoadFinish(Action<uint> value) { }

	[CompilerGeneratedAttribute] // RVA: 0x653080 Offset: 0x653080 VA: 0x653080
	// RVA: 0xF75EAC Offset: 0xF75EAC VA: 0xF75EAC Slot: 16
	public void add_OnLoadProgressChange(Action<uint, float> value) { }

	[CompilerGeneratedAttribute] // RVA: 0x653090 Offset: 0x653090 VA: 0x653090
	// RVA: 0xF75FB8 Offset: 0xF75FB8 VA: 0xF75FB8 Slot: 17
	public void remove_OnLoadProgressChange(Action<uint, float> value) { }

	[CompilerGeneratedAttribute] // RVA: 0x6530A0 Offset: 0x6530A0 VA: 0x6530A0
	// RVA: 0xF760C4 Offset: 0xF760C4 VA: 0xF760C4 Slot: 18
	public void add_OnRegionChange(Action<uint, int> value) { }

	[CompilerGeneratedAttribute] // RVA: 0x6530B0 Offset: 0x6530B0 VA: 0x6530B0
	// RVA: 0xF761D0 Offset: 0xF761D0 VA: 0xF761D0 Slot: 19
	public void remove_OnRegionChange(Action<uint, int> value) { }

	// RVA: 0xF762DC Offset: 0xF762DC VA: 0xF762DC
	public void .ctor(RoundInfo info, PreBattleData preBattleData) { }

	// RVA: 0xF76670 Offset: 0xF76670 VA: 0xF76670 Slot: 20
	public bool isSameTeam(uint uid) { }

	// RVA: 0xF76730 Offset: 0xF76730 VA: 0xF76730 Slot: 21
	public BattleTeam GetSelfTeamInfo() { }

	// RVA: 0xF7675C Offset: 0xF7675C VA: 0xF7675C Slot: 22
	public BattleTeam GetOtherTeamInfo() { }

	// RVA: 0xF76788 Offset: 0xF76788 VA: 0xF76788 Slot: 23
	public uint GetSelfUid() { }

	// RVA: 0xF767AC Offset: 0xF767AC VA: 0xF767AC Slot: 24
	public int GetSelfTeamCamp() { }

	// RVA: 0xF767F8 Offset: 0xF767F8 VA: 0xF767F8 Slot: 25
	public int GetOtherTeamCamp() { }

	// RVA: 0xF76844 Offset: 0xF76844 VA: 0xF76844 Slot: 26
	public int GetDefaultOcc() { }

	// RVA: 0xF76870 Offset: 0xF76870 VA: 0xF76870 Slot: 27
	public int GetCrtSelectedOcc() { }

	// RVA: 0xF768AC Offset: 0xF768AC VA: 0xF768AC Slot: 28
	public int GetWeaponUid() { }

	// RVA: 0xF768E4 Offset: 0xF768E4 VA: 0xF768E4 Slot: 29
	public string GetWeaponName(int uid) { }

	// RVA: 0xF769E4 Offset: 0xF769E4 VA: 0xF769E4 Slot: 30
	public bool IsUnlock(int occUid) { }

	// RVA: 0xF76A18 Offset: 0xF76A18 VA: 0xF76A18 Slot: 31
	public string GetUnlockDescription(int occUid) { }

	// RVA: 0xF76A4C Offset: 0xF76A4C VA: 0xF76A4C Slot: 32
	public bool IsSelectedByOther(int occUid) { }

	// RVA: 0xF76A80 Offset: 0xF76A80 VA: 0xF76A80 Slot: 33
	public IList<game.SelectCharacterInfo> GetOtherOccList() { }

	// RVA: 0xF76AAC Offset: 0xF76AAC VA: 0xF76AAC Slot: 34
	public void SelectOcc(int occUid) { }

	// RVA: 0xF76B30 Offset: 0xF76B30 VA: 0xF76B30 Slot: 35
	public bool PopWarnTip(int occUid) { }

	// RVA: 0xF76B64 Offset: 0xF76B64 VA: 0xF76B64 Slot: 36
	public int GetSlefTeamMemberCnt() { }

	// RVA: 0xF76C1C Offset: 0xF76C1C VA: 0xF76C1C Slot: 37
	public int GetOtherTeamMemberCnt() { }

	// RVA: 0xF76CD4 Offset: 0xF76CD4 VA: 0xF76CD4 Slot: 38
	public List<uint> GetSelfTeamSortedList() { }

	// RVA: 0xF76F7C Offset: 0xF76F7C VA: 0xF76F7C Slot: 39
	public List<uint> GetOtherTeamSortedList() { }

	// RVA: 0xF771E8 Offset: 0xF771E8 VA: 0xF771E8 Slot: 40
	public void LocalReady() { }

	// RVA: 0xF77290 Offset: 0xF77290 VA: 0xF77290 Slot: 41
	public void LocalCancleReady() { }

	// RVA: 0xF77338 Offset: 0xF77338 VA: 0xF77338 Slot: 42
	public DateTime GetEndTime() { }

	// RVA: 0xF7736C Offset: 0xF7736C VA: 0xF7736C Slot: 43
	public bool IsRemotePlayerReady(uint uid) { }

	// RVA: 0xF773B8 Offset: 0xF773B8 VA: 0xF773B8 Slot: 44
	public int GetRemotePlayerOcc(uint uid) { }

	// RVA: 0xF774CC Offset: 0xF774CC VA: 0xF774CC Slot: 45
	public string GetPlayerName(uint uid) { }

	// RVA: 0xF77518 Offset: 0xF77518 VA: 0xF77518 Slot: 46
	public SelectOccPanel.OccInfo GetOccInfo(int occUid) { }

	// RVA: 0xF7774C Offset: 0xF7774C VA: 0xF7774C Slot: 47
	public int GetMapCfgId() { }

	// RVA: 0xF77778 Offset: 0xF77778 VA: 0xF77778 Slot: 48
	public string GetSpawnPosName(uint playerUid, out string secondPosName) { }

	// RVA: 0xF7793C Offset: 0xF7793C VA: 0xF7793C Slot: 49
	public bool ShouldShowOtherTeamInfo() { }

	[CompilerGeneratedAttribute] // RVA: 0x6530C0 Offset: 0x6530C0 VA: 0x6530C0
	// RVA: 0xF779B8 Offset: 0xF779B8 VA: 0xF779B8
	private void <.ctor>b__27_0() { }

	[CompilerGeneratedAttribute] // RVA: 0x6530D0 Offset: 0x6530D0 VA: 0x6530D0
	// RVA: 0xF779CC Offset: 0xF779CC VA: 0xF779CC
	private void <.ctor>b__27_1() { }

	[CompilerGeneratedAttribute] // RVA: 0x6530E0 Offset: 0x6530E0 VA: 0x6530E0
	// RVA: 0xF779E0 Offset: 0xF779E0 VA: 0xF779E0
	private void <.ctor>b__27_2(uint uid) { }

	[CompilerGeneratedAttribute] // RVA: 0x6530F0 Offset: 0x6530F0 VA: 0x6530F0
	// RVA: 0xF77A54 Offset: 0xF77A54 VA: 0xF77A54
	private void <.ctor>b__27_3(uint playerUid, float progress) { }

	[CompilerGeneratedAttribute] // RVA: 0x653100 Offset: 0x653100 VA: 0x653100
	// RVA: 0xF77AD0 Offset: 0xF77AD0 VA: 0xF77AD0
	private void <.ctor>b__27_4() { }

	[CompilerGeneratedAttribute] // RVA: 0x653110 Offset: 0x653110 VA: 0x653110
	// RVA: 0xF77AE4 Offset: 0xF77AE4 VA: 0xF77AE4
	private void <.ctor>b__27_5(uint uid, int occUid) { }

	[CompilerGeneratedAttribute] // RVA: 0x653120 Offset: 0x653120 VA: 0x653120
	// RVA: 0xF77B60 Offset: 0xF77B60 VA: 0xF77B60
	private void <.ctor>b__27_6(uint uid, int regionId) { }

	[CompilerGeneratedAttribute] // RVA: 0x653130 Offset: 0x653130 VA: 0x653130
	// RVA: 0xF77BDC Offset: 0xF77BDC VA: 0xF77BDC
	private void <.ctor>b__27_7(uint uid, bool sameTeam, bool isReady) { }
}
