using System.Reflection;

namespace pokemonBattleSimulator.PkmnObjects
{

  public enum MoveType
  {
    Physical,
    Special,
    Status
  }

  public enum Moves
  {
    Absorb,
    Acid,
    AcidArmor,
    Agility,
    Amnesia,
    AuroraBeam,
    Barrier,
    Bide,
    Bind,
    Bite,
    Blizzard,
    BodySlam,
    BoneClub,
    Bonemerang,
    Bubble,
    BubbleBeam,
    Clamp,
    CometPunch,
    ConfuseRay,
    Confusion,
    Constrict,
    Conversion,
    Counter,
    Crabhammer,
    Cut,
    DefenseCurl,
    Dig,
    Disable,
    DizzyPunch,
    DoubleKick,
    DoubleTeam,
    DoubleEdge,
    DoubleSlap,
    DragonRage,
    DreamEater,
    DrillPeck,
    Earthquake,
    EggBomb,
    Ember,
    Explosion,
    FireBlast,
    FirePunch,
    FireSpin,
    Fissure,
    Flamethrower,
    Flash,
    Fly,
    FocusEnergy,
    FuryAttack,
    FurySwipes,
    Glare,
    Growl,
    Growth,
    Guillotine,
    Gust,
    Harden,
    Haze,
    Headbutt,
    HighJumpKick,
    HornAttack,
    HornDrill,
    HydroPump,
    HyperBeam,
    HyperFang,
    Hypnosis,
    IceBeam,
    IcePunch,
    JumpKick,
    KarateChop,
    Kinesis,
    LeechLife,
    LeechSeed,
    Leer,
    Lick,
    LightScreen,
    LovelyKiss,
    LowKick,
    Meditate,
    MegaDrain,
    MegaKick,
    MegaPunch,
    Metronome,
    Mimic,
    Minimize,
    MirrorMove,
    Mist,
    NightShade,
    PayDay,
    Peck,
    PetalDance,
    PinMissile,
    PoisonGas,
    PoisonPowder,
    PoisonSting,
    Pound,
    Psybeam,
    Psychic,
    Psywave,
    QuickAttack,
    Rage,
    RazorLeaf,
    RazorWind,
    Recover,
    Reflect,
    Rest,
    Roar,
    RockSlide,
    RockThrow,
    RollingKick,
    SandAttack,
    Scratch,
    Screech,
    SeismicToss,
    SelfDestruct,
    Sharpen,
    Sing,
    SkullBash,
    SkyAttack,
    Slam,
    Slash,
    SleepPowder,
    Sludge,
    Smog,
    Smokescreen,
    SoftBoiled,
    SolarBeam,
    SonicBoom,
    SpikeCannon,
    Splash,
    Spore,
    Stomp,
    Strength,
    StringShot,
    Struggle,
    StunSpore,
    Submission,
    Substitute,
    SuperFang,
    Supersonic,
    Surf,
    Swift,
    SwordsDance,
    Tackle,
    TailWhip,
    TakeDown,
    Teleport,
    Thunder,
    ThunderPunch,
    ThunderWave,
    Thunderbolt,
    ThunderShock,
    Toxic,
    Transform,
    TriAttack,
    Twineedle,
    ViceGrip,
    VineWhip,
    WaterGun,
    Waterfall,
    Whirlwind,
    WingAttack,
    Withdraw,
    Wrap,
    WillOWisp,
    StealthRock,
    MistyExplosion,
    FutureSight,
    MeteorBeam,
    Rollout,
    RelicSong,
    NightSlash,
    AirCutter,
    CrossChop,
    PsychoCut,
    LeafBlade,
    DrillRun,
    StoneEdge,
    SolarBlade,
    MachPunch,
    VacuumWave,
    ExtremeSpeed,
    IceShard,
    AquaJet,
    BulletPunch,
    ShadowSneak,
    SuckerPunch,
    FakeOut,
    Whirlpool,
    SandTomb,
    MagmaStorm,
    Infestation,
    DragonDance,
    NastyPlot,
    Calmmind,
    NoRetreat,
    BulkUp,
    IronDefense,
    ShellSmash,
    Coil,
    HoneClaws,
    WorkUp,
    TailGlow,
    SlackOff,
    Roost,
    HealOrder,
    Moonlight,
    Synthesis,
    MorningSun,
    StrengthSap,
    Spikes,
    ToxicSpikes,
    StickyWeb,
    Protect,
    KingsShield,
    Encore,
    Taunt,
    BatonPass,
    Switcheroo,
    Trick,
    Coaching,
    RolePlay,
    Imprison,
    Detect,
    DestinyBond,
    Memento,
    Yawn,
    Nuzzle,
    GrassWhistle,
    DarkVoid
  }

