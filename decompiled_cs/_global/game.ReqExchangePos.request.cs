// Namespace: 
public class game.ReqExchangePos.request : SprotoTypeBase // TypeDefIndex: 9250
{
	// Fields
	private static int max_field_count; // 0x0
	private long _camp; // 0x18
	private long _index; // 0x20

	// Properties
	public long camp { get; set; }
	public bool HasCamp { get; }
	public long index { get; set; }
	public bool HasIndex { get; }

	// Methods

	// RVA: 0x25590CC Offset: 0x25590CC VA: 0x25590CC
	public long get_camp() { }

	// RVA: 0x25590D4 Offset: 0x25590D4 VA: 0x25590D4
	public void set_camp(long value) { }

	// RVA: 0x2559118 Offset: 0x2559118 VA: 0x2559118
	public bool get_HasCamp() { }

	// RVA: 0x2559148 Offset: 0x2559148 VA: 0x2559148
	public long get_index() { }

	// RVA: 0x2559150 Offset: 0x2559150 VA: 0x2559150
	public void set_index(long value) { }

	// RVA: 0x2559194 Offset: 0x2559194 VA: 0x2559194
	public bool get_HasIndex() { }

	// RVA: 0x25591C4 Offset: 0x25591C4 VA: 0x25591C4
	public void .ctor() { }

	// RVA: 0x2559260 Offset: 0x2559260 VA: 0x2559260
	public void .ctor(byte[] buffer) { }

	// RVA: 0x2559318 Offset: 0x2559318 VA: 0x2559318 Slot: 5
	protected override void decode() { }

	// RVA: 0x25593F4 Offset: 0x25593F4 VA: 0x25593F4 Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x2559518 Offset: 0x2559518 VA: 0x2559518 Slot: 3
	public override string ToString() { }

	// RVA: 0x25595C8 Offset: 0x25595C8 VA: 0x25595C8
	private static void .cctor() { }
}
