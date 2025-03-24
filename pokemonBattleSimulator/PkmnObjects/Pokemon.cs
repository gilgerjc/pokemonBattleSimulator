namespace pokemonBattleSimulator.PkmnObjects
{
  public class Pokemon
  {
    public readonly string _Name;
    public readonly int _Level;
    public readonly int[] _BaseStats;
    public readonly int[] _IVs;
    public readonly int[] _EVs;

    public Nature _Nature;
    public Ability _Ability;
    public PkmnType _Type1;
    public PkmnType _Type2;
    public Items _Item;

    public int[] _Stats = new int[6];  // HP - ATT - DEF - Sp. ATT - Sp. DEF - SPD

    public Pokemon(string name, int level, int[] IVs, int[] EVs, Nature Nature, Ability ability, Items item)
    {
      _Name = name;
      _Level = level;
      _IVs = IVs;
      _EVs = EVs;
      _Nature = Nature;
      _BaseStats = GetBaseStatsFromCsv();
      (_Type1, _Type2) = GetTypingFromCsv();
      _Ability = ability;
      _Item = item;

      CalculateStats();
    }

    /// <summary>
    /// Gets base stats for current pokemon from CSV
    /// </summary>
    /// <returns></returns>
    private int[] GetBaseStatsFromCsv()
    {
      string filePath = "pokemon_stats.csv"; // Change this to the path of your CSV file
      List<int[]> baseStatsList = new List<int[]>();

      try
      {
        // Read the CSV file line by line
        var lines = File.ReadAllLines(filePath);

        foreach (var line in lines.Skip(1)) // Skip the header row
        {
          var columns = line.Split(',');
          string name = columns[0].Trim();

          // If the name matches, parse the base stats
          if (name.Equals(_Name, StringComparison.OrdinalIgnoreCase))
          {
            // Get the base stats from the appropriate columns (index 2-7)
            int[] baseStats = new int[6];
            for (int i = 0; i < 6; i++)
            {
              baseStats[i] = int.Parse(columns[i + 1]); // Base stats start from column 2
            }
            return baseStats;
          }
        }

        // If the Pokémon name was not found
        Console.WriteLine("Pokémon not found.");
        return new int[6];
      }
      catch (Exception ex)
      {
        Console.WriteLine($"Error reading file: {ex.Message}");
        return new int[6];
      }
    }

    /// <summary>
    /// Gets the typing of a pokemon
    /// </summary>
    /// <returns></returns>
    private (PkmnType, PkmnType) GetTypingFromCsv()
    {
      string filePath = "path_to_your_gen1_pokemon_typing.csv"; // Replace with the path to your CSV file
      Dictionary<string, (PkmnType, PkmnType)> pokemonTypes = new Dictionary<string, (PkmnType, PkmnType)>();

      try
      {
        // Read the CSV file line by line
        var lines = File.ReadAllLines(filePath);

        foreach (var line in lines.Skip(1)) // Skip the header row
        {
          var columns = line.Split(',');

          // Assuming Pokémon name is in the 1st column, Type 1 in the 2nd, and Type 2 in the 3rd
          string name = columns[0].Trim();
          PkmnType type1 = (PkmnType)Enum.Parse(typeof(PkmnType), columns[1].Trim(), true);
          PkmnType type2 = columns.Length > 2 && !string.IsNullOrEmpty(columns[2].Trim())
                            ? (PkmnType)Enum.Parse(typeof(PkmnType), columns[2].Trim(), true)
                            : PkmnType.None;

          // Store the typing in the dictionary
          pokemonTypes[name] = (type1, type2);
        }

        // If the Pokémon name exists in the dictionary, return its typing
        if (pokemonTypes.ContainsKey(_Name))
        {
          return pokemonTypes[_Name];
        }

        // If the Pokémon is not found, return (None, None)
        Console.WriteLine("Pokémon not found.");
        return (PkmnType.None, PkmnType.None);
      }
      catch (Exception ex)
      {
        Console.WriteLine($"Error reading file: {ex.Message}");
        return (PkmnType.None, PkmnType.None);
      }
    }

    private static (int, int) GetNatureIndices(Nature nature)
    {
      int lower; int raise;
      lower = (int)nature % 5;
      raise = (int)nature / 5;

      return (lower, raise);
    }

    /// <summary>
    /// Calculates the stats of a pokemon from its base stats, EV/IVs, Nature, and Level
    /// </summary>
    private void CalculateStats()
    {
      double natureMultiplier = 1;
      (int lower, int raise) = GetNatureIndices(_Nature);

      // HP calc
      _Stats[0] = (2 * _BaseStats[0] + _IVs[0] + _EVs[0] / 4) * _Level / 100 + _Level + 10;

      for (int i = 1; i < _Stats.Count(); i++)
      {
        //increase/decrease multiplier depending on nature
        if (i == raise) { natureMultiplier = 1.1; }
        if (i == lower) { natureMultiplier = 0.9; }

        _Stats[i] = (int)(((2 * _BaseStats[i] + _IVs[i] + _EVs[i] / 4) * _Level / 100 + 5) * natureMultiplier);

        // reset multiplier
        natureMultiplier = 1;
      }
    }
  }
}
