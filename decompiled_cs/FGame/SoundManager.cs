namespace FGame
{

// Namespace: FGame
public class SoundManager : BaseSingleton<SoundManager> // TypeDefIndex: 9980
{
	// Fields
	private ILuaFunctionWrap mEnableLoudspeakerFunc; // 0x8
	private ILuaFunctionWrap mEnableMicrophoneFunc; // 0xC
	private ILuaFunctionWrap mJoinChannelFunc; // 0x10
	private ILuaFunctionWrap mLeaveChannelFunc; // 0x14
	private ILuaFunctionWrap mSetVoiceVolumeFunc; // 0x18
	private ILuaFunctionWrap mSetMicrophoneVolumeFunc; // 0x1C
	private ILuaFunctionWrap mMuteRemotePlayerFunc; // 0x20
	private ILuaFunctionWrap mMuteLocalPlayerFunc; // 0x24
	private ILuaFunctionWrap mCheckMicrophonePermissionFunc; // 0x28
	private ILuaFunctionWrap mClearDataFunc; // 0x2C
	private bool mVoiceModuleEnabled; // 0x30
	private Coroutine mCheckChannelCoroutine; // 0x34

	// Methods

	// RVA: 0xD91970 Offset: 0xD91970 VA: 0xD91970
	public void InitSoundSetting() { }

	// RVA: 0xD92108 Offset: 0xD92108 VA: 0xD92108
	public void Shutdown() { }

	// RVA: 0xD92404 Offset: 0xD92404 VA: 0xD92404
	public bool GetVoiceEnabled() { }

	// RVA: 0xD91DE8 Offset: 0xD91DE8 VA: 0xD91DE8
	public void SetVoiceVolume(int volume) { }

	// RVA: 0xD91F78 Offset: 0xD91F78 VA: 0xD91F78
	public void SetMicrophoneVolume(int volume) { }

	// RVA: 0xD9240C Offset: 0xD9240C VA: 0xD9240C
	public void MuteRemotePlayer(long playerId, bool mute) { }

	// RVA: 0xD926C0 Offset: 0xD926C0 VA: 0xD926C0
	public void CheckMicrophonePermission(Action<bool> action) { }

	// RVA: 0xD9282C Offset: 0xD9282C VA: 0xD9282C
	public void EnableLoudspeaker(bool enable) { }

	// RVA: 0xD92DC4 Offset: 0xD92DC4 VA: 0xD92DC4
	public void EnsureLoudspeaker() { }

	// RVA: 0xD93008 Offset: 0xD93008 VA: 0xD93008
	public void ForceDisableLoudspeaker() { }

	// RVA: 0xD92AEC Offset: 0xD92AEC VA: 0xD92AEC
	public void EnableMicrophone(bool enable) { }

	// RVA: 0xD93184 Offset: 0xD93184 VA: 0xD93184
	public void EnsureMicrophone() { }

	// RVA: 0xD933C8 Offset: 0xD933C8 VA: 0xD933C8
	public void ForceDisableMicrophone() { }

	// RVA: 0xD93544 Offset: 0xD93544 VA: 0xD93544
	public void JoinChannel() { }

	// RVA: 0xD93650 Offset: 0xD93650 VA: 0xD93650
	private void CheckChannelAlive() { }

	// RVA: 0xD9212C Offset: 0xD9212C VA: 0xD9212C
	private void StopCheckChannelAlive() { }

	[IteratorStateMachineAttribute] // RVA: 0x647664 Offset: 0x647664 VA: 0x647664
	// RVA: 0xD9371C Offset: 0xD9371C VA: 0xD9371C
	private IEnumerator _CheckChannelAlive() { }

	// RVA: 0xD921F4 Offset: 0xD921F4 VA: 0xD921F4
	public void LeaveChannel() { }

	// RVA: 0xD92300 Offset: 0xD92300 VA: 0xD92300
	public void ClearVoiceData() { }

	// RVA: 0xD937C8 Offset: 0xD937C8 VA: 0xD937C8
	public void OnBattleRoomStart() { }

	// RVA: 0xD938F0 Offset: 0xD938F0 VA: 0xD938F0
	public void OnRoundEnd() { }

	// RVA: 0xD938F4 Offset: 0xD938F4 VA: 0xD938F4
	public void OnBattleEnd() { }

	// RVA: 0xD93918 Offset: 0xD93918 VA: 0xD93918
	public void .ctor() { }
}

} // namespace FGame
