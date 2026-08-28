// Namespace: 
public class RspBattleRoundResult.Data // TypeDefIndex: 8080
{
	// Fields
	public u8 round; // 0x8
	public boolean result; // 0xC
	public enum_type<BattleGameOverReason, u8> reason; // 0x10
	public u8 replay_bid; // 0x14
	public u8 replay_dead; // 0x18
	public u64 replay_item_uid; // 0x1C
	public Vector3 replay_item_pos; // 0x20
	public enum_type<ReplayMode, u8> replay_mode; // 0x24

	// Methods

	// RVA: 0x17CDBA4 Offset: 0x17CDBA4 VA: 0x17CDBA4
	public void .ctor() { }
}
