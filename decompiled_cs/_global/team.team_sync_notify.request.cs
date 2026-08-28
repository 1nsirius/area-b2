// Namespace: 
public class team.team_sync_notify.request : SprotoTypeBase // TypeDefIndex: 9511
{
	// Fields
	private static int max_field_count; // 0x0
	private team.TeamData _team_data; // 0x14

	// Properties
	public team.TeamData team_data { get; set; }
	public bool HasTeam_data { get; }

	// Methods

	// RVA: 0xD7BBA8 Offset: 0xD7BBA8 VA: 0xD7BBA8
	public team.TeamData get_team_data() { }

	// RVA: 0xD7BBB0 Offset: 0xD7BBB0 VA: 0xD7BBB0
	public void set_team_data(team.TeamData value) { }

	// RVA: 0xD7BBF0 Offset: 0xD7BBF0 VA: 0xD7BBF0
	public bool get_HasTeam_data() { }

	// RVA: 0xD7BC20 Offset: 0xD7BC20 VA: 0xD7BC20
	public void .ctor() { }

	// RVA: 0xD7BCBC Offset: 0xD7BCBC VA: 0xD7BCBC
	public void .ctor(byte[] buffer) { }

	// RVA: 0xD7BD74 Offset: 0xD7BD74 VA: 0xD7BD74 Slot: 5
	protected override void decode() { }

	// RVA: 0xD7BE40 Offset: 0xD7BE40 VA: 0xD7BE40 Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0xD7BEF0 Offset: 0xD7BEF0 VA: 0xD7BEF0 Slot: 3
	public override string ToString() { }

	// RVA: 0xD7BF58 Offset: 0xD7BF58 VA: 0xD7BF58
	private static void .cctor() { }
}
