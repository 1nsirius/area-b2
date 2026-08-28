// Namespace: 
public class body_state_table.Record : ICloneable // TypeDefIndex: 10544
{
	// Fields
	[CompilerGeneratedAttribute] // RVA: 0x56EE54 Offset: 0x56EE54 VA: 0x56EE54
	private int <id>k__BackingField; // 0x8
	[CompilerGeneratedAttribute] // RVA: 0x56EE64 Offset: 0x56EE64 VA: 0x56EE64
	private string <name>k__BackingField; // 0xC
	[CompilerGeneratedAttribute] // RVA: 0x56EE74 Offset: 0x56EE74 VA: 0x56EE74
	private int <Stand>k__BackingField; // 0x10
	[CompilerGeneratedAttribute] // RVA: 0x56EE84 Offset: 0x56EE84 VA: 0x56EE84
	private int <Run>k__BackingField; // 0x14
	[CompilerGeneratedAttribute] // RVA: 0x56EE94 Offset: 0x56EE94 VA: 0x56EE94
	private int <Crouch>k__BackingField; // 0x18
	[CompilerGeneratedAttribute] // RVA: 0x56EEA4 Offset: 0x56EEA4 VA: 0x56EEA4
	private int <Creep>k__BackingField; // 0x1C
	[CompilerGeneratedAttribute] // RVA: 0x56EEB4 Offset: 0x56EEB4 VA: 0x56EEB4
	private int <LieDown>k__BackingField; // 0x20
	[CompilerGeneratedAttribute] // RVA: 0x56EEC4 Offset: 0x56EEC4 VA: 0x56EEC4
	private int <Fall>k__BackingField; // 0x24
	[CompilerGeneratedAttribute] // RVA: 0x56EED4 Offset: 0x56EED4 VA: 0x56EED4
	private int <JumpOn>k__BackingField; // 0x28
	[CompilerGeneratedAttribute] // RVA: 0x56EEE4 Offset: 0x56EEE4 VA: 0x56EEE4
	private int <JumpOver>k__BackingField; // 0x2C
	[CompilerGeneratedAttribute] // RVA: 0x56EEF4 Offset: 0x56EEF4 VA: 0x56EEF4
	private int <GroundToRope>k__BackingField; // 0x30
	[CompilerGeneratedAttribute] // RVA: 0x56EF04 Offset: 0x56EF04 VA: 0x56EF04
	private int <RoofToRope>k__BackingField; // 0x34
	[CompilerGeneratedAttribute] // RVA: 0x56EF14 Offset: 0x56EF14 VA: 0x56EF14
	private int <IndoorToRope>k__BackingField; // 0x38
	[CompilerGeneratedAttribute] // RVA: 0x56EF24 Offset: 0x56EF24 VA: 0x56EF24
	private int <RopePlusToGround>k__BackingField; // 0x3C
	[CompilerGeneratedAttribute] // RVA: 0x56EF34 Offset: 0x56EF34 VA: 0x56EF34
	private int <RopePlusToRoof>k__BackingField; // 0x40
	[CompilerGeneratedAttribute] // RVA: 0x56EF44 Offset: 0x56EF44 VA: 0x56EF44
	private int <RopePlusToIndoor>k__BackingField; // 0x44
	[CompilerGeneratedAttribute] // RVA: 0x56EF54 Offset: 0x56EF54 VA: 0x56EF54
	private int <RopeMinusToGround>k__BackingField; // 0x48
	[CompilerGeneratedAttribute] // RVA: 0x56EF64 Offset: 0x56EF64 VA: 0x56EF64
	private int <RopeMinusToRoof>k__BackingField; // 0x4C
	[CompilerGeneratedAttribute] // RVA: 0x56EF74 Offset: 0x56EF74 VA: 0x56EF74
	private int <RopeMinusToIndoor>k__BackingField; // 0x50
	[CompilerGeneratedAttribute] // RVA: 0x56EF84 Offset: 0x56EF84 VA: 0x56EF84
	private int <RopePlus>k__BackingField; // 0x54
	[CompilerGeneratedAttribute] // RVA: 0x56EF94 Offset: 0x56EF94 VA: 0x56EF94
	private int <RopeMinus>k__BackingField; // 0x58
	[CompilerGeneratedAttribute] // RVA: 0x56EFA4 Offset: 0x56EFA4 VA: 0x56EFA4
	private int <RopePlusToMinus>k__BackingField; // 0x5C
	[CompilerGeneratedAttribute] // RVA: 0x56EFB4 Offset: 0x56EFB4 VA: 0x56EFB4
	private int <RopeMinusToPlus>k__BackingField; // 0x60
	[CompilerGeneratedAttribute] // RVA: 0x56EFC4 Offset: 0x56EFC4 VA: 0x56EFC4
	private int <CreepToCrouch>k__BackingField; // 0x64
	[CompilerGeneratedAttribute] // RVA: 0x56EFD4 Offset: 0x56EFD4 VA: 0x56EFD4
	private int <CreepToStand>k__BackingField; // 0x68
	[CompilerGeneratedAttribute] // RVA: 0x56EFE4 Offset: 0x56EFE4 VA: 0x56EFE4
	private int <CrouchToCreep>k__BackingField; // 0x6C
	[CompilerGeneratedAttribute] // RVA: 0x56EFF4 Offset: 0x56EFF4 VA: 0x56EFF4
	private int <StandToCreep>k__BackingField; // 0x70
	[CompilerGeneratedAttribute] // RVA: 0x56F004 Offset: 0x56F004 VA: 0x56F004
	private int <JumpEnd>k__BackingField; // 0x74
	[CompilerGeneratedAttribute] // RVA: 0x56F014 Offset: 0x56F014 VA: 0x56F014
	private int <RopePlusSus>k__BackingField; // 0x78
	[CompilerGeneratedAttribute] // RVA: 0x56F024 Offset: 0x56F024 VA: 0x56F024
	private int <RopeMinusSus>k__BackingField; // 0x7C
	[CompilerGeneratedAttribute] // RVA: 0x56F034 Offset: 0x56F034 VA: 0x56F034
	private int <RopePlusToMinusSus>k__BackingField; // 0x80
	[CompilerGeneratedAttribute] // RVA: 0x56F044 Offset: 0x56F044 VA: 0x56F044
	private int <RopeMinusToPlusSus>k__BackingField; // 0x84
	[CompilerGeneratedAttribute] // RVA: 0x56F054 Offset: 0x56F054 VA: 0x56F054
	private int <LieDownToStand>k__BackingField; // 0x88
	[CompilerGeneratedAttribute] // RVA: 0x56F064 Offset: 0x56F064 VA: 0x56F064
	private int <LieDownToCrouch>k__BackingField; // 0x8C
	[CompilerGeneratedAttribute] // RVA: 0x56F074 Offset: 0x56F074 VA: 0x56F074
	private int <StandToLieDown>k__BackingField; // 0x90
	[CompilerGeneratedAttribute] // RVA: 0x56F084 Offset: 0x56F084 VA: 0x56F084
	private int <CrouchToLieDown>k__BackingField; // 0x94
	[CompilerGeneratedAttribute] // RVA: 0x56F094 Offset: 0x56F094 VA: 0x56F094
	private int <CreepToLieDown>k__BackingField; // 0x98
	[CompilerGeneratedAttribute] // RVA: 0x56F0A4 Offset: 0x56F0A4 VA: 0x56F0A4
	private int <LieDownToCreep>k__BackingField; // 0x9C
	[CompilerGeneratedAttribute] // RVA: 0x56F0B4 Offset: 0x56F0B4 VA: 0x56F0B4
	private int <ClimbLadderDown>k__BackingField; // 0xA0
	[CompilerGeneratedAttribute] // RVA: 0x56F0C4 Offset: 0x56F0C4 VA: 0x56F0C4
	private int <ClimbLadderUp>k__BackingField; // 0xA4
	[CompilerGeneratedAttribute] // RVA: 0x56F0D4 Offset: 0x56F0D4 VA: 0x56F0D4
	private int <LeaveLadderDown>k__BackingField; // 0xA8
	[CompilerGeneratedAttribute] // RVA: 0x56F0E4 Offset: 0x56F0E4 VA: 0x56F0E4
	private int <LeaveLadderUp>k__BackingField; // 0xAC
	[CompilerGeneratedAttribute] // RVA: 0x56F0F4 Offset: 0x56F0F4 VA: 0x56F0F4
	private int <Ladder>k__BackingField; // 0xB0
	[CompilerGeneratedAttribute] // RVA: 0x56F104 Offset: 0x56F104 VA: 0x56F104
	private int <StandToAgonal>k__BackingField; // 0xB4
	[CompilerGeneratedAttribute] // RVA: 0x56F114 Offset: 0x56F114 VA: 0x56F114
	private int <CrouchToAgonal>k__BackingField; // 0xB8
	[CompilerGeneratedAttribute] // RVA: 0x56F124 Offset: 0x56F124 VA: 0x56F124
	private int <CreepToAgonal>k__BackingField; // 0xBC
	[CompilerGeneratedAttribute] // RVA: 0x56F134 Offset: 0x56F134 VA: 0x56F134
	private int <LieDownToAgonal>k__BackingField; // 0xC0
	[CompilerGeneratedAttribute] // RVA: 0x56F144 Offset: 0x56F144 VA: 0x56F144
	private int <AgonalLand>k__BackingField; // 0xC4
	[CompilerGeneratedAttribute] // RVA: 0x56F154 Offset: 0x56F154 VA: 0x56F154
	private int <AgonalToCrouch>k__BackingField; // 0xC8
	[CompilerGeneratedAttribute] // RVA: 0x56F164 Offset: 0x56F164 VA: 0x56F164
	private int <AgonalFall>k__BackingField; // 0xCC
	[CompilerGeneratedAttribute] // RVA: 0x56F174 Offset: 0x56F174 VA: 0x56F174
	private int <MountedLMG>k__BackingField; // 0xD0
	[CompilerGeneratedAttribute] // RVA: 0x56F184 Offset: 0x56F184 VA: 0x56F184
	private int <HandrailToRope>k__BackingField; // 0xD4

