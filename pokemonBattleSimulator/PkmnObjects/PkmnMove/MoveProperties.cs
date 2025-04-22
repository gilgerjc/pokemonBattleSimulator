namespace pokemonBattleSimulator.PkmnObjects.PkmnMove
{
  public static class MoveProperties
  {
    private static readonly HashSet<Moves> PriorityMoves = new()
    {
        Moves.QuickAttack,
        Moves.MachPunch,
        Moves.VacuumWave,
        Moves.ExtremeSpeed,
        Moves.IceShard,
        Moves.AquaJet,
        Moves.BulletPunch,
        Moves.ShadowSneak,
        Moves.SuckerPunch,
        Moves.FakeOut
    };

    private static readonly HashSet<Ability> KOBoostAbilities = new()
    {
        Ability.Moxie,
        Ability.BeastBoost,
        Ability.ChillingNeigh,
        Ability.GrimNeigh
    };

    private static readonly HashSet<Moves> HighCritMoves = new()
    {
        Moves.NightSlash, Moves.Slash, Moves.Crabhammer, Moves.AirCutter,
        Moves.CrossChop, Moves.PsychoCut, Moves.LeafBlade, Moves.DrillRun,
        Moves.StoneEdge, Moves.SkyAttack, Moves.SolarBlade
    };

    private static readonly HashSet<Moves> MovesNeverConsideredHighestDamage = new()
    {
        Moves.Explosion, Moves.SelfDestruct, Moves.MistyExplosion,
        Moves.RelicSong, Moves.Rollout, Moves.MeteorBeam, Moves.FutureSight,
        Moves.Whirlpool, Moves.FireSpin, Moves.SandTomb, Moves.MagmaStorm, Moves.Infestation
    };

    private static readonly HashSet<Moves> SetupMoves = new()
    {
        Moves.SwordsDance, Moves.DragonDance, Moves.NastyPlot, Moves.Calmmind,
        Moves.BulkUp, Moves.IronDefense, Moves.Agility, Moves.ShellSmash, Moves.Coil,
        Moves.Reflect, Moves.LightScreen, Moves.AcidArmor, Moves.Amnesia, Moves.HoneClaws,
        Moves.TailGlow, Moves.Meditate, Moves.WorkUp, Moves.NoRetreat
    };

    private static readonly HashSet<Moves> RecoveryMoves = new()
    {
        Moves.Recover, Moves.SlackOff, Moves.Roost, Moves.SoftBoiled,
        Moves.HealOrder, Moves.Moonlight, Moves.Synthesis, Moves.MorningSun,
        Moves.Rest, Moves.StrengthSap
    };

    private static readonly HashSet<Moves> HazardMoves = new()
    {
        Moves.StealthRock, Moves.Spikes, Moves.ToxicSpikes, Moves.StickyWeb
    };

    private static readonly HashSet<Moves> UtilityMoves = new()
    {
        Moves.Protect, Moves.KingsShield, Moves.Encore, Moves.Taunt,
        Moves.BatonPass, Moves.Switcheroo, Moves.Trick, Moves.Substitute,
        Moves.Detect, Moves.Imprison, Moves.RolePlay, Moves.Coaching,
        Moves.DestinyBond, Moves.Memento, Moves.Yawn
    };

    private static readonly HashSet<Moves> StatusInflictingMoves = new()
    {
        Moves.WillOWisp, Moves.ThunderWave, Moves.Toxic, Moves.StunSpore, Moves.Glare,
        Moves.Nuzzle, Moves.GrassWhistle, Moves.Sing, Moves.Hypnosis, Moves.SleepPowder,
        Moves.DarkVoid, Moves.LovelyKiss
    };

    public static bool HasPriority(Move move) => PriorityMoves.Contains(move._Move);

    public static bool GrantsBoostOnKill(Pokemon user) => KOBoostAbilities.Contains(user._Ability);

    public static bool HasHighCritChance(Move move) => HighCritMoves.Contains(move._Move);

    public static bool IsSpecialCaseMove(Move move) => MovesNeverConsideredHighestDamage.Contains(move._Move);

    public static bool IsSetupMove(Move move) => SetupMoves.Contains(move._Move);

    public static bool IsRecoveryMove(Move move) => RecoveryMoves.Contains(move._Move);

    public static bool IsHazardMove(Move move) => HazardMoves.Contains(move._Move);

    public static bool IsUtilityMove(Move move) => UtilityMoves.Contains(move._Move);

    public static bool IsStatusInflictor(Move move) => StatusInflictingMoves.Contains(move._Move);

    public static bool IsUseless(Move move, Field field, Pokemon aiMon, Pokemon playerMon)
    {
      // Example: Don't use hazards if already present
      if (move._Move == Moves.StealthRock && field._StealthRock.Item2)
        return true;
      if (move._Move == Moves.Spikes && field._SpikeLayers.Item2 >= 3)
        return true;
      if (move._Move == Moves.ToxicSpikes && field._ToxicSpikeLayers.Item2 >= 2)
        return true;

      // Don’t status if already statused
      if (IsStatusInflictor(move) && playerMon._Status != Status.None)
        return true;

      return false;
    }

    // Optional: General-purpose tag system
    public static string GetMoveTag(Move move)
    {
      if (IsSetupMove(move)) return "Setup";
      if (IsRecoveryMove(move)) return "Recovery";
      if (IsHazardMove(move)) return "Hazard";
      if (IsUtilityMove(move)) return "Utility";
      if (IsStatusInflictor(move)) return "Status";
      if (HasPriority(move)) return "Priority";
      if (IsSpecialCaseMove(move)) return "Special";
      return "Standard";
    }

    // Specific case: Reduce Sucker Punch score if used last turn
    public static int GetSuckerPunchPenalty(bool usedLastTurn)
    {
      return usedLastTurn && new Random().NextDouble() < 0.5 ? -20 : 0;
    }
  }
}
