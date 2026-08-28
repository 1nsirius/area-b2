// Namespace: 
private class Conduct.ConductInner // TypeDefIndex: 13284
{
	// Fields
	private static readonly Stack<Conduct.ConductInner> mPoolInner; // 0x0
	private float mStartTime; // 0x8
	private float mDuration; // 0xC
	private Conduct.FinishCallback mFinishCallback; // 0x10
	private Action mFinishCallbackWithoutTime; // 0x14
	private Action<float> mUpdating; // 0x18
	private Action mOnBreak; // 0x1C
	private Func<float> mGetTime; // 0x20

	// Methods

	// RVA: 0x92F3F4 Offset: 0x92F3F4 VA: 0x92F3F4
	private static void .cctor() { }

	// RVA: 0x92F4E8 Offset: 0x92F4E8 VA: 0x92F4E8
	private void .ctor() { }

	// RVA: 0x92E8B8 Offset: 0x92E8B8 VA: 0x92E8B8
	public static void InitInner() { }

	// RVA: 0x92F4F0 Offset: 0x92F4F0 VA: 0x92F4F0
	private static Conduct.ConductInner PopInner() { }

	// RVA: 0x92F634 Offset: 0x92F634 VA: 0x92F634
	private static void Push(Conduct.ConductInner conductInner) { }

	// RVA: 0x92EA68 Offset: 0x92EA68 VA: 0x92EA68
	public void Update(Action onFinish) { }

	// RVA: 0x92EEF8 Offset: 0x92EEF8 VA: 0x92EEF8
	public static Conduct.ConductInner MakeInner(float duration, Nullable<float> startTime) { }

	// RVA: 0x92F6F0 Offset: 0x92F6F0 VA: 0x92F6F0
	private void StopConduct() { }

	// RVA: 0x92F1F8 Offset: 0x92F1F8 VA: 0x92F1F8
	public void WithFinishCallback(Conduct.FinishCallback finishCallback) { }

	// RVA: 0x92F240 Offset: 0x92F240 VA: 0x92F240
	public void WithFinishCallback(Action finishCallback) { }

	// RVA: 0x92F280 Offset: 0x92F280 VA: 0x92F280
	public void WithBreakCallback(Action breakCallback) { }

	// RVA: 0x92F2B8 Offset: 0x92F2B8 VA: 0x92F2B8
	public void WithUpdating(Action<float> updating) { }

	// RVA: 0x92F310 Offset: 0x92F310 VA: 0x92F310
	public void WithGetTime(Func<float> getTime, Nullable<float> startTime) { }

	// RVA: 0x92F114 Offset: 0x92F114 VA: 0x92F114
	public void Release() { }
}
