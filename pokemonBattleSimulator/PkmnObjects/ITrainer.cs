namespace pokemonBattleSimulator.PkmnObjects
{
  internal interface ITrainer
  {
    public string _Name { get; set; }
    public Pokemon[] _Party { get; set;}
    public Pokemon[] _EnemyParty { get; set; }

    public int _ActivePkmn { get; set; }

    public static abstract Move ChoseMove();
  }
}
