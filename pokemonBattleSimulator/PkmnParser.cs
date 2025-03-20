using pokemonBattleSimulator.PkmnObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pokemonBattleSimulator
{
  public static class PkmnParser
  {
    public static List<Pokemon> ParsePokemonEntries(string input)
    {
      List<Pokemon> pokemonList = new();

      // Split entries by double newlines or multiple spaces
      string[] entries = input.Split(new string[] { "\n\n", "\r\n\r\n", "\n \n", "\r\n \r\n" }, StringSplitOptions.RemoveEmptyEntries);

      foreach (string entry in entries)
      {
        string[] lines = entry.Split('\n', StringSplitOptions.RemoveEmptyEntries)
                              .Select(line => line.Trim())
                              .ToArray();

        if (lines.Length < 6)
          throw new ArgumentException("Invalid Pokémon format!");

        // Extract Pokémon Name & Item
        string[] nameAndItem = lines[0].Split('@', StringSplitOptions.TrimEntries);
        string name = nameAndItem[0];
        Item item = nameAndItem.Length > 1 && Enum.TryParse(nameAndItem[1].Replace(" ", ""), out Item parsedItem) ? parsedItem : Item.None;

        // Extract Level
        int level = int.Parse(lines[1].Split(':')[1].Trim());

        // Extract Nature
        Nature nature = Enum.TryParse(lines[2].Split(' ')[0], out Nature parsedNature) ? parsedNature : throw new ArgumentException("Invalid Nature!");

        // Extract Ability
        Ability ability = Enum.TryParse(lines[3].Split(':')[1].Trim().Replace(" ", ""), out Ability parsedAbility) ? parsedAbility : throw new ArgumentException("Invalid Ability!");

        // Extract Moves
        Moves[] moves = lines.Skip(4)
                             .Take(4)
                             .Select(line => line.TrimStart('-').Trim())
                             .Select(move => Enum.TryParse(move.Replace(" ", ""), out Moves parsedMove) ? parsedMove : Moves.None)
                             .ToArray();

        // Create the Pokemon object and add it to the list
        pokemonList.Add(new Pokemon(name, level, nature, ability, item, moves));
      }

      return pokemonList;
    }
  }
}
