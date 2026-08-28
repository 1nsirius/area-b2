// Namespace: 
public class client.role_data : SprotoTypeBase // TypeDefIndex: 9163
{
	// Fields
	private static int max_field_count; // 0x0
	private string _name; // 0x14
	private long _level; // 0x18
	private long _exp; // 0x20
	private List<client.Stat> _stats; // 0x28
	private long _icon; // 0x30
	private List<client.Money> _money; // 0x38
	private List<client.Character> _characters; // 0x3C
	private List<client.EventStat> _event_stats; // 0x40
	private List<client.Stat> _client_config; // 0x44
	private string _icon_url; // 0x48
	private long _time_zone; // 0x50
	private long _icon_frame; // 0x58
	private long _create_time; // 0x60
	private long _current_season_id; // 0x68
	private bool _is_active; // 0x70

	// Properties
	public string name { get; set; }
	public bool HasName { get; }
	public long level { get; set; }
	public bool HasLevel { get; }
	public long exp { get; set; }
	public bool HasExp { get; }
	public List<client.Stat> stats { get; set; }
	public bool HasStats { get; }
	public long icon { get; set; }
	public bool HasIcon { get; }
	public List<client.Money> money { get; set; }
	public bool HasMoney { get; }
	public List<client.Character> characters { get; set; }
	public bool HasCharacters { get; }
	public List<client.EventStat> event_stats { get; set; }
	public bool HasEvent_stats { get; }
	public List<client.Stat> client_config { get; set; }
	public bool HasClient_config { get; }
	public string icon_url { get; set; }
	public bool HasIcon_url { get; }
	public long time_zone { get; set; }
	public bool HasTime_zone { get; }
	public long icon_frame { get; set; }
	public bool HasIcon_frame { get; }
	public long create_time { get; set; }
	public bool HasCreate_time { get; }
	public long current_season_id { get; set; }
	public bool HasCurrent_season_id { get; }
	public bool is_active { get; set; }
	public bool HasIs_active { get; }

	// Methods

	// RVA: 0x244B2B8 Offset: 0x244B2B8 VA: 0x244B2B8
	public string get_name() { }

	// RVA: 0x244B2C0 Offset: 0x244B2C0 VA: 0x244B2C0
	public void set_name(string value) { }

	// RVA: 0x244B300 Offset: 0x244B300 VA: 0x244B300
	public bool get_HasName() { }

	// RVA: 0x244B330 Offset: 0x244B330 VA: 0x244B330
	public long get_level() { }

	// RVA: 0x244B338 Offset: 0x244B338 VA: 0x244B338
	public void set_level(long value) { }

	// RVA: 0x244B37C Offset: 0x244B37C VA: 0x244B37C
	public bool get_HasLevel() { }

	// RVA: 0x244B3AC Offset: 0x244B3AC VA: 0x244B3AC
	public long get_exp() { }

	// RVA: 0x244B3B4 Offset: 0x244B3B4 VA: 0x244B3B4
	public void set_exp(long value) { }

	// RVA: 0x244B3F8 Offset: 0x244B3F8 VA: 0x244B3F8
	public bool get_HasExp() { }

	// RVA: 0x244B428 Offset: 0x244B428 VA: 0x244B428
	public List<client.Stat> get_stats() { }

	// RVA: 0x244B430 Offset: 0x244B430 VA: 0x244B430
	public void set_stats(List<client.Stat> value) { }

	// RVA: 0x244B470 Offset: 0x244B470 VA: 0x244B470
	public bool get_HasStats() { }

	// RVA: 0x244B4A0 Offset: 0x244B4A0 VA: 0x244B4A0
	public long get_icon() { }

	// RVA: 0x244B4A8 Offset: 0x244B4A8 VA: 0x244B4A8
	public void set_icon(long value) { }

	// RVA: 0x244B4EC Offset: 0x244B4EC VA: 0x244B4EC
	public bool get_HasIcon() { }

	// RVA: 0x244B51C Offset: 0x244B51C VA: 0x244B51C
	public List<client.Money> get_money() { }

	// RVA: 0x244B524 Offset: 0x244B524 VA: 0x244B524
	public void set_money(List<client.Money> value) { }

	// RVA: 0x244B564 Offset: 0x244B564 VA: 0x244B564
	public bool get_HasMoney() { }

