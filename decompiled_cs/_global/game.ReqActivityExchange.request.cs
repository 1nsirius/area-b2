// Namespace: 
public class game.ReqActivityExchange.request : SprotoTypeBase // TypeDefIndex: 9213
{
	// Fields
	private static int max_field_count; // 0x0
	private long _activity_id; // 0x18
	private long _exchange_id; // 0x20

	// Properties
	public long activity_id { get; set; }
	public bool HasActivity_id { get; }
	public long exchange_id { get; set; }
	public bool HasExchange_id { get; }

	// Methods

	// RVA: 0x25548F8 Offset: 0x25548F8 VA: 0x25548F8
	public long get_activity_id() { }

	// RVA: 0x2554900 Offset: 0x2554900 VA: 0x2554900
	public void set_activity_id(long value) { }

	// RVA: 0x2554944 Offset: 0x2554944 VA: 0x2554944
	public bool get_HasActivity_id() { }

	// RVA: 0x2554974 Offset: 0x2554974 VA: 0x2554974
	public long get_exchange_id() { }

	// RVA: 0x255497C Offset: 0x255497C VA: 0x255497C
	public void set_exchange_id(long value) { }

	// RVA: 0x25549C0 Offset: 0x25549C0 VA: 0x25549C0
	public bool get_HasExchange_id() { }

	// RVA: 0x25549F0 Offset: 0x25549F0 VA: 0x25549F0
	public void .ctor() { }

	// RVA: 0x2554A8C Offset: 0x2554A8C VA: 0x2554A8C
	public void .ctor(byte[] buffer) { }

	// RVA: 0x2554B44 Offset: 0x2554B44 VA: 0x2554B44 Slot: 5
	protected override void decode() { }

	// RVA: 0x2554C20 Offset: 0x2554C20 VA: 0x2554C20 Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x2554D44 Offset: 0x2554D44 VA: 0x2554D44 Slot: 3
	public override string ToString() { }

	// RVA: 0x2554DF4 Offset: 0x2554DF4 VA: 0x2554DF4
	private static void .cctor() { }
}
