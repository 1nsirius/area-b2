// Namespace: 
public class team.match_success_notify.request : SprotoTypeBase // TypeDefIndex: 9480
{
	// Fields
	private static int max_field_count; // 0x0
	private long _timeout_second; // 0x18
	private List<team.MatchConfirmPlayerInfo> _blue_players; // 0x20
	private List<team.MatchConfirmPlayerInfo> _orange_players; // 0x24

	// Properties
	public long timeout_second { get; set; }
	public bool HasTimeout_second { get; }
	public List<team.MatchConfirmPlayerInfo> blue_players { get; set; }
	public bool HasBlue_players { get; }
	public List<team.MatchConfirmPlayerInfo> orange_players { get; set; }
	public bool HasOrange_players { get; }

	// Methods

	// RVA: 0xD76F7C Offset: 0xD76F7C VA: 0xD76F7C
	public long get_timeout_second() { }

	// RVA: 0xD76F84 Offset: 0xD76F84 VA: 0xD76F84
	public void set_timeout_second(long value) { }

	// RVA: 0xD76FC8 Offset: 0xD76FC8 VA: 0xD76FC8
	public bool get_HasTimeout_second() { }

	// RVA: 0xD76FF8 Offset: 0xD76FF8 VA: 0xD76FF8
	public List<team.MatchConfirmPlayerInfo> get_blue_players() { }

	// RVA: 0xD77000 Offset: 0xD77000 VA: 0xD77000
	public void set_blue_players(List<team.MatchConfirmPlayerInfo> value) { }

	// RVA: 0xD77040 Offset: 0xD77040 VA: 0xD77040
	public bool get_HasBlue_players() { }

	// RVA: 0xD77070 Offset: 0xD77070 VA: 0xD77070
	public List<team.MatchConfirmPlayerInfo> get_orange_players() { }

	// RVA: 0xD77078 Offset: 0xD77078 VA: 0xD77078
	public void set_orange_players(List<team.MatchConfirmPlayerInfo> value) { }

	// RVA: 0xD770B8 Offset: 0xD770B8 VA: 0xD770B8
	public bool get_HasOrange_players() { }

	// RVA: 0xD770E8 Offset: 0xD770E8 VA: 0xD770E8
	public void .ctor() { }

	// RVA: 0xD77184 Offset: 0xD77184 VA: 0xD77184
	public void .ctor(byte[] buffer) { }

	// RVA: 0xD7723C Offset: 0xD7723C VA: 0xD7723C Slot: 5
	protected override void decode() { }

	// RVA: 0xD773AC Offset: 0xD773AC VA: 0xD773AC Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0xD77570 Offset: 0xD77570 VA: 0xD77570 Slot: 3
	public override string ToString() { }

	// RVA: 0xD7763C Offset: 0xD7763C VA: 0xD7763C
	private static void .cctor() { }
}
