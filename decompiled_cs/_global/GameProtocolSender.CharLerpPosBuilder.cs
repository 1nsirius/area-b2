// Namespace: 
private struct GameProtocolSender.CharLerpPosBuilder // TypeDefIndex: 11573
{
	// Fields
	private LerpData mLerpData; // 0x0
	private GameProtocolSender mSender; // 0x4

	// Methods

	// RVA: 0x8CF264 Offset: 0x8CF264 VA: 0x8CF264
	public static GameProtocolSender.CharLerpPosBuilder Begin(GameProtocolSender sender, LerpData lerpData, float duration) { }

	// RVA: 0x744AD8 Offset: 0x744AD8 VA: 0x744AD8
	public void Send(Packet packet) { }

	// RVA: 0x744AE0 Offset: 0x744AE0 VA: 0x744AE0
	public GameProtocolSender.CharLerpPosBuilder AddCharPosWithEyesLocal(in Vector3 value) { }

	// RVA: 0x744AF4 Offset: 0x744AF4 VA: 0x744AF4
	public GameProtocolSender.CharLerpPosBuilder AddCharRotWithEyesLocal(in Quaternion value) { }

	// RVA: 0x744B08 Offset: 0x744B08 VA: 0x744B08
	public GameProtocolSender.CharLerpPosBuilder AddEyesCoordinateWithEyesLocal(in Quaternion value) { }

	// RVA: 0x744B1C Offset: 0x744B1C VA: 0x744B1C
	public GameProtocolSender.CharLerpPosBuilder AddEyesCoordinateWithEyesWorld(in Quaternion value) { }

	// RVA: 0x744B30 Offset: 0x744B30 VA: 0x744B30
	public GameProtocolSender.CharLerpPosBuilder AddEyesLocalPos(in Vector3 value) { }

	// RVA: 0x744B44 Offset: 0x744B44 VA: 0x744B44
	public GameProtocolSender.CharLerpPosBuilder AddEyesLocalRot(in Quaternion value) { }
}
