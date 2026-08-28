// Namespace: 
public class AkChannelEmitter : IDisposable // TypeDefIndex: 5890
{
	// Fields
	private IntPtr swigCPtr; // 0x8
	protected bool swigCMemOwn; // 0xC

	// Properties
	public AkTransform position { get; set; }
	public uint uInputChannels { get; set; }

	// Methods

	// RVA: 0xFE4B00 Offset: 0xFE4B00 VA: 0xFE4B00
	internal void .ctor(IntPtr cPtr, bool cMemoryOwn) { }

	// RVA: 0xFE4B28 Offset: 0xFE4B28 VA: 0xFE4B28
	internal static IntPtr getCPtr(AkChannelEmitter obj) { }

	// RVA: 0xFE4B80 Offset: 0xFE4B80 VA: 0xFE4B80 Slot: 5
	internal virtual void setCPtr(IntPtr cPtr) { }

	// RVA: 0xFE4BAC Offset: 0xFE4BAC VA: 0xFE4BAC Slot: 1
	protected override void Finalize() { }

	// RVA: 0xFE4C20 Offset: 0xFE4C20 VA: 0xFE4C20 Slot: 6
	public virtual void Dispose() { }

	// RVA: 0xFE4DA4 Offset: 0xFE4DA4 VA: 0xFE4DA4
	public void set_position(AkTransform value) { }

	// RVA: 0xFE4E44 Offset: 0xFE4E44 VA: 0xFE4E44
	public AkTransform get_position() { }

	// RVA: 0xFE4F14 Offset: 0xFE4F14 VA: 0xFE4F14
	public void set_uInputChannels(uint value) { }

	// RVA: 0xFE4FA4 Offset: 0xFE4FA4 VA: 0xFE4FA4
	public uint get_uInputChannels() { }
}
