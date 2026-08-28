// Namespace: 
public class game.SelectCharacterInfo : SprotoTypeBase // TypeDefIndex: 9396
{
	// Fields
	private static int max_field_count; // 0x0
	private long _character_id; // 0x18
	private long _unlock_time; // 0x20
	private long _limit_time; // 0x28

	// Properties
	public long character_id { get; set; }
	public bool HasCharacter_id { get; }
	public long unlock_time { get; set; }
	public bool HasUnlock_time { get; }
	public long limit_time { get; set; }
	public bool HasLimit_time { get; }

	// Methods

	// RVA: 0x22697C8 Offset: 0x22697C8 VA: 0x22697C8
	public long get_character_id() { }

	// RVA: 0x22697D0 Offset: 0x22697D0 VA: 0x22697D0
	public void set_character_id(long value) { }

	// RVA: 0x2269814 Offset: 0x2269814 VA: 0x2269814
	public bool get_HasCharacter_id() { }

	// RVA: 0x2269844 Offset: 0x2269844 VA: 0x2269844
	public long get_unlock_time() { }

	// RVA: 0x226984C Offset: 0x226984C VA: 0x226984C
	public void set_unlock_time(long value) { }

	// RVA: 0x2269890 Offset: 0x2269890 VA: 0x2269890
	public bool get_HasUnlock_time() { }

	// RVA: 0x22698C0 Offset: 0x22698C0 VA: 0x22698C0
	public long get_limit_time() { }

	// RVA: 0x22698C8 Offset: 0x22698C8 VA: 0x22698C8
	public void set_limit_time(long value) { }

	// RVA: 0x226990C Offset: 0x226990C VA: 0x226990C
	public bool get_HasLimit_time() { }

	// RVA: 0x226993C Offset: 0x226993C VA: 0x226993C
	public void .ctor() { }

	// RVA: 0x22699D8 Offset: 0x22699D8 VA: 0x22699D8
	public void .ctor(byte[] buffer) { }

	// RVA: 0x2269A90 Offset: 0x2269A90 VA: 0x2269A90 Slot: 5
	protected override void decode() { }

	// RVA: 0x2269BB4 Offset: 0x2269BB4 VA: 0x2269BB4 Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x2269D3C Offset: 0x2269D3C VA: 0x2269D3C Slot: 3
	public override string ToString() { }

	// RVA: 0x2269E14 Offset: 0x2269E14 VA: 0x2269E14
	private static void .cctor() { }
}
