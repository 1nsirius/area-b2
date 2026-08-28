// Namespace: 
[Serializable]
public class BattleConfiguration.EffectCfg // TypeDefIndex: 12360
{
	// Fields
	[HeaderAttribute] // RVA: 0x576B84 Offset: 0x576B84 VA: 0x576B84
	public GameObject smoke_1; // 0x8
	public float smoke_1_length; // 0xC
	[HeaderAttribute] // RVA: 0x576BC0 Offset: 0x576BC0 VA: 0x576BC0
	public GameObject blood_1; // 0x10
	public float blood_1_length; // 0x14
	[HeaderAttribute] // RVA: 0x576BFC Offset: 0x576BFC VA: 0x576BFC
	public BattleConfiguration.gameEffect bulletPath; // 0x18
	[HeaderAttribute] // RVA: 0x576C30 Offset: 0x576C30 VA: 0x576C30
	public BattleConfiguration.gameEffect[] bulletHole; // 0x20
	[HeaderAttribute] // RVA: 0x576C64 Offset: 0x576C64 VA: 0x576C64
	public BattleConfiguration.gameEffect[] characterDamage; // 0x24
	[HeaderAttribute] // RVA: 0x576C98 Offset: 0x576C98 VA: 0x576C98
	public BattleConfiguration.gameEffect characterWarning; // 0x28
	[HeaderAttribute] // RVA: 0x576CCC Offset: 0x576CCC VA: 0x576CCC
	public BattleConfiguration.gameEffect[] sceneBeHitDown; // 0x30
	[HeaderAttribute] // RVA: 0x576D00 Offset: 0x576D00 VA: 0x576D00
	public BattleConfiguration.gameEffect[] sceneBeHitGround; // 0x34
	[HeaderAttribute] // RVA: 0x576D34 Offset: 0x576D34 VA: 0x576D34
	public BattleConfiguration.gameEffect[] explodeEffect; // 0x38
	[HeaderAttribute] // RVA: 0x576D68 Offset: 0x576D68 VA: 0x576D68
	public BattleConfiguration.gameEffect[] meleeATKEffect; // 0x3C
	[HeaderAttribute] // RVA: 0x576D9C Offset: 0x576D9C VA: 0x576D9C
	public BattleConfiguration.gameEffect[] goodsDestroy; // 0x40
	[HeaderAttribute] // RVA: 0x576DD0 Offset: 0x576DD0 VA: 0x576DD0
	public BattleConfiguration.gameEffect[] carAndCameraEffect; // 0x44
	[HeaderAttribute] // RVA: 0x576E04 Offset: 0x576E04 VA: 0x576E04
	public uint MaxHpToShowLowSaturation; // 0x48
	public float SaturationWhenLowHP; // 0x4C
	public float SaturationChangeDurationWhenHasBuff; // 0x50

	// Methods

	// RVA: 0x9A0DF0 Offset: 0x9A0DF0 VA: 0x9A0DF0
	public void .ctor() { }
}
