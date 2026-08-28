namespace FGame
{

// Namespace: FGame
public interface IPlayerData // TypeDefIndex: 9903
{
	// Properties
	public abstract uint Exp { get; }
	public abstract uint IconId { get; }
	public abstract uint Level { get; }
	public abstract string Name { get; }
	public abstract uint Uid { get; }

	// Methods

	// RVA: -1 Offset: -1 Slot: 0
	public abstract uint get_Exp();

	// RVA: -1 Offset: -1 Slot: 1
	public abstract uint get_IconId();

	// RVA: -1 Offset: -1 Slot: 2
	public abstract uint get_Level();

	// RVA: -1 Offset: -1 Slot: 3
	public abstract string get_Name();

	// RVA: -1 Offset: -1 Slot: 4
	public abstract uint get_Uid();

	// RVA: -1 Offset: -1 Slot: 5
	public abstract long GetStat(string key);
}

} // namespace FGame
