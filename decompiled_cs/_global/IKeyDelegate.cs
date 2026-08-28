// Namespace: 
public interface IKeyDelegate // TypeDefIndex: 5227
{
	// Properties
	public abstract KeyCode keyCode { get; }
	public abstract string desc { get; }
	public abstract Action del { get; }

	// Methods

	// RVA: -1 Offset: -1 Slot: 0
	public abstract KeyCode get_keyCode();

	// RVA: -1 Offset: -1 Slot: 1
	public abstract string get_desc();

	// RVA: -1 Offset: -1 Slot: 2
	public abstract Action get_del();
}
