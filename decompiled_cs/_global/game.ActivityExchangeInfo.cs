// Namespace: 
public class game.ActivityExchangeInfo : SprotoTypeBase // TypeDefIndex: 9191
{
	// Fields
	private static int max_field_count; // 0x0
	private long _exchange_id; // 0x18
	private long _exchange_times; // 0x20
	private long _max_exchange_times; // 0x28

	// Properties
	public long exchange_id { get; set; }
	public bool HasExchange_id { get; }
	public long exchange_times { get; set; }
	public bool HasExchange_times { get; }
	public long max_exchange_times { get; set; }
	public bool HasMax_exchange_times { get; }

	// Methods

	// RVA: 0x2547D64 Offset: 0x2547D64 VA: 0x2547D64
	public long get_exchange_id() { }

	// RVA: 0x2547D6C Offset: 0x2547D6C VA: 0x2547D6C
	public void set_exchange_id(long value) { }

	// RVA: 0x2547DB0 Offset: 0x2547DB0 VA: 0x2547DB0
	public bool get_HasExchange_id() { }

	// RVA: 0x2547DE0 Offset: 0x2547DE0 VA: 0x2547DE0
	public long get_exchange_times() { }

	// RVA: 0x2547DE8 Offset: 0x2547DE8 VA: 0x2547DE8
	public void set_exchange_times(long value) { }

	// RVA: 0x2547E2C Offset: 0x2547E2C VA: 0x2547E2C
	public bool get_HasExchange_times() { }

	// RVA: 0x2547E5C Offset: 0x2547E5C VA: 0x2547E5C
	public long get_max_exchange_times() { }

	// RVA: 0x2547E64 Offset: 0x2547E64 VA: 0x2547E64
	public void set_max_exchange_times(long value) { }

	// RVA: 0x2547EA8 Offset: 0x2547EA8 VA: 0x2547EA8
	public bool get_HasMax_exchange_times() { }

	// RVA: 0x2547ED8 Offset: 0x2547ED8 VA: 0x2547ED8
	public void .ctor() { }

	// RVA: 0x2547F74 Offset: 0x2547F74 VA: 0x2547F74
	public void .ctor(byte[] buffer) { }

	// RVA: 0x254802C Offset: 0x254802C VA: 0x254802C Slot: 5
	protected override void decode() { }

	// RVA: 0x2548150 Offset: 0x2548150 VA: 0x2548150 Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x25482D8 Offset: 0x25482D8 VA: 0x25482D8 Slot: 3
	public override string ToString() { }

	// RVA: 0x25483B0 Offset: 0x25483B0 VA: 0x25483B0
	private static void .cctor() { }
}
