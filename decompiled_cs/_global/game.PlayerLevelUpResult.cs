// Namespace: 
public class game.PlayerLevelUpResult : SprotoTypeBase // TypeDefIndex: 9209
{
	// Fields
	private static int max_field_count; // 0x0
	private long _uid; // 0x18
	private long _old_level; // 0x20
	private long _old_exp; // 0x28
	private long _new_level; // 0x30
	private long _new_exp; // 0x38

	// Properties
	public long uid { get; set; }
	public bool HasUid { get; }
	public long old_level { get; set; }
	public bool HasOld_level { get; }
	public long old_exp { get; set; }
	public bool HasOld_exp { get; }
	public long new_level { get; set; }
	public bool HasNew_level { get; }
	public long new_exp { get; set; }
	public bool HasNew_exp { get; }

	// Methods

	// RVA: 0x25526B8 Offset: 0x25526B8 VA: 0x25526B8
	public long get_uid() { }

	// RVA: 0x25526C0 Offset: 0x25526C0 VA: 0x25526C0
	public void set_uid(long value) { }

	// RVA: 0x2552704 Offset: 0x2552704 VA: 0x2552704
	public bool get_HasUid() { }

	// RVA: 0x2552734 Offset: 0x2552734 VA: 0x2552734
	public long get_old_level() { }

	// RVA: 0x255273C Offset: 0x255273C VA: 0x255273C
	public void set_old_level(long value) { }

	// RVA: 0x2552780 Offset: 0x2552780 VA: 0x2552780
	public bool get_HasOld_level() { }

	// RVA: 0x25527B0 Offset: 0x25527B0 VA: 0x25527B0
	public long get_old_exp() { }

	// RVA: 0x25527B8 Offset: 0x25527B8 VA: 0x25527B8
	public void set_old_exp(long value) { }

	// RVA: 0x25527FC Offset: 0x25527FC VA: 0x25527FC
	public bool get_HasOld_exp() { }

	// RVA: 0x255282C Offset: 0x255282C VA: 0x255282C
	public long get_new_level() { }

	// RVA: 0x2552834 Offset: 0x2552834 VA: 0x2552834
	public void set_new_level(long value) { }

	// RVA: 0x2552878 Offset: 0x2552878 VA: 0x2552878
	public bool get_HasNew_level() { }

	// RVA: 0x25528A8 Offset: 0x25528A8 VA: 0x25528A8
	public long get_new_exp() { }

	// RVA: 0x25528B0 Offset: 0x25528B0 VA: 0x25528B0
	public void set_new_exp(long value) { }

	// RVA: 0x25528F4 Offset: 0x25528F4 VA: 0x25528F4
	public bool get_HasNew_exp() { }

	// RVA: 0x2552924 Offset: 0x2552924 VA: 0x2552924
	public void .ctor() { }

	// RVA: 0x25529C0 Offset: 0x25529C0 VA: 0x25529C0
	public void .ctor(byte[] buffer) { }

	// RVA: 0x2552A78 Offset: 0x2552A78 VA: 0x2552A78 Slot: 5
	protected override void decode() { }

	// RVA: 0x2552C0C Offset: 0x2552C0C VA: 0x2552C0C Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x2552E5C Offset: 0x2552E5C VA: 0x2552E5C Slot: 3
	public override string ToString() { }

	// RVA: 0x255314C Offset: 0x255314C VA: 0x255314C
	private static void .cctor() { }
}
