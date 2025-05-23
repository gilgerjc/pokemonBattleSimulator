﻿using pokemonBattleSimulator.PkmnObjects;
using pokemonBattleSimulator.PkmnObjects.PkmnMove;

namespace pokemonBattleSimulator
{
  public static class Calc
  {
    // Your existing damage function
    public static int DamageRoll(Pokemon user, Pokemon target, Move move, bool crit = false)
    {
      int att = 0;
      int def = 0;
      double multiplier = 1.0;

      Func<int, double> GetStatChangeMultiplier = x => (x > 0) ? (2 + x) / 2.0 : 2 / (2 - x);

      if (move._MoveType == MoveType.Physical)
      {
        att = user._Stats[Stat.Att]; def = target._Stats[Stat.Def];
        multiplier *= GetStatChangeMultiplier(user._StatChanges[Stat.Att]);
        multiplier *= GetStatChangeMultiplier(user._StatChanges[Stat.Def]);
      }
      else if (move._MoveType == MoveType.Special)
      {
        att = user._Stats[Stat.SpAtt]; def = target._Stats[Stat.SpDef];
        multiplier *= GetStatChangeMultiplier(user._StatChanges[Stat.SpAtt]);
        multiplier *= GetStatChangeMultiplier(user._StatChanges[Stat.SpDef]);
      }
      else { return 0; } // status move does 0 damage

      if (crit)
      {
        multiplier = 1;
        if (move._Random.Next(move._CritRate) == 0) { multiplier *= 1.5; }
      }

      if (move._IsMultitarget) { multiplier *= 0.75; }

      multiplier *= move._Random.Next(85, 101) / 100.0;

      if (move._Typing == user._Type1 || move._Typing == user._Type2)
      {
        multiplier *= 1.5;
      }

      if (target._Type1 != PkmnType.None)
      {
        multiplier *= TypeEffectiveness.Chart[(int)move._Typing, (int)target._Type1];
      }

      if (target._Type2 != PkmnType.None)
      {
        multiplier *= TypeEffectiveness.Chart[(int)move._Typing, (int)target._Type2];
      }

      int damageRoll = (int)(((((((2 * user._Level) / 5) + 2) * move._BasePower * (att / def)) / 50) + 2) * multiplier);

      return damageRoll;
    }

    public static bool WillMoveKill(Pokemon user, Pokemon target, Move move)
    {
      int damage = DamageRoll(user, target, move);
      return damage >= target._Stats[Stat.HP];
    }

    public static bool IsOHKO(Pokemon attacker, Pokemon target)
    {
      foreach (var move in attacker._Moves)
      {
        if (WillMoveKill(attacker, target, move))
          return true;
      }
      return false;
    }

    public static bool IsHighestDamagingMove(Move moveToCheck, Pokemon user, Pokemon target, List<Move> movePool)
    {
      int maxDamage = (int)(user._Moves?
          .Where(m => m != null && m._currPP > 0)
          .Select(m => DamageRoll(user, target, m))
          .DefaultIfEmpty(0) // fallback if no valid moves
          .Max());

      int moveDamage = DamageRoll(user, target, moveToCheck);

      return moveDamage == maxDamage;
    }

    internal static bool IsFaster(Pokemon aiMon, Pokemon playerMon, Field field)
    {
      double aiSpeed = GetEffectiveSpeed(aiMon, field, isEnemy: true);
      double playerSpeed = GetEffectiveSpeed(playerMon, field, isEnemy: false);

      return aiSpeed > playerSpeed;
    }

    private static double GetEffectiveSpeed(Pokemon pkmn, Field field, bool isEnemy)
    {
      int baseSpeed = pkmn._Stats[Stat.Spd];
      int stage = pkmn._StatChanges[Stat.Spd];

      // Apply stat stage multiplier
      double stageMultiplier = stage >= 0 ? (2.0 + stage) / 2.0 : 2.0 / (2.0 - stage);
      double speed = baseSpeed * stageMultiplier;

      // Apply status penalties (e.g., Paralysis cuts speed)
      if (pkmn._Status == Status.Paralyzed)
        speed *= 0.5;

      // Apply Tailwind
      if (isEnemy && field._Tailwind.Item2)
        speed *= 2;
      if (!isEnemy && field._Tailwind.Item1)
        speed *= 2;

      // Extend here for: Chlorophyll, Unburden, Slush Rush, etc.
      return speed;
    }
  }

}
