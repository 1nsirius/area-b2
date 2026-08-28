namespace FGame
{

// Namespace: FGame
public class NetStateManager : BaseSingleton<NetStateManager>, IManager // TypeDefIndex: 9973
{
	// Fields
	private LobbyReConnector mLReConn; // 0x8
	private BattleReConnector mBReConn; // 0xC
	protected bool isShowDlg; // 0x10
	private float mLoginTimeOut; // 0x14
	private bool mAbort; // 0x18
	private int mBattleRecCount; // 0x1C

	// Properties
	public bool IsShowDlg { get; }
	public bool Abort { set; }
	public int BattleRecCount { get; set; }

	// Methods

	// RVA: 0xF5E390 Offset: 0xF5E390 VA: 0xF5E390
	public bool get_IsShowDlg() { }

	// RVA: 0xF50630 Offset: 0xF50630 VA: 0xF50630
	public void set_Abort(bool value) { }

	// RVA: 0xF5E398 Offset: 0xF5E398 VA: 0xF5E398
	public void set_BattleRecCount(int value) { }

	// RVA: 0xF5E6D8 Offset: 0xF5E6D8 VA: 0xF5E6D8
	public int get_BattleRecCount() { }

	[IteratorStateMachineAttribute] // RVA: 0x6475DC Offset: 0x6475DC VA: 0x6475DC
	// RVA: 0xF5E6E0 Offset: 0xF5E6E0 VA: 0xF5E6E0 Slot: 4
	public IEnumerator Initialize() { }

	// RVA: 0xF5E78C Offset: 0xF5E78C VA: 0xF5E78C Slot: 5
	public void Shutdown() { }

	// RVA: 0xF5E97C Offset: 0xF5E97C VA: 0xF5E97C Slot: 6
	public void BeforeUpdate() { }

	// RVA: 0xF5E980 Offset: 0xF5E980 VA: 0xF5E980 Slot: 7
	public void Update() { }

	// RVA: 0xF5E9D8 Offset: 0xF5E9D8 VA: 0xF5E9D8 Slot: 8
	public void LateUpdate() { }

	// RVA: 0xF5EC90 Offset: 0xF5EC90 VA: 0xF5EC90 Slot: 9
	public void FixedUpdate() { }

	// RVA: 0xF5EC94 Offset: 0xF5EC94 VA: 0xF5EC94
	public void SetBattleIdle() { }

	// RVA: 0xF5ECB4 Offset: 0xF5ECB4 VA: 0xF5ECB4
	public void SetBattleIdle2DisConnect() { }

	// RVA: 0xF43894 Offset: 0xF43894 VA: 0xF43894
	public void CloseAllNet() { }

	// RVA: 0xF4B884 Offset: 0xF4B884 VA: 0xF4B884
	public void ShowDlg(int count) { }

	// RVA: 0xF5ED04 Offset: 0xF5ED04 VA: 0xF5ED04
	public void ShowWaitBattle() { }

	// RVA: 0xF4C16C Offset: 0xF4C16C VA: 0xF4C16C
	public void ShowWaitSelect() { }

	// RVA: 0xF5EFEC Offset: 0xF5EFEC VA: 0xF5EFEC
	public void ShowBattleEnd() { }

	// RVA: 0xF5E450 Offset: 0xF5E450 VA: 0xF5E450
	public void ShowBattleError() { }

	// RVA: 0xF4B5FC Offset: 0xF4B5FC VA: 0xF4B5FC
	public void ShowKickOut() { }

	// RVA: 0xF4B53C Offset: 0xF4B53C VA: 0xF4B53C
	public void HideDlg() { }

	// RVA: 0xF5F274 Offset: 0xF5F274 VA: 0xF5F274
	public void AskOut() { }

	// RVA: 0xF5F49C Offset: 0xF5F49C VA: 0xF5F49C
	public void LoginOut() { }

	// RVA: 0xF5FA8C Offset: 0xF5FA8C VA: 0xF5FA8C
	public void ReCheckInLobby() { }

	// RVA: 0xF4AB08 Offset: 0xF4AB08 VA: 0xF4AB08
	public void BackLobby() { }

	// RVA: 0xF4C44C Offset: 0xF4C44C VA: 0xF4C44C
	public void BackNaming() { }

	// RVA: 0xF4AE50 Offset: 0xF4AE50 VA: 0xF4AE50
	public void LobbyToNormal() { }

	// RVA: 0xF5FA5C Offset: 0xF5FA5C VA: 0xF5FA5C
	public bool IsLobbyStateOk() { }

	// RVA: 0xF5FC50 Offset: 0xF5FC50 VA: 0xF5FC50
	public bool IsLobbyIdle() { }

	// RVA: 0xF4C13C Offset: 0xF4C13C VA: 0xF4C13C
	public bool IsBattleIdle() { }

	// RVA: 0xF5FC80 Offset: 0xF5FC80 VA: 0xF5FC80
	private void OnLobbyBeginConnect() { }

	// RVA: 0xF5FC9C Offset: 0xF5FC9C VA: 0xF5FC9C
	private void OnLobbyConnected() { }

	// RVA: 0xF4EF34 Offset: 0xF4EF34 VA: 0xF4EF34
	public void ResetLoginTimeOut(bool ok = False) { }

	// RVA: 0xF5FCC8 Offset: 0xF5FCC8 VA: 0xF5FCC8
	private void OnLobbyReConnect() { }

	// RVA: 0xF4F428 Offset: 0xF4F428 VA: 0xF4F428
	public void SetReConnectTime(int count) { }

	// RVA: 0xF5FCCC Offset: 0xF5FCCC VA: 0xF5FCCC
	public void .ctor() { }

	[CompilerGeneratedAttribute] // RVA: 0x647654 Offset: 0x647654 VA: 0x647654
	// RVA: 0xF5FD5C Offset: 0xF5FD5C VA: 0xF5FD5C
	private void <AskOut>g__OnNo|29_0() { }
}

} // namespace FGame
