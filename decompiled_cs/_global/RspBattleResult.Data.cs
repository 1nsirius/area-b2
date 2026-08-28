// Namespace: 
public class RspBattleResult.Data // TypeDefIndex: 7959
{
	// Fields
	public enum_type<BattleGameOverReason, u8> reason; // 0x8
	public enum_type<BattleCamp, u8> win_camp; // 0xC
	public u8 replay_bid; // 0x10
	public vector<u32> winners_rank; // 0x14

	// Methods

	// RVA: 0x17CD14C Offset: 0x17CD14C VA: 0x17CD14C
	public void .ctor() { }
}
