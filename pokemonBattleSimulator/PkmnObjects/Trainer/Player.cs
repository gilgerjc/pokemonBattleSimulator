using pokemonBattleSimulator.PkmnObjects.PkmnMove;

namespace pokemonBattleSimulator.PkmnObjects.Trainer
{
  public class Player : ITrainer
  {
    public string _Name { get; set; }
    public Pokemon[] _Party { get; set; }
    public Pokemon[] _ActivePkmn { get; set; }

    public Player(string name, Pokemon[] box)
    {
      _Name = name;
      _Party = box;
      _ActivePkmn = [box[0], box[1]];
    }

    public Move ChoseMove(Pokemon playerMon, Field field)
    {
      throw new NotImplementedException();
    }

    public Dictionary<Move, List<(int, double)>> GetMoveScoreProbabilities(Pokemon pokemon, Field field)
    {
      throw new NotImplementedException();
    }

    public Dictionary<Move, double> GetMoveProbabilities(Pokemon pokemon, Field field)
    {
      throw new NotImplementedException();
    }
  }
}
