// Namespace: 
public class game.RspActivityInfo.request : SprotoTypeBase // TypeDefIndex: 9311
{
	// Fields
	private static int max_field_count; // 0x0
	private List<game.ActivityInfo> _infos; // 0x14

	// Properties
	public List<game.ActivityInfo> infos { get; set; }
	public bool HasInfos { get; }

	// Methods

	// RVA: 0x2258124 Offset: 0x2258124 VA: 0x2258124
	public List<game.ActivityInfo> get_infos() { }

	// RVA: 0x225812C Offset: 0x225812C VA: 0x225812C
	public void set_infos(List<game.ActivityInfo> value) { }

	// RVA: 0x225816C Offset: 0x225816C VA: 0x225816C
	public bool get_HasInfos() { }

	// RVA: 0x225819C Offset: 0x225819C VA: 0x225819C
	public void .ctor() { }

	// RVA: 0x2258238 Offset: 0x2258238 VA: 0x2258238
	public void .ctor(byte[] buffer) { }

	// RVA: 0x22582F0 Offset: 0x22582F0 VA: 0x22582F0 Slot: 5
	protected override void decode() { }

	// RVA: 0x22583BC Offset: 0x22583BC VA: 0x22583BC Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x22584B4 Offset: 0x22584B4 VA: 0x22584B4 Slot: 3
	public override string ToString() { }

	// RVA: 0x2258544 Offset: 0x2258544 VA: 0x2258544
	private static void .cctor() { }
}
