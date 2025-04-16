using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

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
    Wrap
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
    public Action _MoveAction;

    public int _currPP;


    public bool _IsMultitarget;

    public Random _Random = new Random();

    public Move(Moves move, int basePower, int accuracy, MoveType moveType, PkmnType typing, int maxPP)
    {
      this._Move = move;
      this._BasePower = basePower;
      this._Accuracy = accuracy;
      this._MoveType = moveType;
      this._Typing = typing;
      this._MaxPP = maxPP;
      this._currPP = this._MaxPP;
      this._MoveAction = MoveFunctions.moveDictionary[move];

      // flags
      this._IsMultitarget = false;
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

    public static int DamageRoll(Pokemon User, Pokemon Target, Move move, bool crit = false)
    {
      int att = 0;
      int def = 0;
      double multiplier = 1.0;

      Func<int, double> GetStatChangeMultiplier = x => (x > 0) ? (2 + x) / 2.0 : 2 / (2 - x);

      // Get att/def

      if (move._MoveType == MoveType.Physical)
      {
        att = User._Stats[Stat.Att]; def = Target._Stats[Stat.Def];// set physical
        
        multiplier *= GetStatChangeMultiplier(User._StatChanges[Stat.Att]);
        multiplier *= GetStatChangeMultiplier(User._StatChanges[Stat.Def]);
      }
      else if (move._MoveType == MoveType.Special)
      {
        att = User._Stats[Stat.SpAtt]; def = Target._Stats[Stat.SpDef]; // set special

        multiplier *= GetStatChangeMultiplier(User._StatChanges[Stat.SpAtt]);
        multiplier *= GetStatChangeMultiplier(User._StatChanges[Stat.SpDef]);
      }
      else { multiplier = 0; } // status moves

      // Crit
      if (crit)
      {
        multiplier = 1; // ignore stat changes, reset multiplier
        if (move._Random.Next(16) == 15) { multiplier *= 1.5; }
      }

      // Multitarget
      if (move._IsMultitarget) { multiplier *= .75; }

      // Weather - TODO


      // Roll
      multiplier *= move._Random.Next(85, 101) / 100.0;

      // STAB
      if (move._Typing == User._Type1 || move._Typing == User._Type2) { multiplier *= 1.5; }

      // Type effectiveness
      if (Target._Type1 != PkmnType.None)
      {
        multiplier *= TypeEffectiveness.Chart[(int) move._Typing, (int)Target._Type1];
      }
      if (Target._Type2 != PkmnType.None)
      {
        multiplier *= TypeEffectiveness.Chart[(int)move._Typing, (int)Target._Type2];
      }

      int damageRoll = (int)(((((((2 * User._Level) / 5) + 2) * move._BasePower * (att/def)) / 50) + 2) * multiplier);

      return damageRoll;
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
