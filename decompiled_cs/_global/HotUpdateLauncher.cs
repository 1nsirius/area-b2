// Namespace: 
public class HotUpdateLauncher : MonoBehaviour // TypeDefIndex: 5460
{
	// Fields
	public AndroidPermissionWindow mAndroidPermissionWindow; // 0xC
	[SerializeField] // RVA: 0x55D6C4 Offset: 0x55D6C4 VA: 0x55D6C4
	private UnityEvent onLanguageLoadedEvent; // 0x10
	[SerializeField] // RVA: 0x55D6D4 Offset: 0x55D6D4 VA: 0x55D6D4
	private UnityEvent onCanDoFirstPackEvent; // 0x14
	[SerializeField] // RVA: 0x55D6E4 Offset: 0x55D6E4 VA: 0x55D6E4
	private UnityEvent onCanDoHotUpdateEvent; // 0x18
	[SerializeField] // RVA: 0x55D6F4 Offset: 0x55D6F4 VA: 0x55D6F4
	private float splashScreenDuration; // 0x1C
	private float mSplashScreenTimer; // 0x20
	private bool mlanguageLoaded; // 0x24
	private Nullable<bool> mRemoteHotUpdateEnabled; // 0x25
	private bool mRemoteHotUpdateEnabledGot; // 0x27
	private Nullable<bool> mLocalHotUpdateEnabled; // 0x28
	private static HotUpdateLauncher.Status mCurStatus; // 0x0
	private static bool mSplashScreenFinished; // 0x4
	private static bool mLogoFinished; // 0x5
	public VideoPlayer mVideo; // 0x2C
	private static bool mHotUpdateFinished; // 0x6

	// Properties
	private static HotUpdateLauncher.Status CurStatus { get; set; }
	public static bool splashScreenFinished { get; set; }
	public static bool logoFinished { get; set; }
	public static bool hotUpdateFinished { get; set; }
	private bool hotUpdateEnabled { get; }
	private bool localHotUpdateEnabled { get; }

	// Methods

	// RVA: 0x2CCD68C Offset: 0x2CCD68C VA: 0x2CCD68C
	private static HotUpdateLauncher.Status get_CurStatus() { }

	// RVA: 0x2CCD718 Offset: 0x2CCD718 VA: 0x2CCD718
	private static void set_CurStatus(HotUpdateLauncher.Status value) { }

	// RVA: 0x2CCD944 Offset: 0x2CCD944 VA: 0x2CCD944
	private void Start() { }

	[IteratorStateMachineAttribute] // RVA: 0x579ACC Offset: 0x579ACC VA: 0x579ACC
	// RVA: 0x2CCD968 Offset: 0x2CCD968 VA: 0x2CCD968
	private IEnumerator _Start() { }

	[IteratorStateMachineAttribute] // RVA: 0x579B44 Offset: 0x579B44 VA: 0x579B44
	// RVA: 0x2CCDA14 Offset: 0x2CCDA14 VA: 0x2CCDA14
	private IEnumerator CheckPermissions() { }

	// RVA: 0x2CCDAC0 Offset: 0x2CCDAC0 VA: 0x2CCDAC0
	private void Update() { }

	// RVA: 0x2CCDDA8 Offset: 0x2CCDDA8 VA: 0x2CCDDA8
	private void OnLanguageLoaded() { }

	// RVA: 0x2CCDDC8 Offset: 0x2CCDDC8 VA: 0x2CCDDC8
	public void CheckHotUpdateEnabled() { }

	// RVA: 0x2CCDF94 Offset: 0x2CCDF94 VA: 0x2CCDF94
	public void NoHotUpdateEnterGame() { }

	// RVA: 0x2CCE1B0 Offset: 0x2CCE1B0 VA: 0x2CCE1B0
	public static void ForceFinishUpdate() { }

	// RVA: 0x2CCE4F8 Offset: 0x2CCE4F8 VA: 0x2CCE4F8
	private static void EnterGameScene() { }

	// RVA: 0x2CCDC44 Offset: 0x2CCDC44 VA: 0x2CCDC44
	public static bool get_splashScreenFinished() { }

	// RVA: 0x2CCDCD0 Offset: 0x2CCDCD0 VA: 0x2CCDCD0
	private static void set_splashScreenFinished(bool value) { }

	// RVA: 0x2CCE5E0 Offset: 0x2CCE5E0 VA: 0x2CCE5E0
	public static bool get_logoFinished() { }

	// RVA: 0x2CCE66C Offset: 0x2CCE66C VA: 0x2CCE66C
	private static void set_logoFinished(bool value) { }

	// RVA: 0x2CCE290 Offset: 0x2CCE290 VA: 0x2CCE290
	public void PlayVideo() { }

	// RVA: 0x2CCE744 Offset: 0x2CCE744 VA: 0x2CCE744
	public void EndVideo() { }

	// RVA: 0x2CCE938 Offset: 0x2CCE938 VA: 0x2CCE938
	public static bool get_hotUpdateFinished() { }

	// RVA: 0x2CCE0D8 Offset: 0x2CCE0D8 VA: 0x2CCE0D8
	private static void set_hotUpdateFinished(bool value) { }

	// RVA: 0x2CCD7E8 Offset: 0x2CCD7E8 VA: 0x2CCD7E8
	private static void CheckEnterGame() { }

	// RVA: 0x2CCE9C4 Offset: 0x2CCE9C4 VA: 0x2CCE9C4
	public void SetLogoFinishFlag() { }

	// RVA: 0x2CCEA40 Offset: 0x2CCEA40 VA: 0x2CCEA40
	public void SetHotUpdateFinishFlag() { }

	// RVA: 0x2CCEAC8 Offset: 0x2CCEAC8 VA: 0x2CCEAC8
	public void SetFirstCopyFinishFlag() { }

	// RVA: 0x2CCEB44 Offset: 0x2CCEB44 VA: 0x2CCEB44
	private void DisableRemoteControlHotUpdate() { }

	// RVA: 0x2CCEB50 Offset: 0x2CCEB50 VA: 0x2CCEB50
	private void SetRemoteHotUpdateEnable(bool enable) { }

	// RVA: 0x2CCDF00 Offset: 0x2CCDF00 VA: 0x2CCDF00
	private bool get_hotUpdateEnabled() { }

	// RVA: 0x2CCEBD4 Offset: 0x2CCEBD4 VA: 0x2CCEBD4
	private bool get_localHotUpdateEnabled() { }

	// RVA: 0x2CCED0C Offset: 0x2CCED0C VA: 0x2CCED0C
	private void AsyncGetRemoteHotUpdateControl() { }

	// RVA: 0x2CCEFF8 Offset: 0x2CCEFF8 VA: 0x2CCEFF8
	public void .ctor() { }

	// RVA: 0x2CCF0A4 Offset: 0x2CCF0A4 VA: 0x2CCF0A4
	private static void .cctor() { }

	[CompilerGeneratedAttribute] // RVA: 0x579BBC Offset: 0x579BBC VA: 0x579BBC
	// RVA: 0x2CCF0A8 Offset: 0x2CCF0A8 VA: 0x2CCF0A8
	private void <AsyncGetRemoteHotUpdateControl>b__49_0(DownloadTaskSucceedResult downloadResult) { }

	[CompilerGeneratedAttribute] // RVA: 0x579BCC Offset: 0x579BCC VA: 0x579BCC
	// RVA: 0x2CCF210 Offset: 0x2CCF210 VA: 0x2CCF210
	private void <AsyncGetRemoteHotUpdateControl>b__49_1(DownloadTaskFailResult request) { }
}
