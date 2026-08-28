// Namespace: 
public class game.RspChangeVoiceState.request : SprotoTypeBase // TypeDefIndex: 9329
{
	// Fields
	private static int max_field_count; // 0x0
	private long _state; // 0x18
	private long _uid; // 0x20

	// Properties
	public long state { get; set; }
	public bool HasState { get; }
	public long uid { get; set; }
	public bool HasUid { get; }

	// Methods

	// RVA: 0x225B77C Offset: 0x225B77C VA: 0x225B77C
	public long get_state() { }

	// RVA: 0x225B784 Offset: 0x225B784 VA: 0x225B784
	public void set_state(long value) { }

	// RVA: 0x225B7C8 Offset: 0x225B7C8 VA: 0x225B7C8
	public bool get_HasState() { }

	// RVA: 0x225B7F8 Offset: 0x225B7F8 VA: 0x225B7F8
	public long get_uid() { }

	// RVA: 0x225B800 Offset: 0x225B800 VA: 0x225B800
	public void set_uid(long value) { }

	// RVA: 0x225B844 Offset: 0x225B844 VA: 0x225B844
	public bool get_HasUid() { }

	// RVA: 0x225B874 Offset: 0x225B874 VA: 0x225B874
	public void .ctor() { }

	// RVA: 0x225B910 Offset: 0x225B910 VA: 0x225B910
	public void .ctor(byte[] buffer) { }

	// RVA: 0x225B9C8 Offset: 0x225B9C8 VA: 0x225B9C8 Slot: 5
	protected override void decode() { }

	// RVA: 0x225BAA4 Offset: 0x225BAA4 VA: 0x225BAA4 Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x225BBC8 Offset: 0x225BBC8 VA: 0x225BBC8 Slot: 3
	public override string ToString() { }

	// RVA: 0x225BC78 Offset: 0x225BC78 VA: 0x225BC78
	private static void .cctor() { }
}
