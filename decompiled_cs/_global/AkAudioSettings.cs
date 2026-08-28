// Namespace: 
public class AkAudioSettings : IDisposable // TypeDefIndex: 5879
{
	// Fields
	private IntPtr swigCPtr; // 0x8
	protected bool swigCMemOwn; // 0xC

	// Properties
	public uint uNumSamplesPerFrame { get; set; }
	public uint uNumSamplesPerSecond { get; set; }

	// Methods

	// RVA: 0xFDA45C Offset: 0xFDA45C VA: 0xFDA45C
	internal void .ctor(IntPtr cPtr, bool cMemoryOwn) { }

	// RVA: 0xFDA484 Offset: 0xFDA484 VA: 0xFDA484
	internal static IntPtr getCPtr(AkAudioSettings obj) { }

	// RVA: 0xFDA4DC Offset: 0xFDA4DC VA: 0xFDA4DC Slot: 5
	internal virtual void setCPtr(IntPtr cPtr) { }

	// RVA: 0xFDA508 Offset: 0xFDA508 VA: 0xFDA508 Slot: 1
	protected override void Finalize() { }

	// RVA: 0xFDA57C Offset: 0xFDA57C VA: 0xFDA57C Slot: 6
	public virtual void Dispose() { }

	// RVA: 0xFDA700 Offset: 0xFDA700 VA: 0xFDA700
	public void set_uNumSamplesPerFrame(uint value) { }

	// RVA: 0xFDA790 Offset: 0xFDA790 VA: 0xFDA790
	public uint get_uNumSamplesPerFrame() { }

	// RVA: 0xFDA818 Offset: 0xFDA818 VA: 0xFDA818
	public void set_uNumSamplesPerSecond(uint value) { }

	// RVA: 0xFDA8A8 Offset: 0xFDA8A8 VA: 0xFDA8A8
	public uint get_uNumSamplesPerSecond() { }

	// RVA: 0xFDA930 Offset: 0xFDA930 VA: 0xFDA930
	public void .ctor() { }
}
