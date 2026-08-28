// Namespace: 
internal struct ExecutionContext.Reader // TypeDefIndex: 778
{
	// Fields
	private ExecutionContext m_ec; // 0x0

	// Properties
	public bool IsNull { get; }
	public bool IsFlowSuppressed { get; }
	public SynchronizationContext SynchronizationContext { get; }
	public SynchronizationContext SynchronizationContextNoFlow { get; }
	public LogicalCallContext.Reader LogicalCallContext { get; }

	// Methods

	// RVA: 0x75E92C Offset: 0x75E92C VA: 0x75E92C
	public void .ctor(ExecutionContext ec) { }

	// RVA: 0x75E934 Offset: 0x75E934 VA: 0x75E934
	public ExecutionContext DangerousGetRawExecutionContext() { }

	// RVA: 0x75E93C Offset: 0x75E93C VA: 0x75E93C
	public bool get_IsNull() { }

	// RVA: 0x75E950 Offset: 0x75E950 VA: 0x75E950
	public bool IsDefaultFTContext(bool ignoreSyncCtx) { }

	// RVA: 0x75E958 Offset: 0x75E958 VA: 0x75E958
	public bool get_IsFlowSuppressed() { }

	// RVA: 0x75E970 Offset: 0x75E970 VA: 0x75E970
	public SynchronizationContext get_SynchronizationContext() { }

	// RVA: 0x75E984 Offset: 0x75E984 VA: 0x75E984
	public SynchronizationContext get_SynchronizationContextNoFlow() { }

	// RVA: 0x75E998 Offset: 0x75E998 VA: 0x75E998
	public LogicalCallContext.Reader get_LogicalCallContext() { }

	// RVA: 0x75E9A0 Offset: 0x75E9A0 VA: 0x75E9A0
	public bool HasSameLocalValues(ExecutionContext other) { }
}
