namespace pokemonBattleSimulator.PkmnObjects
{
  public enum Stat
  {
    HP,
    Att,
    Def,
    SpAtt,
    SpDef,
    Spd
  }

  public class Stats : Dictionary<Stat, int>
  {
    public Stats()
    {
      foreach (Stat stat in Enum.GetValues(typeof(Stat)))
      {
        this.Add(stat, 0);
      }
    }

    public Stats(int[] statsArr)
    {
      int index = 0;
      foreach (Stat stat in Enum.GetValues(typeof(Stat)))
      {
        this.Add(stat, statsArr[index]);
        index++;
      }
    }

    public void SetStats(int[] statsArr)
    {
      int index = 0;
      foreach (Stat stat in Enum.GetValues(typeof(Stat)))
      {
        this[stat] = statsArr[index];
        index++;
      }
    }
  }
}
