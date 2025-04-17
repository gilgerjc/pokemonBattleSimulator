using pokemonBattleSimulator.PkmnObjects;

namespace pokemonBattleSimulator
{
  public class RunAndBunAI : ITrainer
  {
    public string _Name { get; set; }
    public Pokemon?[] _Party { get; set; }
    public Pokemon?[] _ActivePkmn { get; set; } // lead pokemon


    private int pkmnIndex = 0; // used for move selection, only changed in double battles


    private static Random _rand = new Random();

    public RunAndBunAI(string name, Pokemon?[] party)
    {
      _Name = name;
      _Party = party;
      _ActivePkmn = [party[0], party[1]];
    }

    public Move ChoseMove(Pokemon playerMon, Field field)
    {

      Dictionary<Move, int> moveScores = new();

      List<Move> movePool = _ActivePkmn[pkmnIndex]._Moves.ToList();

      foreach (var move in movePool)
      {
        if (move._currPP <= 0)
          continue;

        int score = 0;
        bool willKill = Calc.WillMoveKill(_ActivePkmn[pkmnIndex], playerMon, move);
        bool isFaster = Calc.IsFaster(_ActivePkmn[pkmnIndex], playerMon, field);
        bool hasPriority = move._Priority > 0;

        if (Calc.IsHighestDamagingMove(move, _ActivePkmn[pkmnIndex], playerMon, movePool))
        {
          score += _rand.NextDouble() < 0.8 ? 6 : 8;
        }

        if (willKill)
        {
          score += isFaster || hasPriority ? 6 : 3;
          if (MoveProperties.GrantsBoostOnKill(_ActivePkmn[pkmnIndex])) score += 1;
        }

        if (move._CritRate < 16 && TypeEffectiveness.GetEffectiveness(move, playerMon) > 1)
        {
          score += _rand.NextDouble() < 0.5 ? 1 : 0;
        }

        moveScores[move] = score;
      }

      // Check for valid move options
      if (moveScores.Count > 0 && moveScores.Values.Max() > -5)
      {
        int maxScore = moveScores.Values.Max();
        var bestMoves = moveScores.Where(kvp => kvp.Value == maxScore).Select(kvp => kvp.Key).ToList();
        return bestMoves[_rand.Next(bestMoves.Count)];
      }

      //// Check for a switch
      //if (_ActivePkmn[pkmnIndex]._Stats[Stat.HP] > _ActivePkmn[pkmnIndex]._Stats[Stat.HP] / 2)
      //{
      //  var validSwitchOptions = party.Where(p =>
      //      p != _ActivePkmn[pkmnIndex] &&
      //      Calc.IsFaster(p, playerMon, field) &&
      //      !Calc.IsOHKO(playerMon, p)).ToList();

      //  if (validSwitchOptions.Count > 0 && _rand.NextDouble() < 0.5)
      //  {
      //    return validSwitchOptions[_rand.Next(validSwitchOptions.Count)];
      //  }
      //}

      // Default to struggling with whatever is left
      return movePool.FirstOrDefault(m => m._currPP > 0) ?? movePool.First(); // fallback
    }
  }
}
