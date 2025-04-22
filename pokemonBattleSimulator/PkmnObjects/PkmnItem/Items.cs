using System.Reflection;

namespace pokemonBattleSimulator.PkmnObjects.PkmnItem
{
  public class Item
  {
    public bool _IsConsumed { get; set; }
    public readonly Items _Item;
    public Action<Pokemon, Pokemon, Field> _ItemFunction;

    public Item(Items item)
    {
      _Item = item;
      _IsConsumed = false;
      _ItemFunction = ItemFunctions.itemDictionary[item];
    }
  }
  public enum Items
  {
    None,
    Berry,
    BitterBerry,
    BurntBerry,
    GoldBerry,
    IceBerry,
    MintBerry,
    MiracleBerry,
    MysteryBerry,
    PRZCureBerry,
    PSNCureBerry,
    BlackBelt,
    BlackGlasses,
    BrightPowder,
    Charcoal,
    DragonFang,
    DragonScale,
    Everstone,
    ExpShare,
    FocusBand,
    HardStone,
    KingsRock,
    Leftovers,
    LightBall,
    LuckyEgg,
    LuckyPunch,
    Magnet,
    MetalCoat,
    MetalPowder,
    MiracleSeed,
    MysticWater,
    NeverMeltIce,
    PinkBow,
    PoisonBarb,
    PolkadotBow,
    ScopeLens,
    SharpBeak,
    ShellBell,
    SilkScarf,
    SilverPowder,
    SoftSand,
    SpellTag,
    Stick,
    ThickClub,
    TwistedSpoon,
    AmuletCoin,
    CleanseTag,
    DeepSeaScale,
    DeepSeaTooth,
    LaxIncense,
    LuckIncense,
    MachoBrace,
    SeaIncense,
    SmokeBall,
    SootheBell,
    WaveIncense,
    WhiteHerb,
    BlueScarf,
    GreenScarf,
    PinkScarf,
    RedScarf,
    YellowScarf,
    ChoiceBand,
    FluffyTail,
    LavaCookie,
    MentalHerb,
    OranBerry,
    PechaBerry,
    PersimBerry,
    RawstBerry,
    SitrusBerry,
    ChestoBerry,
    LumBerry,
    AspearBerry,
    LeppaBerry,
    HondewBerry,
    KelpsyBerry,
    PomegBerry,
    QualotBerry,
    TamatoBerry,
    BelueBerry,
    DurinBerry,
    GrepaBerry,
    LansatBerry,
    LiechiBerry,
    SalacBerry,
    StarfBerry,
    WepearBerry,
    AguavBerry,
    ApicotBerry,
    CheriBerry,
    CornnBerry,
    EnigmaBerry,
    FigyBerry,
    GanlonBerry,
    IapapaBerry,
    MagoBerry,
    NanabBerry,
    NomelBerry,
    PamtreBerry,
    RazzBerry,
    SpelonBerry,
    WikiBerry
  }

  public static class ItemFunctions
  {
    public static Dictionary<Items, Action<Pokemon, Pokemon, Field>> itemDictionary = new Dictionary<Items, Action<Pokemon, Pokemon, Field>>();

