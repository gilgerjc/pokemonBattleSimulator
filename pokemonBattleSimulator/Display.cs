using pokemonBattleSimulator.PkmnObjects;
using pokemonBattleSimulator.PkmnObjects.PkmnMove;

namespace pokemonBattleSimulator
{
  public static class Display
  {

    public static void ShowField(Field field)
    {

    }

    public static void ShowPokemon(Pokemon pkmn)
    {
      Console.WriteLine($"=== {pkmn._Name}  Lv{pkmn._Level} ===");
      Console.WriteLine($"Type: {pkmn._Type1}" + (pkmn._Type2 != PkmnType.None ? $"/{pkmn._Type2}" : ""));
      Console.WriteLine($"Ability: {pkmn._Ability}");
      Console.WriteLine($"Item: {pkmn._Item}");
      Console.WriteLine($"Status: {pkmn._Status}\n");

      // HP Bar
      ShowHPBar(pkmn);

      // Stat changes (buffs/debuffs)
      Console.WriteLine("Stat Changes:");
      foreach (Stat stat in Enum.GetValues(typeof(Stat)))
      {
        int change = pkmn._StatChanges[stat];
        string arrow = GetStatArrow(change);
        Console.WriteLine($"  {stat}: {pkmn._Stats[stat],-6} {arrow}");
      }

      // Move list with PP
      Console.WriteLine("\nMoves:");
      foreach (Move move in pkmn._Moves)
      {
        if (move != null)
        {
          Console.WriteLine($"  - {move._Move,-15} [{move._currPP}/{move._MaxPP}]");
        }
      }

      Console.WriteLine();
    }

    private static void ShowHPBar(Pokemon pkmn)
    {
      int maxHP = pkmn._Stats[Stat.HP];
      int currHP = Math.Max(0, pkmn._Stats[Stat.HP]); // Clamp to 0
      double percent = currHP / (double)maxHP;

      int totalBars = 20;
      int filled = (int)(percent * totalBars);
      int empty = totalBars - filled;

      ConsoleColor originalColor = Console.ForegroundColor;

      if (percent > 0.5)
        Console.ForegroundColor = ConsoleColor.Green;
      else if (percent > 0.2)
        Console.ForegroundColor = ConsoleColor.Yellow;
      else
        Console.ForegroundColor = ConsoleColor.Red;

      Console.Write("[");
      Console.Write(new string('█', filled));
      Console.Write(new string(' ', empty));
      Console.WriteLine($"]  {currHP}/{maxHP} HP");
      Console.ForegroundColor = originalColor;
    }

    private static string GetStatArrow(int stage)
    {
      if (stage > 0) return new string('▲', stage);
      if (stage < 0) return new string('▼', -stage);
      return "-";
    }
  }
}
