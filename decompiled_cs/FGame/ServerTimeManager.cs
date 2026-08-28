namespace FGame
{

// Namespace: FGame
[LuaCallCSharpAttribute] // RVA: 0x554054 Offset: 0x554054 VA: 0x554054
public class ServerTimeManager : BaseSingleton<ServerTimeManager> // TypeDefIndex: 9951
{
	// Fields
	private List<ServerTimeManager.AddParam> mAddList; // 0x8
	private DateTime mDateStart; // 0x10
	private Dictionary<string, TickTimeEvent> mEventDicts; // 0x18
	private bool mIsIterTicks; // 0x1C
	private List<string> mRemoveList; // 0x20
	private float mSecCount; // 0x24
	private long mServerTickTime; // 0x28
	[CompilerGeneratedAttribute] // RVA: 0x563804 Offset: 0x563804 VA: 0x563804
	private long <ServerOffset>k__BackingField; // 0x30

	// Properties
	public long TickTime { get; }
	public long ServerOffset { get; set; }
	public long ServerTick { get; set; }

	// Methods

	// RVA: 0xD90558 Offset: 0xD90558 VA: 0xD90558
	public long get_TickTime() { }

	[CompilerGeneratedAttribute] // RVA: 0x6473E0 Offset: 0x6473E0 VA: 0x6473E0
	// RVA: 0xD90628 Offset: 0xD90628 VA: 0xD90628
	public long get_ServerOffset() { }

	[CompilerGeneratedAttribute] // RVA: 0x6473F0 Offset: 0x6473F0 VA: 0x6473F0
	// RVA: 0xD90630 Offset: 0xD90630 VA: 0xD90630
	private void set_ServerOffset(long value) { }

	// RVA: 0xD90640 Offset: 0xD90640 VA: 0xD90640
	public long get_ServerTick() { }

	// RVA: 0xD90648 Offset: 0xD90648 VA: 0xD90648
	public void set_ServerTick(long value) { }

	// RVA: 0xD90658 Offset: 0xD90658 VA: 0xD90658
	public void AddCountdownEvent(string eventstr, long sec, int loopTimes, Action<object> handler, Action<object> updateHandler) { }

	// RVA: 0xD909EC Offset: 0xD909EC VA: 0xD909EC
	public void DelCountdownEvent(string eventstr) { }

	// RVA: 0xD90AC0 Offset: 0xD90AC0 VA: 0xD90AC0
	public long GetEventLeftSec(string eventname) { }

	// RVA: 0xD90BA8 Offset: 0xD90BA8 VA: 0xD90BA8
	public void Initialize() { }

	// RVA: 0xD90C80 Offset: 0xD90C80 VA: 0xD90C80
	public void Shutdown() { }

	// RVA: 0xD90D58 Offset: 0xD90D58 VA: 0xD90D58
	public void Update() { }

	// RVA: 0xD90750 Offset: 0xD90750 VA: 0xD90750
	private void Add(ServerTimeManager.AddParam parameters) { }

	// RVA: 0xD91374 Offset: 0xD91374 VA: 0xD91374
	private DateTime GetGameTime() { }

	// RVA: 0xD914A4 Offset: 0xD914A4 VA: 0xD914A4
	public DateTime GetServerGameTime() { }

	// RVA: 0xD916BC Offset: 0xD916BC VA: 0xD916BC
	private void OnUpdateServerTick(SprotoTypeBase msg) { }

	// RVA: 0xD9180C Offset: 0xD9180C VA: 0xD9180C
	public void .ctor() { }
}

} // namespace FGame
