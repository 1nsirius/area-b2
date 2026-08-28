// Namespace: 
public class game.ReqReportBadPlayer.request : SprotoTypeBase // TypeDefIndex: 9290
{
	// Fields
	private static int max_field_count; // 0x0
	private long _uid; // 0x18
	private List<long> _report_types; // 0x20
	private string _desc; // 0x24
	private long _battleid; // 0x28

	// Properties
	public long uid { get; set; }
	public bool HasUid { get; }
	public List<long> report_types { get; set; }
	public bool HasReport_types { get; }
	public string desc { get; set; }
	public bool HasDesc { get; }
	public long battleid { get; set; }
	public bool HasBattleid { get; }

	// Methods

	// RVA: 0x255FAD4 Offset: 0x255FAD4 VA: 0x255FAD4
	public long get_uid() { }

	// RVA: 0x255FADC Offset: 0x255FADC VA: 0x255FADC
	public void set_uid(long value) { }

	// RVA: 0x255FB20 Offset: 0x255FB20 VA: 0x255FB20
	public bool get_HasUid() { }

	// RVA: 0x255FB50 Offset: 0x255FB50 VA: 0x255FB50
	public List<long> get_report_types() { }

	// RVA: 0x255FB58 Offset: 0x255FB58 VA: 0x255FB58
	public void set_report_types(List<long> value) { }

	// RVA: 0x255FB98 Offset: 0x255FB98 VA: 0x255FB98
	public bool get_HasReport_types() { }

	// RVA: 0x255FBC8 Offset: 0x255FBC8 VA: 0x255FBC8
	public string get_desc() { }

	// RVA: 0x255FBD0 Offset: 0x255FBD0 VA: 0x255FBD0
	public void set_desc(string value) { }

	// RVA: 0x255FC10 Offset: 0x255FC10 VA: 0x255FC10
	public bool get_HasDesc() { }

	// RVA: 0x255FC40 Offset: 0x255FC40 VA: 0x255FC40
	public long get_battleid() { }

	// RVA: 0x255FC48 Offset: 0x255FC48 VA: 0x255FC48
	public void set_battleid(long value) { }

	// RVA: 0x255FC8C Offset: 0x255FC8C VA: 0x255FC8C
	public bool get_HasBattleid() { }

	// RVA: 0x255FCBC Offset: 0x255FCBC VA: 0x255FCBC
	public void .ctor() { }

	// RVA: 0x255FD58 Offset: 0x255FD58 VA: 0x255FD58
	public void .ctor(byte[] buffer) { }

	// RVA: 0x255FE10 Offset: 0x255FE10 VA: 0x255FE10 Slot: 5
	protected override void decode() { }

	// RVA: 0x255FF64 Offset: 0x255FF64 VA: 0x255FF64 Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x2560138 Offset: 0x2560138 VA: 0x2560138 Slot: 3
	public override string ToString() { }

	// RVA: 0x2560380 Offset: 0x2560380 VA: 0x2560380
	private static void .cctor() { }
}
