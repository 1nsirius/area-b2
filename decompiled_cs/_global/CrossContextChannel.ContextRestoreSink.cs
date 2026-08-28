// Namespace: 
private class CrossContextChannel.ContextRestoreSink : IMessageSink // TypeDefIndex: 1156
{
	// Fields
	private IMessageSink _next; // 0x8
	private Context _context; // 0xC
	private IMessage _call; // 0x10

	// Methods

	// RVA: 0x171EB8C Offset: 0x171EB8C VA: 0x171EB8C
	public void .ctor(IMessageSink next, Context context, IMessage call) { }

	// RVA: 0x171EBBC Offset: 0x171EBBC VA: 0x171EBBC Slot: 4
	public IMessage SyncProcessMessage(IMessage msg) { }

	// RVA: 0x171EF50 Offset: 0x171EF50 VA: 0x171EF50 Slot: 5
	public IMessageCtrl AsyncProcessMessage(IMessage msg, IMessageSink replySink) { }
}
