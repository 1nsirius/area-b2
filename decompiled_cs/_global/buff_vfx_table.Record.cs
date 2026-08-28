// Namespace: 
public class buff_vfx_table.Record : ICloneable // TypeDefIndex: 10564
{
	// Fields
	[CompilerGeneratedAttribute] // RVA: 0x56F3D4 Offset: 0x56F3D4 VA: 0x56F3D4
	private int <id>k__BackingField; // 0x8
	[CompilerGeneratedAttribute] // RVA: 0x56F3E4 Offset: 0x56F3E4 VA: 0x56F3E4
	private int <particle_id>k__BackingField; // 0xC
	[CompilerGeneratedAttribute] // RVA: 0x56F3F4 Offset: 0x56F3F4 VA: 0x56F3F4
	private string <vector_param>k__BackingField; // 0x10
	[CompilerGeneratedAttribute] // RVA: 0x56F404 Offset: 0x56F404 VA: 0x56F404
	private float[] <vector_param_buffvalue_0>k__BackingField; // 0x14
	[CompilerGeneratedAttribute] // RVA: 0x56F414 Offset: 0x56F414 VA: 0x56F414
	private float[] <vector_param_buffvalue_1>k__BackingField; // 0x18

	// Properties
	public int id { get; set; }
	public int particle_id { get; set; }
	public string vector_param { get; set; }
	public float[] vector_param_buffvalue_0 { get; set; }
	public float[] vector_param_buffvalue_1 { get; set; }

	// Methods

	[CompilerGeneratedAttribute] // RVA: 0x65F310 Offset: 0x65F310 VA: 0x65F310
	// RVA: 0x1DFBF40 Offset: 0x1DFBF40 VA: 0x1DFBF40
	public int get_id() { }

	[CompilerGeneratedAttribute] // RVA: 0x65F320 Offset: 0x65F320 VA: 0x65F320
	// RVA: 0x1DFBF48 Offset: 0x1DFBF48 VA: 0x1DFBF48
	private void set_id(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65F330 Offset: 0x65F330 VA: 0x65F330
	// RVA: 0x1DFBF50 Offset: 0x1DFBF50 VA: 0x1DFBF50
	public int get_particle_id() { }

	[CompilerGeneratedAttribute] // RVA: 0x65F340 Offset: 0x65F340 VA: 0x65F340
	// RVA: 0x1DFBF58 Offset: 0x1DFBF58 VA: 0x1DFBF58
	private void set_particle_id(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65F350 Offset: 0x65F350 VA: 0x65F350
	// RVA: 0x1DFBF60 Offset: 0x1DFBF60 VA: 0x1DFBF60
	public string get_vector_param() { }

	[CompilerGeneratedAttribute] // RVA: 0x65F360 Offset: 0x65F360 VA: 0x65F360
	// RVA: 0x1DFBF68 Offset: 0x1DFBF68 VA: 0x1DFBF68
	private void set_vector_param(string value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65F370 Offset: 0x65F370 VA: 0x65F370
	// RVA: 0x1DFBF70 Offset: 0x1DFBF70 VA: 0x1DFBF70
	public float[] get_vector_param_buffvalue_0() { }

	[CompilerGeneratedAttribute] // RVA: 0x65F380 Offset: 0x65F380 VA: 0x65F380
	// RVA: 0x1DFBF78 Offset: 0x1DFBF78 VA: 0x1DFBF78
	private void set_vector_param_buffvalue_0(float[] value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65F390 Offset: 0x65F390 VA: 0x65F390
	// RVA: 0x1DFBF80 Offset: 0x1DFBF80 VA: 0x1DFBF80
	public float[] get_vector_param_buffvalue_1() { }

	[CompilerGeneratedAttribute] // RVA: 0x65F3A0 Offset: 0x65F3A0 VA: 0x65F3A0
	// RVA: 0x1DFBF88 Offset: 0x1DFBF88 VA: 0x1DFBF88
	private void set_vector_param_buffvalue_1(float[] value) { }

	// RVA: 0x1DFBD40 Offset: 0x1DFBD40 VA: 0x1DFBD40
	internal void .ctor(MemoryStream reader, Action<buff_vfx_table.Record, MemoryStream>[] readActions) { }

	// RVA: 0x1DFB018 Offset: 0x1DFB018 VA: 0x1DFB018
	internal static bool SetupReadActions(Field[] fields, Action<buff_vfx_table.Record, MemoryStream>[] readActions) { }

	// RVA: 0x1DFBF98 Offset: 0x1DFBF98 VA: 0x1DFBF98 Slot: 4
	public object Clone() { }
}
