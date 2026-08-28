namespace FGame
{

// Namespace: FGame
public class TickTimeEvent // TypeDefIndex: 9953
{
	// Fields
	public string mEventName; // 0x8
	public long mEventOutTime; // 0x10
	public long mLeftSec; // 0x18
	public int mLoopTimes; // 0x20
	public long mStepSec; // 0x28
	public long mTickTime; // 0x30
	public Action<object> OnTimeOut; // 0x38
	public Action<object> OnUpdate; // 0x3C

	// Properties
	public long LeftSec { get; }

	// Methods

	// RVA: 0xD90BA0 Offset: 0xD90BA0 VA: 0xD90BA0
	public long get_LeftSec() { }

	// RVA: 0xD94820 Offset: 0xD94820 VA: 0xD94820
	public void TimeOut() { }

	// RVA: 0xD94890 Offset: 0xD94890 VA: 0xD94890
	public void Update() { }

	// RVA: 0xD91258 Offset: 0xD91258 VA: 0xD91258
	public bool UpdateTickTime(long ticktime) { }

	// RVA: 0xD912F0 Offset: 0xD912F0 VA: 0xD912F0
	public void .ctor() { }
}

} // namespace FGame
