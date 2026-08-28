// Namespace: 
public class team.create_team_req.request : SprotoTypeBase // TypeDefIndex: 9467
{
	// Fields
	private static int max_field_count; // 0x0
	private long _battle_zone; // 0x18
	private long _combat_type; // 0x20

	// Properties
	public long battle_zone { get; set; }
	public bool HasBattle_zone { get; }
	public long combat_type { get; set; }
	public bool HasCombat_type { get; }

	// Methods

	// RVA: 0xD74CE0 Offset: 0xD74CE0 VA: 0xD74CE0
	public long get_battle_zone() { }

	// RVA: 0xD74CE8 Offset: 0xD74CE8 VA: 0xD74CE8
	public void set_battle_zone(long value) { }

	// RVA: 0xD74D2C Offset: 0xD74D2C VA: 0xD74D2C
	public bool get_HasBattle_zone() { }

	// RVA: 0xD74D5C Offset: 0xD74D5C VA: 0xD74D5C
	public long get_combat_type() { }

	// RVA: 0xD74D64 Offset: 0xD74D64 VA: 0xD74D64
	public void set_combat_type(long value) { }

	// RVA: 0xD74DA8 Offset: 0xD74DA8 VA: 0xD74DA8
	public bool get_HasCombat_type() { }

	// RVA: 0xD74DD8 Offset: 0xD74DD8 VA: 0xD74DD8
	public void .ctor() { }

	// RVA: 0xD74E74 Offset: 0xD74E74 VA: 0xD74E74
	public void .ctor(byte[] buffer) { }

	// RVA: 0xD74F2C Offset: 0xD74F2C VA: 0xD74F2C Slot: 5
	protected override void decode() { }

	// RVA: 0xD75008 Offset: 0xD75008 VA: 0xD75008 Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0xD7512C Offset: 0xD7512C VA: 0xD7512C Slot: 3
	public override string ToString() { }

	// RVA: 0xD751DC Offset: 0xD751DC VA: 0xD751DC
	private static void .cctor() { }
}
