// Namespace: 
public class game.WeaponInfo : SprotoTypeBase // TypeDefIndex: 9398
{
	// Fields
	private static int max_field_count; // 0x0
	private long _id; // 0x18
	private List<game.Attachment> _attachments; // 0x20

	// Properties
	public long id { get; set; }
	public bool HasId { get; }
	public List<game.Attachment> attachments { get; set; }
	public bool HasAttachments { get; }

	// Methods

	// RVA: 0x226A7E8 Offset: 0x226A7E8 VA: 0x226A7E8
	public long get_id() { }

	// RVA: 0x226A7F0 Offset: 0x226A7F0 VA: 0x226A7F0
	public void set_id(long value) { }

	// RVA: 0x226A834 Offset: 0x226A834 VA: 0x226A834
	public bool get_HasId() { }

	// RVA: 0x226A864 Offset: 0x226A864 VA: 0x226A864
	public List<game.Attachment> get_attachments() { }

	// RVA: 0x226A86C Offset: 0x226A86C VA: 0x226A86C
	public void set_attachments(List<game.Attachment> value) { }

	// RVA: 0x226A8AC Offset: 0x226A8AC VA: 0x226A8AC
	public bool get_HasAttachments() { }

	// RVA: 0x226A8DC Offset: 0x226A8DC VA: 0x226A8DC
	public void .ctor() { }

	// RVA: 0x226A978 Offset: 0x226A978 VA: 0x226A978
	public void .ctor(byte[] buffer) { }

	// RVA: 0x226AA30 Offset: 0x226AA30 VA: 0x226AA30 Slot: 5
	protected override void decode() { }

	// RVA: 0x226AB50 Offset: 0x226AB50 VA: 0x226AB50 Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x226ACB0 Offset: 0x226ACB0 VA: 0x226ACB0 Slot: 3
	public override string ToString() { }

	// RVA: 0x226AD60 Offset: 0x226AD60 VA: 0x226AD60
	private static void .cctor() { }
}
