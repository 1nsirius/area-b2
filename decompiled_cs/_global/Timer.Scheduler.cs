// Namespace: 
private sealed class Timer.Scheduler // TypeDefIndex: 821
{
	// Fields
	private static Timer.Scheduler instance; // 0x0
	private SortedList list; // 0x8
	private ManualResetEvent changed; // 0xC

	// Properties
	public static Timer.Scheduler Instance { get; }

	// Methods

	// RVA: 0x1AC3DCC Offset: 0x1AC3DCC VA: 0x1AC3DCC
	private static void .cctor() { }

	// RVA: 0x1AC3D40 Offset: 0x1AC3D40 VA: 0x1AC3D40
	public static Timer.Scheduler get_Instance() { }

	// RVA: 0x1AC3E3C Offset: 0x1AC3E3C VA: 0x1AC3E3C
	private void .ctor() { }

	// RVA: 0x1AC39F0 Offset: 0x1AC39F0 VA: 0x1AC39F0
	public void Remove(Timer timer) { }

	// RVA: 0x1AC3AD4 Offset: 0x1AC3AD4 VA: 0x1AC3AD4
	public void Change(Timer timer, long new_next_run) { }

	// RVA: 0x1AC4294 Offset: 0x1AC4294 VA: 0x1AC4294
	private int FindByDueTime(long nr) { }

	// RVA: 0x1AC4020 Offset: 0x1AC4020 VA: 0x1AC4020
	private void Add(Timer timer) { }

	// RVA: 0x1AC3FA4 Offset: 0x1AC3FA4 VA: 0x1AC3FA4
	private int InternalRemove(Timer timer) { }

	// RVA: 0x1AC44EC Offset: 0x1AC44EC VA: 0x1AC44EC
	private static void TimerCB(object o) { }

	// RVA: 0x1AC4E10 Offset: 0x1AC4E10 VA: 0x1AC4E10
	private void SchedulerThread() { }

	// RVA: 0x1AC5668 Offset: 0x1AC5668 VA: 0x1AC5668
	private void ShrinkIfNeeded(List<Timer> list, int initial) { }
}
