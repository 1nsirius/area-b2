// Namespace: 
[CompilerGeneratedAttribute] // RVA: 0x4D9EFC Offset: 0x4D9EFC VA: 0x4D9EFC
[Serializable]
private sealed class Stream.<>c // TypeDefIndex: 628
{
	// Fields
	public static readonly Stream.<>c <>9; // 0x0
	public static Func<SemaphoreSlim> <>9__4_0; // 0x4
	public static Func<object, int> <>9__39_0; // 0x8
	public static Func<Stream, Stream.ReadWriteParameters, AsyncCallback, object, IAsyncResult> <>9__43_0; // 0xC
	public static Func<Stream, IAsyncResult, int> <>9__43_1; // 0x10
	public static Func<object, int> <>9__46_0; // 0x14
	public static Action<Task, object> <>9__47_0; // 0x18
	public static Func<Stream, Stream.ReadWriteParameters, AsyncCallback, object, IAsyncResult> <>9__53_0; // 0x1C
	public static Func<Stream, IAsyncResult, VoidTaskResult> <>9__53_1; // 0x20

	// Methods

	// RVA: 0x165B584 Offset: 0x165B584 VA: 0x165B584
	private static void .cctor() { }

	// RVA: 0x165B5F8 Offset: 0x165B5F8 VA: 0x165B5F8
	public void .ctor() { }

	// RVA: 0x165B600 Offset: 0x165B600 VA: 0x165B600
	internal SemaphoreSlim <EnsureAsyncActiveSemaphoreInitialized>b__4_0() { }

	// RVA: 0x165B674 Offset: 0x165B674 VA: 0x165B674
	internal int <BeginReadInternal>b__39_0(object <p0>) { }

	// RVA: 0x165B7A4 Offset: 0x165B7A4 VA: 0x165B7A4
	internal IAsyncResult <BeginEndReadAsync>b__43_0(Stream stream, Stream.ReadWriteParameters args, AsyncCallback callback, object state) { }

	// RVA: 0x165B80C Offset: 0x165B80C VA: 0x165B80C
	internal int <BeginEndReadAsync>b__43_1(Stream stream, IAsyncResult asyncResult) { }

	// RVA: 0x165B848 Offset: 0x165B848 VA: 0x165B848
	internal int <BeginWriteInternal>b__46_0(object <p0>) { }

	// RVA: 0x165B96C Offset: 0x165B96C VA: 0x165B96C
	internal void <RunReadWriteTaskWhenReady>b__47_0(Task t, object state) { }

	// RVA: 0x165BAD4 Offset: 0x165BAD4 VA: 0x165BAD4
	internal IAsyncResult <BeginEndWriteAsync>b__53_0(Stream stream, Stream.ReadWriteParameters args, AsyncCallback callback, object state) { }

	// RVA: 0x165BB3C Offset: 0x165BB3C VA: 0x165BB3C
	internal VoidTaskResult <BeginEndWriteAsync>b__53_1(Stream stream, IAsyncResult asyncResult) { }
}
