namespace FGame
{

// Namespace: FGame
public class BaseReConnector // TypeDefIndex: 9976
{
	// Fields
	private BaseReConnector.ReConnState mState; // 0x8
	protected readonly float ReConnOvertime; // 0xC
	protected float mReConnOverTick; // 0x10
	protected int mReconnCount; // 0x14

	// Properties
	public int ReconnCount { set; }
	public BaseReConnector.ReConnState State { get; }

	// Methods

	// RVA: 0xBE818C Offset: 0xBE818C VA: 0xBE818C
	public void set_ReconnCount(int value) { }

	// RVA: 0xBE8194 Offset: 0xBE8194 VA: 0xBE8194
	public BaseReConnector.ReConnState get_State() { }

	// RVA: 0xBE819C Offset: 0xBE819C VA: 0xBE819C Slot: 4
	public virtual void Initialize() { }

	// RVA: 0xBE81A8 Offset: 0xBE81A8 VA: 0xBE81A8 Slot: 5
	public virtual void Shutdown() { }

	// RVA: 0xBE81B4 Offset: 0xBE81B4 VA: 0xBE81B4 Slot: 6
	public virtual void Update() { }

	// RVA: 0xBE81B8 Offset: 0xBE81B8 VA: 0xBE81B8 Slot: 7
	public virtual void ChangeState(BaseReConnector.ReConnState state) { }

	// RVA: 0xBE820C Offset: 0xBE820C VA: 0xBE820C Slot: 8
	protected virtual void LeaveState(BaseReConnector.ReConnState lastState) { }

	// RVA: 0xBE8220 Offset: 0xBE8220 VA: 0xBE8220 Slot: 9
	protected virtual void EnterState(BaseReConnector.ReConnState lastState) { }

	// RVA: 0xBE82E8 Offset: 0xBE82E8 VA: 0xBE82E8
	public void .ctor() { }
}

} // namespace FGame
