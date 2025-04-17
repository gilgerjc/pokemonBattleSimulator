using pokemonBattleSimulator.PkmnObjects;
using System.Text.RegularExpressions;

namespace pokemonBattleSimulator
{
  public static class PkmnParser
  {
    private static string Clean(string input)
    {
      return Regex.Replace(input, "[^a-zA-Z0-9]", "");
    }

    public static Pokemon PkmnParse(string block)
    {
      string[] lines = block.Split('\n', StringSplitOptions.RemoveEmptyEntries);

      string nameLine = lines[0];
      string itemLine = lines[1];
      string levelLine = lines.FirstOrDefault(l => l.StartsWith("Level:"));
      string natureLine = lines.FirstOrDefault(l => l.Contains("Nature"));
      string abilityLine = lines.FirstOrDefault(l => l.StartsWith("Ability:"));
      string ivLine = lines.FirstOrDefault(l => l.StartsWith("IVs:"));
      var moveLines = lines.Where(l => l.StartsWith("-")).ToList();

      // Name and Item
      string name = nameLine.Split('@')[0].Trim();
      string itemRaw = nameLine.Contains('@') ? nameLine.Split('@')[1].Trim() : "None";
      string itemClean = Clean(itemRaw);
      Items item = Enum.TryParse<Items>(itemClean, true, out var parsedItem) ? parsedItem : Items.None;

      // Level
      int level = int.Parse(levelLine.Split(':')[1].Trim());

      // Nature
      string natureRaw = natureLine.Replace("Nature", "").Trim();
      Nature nature = Enum.TryParse<Nature>(Clean(natureRaw), true, out var parsedNature) ? parsedNature : Nature.Hardy;

      // Ability
      string abilityRaw = abilityLine.Split(':')[1].Trim();
      Ability ability = Enum.TryParse<Ability>(Clean(abilityRaw), true, out var parsedAbility) ? parsedAbility : Ability.Adaptability;

      // IVs
      Stats ivs = new Stats();
      if (ivLine != null)
      {
        var parts = ivLine.Replace("IVs:", "").Split('/', StringSplitOptions.TrimEntries);
        foreach (var part in parts)
        {
          var pair = part.Split(' ', StringSplitOptions.RemoveEmptyEntries);
          int val = int.Parse(pair[0]);
          string statStr = Clean(pair[1]);
          Stat stat = statStr.ToLower() switch
          {
            "hp" => Stat.HP,
            "atk" => Stat.Att,
            "def" => Stat.Def,
            "spa" => Stat.SpAtt,
            "spd" => Stat.SpDef,
            "spe" => Stat.Spd,
            _ => throw new Exception($"Unknown stat: {statStr}")
          };
          ivs[stat] = val;
        }
      }

      Move[] moves = new Move[4];

      // Add moves
      int i = 0;
      foreach (var moveLine in moveLines)
      {
        string moveRaw = moveLine.Substring(1).Trim(); // remove dash
        string moveClean = Clean(moveRaw);
        if (Enum.TryParse<Moves>(moveClean, true, out var move))
        {
          Move moveObj = MoveDatabase.GetMoveFromCSV(move); // your move lookup
          moves[i] = moveObj;
          i++;
        }
      }

      // Create the Pokémon object
      Pokemon poke = new(name, level, ivs, nature, ability, item, moves);

      return poke;
    }


    public static ITrainer TrainerParse(string input, bool isPlayer)
    {
      string[] sections = input.Split(":\n", 2, StringSplitOptions.None);
      if (sections.Length < 2)
        throw new ArgumentException("Trainer block must contain a name followed by ':' and team data.");

      string trainerName = sections[0].Trim();
      string teamData = sections[1].Trim();

      // Split individual Pokémon blocks
      string[] blocks = teamData.Split("\n\n", StringSplitOptions.RemoveEmptyEntries);

      int max = 6; if (isPlayer) { max = 100; }

      Pokemon?[] party = new Pokemon[max];

      for (int i = 0; i < max; i++)
      {
        if (i < blocks.Length)
        {
          party[i] = PkmnParse(blocks[i]);
        }
        else
        {
          party[i] = null;
        }
      }

      if (isPlayer) { return new Player("Player", party); }
      else { return new RunAndBunAI(trainerName, party); }

    }

    public static Field BattleParse(string input)
    {
      var lines = input.Split('\n').Select(l => l.Trim()).ToList();

      List<String> fieldVariables = new List<string>();

      // Step 1: Parse field conditions
      int index = 0;
      while (index < lines.Count && lines[index].StartsWith("="))
      {
        fieldVariables.Add(lines[index++].Substring(1).ToLower());
      }

      // Step 2: Split enemy and player blocks
      var rest = string.Join('\n', lines.Skip(index));
      var trainerBlocks = rest.Split("***", StringSplitOptions.RemoveEmptyEntries);
      if (trainerBlocks.Length != 2)
        throw new Exception("Battle input must contain two trainer blocks separated by ***");

      var enemyBlock = trainerBlocks[0].Trim();
      var playerBlock = trainerBlocks[1].Trim();

      // Step 3: Generate trainers
      ITrainer AI = TrainerParse(enemyBlock, false);
      ITrainer Player = TrainerParse(playerBlock, true);

      Field field = new Field(AI, Player);

      foreach (string fieldVariable in fieldVariables)
      {

      }

      return field;
    }

  }
}
