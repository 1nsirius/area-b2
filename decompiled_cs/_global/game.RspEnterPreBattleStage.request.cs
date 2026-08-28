// Namespace: 
public class game.RspEnterPreBattleStage.request : SprotoTypeBase // TypeDefIndex: 9343
{
	// Fields
	private static int max_field_count; // 0x0
	private long _uid; // 0x18
	private bool _success; // 0x20
	private long _stage; // 0x28

	// Properties
	public long uid { get; set; }
	public bool HasUid { get; }
	public bool success { get; set; }
	public bool HasSuccess { get; }
	public long stage { get; set; }
	public bool HasStage { get; }

	// Methods

	// RVA: 0x225EF58 Offset: 0x225EF58 VA: 0x225EF58
	public long get_uid() { }

	// RVA: 0x225EF60 Offset: 0x225EF60 VA: 0x225EF60
	public void set_uid(long value) { }

	// RVA: 0x225EFA4 Offset: 0x225EFA4 VA: 0x225EFA4
	public bool get_HasUid() { }

	// RVA: 0x225EFD4 Offset: 0x225EFD4 VA: 0x225EFD4
	public bool get_success() { }

	// RVA: 0x225EFDC Offset: 0x225EFDC VA: 0x225EFDC
	public void set_success(bool value) { }

	// RVA: 0x225F01C Offset: 0x225F01C VA: 0x225F01C
	public bool get_HasSuccess() { }

	// RVA: 0x225F04C Offset: 0x225F04C VA: 0x225F04C
	public long get_stage() { }

	// RVA: 0x225F054 Offset: 0x225F054 VA: 0x225F054
	public void set_stage(long value) { }

	// RVA: 0x225F098 Offset: 0x225F098 VA: 0x225F098
	public bool get_HasStage() { }

	// RVA: 0x225F0C8 Offset: 0x225F0C8 VA: 0x225F0C8
	public void .ctor() { }

	// RVA: 0x225F164 Offset: 0x225F164 VA: 0x225F164
	public void .ctor(byte[] buffer) { }

	// RVA: 0x225F21C Offset: 0x225F21C VA: 0x225F21C Slot: 5
	protected override void decode() { }

	// RVA: 0x225F33C Offset: 0x225F33C VA: 0x225F33C Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x225F4C0 Offset: 0x225F4C0 VA: 0x225F4C0 Slot: 3
	public override string ToString() { }

	// RVA: 0x225F5A0 Offset: 0x225F5A0 VA: 0x225F5A0
	private static void .cctor() { }
}
