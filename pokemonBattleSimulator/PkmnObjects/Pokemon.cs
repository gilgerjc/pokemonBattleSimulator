namespace pokemonBattleSimulator.PkmnObjects
{
  public class Pokemon
  {
    public readonly string _Name;
    public readonly int _Level;

    public Stats _BaseStats = new Stats();
    public Stats _IVs = new Stats();
    public Stats _EVs = new Stats();
    public Stats _Stats = new Stats();
    public Stats _StatChanges = new Stats();

    public Nature _Nature;
    public Ability _Ability;
    public PkmnType _Type1;
    public PkmnType _Type2;
    public Items _Item;
    public Status _Status;
    public Move[] _Moves;

    public bool _IsImmune = false;
    public bool _IsSwitchingIn = false;
    public bool _IsSwitchingOut = false;

    public Pokemon(string name, int level, Stats IVs, Nature Nature, Ability ability, Items item, Move[] moves)
    {
      _Name = name;
      _Level = level;
      _IVs = IVs;
      _EVs = new Stats(); // Always 0
      _Nature = Nature;
      _BaseStats = new Stats(); GetBaseStatsFromCsv();
      (_Type1, _Type2) = GetTypingFromCsv();
      _Ability = ability;
      _Item = item;
      _Status = Status.None;
      _Moves = moves;

      CalculateStats();
    }

    /// <summary>
    /// Gets base stats for current pokemon from CSV
    /// </summary>
    /// <returns></returns>
    private void GetBaseStatsFromCsv()
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
            this._BaseStats.SetStats(baseStats);
          }
        }

        // If the Pokémon name was not found
        Console.WriteLine("Pokémon not found.");
        this._BaseStats.SetStats(new int[6]);
      }
      catch (Exception ex)
      {
        Console.WriteLine($"Error reading file: {ex.Message}");
        this._BaseStats.SetStats(new int[6]);
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

    private static (Stat, Stat) GetNatureIndices(Nature nature)
    {
      int lower; int raise;
      lower = (int)nature % 5;
      raise = (int)nature / 5;
      Stat lowerStat = (Stat)Enum.GetValues(typeof(Stat)).GetValue(lower);
      Stat raiseStat = (Stat)Enum.GetValues(typeof(Stat)).GetValue(raise);
      return (lowerStat, raiseStat);
    }

    /// <summary>
    /// Calculates the stats of a pokemon from its base stats, EV/IVs, Nature, and Level
    /// </summary>
    private void CalculateStats()
    {
      double natureMultiplier = 1;
      (Stat lower, Stat raise) = GetNatureIndices(_Nature);

      // HP calc
      _Stats[Stat.HP] = (2 * _BaseStats[Stat.HP] + _IVs[Stat.HP] + _EVs[Stat.HP] / 4) * _Level / 100 + _Level + 10;

      foreach (Stat stat in Enum.GetValues(typeof(Stat)))
      {
        //increase/decrease multiplier depending on nature
        if (raise != lower)
        {
          if (stat == raise) { natureMultiplier = 1.1; }
          if (stat == lower) { natureMultiplier = 0.9; }
        }

        _Stats[stat] = (int)(((2 * _BaseStats[stat] + _IVs[stat] + _EVs[stat] / 4) * _Level / 100 + 5) * natureMultiplier);

        // reset multiplier
        natureMultiplier = 1;
      }
    }
  }
}
