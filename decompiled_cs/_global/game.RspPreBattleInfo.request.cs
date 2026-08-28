// Namespace: 
public class game.RspPreBattleInfo.request : SprotoTypeBase // TypeDefIndex: 9367
{
	// Fields
	private static int max_field_count; // 0x0
	private List<game.PreBattleUserData> _my_team_user_data; // 0x14
	private game.ChooseWeaponData _choose_weapon_data; // 0x18

	// Properties
	public List<game.PreBattleUserData> my_team_user_data { get; set; }
	public bool HasMy_team_user_data { get; }
	public game.ChooseWeaponData choose_weapon_data { get; set; }
	public bool HasChoose_weapon_data { get; }

	// Methods

	// RVA: 0x2262F9C Offset: 0x2262F9C VA: 0x2262F9C
	public List<game.PreBattleUserData> get_my_team_user_data() { }

	// RVA: 0x2262FA4 Offset: 0x2262FA4 VA: 0x2262FA4
	public void set_my_team_user_data(List<game.PreBattleUserData> value) { }

	// RVA: 0x2262FE4 Offset: 0x2262FE4 VA: 0x2262FE4
	public bool get_HasMy_team_user_data() { }

	// RVA: 0x2263014 Offset: 0x2263014 VA: 0x2263014
	public game.ChooseWeaponData get_choose_weapon_data() { }

	// RVA: 0x226301C Offset: 0x226301C VA: 0x226301C
	public void set_choose_weapon_data(game.ChooseWeaponData value) { }

	// RVA: 0x226305C Offset: 0x226305C VA: 0x226305C
	public bool get_HasChoose_weapon_data() { }

	// RVA: 0x226308C Offset: 0x226308C VA: 0x226308C
	public void .ctor() { }

	// RVA: 0x2263128 Offset: 0x2263128 VA: 0x2263128
	public void .ctor(byte[] buffer) { }

	// RVA: 0x22631E0 Offset: 0x22631E0 VA: 0x22631E0 Slot: 5
	protected override void decode() { }

	// RVA: 0x22632FC Offset: 0x22632FC VA: 0x22632FC Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x226344C Offset: 0x226344C VA: 0x226344C Slot: 3
	public override string ToString() { }

	// RVA: 0x22634D0 Offset: 0x22634D0 VA: 0x22634D0
	private static void .cctor() { }
}
