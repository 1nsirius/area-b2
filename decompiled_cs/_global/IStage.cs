// Namespace: 
public interface IStage // TypeDefIndex: 5270
{
	// Methods

	// RVA: -1 Offset: -1 Slot: 0
	public abstract void Enter(eStageType nextStage);

	// RVA: -1 Offset: -1 Slot: 1
	public abstract void Exit();

	// RVA: -1 Offset: -1 Slot: 2
	public abstract void OnTick();

	// RVA: -1 Offset: -1 Slot: 3
	public abstract string GetSceneName();
}
