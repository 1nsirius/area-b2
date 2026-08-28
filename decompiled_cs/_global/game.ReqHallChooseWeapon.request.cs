// Namespace: 
public class game.ReqHallChooseWeapon.request : SprotoTypeBase // TypeDefIndex: 9261
{
	// Fields
	private static int max_field_count; // 0x0
	private long _character_id; // 0x18
	private long _kind; // 0x20
	private long _id; // 0x28
	private List<game.Attachment> _attachments; // 0x30

	// Properties
	public long character_id { get; set; }
	public bool HasCharacter_id { get; }
	public long kind { get; set; }
	public bool HasKind { get; }
	public long id { get; set; }
	public bool HasId { get; }
	public List<game.Attachment> attachments { get; set; }
	public bool HasAttachments { get; }

	// Methods

	// RVA: 0x255B538 Offset: 0x255B538 VA: 0x255B538
	public long get_character_id() { }

	// RVA: 0x255B540 Offset: 0x255B540 VA: 0x255B540
	public void set_character_id(long value) { }

	// RVA: 0x255B584 Offset: 0x255B584 VA: 0x255B584
	public bool get_HasCharacter_id() { }

	// RVA: 0x255B5B4 Offset: 0x255B5B4 VA: 0x255B5B4
	public long get_kind() { }

	// RVA: 0x255B5BC Offset: 0x255B5BC VA: 0x255B5BC
	public void set_kind(long value) { }

	// RVA: 0x255B600 Offset: 0x255B600 VA: 0x255B600
	public bool get_HasKind() { }

	// RVA: 0x255B630 Offset: 0x255B630 VA: 0x255B630
	public long get_id() { }

	// RVA: 0x255B638 Offset: 0x255B638 VA: 0x255B638
	public void set_id(long value) { }

	// RVA: 0x255B67C Offset: 0x255B67C VA: 0x255B67C
	public bool get_HasId() { }

	// RVA: 0x255B6AC Offset: 0x255B6AC VA: 0x255B6AC
	public List<game.Attachment> get_attachments() { }

	// RVA: 0x255B6B4 Offset: 0x255B6B4 VA: 0x255B6B4
	public void set_attachments(List<game.Attachment> value) { }

	// RVA: 0x255B6F4 Offset: 0x255B6F4 VA: 0x255B6F4
	public bool get_HasAttachments() { }

	// RVA: 0x255B724 Offset: 0x255B724 VA: 0x255B724
	public void .ctor() { }

	// RVA: 0x255B7C0 Offset: 0x255B7C0 VA: 0x255B7C0
	public void .ctor(byte[] buffer) { }

	// RVA: 0x255B878 Offset: 0x255B878 VA: 0x255B878 Slot: 5
	protected override void decode() { }

	// RVA: 0x255BA18 Offset: 0x255BA18 VA: 0x255BA18 Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x255BC40 Offset: 0x255BC40 VA: 0x255BC40 Slot: 3
	public override string ToString() { }

	// RVA: 0x255BEAC Offset: 0x255BEAC VA: 0x255BEAC
	private static void .cctor() { }
}
