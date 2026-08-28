namespace FGame
{

// Namespace: FGame
[LuaCallCSharpAttribute] // RVA: 0x553FC8 Offset: 0x553FC8 VA: 0x553FC8
public class PlayerData : BaseSingleton<PlayerData>, IPlayerData // TypeDefIndex: 9931
{
	// Fields
	private XorInt mExp; // 0x8
	private Dictionary<string, long> mGlobalStats; // 0x10
	private uint mIconId; // 0x14
	private uint mLevel; // 0x18
	private string mName; // 0x1C
	private uint mUid; // 0x20
	private List<long> mUnlockCharacters; // 0x24
	private uint mCurrentSeasonID; // 0x28
	private List<long> mHasCharacters; // 0x2C
	[CompilerGeneratedAttribute] // RVA: 0x563714 Offset: 0x563714 VA: 0x563714
	private static uint <GiftCount>k__BackingField; // 0x0
	private long mServerTimeZone; // 0x30
	public Dictionary<string, int> RechargeList; // 0x38
	[CompilerGeneratedAttribute] // RVA: 0x563724 Offset: 0x563724 VA: 0x563724
	private XorInt <GoldCount>k__BackingField; // 0x3C
	[CompilerGeneratedAttribute] // RVA: 0x563734 Offset: 0x563734 VA: 0x563734
	private XorInt <DiamondCount>k__BackingField; // 0x44
	public long LastShareTime; // 0x50
	[CompilerGeneratedAttribute] // RVA: 0x563744 Offset: 0x563744 VA: 0x563744
	private Action OnDataChange; // 0x58
	[CompilerGeneratedAttribute] // RVA: 0x563754 Offset: 0x563754 VA: 0x563754
	private Action<string, string, long> OnBattleStatChange; // 0x5C
	public Dictionary<string, PlayerData.BindedVendor> BindedVendors; // 0x60
	public string Region; // 0x64
	private string mRegionName; // 0x68
	public string SDKServerName; // 0x6C
	public string SDKServerId; // 0x70
	private string mIconUrl; // 0x74
	private uint mIconFrame; // 0x78
	private uint mShowCharacterId; // 0x7C
	public string ConnectIp; // 0x80
	public uint Port; // 0x84
	public string env_info; // 0x88
	public JF_ACCINFO envInfo; // 0x8C

	// Properties
	public static uint GiftCount { get; set; }
	public List<long> UnlockCharacters { get; set; }
	public XorInt GoldCount { get; set; }
	public XorInt DiamondCount { get; set; }
	public uint Exp { get; set; }
	public uint IconId { get; set; }
	public uint IconFrame { get; set; }
	public uint Level { get; set; }
	public string Name { get; set; }
	public uint Uid { get; set; }
	public uint CurrentSeasonID { get; set; }
	public uint ShowCharacterId { get; set; }
	public long ServerTimeZone { get; set; }
	public string RegionName { get; set; }
	public string IconUrl { get; set; }

	// Methods

	[CompilerGeneratedAttribute] // RVA: 0x647200 Offset: 0x647200 VA: 0x647200
	// RVA: 0xB6DA78 Offset: 0xB6DA78 VA: 0xB6DA78
	public static uint get_GiftCount() { }

	[CompilerGeneratedAttribute] // RVA: 0x647210 Offset: 0x647210 VA: 0x647210
	// RVA: 0xB6DADC Offset: 0xB6DADC VA: 0xB6DADC
	public static void set_GiftCount(uint value) { }

	// RVA: 0xB6DB40 Offset: 0xB6DB40 VA: 0xB6DB40
	public static void AddRechageItem(string productId, int showMoneyValue) { }

	// RVA: 0xB6DCA4 Offset: 0xB6DCA4 VA: 0xB6DCA4
	public static int GetRechargeShowMoney(string productId) { }

	// RVA: 0xB6DDAC Offset: 0xB6DDAC VA: 0xB6DDAC
	public List<long> get_UnlockCharacters() { }

	// RVA: 0xB6DDB4 Offset: 0xB6DDB4 VA: 0xB6DDB4
	public void set_UnlockCharacters(List<long> value) { }

	// RVA: 0xB6DDDC Offset: 0xB6DDDC VA: 0xB6DDDC
	public static List<long> GetPlayerCharacter() { }

	// RVA: 0xB6DE7C Offset: 0xB6DE7C VA: 0xB6DE7C
	public static void AddHasCharacter(long charId) { }

	[CompilerGeneratedAttribute] // RVA: 0x647220 Offset: 0x647220 VA: 0x647220
	// RVA: 0xB6E054 Offset: 0xB6E054 VA: 0xB6E054
	public XorInt get_GoldCount() { }

	[CompilerGeneratedAttribute] // RVA: 0x647230 Offset: 0x647230 VA: 0x647230
	// RVA: 0xB6E068 Offset: 0xB6E068 VA: 0xB6E068
	public void set_GoldCount(XorInt value) { }

	[CompilerGeneratedAttribute] // RVA: 0x647240 Offset: 0x647240 VA: 0x647240
	// RVA: 0xB6E074 Offset: 0xB6E074 VA: 0xB6E074
	public XorInt get_DiamondCount() { }

	[CompilerGeneratedAttribute] // RVA: 0x647250 Offset: 0x647250 VA: 0x647250
	// RVA: 0xB6E088 Offset: 0xB6E088 VA: 0xB6E088
	public void set_DiamondCount(XorInt value) { }

	// RVA: 0xB6E094 Offset: 0xB6E094 VA: 0xB6E094 Slot: 4
	public uint get_Exp() { }

	// RVA: 0xB6E124 Offset: 0xB6E124 VA: 0xB6E124
	public void set_Exp(uint value) { }

	// RVA: 0xB6E244 Offset: 0xB6E244 VA: 0xB6E244 Slot: 5
	public uint get_IconId() { }

	// RVA: 0xB6E24C Offset: 0xB6E24C VA: 0xB6E24C
	public void set_IconId(uint value) { }

	// RVA: 0xB6E278 Offset: 0xB6E278 VA: 0xB6E278
	public uint get_IconFrame() { }

	// RVA: 0xB6E280 Offset: 0xB6E280 VA: 0xB6E280
	public void set_IconFrame(uint value) { }

	// RVA: 0xB6E2AC Offset: 0xB6E2AC VA: 0xB6E2AC Slot: 6
	public uint get_Level() { }

	// RVA: 0xB6E2B4 Offset: 0xB6E2B4 VA: 0xB6E2B4
	public void set_Level(uint value) { }

	// RVA: 0xB6E364 Offset: 0xB6E364 VA: 0xB6E364 Slot: 7
	public string get_Name() { }

	// RVA: 0xB6E36C Offset: 0xB6E36C VA: 0xB6E36C
	public void set_Name(string value) { }

	// RVA: 0xB6E57C Offset: 0xB6E57C VA: 0xB6E57C Slot: 8
	public uint get_Uid() { }

	// RVA: 0xB6E584 Offset: 0xB6E584 VA: 0xB6E584
	public void set_Uid(uint value) { }

	// RVA: 0xB6E5B0 Offset: 0xB6E5B0 VA: 0xB6E5B0
	public uint get_CurrentSeasonID() { }

	// RVA: 0xB6E5B8 Offset: 0xB6E5B8 VA: 0xB6E5B8
	public void set_CurrentSeasonID(uint value) { }

	// RVA: 0xB6E5E4 Offset: 0xB6E5E4 VA: 0xB6E5E4
	public uint get_ShowCharacterId() { }

	// RVA: 0xB6E5EC Offset: 0xB6E5EC VA: 0xB6E5EC
	public void set_ShowCharacterId(uint value) { }

	// RVA: 0xB6E618 Offset: 0xB6E618 VA: 0xB6E618
	public long get_ServerTimeZone() { }

	// RVA: 0xB6E620 Offset: 0xB6E620 VA: 0xB6E620
	public void set_ServerTimeZone(long value) { }

	[CompilerGeneratedAttribute] // RVA: 0x647260 Offset: 0x647260 VA: 0x647260
	// RVA: 0xB6E668 Offset: 0xB6E668 VA: 0xB6E668
	public void add_OnDataChange(Action value) { }

	[CompilerGeneratedAttribute] // RVA: 0x647270 Offset: 0x647270 VA: 0x647270
	// RVA: 0xB6E774 Offset: 0xB6E774 VA: 0xB6E774
	public void remove_OnDataChange(Action value) { }

	[CompilerGeneratedAttribute] // RVA: 0x647280 Offset: 0x647280 VA: 0x647280
	// RVA: 0xB6E880 Offset: 0xB6E880 VA: 0xB6E880
	public void add_OnBattleStatChange(Action<string, string, long> value) { }

	[CompilerGeneratedAttribute] // RVA: 0x647290 Offset: 0x647290 VA: 0x647290
	// RVA: 0xB6E98C Offset: 0xB6E98C VA: 0xB6E98C
	public void remove_OnBattleStatChange(Action<string, string, long> value) { }

	// RVA: 0xB6EA98 Offset: 0xB6EA98 VA: 0xB6EA98
	public void Reset(uint uid, client.role_data data) { }

	// RVA: 0xB6F6AC Offset: 0xB6F6AC VA: 0xB6F6AC
	private void ResetUnlockedCharacters(List<client.Character> characters) { }

	// RVA: 0xB6F50C Offset: 0xB6F50C VA: 0xB6F50C
	private void RefillGlobalStats(List<client.Stat> stats) { }

	// RVA: 0xB6F858 Offset: 0xB6F858 VA: 0xB6F858
	public void UpdateGlobalStat(string key, long value) { }

	// RVA: 0xB6F8F4 Offset: 0xB6F8F4 VA: 0xB6F8F4
	public void UpdateBattleStat(string battle_type, string key, long val) { }

	// RVA: 0xB6F988 Offset: 0xB6F988 VA: 0xB6F988
	public bool IsNewPlayer() { }

	// RVA: 0xB6F9A4 Offset: 0xB6F9A4 VA: 0xB6F9A4 Slot: 9
	public long GetStat(string key) { }

	// RVA: 0xB6FA54 Offset: 0xB6FA54 VA: 0xB6FA54
	public long GetBattleVal(string battleType, string key) { }

	// RVA: 0xB6FF30 Offset: 0xB6FF30 VA: 0xB6FF30
	public bool CopyBattleStatTo(string battleType, Dictionary<string, int> target) { }

	// RVA: 0xB70244 Offset: 0xB70244 VA: 0xB70244
	public void AddBindedVendor(string vendorName, string name, string avatar) { }

	// RVA: 0xB70338 Offset: 0xB70338 VA: 0xB70338
	public void Logout() { }

	// RVA: 0xB703CC Offset: 0xB703CC VA: 0xB703CC
	public string get_RegionName() { }

	// RVA: 0xB703D4 Offset: 0xB703D4 VA: 0xB703D4
	public void set_RegionName(string value) { }

	// RVA: 0xB70418 Offset: 0xB70418 VA: 0xB70418
	public string get_IconUrl() { }

	// RVA: 0xB6F814 Offset: 0xB6F814 VA: 0xB6F814
	public void set_IconUrl(string value) { }

	// RVA: 0xB70420 Offset: 0xB70420 VA: 0xB70420
	public void .ctor() { }
}

} // namespace FGame
