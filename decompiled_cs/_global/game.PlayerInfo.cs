// Namespace: 
public class game.PlayerInfo : SprotoTypeBase // TypeDefIndex: 9208
{
	// Fields
	private static int max_field_count; // 0x0
	private long _uid; // 0x18
	private string _name; // 0x20
	private long _level; // 0x28
	private long _icon; // 0x30
	private long _camp; // 0x38
	private long _index; // 0x40
	private long _rank_score; // 0x48
	private string _icon_url; // 0x50

	// Properties
	public long uid { get; set; }
	public bool HasUid { get; }
	public string name { get; set; }
	public bool HasName { get; }
	public long level { get; set; }
	public bool HasLevel { get; }
	public long icon { get; set; }
	public bool HasIcon { get; }
	public long camp { get; set; }
	public bool HasCamp { get; }
	public long index { get; set; }
	public bool HasIndex { get; }
	public long rank_score { get; set; }
	public bool HasRank_score { get; }
	public string icon_url { get; set; }
	public bool HasIcon_url { get; }

	// Methods

	// RVA: 0x255177C Offset: 0x255177C VA: 0x255177C
	public long get_uid() { }

	// RVA: 0x2551784 Offset: 0x2551784 VA: 0x2551784
	public void set_uid(long value) { }

	// RVA: 0x25517C8 Offset: 0x25517C8 VA: 0x25517C8
	public bool get_HasUid() { }

	// RVA: 0x25517F8 Offset: 0x25517F8 VA: 0x25517F8
	public string get_name() { }

	// RVA: 0x2551800 Offset: 0x2551800 VA: 0x2551800
	public void set_name(string value) { }

	// RVA: 0x2551840 Offset: 0x2551840 VA: 0x2551840
	public bool get_HasName() { }

	// RVA: 0x2551870 Offset: 0x2551870 VA: 0x2551870
	public long get_level() { }

	// RVA: 0x2551878 Offset: 0x2551878 VA: 0x2551878
	public void set_level(long value) { }

	// RVA: 0x25518BC Offset: 0x25518BC VA: 0x25518BC
	public bool get_HasLevel() { }

	// RVA: 0x25518EC Offset: 0x25518EC VA: 0x25518EC
	public long get_icon() { }

	// RVA: 0x25518F4 Offset: 0x25518F4 VA: 0x25518F4
	public void set_icon(long value) { }

	// RVA: 0x2551938 Offset: 0x2551938 VA: 0x2551938
	public bool get_HasIcon() { }

	// RVA: 0x2551968 Offset: 0x2551968 VA: 0x2551968
	public long get_camp() { }

	// RVA: 0x2551970 Offset: 0x2551970 VA: 0x2551970
	public void set_camp(long value) { }

	// RVA: 0x25519B4 Offset: 0x25519B4 VA: 0x25519B4
	public bool get_HasCamp() { }

	// RVA: 0x25519E4 Offset: 0x25519E4 VA: 0x25519E4
	public long get_index() { }

	// RVA: 0x25519EC Offset: 0x25519EC VA: 0x25519EC
	public void set_index(long value) { }

	// RVA: 0x2551A30 Offset: 0x2551A30 VA: 0x2551A30
	public bool get_HasIndex() { }

	// RVA: 0x2551A60 Offset: 0x2551A60 VA: 0x2551A60
	public long get_rank_score() { }

	// RVA: 0x2551A68 Offset: 0x2551A68 VA: 0x2551A68
	public void set_rank_score(long value) { }

	// RVA: 0x2551AAC Offset: 0x2551AAC VA: 0x2551AAC
	public bool get_HasRank_score() { }

	// RVA: 0x2551ADC Offset: 0x2551ADC VA: 0x2551ADC
	public string get_icon_url() { }

	// RVA: 0x2551AE4 Offset: 0x2551AE4 VA: 0x2551AE4
	public void set_icon_url(string value) { }

	// RVA: 0x2551B24 Offset: 0x2551B24 VA: 0x2551B24
	public bool get_HasIcon_url() { }

	// RVA: 0x2551B54 Offset: 0x2551B54 VA: 0x2551B54
	public void .ctor() { }

	// RVA: 0x2551BF0 Offset: 0x2551BF0 VA: 0x2551BF0
	public void .ctor(byte[] buffer) { }

	// RVA: 0x2551CA8 Offset: 0x2551CA8 VA: 0x2551CA8 Slot: 5
	protected override void decode() { }

	// RVA: 0x2551EDC Offset: 0x2551EDC VA: 0x2551EDC Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x2552240 Offset: 0x2552240 VA: 0x2552240 Slot: 3
	public override string ToString() { }

	// RVA: 0x2552650 Offset: 0x2552650 VA: 0x2552650
	private static void .cctor() { }
}
