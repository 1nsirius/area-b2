// Namespace: 
public class LoadingStage : IStage // TypeDefIndex: 5602
{
	// Fields
	private float mEndTime; // 0x8
	private Action mCallBack; // 0xC
	private LoadingStage.State mState; // 0x10
	private eStageType nextStage; // 0x14

	// Methods

	// RVA: 0x2CD53F0 Offset: 0x2CD53F0 VA: 0x2CD53F0
	public void .ctor(Action cb) { }

	// RVA: 0x2CD5410 Offset: 0x2CD5410 VA: 0x2CD5410 Slot: 4
	public void Enter(eStageType nextStage) { }

	// RVA: 0x2CD5680 Offset: 0x2CD5680 VA: 0x2CD5680 Slot: 5
	public void Exit() { }

	// RVA: 0x2CD55F0 Offset: 0x2CD55F0 VA: 0x2CD55F0 Slot: 7
	public string GetSceneName() { }

	// RVA: 0x2CD579C Offset: 0x2CD579C VA: 0x2CD579C Slot: 6
	public void OnTick() { }

	// RVA: 0x2CD564C Offset: 0x2CD564C VA: 0x2CD564C
	private void OnSceneLoaded() { }

	// RVA: 0x2CD5890 Offset: 0x2CD5890 VA: 0x2CD5890
	private static void ManulGc() { }

	[IteratorStateMachineAttribute] // RVA: 0x57A30C Offset: 0x57A30C VA: 0x57A30C
	[CompilerGeneratedAttribute] // RVA: 0x57A30C Offset: 0x57A30C VA: 0x57A30C
	// RVA: 0x2CD5728 Offset: 0x2CD5728 VA: 0x2CD5728
	internal static IEnumerator <Exit>g__DelayHide|6_0() { }
}
