// Namespace: 
[VisibleToOtherModulesAttribute] // RVA: 0x4F6CFC Offset: 0x4F6CFC VA: 0x4F6CFC
internal sealed class PlayableBinding.CreateOutputMethod : MulticastDelegate // TypeDefIndex: 3496
{
	// Methods

	// RVA: 0x1969030 Offset: 0x1969030 VA: 0x1969030
	public void .ctor(object object, IntPtr method) { }

	// RVA: 0x1968AAC Offset: 0x1968AAC VA: 0x1968AAC Slot: 12
	public virtual PlayableOutput Invoke(PlayableGraph graph, string name) { }

	// RVA: 0x1969044 Offset: 0x1969044 VA: 0x1969044 Slot: 13
	public virtual IAsyncResult BeginInvoke(PlayableGraph graph, string name, AsyncCallback callback, object object) { }

	// RVA: 0x19690E4 Offset: 0x19690E4 VA: 0x19690E4 Slot: 14
	public virtual PlayableOutput EndInvoke(IAsyncResult result) { }
}
