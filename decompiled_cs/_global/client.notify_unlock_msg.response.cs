// Namespace: 
public class client.notify_unlock_msg.response : SprotoTypeBase // TypeDefIndex: 9134
{
	// Fields
	private static int max_field_count; // 0x0
	private long _errorcode; // 0x18
	private List<game.SelectCharacterInfo> _unlock_characters; // 0x20

	// Properties
	public long errorcode { get; set; }
	public bool HasErrorcode { get; }
	public List<game.SelectCharacterInfo> unlock_characters { get; set; }
	public bool HasUnlock_characters { get; }

	// Methods

	// RVA: 0x24438D8 Offset: 0x24438D8 VA: 0x24438D8
	public long get_errorcode() { }

	// RVA: 0x24438E0 Offset: 0x24438E0 VA: 0x24438E0
	public void set_errorcode(long value) { }

	// RVA: 0x2443924 Offset: 0x2443924 VA: 0x2443924
	public bool get_HasErrorcode() { }

	// RVA: 0x2443954 Offset: 0x2443954 VA: 0x2443954
	public List<game.SelectCharacterInfo> get_unlock_characters() { }

	// RVA: 0x244395C Offset: 0x244395C VA: 0x244395C
	public void set_unlock_characters(List<game.SelectCharacterInfo> value) { }

	// RVA: 0x244399C Offset: 0x244399C VA: 0x244399C
	public bool get_HasUnlock_characters() { }

	// RVA: 0x24439CC Offset: 0x24439CC VA: 0x24439CC
	public void .ctor() { }

	// RVA: 0x2443A68 Offset: 0x2443A68 VA: 0x2443A68
	public void .ctor(byte[] buffer) { }

	// RVA: 0x2443B20 Offset: 0x2443B20 VA: 0x2443B20 Slot: 5
	protected override void decode() { }

	// RVA: 0x2443C40 Offset: 0x2443C40 VA: 0x2443C40 Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x2443DA0 Offset: 0x2443DA0 VA: 0x2443DA0 Slot: 3
	public override string ToString() { }

	// RVA: 0x2443E50 Offset: 0x2443E50 VA: 0x2443E50
	private static void .cctor() { }
}
