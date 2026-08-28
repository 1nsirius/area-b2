// Namespace: 
public class CharacterEquipmentDataManager.CharacterData : IComparer<CharacterEquipmentDataManager.CharacterData> // TypeDefIndex: 9895
{
	// Fields
	public int CharacterID; // 0x8
	public int MainWeaponID; // 0xC
	public int SubWeaponID; // 0x10
	public int MainPropID; // 0x14
	public int SubPropID; // 0x18
	public Dictionary<int, int> SightDict; // 0x1C

	// Properties
	public int SightID { get; set; }

	// Methods

	// RVA: 0xBF9658 Offset: 0xBF9658 VA: 0xBF9658
	public int get_SightID() { }

	// RVA: 0xBFA0A0 Offset: 0xBFA0A0 VA: 0xBFA0A0
	public void set_SightID(int value) { }

	// RVA: 0xBFA368 Offset: 0xBFA368 VA: 0xBFA368
	public bool HasID(int id) { }

	// RVA: 0xBFAAC8 Offset: 0xBFAAC8 VA: 0xBFAAC8
	public int GetSightIDByWeapon(int weaponID) { }

	// RVA: 0xBFAB88 Offset: 0xBFAB88 VA: 0xBFAB88 Slot: 4
	public int Compare(CharacterEquipmentDataManager.CharacterData a, CharacterEquipmentDataManager.CharacterData b) { }

	// RVA: 0xBF9A08 Offset: 0xBF9A08 VA: 0xBF9A08
	public void .ctor() { }
}
