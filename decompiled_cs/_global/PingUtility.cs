// Namespace: 
public class PingUtility : MonoSingleton<PingUtility> // TypeDefIndex: 5264
{
	// Fields
	private Dictionary<string, long> pings; // 0xC

	// Methods

	// RVA: 0x2CE41B0 Offset: 0x2CE41B0 VA: 0x2CE41B0
	public Coroutine Ping(string ip, Action<long> callback, int timeout = 1000) { }

	[IteratorStateMachineAttribute] // RVA: 0x579964 Offset: 0x579964 VA: 0x579964
	// RVA: 0x2CE41DC Offset: 0x2CE41DC VA: 0x2CE41DC
	private IEnumerator _Ping(string ip, Action<long> callback, int timeout) { }

	// RVA: 0x2CE42BC Offset: 0x2CE42BC VA: 0x2CE42BC
	public Coroutine PingEjoyServer(string region, Action<long> callback, int timeout = 1000) { }

	[IteratorStateMachineAttribute] // RVA: 0x5799DC Offset: 0x5799DC VA: 0x5799DC
	// RVA: 0x2CE42E8 Offset: 0x2CE42E8 VA: 0x2CE42E8
	private IEnumerator _PingEjoyServer(string region, Action<long> callback, int timeout) { }

	// RVA: 0x2CE43E0 Offset: 0x2CE43E0 VA: 0x2CE43E0
	private long CalPing(string url, long elapsed) { }

	// RVA: 0x2CE4594 Offset: 0x2CE4594 VA: 0x2CE4594
	public void .ctor() { }
}
