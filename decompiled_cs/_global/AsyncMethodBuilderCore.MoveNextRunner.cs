// Namespace: 
internal sealed class AsyncMethodBuilderCore.MoveNextRunner // TypeDefIndex: 1260
{
	// Fields
	private readonly ExecutionContext m_context; // 0x8
	internal IAsyncStateMachine m_stateMachine; // 0xC
	private static ContextCallback s_invokeMoveNext; // 0x0

	// Methods

	// RVA: 0x1A684B4 Offset: 0x1A684B4 VA: 0x1A684B4
	internal void .ctor(ExecutionContext context, IAsyncStateMachine stateMachine) { }

	// RVA: 0x1A69134 Offset: 0x1A69134 VA: 0x1A69134
	internal void Run() { }

	// RVA: 0x1A6935C Offset: 0x1A6935C VA: 0x1A6935C
	private static void InvokeMoveNext(object stateMachine) { }
}
