// Namespace: 
public class game.RspBattlePoints.request : SprotoTypeBase // TypeDefIndex: 9317
{
	// Fields
	private static int max_field_count; // 0x0
	private long _timestamp; // 0x18
	private long _player_id; // 0x20
	private List<game.ActionPoint> _points; // 0x28

	// Properties
	public long timestamp { get; set; }
	public bool HasTimestamp { get; }
	public long player_id { get; set; }
	public bool HasPlayer_id { get; }
	public List<game.ActionPoint> points { get; set; }
	public bool HasPoints { get; }

	// Methods

	// RVA: 0x2259B50 Offset: 0x2259B50 VA: 0x2259B50
	public long get_timestamp() { }

	// RVA: 0x2259B58 Offset: 0x2259B58 VA: 0x2259B58
	public void set_timestamp(long value) { }

	// RVA: 0x2259B9C Offset: 0x2259B9C VA: 0x2259B9C
	public bool get_HasTimestamp() { }

	// RVA: 0x2259BCC Offset: 0x2259BCC VA: 0x2259BCC
	public long get_player_id() { }

	// RVA: 0x2259BD4 Offset: 0x2259BD4 VA: 0x2259BD4
	public void set_player_id(long value) { }

	// RVA: 0x2259C18 Offset: 0x2259C18 VA: 0x2259C18
	public bool get_HasPlayer_id() { }

	// RVA: 0x2259C48 Offset: 0x2259C48 VA: 0x2259C48
	public List<game.ActionPoint> get_points() { }

	// RVA: 0x2259C50 Offset: 0x2259C50 VA: 0x2259C50
	public void set_points(List<game.ActionPoint> value) { }

	// RVA: 0x2259C90 Offset: 0x2259C90 VA: 0x2259C90
	public bool get_HasPoints() { }

	// RVA: 0x2259CC0 Offset: 0x2259CC0 VA: 0x2259CC0
	public void .ctor() { }

	// RVA: 0x2259D5C Offset: 0x2259D5C VA: 0x2259D5C
	public void .ctor(byte[] buffer) { }

	// RVA: 0x2259E14 Offset: 0x2259E14 VA: 0x2259E14 Slot: 5
	protected override void decode() { }

	// RVA: 0x2259F7C Offset: 0x2259F7C VA: 0x2259F7C Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x225A140 Offset: 0x225A140 VA: 0x225A140 Slot: 3
	public override string ToString() { }

	// RVA: 0x225A218 Offset: 0x225A218 VA: 0x225A218
	private static void .cctor() { }
}
