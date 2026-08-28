// Namespace: 
public static class AkCallbackManager // TypeDefIndex: 5974
{
	// Fields
	[CompilerGeneratedAttribute] // RVA: 0x55EE40 Offset: 0x55EE40 VA: 0x55EE40
	private static bool <IsLoggingEnabled>k__BackingField; // 0x0
	private static readonly AkEventCallbackInfo AkEventCallbackInfo; // 0x4
	private static readonly AkDynamicSequenceItemCallbackInfo AkDynamicSequenceItemCallbackInfo; // 0x8
	private static readonly AkMIDIEventCallbackInfo AkMIDIEventCallbackInfo; // 0xC
	private static readonly AkMarkerCallbackInfo AkMarkerCallbackInfo; // 0x10
	private static readonly AkDurationCallbackInfo AkDurationCallbackInfo; // 0x14
	private static readonly AkMusicSyncCallbackInfo AkMusicSyncCallbackInfo; // 0x18
	private static readonly AkMusicPlaylistCallbackInfo AkMusicPlaylistCallbackInfo; // 0x1C
	private static readonly AkAudioSourceChangeCallbackInfo AkAudioSourceChangeCallbackInfo; // 0x20
	private static readonly AkMonitoringCallbackInfo AkMonitoringCallbackInfo; // 0x24
	private static readonly AkBankCallbackInfo AkBankCallbackInfo; // 0x28
	private static readonly Dictionary<int, AkCallbackManager.EventCallbackPackage> m_mapEventCallbacks; // 0x2C
	private static readonly Dictionary<int, AkCallbackManager.BankCallbackPackage> m_mapBankCallbacks; // 0x30
	private static AkCallbackManager.EventCallbackPackage m_LastAddedEventPackage; // 0x34
	private static IntPtr m_pNotifMem; // 0x38
	private static AkCallbackManager.MonitoringCallback m_MonitoringCB; // 0x3C
	private static AkCallbackManager.BGMCallbackPackage ms_sourceChangeCallbackPkg; // 0x40

	// Properties
	private static bool IsLoggingEnabled { get; set; }

	// Methods

	[CompilerGeneratedAttribute] // RVA: 0x57B22C Offset: 0x57B22C VA: 0x57B22C
	// RVA: 0xFDF418 Offset: 0xFDF418 VA: 0xFDF418
	private static bool get_IsLoggingEnabled() { }

	[CompilerGeneratedAttribute] // RVA: 0x57B23C Offset: 0x57B23C VA: 0x57B23C
	// RVA: 0xFDF4A4 Offset: 0xFDF4A4 VA: 0xFDF4A4
	private static void set_IsLoggingEnabled(bool value) { }

	// RVA: 0xFDF534 Offset: 0xFDF534 VA: 0xFDF534
	public static void RemoveEventCallback(uint in_playingID) { }

	// RVA: 0xFDF8EC Offset: 0xFDF8EC VA: 0xFDF8EC
	public static void RemoveEventCallbackCookie(object in_cookie) { }

	// RVA: 0xFDFCC4 Offset: 0xFDFCC4 VA: 0xFDFCC4
	public static void RemoveBankCallback(object in_cookie) { }

	// RVA: 0xFE009C Offset: 0xFE009C VA: 0xFE009C
	public static void SetLastAddedPlayingID(uint in_playingID) { }

	// RVA: 0xFE01E0 Offset: 0xFE01E0 VA: 0xFE01E0
	public static AKRESULT Init(AkCallbackManager.InitializationSettings settings) { }

	// RVA: 0xFE03AC Offset: 0xFE03AC VA: 0xFE03AC
	public static void Term() { }

	// RVA: 0xFE0564 Offset: 0xFE0564 VA: 0xFE0564
	public static void SetMonitoringCallback(AkMonitorErrorLevel in_Level, AkCallbackManager.MonitoringCallback in_CB) { }

	// RVA: 0xFE068C Offset: 0xFE068C VA: 0xFE068C
	public static void SetBGMCallback(AkCallbackManager.BGMCallback in_CB, object in_cookie) { }

	// RVA: 0xFE0774 Offset: 0xFE0774 VA: 0xFE0774
	public static int PostCallbacks() { }

	// RVA: 0xFE2D64 Offset: 0xFE2D64 VA: 0xFE2D64
	private static void .cctor() { }
}
