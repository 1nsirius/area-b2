// Namespace: 
public class invite.InvitePlayerInfo : SprotoTypeBase // TypeDefIndex: 9414
{
	// Fields
	private static int max_field_count; // 0x0
	private long _uid; // 0x18
	private string _name; // 0x20
	private long _icon; // 0x28
	private long _level; // 0x30
	private string _icon_url; // 0x38
	private string _extra_arg; // 0x3C
	private long _rank_score; // 0x40

	// Properties
	public long uid { get; set; }
	public bool HasUid { get; }
	public string name { get; set; }
	public bool HasName { get; }
	public long icon { get; set; }
	public bool HasIcon { get; }
	public long level { get; set; }
	public bool HasLevel { get; }
	public string icon_url { get; set; }
	public bool HasIcon_url { get; }
	public string extra_arg { get; set; }
	public bool HasExtra_arg { get; }
	public long rank_score { get; set; }
	public bool HasRank_score { get; }

	// Methods

	// RVA: 0x226CFDC Offset: 0x226CFDC VA: 0x226CFDC
	public long get_uid() { }

	// RVA: 0x226CFE4 Offset: 0x226CFE4 VA: 0x226CFE4
	public void set_uid(long value) { }

	// RVA: 0x226D028 Offset: 0x226D028 VA: 0x226D028
	public bool get_HasUid() { }

	// RVA: 0x226D058 Offset: 0x226D058 VA: 0x226D058
	public string get_name() { }

	// RVA: 0x226D060 Offset: 0x226D060 VA: 0x226D060
	public void set_name(string value) { }

	// RVA: 0x226D0A0 Offset: 0x226D0A0 VA: 0x226D0A0
	public bool get_HasName() { }

	// RVA: 0x226D0D0 Offset: 0x226D0D0 VA: 0x226D0D0
	public long get_icon() { }

	// RVA: 0x226D0D8 Offset: 0x226D0D8 VA: 0x226D0D8
	public void set_icon(long value) { }

	// RVA: 0x226D11C Offset: 0x226D11C VA: 0x226D11C
	public bool get_HasIcon() { }

	// RVA: 0x226D14C Offset: 0x226D14C VA: 0x226D14C
	public long get_level() { }

	// RVA: 0x226D154 Offset: 0x226D154 VA: 0x226D154
	public void set_level(long value) { }

	// RVA: 0x226D198 Offset: 0x226D198 VA: 0x226D198
	public bool get_HasLevel() { }

	// RVA: 0x226D1C8 Offset: 0x226D1C8 VA: 0x226D1C8
	public string get_icon_url() { }

	// RVA: 0x226D1D0 Offset: 0x226D1D0 VA: 0x226D1D0
	public void set_icon_url(string value) { }

	// RVA: 0x226D210 Offset: 0x226D210 VA: 0x226D210
	public bool get_HasIcon_url() { }

	// RVA: 0x226D240 Offset: 0x226D240 VA: 0x226D240
	public string get_extra_arg() { }

	// RVA: 0x226D248 Offset: 0x226D248 VA: 0x226D248
	public void set_extra_arg(string value) { }

	// RVA: 0x226D288 Offset: 0x226D288 VA: 0x226D288
	public bool get_HasExtra_arg() { }

	// RVA: 0x226D2B8 Offset: 0x226D2B8 VA: 0x226D2B8
	public long get_rank_score() { }

	// RVA: 0x226D2C0 Offset: 0x226D2C0 VA: 0x226D2C0
	public void set_rank_score(long value) { }

	// RVA: 0x226D304 Offset: 0x226D304 VA: 0x226D304
	public bool get_HasRank_score() { }

	// RVA: 0x226D334 Offset: 0x226D334 VA: 0x226D334
	public void .ctor() { }

	// RVA: 0x226D3D0 Offset: 0x226D3D0 VA: 0x226D3D0
	public void .ctor(byte[] buffer) { }

	// RVA: 0x226D488 Offset: 0x226D488 VA: 0x226D488 Slot: 5
	protected override void decode() { }

	// RVA: 0x226D680 Offset: 0x226D680 VA: 0x226D680 Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x226D974 Offset: 0x226D974 VA: 0x226D974 Slot: 3
	public override string ToString() { }

	// RVA: 0x226DCE8 Offset: 0x226DCE8 VA: 0x226DCE8
	private static void .cctor() { }
}
