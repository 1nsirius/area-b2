// Namespace: 
public class client.god_player_req.response : SprotoTypeBase // TypeDefIndex: 9123
{
	// Fields
	private static int max_field_count; // 0x0
	private long _errorcode; // 0x18
	private long _rank; // 0x20

	// Properties
	public long errorcode { get; set; }
	public bool HasErrorcode { get; }
	public long rank { get; set; }
	public bool HasRank { get; }

	// Methods

	// RVA: 0x24415B4 Offset: 0x24415B4 VA: 0x24415B4
	public long get_errorcode() { }

	// RVA: 0x24415BC Offset: 0x24415BC VA: 0x24415BC
	public void set_errorcode(long value) { }

	// RVA: 0x2441600 Offset: 0x2441600 VA: 0x2441600
	public bool get_HasErrorcode() { }

	// RVA: 0x2441630 Offset: 0x2441630 VA: 0x2441630
	public long get_rank() { }

	// RVA: 0x2441638 Offset: 0x2441638 VA: 0x2441638
	public void set_rank(long value) { }

	// RVA: 0x244167C Offset: 0x244167C VA: 0x244167C
	public bool get_HasRank() { }

	// RVA: 0x24416AC Offset: 0x24416AC VA: 0x24416AC
	public void .ctor() { }

	// RVA: 0x2441748 Offset: 0x2441748 VA: 0x2441748
	public void .ctor(byte[] buffer) { }

	// RVA: 0x2441800 Offset: 0x2441800 VA: 0x2441800 Slot: 5
	protected override void decode() { }

	// RVA: 0x24418DC Offset: 0x24418DC VA: 0x24418DC Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x2441A00 Offset: 0x2441A00 VA: 0x2441A00 Slot: 3
	public override string ToString() { }

	// RVA: 0x2441AB0 Offset: 0x2441AB0 VA: 0x2441AB0
	private static void .cctor() { }
}
