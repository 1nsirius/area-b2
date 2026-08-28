// Namespace: 
public class client.use_skin.request : SprotoTypeBase // TypeDefIndex: 9184
{
	// Fields
	private static int max_field_count; // 0x0
	private long _skin_id; // 0x18
	private long _char_id; // 0x20
	private long _prop_id; // 0x28

	// Properties
	public long skin_id { get; set; }
	public bool HasSkin_id { get; }
	public long char_id { get; set; }
	public bool HasChar_id { get; }
	public long prop_id { get; set; }
	public bool HasProp_id { get; }

	// Methods

	// RVA: 0x2546018 Offset: 0x2546018 VA: 0x2546018
	public long get_skin_id() { }

	// RVA: 0x2546020 Offset: 0x2546020 VA: 0x2546020
	public void set_skin_id(long value) { }

	// RVA: 0x2546064 Offset: 0x2546064 VA: 0x2546064
	public bool get_HasSkin_id() { }

	// RVA: 0x2546094 Offset: 0x2546094 VA: 0x2546094
	public long get_char_id() { }

	// RVA: 0x254609C Offset: 0x254609C VA: 0x254609C
	public void set_char_id(long value) { }

	// RVA: 0x25460E0 Offset: 0x25460E0 VA: 0x25460E0
	public bool get_HasChar_id() { }

	// RVA: 0x2546110 Offset: 0x2546110 VA: 0x2546110
	public long get_prop_id() { }

	// RVA: 0x2546118 Offset: 0x2546118 VA: 0x2546118
	public void set_prop_id(long value) { }

	// RVA: 0x254615C Offset: 0x254615C VA: 0x254615C
	public bool get_HasProp_id() { }

	// RVA: 0x254618C Offset: 0x254618C VA: 0x254618C
	public void .ctor() { }

	// RVA: 0x2546228 Offset: 0x2546228 VA: 0x2546228
	public void .ctor(byte[] buffer) { }

	// RVA: 0x25462E0 Offset: 0x25462E0 VA: 0x25462E0 Slot: 5
	protected override void decode() { }

	// RVA: 0x2546404 Offset: 0x2546404 VA: 0x2546404 Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x254658C Offset: 0x254658C VA: 0x254658C Slot: 3
	public override string ToString() { }

	// RVA: 0x2546664 Offset: 0x2546664 VA: 0x2546664
	private static void .cctor() { }
}
