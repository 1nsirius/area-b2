// Namespace: 
public class RspPlaceToolOperator.Data // TypeDefIndex: 8316
{
	// Fields
	public u8 bid; // 0x8
	public u32 hand_item_id; // 0xC
	public vector<u64> relevant_id; // 0x10
	public u64 affected_id; // 0x14
	public f32 duration; // 0x18
	public enum_type<OperateState, u8> state; // 0x1C
	public LerpData lerp_data; // 0x20

	// Methods

	// RVA: 0x17A8CB4 Offset: 0x17A8CB4 VA: 0x17A8CB4
	public void .ctor() { }
}
