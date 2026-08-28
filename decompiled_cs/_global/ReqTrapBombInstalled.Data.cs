// Namespace: 
public class ReqTrapBombInstalled.Data // TypeDefIndex: 8142
{
	// Fields
	public u64 trap_bomb_uid; // 0x8
	public u32 block_id; // 0xC
	public Vector3 bomb_pos; // 0x10
	public Quaternion bomb_rot; // 0x14
	public Vector3 bomb_extens; // 0x18
	public Vector3 trigger_pos; // 0x1C
	public Vector3 trigger_extens; // 0x20
	public enum_type<TrapBombInstallType, u8> install_type; // 0x24

	// Methods

	// RVA: 0x17BEE6C Offset: 0x17BEE6C VA: 0x17BEE6C
	public void .ctor() { }
}
