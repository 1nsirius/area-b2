// Namespace: 
public abstract class Character.ToolSkillBaseInstance : Character.SkillInstance // TypeDefIndex: 13265
{
	// Fields
	[CompilerGeneratedAttribute] // RVA: 0x57969C Offset: 0x57969C VA: 0x57969C
	private ToolBase <Tool>k__BackingField; // 0x10

	// Properties
	public ToolBase Tool { get; set; }

	// Methods

	[CompilerGeneratedAttribute] // RVA: 0x668640 Offset: 0x668640 VA: 0x668640
	// RVA: 0x96DD60 Offset: 0x96DD60 VA: 0x96DD60
	public ToolBase get_Tool() { }

	[CompilerGeneratedAttribute] // RVA: 0x668650 Offset: 0x668650 VA: 0x668650
	// RVA: 0x96DD68 Offset: 0x96DD68 VA: 0x96DD68
	private void set_Tool(ToolBase value) { }

	// RVA: 0x96DD70 Offset: 0x96DD70 VA: 0x96DD70 Slot: 5
	public override void Load(Character c, SkillCfg skillCfg) { }

	// RVA: 0x96E304 Offset: 0x96E304 VA: 0x96E304 Slot: 6
	public override void Destroy() { }

	// RVA: -1 Offset: -1 Slot: 4
	public abstract override void Apply(Character.ISkillApply apply);

	// RVA: 0x96B9BC Offset: 0x96B9BC VA: 0x96B9BC
	protected void .ctor() { }
}
