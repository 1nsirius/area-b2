// Namespace: 
public class game.RankPlayerResult : SprotoTypeBase // TypeDefIndex: 9211
{
	// Fields
	private static int max_field_count; // 0x0
	private long _old_rank_score; // 0x18
	private long _new_rank_score; // 0x20
	private long _old_protect_score; // 0x28
	private long _new_protect_score; // 0x30
	private bool _is_protect; // 0x38
	private bool _is_offline; // 0x39
	private bool _is_win; // 0x3A

	// Properties
	public long old_rank_score { get; set; }
	public bool HasOld_rank_score { get; }
	public long new_rank_score { get; set; }
	public bool HasNew_rank_score { get; }
	public long old_protect_score { get; set; }
	public bool HasOld_protect_score { get; }
	public long new_protect_score { get; set; }
	public bool HasNew_protect_score { get; }
	public bool is_protect { get; set; }
	public bool HasIs_protect { get; }
	public bool is_offline { get; set; }
	public bool HasIs_offline { get; }
	public bool is_win { get; set; }
	public bool HasIs_win { get; }

	// Methods

	// RVA: 0x2553B00 Offset: 0x2553B00 VA: 0x2553B00
	public long get_old_rank_score() { }

	// RVA: 0x2553B08 Offset: 0x2553B08 VA: 0x2553B08
	public void set_old_rank_score(long value) { }

	// RVA: 0x2553B4C Offset: 0x2553B4C VA: 0x2553B4C
	public bool get_HasOld_rank_score() { }

	// RVA: 0x2553B7C Offset: 0x2553B7C VA: 0x2553B7C
	public long get_new_rank_score() { }

	// RVA: 0x2553B84 Offset: 0x2553B84 VA: 0x2553B84
	public void set_new_rank_score(long value) { }

	// RVA: 0x2553BC8 Offset: 0x2553BC8 VA: 0x2553BC8
	public bool get_HasNew_rank_score() { }

	// RVA: 0x2553BF8 Offset: 0x2553BF8 VA: 0x2553BF8
	public long get_old_protect_score() { }

	// RVA: 0x2553C00 Offset: 0x2553C00 VA: 0x2553C00
	public void set_old_protect_score(long value) { }

	// RVA: 0x2553C44 Offset: 0x2553C44 VA: 0x2553C44
	public bool get_HasOld_protect_score() { }

	// RVA: 0x2553C74 Offset: 0x2553C74 VA: 0x2553C74
	public long get_new_protect_score() { }

	// RVA: 0x2553C7C Offset: 0x2553C7C VA: 0x2553C7C
	public void set_new_protect_score(long value) { }

	// RVA: 0x2553CC0 Offset: 0x2553CC0 VA: 0x2553CC0
	public bool get_HasNew_protect_score() { }

	// RVA: 0x2553CF0 Offset: 0x2553CF0 VA: 0x2553CF0
	public bool get_is_protect() { }

	// RVA: 0x2553CF8 Offset: 0x2553CF8 VA: 0x2553CF8
	public void set_is_protect(bool value) { }

	// RVA: 0x2553D38 Offset: 0x2553D38 VA: 0x2553D38
	public bool get_HasIs_protect() { }

	// RVA: 0x2553D68 Offset: 0x2553D68 VA: 0x2553D68
	public bool get_is_offline() { }

	// RVA: 0x2553D70 Offset: 0x2553D70 VA: 0x2553D70
	public void set_is_offline(bool value) { }

	// RVA: 0x2553DB0 Offset: 0x2553DB0 VA: 0x2553DB0
	public bool get_HasIs_offline() { }

	// RVA: 0x2553DE0 Offset: 0x2553DE0 VA: 0x2553DE0
	public bool get_is_win() { }

	// RVA: 0x2553DE8 Offset: 0x2553DE8 VA: 0x2553DE8
	public void set_is_win(bool value) { }

	// RVA: 0x2553E28 Offset: 0x2553E28 VA: 0x2553E28
	public bool get_HasIs_win() { }

	// RVA: 0x2553E58 Offset: 0x2553E58 VA: 0x2553E58
	public void .ctor() { }

	// RVA: 0x2553EF4 Offset: 0x2553EF4 VA: 0x2553EF4
	public void .ctor(byte[] buffer) { }

	// RVA: 0x2553FAC Offset: 0x2553FAC VA: 0x2553FAC Slot: 5
	protected override void decode() { }

	// RVA: 0x25541A4 Offset: 0x25541A4 VA: 0x25541A4 Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x25544B0 Offset: 0x25544B0 VA: 0x25544B0 Slot: 3
	public override string ToString() { }

	// RVA: 0x2554888 Offset: 0x2554888 VA: 0x2554888
	private static void .cctor() { }
}
