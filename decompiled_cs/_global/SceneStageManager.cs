// Namespace: 
[LuaCallCSharpAttribute] // RVA: 0x550120 Offset: 0x550120 VA: 0x550120
public class SceneStageManager : BaseSingleton<SceneStageManager>, IManager // TypeDefIndex: 5455
{
	// Fields
	public eStageType currentStage; // 0x8
	private IStage mCrtStage; // 0xC

	// Methods

	// RVA: 0x2CF5680 Offset: 0x2CF5680 VA: 0x2CF5680 Slot: 5
	public void Shutdown() { }

	// RVA: 0x2CF5684 Offset: 0x2CF5684 VA: 0x2CF5684 Slot: 8
	public void LateUpdate() { }

	// RVA: 0x2CF5688 Offset: 0x2CF5688 VA: 0x2CF5688 Slot: 7
	public void Update() { }

	// RVA: 0x2CF5758 Offset: 0x2CF5758 VA: 0x2CF5758 Slot: 6
	public void BeforeUpdate() { }

	// RVA: 0x2CF575C Offset: 0x2CF575C VA: 0x2CF575C Slot: 9
	public void FixedUpdate() { }

	[IteratorStateMachineAttribute] // RVA: 0x579A54 Offset: 0x579A54 VA: 0x579A54
	// RVA: 0x2CF5760 Offset: 0x2CF5760 VA: 0x2CF5760 Slot: 4
	public IEnumerator Initialize() { }

	// RVA: 0x2CF57F4 Offset: 0x2CF57F4 VA: 0x2CF57F4
	public void EnterStage(eStageType target, Action callBack) { }

	// RVA: 0x2CF5BE4 Offset: 0x2CF5BE4 VA: 0x2CF5BE4
	public static bool IsHallStage() { }

	// RVA: 0x2CF5990 Offset: 0x2CF5990 VA: 0x2CF5990
	private IStage CreateStage(eStageType targetStage, Action loadedCallBack) { }

	// RVA: 0x2CF5C90 Offset: 0x2CF5C90 VA: 0x2CF5C90
	private bool CheckLoading(eStageType targetStage) { }

	// RVA: 0x2CF5CC4 Offset: 0x2CF5CC4 VA: 0x2CF5CC4
	public void .ctor() { }
}
