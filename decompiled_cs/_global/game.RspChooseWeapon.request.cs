// Namespace: 
public class game.RspChooseWeapon.request : SprotoTypeBase // TypeDefIndex: 9339
{
	// Fields
	private static int max_field_count; // 0x0
	private bool _success; // 0x14
	private long _kind; // 0x18
	private long _id; // 0x20
	private List<game.Attachment> _attachments; // 0x28

	// Properties
	public bool success { get; set; }
	public bool HasSuccess { get; }
	public long kind { get; set; }
	public bool HasKind { get; }
	public long id { get; set; }
	public bool HasId { get; }
	public List<game.Attachment> attachments { get; set; }
	public bool HasAttachments { get; }

	// Methods

	// RVA: 0x225D5A4 Offset: 0x225D5A4 VA: 0x225D5A4
	public bool get_success() { }

	// RVA: 0x225D5AC Offset: 0x225D5AC VA: 0x225D5AC
	public void set_success(bool value) { }

	// RVA: 0x225D5EC Offset: 0x225D5EC VA: 0x225D5EC
	public bool get_HasSuccess() { }

	// RVA: 0x225D61C Offset: 0x225D61C VA: 0x225D61C
	public long get_kind() { }

	// RVA: 0x225D624 Offset: 0x225D624 VA: 0x225D624
	public void set_kind(long value) { }

	// RVA: 0x225D668 Offset: 0x225D668 VA: 0x225D668
	public bool get_HasKind() { }

	// RVA: 0x225D698 Offset: 0x225D698 VA: 0x225D698
	public long get_id() { }

	// RVA: 0x225D6A0 Offset: 0x225D6A0 VA: 0x225D6A0
	public void set_id(long value) { }

	// RVA: 0x225D6E4 Offset: 0x225D6E4 VA: 0x225D6E4
	public bool get_HasId() { }

	// RVA: 0x225D714 Offset: 0x225D714 VA: 0x225D714
	public List<game.Attachment> get_attachments() { }

	// RVA: 0x225D71C Offset: 0x225D71C VA: 0x225D71C
	public void set_attachments(List<game.Attachment> value) { }

	// RVA: 0x225D75C Offset: 0x225D75C VA: 0x225D75C
	public bool get_HasAttachments() { }

	// RVA: 0x225D78C Offset: 0x225D78C VA: 0x225D78C
	public void .ctor() { }

	// RVA: 0x225D828 Offset: 0x225D828 VA: 0x225D828
	public void .ctor(byte[] buffer) { }

	// RVA: 0x225D8E0 Offset: 0x225D8E0 VA: 0x225D8E0 Slot: 5
	protected override void decode() { }

	// RVA: 0x225DA7C Offset: 0x225DA7C VA: 0x225DA7C Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x225DCA4 Offset: 0x225DCA4 VA: 0x225DCA4 Slot: 3
	public override string ToString() { }

	// RVA: 0x225DF0C Offset: 0x225DF0C VA: 0x225DF0C
	private static void .cctor() { }
}
