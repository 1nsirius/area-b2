// Namespace: 
public abstract class AkTriggerHandler : MonoBehaviour // TypeDefIndex: 6101
{
	// Fields
	public const int AWAKE_TRIGGER_ID = 1151176110;
	public const int START_TRIGGER_ID = 1281810935;
	public const int DESTROY_TRIGGER_ID = -358577003;
	public const int MAX_NB_TRIGGERS = 32;
	public static Dictionary<uint, string> triggerTypes; // 0x0
	private bool didDestroy; // 0xC
	public List<int> triggerList; // 0x10
	public bool useOtherObject; // 0x14

	// Methods

	// RVA: -1 Offset: -1 Slot: 4
	public abstract void HandleEvent(GameObject in_gameObject);

	// RVA: 0xCA9A08 Offset: 0xCA9A08 VA: 0xCA9A08 Slot: 5
	protected virtual void Awake() { }

	// RVA: 0xCAA120 Offset: 0xCAA120 VA: 0xCAA120 Slot: 6
	protected virtual void Start() { }

	// RVA: 0xCAA1C0 Offset: 0xCAA1C0 VA: 0xCAA1C0 Slot: 7
	protected virtual void OnDestroy() { }

	// RVA: 0xCAA1D0 Offset: 0xCAA1D0 VA: 0xCAA1D0
	public void DoDestroy() { }

	// RVA: 0xCA9AFC Offset: 0xCA9AFC VA: 0xCA9AFC
	protected void RegisterTriggers(List<int> in_triggerList, AkTriggerBase.Trigger in_delegate) { }

	// RVA: 0xCAA2CC Offset: 0xCAA2CC VA: 0xCAA2CC
	protected void UnregisterTriggers(List<int> in_triggerList, AkTriggerBase.Trigger in_delegate) { }

	// RVA: 0xCAA7D8 Offset: 0xCAA7D8 VA: 0xCAA7D8
	protected void .ctor() { }

	// RVA: 0xCAA894 Offset: 0xCAA894 VA: 0xCAA894
	private static void .cctor() { }
}
