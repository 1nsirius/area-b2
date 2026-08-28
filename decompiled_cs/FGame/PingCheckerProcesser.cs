namespace FGame
{

// Namespace: FGame
public class PingCheckerProcesser : IDisposable // TypeDefIndex: 9893
{
	// Fields
	private const int TimeOutSeconds = 3;
	private bool mIsDone; // 0x8
	private List<PingChecker> mPingCheckers; // 0xC
	private int mCheckCount; // 0x10

	// Methods

	// RVA: 0xF61CF0 Offset: 0xF61CF0 VA: 0xF61CF0 Slot: 4
	public void Dispose() { }

	// RVA: 0xF61DE4 Offset: 0xF61DE4 VA: 0xF61DE4
	public void StartCheck() { }

	// RVA: 0xF61F6C Offset: 0xF61F6C VA: 0xF61F6C
	public bool IsDone() { }

	// RVA: 0xF61F74 Offset: 0xF61F74 VA: 0xF61F74
	public void OnTick() { }

	// RVA: 0xF62410 Offset: 0xF62410 VA: 0xF62410
	public void .ctor() { }

	[CompilerGeneratedAttribute] // RVA: 0x646DB0 Offset: 0x646DB0 VA: 0x646DB0
	// RVA: 0xF6249C Offset: 0xF6249C VA: 0xF6249C
	private void <StartCheck>b__5_0(BattleZoneData.BattleZoneInfo info) { }
}

} // namespace FGame
