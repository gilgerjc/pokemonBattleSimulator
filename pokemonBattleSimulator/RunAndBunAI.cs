using pokemonBattleSimulator.PkmnObjects;

namespace pokemonBattleSimulator
{
  public class RunAndBunAI : ITrainer
  {
    public string _Name { get; set; }
    public Pokemon[] _Party { get; set; }
    public Pokemon[] _EnemyParty { get; set; }
    public int _ActivePkmn { get; set; }

    public class AIController
    {
      private static Random _rand = new Random();

      public static Move ChooseMove(Pokemon aiMon, Pokemon playerMon, List<Move> movePool, List<Pokemon> party, Field field)
      {
        Dictionary<Move, int> moveScores = new();

        foreach (var move in movePool)
        {
          if (move._currPP <= 0)
            continue;

          int score = 0;
          bool willKill = DamageCalc.WillMoveKill(aiMon, playerMon, move);
          bool isFaster = SpeedCalc.IsFaster(aiMon, playerMon, field);
          bool hasPriority = move._Priority > 0;

          if (DamageCalc.IsHighestDamagingMove(move, aiMon, playerMon, movePool))
          {
            score += _rand.NextDouble() < 0.8 ? 6 : 8;
          }

          if (willKill)
          {
            score += isFaster || hasPriority ? 6 : 3;
            if (MoveProperties.GrantsBoostOnKill(aiMon)) score += 1;
          }

          if (MoveProperties.HasHighCritChance(move) && TypeChart.IsSuperEffective(move._Typing, playerMon._Type1, playerMon._Type2))
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

        // Check for a switch
        if (aiMon._Stats[Stat.HP] > aiMon._Stats[Stat.HP] / 2)
        {
          var validSwitchOptions = party.Where(p =>
              p != aiMon &&
              SpeedCalc.IsFaster(p, playerMon, field) &&
              !DamageCalc.IsOHKO(playerMon, p)).ToList();

          if (validSwitchOptions.Count > 0 && _rand.NextDouble() < 0.5)
          {
            return validSwitchOptions[_rand.Next(validSwitchOptions.Count)];
          }
        }

        // Default to struggling with whatever is left
        return movePool.FirstOrDefault(m => m._currPP > 0) ?? movePool.First(); // fallback
      }
    }

  }
}
