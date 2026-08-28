// Namespace: 
public class team.TeamMember : SprotoTypeBase // TypeDefIndex: 9458
{
	// Fields
	private static int max_field_count; // 0x0
	private long _pos; // 0x18
	private team.TeamPlayerInfo _info; // 0x20
	private bool _is_ready; // 0x24

	// Properties
	public long pos { get; set; }
	public bool HasPos { get; }
	public team.TeamPlayerInfo info { get; set; }
	public bool HasInfo { get; }
	public bool is_ready { get; set; }
	public bool HasIs_ready { get; }

	// Methods

	// RVA: 0xD726A4 Offset: 0xD726A4 VA: 0xD726A4
	public long get_pos() { }

	// RVA: 0xD726AC Offset: 0xD726AC VA: 0xD726AC
	public void set_pos(long value) { }

	// RVA: 0xD726F0 Offset: 0xD726F0 VA: 0xD726F0
	public bool get_HasPos() { }

	// RVA: 0xD72720 Offset: 0xD72720 VA: 0xD72720
	public team.TeamPlayerInfo get_info() { }

	// RVA: 0xD72728 Offset: 0xD72728 VA: 0xD72728
	public void set_info(team.TeamPlayerInfo value) { }

	// RVA: 0xD72768 Offset: 0xD72768 VA: 0xD72768
	public bool get_HasInfo() { }

	// RVA: 0xD72798 Offset: 0xD72798 VA: 0xD72798
	public bool get_is_ready() { }

	// RVA: 0xD727A0 Offset: 0xD727A0 VA: 0xD727A0
	public void set_is_ready(bool value) { }

	// RVA: 0xD727E0 Offset: 0xD727E0 VA: 0xD727E0
	public bool get_HasIs_ready() { }

	// RVA: 0xD72810 Offset: 0xD72810 VA: 0xD72810
	public void .ctor() { }

	// RVA: 0xD728AC Offset: 0xD728AC VA: 0xD728AC
	public void .ctor(byte[] buffer) { }

	// RVA: 0xD72964 Offset: 0xD72964 VA: 0xD72964 Slot: 5
	protected override void decode() { }

	// RVA: 0xD72ACC Offset: 0xD72ACC VA: 0xD72ACC Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0xD72C44 Offset: 0xD72C44 VA: 0xD72C44 Slot: 3
	public override string ToString() { }

	// RVA: 0xD72D0C Offset: 0xD72D0C VA: 0xD72D0C
	private static void .cctor() { }
}
