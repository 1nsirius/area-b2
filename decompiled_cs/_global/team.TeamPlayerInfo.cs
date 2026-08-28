// Namespace: 
public class team.TeamPlayerInfo : SprotoTypeBase // TypeDefIndex: 9459
{
	// Fields
	private static int max_field_count; // 0x0
	private long _uid; // 0x18
	private string _name; // 0x20
	private long _icon; // 0x28
	private long _level; // 0x30
	private long _mmr; // 0x38
	private string _icon_url; // 0x40
	private long _rank_score; // 0x48
	private client.CharacterSkin _show_character; // 0x50

	// Properties
	public long uid { get; set; }
	public bool HasUid { get; }
	public string name { get; set; }
	public bool HasName { get; }
	public long icon { get; set; }
	public bool HasIcon { get; }
	public long level { get; set; }
	public bool HasLevel { get; }
	public long mmr { get; set; }
	public bool HasMmr { get; }
	public string icon_url { get; set; }
	public bool HasIcon_url { get; }
	public long rank_score { get; set; }
	public bool HasRank_score { get; }
	public client.CharacterSkin show_character { get; set; }
	public bool HasShow_character { get; }

	// Methods

	// RVA: 0xD72D74 Offset: 0xD72D74 VA: 0xD72D74
	public long get_uid() { }

	// RVA: 0xD72D7C Offset: 0xD72D7C VA: 0xD72D7C
	public void set_uid(long value) { }

	// RVA: 0xD72DC0 Offset: 0xD72DC0 VA: 0xD72DC0
	public bool get_HasUid() { }

	// RVA: 0xD72DF0 Offset: 0xD72DF0 VA: 0xD72DF0
	public string get_name() { }

	// RVA: 0xD72DF8 Offset: 0xD72DF8 VA: 0xD72DF8
	public void set_name(string value) { }

	// RVA: 0xD72E38 Offset: 0xD72E38 VA: 0xD72E38
	public bool get_HasName() { }

	// RVA: 0xD72E68 Offset: 0xD72E68 VA: 0xD72E68
	public long get_icon() { }

	// RVA: 0xD72E70 Offset: 0xD72E70 VA: 0xD72E70
	public void set_icon(long value) { }

	// RVA: 0xD72EB4 Offset: 0xD72EB4 VA: 0xD72EB4
	public bool get_HasIcon() { }

	// RVA: 0xD72EE4 Offset: 0xD72EE4 VA: 0xD72EE4
	public long get_level() { }

	// RVA: 0xD72EEC Offset: 0xD72EEC VA: 0xD72EEC
	public void set_level(long value) { }

	// RVA: 0xD72F30 Offset: 0xD72F30 VA: 0xD72F30
	public bool get_HasLevel() { }

	// RVA: 0xD72F60 Offset: 0xD72F60 VA: 0xD72F60
	public long get_mmr() { }

	// RVA: 0xD72F68 Offset: 0xD72F68 VA: 0xD72F68
	public void set_mmr(long value) { }

	// RVA: 0xD72FAC Offset: 0xD72FAC VA: 0xD72FAC
	public bool get_HasMmr() { }

	// RVA: 0xD72FDC Offset: 0xD72FDC VA: 0xD72FDC
	public string get_icon_url() { }

	// RVA: 0xD72FE4 Offset: 0xD72FE4 VA: 0xD72FE4
	public void set_icon_url(string value) { }

	// RVA: 0xD73024 Offset: 0xD73024 VA: 0xD73024
	public bool get_HasIcon_url() { }

	// RVA: 0xD73054 Offset: 0xD73054 VA: 0xD73054
	public long get_rank_score() { }

	// RVA: 0xD7305C Offset: 0xD7305C VA: 0xD7305C
	public void set_rank_score(long value) { }

	// RVA: 0xD730A0 Offset: 0xD730A0 VA: 0xD730A0
	public bool get_HasRank_score() { }

	// RVA: 0xD730D0 Offset: 0xD730D0 VA: 0xD730D0
	public client.CharacterSkin get_show_character() { }

	// RVA: 0xD730D8 Offset: 0xD730D8 VA: 0xD730D8
	public void set_show_character(client.CharacterSkin value) { }

	// RVA: 0xD73118 Offset: 0xD73118 VA: 0xD73118
	public bool get_HasShow_character() { }

	// RVA: 0xD73148 Offset: 0xD73148 VA: 0xD73148
	public void .ctor() { }

	// RVA: 0xD731E4 Offset: 0xD731E4 VA: 0xD731E4
	public void .ctor(byte[] buffer) { }

	// RVA: 0xD7329C Offset: 0xD7329C VA: 0xD7329C Slot: 5
	protected override void decode() { }

	// RVA: 0xD73514 Offset: 0xD73514 VA: 0xD73514 Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0xD7386C Offset: 0xD7386C VA: 0xD7386C Slot: 3
	public override string ToString() { }

	// RVA: 0xD73C58 Offset: 0xD73C58 VA: 0xD73C58
	private static void .cctor() { }
}
