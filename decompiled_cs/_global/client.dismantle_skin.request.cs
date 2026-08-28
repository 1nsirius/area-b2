// Namespace: 
public class client.dismantle_skin.request : SprotoTypeBase // TypeDefIndex: 9099
{
	// Fields
	private static int max_field_count; // 0x0
	private List<client.DismantleInfo> _skins; // 0x14

	// Properties
	public List<client.DismantleInfo> skins { get; set; }
	public bool HasSkins { get; }

	// Methods

	// RVA: 0x243C99C Offset: 0x243C99C VA: 0x243C99C
	public List<client.DismantleInfo> get_skins() { }

	// RVA: 0x243C9A4 Offset: 0x243C9A4 VA: 0x243C9A4
	public void set_skins(List<client.DismantleInfo> value) { }

	// RVA: 0x243C9E4 Offset: 0x243C9E4 VA: 0x243C9E4
	public bool get_HasSkins() { }

	// RVA: 0x243CA14 Offset: 0x243CA14 VA: 0x243CA14
	public void .ctor() { }

	// RVA: 0x243CAB0 Offset: 0x243CAB0 VA: 0x243CAB0
	public void .ctor(byte[] buffer) { }

	// RVA: 0x243CB68 Offset: 0x243CB68 VA: 0x243CB68 Slot: 5
	protected override void decode() { }

	// RVA: 0x243CC34 Offset: 0x243CC34 VA: 0x243CC34 Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x243CD2C Offset: 0x243CD2C VA: 0x243CD2C Slot: 3
	public override string ToString() { }

	// RVA: 0x243CDBC Offset: 0x243CDBC VA: 0x243CDBC
	private static void .cctor() { }
}
