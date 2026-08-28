// Namespace: 
public class game.BattlePlayerResult : SprotoTypeBase // TypeDefIndex: 9200
{
	// Fields
	private static int max_field_count; // 0x0
	private long _uid; // 0x18
	private long _score; // 0x20
	private long _kill; // 0x28
	private long _assist; // 0x30
	private long _dead; // 0x38
	private bool _is_no_hurt; // 0x40
	private long _time_stamp; // 0x48
	private long _voicestate; // 0x50
	private long _rank_score; // 0x58

	// Properties
	public long uid { get; set; }
	public bool HasUid { get; }
	public long score { get; set; }
	public bool HasScore { get; }
	public long kill { get; set; }
	public bool HasKill { get; }
	public long assist { get; set; }
	public bool HasAssist { get; }
	public long dead { get; set; }
	public bool HasDead { get; }
	public bool is_no_hurt { get; set; }
	public bool HasIs_no_hurt { get; }
	public long time_stamp { get; set; }
	public bool HasTime_stamp { get; }
	public long voicestate { get; set; }
	public bool HasVoicestate { get; }
	public long rank_score { get; set; }
	public bool HasRank_score { get; }

	// Methods

	// RVA: 0x254B0F4 Offset: 0x254B0F4 VA: 0x254B0F4
	public long get_uid() { }

	// RVA: 0x254B0FC Offset: 0x254B0FC VA: 0x254B0FC
	public void set_uid(long value) { }

	// RVA: 0x254B140 Offset: 0x254B140 VA: 0x254B140
	public bool get_HasUid() { }

	// RVA: 0x254B170 Offset: 0x254B170 VA: 0x254B170
	public long get_score() { }

	// RVA: 0x254B178 Offset: 0x254B178 VA: 0x254B178
	public void set_score(long value) { }

	// RVA: 0x254B1BC Offset: 0x254B1BC VA: 0x254B1BC
	public bool get_HasScore() { }

	// RVA: 0x254B1EC Offset: 0x254B1EC VA: 0x254B1EC
	public long get_kill() { }

	// RVA: 0x254B1F4 Offset: 0x254B1F4 VA: 0x254B1F4
	public void set_kill(long value) { }

	// RVA: 0x254B238 Offset: 0x254B238 VA: 0x254B238
	public bool get_HasKill() { }

	// RVA: 0x254B268 Offset: 0x254B268 VA: 0x254B268
	public long get_assist() { }

	// RVA: 0x254B270 Offset: 0x254B270 VA: 0x254B270
	public void set_assist(long value) { }

	// RVA: 0x254B2B4 Offset: 0x254B2B4 VA: 0x254B2B4
	public bool get_HasAssist() { }

	// RVA: 0x254B2E4 Offset: 0x254B2E4 VA: 0x254B2E4
	public long get_dead() { }

	// RVA: 0x254B2EC Offset: 0x254B2EC VA: 0x254B2EC
	public void set_dead(long value) { }

	// RVA: 0x254B330 Offset: 0x254B330 VA: 0x254B330
	public bool get_HasDead() { }

	// RVA: 0x254B360 Offset: 0x254B360 VA: 0x254B360
	public bool get_is_no_hurt() { }

	// RVA: 0x254B368 Offset: 0x254B368 VA: 0x254B368
	public void set_is_no_hurt(bool value) { }

	// RVA: 0x254B3A8 Offset: 0x254B3A8 VA: 0x254B3A8
	public bool get_HasIs_no_hurt() { }

	// RVA: 0x254B3D8 Offset: 0x254B3D8 VA: 0x254B3D8
	public long get_time_stamp() { }

	// RVA: 0x254B3E0 Offset: 0x254B3E0 VA: 0x254B3E0
	public void set_time_stamp(long value) { }

	// RVA: 0x254B424 Offset: 0x254B424 VA: 0x254B424
	public bool get_HasTime_stamp() { }

	// RVA: 0x254B454 Offset: 0x254B454 VA: 0x254B454
	public long get_voicestate() { }

	// RVA: 0x254B45C Offset: 0x254B45C VA: 0x254B45C
	public void set_voicestate(long value) { }

	// RVA: 0x254B4A0 Offset: 0x254B4A0 VA: 0x254B4A0
	public bool get_HasVoicestate() { }

	// RVA: 0x254B4D0 Offset: 0x254B4D0 VA: 0x254B4D0
	public long get_rank_score() { }

	// RVA: 0x254B4D8 Offset: 0x254B4D8 VA: 0x254B4D8
	public void set_rank_score(long value) { }

	// RVA: 0x254B51C Offset: 0x254B51C VA: 0x254B51C
	public bool get_HasRank_score() { }

	// RVA: 0x254B54C Offset: 0x254B54C VA: 0x254B54C
	public void .ctor() { }

	// RVA: 0x254B5E8 Offset: 0x254B5E8 VA: 0x254B5E8
	public void .ctor(byte[] buffer) { }

	// RVA: 0x254B6A0 Offset: 0x254B6A0 VA: 0x254B6A0 Slot: 5
	protected override void decode() { }

	// RVA: 0x254B910 Offset: 0x254B910 VA: 0x254B910 Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x254BCEC Offset: 0x254BCEC VA: 0x254BCEC Slot: 3
	public override string ToString() { }

	// RVA: 0x254C1B8 Offset: 0x254C1B8 VA: 0x254C1B8
	private static void .cctor() { }
}
