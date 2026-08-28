// Namespace: 
public class team.TeamData : SprotoTypeBase // TypeDefIndex: 9457
{
	// Fields
	private static int max_field_count; // 0x0
	private string _team_id; // 0x14
	private List<team.TeamMember> _members; // 0x18
	private long _captain_index; // 0x20
	private long _capacity; // 0x28
	private long _battle_zone; // 0x30
	private long _combat_type; // 0x38
	private long _min_rank_limit; // 0x40
	private long _max_rank_limit; // 0x48

	// Properties
	public string team_id { get; set; }
	public bool HasTeam_id { get; }
	public List<team.TeamMember> members { get; set; }
	public bool HasMembers { get; }
	public long captain_index { get; set; }
	public bool HasCaptain_index { get; }
	public long capacity { get; set; }
	public bool HasCapacity { get; }
	public long battle_zone { get; set; }
	public bool HasBattle_zone { get; }
	public long combat_type { get; set; }
	public bool HasCombat_type { get; }
	public long min_rank_limit { get; set; }
	public bool HasMin_rank_limit { get; }
	public long max_rank_limit { get; set; }
	public bool HasMax_rank_limit { get; }

	// Methods

	// RVA: 0xD716BC Offset: 0xD716BC VA: 0xD716BC
	public string get_team_id() { }

	// RVA: 0xD716C4 Offset: 0xD716C4 VA: 0xD716C4
	public void set_team_id(string value) { }

	// RVA: 0xD71704 Offset: 0xD71704 VA: 0xD71704
	public bool get_HasTeam_id() { }

	// RVA: 0xD71734 Offset: 0xD71734 VA: 0xD71734
	public List<team.TeamMember> get_members() { }

	// RVA: 0xD7173C Offset: 0xD7173C VA: 0xD7173C
	public void set_members(List<team.TeamMember> value) { }

	// RVA: 0xD7177C Offset: 0xD7177C VA: 0xD7177C
	public bool get_HasMembers() { }

	// RVA: 0xD717AC Offset: 0xD717AC VA: 0xD717AC
	public long get_captain_index() { }

	// RVA: 0xD717B4 Offset: 0xD717B4 VA: 0xD717B4
	public void set_captain_index(long value) { }

	// RVA: 0xD717F8 Offset: 0xD717F8 VA: 0xD717F8
	public bool get_HasCaptain_index() { }

	// RVA: 0xD71828 Offset: 0xD71828 VA: 0xD71828
	public long get_capacity() { }

	// RVA: 0xD71830 Offset: 0xD71830 VA: 0xD71830
	public void set_capacity(long value) { }

	// RVA: 0xD71874 Offset: 0xD71874 VA: 0xD71874
	public bool get_HasCapacity() { }

	// RVA: 0xD718A4 Offset: 0xD718A4 VA: 0xD718A4
	public long get_battle_zone() { }

	// RVA: 0xD718AC Offset: 0xD718AC VA: 0xD718AC
	public void set_battle_zone(long value) { }

	// RVA: 0xD718F0 Offset: 0xD718F0 VA: 0xD718F0
	public bool get_HasBattle_zone() { }

	// RVA: 0xD71920 Offset: 0xD71920 VA: 0xD71920
	public long get_combat_type() { }

	// RVA: 0xD71928 Offset: 0xD71928 VA: 0xD71928
	public void set_combat_type(long value) { }

	// RVA: 0xD7196C Offset: 0xD7196C VA: 0xD7196C
	public bool get_HasCombat_type() { }

	// RVA: 0xD7199C Offset: 0xD7199C VA: 0xD7199C
	public long get_min_rank_limit() { }

	// RVA: 0xD719A4 Offset: 0xD719A4 VA: 0xD719A4
	public void set_min_rank_limit(long value) { }

	// RVA: 0xD719E8 Offset: 0xD719E8 VA: 0xD719E8
	public bool get_HasMin_rank_limit() { }

	// RVA: 0xD71A18 Offset: 0xD71A18 VA: 0xD71A18
	public long get_max_rank_limit() { }

	// RVA: 0xD71A20 Offset: 0xD71A20 VA: 0xD71A20
	public void set_max_rank_limit(long value) { }

	// RVA: 0xD71A64 Offset: 0xD71A64 VA: 0xD71A64
	public bool get_HasMax_rank_limit() { }

	// RVA: 0xD71A94 Offset: 0xD71A94 VA: 0xD71A94
	public void .ctor() { }

	// RVA: 0xD71B30 Offset: 0xD71B30 VA: 0xD71B30
	public void .ctor(byte[] buffer) { }

	// RVA: 0xD71BE8 Offset: 0xD71BE8 VA: 0xD71BE8 Slot: 5
	protected override void decode() { }

	// RVA: 0xD71E64 Offset: 0xD71E64 VA: 0xD71E64 Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0xD72214 Offset: 0xD72214 VA: 0xD72214 Slot: 3
	public override string ToString() { }

	// RVA: 0xD7263C Offset: 0xD7263C VA: 0xD7263C
	private static void .cctor() { }
}
