// Namespace: 
public class game.RspCharacterInfo.request : SprotoTypeBase // TypeDefIndex: 9331
{
	// Fields
	private static int max_field_count; // 0x0
	private List<game.CharacterInfo> _characters; // 0x14

	// Properties
	public List<game.CharacterInfo> characters { get; set; }
	public bool HasCharacters { get; }

	// Methods

	// RVA: 0x225BCE8 Offset: 0x225BCE8 VA: 0x225BCE8
	public List<game.CharacterInfo> get_characters() { }

	// RVA: 0x225BCF0 Offset: 0x225BCF0 VA: 0x225BCF0
	public void set_characters(List<game.CharacterInfo> value) { }

	// RVA: 0x225BD30 Offset: 0x225BD30 VA: 0x225BD30
	public bool get_HasCharacters() { }

	// RVA: 0x225BD60 Offset: 0x225BD60 VA: 0x225BD60
	public void .ctor() { }

	// RVA: 0x225BDFC Offset: 0x225BDFC VA: 0x225BDFC
	public void .ctor(byte[] buffer) { }

	// RVA: 0x225BEB4 Offset: 0x225BEB4 VA: 0x225BEB4 Slot: 5
	protected override void decode() { }

	// RVA: 0x225BF80 Offset: 0x225BF80 VA: 0x225BF80 Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x225C078 Offset: 0x225C078 VA: 0x225C078 Slot: 3
	public override string ToString() { }

	// RVA: 0x225C108 Offset: 0x225C108 VA: 0x225C108
	private static void .cctor() { }
}
