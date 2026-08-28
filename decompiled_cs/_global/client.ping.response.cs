// Namespace: 
public class client.ping.response : SprotoTypeBase // TypeDefIndex: 9142
{
	// Fields
	private static int max_field_count; // 0x0
	private long _timestamp; // 0x18

	// Properties
	public long timestamp { get; set; }
	public bool HasTimestamp { get; }

	// Methods

	// RVA: 0x244545C Offset: 0x244545C VA: 0x244545C
	public long get_timestamp() { }

	// RVA: 0x2445464 Offset: 0x2445464 VA: 0x2445464
	public void set_timestamp(long value) { }

	// RVA: 0x24454A8 Offset: 0x24454A8 VA: 0x24454A8
	public bool get_HasTimestamp() { }

	// RVA: 0x24454D8 Offset: 0x24454D8 VA: 0x24454D8
	public void .ctor() { }

	// RVA: 0x2445574 Offset: 0x2445574 VA: 0x2445574
	public void .ctor(byte[] buffer) { }

	// RVA: 0x244562C Offset: 0x244562C VA: 0x244562C Slot: 5
	protected override void decode() { }

	// RVA: 0x24456B4 Offset: 0x24456B4 VA: 0x24456B4 Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x2445774 Offset: 0x2445774 VA: 0x2445774 Slot: 3
	public override string ToString() { }

	// RVA: 0x2445804 Offset: 0x2445804 VA: 0x2445804
	private static void .cctor() { }
}
