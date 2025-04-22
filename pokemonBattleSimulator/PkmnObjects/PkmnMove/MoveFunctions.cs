using System.Reflection;

namespace pokemonBattleSimulator.PkmnObjects.PkmnMove
{
  public static class MoveFunctions
  {
    public static Dictionary<Moves, Action<Pokemon, Pokemon, Field>> moveDictionary = new Dictionary<Moves, Action<Pokemon, Pokemon, Field>>();

    public static void LoadMoveDictionary()
    {
      MethodInfo[] methods = typeof(MoveFunctions).GetMethods(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
      foreach (Moves move in Enum.GetValues(typeof(Moves)))
      {
        foreach (MethodInfo method in methods)
        {
          if (move.ToString() == method.Name &&
              method.GetParameters().Length == 3 &&
              method.ReturnType == typeof(void))
          {
            // Create delegate with no target because it's static
            Action<Pokemon, Pokemon, Field> moveMethod = (Action<Pokemon, Pokemon, Field>)Delegate.CreateDelegate(typeof(Action<Pokemon, Pokemon, Field>), method);
            moveDictionary.Add(move, moveMethod);
          }
        }
      }
    }

    #region moveMethods

    public static void None(Pokemon User, Pokemon Target, Field field)
    {

    }

    public static void Absorb(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Acid(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void AcidArmor(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Agility(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Amnesia(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void AuroraBeam(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Barrier(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Bide(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Bind(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Bite(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Blizzard(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void BodySlam(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void BoneClub(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Bonemerang(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Bubble(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void BubbleBeam(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Clamp(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void CometPunch(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void ConfuseRay(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Confusion(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Constrict(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Conversion(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Counter(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Crabhammer(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Cut(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void DefenseCurl(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Dig(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Disable(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void DizzyPunch(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void DoubleKick(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void DoubleTeam(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void DoubleEdge(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void DoubleSlap(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void DragonRage(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void DreamEater(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void DrillPeck(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Earthquake(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void EggBomb(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Ember(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Explosion(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void FireBlast(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void FirePunch(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void FireSpin(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Fissure(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Flamethrower(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Flash(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Fly(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void FocusEnergy(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void FuryAttack(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void FurySwipes(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Glare(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Growl(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Growth(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Guillotine(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Gust(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Harden(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Haze(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Headbutt(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void HighJumpKick(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void HornAttack(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void HornDrill(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void HydroPump(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void HyperBeam(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void HyperFang(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Hypnosis(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void IceBeam(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void IcePunch(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void JumpKick(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void KarateChop(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Kinesis(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void LeechLife(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void LeechSeed(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Leer(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Lick(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void LightScreen(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void LovelyKiss(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void LowKick(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Meditate(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void MegaDrain(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void MegaKick(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void MegaPunch(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Metronome(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Mimic(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Minimize(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void MirrorMove(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Mist(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void NightShade(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void PayDay(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Peck(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void PetalDance(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void PinMissile(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void PoisonGas(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void PoisonPowder(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void PoisonSting(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Pound(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Psybeam(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Psychic(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Psywave(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void QuickAttack(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Rage(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void RazorLeaf(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void RazorWind(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Recover(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Reflect(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Rest(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Roar(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void RockSlide(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void RockThrow(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void RollingKick(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void SandAttack(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Scratch(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Screech(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void SeismicToss(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void SelfDestruct(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Sharpen(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Sing(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void SkullBash(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void SkyAttack(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Slam(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Slash(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void SleepPowder(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Sludge(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Smog(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Smokescreen(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void SoftBoiled(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void SolarBeam(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void SonicBoom(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void SpikeCannon(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Splash(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Spore(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Stomp(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Strength(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void StringShot(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Struggle(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void StunSpore(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Submission(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Substitute(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void SuperFang(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Supersonic(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Surf(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Swift(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void SwordsDance(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Tackle(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void TailWhip(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void TakeDown(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Teleport(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Thunder(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void ThunderPunch(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void ThunderWave(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Thunderbolt(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void ThunderShock(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Toxic(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Transform(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void TriAttack(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Twineedle(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void ViceGrip(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void VineWhip(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void WaterGun(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Waterfall(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Whirlwind(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void WingAttack(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Withdraw(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Wrap(Pokemon User, Pokemon Target, Field field)
    {

    }

    public static void Acupressure(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Aeroblast(Pokemon User, Pokemon Target, Field field)
    {


    }


    public static void AncientPower(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Attract(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Barrage(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void BellyDrum(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void BlazeKick(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void ClearBodyAbility(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Curse(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Detect(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void DoomDesire(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void DynamicPunch(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Encore(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Endure(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void FalseSwipe(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Fear(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void FuryCutter(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void HealBell(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void HiddenPower(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void IcyWind(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void IronTail(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void LusterPurge(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void MeanLook(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void MiracleEye(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void MudSlap(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Nightmare(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void PerishSong(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Protect(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Pursuit(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void RainDance(Pokemon User, Pokemon Target, Field field)
    {


    }


    public static void Reversal(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Return(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Safeguard(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void ScaryFace(Pokemon User, Pokemon Target, Field field)
    {


    }


    public static void ShadowBall(Pokemon User, Pokemon Target, Field field)
    {


    }


    public static void SleepTalk(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void SludgeBomb(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Snore(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void SpacialRend(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void SpiderWeb(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Synthesis(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void ToxicSpikes(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void ZapCannon(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void AerialAce(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void ArmThrust(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Assist(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void BrickBreak(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void CalmMind(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Charge(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void ClawSharpen(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Coil(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Crunch(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Dive(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Endeavor(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Facade(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void FakeOut(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void FeatherDance(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void FellStinger(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Foresight(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void GigaDrain(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void GigaImpact(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Hail(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void HelpingHand(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void HyperVoice(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void KnockOff(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void MachPunch(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void MagnetBomb(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void MetalClaw(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void NaturePower(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void OdorSleuth(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Outrage(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Overheat(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void PoisonTail(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Revenge(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void RockSmash(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void RolePlay(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Sandstorm(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void SecretPower(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void ShockWave(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void SignalBeam(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void SkyUppercut(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void SlackOff(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Snatch(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Spite(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void WorrySeed(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Yawn(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Avalanche(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void BraveBird(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Chatter(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void CloseCombat(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void CrossPoison(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void DarkPulse(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void DracoMeteor(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void DrainPunch(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void EarthPower(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void ElectivireAbility(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void FlareBlitz(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void GyroBall(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void HeadSmash(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void HealBlock(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void HealOrder(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void IceShard(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void IronHead(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void MagnetRise(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void NastyPlot(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void OminousWind(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void PoisonJab(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Punishment(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void ShadowClaw(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void SilverWind(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void StealthRock(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void StoneEdge(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Uturn(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void WaterPulse(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Whirlpool(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Acrobatics(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Autotomize(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void BoilingWater(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Copycat(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void CoreEnforcer(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Defog(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Discharge(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void DragonClaw(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void DragonPulse(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Electroweb(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void FoulPlay(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void FusionFlare(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void FusionBolt(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Glaciate(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void HeatCrash(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void HeatWave(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void LandsWrath(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void MagmaStorm(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void MuddyWater(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void MysticalFire(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void PowerSplit(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void PowerWhip(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void RagePowder(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Retaliate(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Round(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Scald(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void SecretSword(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void ShellSmash(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void ShiftGear(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Skydrop(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Snarl(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void StoredPower(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void StormThrow(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void StruggleBug(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void SuckerPunch(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void WaterSpout(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void WildCharge(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void WorkUp(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void WringOut(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void ZoroarkAbility(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void BabyDollEyes(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Belch(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Boomburst(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void DazzlingGleam(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void DisarmingVoice(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void DrainingKiss(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void EerieImpulse(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void ElectricTerrain(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void FairyLock(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void FlowerShield(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void ForestsCurse(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void FreezeDry(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Geomancy(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void GrassyTerrain(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void HoldBack(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void HyperspaceHole(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Infestation(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void KingsShield(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void LightOfRuin(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void MagneticFlux(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void MatBlock(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void MistyTerrain(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Moonblast(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void NobleRoar(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void OblivionWing(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void OriginPulse(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void ParabolicCharge(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void PartingShot(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void PetalBlizzard(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void PhantomForce(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void PlayNice(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void PlayRough(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void PowerUpPunch(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void PrecipiceBlades(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void Rototiller(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void SpikyShield(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void SteamEruption(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void StickyWeb(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void ThousandArrows(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void ThousandWaves(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void TopsyTurvy(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void ToxicThread(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void TrickOrTreat(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void VenomDrench(Pokemon User, Pokemon Target, Field field)
    {


    }

    public static void WaterShuriken(Pokemon User, Pokemon Target, Field field)
    {


    }


    #endregion
  }
}
