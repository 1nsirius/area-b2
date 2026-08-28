// Namespace: 
public class team.team_match_punish_notify.request : SprotoTypeBase // TypeDefIndex: 9500
{
	// Fields
	private static int max_field_count; // 0x0
	private long _punish_timeout; // 0x18
	private long _combat_type; // 0x20
	private long _punish_battle_cnt; // 0x28

	// Properties
	public long punish_timeout { get; set; }
	public bool HasPunish_timeout { get; }
	public long combat_type { get; set; }
	public bool HasCombat_type { get; }
	public long punish_battle_cnt { get; set; }
	public bool HasPunish_battle_cnt { get; }

	// Methods

	// RVA: 0xD79F7C Offset: 0xD79F7C VA: 0xD79F7C
	public long get_punish_timeout() { }

	// RVA: 0xD79F84 Offset: 0xD79F84 VA: 0xD79F84
	public void set_punish_timeout(long value) { }

	// RVA: 0xD79FC8 Offset: 0xD79FC8 VA: 0xD79FC8
	public bool get_HasPunish_timeout() { }

	// RVA: 0xD79FF8 Offset: 0xD79FF8 VA: 0xD79FF8
	public long get_combat_type() { }

	// RVA: 0xD7A000 Offset: 0xD7A000 VA: 0xD7A000
	public void set_combat_type(long value) { }

	// RVA: 0xD7A044 Offset: 0xD7A044 VA: 0xD7A044
	public bool get_HasCombat_type() { }

	// RVA: 0xD7A074 Offset: 0xD7A074 VA: 0xD7A074
	public long get_punish_battle_cnt() { }

	// RVA: 0xD7A07C Offset: 0xD7A07C VA: 0xD7A07C
	public void set_punish_battle_cnt(long value) { }

	// RVA: 0xD7A0C0 Offset: 0xD7A0C0 VA: 0xD7A0C0
	public bool get_HasPunish_battle_cnt() { }

	// RVA: 0xD7A0F0 Offset: 0xD7A0F0 VA: 0xD7A0F0
	public void .ctor() { }

	// RVA: 0xD7A18C Offset: 0xD7A18C VA: 0xD7A18C
	public void .ctor(byte[] buffer) { }

	// RVA: 0xD7A244 Offset: 0xD7A244 VA: 0xD7A244 Slot: 5
	protected override void decode() { }

	// RVA: 0xD7A368 Offset: 0xD7A368 VA: 0xD7A368 Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0xD7A4F0 Offset: 0xD7A4F0 VA: 0xD7A4F0 Slot: 3
	public override string ToString() { }

	// RVA: 0xD7A5C8 Offset: 0xD7A5C8 VA: 0xD7A5C8
	private static void .cctor() { }
}
