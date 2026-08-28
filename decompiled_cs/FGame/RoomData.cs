namespace FGame
{

// Namespace: FGame
public class RoomData : BaseSingleton<RoomData> // TypeDefIndex: 9945
{
	// Fields
	[CompilerGeneratedAttribute] // RVA: 0x5637B4 Offset: 0x5637B4 VA: 0x5637B4
	private uint <BattleZone>k__BackingField; // 0x8
	[CompilerGeneratedAttribute] // RVA: 0x5637C4 Offset: 0x5637C4 VA: 0x5637C4
	private uint <OwnerUid>k__BackingField; // 0xC
	[CompilerGeneratedAttribute] // RVA: 0x5637D4 Offset: 0x5637D4 VA: 0x5637D4
	private long <room_id>k__BackingField; // 0x10
	[CompilerGeneratedAttribute] // RVA: 0x5637E4 Offset: 0x5637E4 VA: 0x5637E4
	private long <map_id>k__BackingField; // 0x18
	[CompilerGeneratedAttribute] // RVA: 0x5637F4 Offset: 0x5637F4 VA: 0x5637F4
	private long <mode_id>k__BackingField; // 0x20

	// Properties
	public uint BattleZone { get; set; }
	public uint OwnerUid { get; set; }
	public long room_id { get; set; }
	public long owner_id { get; }
	public long battle_zone { get; }
	public long map_id { get; set; }
	public long mode_id { get; set; }

	// Methods

	[CompilerGeneratedAttribute] // RVA: 0x647340 Offset: 0x647340 VA: 0x647340
	// RVA: 0xB82320 Offset: 0xB82320 VA: 0xB82320
	public uint get_BattleZone() { }

	[CompilerGeneratedAttribute] // RVA: 0x647350 Offset: 0x647350 VA: 0x647350
	// RVA: 0xB82328 Offset: 0xB82328 VA: 0xB82328
	private void set_BattleZone(uint value) { }

	[CompilerGeneratedAttribute] // RVA: 0x647360 Offset: 0x647360 VA: 0x647360
	// RVA: 0xB82330 Offset: 0xB82330 VA: 0xB82330
	public uint get_OwnerUid() { }

	[CompilerGeneratedAttribute] // RVA: 0x647370 Offset: 0x647370 VA: 0x647370
	// RVA: 0xB82338 Offset: 0xB82338 VA: 0xB82338
	private void set_OwnerUid(uint value) { }

	[CompilerGeneratedAttribute] // RVA: 0x647380 Offset: 0x647380 VA: 0x647380
	// RVA: 0xB82340 Offset: 0xB82340 VA: 0xB82340
	public long get_room_id() { }

	[CompilerGeneratedAttribute] // RVA: 0x647390 Offset: 0x647390 VA: 0x647390
	// RVA: 0xB82348 Offset: 0xB82348 VA: 0xB82348
	private void set_room_id(long value) { }

	// RVA: 0xB82358 Offset: 0xB82358 VA: 0xB82358
	public long get_owner_id() { }

	// RVA: 0xB82364 Offset: 0xB82364 VA: 0xB82364
	public long get_battle_zone() { }

	[CompilerGeneratedAttribute] // RVA: 0x6473A0 Offset: 0x6473A0 VA: 0x6473A0
	// RVA: 0xB82370 Offset: 0xB82370 VA: 0xB82370
	public long get_map_id() { }

	[CompilerGeneratedAttribute] // RVA: 0x6473B0 Offset: 0x6473B0 VA: 0x6473B0
	// RVA: 0xB82378 Offset: 0xB82378 VA: 0xB82378
	private void set_map_id(long value) { }

	[CompilerGeneratedAttribute] // RVA: 0x6473C0 Offset: 0x6473C0 VA: 0x6473C0
	// RVA: 0xB82388 Offset: 0xB82388 VA: 0xB82388
	public long get_mode_id() { }

	[CompilerGeneratedAttribute] // RVA: 0x6473D0 Offset: 0x6473D0 VA: 0x6473D0
	// RVA: 0xB82390 Offset: 0xB82390 VA: 0xB82390
	private void set_mode_id(long value) { }

	// RVA: 0xB823A0 Offset: 0xB823A0 VA: 0xB823A0
	public void Refill(game.RspRoomEntered.request pkt) { }

	// RVA: 0xB825A8 Offset: 0xB825A8 VA: 0xB825A8
	public void Clear() { }

	// RVA: 0xB825AC Offset: 0xB825AC VA: 0xB825AC
	public void SetBattleZoneId(uint battleZone) { }

	// RVA: 0xB82704 Offset: 0xB82704 VA: 0xB82704
	public void SetOwnerId(uint ownerId) { }

	// RVA: 0xB8270C Offset: 0xB8270C VA: 0xB8270C
	public void .ctor() { }
}

} // namespace FGame
