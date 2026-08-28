// Namespace: 
public class client.load_role.request : SprotoTypeBase // TypeDefIndex: 9127
{
	// Fields
	private static int max_field_count; // 0x0
	private client.AnalysisInfo _analysis_info; // 0x14
	private string _lang; // 0x18

	// Properties
	public client.AnalysisInfo analysis_info { get; set; }
	public bool HasAnalysis_info { get; }
	public string lang { get; set; }
	public bool HasLang { get; }

	// Methods

	// RVA: 0x2441F38 Offset: 0x2441F38 VA: 0x2441F38
	public client.AnalysisInfo get_analysis_info() { }

	// RVA: 0x2441F40 Offset: 0x2441F40 VA: 0x2441F40
	public void set_analysis_info(client.AnalysisInfo value) { }

	// RVA: 0x2441F80 Offset: 0x2441F80 VA: 0x2441F80
	public bool get_HasAnalysis_info() { }

	// RVA: 0x2441FB0 Offset: 0x2441FB0 VA: 0x2441FB0
	public string get_lang() { }

	// RVA: 0x2441FB8 Offset: 0x2441FB8 VA: 0x2441FB8
	public void set_lang(string value) { }

	// RVA: 0x2441FF8 Offset: 0x2441FF8 VA: 0x2441FF8
	public bool get_HasLang() { }

	// RVA: 0x2442028 Offset: 0x2442028 VA: 0x2442028
	public void .ctor() { }

	// RVA: 0x24420C4 Offset: 0x24420C4 VA: 0x24420C4
	public void .ctor(byte[] buffer) { }

	// RVA: 0x244217C Offset: 0x244217C VA: 0x244217C Slot: 5
	protected override void decode() { }

	// RVA: 0x244228C Offset: 0x244228C VA: 0x244228C Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x2442394 Offset: 0x2442394 VA: 0x2442394 Slot: 3
	public override string ToString() { }

	// RVA: 0x2442400 Offset: 0x2442400 VA: 0x2442400
	private static void .cctor() { }
}
