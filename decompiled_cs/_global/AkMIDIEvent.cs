// Namespace: 
public class AkMIDIEvent : IDisposable // TypeDefIndex: 5915
{
	// Fields
	private IntPtr swigCPtr; // 0x8
	protected bool swigCMemOwn; // 0xC

	// Properties
	public byte byChan { get; set; }
	public AkMIDIEvent.tGen Gen { get; set; }
	public AkMIDIEvent.tCc Cc { get; set; }
	public AkMIDIEvent.tNoteOnOff NoteOnOff { get; set; }
	public AkMIDIEvent.tPitchBend PitchBend { get; set; }
	public AkMIDIEvent.tNoteAftertouch NoteAftertouch { get; set; }
	public AkMIDIEvent.tChanAftertouch ChanAftertouch { get; set; }
	public AkMIDIEvent.tProgramChange ProgramChange { get; set; }
	public AkMIDIEventTypes byType { get; set; }
	public byte byOnOffNote { get; set; }
	public byte byVelocity { get; set; }
	public AkMIDICcTypes byCc { get; set; }
	public byte byCcValue { get; set; }
	public byte byValueLsb { get; set; }
	public byte byValueMsb { get; set; }
	public byte byAftertouchNote { get; set; }
	public byte byNoteAftertouchValue { get; set; }
	public byte byChanAftertouchValue { get; set; }
	public byte byProgramNum { get; set; }

	// Methods

	// RVA: 0x1BAB37C Offset: 0x1BAB37C VA: 0x1BAB37C
	internal void .ctor(IntPtr cPtr, bool cMemoryOwn) { }

	// RVA: 0x1BAB3A4 Offset: 0x1BAB3A4 VA: 0x1BAB3A4
	internal static IntPtr getCPtr(AkMIDIEvent obj) { }

	// RVA: 0x1BAB3FC Offset: 0x1BAB3FC VA: 0x1BAB3FC Slot: 5
	internal virtual void setCPtr(IntPtr cPtr) { }

	// RVA: 0x1BAB428 Offset: 0x1BAB428 VA: 0x1BAB428 Slot: 1
	protected override void Finalize() { }

	// RVA: 0x1BAB49C Offset: 0x1BAB49C VA: 0x1BAB49C Slot: 6
	public virtual void Dispose() { }

	// RVA: 0x1BAB620 Offset: 0x1BAB620 VA: 0x1BAB620
	public void set_byChan(byte value) { }

	// RVA: 0x1BAB6B0 Offset: 0x1BAB6B0 VA: 0x1BAB6B0
	public byte get_byChan() { }

	// RVA: 0x1BAB738 Offset: 0x1BAB738 VA: 0x1BAB738
	public void set_Gen(AkMIDIEvent.tGen value) { }

	// RVA: 0x1BAB868 Offset: 0x1BAB868 VA: 0x1BAB868
	public AkMIDIEvent.tGen get_Gen() { }

	// RVA: 0x1BAB964 Offset: 0x1BAB964 VA: 0x1BAB964
	public void set_Cc(AkMIDIEvent.tCc value) { }

	// RVA: 0x1BABA94 Offset: 0x1BABA94 VA: 0x1BABA94
	public AkMIDIEvent.tCc get_Cc() { }

	// RVA: 0x1BABB90 Offset: 0x1BABB90 VA: 0x1BABB90
	public void set_NoteOnOff(AkMIDIEvent.tNoteOnOff value) { }

	// RVA: 0x1BABCC0 Offset: 0x1BABCC0 VA: 0x1BABCC0
	public AkMIDIEvent.tNoteOnOff get_NoteOnOff() { }

	// RVA: 0x1BABDBC Offset: 0x1BABDBC VA: 0x1BABDBC
	public void set_PitchBend(AkMIDIEvent.tPitchBend value) { }

	// RVA: 0x1BABEEC Offset: 0x1BABEEC VA: 0x1BABEEC
	public AkMIDIEvent.tPitchBend get_PitchBend() { }

	// RVA: 0x1BABFE8 Offset: 0x1BABFE8 VA: 0x1BABFE8
	public void set_NoteAftertouch(AkMIDIEvent.tNoteAftertouch value) { }

	// RVA: 0x1BAC118 Offset: 0x1BAC118 VA: 0x1BAC118
	public AkMIDIEvent.tNoteAftertouch get_NoteAftertouch() { }

