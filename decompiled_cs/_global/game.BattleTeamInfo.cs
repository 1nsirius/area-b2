// Namespace: 
public class game.BattleTeamInfo : SprotoTypeBase // TypeDefIndex: 9201
{
	// Fields
	private static int max_field_count; // 0x0
	private long _team; // 0x18
	private long _camp; // 0x20
	private long _win_times; // 0x28
	private List<game.CharacterChoosePlayer> _players; // 0x30

	// Properties
	public long team { get; set; }
	public bool HasTeam { get; }
	public long camp { get; set; }
	public bool HasCamp { get; }
	public long win_times { get; set; }
	public bool HasWin_times { get; }
	public List<game.CharacterChoosePlayer> players { get; set; }
	public bool HasPlayers { get; }

	// Methods

	// RVA: 0x254C220 Offset: 0x254C220 VA: 0x254C220
	public long get_team() { }

	// RVA: 0x254C228 Offset: 0x254C228 VA: 0x254C228
	public void set_team(long value) { }

	// RVA: 0x254C26C Offset: 0x254C26C VA: 0x254C26C
	public bool get_HasTeam() { }

	// RVA: 0x254C29C Offset: 0x254C29C VA: 0x254C29C
	public long get_camp() { }

	// RVA: 0x254C2A4 Offset: 0x254C2A4 VA: 0x254C2A4
	public void set_camp(long value) { }

	// RVA: 0x254C2E8 Offset: 0x254C2E8 VA: 0x254C2E8
	public bool get_HasCamp() { }

	// RVA: 0x254C318 Offset: 0x254C318 VA: 0x254C318
	public long get_win_times() { }

	// RVA: 0x254C320 Offset: 0x254C320 VA: 0x254C320
	public void set_win_times(long value) { }

	// RVA: 0x254C364 Offset: 0x254C364 VA: 0x254C364
	public bool get_HasWin_times() { }

	// RVA: 0x254C394 Offset: 0x254C394 VA: 0x254C394
	public List<game.CharacterChoosePlayer> get_players() { }

	// RVA: 0x254C39C Offset: 0x254C39C VA: 0x254C39C
	public void set_players(List<game.CharacterChoosePlayer> value) { }

	// RVA: 0x254C3DC Offset: 0x254C3DC VA: 0x254C3DC
	public bool get_HasPlayers() { }

	// RVA: 0x254C40C Offset: 0x254C40C VA: 0x254C40C
	public void .ctor() { }

	// RVA: 0x254C4A8 Offset: 0x254C4A8 VA: 0x254C4A8
	public void .ctor(byte[] buffer) { }

	// RVA: 0x254C560 Offset: 0x254C560 VA: 0x254C560 Slot: 5
	protected override void decode() { }

	// RVA: 0x254C700 Offset: 0x254C700 VA: 0x254C700 Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x254C928 Offset: 0x254C928 VA: 0x254C928 Slot: 3
	public override string ToString() { }

	// RVA: 0x254CB94 Offset: 0x254CB94 VA: 0x254CB94
	private static void .cctor() { }
}
