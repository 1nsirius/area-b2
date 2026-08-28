// Namespace: 
private sealed class Task.DelayPromise : Task<VoidTaskResult> // TypeDefIndex: 841
{
	// Fields
	internal readonly CancellationToken Token; // 0x2C
	internal CancellationTokenRegistration Registration; // 0x30
	internal Timer Timer; // 0x3C

	// Methods

	// RVA: 0x1AB9B5C Offset: 0x1AB9B5C VA: 0x1AB9B5C
	internal void .ctor(CancellationToken token) { }

	// RVA: 0x1AB90AC Offset: 0x1AB90AC VA: 0x1AB90AC
	internal void Complete() { }
}
