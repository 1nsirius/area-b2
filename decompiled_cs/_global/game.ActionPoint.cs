// Namespace: 
public class game.ActionPoint : SprotoTypeBase // TypeDefIndex: 9190
{
	// Fields
	private static int max_field_count; // 0x0
	private long _action; // 0x18
	private long _point; // 0x20

	// Properties
	public long action { get; set; }
	public bool HasAction { get; }
	public long point { get; set; }
	public bool HasPoint { get; }

	// Methods

	// RVA: 0x2547800 Offset: 0x2547800 VA: 0x2547800
	public long get_action() { }

	// RVA: 0x2547808 Offset: 0x2547808 VA: 0x2547808
	public void set_action(long value) { }

	// RVA: 0x254784C Offset: 0x254784C VA: 0x254784C
	public bool get_HasAction() { }

	// RVA: 0x254787C Offset: 0x254787C VA: 0x254787C
	public long get_point() { }

	// RVA: 0x2547884 Offset: 0x2547884 VA: 0x2547884
	public void set_point(long value) { }

	// RVA: 0x25478C8 Offset: 0x25478C8 VA: 0x25478C8
	public bool get_HasPoint() { }

	// RVA: 0x25478F8 Offset: 0x25478F8 VA: 0x25478F8
	public void .ctor() { }

	// RVA: 0x2547994 Offset: 0x2547994 VA: 0x2547994
	public void .ctor(byte[] buffer) { }

	// RVA: 0x2547A4C Offset: 0x2547A4C VA: 0x2547A4C Slot: 5
	protected override void decode() { }

	// RVA: 0x2547B28 Offset: 0x2547B28 VA: 0x2547B28 Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x2547C4C Offset: 0x2547C4C VA: 0x2547C4C Slot: 3
	public override string ToString() { }

	// RVA: 0x2547CFC Offset: 0x2547CFC VA: 0x2547CFC
	private static void .cctor() { }
}
