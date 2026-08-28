namespace FGame
{

// Namespace: FGame
[LuaCallCSharpAttribute] // RVA: 0x553E04 Offset: 0x553E04 VA: 0x553E04
public class BattleZoneData : BaseSingleton<BattleZoneData> // TypeDefIndex: 9888
{
	// Fields
	private readonly Dictionary<uint, BattleZoneData.BattleZoneInfo> mPingValDict; // 0x8
	private uint mSelectedBattleZone; // 0xC
	[CompilerGeneratedAttribute] // RVA: 0x5634A4 Offset: 0x5634A4 VA: 0x5634A4
	private Action<uint> OnBattleZoneIdChange; // 0x10
	[CompilerGeneratedAttribute] // RVA: 0x5634B4 Offset: 0x5634B4 VA: 0x5634B4
	private Action<bool> OnAutoSelectChange; // 0x14
	[CompilerGeneratedAttribute] // RVA: 0x5634C4 Offset: 0x5634C4 VA: 0x5634C4
	private bool <AutoSelect>k__BackingField; // 0x18

	// Properties
	public int Count { get; }
	public bool AutoSelect { get; set; }
	public uint SelectedBattleZone { get; set; }

	// Methods

	[CompilerGeneratedAttribute] // RVA: 0x646D40 Offset: 0x646D40 VA: 0x646D40
	// RVA: 0xBEB74C Offset: 0xBEB74C VA: 0xBEB74C
	public void add_OnBattleZoneIdChange(Action<uint> value) { }

	[CompilerGeneratedAttribute] // RVA: 0x646D50 Offset: 0x646D50 VA: 0x646D50
	// RVA: 0xBEB858 Offset: 0xBEB858 VA: 0xBEB858
	public void remove_OnBattleZoneIdChange(Action<uint> value) { }

	[CompilerGeneratedAttribute] // RVA: 0x646D60 Offset: 0x646D60 VA: 0x646D60
	// RVA: 0xBEB964 Offset: 0xBEB964 VA: 0xBEB964
	public void add_OnAutoSelectChange(Action<bool> value) { }

	[CompilerGeneratedAttribute] // RVA: 0x646D70 Offset: 0x646D70 VA: 0x646D70
	// RVA: 0xBEBA70 Offset: 0xBEBA70 VA: 0xBEBA70
	public void remove_OnAutoSelectChange(Action<bool> value) { }

	// RVA: 0xBEBB7C Offset: 0xBEBB7C VA: 0xBEBB7C
	public int get_Count() { }

	// RVA: 0xBEBBF4 Offset: 0xBEBBF4 VA: 0xBEBBF4
	public List<uint> GetBattleZoneIdList() { }

	[CompilerGeneratedAttribute] // RVA: 0x646D80 Offset: 0x646D80 VA: 0x646D80
	// RVA: 0xBEBDF0 Offset: 0xBEBDF0 VA: 0xBEBDF0
	public bool get_AutoSelect() { }

	[CompilerGeneratedAttribute] // RVA: 0x646D90 Offset: 0x646D90 VA: 0x646D90
	// RVA: 0xBEBDF8 Offset: 0xBEBDF8 VA: 0xBEBDF8
	private void set_AutoSelect(bool value) { }

	// RVA: 0xBEBE00 Offset: 0xBEBE00 VA: 0xBEBE00
	public uint get_SelectedBattleZone() { }

	// RVA: 0xBEBE08 Offset: 0xBEBE08 VA: 0xBEBE08
	private void set_SelectedBattleZone(uint value) { }

	// RVA: 0xBEBF0C Offset: 0xBEBF0C VA: 0xBEBF0C
	public void Foreach(Action<BattleZoneData.BattleZoneInfo> action) { }

	// RVA: 0xBEC0A8 Offset: 0xBEC0A8 VA: 0xBEC0A8
	public void ResetBattleZones(BattleZoneData.BattleZoneInfo[] infos) { }

	// RVA: 0xBEC4B4 Offset: 0xBEC4B4 VA: 0xBEC4B4
	public void Init(bool auto, uint battleZoneId) { }

	// RVA: 0xBEC4C0 Offset: 0xBEC4C0 VA: 0xBEC4C0
	public void SetAutoSelect(bool auto) { }

	// RVA: 0xBEC598 Offset: 0xBEC598 VA: 0xBEC598
	public int GetPingVal(uint battleZone) { }

	// RVA: 0xBEC654 Offset: 0xBEC654 VA: 0xBEC654
	public BattleZoneData.BattleZoneInfo GetBattleZoneInfo(uint battleZone) { }

	// RVA: 0xBEC6F4 Offset: 0xBEC6F4 VA: 0xBEC6F4
	public void SetPingVal(uint battleZone, int ping) { }

	// RVA: 0xBEC828 Offset: 0xBEC828 VA: 0xBEC828
	public void SetBattleZoneId(uint battleZone) { }

	// RVA: 0xBEC2FC Offset: 0xBEC2FC VA: 0xBEC2FC
	private void SelectFirstZone() { }

	// RVA: 0xBEC564 Offset: 0xBEC564 VA: 0xBEC564
	private void AutoSelectMinBatleZone() { }

	// RVA: 0xBEC82C Offset: 0xBEC82C VA: 0xBEC82C
	private uint GetMinBattleZoneId() { }

	// RVA: 0xBECA44 Offset: 0xBECA44 VA: 0xBECA44
	public void .ctor() { }
}

} // namespace FGame