    public static void LoadItemDictionary()
    {
      MethodInfo[] methods = typeof(ItemFunctions).GetMethods(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
      foreach (Items item in Enum.GetValues(typeof(Items)))
      {
        foreach (MethodInfo method in methods)
        {
          if (item.ToString() == method.Name &&
              method.GetParameters().Length == 0 &&
              method.ReturnType == typeof(void))
          {
            // Create delegate with no target because it's static
            Action<Pokemon, Pokemon, Field> itemMethod = (Action<Pokemon, Pokemon, Field>)Delegate.CreateDelegate(typeof(Action<Pokemon, Pokemon, Field>), method);
            itemDictionary.Add(item, itemMethod);
          }
        }
      }
    }

    #region"Item Functions"
    public static void Berry(Pokemon Holder, Pokemon Target, Field field)
    {


    }
    public static void BitterBerry(Pokemon Holder, Pokemon Target, Field field)
    {


    }
    public static void BurntBerry(Pokemon Holder, Pokemon Target, Field field)
    {


    }
    public static void GoldBerry(Pokemon Holder, Pokemon Target, Field field)
    {


    }
    public static void IceBerry(Pokemon Holder, Pokemon Target, Field field)
    {


    }
    public static void MintBerry(Pokemon Holder, Pokemon Target, Field field)
    {


    }
    public static void MiracleBerry(Pokemon Holder, Pokemon Target, Field field)
    {


    }
    public static void MysteryBerry(Pokemon Holder, Pokemon Target, Field field)
    {


    }
    public static void PRZCureBerry(Pokemon Holder, Pokemon Target, Field field)
    {


    }
    public static void PSNCureBerry(Pokemon Holder, Pokemon Target, Field field)
    {


    }
    public static void BlackBelt(Pokemon Holder, Pokemon Target, Field field)
    {


    }
    public static void BlackGlasses(Pokemon Holder, Pokemon Target, Field field)
    {


    }
    public static void BrightPowder(Pokemon Holder, Pokemon Target, Field field)
    {


    }
    public static void Charcoal(Pokemon Holder, Pokemon Target, Field field)
    {


    }
    public static void DragonFang(Pokemon Holder, Pokemon Target, Field field)
    {


    }
    public static void DragonScale(Pokemon Holder, Pokemon Target, Field field)
    {


    }
    public static void Everstone(Pokemon Holder, Pokemon Target, Field field)
    {


    }
    public static void ExpShare(Pokemon Holder, Pokemon Target, Field field)
    {


    }
    public static void FocusBand(Pokemon Holder, Pokemon Target, Field field)
    {


    }
    public static void HardStone(Pokemon Holder, Pokemon Target, Field field)
    {


    }
    public static void KingsRock(Pokemon Holder, Pokemon Target, Field field)
    {


    }
    public static void Leftovers(Pokemon Holder, Pokemon Target, Field field)
    {


    }
    public static void LightBall(Pokemon Holder, Pokemon Target, Field field)
    {


    }
    public static void LuckyEgg(Pokemon Holder, Pokemon Target, Field field)
    {


    }
    public static void LuckyPunch(Pokemon Holder, Pokemon Target, Field field)
    {


    }
    public static void Magnet(Pokemon Holder, Pokemon Target, Field field)
    {


    }
    public static void MetalCoat(Pokemon Holder, Pokemon Target, Field field)
    {


    }
    public static void MetalPowder(Pokemon Holder, Pokemon Target, Field field)
    {


    }
    public static void MiracleSeed(Pokemon Holder, Pokemon Target, Field field)
    {


    }
    public static void MysticWater(Pokemon Holder, Pokemon Target, Field field)
    {


    }
    public static void NeverMeltIce(Pokemon Holder, Pokemon Target, Field field)
    {


    }
    public static void PinkBow(Pokemon Holder, Pokemon Target, Field field)
    {


    }
    public static void PoisonBarb(Pokemon Holder, Pokemon Target, Field field)
    {


    }
    public static void PolkadotBow(Pokemon Holder, Pokemon Target, Field field)
    {


    }
    public static void ScopeLens(Pokemon Holder, Pokemon Target, Field field)
    {


    }
    public static void SharpBeak(Pokemon Holder, Pokemon Target, Field field)
    {


    }
    public static void ShellBell(Pokemon Holder, Pokemon Target, Field field)
    {


    }
    public static void SilkScarf(Pokemon Holder, Pokemon Target, Field field)
    {


    }
    public static void SilverPowder(Pokemon Holder, Pokemon Target, Field field)
    {


    }
    public static void SoftSand(Pokemon Holder, Pokemon Target, Field field)
    {


    }
    public static void SpellTag(Pokemon Holder, Pokemon Target, Field field)
    {


    }
    public static void Stick(Pokemon Holder, Pokemon Target, Field field)
    {


    }
    public static void ThickClub(Pokemon Holder, Pokemon Target, Field field)
    {


    }
    public static void TwistedSpoon(Pokemon Holder, Pokemon Target, Field field)
    {


    }
    public static void AmuletCoin(Pokemon Holder, Pokemon Target, Field field)
    {


    }
    public static void CleanseTag(Pokemon Holder, Pokemon Target, Field field)
    {


    }
    public static void DeepSeaScale(Pokemon Holder, Pokemon Target, Field field)
    {


    }
    public static void DeepSeaTooth(Pokemon Holder, Pokemon Target, Field field)
    {


    }
    public static void LaxIncense(Pokemon Holder, Pokemon Target, Field field)
    {


    }
    public static void LuckIncense(Pokemon Holder, Pokemon Target, Field field)
    {


    }
    public static void MachoBrace(Pokemon Holder, Pokemon Target, Field field)
    {


    }
    public static void SeaIncense(Pokemon Holder, Pokemon Target, Field field)
    {


    }
    public static void SmokeBall(Pokemon Holder, Pokemon Target, Field field)
    {


    }
    public static void SootheBell(Pokemon Holder, Pokemon Target, Field field)
    {


    }
    public static void WaveIncense(Pokemon Holder, Pokemon Target, Field field)
    {


    }
    public static void WhiteHerb(Pokemon Holder, Pokemon Target, Field field)
    {


    }
    public static void BlueScarf(Pokemon Holder, Pokemon Target, Field field)
    {


    }
    public static void GreenScarf(Pokemon Holder, Pokemon Target, Field field)
    {


    }
    public static void PinkScarf(Pokemon Holder, Pokemon Target, Field field)
    {


    }
    public static void RedScarf(Pokemon Holder, Pokemon Target, Field field)
    {


    }
    public static void YellowScarf(Pokemon Holder, Pokemon Target, Field field)
    {


    }
    public static void ChoiceBand(Pokemon Holder, Pokemon Target, Field field)
    {


    }
    public static void FluffyTail(Pokemon Holder, Pokemon Target, Field field)
    {


    }
    public static void LavaCookie(Pokemon Holder, Pokemon Target, Field field)
    {


    }
    public static void MentalHerb(Pokemon Holder, Pokemon Target, Field field)
    {


    }
    public static void OranBerry(Pokemon Holder, Pokemon Target, Field field)
    {


    }
    public static void PechaBerry(Pokemon Holder, Pokemon Target, Field field)
    {


    }
    public static void PersimBerry(Pokemon Holder, Pokemon Target, Field field)
    {


    }
    public static void RawstBerry(Pokemon Holder, Pokemon Target, Field field)
    {


    }
    public static void SitrusBerry(Pokemon Holder, Pokemon Target, Field field)
    {


    }
    public static void ChestoBerry(Pokemon Holder, Pokemon Target, Field field)
    {


    }
    public static void LumBerry(Pokemon Holder, Pokemon Target, Field field)
    {


    }
    public static void AspearBerry(Pokemon Holder, Pokemon Target, Field field)
    {


    }
    public static void LeppaBerry(Pokemon Holder, Pokemon Target, Field field)
    {


    }
    public static void HondewBerry(Pokemon Holder, Pokemon Target, Field field)
    {


    }
    public static void KelpsyBerry(Pokemon Holder, Pokemon Target, Field field)
    {


    }
    public static void PomegBerry(Pokemon Holder, Pokemon Target, Field field)
    {


    }
    public static void QualotBerry(Pokemon Holder, Pokemon Target, Field field)
    {


    }
    public static void TamatoBerry(Pokemon Holder, Pokemon Target, Field field)
    {


    }
    public static void BelueBerry(Pokemon Holder, Pokemon Target, Field field)
    {


    }
    public static void DurinBerry(Pokemon Holder, Pokemon Target, Field field)
    {


    }
    public static void GrepaBerry(Pokemon Holder, Pokemon Target, Field field)
    {


    }
    public static void LansatBerry(Pokemon Holder, Pokemon Target, Field field)
    {


    }
    public static void LiechiBerry(Pokemon Holder, Pokemon Target, Field field)
    {


    }
    public static void SalacBerry(Pokemon Holder, Pokemon Target, Field field)
    {


    }
    public static void StarfBerry(Pokemon Holder, Pokemon Target, Field field)
    {


    }
    public static void WepearBerry(Pokemon Holder, Pokemon Target, Field field)
    {


    }
    public static void AguavBerry(Pokemon Holder, Pokemon Target, Field field)
    {


    }
    public static void ApicotBerry(Pokemon Holder, Pokemon Target, Field field)
    {


    }
    public static void CheriBerry(Pokemon Holder, Pokemon Target, Field field)
    {


    }
    public static void CornnBerry(Pokemon Holder, Pokemon Target, Field field)
    {


    }
    public static void EnigmaBerry(Pokemon Holder, Pokemon Target, Field field)
    {


    }
    public static void FigyBerry(Pokemon Holder, Pokemon Target, Field field)
    {


    }
    public static void GanlonBerry(Pokemon Holder, Pokemon Target, Field field)
    {


    }
    public static void IapapaBerry(Pokemon Holder, Pokemon Target, Field field)
    {


    }
    public static void MagoBerry(Pokemon Holder, Pokemon Target, Field field)
    {


    }
    public static void NanabBerry(Pokemon Holder, Pokemon Target, Field field)
    {


    }
    public static void NomelBerry(Pokemon Holder, Pokemon Target, Field field)
    {


    }
    public static void PamtreBerry(Pokemon Holder, Pokemon Target, Field field)
    {


    }
    public static void RazzBerry(Pokemon Holder, Pokemon Target, Field field)
    {


    }
    public static void SpelonBerry(Pokemon Holder, Pokemon Target, Field field)
    {


    }
    public static void WikiBerry(Pokemon Holder, Pokemon Target, Field field)
    {


    }
    #endregion
  }
}
