// Namespace: 
public class client.EventStat : SprotoTypeBase // TypeDefIndex: 9060
{
	// Fields
	private static int max_field_count; // 0x0
	private string _event_type; // 0x14
	private List<client.Stat> _stats; // 0x18

	// Properties
	public string event_type { get; set; }
	public bool HasEvent_type { get; }
	public List<client.Stat> stats { get; set; }
	public bool HasStats { get; }

	// Methods

	// RVA: 0x24313B8 Offset: 0x24313B8 VA: 0x24313B8
	public string get_event_type() { }

	// RVA: 0x24313C0 Offset: 0x24313C0 VA: 0x24313C0
	public void set_event_type(string value) { }

	// RVA: 0x2431400 Offset: 0x2431400 VA: 0x2431400
	public bool get_HasEvent_type() { }

	// RVA: 0x2431430 Offset: 0x2431430 VA: 0x2431430
	public List<client.Stat> get_stats() { }

	// RVA: 0x2431438 Offset: 0x2431438 VA: 0x2431438
	public void set_stats(List<client.Stat> value) { }

	// RVA: 0x2431478 Offset: 0x2431478 VA: 0x2431478
	public bool get_HasStats() { }

	// RVA: 0x24314A8 Offset: 0x24314A8 VA: 0x24314A8
	public void .ctor() { }

	// RVA: 0x2431544 Offset: 0x2431544 VA: 0x2431544
	public void .ctor(byte[] buffer) { }

	// RVA: 0x24315FC Offset: 0x24315FC VA: 0x24315FC Slot: 5
	protected override void decode() { }

	// RVA: 0x243170C Offset: 0x243170C VA: 0x243170C Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x243185C Offset: 0x243185C VA: 0x243185C Slot: 3
	public override string ToString() { }

	// RVA: 0x2431AE4 Offset: 0x2431AE4 VA: 0x2431AE4
	private static void .cctor() { }
}
