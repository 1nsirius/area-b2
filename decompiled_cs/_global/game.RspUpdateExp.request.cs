// Namespace: 
public class game.RspUpdateExp.request : SprotoTypeBase // TypeDefIndex: 9389
{
	// Fields
	private static int max_field_count; // 0x0
	private long _add_exp; // 0x18
	private long _current_exp; // 0x20
	private long _level; // 0x28
	private bool _is_level_up; // 0x30

	// Properties
	public long add_exp { get; set; }
	public bool HasAdd_exp { get; }
	public long current_exp { get; set; }
	public bool HasCurrent_exp { get; }
	public long level { get; set; }
	public bool HasLevel { get; }
	public bool is_level_up { get; set; }
	public bool HasIs_level_up { get; }

	// Methods

	// RVA: 0x22678AC Offset: 0x22678AC VA: 0x22678AC
	public long get_add_exp() { }

	// RVA: 0x22678B4 Offset: 0x22678B4 VA: 0x22678B4
	public void set_add_exp(long value) { }

	// RVA: 0x22678F8 Offset: 0x22678F8 VA: 0x22678F8
	public bool get_HasAdd_exp() { }

	// RVA: 0x2267928 Offset: 0x2267928 VA: 0x2267928
	public long get_current_exp() { }

	// RVA: 0x2267930 Offset: 0x2267930 VA: 0x2267930
	public void set_current_exp(long value) { }

	// RVA: 0x2267974 Offset: 0x2267974 VA: 0x2267974
	public bool get_HasCurrent_exp() { }

	// RVA: 0x22679A4 Offset: 0x22679A4 VA: 0x22679A4
	public long get_level() { }

	// RVA: 0x22679AC Offset: 0x22679AC VA: 0x22679AC
	public void set_level(long value) { }

	// RVA: 0x22679F0 Offset: 0x22679F0 VA: 0x22679F0
	public bool get_HasLevel() { }

	// RVA: 0x2267A20 Offset: 0x2267A20 VA: 0x2267A20
	public bool get_is_level_up() { }

	// RVA: 0x2267A28 Offset: 0x2267A28 VA: 0x2267A28
	public void set_is_level_up(bool value) { }

	// RVA: 0x2267A68 Offset: 0x2267A68 VA: 0x2267A68
	public bool get_HasIs_level_up() { }

	// RVA: 0x2267A98 Offset: 0x2267A98 VA: 0x2267A98
	public void .ctor() { }

	// RVA: 0x2267B34 Offset: 0x2267B34 VA: 0x2267B34
	public void .ctor(byte[] buffer) { }

	// RVA: 0x2267BEC Offset: 0x2267BEC VA: 0x2267BEC Slot: 5
	protected override void decode() { }

	// RVA: 0x2267D44 Offset: 0x2267D44 VA: 0x2267D44 Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x2267F2C Offset: 0x2267F2C VA: 0x2267F2C Slot: 3
	public override string ToString() { }

	// RVA: 0x22681A4 Offset: 0x22681A4 VA: 0x22681A4
	private static void .cctor() { }
}
