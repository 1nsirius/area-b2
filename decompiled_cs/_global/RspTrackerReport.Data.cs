// Namespace: 
public class RspTrackerReport.Data // TypeDefIndex: 8114
{
	// Fields
	public u8 errcode; // 0x8
	public u8 bid; // 0xC
	public u8 listener_bid; // 0x10
	public u32 elapse; // 0x14
	public u8 remain_times; // 0x18
	public Vector3 pos; // 0x1C
	public enum_type<MarkType, u8> mark_type; // 0x20

	// Methods

	// RVA: 0x10C9944 Offset: 0x10C9944 VA: 0x10C9944
	public void .ctor() { }
}
