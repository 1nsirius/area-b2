// Namespace: 
public class client.change_show_character.response : SprotoTypeBase // TypeDefIndex: 9094
{
	// Fields
	private static int max_field_count; // 0x0
	private long _errorcode; // 0x18
	private long _character_id; // 0x20

	// Properties
	public long errorcode { get; set; }
	public bool HasErrorcode { get; }
	public long character_id { get; set; }
	public bool HasCharacter_id { get; }

	// Methods

	// RVA: 0x243B6B8 Offset: 0x243B6B8 VA: 0x243B6B8
	public long get_errorcode() { }

	// RVA: 0x243B6C0 Offset: 0x243B6C0 VA: 0x243B6C0
	public void set_errorcode(long value) { }

	// RVA: 0x243B704 Offset: 0x243B704 VA: 0x243B704
	public bool get_HasErrorcode() { }

	// RVA: 0x243B734 Offset: 0x243B734 VA: 0x243B734
	public long get_character_id() { }

	// RVA: 0x243B73C Offset: 0x243B73C VA: 0x243B73C
	public void set_character_id(long value) { }

	// RVA: 0x243B780 Offset: 0x243B780 VA: 0x243B780
	public bool get_HasCharacter_id() { }

	// RVA: 0x243B7B0 Offset: 0x243B7B0 VA: 0x243B7B0
	public void .ctor() { }

	// RVA: 0x243B84C Offset: 0x243B84C VA: 0x243B84C
	public void .ctor(byte[] buffer) { }

	// RVA: 0x243B904 Offset: 0x243B904 VA: 0x243B904 Slot: 5
	protected override void decode() { }

	// RVA: 0x243B9E0 Offset: 0x243B9E0 VA: 0x243B9E0 Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x243BB04 Offset: 0x243BB04 VA: 0x243BB04 Slot: 3
	public override string ToString() { }

	// RVA: 0x243BBB4 Offset: 0x243BBB4 VA: 0x243BBB4
	private static void .cctor() { }
}