	// Properties
	public int id { get; set; }
	public string name { get; set; }
	public int Stand { get; set; }
	public int Run { get; set; }
	public int Crouch { get; set; }
	public int Creep { get; set; }
	public int LieDown { get; set; }
	public int Fall { get; set; }
	public int JumpOn { get; set; }
	public int JumpOver { get; set; }
	public int GroundToRope { get; set; }
	public int RoofToRope { get; set; }
	public int IndoorToRope { get; set; }
	public int RopePlusToGround { get; set; }
	public int RopePlusToRoof { get; set; }
	public int RopePlusToIndoor { get; set; }
	public int RopeMinusToGround { get; set; }
	public int RopeMinusToRoof { get; set; }
	public int RopeMinusToIndoor { get; set; }
	public int RopePlus { get; set; }
	public int RopeMinus { get; set; }
	public int RopePlusToMinus { get; set; }
	public int RopeMinusToPlus { get; set; }
	public int CreepToCrouch { get; set; }
	public int CreepToStand { get; set; }
	public int CrouchToCreep { get; set; }
	public int StandToCreep { get; set; }
	public int JumpEnd { get; set; }
	public int RopePlusSus { get; set; }
	public int RopeMinusSus { get; set; }
	public int RopePlusToMinusSus { get; set; }
	public int RopeMinusToPlusSus { get; set; }
	public int LieDownToStand { get; set; }
	public int LieDownToCrouch { get; set; }
	public int StandToLieDown { get; set; }
	public int CrouchToLieDown { get; set; }
	public int CreepToLieDown { get; set; }
	public int LieDownToCreep { get; set; }
	public int ClimbLadderDown { get; set; }
	public int ClimbLadderUp { get; set; }
	public int LeaveLadderDown { get; set; }
	public int LeaveLadderUp { get; set; }
	public int Ladder { get; set; }
	public int StandToAgonal { get; set; }
	public int CrouchToAgonal { get; set; }
	public int CreepToAgonal { get; set; }
	public int LieDownToAgonal { get; set; }
	public int AgonalLand { get; set; }
	public int AgonalToCrouch { get; set; }
	public int AgonalFall { get; set; }
	public int MountedLMG { get; set; }
	public int HandrailToRope { get; set; }

