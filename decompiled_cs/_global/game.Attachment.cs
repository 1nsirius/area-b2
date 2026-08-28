// Namespace: 
public class game.Attachment : SprotoTypeBase // TypeDefIndex: 9199
{
	// Fields
	private static int max_field_count; // 0x0
	private long _id; // 0x18
	private long _kind; // 0x20

	// Properties
	public long id { get; set; }
	public bool HasId { get; }
	public long kind { get; set; }
	public bool HasKind { get; }

	// Methods

	// RVA: 0x254AB90 Offset: 0x254AB90 VA: 0x254AB90
	public long get_id() { }

	// RVA: 0x254AB98 Offset: 0x254AB98 VA: 0x254AB98
	public void set_id(long value) { }

	// RVA: 0x254ABDC Offset: 0x254ABDC VA: 0x254ABDC
	public bool get_HasId() { }

	// RVA: 0x254AC0C Offset: 0x254AC0C VA: 0x254AC0C
	public long get_kind() { }

	// RVA: 0x254AC14 Offset: 0x254AC14 VA: 0x254AC14
	public void set_kind(long value) { }

	// RVA: 0x254AC58 Offset: 0x254AC58 VA: 0x254AC58
	public bool get_HasKind() { }

	// RVA: 0x254AC88 Offset: 0x254AC88 VA: 0x254AC88
	public void .ctor() { }

	// RVA: 0x254AD24 Offset: 0x254AD24 VA: 0x254AD24
	public void .ctor(byte[] buffer) { }

	// RVA: 0x254ADDC Offset: 0x254ADDC VA: 0x254ADDC Slot: 5
	protected override void decode() { }

	// RVA: 0x254AEB8 Offset: 0x254AEB8 VA: 0x254AEB8 Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x254AFDC Offset: 0x254AFDC VA: 0x254AFDC Slot: 3
	public override string ToString() { }

	// RVA: 0x254B08C Offset: 0x254B08C VA: 0x254B08C
	private static void .cctor() { }
}
