// Namespace: 
public class game.RspHallChooseWeapon.request : SprotoTypeBase // TypeDefIndex: 9351
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

	// RVA: 0x22603AC Offset: 0x22603AC VA: 0x22603AC
	public long get_character_id() { }

	// RVA: 0x22603B4 Offset: 0x22603B4 VA: 0x22603B4
	public void set_character_id(long value) { }

	// RVA: 0x22603F8 Offset: 0x22603F8 VA: 0x22603F8
	public bool get_HasCharacter_id() { }

	// RVA: 0x2260428 Offset: 0x2260428 VA: 0x2260428
	public long get_kind() { }

	// RVA: 0x2260430 Offset: 0x2260430 VA: 0x2260430
	public void set_kind(long value) { }

	// RVA: 0x2260474 Offset: 0x2260474 VA: 0x2260474
	public bool get_HasKind() { }

	// RVA: 0x22604A4 Offset: 0x22604A4 VA: 0x22604A4
	public long get_id() { }

	// RVA: 0x22604AC Offset: 0x22604AC VA: 0x22604AC
	public void set_id(long value) { }

	// RVA: 0x22604F0 Offset: 0x22604F0 VA: 0x22604F0
	public bool get_HasId() { }

	// RVA: 0x2260520 Offset: 0x2260520 VA: 0x2260520
	public List<game.Attachment> get_attachments() { }

	// RVA: 0x2260528 Offset: 0x2260528 VA: 0x2260528
	public void set_attachments(List<game.Attachment> value) { }

	// RVA: 0x2260568 Offset: 0x2260568 VA: 0x2260568
	public bool get_HasAttachments() { }

	// RVA: 0x2260598 Offset: 0x2260598 VA: 0x2260598
	public void .ctor() { }

	// RVA: 0x2260634 Offset: 0x2260634 VA: 0x2260634
	public void .ctor(byte[] buffer) { }

	// RVA: 0x22606EC Offset: 0x22606EC VA: 0x22606EC Slot: 5
	protected override void decode() { }

	// RVA: 0x2260890 Offset: 0x2260890 VA: 0x2260890 Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x2260AB8 Offset: 0x2260AB8 VA: 0x2260AB8 Slot: 3
	public override string ToString() { }

	// RVA: 0x2260D24 Offset: 0x2260D24 VA: 0x2260D24
	private static void .cctor() { }
}
