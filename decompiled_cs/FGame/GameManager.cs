namespace FGame
{

// Namespace: FGame
[LuaCallCSharpAttribute] // RVA: 0x554090 Offset: 0x554090 VA: 0x554090
public sealed class GameManager : BaseSingleton<GameManager>, IManager // TypeDefIndex: 9962
{
	// Fields
	public ILuaFunctionWrap LuaReceivePackage; // 0x8
	public ILuaTableWrap LuaGameOwner; // 0xC
	public ILuaTableWrap LuaGameingOwner; // 0x10
	public ILuaTableWrap LuaLobbyOwner; // 0x14
	private string mGameState; // 0x18
	private string mGameingState; // 0x1C
	private string mLobbyState; // 0x20
	[CompilerGeneratedAttribute] // RVA: 0x563824 Offset: 0x563824 VA: 0x563824
	private ILuaFunctionWrap <LuaMessageDispatcher>k__BackingField; // 0x24
	private bool mLogin; // 0x28

	// Properties
	public ILuaFunctionWrap LuaMessageDispatcher { get; set; }

	// Methods

	[CompilerGeneratedAttribute] // RVA: 0x647444 Offset: 0x647444 VA: 0x647444
	// RVA: 0xF4151C Offset: 0xF4151C VA: 0xF4151C
	public ILuaFunctionWrap get_LuaMessageDispatcher() { }

	[CompilerGeneratedAttribute] // RVA: 0x647454 Offset: 0x647454 VA: 0x647454
	// RVA: 0xF41524 Offset: 0xF41524 VA: 0xF41524
	public void set_LuaMessageDispatcher(ILuaFunctionWrap value) { }

	[IteratorStateMachineAttribute] // RVA: 0x647464 Offset: 0x647464 VA: 0x647464
	// RVA: 0xF4152C Offset: 0xF4152C VA: 0xF4152C Slot: 4
	public IEnumerator Initialize() { }

	// RVA: 0xF415C0 Offset: 0xF415C0 VA: 0xF415C0
	public void Play() { }

	// RVA: 0xF41668 Offset: 0xF41668 VA: 0xF41668 Slot: 5
	public void Shutdown() { }

	// RVA: 0xF430C8 Offset: 0xF430C8 VA: 0xF430C8 Slot: 6
	public void BeforeUpdate() { }

	// RVA: 0xF430CC Offset: 0xF430CC VA: 0xF430CC Slot: 7
	public void Update() { }

	// RVA: 0xF43350 Offset: 0xF43350 VA: 0xF43350 Slot: 8
	public void LateUpdate() { }

	// RVA: 0xF43354 Offset: 0xF43354 VA: 0xF43354 Slot: 9
	public void FixedUpdate() { }

	// RVA: 0xF43358 Offset: 0xF43358 VA: 0xF43358
	public void SetGameState(string state) { }

	// RVA: 0xF43458 Offset: 0xF43458 VA: 0xF43458
	public string GetGameState() { }

	// RVA: 0xF43460 Offset: 0xF43460 VA: 0xF43460
	public void SetGameingState(string state) { }

	// RVA: 0xF43560 Offset: 0xF43560 VA: 0xF43560
	public string GetGameingState() { }

	// RVA: 0xF43568 Offset: 0xF43568 VA: 0xF43568
	public void SetLobbyState(string state) { }

	// RVA: 0xF43570 Offset: 0xF43570 VA: 0xF43570
	public string GetLobbyState() { }

	// RVA: 0xF43578 Offset: 0xF43578 VA: 0xF43578
	public void OnLogin() { }

	// RVA: 0xF43584 Offset: 0xF43584 VA: 0xF43584
	public void LoginOut() { }

	[IteratorStateMachineAttribute] // RVA: 0x6474DC Offset: 0x6474DC VA: 0x6474DC
	// RVA: 0xF43B9C Offset: 0xF43B9C VA: 0xF43B9C
	private IEnumerator EnterLogoutScene() { }

	// RVA: 0xF43C30 Offset: 0xF43C30 VA: 0xF43C30
	public void .ctor() { }
}

} // namespace FGame
