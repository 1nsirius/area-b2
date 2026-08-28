// Namespace: 
public abstract class Character.SkillInstance // TypeDefIndex: 13262
{
	// Fields
	protected Character character; // 0x8
	[CompilerGeneratedAttribute] // RVA: 0x57968C Offset: 0x57968C VA: 0x57968C
	private SkillCfg <SkillCfg>k__BackingField; // 0xC

	// Properties
	public SkillCfg SkillCfg { get; set; }

	// Methods

	[CompilerGeneratedAttribute] // RVA: 0x668620 Offset: 0x668620 VA: 0x668620
	// RVA: 0x96C28C Offset: 0x96C28C VA: 0x96C28C
	public SkillCfg get_SkillCfg() { }

	[CompilerGeneratedAttribute] // RVA: 0x668630 Offset: 0x668630 VA: 0x668630
	// RVA: 0x96C294 Offset: 0x96C294 VA: 0x96C294
	private void set_SkillCfg(SkillCfg value) { }

	// RVA: -1 Offset: -1 Slot: 4
	public abstract void Apply(Character.ISkillApply apply);

	// RVA: 0x96AF30 Offset: 0x96AF30 VA: 0x96AF30 Slot: 5
	public virtual void Load(Character c, SkillCfg skillCfg) { }

	// RVA: 0x96C29C Offset: 0x96C29C VA: 0x96C29C Slot: 6
	public virtual void Destroy() { }

	// RVA: 0x96AF44 Offset: 0x96AF44 VA: 0x96AF44
	protected void .ctor() { }
}
