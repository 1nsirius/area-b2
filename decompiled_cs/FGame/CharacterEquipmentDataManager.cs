namespace FGame
{

// Namespace: FGame
[LuaCallCSharpAttribute] // RVA: 0x553E2C Offset: 0x553E2C VA: 0x553E2C
public sealed class CharacterEquipmentDataManager : BaseSingleton<CharacterEquipmentDataManager> // TypeDefIndex: 9894
{
	// Fields
	private Dictionary<int, CharacterEquipmentDataManager.CharacterData> mDataDict; // 0x8
	private List<CharacterEquipmentDataManager.CharacterData> mDataList; // 0xC
	private IComparer<CharacterEquipmentDataManager.CharacterData> mSorter; // 0x10
	private List<CharacterEquipmentDataManager.CharacterData> mTempResult; // 0x14

	// Methods

	// RVA: 0xBF8D00 Offset: 0xBF8D00 VA: 0xBF8D00
	public void Initialize() { }

	// RVA: 0xBF8E2C Offset: 0xBF8E2C VA: 0xBF8E2C
	public void Shutdown() { }

	// RVA: 0xBF8F58 Offset: 0xBF8F58 VA: 0xBF8F58
	private void SortDataToList() { }

	// RVA: 0xBF9124 Offset: 0xBF9124 VA: 0xBF9124
	private void SendChangeWeapon(int characterID, WeaponChooseKind kind, int equipmentID) { }

	// RVA: 0xBF971C Offset: 0xBF971C VA: 0xBF971C
	private void OnGetCharInfoResponse(SprotoTypeBase msg) { }

	// RVA: 0xBF9A94 Offset: 0xBF9A94 VA: 0xBF9A94
	private void TryGetSightID(game.CharacterInfo info, Dictionary<int, int> mapper) { }

	// RVA: 0xBF9DE4 Offset: 0xBF9DE4 VA: 0xBF9DE4
	private void OnChooseWeaponResponse(SprotoTypeBase msg) { }

	// RVA: 0xBFA128 Offset: 0xBFA128 VA: 0xBFA128
	public void OnLogin() { }

	// RVA: 0xBFA12C Offset: 0xBFA12C VA: 0xBFA12C
	public void AskAll() { }

	// RVA: 0xBFA1D4 Offset: 0xBFA1D4 VA: 0xBFA1D4
	public List<CharacterEquipmentDataManager.CharacterData> FindAgentsByEquipmentID(int equipmentID) { }

	// RVA: 0xBF93C8 Offset: 0xBF93C8 VA: 0xBF93C8
	public CharacterEquipmentDataManager.CharacterData FindAgentByID(int agentID) { }

	// RVA: 0xBFA3C0 Offset: 0xBFA3C0 VA: 0xBFA3C0
	public int GetDefaultSightID(int weaponID) { }

	// RVA: 0xBFA480 Offset: 0xBFA480 VA: 0xBFA480
	public void RemoveSight(int characterID) { }

	// RVA: 0xBFA4CC Offset: 0xBFA4CC VA: 0xBFA4CC
	public void SetCharacterEquipment(int characterID, int equipmentID) { }

	// RVA: 0xBFA8A0 Offset: 0xBFA8A0 VA: 0xBFA8A0
	public void TriggerAnimation(RectTransform rect, string anim) { }

	// RVA: 0xBFA998 Offset: 0xBFA998 VA: 0xBFA998
	public void .ctor() { }
}

} // namespace FGame