	// RVA: 0x244B594 Offset: 0x244B594 VA: 0x244B594
	public List<client.Character> get_characters() { }

	// RVA: 0x244B59C Offset: 0x244B59C VA: 0x244B59C
	public void set_characters(List<client.Character> value) { }

	// RVA: 0x244B5DC Offset: 0x244B5DC VA: 0x244B5DC
	public bool get_HasCharacters() { }

	// RVA: 0x244B60C Offset: 0x244B60C VA: 0x244B60C
	public List<client.EventStat> get_event_stats() { }

	// RVA: 0x244B614 Offset: 0x244B614 VA: 0x244B614
	public void set_event_stats(List<client.EventStat> value) { }

	// RVA: 0x244B654 Offset: 0x244B654 VA: 0x244B654
	public bool get_HasEvent_stats() { }

	// RVA: 0x244B684 Offset: 0x244B684 VA: 0x244B684
	public List<client.Stat> get_client_config() { }

	// RVA: 0x244B68C Offset: 0x244B68C VA: 0x244B68C
	public void set_client_config(List<client.Stat> value) { }

	// RVA: 0x244B6CC Offset: 0x244B6CC VA: 0x244B6CC
	public bool get_HasClient_config() { }

	// RVA: 0x244B6FC Offset: 0x244B6FC VA: 0x244B6FC
	public string get_icon_url() { }

	// RVA: 0x244B704 Offset: 0x244B704 VA: 0x244B704
	public void set_icon_url(string value) { }

	// RVA: 0x244B744 Offset: 0x244B744 VA: 0x244B744
	public bool get_HasIcon_url() { }

	// RVA: 0x244B774 Offset: 0x244B774 VA: 0x244B774
	public long get_time_zone() { }

	// RVA: 0x244B77C Offset: 0x244B77C VA: 0x244B77C
	public void set_time_zone(long value) { }

	// RVA: 0x244B7C0 Offset: 0x244B7C0 VA: 0x244B7C0
	public bool get_HasTime_zone() { }

	// RVA: 0x244B7F0 Offset: 0x244B7F0 VA: 0x244B7F0
	public long get_icon_frame() { }

	// RVA: 0x244B7F8 Offset: 0x244B7F8 VA: 0x244B7F8
	public void set_icon_frame(long value) { }

	// RVA: 0x244B83C Offset: 0x244B83C VA: 0x244B83C
	public bool get_HasIcon_frame() { }

	// RVA: 0x244B86C Offset: 0x244B86C VA: 0x244B86C
	public long get_create_time() { }

	// RVA: 0x244B874 Offset: 0x244B874 VA: 0x244B874
	public void set_create_time(long value) { }

	// RVA: 0x244B8B8 Offset: 0x244B8B8 VA: 0x244B8B8
	public bool get_HasCreate_time() { }

	// RVA: 0x244B8E8 Offset: 0x244B8E8 VA: 0x244B8E8
	public long get_current_season_id() { }

	// RVA: 0x244B8F0 Offset: 0x244B8F0 VA: 0x244B8F0
	public void set_current_season_id(long value) { }

	// RVA: 0x244B934 Offset: 0x244B934 VA: 0x244B934
	public bool get_HasCurrent_season_id() { }

	// RVA: 0x244B964 Offset: 0x244B964 VA: 0x244B964
	public bool get_is_active() { }

	// RVA: 0x244B96C Offset: 0x244B96C VA: 0x244B96C
	public void set_is_active(bool value) { }

	// RVA: 0x244B9AC Offset: 0x244B9AC VA: 0x244B9AC
	public bool get_HasIs_active() { }

	// RVA: 0x244B9DC Offset: 0x244B9DC VA: 0x244B9DC
	public void .ctor() { }

	// RVA: 0x244BA78 Offset: 0x244BA78 VA: 0x244BA78
	public void .ctor(byte[] buffer) { }

	// RVA: 0x244BB30 Offset: 0x244BB30 VA: 0x244BB30 Slot: 5
	protected override void decode() { }

	// RVA: 0x244BF4C Offset: 0x244BF4C VA: 0x244BF4C Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x244C5A8 Offset: 0x244C5A8 VA: 0x244C5A8 Slot: 3
	public override string ToString() { }

	// RVA: 0x244CCC4 Offset: 0x244CCC4 VA: 0x244CCC4
	private static void .cctor() { }
}
