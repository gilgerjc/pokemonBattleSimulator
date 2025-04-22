using pokemonBattleSimulator.PkmnObjects;
using pokemonBattleSimulator.PkmnObjects.PkmnItem;
using pokemonBattleSimulator.PkmnObjects.PkmnMove;
using pokemonBattleSimulator.PkmnObjects.Trainer;
using System.Reflection;
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

      Pokemon[] party = new Pokemon[max];

      for (int i = 0; i < max; i++)
      {
        if (i < blocks.Length)
        {
          party[i] = PkmnParse(blocks[i]);
        }
        else
        {
          Move[] moves = new Move[4]; for (int j = 0; j < moves.Length; j++) { moves[j] = MoveDatabase.GetMoveFromCSV(Moves.None); }
          party[i] = new Pokemon("None", 0, new Stats(), Nature.Gentle, Ability.Adaptability, Items.None, moves);
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
      while (index < lines.Count && lines[index].Contains("="))
      {
        fieldVariables.Add(lines[index++].ToLower().Trim());
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
      PropertyInfo[] properties = field.GetType().GetProperties();

      foreach (string fieldVariable in fieldVariables) // set all variables
      {
        if (fieldVariable.StartsWith("weather="))
        {
          string weather = fieldVariable.Replace("weather=", "");
          field._Weather = Enum.TryParse(weather, true, out Weather parsed) ? parsed : Weather.None;
        }
        else
        {
          foreach (PropertyInfo property in properties)
          {
            string prop = property.Name.Substring(1).ToLower();

            if (property.PropertyType == typeof(bool))
            {
              if (fieldVariable.StartsWith(prop)) { property.SetValue(field, true); }
            }
            else if (property.PropertyType == typeof(Tuple<bool,bool>))
            {
              if (!fieldVariable.StartsWith("="))
              {
                if (fieldVariable.Substring(0, fieldVariable.IndexOf('=')).StartsWith(prop))
                {
                  property.SetValue(field, (true, false));
                  if (fieldVariable.Substring(fieldVariable.IndexOf('=')+1).StartsWith(prop)) { property.SetValue(field, (true, true)); }
                }
              }
              else
              {
                if (fieldVariable.Substring(1).StartsWith(prop))
                {
                  property.SetValue(field, (true, true));
                } 
              }
            }
          }
        }
      }

      return field;
    }

  }
}