  public class Move
  {
    public readonly MoveType _MoveType;
    public readonly int _BasePower;
    public readonly int _Accuracy;
    public readonly PkmnType _Typing;
    public readonly int _MaxPP;
    public readonly Moves _Move;
    public readonly int _Priority;
    public readonly int _CritRate;
    public Action _MoveAction;

    public int _currPP;


    public bool _IsMultitarget;

    public Random _Random = new Random();

    public Move(Moves move, int basePower, int accuracy, MoveType moveType, PkmnType typing, int maxPP, int critRate = 16)
    {
      this._Move = move;
      this._BasePower = basePower;
      this._Accuracy = accuracy;
      this._MoveType = moveType;
      this._Typing = typing;
      this._MaxPP = maxPP;
      this._currPP = this._MaxPP;
      this._MoveAction = MoveFunctions.moveDictionary[move];
      this._CritRate = critRate;

      // flags
      this._IsMultitarget = false;
    }
  }

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
      return usedLastTurn && (new Random().NextDouble() < 0.5) ? -20 : 0;
    }
  }

  public static class MoveFunctions
  {
    public static Dictionary<Moves, Action> moveDictionary = new Dictionary<Moves, Action>();

    public static void LoadMoveDictionary()
    {
      MethodInfo[] methods = typeof(MoveFunctions).GetMethods(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
      foreach (Moves move in Enum.GetValues(typeof(Moves)))
      {
        foreach (MethodInfo method in methods)
        {
          if (move.ToString() == method.Name)
          {
            Action moveMethod = (Action)Delegate.CreateDelegate(typeof(Action), method);
            moveDictionary.Add(move, moveMethod);
          }
        }
      }
    }

    public static void Absorb(Pokemon User, Pokemon Target)
    {


    }

    public static void Acid(Pokemon User, Pokemon Target)
    {


    }

    public static void AcidArmor(Pokemon User, Pokemon Target)
    {


    }

    public static void Agility(Pokemon User, Pokemon Target)
    {


    }

    public static void Amnesia(Pokemon User, Pokemon Target)
    {


    }

    public static void AuroraBeam(Pokemon User, Pokemon Target)
    {


    }

    public static void Barrier(Pokemon User, Pokemon Target)
    {


    }

    public static void Bide(Pokemon User, Pokemon Target)
    {


    }

    public static void Bind(Pokemon User, Pokemon Target)
    {


    }

    public static void Bite(Pokemon User, Pokemon Target)
    {


    }

    public static void Blizzard(Pokemon User, Pokemon Target)
    {


    }

    public static void BodySlam(Pokemon User, Pokemon Target)
    {


    }

    public static void BoneClub(Pokemon User, Pokemon Target)
    {


    }

    public static void Bonemerang(Pokemon User, Pokemon Target)
    {


    }

    public static void Bubble(Pokemon User, Pokemon Target)
    {


    }

    public static void BubbleBeam(Pokemon User, Pokemon Target)
    {


    }

    public static void Clamp(Pokemon User, Pokemon Target)
    {


    }

    public static void CometPunch(Pokemon User, Pokemon Target)
    {


    }

    public static void ConfuseRay(Pokemon User, Pokemon Target)
    {


    }

    public static void Confusion(Pokemon User, Pokemon Target)
    {


    }

    public static void Constrict(Pokemon User, Pokemon Target)
    {


    }

    public static void Conversion(Pokemon User, Pokemon Target)
    {


    }

    public static void Counter(Pokemon User, Pokemon Target)
    {


    }

    public static void Crabhammer(Pokemon User, Pokemon Target)
    {


    }

    public static void Cut(Pokemon User, Pokemon Target)
    {


    }

    public static void DefenseCurl(Pokemon User, Pokemon Target)
    {


    }

    public static void Dig(Pokemon User, Pokemon Target)
    {


    }

    public static void Disable(Pokemon User, Pokemon Target)
    {


    }

    public static void DizzyPunch(Pokemon User, Pokemon Target)
    {


    }

    public static void DoubleKick(Pokemon User, Pokemon Target)
    {


    }

    public static void DoubleTeam(Pokemon User, Pokemon Target)
    {


    }

    public static void DoubleEdge(Pokemon User, Pokemon Target)
    {


    }

    public static void DoubleSlap(Pokemon User, Pokemon Target)
    {


    }

    public static void DragonRage(Pokemon User, Pokemon Target)
    {


    }

    public static void DreamEater(Pokemon User, Pokemon Target)
    {


    }

    public static void DrillPeck(Pokemon User, Pokemon Target)
    {


    }

    public static void Earthquake(Pokemon User, Pokemon Target)
    {


    }

    public static void EggBomb(Pokemon User, Pokemon Target)
    {


    }

    public static void Ember(Pokemon User, Pokemon Target)
    {


    }

    public static void Explosion(Pokemon User, Pokemon Target)
    {


    }

    public static void FireBlast(Pokemon User, Pokemon Target)
    {


    }

    public static void FirePunch(Pokemon User, Pokemon Target)
    {


    }

    public static void FireSpin(Pokemon User, Pokemon Target)
    {


    }

    public static void Fissure(Pokemon User, Pokemon Target)
    {


    }

    public static void Flamethrower(Pokemon User, Pokemon Target)
    {


    }

    public static void Flash(Pokemon User, Pokemon Target)
    {


    }

    public static void Fly(Pokemon User, Pokemon Target)
    {


    }

    public static void FocusEnergy(Pokemon User, Pokemon Target)
    {


    }

    public static void FuryAttack(Pokemon User, Pokemon Target)
    {


    }

    public static void FurySwipes(Pokemon User, Pokemon Target)
    {


    }

    public static void Glare(Pokemon User, Pokemon Target)
    {


    }

    public static void Growl(Pokemon User, Pokemon Target)
    {


    }

    public static void Growth(Pokemon User, Pokemon Target)
    {


    }

    public static void Guillotine(Pokemon User, Pokemon Target)
    {


    }

    public static void Gust(Pokemon User, Pokemon Target)
    {


    }

    public static void Harden(Pokemon User, Pokemon Target)
    {


    }

    public static void Haze(Pokemon User, Pokemon Target)
    {


    }

    public static void Headbutt(Pokemon User, Pokemon Target)
    {


    }

    public static void HighJumpKick(Pokemon User, Pokemon Target)
    {


    }

    public static void HornAttack(Pokemon User, Pokemon Target)
    {


    }

    public static void HornDrill(Pokemon User, Pokemon Target)
    {


    }

    public static void HydroPump(Pokemon User, Pokemon Target)
    {


    }

    public static void HyperBeam(Pokemon User, Pokemon Target)
    {


    }

    public static void HyperFang(Pokemon User, Pokemon Target)
    {


    }

    public static void Hypnosis(Pokemon User, Pokemon Target)
    {


    }

    public static void IceBeam(Pokemon User, Pokemon Target)
    {


    }

    public static void IcePunch(Pokemon User, Pokemon Target)
    {


    }

    public static void JumpKick(Pokemon User, Pokemon Target)
    {


    }

    public static void KarateChop(Pokemon User, Pokemon Target)
    {


    }

    public static void Kinesis(Pokemon User, Pokemon Target)
    {


    }

    public static void LeechLife(Pokemon User, Pokemon Target)
    {


    }

    public static void LeechSeed(Pokemon User, Pokemon Target)
    {


    }

    public static void Leer(Pokemon User, Pokemon Target)
    {


    }

    public static void Lick(Pokemon User, Pokemon Target)
    {


    }

    public static void LightScreen(Pokemon User, Pokemon Target)
    {


    }

    public static void LovelyKiss(Pokemon User, Pokemon Target)
    {


    }

    public static void LowKick(Pokemon User, Pokemon Target)
    {


    }

    public static void Meditate(Pokemon User, Pokemon Target)
    {


    }

    public static void MegaDrain(Pokemon User, Pokemon Target)
    {


    }

    public static void MegaKick(Pokemon User, Pokemon Target)
    {


    }

    public static void MegaPunch(Pokemon User, Pokemon Target)
    {


    }

    public static void Metronome(Pokemon User, Pokemon Target)
    {


    }

    public static void Mimic(Pokemon User, Pokemon Target)
    {


    }

    public static void Minimize(Pokemon User, Pokemon Target)
    {


    }

    public static void MirrorMove(Pokemon User, Pokemon Target)
    {


    }

    public static void Mist(Pokemon User, Pokemon Target)
    {


    }

    public static void NightShade(Pokemon User, Pokemon Target)
    {


    }

    public static void PayDay(Pokemon User, Pokemon Target)
    {


    }

    public static void Peck(Pokemon User, Pokemon Target)
    {


    }

    public static void PetalDance(Pokemon User, Pokemon Target)
    {


    }

    public static void PinMissile(Pokemon User, Pokemon Target)
    {


    }

    public static void PoisonGas(Pokemon User, Pokemon Target)
    {


    }

    public static void PoisonPowder(Pokemon User, Pokemon Target)
    {


    }

    public static void PoisonSting(Pokemon User, Pokemon Target)
    {


    }

    public static void Pound(Pokemon User, Pokemon Target)
    {


    }

    public static void Psybeam(Pokemon User, Pokemon Target)
    {


    }

    public static void Psychic(Pokemon User, Pokemon Target)
    {


    }

    public static void Psywave(Pokemon User, Pokemon Target)
    {


    }

    public static void QuickAttack(Pokemon User, Pokemon Target)
    {


    }

    public static void Rage(Pokemon User, Pokemon Target)
    {


    }

    public static void RazorLeaf(Pokemon User, Pokemon Target)
    {


    }

    public static void RazorWind(Pokemon User, Pokemon Target)
    {


    }

    public static void Recover(Pokemon User, Pokemon Target)
    {


    }

    public static void Reflect(Pokemon User, Pokemon Target)
    {


    }

    public static void Rest(Pokemon User, Pokemon Target)
    {


    }

    public static void Roar(Pokemon User, Pokemon Target)
    {


    }

    public static void RockSlide(Pokemon User, Pokemon Target)
    {


    }

    public static void RockThrow(Pokemon User, Pokemon Target)
    {


    }

    public static void RollingKick(Pokemon User, Pokemon Target)
    {


    }

    public static void SandAttack(Pokemon User, Pokemon Target)
    {


    }

    public static void Scratch(Pokemon User, Pokemon Target)
    {


    }

    public static void Screech(Pokemon User, Pokemon Target)
    {


    }

    public static void SeismicToss(Pokemon User, Pokemon Target)
    {


    }

    public static void SelfDestruct(Pokemon User, Pokemon Target)
    {


    }

    public static void Sharpen(Pokemon User, Pokemon Target)
    {


    }

    public static void Sing(Pokemon User, Pokemon Target)
    {


    }

    public static void SkullBash(Pokemon User, Pokemon Target)
    {


    }

    public static void SkyAttack(Pokemon User, Pokemon Target)
    {


    }

    public static void Slam(Pokemon User, Pokemon Target)
    {


    }

    public static void Slash(Pokemon User, Pokemon Target)
    {


    }

    public static void SleepPowder(Pokemon User, Pokemon Target)
    {


    }

    public static void Sludge(Pokemon User, Pokemon Target)
    {


    }

    public static void Smog(Pokemon User, Pokemon Target)
    {


    }

    public static void Smokescreen(Pokemon User, Pokemon Target)
    {


    }

    public static void SoftBoiled(Pokemon User, Pokemon Target)
    {


    }

    public static void SolarBeam(Pokemon User, Pokemon Target)
    {


    }

    public static void SonicBoom(Pokemon User, Pokemon Target)
    {


    }

    public static void SpikeCannon(Pokemon User, Pokemon Target)
    {


    }

    public static void Splash(Pokemon User, Pokemon Target)
    {


    }

    public static void Spore(Pokemon User, Pokemon Target)
    {


    }

    public static void Stomp(Pokemon User, Pokemon Target)
    {


    }

    public static void Strength(Pokemon User, Pokemon Target)
    {


    }

    public static void StringShot(Pokemon User, Pokemon Target)
    {


    }

    public static void Struggle(Pokemon User, Pokemon Target)
    {


    }

    public static void StunSpore(Pokemon User, Pokemon Target)
    {


    }

    public static void Submission(Pokemon User, Pokemon Target)
    {


    }

    public static void Substitute(Pokemon User, Pokemon Target)
    {


    }

    public static void SuperFang(Pokemon User, Pokemon Target)
    {


    }

    public static void Supersonic(Pokemon User, Pokemon Target)
    {


    }

    public static void Surf(Pokemon User, Pokemon Target)
    {


    }

    public static void Swift(Pokemon User, Pokemon Target)
    {


    }

    public static void SwordsDance(Pokemon User, Pokemon Target)
    {


    }

    public static void Tackle(Pokemon User, Pokemon Target)
    {


    }

    public static void TailWhip(Pokemon User, Pokemon Target)
    {


    }

    public static void TakeDown(Pokemon User, Pokemon Target)
    {


    }

    public static void Teleport(Pokemon User, Pokemon Target)
    {


    }

    public static void Thunder(Pokemon User, Pokemon Target)
    {


    }

    public static void ThunderPunch(Pokemon User, Pokemon Target)
    {


    }

    public static void ThunderWave(Pokemon User, Pokemon Target)
    {


    }

    public static void Thunderbolt(Pokemon User, Pokemon Target)
    {


    }

    public static void ThunderShock(Pokemon User, Pokemon Target)
    {


    }

    public static void Toxic(Pokemon User, Pokemon Target)
    {


    }

    public static void Transform(Pokemon User, Pokemon Target)
    {


    }

    public static void TriAttack(Pokemon User, Pokemon Target)
    {


    }

    public static void Twineedle(Pokemon User, Pokemon Target)
    {


    }

    public static void ViceGrip(Pokemon User, Pokemon Target)
    {


    }

    public static void VineWhip(Pokemon User, Pokemon Target)
    {


    }

    public static void WaterGun(Pokemon User, Pokemon Target)
    {


    }

    public static void Waterfall(Pokemon User, Pokemon Target)
    {


    }

    public static void Whirlwind(Pokemon User, Pokemon Target)
    {


    }

    public static void WingAttack(Pokemon User, Pokemon Target)
    {


    }

    public static void Withdraw(Pokemon User, Pokemon Target)
    {


    }

    public static void Wrap(Pokemon User, Pokemon Target)
    {

    }

  }
}
