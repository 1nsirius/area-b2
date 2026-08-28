// Namespace: 
private class TimerThread.TimerNode : TimerThread.Timer // TypeDefIndex: 1937
{
	// Fields
	private TimerThread.TimerNode.TimerState m_TimerState; // 0x10
	private TimerThread.Callback m_Callback; // 0x14
	private object m_Context; // 0x18
	private object m_QueueLock; // 0x1C
	private TimerThread.TimerNode next; // 0x20
	private TimerThread.TimerNode prev; // 0x24

	// Properties
	internal TimerThread.TimerNode Next { get; set; }
	internal TimerThread.TimerNode Prev { get; set; }

	// Methods

	// RVA: 0x1810794 Offset: 0x1810794 VA: 0x1810794
	internal void .ctor() { }

	// RVA: 0x18107C8 Offset: 0x18107C8 VA: 0x18107C8
	internal TimerThread.TimerNode get_Next() { }

	// RVA: 0x18107D0 Offset: 0x18107D0 VA: 0x18107D0
	internal void set_Next(TimerThread.TimerNode value) { }

	// RVA: 0x18107D8 Offset: 0x18107D8 VA: 0x18107D8
	internal TimerThread.TimerNode get_Prev() { }

	// RVA: 0x18107E0 Offset: 0x18107E0 VA: 0x18107E0
	internal void set_Prev(TimerThread.TimerNode value) { }

	// RVA: 0x18107E8 Offset: 0x18107E8 VA: 0x18107E8 Slot: 5
	internal override bool Cancel() { }
}
