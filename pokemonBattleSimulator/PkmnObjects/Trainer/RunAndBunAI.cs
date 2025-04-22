using pokemonBattleSimulator.PkmnObjects.PkmnMove;
using System.Data.SqlTypes;
using System.Runtime.CompilerServices;
using static System.Formats.Asn1.AsnWriter;

namespace pokemonBattleSimulator.PkmnObjects.Trainer
{
  public class RunAndBunAI : ITrainer
  {
    public string _Name { get; set; }
    public Pokemon[] _Party { get; set; }
    public Pokemon[] _ActivePkmn { get; set; } // lead pokemon


    private int pkmnIndex = 0; // used for move selection, only changed in double battles

    public RunAndBunAI(string name, Pokemon[] party)
    {
      _Name = name;
      _Party = party;
      _ActivePkmn = [party[0], party[1]];
    }

    private static List<(int, double)> AddProbabilityBranch(List<(int, double)> scoreProb, double rate, int score1, int score2)
    {
      int initCount = scoreProb.Count;
      for (int i = 0; i < initCount; i++)
      {
        var (score, prob) = scoreProb[i];
        scoreProb.Add((score, prob)); // copy each entry
      }
      for (int i = 0; i < initCount; i++) // update roll 1 (happpens %rate)
      {
        var (score, prob) = scoreProb[i];
        scoreProb[i] = (score + score1, prob * rate);
      }
      for (int i = initCount; i<scoreProb.Count; i++) //update roll 2 (happesn %100 - rate)
      {
        var (score, prob) = scoreProb[i];
        scoreProb[i] = (score + score2, prob * (1.0-rate));
      }

      return scoreProb;
    }

    public Dictionary<Move, List<(int, double)>> GetMoveScoreProbabilities(Pokemon playerMon, Field field)
    {

      Dictionary<Move, List<(int,double)>> moveScores = new();

      List<Move> movePool = _ActivePkmn[pkmnIndex]._Moves.ToList();

      foreach (Move move in movePool)
      {
        if (move != null)
        {

          List<(int, double)> scoreProbabilities = [(0, 1.0)]; // initial probability

          if (move._currPP <= 0)
            continue;

          bool willKill = Calc.WillMoveKill(_ActivePkmn[pkmnIndex], playerMon, move);
          bool isFaster = Calc.IsFaster(_ActivePkmn[pkmnIndex], playerMon, field);
          bool hasPriority = move._Priority > 0;

          if (Calc.IsHighestDamagingMove(move, _ActivePkmn[pkmnIndex], playerMon, movePool))
          {
            scoreProbabilities = AddProbabilityBranch(scoreProbabilities, .8, 6, 8);
          }

          if (willKill)
          {

            if (isFaster || hasPriority)
            {
              for (int i = 0; i < scoreProbabilities.Count; i++)
              {
                var (score, prob) = scoreProbabilities[i];
                scoreProbabilities[i] = (score + 6, prob);
              }
            }
            else
            {
              for (int i = 0; i < scoreProbabilities.Count; i++)
              {
                var (score, prob) = scoreProbabilities[i];
                scoreProbabilities[i] = (score + 3, prob);
              }
            }

            if (MoveProperties.GrantsBoostOnKill(_ActivePkmn[pkmnIndex]))
            {
              for (int i = 0; i < scoreProbabilities.Count; i++)
              {
                var (score, prob) = scoreProbabilities[i];
                scoreProbabilities[i] = (score + 1, prob);
              }
            }
          }

          if (move._CritRate < 16 && TypeEffectiveness.GetEffectiveness(move, playerMon) > 1)
          {
            scoreProbabilities = AddProbabilityBranch(scoreProbabilities, .5, 0, 1);
          }

          moveScores[move] = scoreProbabilities;
        }
      }


      //// Check for valid move options
      //if (moveScores.Count > 0 && moveScores.Values.Max() > -5)
      //{
      //  int maxScore = moveScores.Values.Max();
      //  var bestMoves = moveScores.Where(kvp => kvp.Value == maxScore).Select(kvp => kvp.Key).ToList();
      //  return bestMoves[_rand.Next(bestMoves.Count)];
      //}

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
      return moveScores;
    }


    public Dictionary<Move, double> GetMoveProbabilities(Pokemon playerMon, Field field)
    {
      var result = new Dictionary<Move, double>();

      var moveDistributions = GetMoveScoreProbabilities(playerMon, field);

      // Create a flat list of moves
      var moves = moveDistributions.Keys.ToList();

      // Build a list of all probability entries per move
      var moveOptions = moves
          .Select(move => moveDistributions[move].Select(entry => (move, entry.Item1, entry.Item2)).ToList())
          .ToList();

      // Generate all combinations of move scores and their joint probabilities
      IEnumerable<List<(Move move, int score, double prob)>> AllCombinations(List<List<(Move move, int score, double prob)>> lists)
      {
        IEnumerable<List<(Move move, int score, double prob)>> seed = new[] { new List<(Move, int, double)>() };
        foreach (var list in lists)
        {
          seed = from combination in seed
                 from item in list
                 select new List<(Move, int, double)>(combination) { item };
        }
        return seed;
      }

      var allScoreCombinations = AllCombinations(moveOptions);

      foreach (var combo in allScoreCombinations)
      {
        double jointProb = combo.Aggregate(1.0, (acc, val) => acc * val.prob);

        int maxScore = combo.Max(x => x.score);
        var topMoves = combo.Where(x => x.score == maxScore).Select(x => x.move).ToList();

        double probPerMove = jointProb / topMoves.Count;

        foreach (var move in topMoves)
        {
          if (!result.ContainsKey(move))
            result[move] = 0;
          result[move] += probPerMove;
        }
      }

      return result;
    }

    public Move ChoseMove(Pokemon playerMon, Field field)
    {
      throw new NotImplementedException();
    }
  }
}
