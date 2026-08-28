// Namespace: 
public class client.dismantle_skin.response : SprotoTypeBase // TypeDefIndex: 9100
{
	// Fields
	private static int max_field_count; // 0x0
	private List<client.DismantleInfo> _success; // 0x14
	private List<client.DismantleInfo> _failed; // 0x18

	// Properties
	public List<client.DismantleInfo> success { get; set; }
	public bool HasSuccess { get; }
	public List<client.DismantleInfo> failed { get; set; }
	public bool HasFailed { get; }

	// Methods

	// RVA: 0x243CE24 Offset: 0x243CE24 VA: 0x243CE24
	public List<client.DismantleInfo> get_success() { }

	// RVA: 0x243CE2C Offset: 0x243CE2C VA: 0x243CE2C
	public void set_success(List<client.DismantleInfo> value) { }

	// RVA: 0x243CE6C Offset: 0x243CE6C VA: 0x243CE6C
	public bool get_HasSuccess() { }

	// RVA: 0x243CE9C Offset: 0x243CE9C VA: 0x243CE9C
	public List<client.DismantleInfo> get_failed() { }

	// RVA: 0x243CEA4 Offset: 0x243CEA4 VA: 0x243CEA4
	public void set_failed(List<client.DismantleInfo> value) { }

	// RVA: 0x243CEE4 Offset: 0x243CEE4 VA: 0x243CEE4
	public bool get_HasFailed() { }

	// RVA: 0x243CF14 Offset: 0x243CF14 VA: 0x243CF14
	public void .ctor() { }

	// RVA: 0x243CFB0 Offset: 0x243CFB0 VA: 0x243CFB0
	public void .ctor(byte[] buffer) { }

	// RVA: 0x243D068 Offset: 0x243D068 VA: 0x243D068 Slot: 5
	protected override void decode() { }

	// RVA: 0x243D184 Offset: 0x243D184 VA: 0x243D184 Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x243D2E0 Offset: 0x243D2E0 VA: 0x243D2E0 Slot: 3
	public override string ToString() { }

	// RVA: 0x243D580 Offset: 0x243D580 VA: 0x243D580
	private static void .cctor() { }
}
