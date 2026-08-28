// Namespace: 
public class game.RspPingBattleZoneList.request : SprotoTypeBase // TypeDefIndex: 9361
{
	// Fields
	private static int max_field_count; // 0x0
	private List<game.BattleZone> _battle_zones; // 0x14

	// Properties
	public List<game.BattleZone> battle_zones { get; set; }
	public bool HasBattle_zones { get; }

	// Methods

	// RVA: 0x22621EC Offset: 0x22621EC VA: 0x22621EC
	public List<game.BattleZone> get_battle_zones() { }

	// RVA: 0x22621F4 Offset: 0x22621F4 VA: 0x22621F4
	public void set_battle_zones(List<game.BattleZone> value) { }

	// RVA: 0x2262234 Offset: 0x2262234 VA: 0x2262234
	public bool get_HasBattle_zones() { }

	// RVA: 0x2262264 Offset: 0x2262264 VA: 0x2262264
	public void .ctor() { }

	// RVA: 0x2262300 Offset: 0x2262300 VA: 0x2262300
	public void .ctor(byte[] buffer) { }

	// RVA: 0x22623B8 Offset: 0x22623B8 VA: 0x22623B8 Slot: 5
	protected override void decode() { }

	// RVA: 0x2262484 Offset: 0x2262484 VA: 0x2262484 Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x226257C Offset: 0x226257C VA: 0x226257C Slot: 3
	public override string ToString() { }

	// RVA: 0x226260C Offset: 0x226260C VA: 0x226260C
	private static void .cctor() { }
}