	// Methods

	[CompilerGeneratedAttribute] // RVA: 0x65E810 Offset: 0x65E810 VA: 0x65E810
	// RVA: 0x1E9AFC4 Offset: 0x1E9AFC4 VA: 0x1E9AFC4
	public int get_id() { }

	[CompilerGeneratedAttribute] // RVA: 0x65E820 Offset: 0x65E820 VA: 0x65E820
	// RVA: 0x1E9AFCC Offset: 0x1E9AFCC VA: 0x1E9AFCC
	private void set_id(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65E830 Offset: 0x65E830 VA: 0x65E830
	// RVA: 0x1E9AFD4 Offset: 0x1E9AFD4 VA: 0x1E9AFD4
	public string get_name() { }

	[CompilerGeneratedAttribute] // RVA: 0x65E840 Offset: 0x65E840 VA: 0x65E840
	// RVA: 0x1E9AFDC Offset: 0x1E9AFDC VA: 0x1E9AFDC
	private void set_name(string value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65E850 Offset: 0x65E850 VA: 0x65E850
	// RVA: 0x1E9AFE4 Offset: 0x1E9AFE4 VA: 0x1E9AFE4
	public int get_Stand() { }

	[CompilerGeneratedAttribute] // RVA: 0x65E860 Offset: 0x65E860 VA: 0x65E860
	// RVA: 0x1E9AFEC Offset: 0x1E9AFEC VA: 0x1E9AFEC
	private void set_Stand(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65E870 Offset: 0x65E870 VA: 0x65E870
	// RVA: 0x1E9AFF4 Offset: 0x1E9AFF4 VA: 0x1E9AFF4
	public int get_Run() { }

	[CompilerGeneratedAttribute] // RVA: 0x65E880 Offset: 0x65E880 VA: 0x65E880
	// RVA: 0x1E9AFFC Offset: 0x1E9AFFC VA: 0x1E9AFFC
	private void set_Run(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65E890 Offset: 0x65E890 VA: 0x65E890
	// RVA: 0x1E9B004 Offset: 0x1E9B004 VA: 0x1E9B004
	public int get_Crouch() { }

	[CompilerGeneratedAttribute] // RVA: 0x65E8A0 Offset: 0x65E8A0 VA: 0x65E8A0
	// RVA: 0x1E9B00C Offset: 0x1E9B00C VA: 0x1E9B00C
	private void set_Crouch(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65E8B0 Offset: 0x65E8B0 VA: 0x65E8B0
	// RVA: 0x1E9B014 Offset: 0x1E9B014 VA: 0x1E9B014
	public int get_Creep() { }

	[CompilerGeneratedAttribute] // RVA: 0x65E8C0 Offset: 0x65E8C0 VA: 0x65E8C0
	// RVA: 0x1E9B01C Offset: 0x1E9B01C VA: 0x1E9B01C
	private void set_Creep(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65E8D0 Offset: 0x65E8D0 VA: 0x65E8D0
	// RVA: 0x1E9B024 Offset: 0x1E9B024 VA: 0x1E9B024
	public int get_LieDown() { }

	[CompilerGeneratedAttribute] // RVA: 0x65E8E0 Offset: 0x65E8E0 VA: 0x65E8E0
	// RVA: 0x1E9B02C Offset: 0x1E9B02C VA: 0x1E9B02C
	private void set_LieDown(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65E8F0 Offset: 0x65E8F0 VA: 0x65E8F0
	// RVA: 0x1E9B034 Offset: 0x1E9B034 VA: 0x1E9B034
	public int get_Fall() { }

	[CompilerGeneratedAttribute] // RVA: 0x65E900 Offset: 0x65E900 VA: 0x65E900
	// RVA: 0x1E9B03C Offset: 0x1E9B03C VA: 0x1E9B03C
	private void set_Fall(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65E910 Offset: 0x65E910 VA: 0x65E910
	// RVA: 0x1E9B044 Offset: 0x1E9B044 VA: 0x1E9B044
	public int get_JumpOn() { }

	[CompilerGeneratedAttribute] // RVA: 0x65E920 Offset: 0x65E920 VA: 0x65E920
	// RVA: 0x1E9B04C Offset: 0x1E9B04C VA: 0x1E9B04C
	private void set_JumpOn(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65E930 Offset: 0x65E930 VA: 0x65E930
	// RVA: 0x1E9B054 Offset: 0x1E9B054 VA: 0x1E9B054
	public int get_JumpOver() { }

	[CompilerGeneratedAttribute] // RVA: 0x65E940 Offset: 0x65E940 VA: 0x65E940
	// RVA: 0x1E9B05C Offset: 0x1E9B05C VA: 0x1E9B05C
	private void set_JumpOver(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65E950 Offset: 0x65E950 VA: 0x65E950
	// RVA: 0x1E9B064 Offset: 0x1E9B064 VA: 0x1E9B064
	public int get_GroundToRope() { }

	[CompilerGeneratedAttribute] // RVA: 0x65E960 Offset: 0x65E960 VA: 0x65E960
	// RVA: 0x1E9B06C Offset: 0x1E9B06C VA: 0x1E9B06C
	private void set_GroundToRope(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65E970 Offset: 0x65E970 VA: 0x65E970
	// RVA: 0x1E9B074 Offset: 0x1E9B074 VA: 0x1E9B074
	public int get_RoofToRope() { }

	[CompilerGeneratedAttribute] // RVA: 0x65E980 Offset: 0x65E980 VA: 0x65E980
	// RVA: 0x1E9B07C Offset: 0x1E9B07C VA: 0x1E9B07C
	private void set_RoofToRope(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65E990 Offset: 0x65E990 VA: 0x65E990
	// RVA: 0x1E9B084 Offset: 0x1E9B084 VA: 0x1E9B084
	public int get_IndoorToRope() { }

	[CompilerGeneratedAttribute] // RVA: 0x65E9A0 Offset: 0x65E9A0 VA: 0x65E9A0
	// RVA: 0x1E9B08C Offset: 0x1E9B08C VA: 0x1E9B08C
	private void set_IndoorToRope(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65E9B0 Offset: 0x65E9B0 VA: 0x65E9B0
	// RVA: 0x1E9B094 Offset: 0x1E9B094 VA: 0x1E9B094
	public int get_RopePlusToGround() { }

	[CompilerGeneratedAttribute] // RVA: 0x65E9C0 Offset: 0x65E9C0 VA: 0x65E9C0
	// RVA: 0x1E9B09C Offset: 0x1E9B09C VA: 0x1E9B09C
	private void set_RopePlusToGround(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65E9D0 Offset: 0x65E9D0 VA: 0x65E9D0
	// RVA: 0x1E9B0A4 Offset: 0x1E9B0A4 VA: 0x1E9B0A4
	public int get_RopePlusToRoof() { }

	[CompilerGeneratedAttribute] // RVA: 0x65E9E0 Offset: 0x65E9E0 VA: 0x65E9E0
	// RVA: 0x1E9B0AC Offset: 0x1E9B0AC VA: 0x1E9B0AC
	private void set_RopePlusToRoof(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65E9F0 Offset: 0x65E9F0 VA: 0x65E9F0
	// RVA: 0x1E9B0B4 Offset: 0x1E9B0B4 VA: 0x1E9B0B4
	public int get_RopePlusToIndoor() { }

	[CompilerGeneratedAttribute] // RVA: 0x65EA00 Offset: 0x65EA00 VA: 0x65EA00
	// RVA: 0x1E9B0BC Offset: 0x1E9B0BC VA: 0x1E9B0BC
	private void set_RopePlusToIndoor(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65EA10 Offset: 0x65EA10 VA: 0x65EA10
	// RVA: 0x1E9B0C4 Offset: 0x1E9B0C4 VA: 0x1E9B0C4
	public int get_RopeMinusToGround() { }

	[CompilerGeneratedAttribute] // RVA: 0x65EA20 Offset: 0x65EA20 VA: 0x65EA20
	// RVA: 0x1E9B0CC Offset: 0x1E9B0CC VA: 0x1E9B0CC
	private void set_RopeMinusToGround(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65EA30 Offset: 0x65EA30 VA: 0x65EA30
	// RVA: 0x1E9B0D4 Offset: 0x1E9B0D4 VA: 0x1E9B0D4
	public int get_RopeMinusToRoof() { }

	[CompilerGeneratedAttribute] // RVA: 0x65EA40 Offset: 0x65EA40 VA: 0x65EA40
	// RVA: 0x1E9B0DC Offset: 0x1E9B0DC VA: 0x1E9B0DC
	private void set_RopeMinusToRoof(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65EA50 Offset: 0x65EA50 VA: 0x65EA50
	// RVA: 0x1E9B0E4 Offset: 0x1E9B0E4 VA: 0x1E9B0E4
	public int get_RopeMinusToIndoor() { }

	[CompilerGeneratedAttribute] // RVA: 0x65EA60 Offset: 0x65EA60 VA: 0x65EA60
	// RVA: 0x1E9B0EC Offset: 0x1E9B0EC VA: 0x1E9B0EC
	private void set_RopeMinusToIndoor(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65EA70 Offset: 0x65EA70 VA: 0x65EA70
	// RVA: 0x1E9B0F4 Offset: 0x1E9B0F4 VA: 0x1E9B0F4
	public int get_RopePlus() { }

	[CompilerGeneratedAttribute] // RVA: 0x65EA80 Offset: 0x65EA80 VA: 0x65EA80
	// RVA: 0x1E9B0FC Offset: 0x1E9B0FC VA: 0x1E9B0FC
	private void set_RopePlus(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65EA90 Offset: 0x65EA90 VA: 0x65EA90
	// RVA: 0x1E9B104 Offset: 0x1E9B104 VA: 0x1E9B104
	public int get_RopeMinus() { }

	[CompilerGeneratedAttribute] // RVA: 0x65EAA0 Offset: 0x65EAA0 VA: 0x65EAA0
	// RVA: 0x1E9B10C Offset: 0x1E9B10C VA: 0x1E9B10C
	private void set_RopeMinus(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65EAB0 Offset: 0x65EAB0 VA: 0x65EAB0
	// RVA: 0x1E9B114 Offset: 0x1E9B114 VA: 0x1E9B114
	public int get_RopePlusToMinus() { }

	[CompilerGeneratedAttribute] // RVA: 0x65EAC0 Offset: 0x65EAC0 VA: 0x65EAC0
	// RVA: 0x1E9B11C Offset: 0x1E9B11C VA: 0x1E9B11C
	private void set_RopePlusToMinus(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65EAD0 Offset: 0x65EAD0 VA: 0x65EAD0
	// RVA: 0x1E9B124 Offset: 0x1E9B124 VA: 0x1E9B124
	public int get_RopeMinusToPlus() { }

	[CompilerGeneratedAttribute] // RVA: 0x65EAE0 Offset: 0x65EAE0 VA: 0x65EAE0
	// RVA: 0x1E9B12C Offset: 0x1E9B12C VA: 0x1E9B12C
	private void set_RopeMinusToPlus(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65EAF0 Offset: 0x65EAF0 VA: 0x65EAF0
	// RVA: 0x1E9B134 Offset: 0x1E9B134 VA: 0x1E9B134
	public int get_CreepToCrouch() { }

	[CompilerGeneratedAttribute] // RVA: 0x65EB00 Offset: 0x65EB00 VA: 0x65EB00
	// RVA: 0x1E9B13C Offset: 0x1E9B13C VA: 0x1E9B13C
	private void set_CreepToCrouch(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65EB10 Offset: 0x65EB10 VA: 0x65EB10
	// RVA: 0x1E9B144 Offset: 0x1E9B144 VA: 0x1E9B144
	public int get_CreepToStand() { }

	[CompilerGeneratedAttribute] // RVA: 0x65EB20 Offset: 0x65EB20 VA: 0x65EB20
	// RVA: 0x1E9B14C Offset: 0x1E9B14C VA: 0x1E9B14C
	private void set_CreepToStand(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65EB30 Offset: 0x65EB30 VA: 0x65EB30
	// RVA: 0x1E9B154 Offset: 0x1E9B154 VA: 0x1E9B154
	public int get_CrouchToCreep() { }

	[CompilerGeneratedAttribute] // RVA: 0x65EB40 Offset: 0x65EB40 VA: 0x65EB40
	// RVA: 0x1E9B15C Offset: 0x1E9B15C VA: 0x1E9B15C
	private void set_CrouchToCreep(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65EB50 Offset: 0x65EB50 VA: 0x65EB50
	// RVA: 0x1E9B164 Offset: 0x1E9B164 VA: 0x1E9B164
	public int get_StandToCreep() { }

	[CompilerGeneratedAttribute] // RVA: 0x65EB60 Offset: 0x65EB60 VA: 0x65EB60
	// RVA: 0x1E9B16C Offset: 0x1E9B16C VA: 0x1E9B16C
	private void set_StandToCreep(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65EB70 Offset: 0x65EB70 VA: 0x65EB70
	// RVA: 0x1E9B174 Offset: 0x1E9B174 VA: 0x1E9B174
	public int get_JumpEnd() { }

	[CompilerGeneratedAttribute] // RVA: 0x65EB80 Offset: 0x65EB80 VA: 0x65EB80
	// RVA: 0x1E9B17C Offset: 0x1E9B17C VA: 0x1E9B17C
	private void set_JumpEnd(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65EB90 Offset: 0x65EB90 VA: 0x65EB90
	// RVA: 0x1E9B184 Offset: 0x1E9B184 VA: 0x1E9B184
	public int get_RopePlusSus() { }

	[CompilerGeneratedAttribute] // RVA: 0x65EBA0 Offset: 0x65EBA0 VA: 0x65EBA0
	// RVA: 0x1E9B18C Offset: 0x1E9B18C VA: 0x1E9B18C
	private void set_RopePlusSus(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65EBB0 Offset: 0x65EBB0 VA: 0x65EBB0
	// RVA: 0x1E9B194 Offset: 0x1E9B194 VA: 0x1E9B194
	public int get_RopeMinusSus() { }

	[CompilerGeneratedAttribute] // RVA: 0x65EBC0 Offset: 0x65EBC0 VA: 0x65EBC0
	// RVA: 0x1E9B19C Offset: 0x1E9B19C VA: 0x1E9B19C
	private void set_RopeMinusSus(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65EBD0 Offset: 0x65EBD0 VA: 0x65EBD0
	// RVA: 0x1E9B1A4 Offset: 0x1E9B1A4 VA: 0x1E9B1A4
	public int get_RopePlusToMinusSus() { }

	[CompilerGeneratedAttribute] // RVA: 0x65EBE0 Offset: 0x65EBE0 VA: 0x65EBE0
	// RVA: 0x1E9B1AC Offset: 0x1E9B1AC VA: 0x1E9B1AC
	private void set_RopePlusToMinusSus(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65EBF0 Offset: 0x65EBF0 VA: 0x65EBF0
	// RVA: 0x1E9B1B4 Offset: 0x1E9B1B4 VA: 0x1E9B1B4
	public int get_RopeMinusToPlusSus() { }

	[CompilerGeneratedAttribute] // RVA: 0x65EC00 Offset: 0x65EC00 VA: 0x65EC00
	// RVA: 0x1E9B1BC Offset: 0x1E9B1BC VA: 0x1E9B1BC
	private void set_RopeMinusToPlusSus(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65EC10 Offset: 0x65EC10 VA: 0x65EC10
	// RVA: 0x1E9B1C4 Offset: 0x1E9B1C4 VA: 0x1E9B1C4
	public int get_LieDownToStand() { }

	[CompilerGeneratedAttribute] // RVA: 0x65EC20 Offset: 0x65EC20 VA: 0x65EC20
	// RVA: 0x1E9B1CC Offset: 0x1E9B1CC VA: 0x1E9B1CC
	private void set_LieDownToStand(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65EC30 Offset: 0x65EC30 VA: 0x65EC30
	// RVA: 0x1E9B1D4 Offset: 0x1E9B1D4 VA: 0x1E9B1D4
	public int get_LieDownToCrouch() { }

	[CompilerGeneratedAttribute] // RVA: 0x65EC40 Offset: 0x65EC40 VA: 0x65EC40
	// RVA: 0x1E9B1DC Offset: 0x1E9B1DC VA: 0x1E9B1DC
	private void set_LieDownToCrouch(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65EC50 Offset: 0x65EC50 VA: 0x65EC50
	// RVA: 0x1E9B1E4 Offset: 0x1E9B1E4 VA: 0x1E9B1E4
	public int get_StandToLieDown() { }

	[CompilerGeneratedAttribute] // RVA: 0x65EC60 Offset: 0x65EC60 VA: 0x65EC60
	// RVA: 0x1E9B1EC Offset: 0x1E9B1EC VA: 0x1E9B1EC
	private void set_StandToLieDown(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65EC70 Offset: 0x65EC70 VA: 0x65EC70
	// RVA: 0x1E9B1F4 Offset: 0x1E9B1F4 VA: 0x1E9B1F4
	public int get_CrouchToLieDown() { }

	[CompilerGeneratedAttribute] // RVA: 0x65EC80 Offset: 0x65EC80 VA: 0x65EC80
	// RVA: 0x1E9B1FC Offset: 0x1E9B1FC VA: 0x1E9B1FC
	private void set_CrouchToLieDown(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65EC90 Offset: 0x65EC90 VA: 0x65EC90
	// RVA: 0x1E9B204 Offset: 0x1E9B204 VA: 0x1E9B204
	public int get_CreepToLieDown() { }

	[CompilerGeneratedAttribute] // RVA: 0x65ECA0 Offset: 0x65ECA0 VA: 0x65ECA0
	// RVA: 0x1E9B20C Offset: 0x1E9B20C VA: 0x1E9B20C
	private void set_CreepToLieDown(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65ECB0 Offset: 0x65ECB0 VA: 0x65ECB0
	// RVA: 0x1E9B214 Offset: 0x1E9B214 VA: 0x1E9B214
	public int get_LieDownToCreep() { }

	[CompilerGeneratedAttribute] // RVA: 0x65ECC0 Offset: 0x65ECC0 VA: 0x65ECC0
	// RVA: 0x1E9B21C Offset: 0x1E9B21C VA: 0x1E9B21C
	private void set_LieDownToCreep(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65ECD0 Offset: 0x65ECD0 VA: 0x65ECD0
	// RVA: 0x1E9B224 Offset: 0x1E9B224 VA: 0x1E9B224
	public int get_ClimbLadderDown() { }

	[CompilerGeneratedAttribute] // RVA: 0x65ECE0 Offset: 0x65ECE0 VA: 0x65ECE0
	// RVA: 0x1E9B22C Offset: 0x1E9B22C VA: 0x1E9B22C
	private void set_ClimbLadderDown(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65ECF0 Offset: 0x65ECF0 VA: 0x65ECF0
	// RVA: 0x1E9B234 Offset: 0x1E9B234 VA: 0x1E9B234
	public int get_ClimbLadderUp() { }

	[CompilerGeneratedAttribute] // RVA: 0x65ED00 Offset: 0x65ED00 VA: 0x65ED00
	// RVA: 0x1E9B23C Offset: 0x1E9B23C VA: 0x1E9B23C
	private void set_ClimbLadderUp(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65ED10 Offset: 0x65ED10 VA: 0x65ED10
	// RVA: 0x1E9B244 Offset: 0x1E9B244 VA: 0x1E9B244
	public int get_LeaveLadderDown() { }

	[CompilerGeneratedAttribute] // RVA: 0x65ED20 Offset: 0x65ED20 VA: 0x65ED20
	// RVA: 0x1E9B24C Offset: 0x1E9B24C VA: 0x1E9B24C
	private void set_LeaveLadderDown(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65ED30 Offset: 0x65ED30 VA: 0x65ED30
	// RVA: 0x1E9B254 Offset: 0x1E9B254 VA: 0x1E9B254
	public int get_LeaveLadderUp() { }

	[CompilerGeneratedAttribute] // RVA: 0x65ED40 Offset: 0x65ED40 VA: 0x65ED40
	// RVA: 0x1E9B25C Offset: 0x1E9B25C VA: 0x1E9B25C
	private void set_LeaveLadderUp(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65ED50 Offset: 0x65ED50 VA: 0x65ED50
	// RVA: 0x1E9B264 Offset: 0x1E9B264 VA: 0x1E9B264
	public int get_Ladder() { }

	[CompilerGeneratedAttribute] // RVA: 0x65ED60 Offset: 0x65ED60 VA: 0x65ED60
	// RVA: 0x1E9B26C Offset: 0x1E9B26C VA: 0x1E9B26C
	private void set_Ladder(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65ED70 Offset: 0x65ED70 VA: 0x65ED70
	// RVA: 0x1E9B274 Offset: 0x1E9B274 VA: 0x1E9B274
	public int get_StandToAgonal() { }

	[CompilerGeneratedAttribute] // RVA: 0x65ED80 Offset: 0x65ED80 VA: 0x65ED80
	// RVA: 0x1E9B27C Offset: 0x1E9B27C VA: 0x1E9B27C
	private void set_StandToAgonal(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65ED90 Offset: 0x65ED90 VA: 0x65ED90
	// RVA: 0x1E9B284 Offset: 0x1E9B284 VA: 0x1E9B284
	public int get_CrouchToAgonal() { }

	[CompilerGeneratedAttribute] // RVA: 0x65EDA0 Offset: 0x65EDA0 VA: 0x65EDA0
	// RVA: 0x1E9B28C Offset: 0x1E9B28C VA: 0x1E9B28C
	private void set_CrouchToAgonal(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65EDB0 Offset: 0x65EDB0 VA: 0x65EDB0
	// RVA: 0x1E9B294 Offset: 0x1E9B294 VA: 0x1E9B294
	public int get_CreepToAgonal() { }

	[CompilerGeneratedAttribute] // RVA: 0x65EDC0 Offset: 0x65EDC0 VA: 0x65EDC0
	// RVA: 0x1E9B29C Offset: 0x1E9B29C VA: 0x1E9B29C
	private void set_CreepToAgonal(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65EDD0 Offset: 0x65EDD0 VA: 0x65EDD0
	// RVA: 0x1E9B2A4 Offset: 0x1E9B2A4 VA: 0x1E9B2A4
	public int get_LieDownToAgonal() { }

	[CompilerGeneratedAttribute] // RVA: 0x65EDE0 Offset: 0x65EDE0 VA: 0x65EDE0
	// RVA: 0x1E9B2AC Offset: 0x1E9B2AC VA: 0x1E9B2AC
	private void set_LieDownToAgonal(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65EDF0 Offset: 0x65EDF0 VA: 0x65EDF0
	// RVA: 0x1E9B2B4 Offset: 0x1E9B2B4 VA: 0x1E9B2B4
	public int get_AgonalLand() { }

	[CompilerGeneratedAttribute] // RVA: 0x65EE00 Offset: 0x65EE00 VA: 0x65EE00
	// RVA: 0x1E9B2BC Offset: 0x1E9B2BC VA: 0x1E9B2BC
	private void set_AgonalLand(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65EE10 Offset: 0x65EE10 VA: 0x65EE10
	// RVA: 0x1E9B2C4 Offset: 0x1E9B2C4 VA: 0x1E9B2C4
	public int get_AgonalToCrouch() { }

	[CompilerGeneratedAttribute] // RVA: 0x65EE20 Offset: 0x65EE20 VA: 0x65EE20
	// RVA: 0x1E9B2CC Offset: 0x1E9B2CC VA: 0x1E9B2CC
	private void set_AgonalToCrouch(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65EE30 Offset: 0x65EE30 VA: 0x65EE30
	// RVA: 0x1E9B2D4 Offset: 0x1E9B2D4 VA: 0x1E9B2D4
	public int get_AgonalFall() { }

	[CompilerGeneratedAttribute] // RVA: 0x65EE40 Offset: 0x65EE40 VA: 0x65EE40
	// RVA: 0x1E9B2DC Offset: 0x1E9B2DC VA: 0x1E9B2DC
	private void set_AgonalFall(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65EE50 Offset: 0x65EE50 VA: 0x65EE50
	// RVA: 0x1E9B2E4 Offset: 0x1E9B2E4 VA: 0x1E9B2E4
	public int get_MountedLMG() { }

	[CompilerGeneratedAttribute] // RVA: 0x65EE60 Offset: 0x65EE60 VA: 0x65EE60
	// RVA: 0x1E9B2EC Offset: 0x1E9B2EC VA: 0x1E9B2EC
	private void set_MountedLMG(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65EE70 Offset: 0x65EE70 VA: 0x65EE70
	// RVA: 0x1E9B2F4 Offset: 0x1E9B2F4 VA: 0x1E9B2F4
	public int get_HandrailToRope() { }

	[CompilerGeneratedAttribute] // RVA: 0x65EE80 Offset: 0x65EE80 VA: 0x65EE80
	// RVA: 0x1E9B2FC Offset: 0x1E9B2FC VA: 0x1E9B2FC
	private void set_HandrailToRope(int value) { }

	// RVA: 0x1E9ADC4 Offset: 0x1E9ADC4 VA: 0x1E9ADC4
	internal void .ctor(MemoryStream reader, Action<body_state_table.Record, MemoryStream>[] readActions) { }

	// RVA: 0x1E95394 Offset: 0x1E95394 VA: 0x1E95394
	internal static bool SetupReadActions(Field[] fields, Action<body_state_table.Record, MemoryStream>[] readActions) { }

	// RVA: 0x1E9B304 Offset: 0x1E9B304 VA: 0x1E9B304 Slot: 4
	public object Clone() { }
}
