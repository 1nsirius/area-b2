// Namespace: 
public class client.ping.request : SprotoTypeBase // TypeDefIndex: 9141
{
	// Fields
	private static int max_field_count; // 0x0
	private long _timestamp; // 0x18

	// Properties
	public long timestamp { get; set; }
	public bool HasTimestamp { get; }

	// Methods

	// RVA: 0x244504C Offset: 0x244504C VA: 0x244504C
	public long get_timestamp() { }

	// RVA: 0x2445054 Offset: 0x2445054 VA: 0x2445054
	public void set_timestamp(long value) { }

	// RVA: 0x2445098 Offset: 0x2445098 VA: 0x2445098
	public bool get_HasTimestamp() { }

	// RVA: 0x24450C8 Offset: 0x24450C8 VA: 0x24450C8
	public void .ctor() { }

	// RVA: 0x2445164 Offset: 0x2445164 VA: 0x2445164
	public void .ctor(byte[] buffer) { }

	// RVA: 0x244521C Offset: 0x244521C VA: 0x244521C Slot: 5
	protected override void decode() { }

	// RVA: 0x24452A4 Offset: 0x24452A4 VA: 0x24452A4 Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x2445364 Offset: 0x2445364 VA: 0x2445364 Slot: 3
	public override string ToString() { }

	// RVA: 0x24453F4 Offset: 0x24453F4 VA: 0x24453F4
	private static void .cctor() { }
}