	// RVA: 0x1BAC214 Offset: 0x1BAC214 VA: 0x1BAC214
	public void set_ChanAftertouch(AkMIDIEvent.tChanAftertouch value) { }

	// RVA: 0x1BAC344 Offset: 0x1BAC344 VA: 0x1BAC344
	public AkMIDIEvent.tChanAftertouch get_ChanAftertouch() { }

	// RVA: 0x1BAC440 Offset: 0x1BAC440 VA: 0x1BAC440
	public void set_ProgramChange(AkMIDIEvent.tProgramChange value) { }

	// RVA: 0x1BAC570 Offset: 0x1BAC570 VA: 0x1BAC570
	public AkMIDIEvent.tProgramChange get_ProgramChange() { }

	// RVA: 0x1BAC66C Offset: 0x1BAC66C VA: 0x1BAC66C
	public void set_byType(AkMIDIEventTypes value) { }

	// RVA: 0x1BAC6FC Offset: 0x1BAC6FC VA: 0x1BAC6FC
	public AkMIDIEventTypes get_byType() { }

	// RVA: 0x1BAC784 Offset: 0x1BAC784 VA: 0x1BAC784
	public void set_byOnOffNote(byte value) { }

	// RVA: 0x1BAC814 Offset: 0x1BAC814 VA: 0x1BAC814
	public byte get_byOnOffNote() { }

	// RVA: 0x1BAC89C Offset: 0x1BAC89C VA: 0x1BAC89C
	public void set_byVelocity(byte value) { }

	// RVA: 0x1BAC92C Offset: 0x1BAC92C VA: 0x1BAC92C
	public byte get_byVelocity() { }

	// RVA: 0x1BAC9B4 Offset: 0x1BAC9B4 VA: 0x1BAC9B4
	public void set_byCc(AkMIDICcTypes value) { }

	// RVA: 0x1BACA44 Offset: 0x1BACA44 VA: 0x1BACA44
	public AkMIDICcTypes get_byCc() { }

	// RVA: 0x1BACACC Offset: 0x1BACACC VA: 0x1BACACC
	public void set_byCcValue(byte value) { }

	// RVA: 0x1BACB5C Offset: 0x1BACB5C VA: 0x1BACB5C
	public byte get_byCcValue() { }

	// RVA: 0x1BACBE4 Offset: 0x1BACBE4 VA: 0x1BACBE4
	public void set_byValueLsb(byte value) { }

	// RVA: 0x1BACC74 Offset: 0x1BACC74 VA: 0x1BACC74
	public byte get_byValueLsb() { }

	// RVA: 0x1BACCFC Offset: 0x1BACCFC VA: 0x1BACCFC
	public void set_byValueMsb(byte value) { }

	// RVA: 0x1BACD8C Offset: 0x1BACD8C VA: 0x1BACD8C
	public byte get_byValueMsb() { }

	// RVA: 0x1BACE14 Offset: 0x1BACE14 VA: 0x1BACE14
	public void set_byAftertouchNote(byte value) { }

	// RVA: 0x1BACEA4 Offset: 0x1BACEA4 VA: 0x1BACEA4
	public byte get_byAftertouchNote() { }

	// RVA: 0x1BACF2C Offset: 0x1BACF2C VA: 0x1BACF2C
	public void set_byNoteAftertouchValue(byte value) { }

	// RVA: 0x1BACFBC Offset: 0x1BACFBC VA: 0x1BACFBC
	public byte get_byNoteAftertouchValue() { }

	// RVA: 0x1BAD044 Offset: 0x1BAD044 VA: 0x1BAD044
	public void set_byChanAftertouchValue(byte value) { }

	// RVA: 0x1BAD0D4 Offset: 0x1BAD0D4 VA: 0x1BAD0D4
	public byte get_byChanAftertouchValue() { }

	// RVA: 0x1BAD15C Offset: 0x1BAD15C VA: 0x1BAD15C
	public void set_byProgramNum(byte value) { }

	// RVA: 0x1BAD1EC Offset: 0x1BAD1EC VA: 0x1BAD1EC
	public byte get_byProgramNum() { }

	// RVA: 0x1BAD274 Offset: 0x1BAD274 VA: 0x1BAD274
	public void .ctor() { }
}
