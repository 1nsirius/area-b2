// Namespace: 
public class game.RspOnLineNumber.request : SprotoTypeBase // TypeDefIndex: 9357
{
	// Fields
	private static int max_field_count; // 0x0
	private long _matching_player_number; // 0x18
	private long _in_battle_player_number; // 0x20

	// Properties
	public long matching_player_number { get; set; }
	public bool HasMatching_player_number { get; }
	public long in_battle_player_number { get; set; }
	public bool HasIn_battle_player_number { get; }

	// Methods

	// RVA: 0x22615C4 Offset: 0x22615C4 VA: 0x22615C4
	public long get_matching_player_number() { }

	// RVA: 0x22615CC Offset: 0x22615CC VA: 0x22615CC
	public void set_matching_player_number(long value) { }

	// RVA: 0x2261610 Offset: 0x2261610 VA: 0x2261610
	public bool get_HasMatching_player_number() { }

	// RVA: 0x2261640 Offset: 0x2261640 VA: 0x2261640
	public long get_in_battle_player_number() { }

	// RVA: 0x2261648 Offset: 0x2261648 VA: 0x2261648
	public void set_in_battle_player_number(long value) { }

	// RVA: 0x226168C Offset: 0x226168C VA: 0x226168C
	public bool get_HasIn_battle_player_number() { }

	// RVA: 0x22616BC Offset: 0x22616BC VA: 0x22616BC
	public void .ctor() { }

	// RVA: 0x2261758 Offset: 0x2261758 VA: 0x2261758
	public void .ctor(byte[] buffer) { }

	// RVA: 0x2261810 Offset: 0x2261810 VA: 0x2261810 Slot: 5
	protected override void decode() { }

	// RVA: 0x22618EC Offset: 0x22618EC VA: 0x22618EC Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x2261A10 Offset: 0x2261A10 VA: 0x2261A10 Slot: 3
	public override string ToString() { }

	// RVA: 0x2261AC0 Offset: 0x2261AC0 VA: 0x2261AC0
	private static void .cctor() { }
}
