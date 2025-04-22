using pokemonBattleSimulator.PkmnObjects.PkmnMove;

namespace pokemonBattleSimulator.PkmnObjects.Trainer
{
  public interface ITrainer
  {
    public string _Name { get; set; }
    public Pokemon[] _Party { get; set; }
    public Pokemon[] _ActivePkmn { get; set; }

    public abstract Move ChoseMove(Pokemon playerMon, Field field);
    Dictionary<Move, double> GetMoveProbabilities(Pokemon pokemon, Field field);
    Dictionary<Move, List<(int, double)>> GetMoveScoreProbabilities(Pokemon pokemon, Field field);
  }
}
