// Namespace: 
public class game.RspUnlockCharacter.request : SprotoTypeBase // TypeDefIndex: 9387
{
	// Fields
	private static int max_field_count; // 0x0
	private long _character_id; // 0x18
	private long _limit_time; // 0x20

	// Properties
	public long character_id { get; set; }
	public bool HasCharacter_id { get; }
	public long limit_time { get; set; }
	public bool HasLimit_time { get; }

	// Methods

	// RVA: 0x2267340 Offset: 0x2267340 VA: 0x2267340
	public long get_character_id() { }

	// RVA: 0x2267348 Offset: 0x2267348 VA: 0x2267348
	public void set_character_id(long value) { }

	// RVA: 0x226738C Offset: 0x226738C VA: 0x226738C
	public bool get_HasCharacter_id() { }

	// RVA: 0x22673BC Offset: 0x22673BC VA: 0x22673BC
	public long get_limit_time() { }

	// RVA: 0x22673C4 Offset: 0x22673C4 VA: 0x22673C4
	public void set_limit_time(long value) { }

	// RVA: 0x2267408 Offset: 0x2267408 VA: 0x2267408
	public bool get_HasLimit_time() { }

	// RVA: 0x2267438 Offset: 0x2267438 VA: 0x2267438
	public void .ctor() { }

	// RVA: 0x22674D4 Offset: 0x22674D4 VA: 0x22674D4
	public void .ctor(byte[] buffer) { }

	// RVA: 0x226758C Offset: 0x226758C VA: 0x226758C Slot: 5
	protected override void decode() { }

	// RVA: 0x2267668 Offset: 0x2267668 VA: 0x2267668 Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x226778C Offset: 0x226778C VA: 0x226778C Slot: 3
	public override string ToString() { }

	// RVA: 0x226783C Offset: 0x226783C VA: 0x226783C
	private static void .cctor() { }
}
