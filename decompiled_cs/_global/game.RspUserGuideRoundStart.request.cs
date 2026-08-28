// Namespace: 
public class game.RspUserGuideRoundStart.request : SprotoTypeBase // TypeDefIndex: 9393
{
	// Fields
	private static int max_field_count; // 0x0
	private long _round; // 0x18
	private long _map_id; // 0x20
	private long _mode_id; // 0x28
	private long _wait_time; // 0x30
	private long _team; // 0x38
	private long _camp; // 0x40

	// Properties
	public long round { get; set; }
	public bool HasRound { get; }
	public long map_id { get; set; }
	public bool HasMap_id { get; }
	public long mode_id { get; set; }
	public bool HasMode_id { get; }
	public long wait_time { get; set; }
	public bool HasWait_time { get; }
	public long team { get; set; }
	public bool HasTeam { get; }
	public long camp { get; set; }
	public bool HasCamp { get; }

	// Methods

	// RVA: 0x226875C Offset: 0x226875C VA: 0x226875C
	public long get_round() { }

	// RVA: 0x2268764 Offset: 0x2268764 VA: 0x2268764
	public void set_round(long value) { }

	// RVA: 0x22687A8 Offset: 0x22687A8 VA: 0x22687A8
	public bool get_HasRound() { }

	// RVA: 0x22687D8 Offset: 0x22687D8 VA: 0x22687D8
	public long get_map_id() { }

	// RVA: 0x22687E0 Offset: 0x22687E0 VA: 0x22687E0
	public void set_map_id(long value) { }

	// RVA: 0x2268824 Offset: 0x2268824 VA: 0x2268824
	public bool get_HasMap_id() { }

	// RVA: 0x2268854 Offset: 0x2268854 VA: 0x2268854
	public long get_mode_id() { }

	// RVA: 0x226885C Offset: 0x226885C VA: 0x226885C
	public void set_mode_id(long value) { }

	// RVA: 0x22688A0 Offset: 0x22688A0 VA: 0x22688A0
	public bool get_HasMode_id() { }

	// RVA: 0x22688D0 Offset: 0x22688D0 VA: 0x22688D0
	public long get_wait_time() { }

	// RVA: 0x22688D8 Offset: 0x22688D8 VA: 0x22688D8
	public void set_wait_time(long value) { }

	// RVA: 0x226891C Offset: 0x226891C VA: 0x226891C
	public bool get_HasWait_time() { }

	// RVA: 0x226894C Offset: 0x226894C VA: 0x226894C
	public long get_team() { }

	// RVA: 0x2268954 Offset: 0x2268954 VA: 0x2268954
	public void set_team(long value) { }

	// RVA: 0x2268998 Offset: 0x2268998 VA: 0x2268998
	public bool get_HasTeam() { }

	// RVA: 0x22689C8 Offset: 0x22689C8 VA: 0x22689C8
	public long get_camp() { }

	// RVA: 0x22689D0 Offset: 0x22689D0 VA: 0x22689D0
	public void set_camp(long value) { }

	// RVA: 0x2268A14 Offset: 0x2268A14 VA: 0x2268A14
	public bool get_HasCamp() { }

	// RVA: 0x2268A44 Offset: 0x2268A44 VA: 0x2268A44
	public void .ctor() { }

	// RVA: 0x2268AE0 Offset: 0x2268AE0 VA: 0x2268AE0
	public void .ctor(byte[] buffer) { }

	// RVA: 0x2268B98 Offset: 0x2268B98 VA: 0x2268B98 Slot: 5
	protected override void decode() { }

	// RVA: 0x2268D64 Offset: 0x2268D64 VA: 0x2268D64 Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x2269018 Offset: 0x2269018 VA: 0x2269018 Slot: 3
	public override string ToString() { }

	// RVA: 0x2269380 Offset: 0x2269380 VA: 0x2269380
	private static void .cctor() { }
}
