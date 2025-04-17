namespace pokemonBattleSimulator.PkmnObjects
{
  public enum PkmnType
  {
    Normal,
    Fighting,
    Flying,
    Poison,
    Ground,
    Rock,
    Bug,
    Ghost,
    Steel,
    Fire,
    Water,
    Grass,
    Electric,
    Psychic,
    Ice,
    Dragon,
    Dark,
    Fairy,
    None // only used for secondary typing
  }

  public static class TypeEffectiveness
  {
    public static readonly double[,] Chart =
    {
     // Normal  Fight  Fly  Poison Ground Rock  Bug  Ghost Steel Fire Water Grass Elec Psyc Ice  Drgn Dark Fairy
        {  1,      1,    1,   1,     1,     0.5,  1,   0,    0.5, 1,   1,    1,    1,   1,   1,   1,   1,   1  }, // Normal
        {  2,      1,    0.5, 0.5,   1,     2,    0.5, 0,    2,   1,   1,    1,    1,   0.5, 2,   1,   2,   0.5}, // Fighting
        {  1,      2,    1,   1,     1,     0.5,  2,   1,    0.5, 1,   1,    2,    0.5, 1,   1,   1,   1,   1  }, // Flying
        {  1,      1,    1,   0.5,   0.5,   0.5,  1,   0.5,  0,   1,   1,    2,    1,   1,   1,   1,   1,   2  }, // Poison
        {  1,      1,    0,   2,     1,     2,    0.5, 1,    2,   2,   1,    0.5,  2,   1,   1,   1,   1,   1  }, // Ground
        {  1,      0.5,  2,   1,     0.5,   1,    2,   1,    0.5, 2,   1,    1,    1,   1,   2,   1,   1,   1  }, // Rock
        {  1,      0.5,  0.5, 0.5,   1,     1,    1,   0.5,  0.5, 0.5, 1,    2,    1,   2,   1,   1,   1,   0.5}, // Bug
        {  0,      1,    1,   1,     1,     1,    1,   2,    1,   1,   1,    1,    1,   1,   1,   1,   0.5, 1  }, // Ghost
        {  1,      1,    1,   1,     1,     2,    1,   1,    0.5, 0.5, 0.5,  1,    1,   1,   2,   1,   1,   2  }, // Steel
        {  1,      1,    1,   1,     1,     0.5,  2,   1,    2,   0.5, 0.5,  2,    1,   1,   2,   0.5, 1,   1  }, // Fire
        {  1,      1,    1,   1,     2,     2,    1,   1,    1,   2,   0.5,  0.5,  1,   1,   1,   0.5, 1,   1  }, // Water
        {  1,      1,    0.5, 0.5,   2,     1,    0.5, 1,    0.5, 0.5, 2,    0.5,  1,   1,   1,   0.5, 1,   1  }, // Grass
        {  1,      1,    2,   1,     0,     1,    1,   1,    0.5, 1,   2,    1,    0.5, 1,   1,   0.5, 1,   1  }, // Electric
        {  1,      2,    1,   2,     1,     1,    1,   1,    0,   1,   1,    1,    1,   0.5, 1,   1,   0,   1  }, // Psychic
        {  1,      1,    2,   1,     2,     1,    1,   1,    0.5, 0.5, 0.5,  2,    1,   1,   0.5, 2,   1,   1  }, // Ice
        {  1,      1,    1,   1,     1,     1,    1,   1,    0.5, 1,   1,    1,    1,   1,   1,   2,   1,   0  }, // Dragon
        {  1,      0.5,  1,   1,     1,     1,    1,   2,    1,   1,   1,    1,    1,   2,   1,   1,   0.5, 0.5}, // Dark
        {  1,      2,    1,   0.5,   1,     1,    1,   1,    0.5, 0.5, 1,    1,    1,   1,   1,   2,   2,   1  }  // Fairy
    };

    public static double GetEffectiveness(Move move, Pokemon Target)
    {
      double effectiveness = 1.0;

      int attIndex = Array.IndexOf(Enum.GetValues(typeof(PkmnType)), move._Typing);
      int defIndex = Array.IndexOf(Enum.GetValues(typeof(PkmnType)), Target._Type1);

      if (Target._Type1 != PkmnType.None) { effectiveness *= Chart[defIndex, attIndex]; }

      defIndex = Array.IndexOf(Enum.GetValues(typeof(PkmnType)), Target._Type2); // check both types

      if (Target._Type1 != PkmnType.None) { effectiveness *= Chart[defIndex, attIndex]; }


      return effectiveness;
    }
  }
}
