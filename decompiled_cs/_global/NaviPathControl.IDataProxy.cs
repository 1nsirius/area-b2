// Namespace: 
public interface NaviPathControl.IDataProxy // TypeDefIndex: 10434
{
	// Properties
	public abstract List<IDynamicGoalProxy> goalList { get; }
	public abstract IDynamicGoalProxy CurNaviTarget { get; }
	public abstract IDynamicGoalProxy realGoal { get; }
	public abstract bool isSelfCar { get; }
	public abstract bool hasFoundRealGoal { get; }
	public abstract bool IsInRealGoalArea { get; }

	// Methods

	// RVA: -1 Offset: -1 Slot: 0
	public abstract List<IDynamicGoalProxy> get_goalList();

	// RVA: -1 Offset: -1 Slot: 1
	public abstract IDynamicGoalProxy get_CurNaviTarget();

	// RVA: -1 Offset: -1 Slot: 2
	public abstract IDynamicGoalProxy get_realGoal();

	// RVA: -1 Offset: -1 Slot: 3
	public abstract bool get_isSelfCar();

	// RVA: -1 Offset: -1 Slot: 4
	public abstract bool get_hasFoundRealGoal();

	// RVA: -1 Offset: -1 Slot: 5
	public abstract void HandleOnClick(IDynamicGoalProxy proxy);

	// RVA: -1 Offset: -1 Slot: 6
	public abstract bool get_IsInRealGoalArea();

	// RVA: -1 Offset: -1 Slot: 7
	public abstract string GetTargetName(U64Id goalId);
}
