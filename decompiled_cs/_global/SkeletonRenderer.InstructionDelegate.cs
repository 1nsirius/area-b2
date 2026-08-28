// Namespace: 
public sealed class SkeletonRenderer.InstructionDelegate : MulticastDelegate // TypeDefIndex: 7230
{
	// Methods

	// RVA: 0x11B012C Offset: 0x11B012C VA: 0x11B012C
	public void .ctor(object object, IntPtr method) { }

	// RVA: 0x11C0E44 Offset: 0x11C0E44 VA: 0x11C0E44 Slot: 12
	public virtual void Invoke(SkeletonRendererInstruction instruction) { }

	// RVA: 0x11C166C Offset: 0x11C166C VA: 0x11C166C Slot: 13
	public virtual IAsyncResult BeginInvoke(SkeletonRendererInstruction instruction, AsyncCallback callback, object object) { }

	// RVA: 0x11C1698 Offset: 0x11C1698 VA: 0x11C1698 Slot: 14
	public virtual void EndInvoke(IAsyncResult result) { }
}
