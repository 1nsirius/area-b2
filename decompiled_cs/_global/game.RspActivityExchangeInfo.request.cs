// Namespace: 
public class game.RspActivityExchangeInfo.request : SprotoTypeBase // TypeDefIndex: 9307
{
	// Fields
	private static int max_field_count; // 0x0
	private long _activity_id; // 0x18
	private List<game.ActivityExchangeItem> _items; // 0x20
	private List<game.ActivityExchangeInfo> _infos; // 0x24

	// Properties
	public long activity_id { get; set; }
	public bool HasActivity_id { get; }
	public List<game.ActivityExchangeItem> items { get; set; }
	public bool HasItems { get; }
	public List<game.ActivityExchangeInfo> infos { get; set; }
	public bool HasInfos { get; }

	// Methods

	// RVA: 0x225747C Offset: 0x225747C VA: 0x225747C
	public long get_activity_id() { }

	// RVA: 0x2257484 Offset: 0x2257484 VA: 0x2257484
	public void set_activity_id(long value) { }

	// RVA: 0x22574C8 Offset: 0x22574C8 VA: 0x22574C8
	public bool get_HasActivity_id() { }

	// RVA: 0x22574F8 Offset: 0x22574F8 VA: 0x22574F8
	public List<game.ActivityExchangeItem> get_items() { }

	// RVA: 0x2257500 Offset: 0x2257500 VA: 0x2257500
	public void set_items(List<game.ActivityExchangeItem> value) { }

	// RVA: 0x2257540 Offset: 0x2257540 VA: 0x2257540
	public bool get_HasItems() { }

	// RVA: 0x2257570 Offset: 0x2257570 VA: 0x2257570
	public List<game.ActivityExchangeInfo> get_infos() { }

	// RVA: 0x2257578 Offset: 0x2257578 VA: 0x2257578
	public void set_infos(List<game.ActivityExchangeInfo> value) { }

	// RVA: 0x22575B8 Offset: 0x22575B8 VA: 0x22575B8
	public bool get_HasInfos() { }

	// RVA: 0x22575E8 Offset: 0x22575E8 VA: 0x22575E8
	public void .ctor() { }

	// RVA: 0x2257684 Offset: 0x2257684 VA: 0x2257684
	public void .ctor(byte[] buffer) { }

	// RVA: 0x225773C Offset: 0x225773C VA: 0x225773C Slot: 5
	protected override void decode() { }

	// RVA: 0x22578AC Offset: 0x22578AC VA: 0x22578AC Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x2257A70 Offset: 0x2257A70 VA: 0x2257A70 Slot: 3
	public override string ToString() { }

	// RVA: 0x2257B48 Offset: 0x2257B48 VA: 0x2257B48
	private static void .cctor() { }
}
