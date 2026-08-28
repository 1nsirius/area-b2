// Namespace: 
public class game.ReqChooseWeapon.request : SprotoTypeBase // TypeDefIndex: 9239
{
	// Fields
	private static int max_field_count; // 0x0
	private long _kind; // 0x18
	private long _id; // 0x20
	private List<game.Attachment> _attachments; // 0x28

	// Properties
	public long kind { get; set; }
	public bool HasKind { get; }
	public long id { get; set; }
	public bool HasId { get; }
	public List<game.Attachment> attachments { get; set; }
	public bool HasAttachments { get; }

	// Methods

	// RVA: 0x255787C Offset: 0x255787C VA: 0x255787C
	public long get_kind() { }

	// RVA: 0x2557884 Offset: 0x2557884 VA: 0x2557884
	public void set_kind(long value) { }

	// RVA: 0x25578C8 Offset: 0x25578C8 VA: 0x25578C8
	public bool get_HasKind() { }

	// RVA: 0x25578F8 Offset: 0x25578F8 VA: 0x25578F8
	public long get_id() { }

	// RVA: 0x2557900 Offset: 0x2557900 VA: 0x2557900
	public void set_id(long value) { }

	// RVA: 0x2557944 Offset: 0x2557944 VA: 0x2557944
	public bool get_HasId() { }

	// RVA: 0x2557974 Offset: 0x2557974 VA: 0x2557974
	public List<game.Attachment> get_attachments() { }

	// RVA: 0x255797C Offset: 0x255797C VA: 0x255797C
	public void set_attachments(List<game.Attachment> value) { }

	// RVA: 0x25579BC Offset: 0x25579BC VA: 0x25579BC
	public bool get_HasAttachments() { }

	// RVA: 0x25579EC Offset: 0x25579EC VA: 0x25579EC
	public void .ctor() { }

	// RVA: 0x2557A88 Offset: 0x2557A88 VA: 0x2557A88
	public void .ctor(byte[] buffer) { }

	// RVA: 0x2557B40 Offset: 0x2557B40 VA: 0x2557B40 Slot: 5
	protected override void decode() { }

	// RVA: 0x2557CA8 Offset: 0x2557CA8 VA: 0x2557CA8 Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x2557E6C Offset: 0x2557E6C VA: 0x2557E6C Slot: 3
	public override string ToString() { }

	// RVA: 0x2557F44 Offset: 0x2557F44 VA: 0x2557F44
	private static void .cctor() { }
}
