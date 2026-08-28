// Namespace: 
[Serializable]
public class BattleConfiguration.SetP2WeaponCfg // TypeDefIndex: 12385
{
	// Fields
	public Vector3 defaultCamLocalEulerSight; // 0x8
	public Vector3 defaultCamLocalEulerBarrel; // 0x14
	public Vector3 defaultCamLocalEulerGrip; // 0x20
	public Vector3 defaultCamLocalEulerUnderBarrel; // 0x2C
	public Vector3 defaultCamLocalEulerPendant; // 0x38
	public List<BattleConfiguration.SetP2WeaponCfg.WpIKOffsetInfo> weaponIKOffsetList; // 0x44
	private Dictionary<string, BattleConfiguration.SetP2WeaponCfg.WpIKOffsetInfo> mWeaponIKOffsetDic; // 0x48

	// Properties
	public Dictionary<string, BattleConfiguration.SetP2WeaponCfg.WpIKOffsetInfo> WeaponIKOffsetDic { get; }

	// Methods

	// RVA: 0x9A19C8 Offset: 0x9A19C8 VA: 0x9A19C8
	public Dictionary<string, BattleConfiguration.SetP2WeaponCfg.WpIKOffsetInfo> get_WeaponIKOffsetDic() { }

	// RVA: 0x9A1BE0 Offset: 0x9A1BE0 VA: 0x9A1BE0
	public void .ctor() { }
}
