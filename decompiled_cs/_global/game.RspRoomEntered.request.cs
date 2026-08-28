// Namespace: 
public class game.RspRoomEntered.request : SprotoTypeBase // TypeDefIndex: 9371
{
	// Fields
	private static int max_field_count; // 0x0
	private long _room_id; // 0x18
	private long _owner_id; // 0x20
	private List<game.PlayerInfo> _players; // 0x28
	private long _battle_zone; // 0x30
	private long _map_id; // 0x38
	private long _mode_id; // 0x40

	// Properties
	public long room_id { get; set; }
	public bool HasRoom_id { get; }
	public long owner_id { get; set; }
	public bool HasOwner_id { get; }
	public List<game.PlayerInfo> players { get; set; }
	public bool HasPlayers { get; }
	public long battle_zone { get; set; }
	public bool HasBattle_zone { get; }
	public long map_id { get; set; }
	public bool HasMap_id { get; }
	public long mode_id { get; set; }
	public bool HasMode_id { get; }

	// Methods

	// RVA: 0x2263958 Offset: 0x2263958 VA: 0x2263958
	public long get_room_id() { }

	// RVA: 0x2263960 Offset: 0x2263960 VA: 0x2263960
	public void set_room_id(long value) { }

	// RVA: 0x22639A4 Offset: 0x22639A4 VA: 0x22639A4
	public bool get_HasRoom_id() { }

	// RVA: 0x22639D4 Offset: 0x22639D4 VA: 0x22639D4
	public long get_owner_id() { }

	// RVA: 0x22639DC Offset: 0x22639DC VA: 0x22639DC
	public void set_owner_id(long value) { }

	// RVA: 0x2263A20 Offset: 0x2263A20 VA: 0x2263A20
	public bool get_HasOwner_id() { }

	// RVA: 0x2263A50 Offset: 0x2263A50 VA: 0x2263A50
	public List<game.PlayerInfo> get_players() { }

	// RVA: 0x2263A58 Offset: 0x2263A58 VA: 0x2263A58
	public void set_players(List<game.PlayerInfo> value) { }

	// RVA: 0x2263A98 Offset: 0x2263A98 VA: 0x2263A98
	public bool get_HasPlayers() { }

	// RVA: 0x2263AC8 Offset: 0x2263AC8 VA: 0x2263AC8
	public long get_battle_zone() { }

	// RVA: 0x2263AD0 Offset: 0x2263AD0 VA: 0x2263AD0
	public void set_battle_zone(long value) { }

	// RVA: 0x2263B14 Offset: 0x2263B14 VA: 0x2263B14
	public bool get_HasBattle_zone() { }

	// RVA: 0x2263B44 Offset: 0x2263B44 VA: 0x2263B44
	public long get_map_id() { }

	// RVA: 0x2263B4C Offset: 0x2263B4C VA: 0x2263B4C
	public void set_map_id(long value) { }

	// RVA: 0x2263B90 Offset: 0x2263B90 VA: 0x2263B90
	public bool get_HasMap_id() { }

	// RVA: 0x2263BC0 Offset: 0x2263BC0 VA: 0x2263BC0
	public long get_mode_id() { }

	// RVA: 0x2263BC8 Offset: 0x2263BC8 VA: 0x2263BC8
	public void set_mode_id(long value) { }

	// RVA: 0x2263C0C Offset: 0x2263C0C VA: 0x2263C0C
	public bool get_HasMode_id() { }

	// RVA: 0x2263C3C Offset: 0x2263C3C VA: 0x2263C3C
	public void .ctor() { }

	// RVA: 0x2263CD8 Offset: 0x2263CD8 VA: 0x2263CD8
	public void .ctor(byte[] buffer) { }

	// RVA: 0x2263D90 Offset: 0x2263D90 VA: 0x2263D90 Slot: 5
	protected override void decode() { }

	// RVA: 0x2263FA0 Offset: 0x2263FA0 VA: 0x2263FA0 Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x2264290 Offset: 0x2264290 VA: 0x2264290 Slot: 3
	public override string ToString() { }

	// RVA: 0x22645EC Offset: 0x22645EC VA: 0x22645EC
	private static void .cctor() { }
}
