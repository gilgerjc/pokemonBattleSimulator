namespace pokemonBattleSimulator.PkmnObjects.PkmnMove
{
  public static class MoveDatabase
  {
    private static Dictionary<Moves, string[]> moveCsvData = new();

    public static void LoadMoveCsv(string csvPath)
    {
      var lines = File.ReadAllLines(csvPath);
      foreach (var line in lines.Skip(1)) // skip header
      {
        var parts = line.Split(',', StringSplitOptions.None);

        if (Enum.TryParse(parts[0].Trim().Replace(" ", ""), true, out Moves move))
        {
          moveCsvData[move] = parts;
        }
      }
    }

    public static Move GetMoveFromCSV(Moves move)
    {
      if (!moveCsvData.TryGetValue(move, out var parts))
        return new Move(Moves.None, 0, 0, MoveType.Status, PkmnType.None, 0);

      string name = parts[0].Trim();
      int basePower = int.TryParse(parts[1], out var bp) ? bp : 0;
      int accuracy = int.TryParse(parts[2], out var acc) ? acc : 100;
      string moveTypeStr = parts[3].Trim();
      string typingStr = parts[4].Trim();

      if (!Enum.TryParse(moveTypeStr, true, out MoveType moveType))
        throw new Exception($"Invalid move type for {name}: {moveTypeStr}");

      if (!Enum.TryParse(typingStr, true, out PkmnType typing))
        throw new Exception($"Invalid move typing for {name}: {typingStr}");

      var moveInstance = new Move(
          move,
          basePower,
          accuracy,
          moveType,
          typing,
          maxPP: 10 // default, you can enhance this later
      );

      return moveInstance;
    }
  }

}
