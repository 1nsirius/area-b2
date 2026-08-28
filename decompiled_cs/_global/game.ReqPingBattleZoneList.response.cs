// Namespace: 
public class game.ReqPingBattleZoneList.response : SprotoTypeBase // TypeDefIndex: 9281
{
	// Fields
	private static int max_field_count; // 0x0
	private long _errorcode; // 0x18
	private List<game.BattleZone> _battle_zones; // 0x20

	// Properties
	public long errorcode { get; set; }
	public bool HasErrorcode { get; }
	public List<game.BattleZone> battle_zones { get; set; }
	public bool HasBattle_zones { get; }

	// Methods

	// RVA: 0x255E3F4 Offset: 0x255E3F4 VA: 0x255E3F4
	public long get_errorcode() { }

	// RVA: 0x255E3FC Offset: 0x255E3FC VA: 0x255E3FC
	public void set_errorcode(long value) { }

	// RVA: 0x255E440 Offset: 0x255E440 VA: 0x255E440
	public bool get_HasErrorcode() { }

	// RVA: 0x255E470 Offset: 0x255E470 VA: 0x255E470
	public List<game.BattleZone> get_battle_zones() { }

	// RVA: 0x255E478 Offset: 0x255E478 VA: 0x255E478
	public void set_battle_zones(List<game.BattleZone> value) { }

	// RVA: 0x255E4B8 Offset: 0x255E4B8 VA: 0x255E4B8
	public bool get_HasBattle_zones() { }

	// RVA: 0x255E4E8 Offset: 0x255E4E8 VA: 0x255E4E8
	public void .ctor() { }

	// RVA: 0x255E584 Offset: 0x255E584 VA: 0x255E584
	public void .ctor(byte[] buffer) { }

	// RVA: 0x255E63C Offset: 0x255E63C VA: 0x255E63C Slot: 5
	protected override void decode() { }

	// RVA: 0x255E75C Offset: 0x255E75C VA: 0x255E75C Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x255E8BC Offset: 0x255E8BC VA: 0x255E8BC Slot: 3
	public override string ToString() { }

	// RVA: 0x255E96C Offset: 0x255E96C VA: 0x255E96C
	private static void .cctor() { }
}
