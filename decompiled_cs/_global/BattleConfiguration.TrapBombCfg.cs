// Namespace: 
[Serializable]
public class BattleConfiguration.TrapBombCfg // TypeDefIndex: 12379
{
	// Fields
	public Vector3 triggerExtent; // 0x8
	public float crouchPlaceHeight; // 0x14
	public float standPlaceHeight; // 0x18
	public float sqrMaxPlaceDistance; // 0x1C
	public float sqrMaxDistanceToEyesLine; // 0x20
	public float minPlaceCos; // 0x24
	public Vector3 eyesPositionOffsetL; // 0x28
	public Vector3 eyesPositionOffsetR; // 0x34
	[SerializeField] // RVA: 0x577EE4 Offset: 0x577EE4 VA: 0x577EE4
	private Vector3 eyesEulerOffset; // 0x40
	public Vector3 standCharacterPosOffset; // 0x4C
	public Vector3 crouchCharacterPosOffset; // 0x58
	[SerializeField] // RVA: 0x577EF4 Offset: 0x577EF4 VA: 0x577EF4
	private Vector3 characterEulerOffset; // 0x64
	public float moveToPlaceDuration; // 0x70
	public Vector3 trapBombPosOffset; // 0x74
	[SerializeField] // RVA: 0x577F04 Offset: 0x577F04 VA: 0x577F04
	private Vector3 trapBombEulerOffset; // 0x80
	public float bombTriggerHeight; // 0x8C
	public Bounds selfBounds; // 0x90
	public int explodeEffectId; // 0xA8
	public int destroyEffectId; // 0xAC
	public int placeEffectId; // 0xB0
	public float delayCloseLineDuration; // 0xB4
	private Nullable<Quaternion> _eyesRotOffset; // 0xB8
	private Nullable<Quaternion> _characterRotOffset; // 0xCC
	private Nullable<Quaternion> _trapBombRotOffset; // 0xE0

	// Properties
	public Quaternion EyesRotOffset { get; }
	public Quaternion CharacterRotOffset { get; }
	public Quaternion TrapBombRotOffset { get; }

	// Methods

	// RVA: 0x9A24E4 Offset: 0x9A24E4 VA: 0x9A24E4
	public Quaternion get_EyesRotOffset() { }

	// RVA: 0x9A261C Offset: 0x9A261C VA: 0x9A261C
	public Quaternion get_CharacterRotOffset() { }

	// RVA: 0x9A2754 Offset: 0x9A2754 VA: 0x9A2754
	public Quaternion get_TrapBombRotOffset() { }

	// RVA: 0x99EC08 Offset: 0x99EC08 VA: 0x99EC08
	public void .ctor() { }
}
