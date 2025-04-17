namespace pokemonBattleSimulator.PkmnObjects
{
  public interface ITrainer
  {
    public string _Name { get; set; }
    public Pokemon[] _Party { get; set;}
    public Pokemon[] _ActivePkmn { get; set; }

    public abstract Move ChoseMove(Pokemon playerMon, Field field);
  }
}
