// Namespace: 
public class AkGameObjEnvironmentData // TypeDefIndex: 6066
{
	// Fields
	private readonly List<AkEnvironment> activeEnvironments; // 0x8
	private readonly List<AkEnvironment> activeEnvironmentsFromPortals; // 0xC
	private readonly List<AkEnvironmentPortal> activePortals; // 0x10
	private readonly AkAuxSendArray auxSendValues; // 0x14
	private Vector3 lastPosition; // 0x18
	private bool hasEnvironmentListChanged; // 0x24
	private bool hasActivePortalListChanged; // 0x25
	private bool hasSentZero; // 0x26

	// Methods

	// RVA: 0x1BA4B78 Offset: 0x1BA4B78 VA: 0x1BA4B78
	private void AddHighestPriorityEnvironmentsFromPortals(Vector3 position) { }

	// RVA: 0x1BA4E94 Offset: 0x1BA4E94 VA: 0x1BA4E94
	private void AddHighestPriorityEnvironments(Vector3 position) { }

	// RVA: 0x1BA3BE4 Offset: 0x1BA3BE4 VA: 0x1BA3BE4
	public void UpdateAuxSend(GameObject gameObject, Vector3 position) { }

	// RVA: 0x1BA50DC Offset: 0x1BA50DC VA: 0x1BA50DC
	private void TryAddEnvironment(AkEnvironment env) { }

	// RVA: 0x1BA52E8 Offset: 0x1BA52E8 VA: 0x1BA52E8
	private void RemoveEnvironment(AkEnvironment env) { }

	// RVA: 0x1BA3A54 Offset: 0x1BA3A54 VA: 0x1BA3A54
	public void AddAkEnvironment(Collider environmentCollider, Collider gameObjectCollider) { }

	// RVA: 0x1BA53A0 Offset: 0x1BA53A0 VA: 0x1BA53A0
	private bool AkEnvironmentBelongsToActivePortals(AkEnvironment env) { }

	// RVA: 0x1BA473C Offset: 0x1BA473C VA: 0x1BA473C
	public void RemoveAkEnvironment(Collider environmentCollider, Collider gameObjectCollider) { }

	// RVA: 0x1BA3904 Offset: 0x1BA3904 VA: 0x1BA3904
	public void .ctor() { }
}
