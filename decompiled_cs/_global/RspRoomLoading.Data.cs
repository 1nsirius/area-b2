// Namespace: 
public class RspRoomLoading.Data // TypeDefIndex: 7642
{
	// Fields
	public enum_type<BattleTeam, u8> my_team; // 0x8
	public u32 combat_type; // 0xC
	public u32 map_id; // 0x10
	public u32 mode_id; // 0x14
	public u32 guide_id; // 0x18
	public vector<CharacterInfo> attacker; // 0x1C
	public vector<CharacterInfo> defender; // 0x20
	public u32 critical_region_id; // 0x24
	public u8 round; // 0x28

	// Methods

	// RVA: 0x17B1204 Offset: 0x17B1204 VA: 0x17B1204
	public void .ctor() { }
}
