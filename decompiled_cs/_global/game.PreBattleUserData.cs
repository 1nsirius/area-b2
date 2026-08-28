// Namespace: 
public class game.PreBattleUserData : SprotoTypeBase // TypeDefIndex: 9210
{
	// Fields
	private static int max_field_count; // 0x0
	private long _uid; // 0x18
	private long _character_id; // 0x20
	private long _stage; // 0x28
	private List<long> _skin; // 0x30

	// Properties
	public long uid { get; set; }
	public bool HasUid { get; }
	public long character_id { get; set; }
	public bool HasCharacter_id { get; }
	public long stage { get; set; }
	public bool HasStage { get; }
	public List<long> skin { get; set; }
	public bool HasSkin { get; }

	// Methods

	// RVA: 0x25531B4 Offset: 0x25531B4 VA: 0x25531B4
	public long get_uid() { }

	// RVA: 0x25531BC Offset: 0x25531BC VA: 0x25531BC
	public void set_uid(long value) { }

	// RVA: 0x2553200 Offset: 0x2553200 VA: 0x2553200
	public bool get_HasUid() { }

	// RVA: 0x2553230 Offset: 0x2553230 VA: 0x2553230
	public long get_character_id() { }

	// RVA: 0x2553238 Offset: 0x2553238 VA: 0x2553238
	public void set_character_id(long value) { }

	// RVA: 0x255327C Offset: 0x255327C VA: 0x255327C
	public bool get_HasCharacter_id() { }

	// RVA: 0x25532AC Offset: 0x25532AC VA: 0x25532AC
	public long get_stage() { }

	// RVA: 0x25532B4 Offset: 0x25532B4 VA: 0x25532B4
	public void set_stage(long value) { }

	// RVA: 0x25532F8 Offset: 0x25532F8 VA: 0x25532F8
	public bool get_HasStage() { }

	// RVA: 0x2553328 Offset: 0x2553328 VA: 0x2553328
	public List<long> get_skin() { }

	// RVA: 0x2553330 Offset: 0x2553330 VA: 0x2553330
	public void set_skin(List<long> value) { }

	// RVA: 0x2553370 Offset: 0x2553370 VA: 0x2553370
	public bool get_HasSkin() { }

	// RVA: 0x25533A0 Offset: 0x25533A0 VA: 0x25533A0
	public void .ctor() { }

	// RVA: 0x255343C Offset: 0x255343C VA: 0x255343C
	public void .ctor(byte[] buffer) { }

	// RVA: 0x25534F4 Offset: 0x25534F4 VA: 0x25534F4 Slot: 5
	protected override void decode() { }

	// RVA: 0x255364C Offset: 0x255364C VA: 0x255364C Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x255382C Offset: 0x255382C VA: 0x255382C Slot: 3
	public override string ToString() { }

	// RVA: 0x2553A98 Offset: 0x2553A98 VA: 0x2553A98
	private static void .cctor() { }
}
