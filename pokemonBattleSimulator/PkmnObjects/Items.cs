using System.Reflection;

namespace pokemonBattleSimulator.PkmnObjects
{
  public class Item
  {
    public bool _IsConsumed { get; set; }
    public readonly Items _Item;
    public Action _ItemFunction;

    public Item(Items item)
    {
      this._Item = item;
      this._IsConsumed = false;
      this._ItemFunction = ItemFunctions.itemDictionary[item];
    }
  }
  public enum Items
  {
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
    WikiBerry,
  }

  public static class ItemFunctions
  {
    public static Dictionary<Items, Action> itemDictionary = new Dictionary<Items, Action>();

    public static void LoadItemDictionary()
    {
      MethodInfo[] methods = typeof(ItemFunctions).GetMethods(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
      foreach (Items item in Enum.GetValues(typeof(Items)))
      {
        foreach (MethodInfo method in methods)
        {
          if (item.ToString() == method.Name)
          {
            Action itemMethod = (Action)Delegate.CreateDelegate(typeof(Action), method);
            itemDictionary.Add(item, itemMethod);
          }
        }
      }
    }

    #region"Move Functions"
    public static void  Berry(Pokemon Holder, Pokemon Target)
    {


    }
    public static void  BitterBerry(Pokemon Holder, Pokemon Target)
    {


    }
    public static void  BurntBerry(Pokemon Holder, Pokemon Target)
    {


    }
    public static void  GoldBerry(Pokemon Holder, Pokemon Target)
    {


    }
    public static void  IceBerry(Pokemon Holder, Pokemon Target)
    {


    }
    public static void  MintBerry(Pokemon Holder, Pokemon Target)
    {


    }
    public static void  MiracleBerry(Pokemon Holder, Pokemon Target)
    {


    }
    public static void  MysteryBerry(Pokemon Holder, Pokemon Target)
    {


    }
    public static void  PRZCureBerry(Pokemon Holder, Pokemon Target)
    {


    }
    public static void  PSNCureBerry(Pokemon Holder, Pokemon Target)
    {


    }
    public static void  BlackBelt(Pokemon Holder, Pokemon Target)
    {


    }
    public static void  BlackGlasses(Pokemon Holder, Pokemon Target)
    {


    }
    public static void  BrightPowder(Pokemon Holder, Pokemon Target)
    {


    }
    public static void  Charcoal(Pokemon Holder, Pokemon Target)
    {


    }
    public static void  DragonFang(Pokemon Holder, Pokemon Target)
    {


    }
    public static void  DragonScale(Pokemon Holder, Pokemon Target)
    {


    }
    public static void  Everstone(Pokemon Holder, Pokemon Target)
    {


    }
    public static void  ExpShare(Pokemon Holder, Pokemon Target)
    {


    }
    public static void  FocusBand(Pokemon Holder, Pokemon Target)
    {


    }
    public static void  HardStone(Pokemon Holder, Pokemon Target)
    {


    }
    public static void  KingsRock(Pokemon Holder, Pokemon Target)
    {


    }
    public static void  Leftovers(Pokemon Holder, Pokemon Target)
    {


    }
    public static void  LightBall(Pokemon Holder, Pokemon Target)
    {


    }
    public static void  LuckyEgg(Pokemon Holder, Pokemon Target)
    {


    }
    public static void  LuckyPunch(Pokemon Holder, Pokemon Target)
    {


    }
    public static void  Magnet(Pokemon Holder, Pokemon Target)
    {


    }
    public static void  MetalCoat(Pokemon Holder, Pokemon Target)
    {


    }
    public static void  MetalPowder(Pokemon Holder, Pokemon Target)
    {


    }
    public static void  MiracleSeed(Pokemon Holder, Pokemon Target)
    {


    }
    public static void  MysticWater(Pokemon Holder, Pokemon Target)
    {


    }
    public static void  NeverMeltIce(Pokemon Holder, Pokemon Target)
    {


    }
    public static void  PinkBow(Pokemon Holder, Pokemon Target)
    {


    }
    public static void  PoisonBarb(Pokemon Holder, Pokemon Target)
    {


    }
    public static void  PolkadotBow(Pokemon Holder, Pokemon Target)
    {


    }
    public static void  ScopeLens(Pokemon Holder, Pokemon Target)
    {


    }
    public static void  SharpBeak(Pokemon Holder, Pokemon Target)
    {


    }
    public static void  ShellBell(Pokemon Holder, Pokemon Target)
    {


    }
    public static void  SilkScarf(Pokemon Holder, Pokemon Target)
    {


    }
    public static void  SilverPowder(Pokemon Holder, Pokemon Target)
    {


    }
    public static void  SoftSand(Pokemon Holder, Pokemon Target)
    {


    }
    public static void  SpellTag(Pokemon Holder, Pokemon Target)
    {


    }
    public static void  Stick(Pokemon Holder, Pokemon Target)
    {


    }
    public static void  ThickClub(Pokemon Holder, Pokemon Target)
    {


    }
    public static void  TwistedSpoon(Pokemon Holder, Pokemon Target)
    {


    }
    public static void  AmuletCoin(Pokemon Holder, Pokemon Target)
    {


    }
    public static void  CleanseTag(Pokemon Holder, Pokemon Target)
    {


    }
    public static void  DeepSeaScale(Pokemon Holder, Pokemon Target)
    {


    }
    public static void  DeepSeaTooth(Pokemon Holder, Pokemon Target)
    {


    }
    public static void  LaxIncense(Pokemon Holder, Pokemon Target)
    {


    }
    public static void  LuckIncense(Pokemon Holder, Pokemon Target)
    {


    }
    public static void  MachoBrace(Pokemon Holder, Pokemon Target)
    {


    }
    public static void  SeaIncense(Pokemon Holder, Pokemon Target)
    {


    }
    public static void  SmokeBall(Pokemon Holder, Pokemon Target)
    {


    }
    public static void  SootheBell(Pokemon Holder, Pokemon Target)
    {


    }
    public static void  WaveIncense(Pokemon Holder, Pokemon Target)
    {


    }
    public static void  WhiteHerb(Pokemon Holder, Pokemon Target)
    {


    }
    public static void  BlueScarf(Pokemon Holder, Pokemon Target)
    {


    }
    public static void  GreenScarf(Pokemon Holder, Pokemon Target)
    {


    }
    public static void  PinkScarf(Pokemon Holder, Pokemon Target)
    {


    }
    public static void  RedScarf(Pokemon Holder, Pokemon Target)
    {


    }
    public static void  YellowScarf(Pokemon Holder, Pokemon Target)
    {


    }
    public static void  ChoiceBand(Pokemon Holder, Pokemon Target)
    {


    }
    public static void  FluffyTail(Pokemon Holder, Pokemon Target)
    {


    }
    public static void  LavaCookie(Pokemon Holder, Pokemon Target)
    {


    }
    public static void  MentalHerb(Pokemon Holder, Pokemon Target)
    {


    }
    public static void  OranBerry(Pokemon Holder, Pokemon Target)
    {


    }
    public static void  PechaBerry(Pokemon Holder, Pokemon Target)
    {


    }
    public static void  PersimBerry(Pokemon Holder, Pokemon Target)
    {


    }
    public static void  RawstBerry(Pokemon Holder, Pokemon Target)
    {


    }
    public static void  SitrusBerry(Pokemon Holder, Pokemon Target)
    {


    }
    public static void  ChestoBerry(Pokemon Holder, Pokemon Target)
    {


    }
    public static void  LumBerry(Pokemon Holder, Pokemon Target)
    {


    }
    public static void  AspearBerry(Pokemon Holder, Pokemon Target)
    {


    }
    public static void  LeppaBerry(Pokemon Holder, Pokemon Target)
    {


    }
    public static void  HondewBerry(Pokemon Holder, Pokemon Target)
    {


    }
    public static void  KelpsyBerry(Pokemon Holder, Pokemon Target)
    {


    }
    public static void  PomegBerry(Pokemon Holder, Pokemon Target)
    {


    }
    public static void  QualotBerry(Pokemon Holder, Pokemon Target)
    {


    }
    public static void  TamatoBerry(Pokemon Holder, Pokemon Target)
    {


    }
    public static void  BelueBerry(Pokemon Holder, Pokemon Target)
    {


    }
    public static void  DurinBerry(Pokemon Holder, Pokemon Target)
    {


    }
    public static void  GrepaBerry(Pokemon Holder, Pokemon Target)
    {


    }
    public static void  LansatBerry(Pokemon Holder, Pokemon Target)
    {


    }
    public static void  LiechiBerry(Pokemon Holder, Pokemon Target)
    {


    }
    public static void  SalacBerry(Pokemon Holder, Pokemon Target)
    {


    }
    public static void  StarfBerry(Pokemon Holder, Pokemon Target)
    {


    }
    public static void  WepearBerry(Pokemon Holder, Pokemon Target)
    {


    }
    public static void  AguavBerry(Pokemon Holder, Pokemon Target)
    {


    }
    public static void  ApicotBerry(Pokemon Holder, Pokemon Target)
    {


    }
    public static void  CheriBerry(Pokemon Holder, Pokemon Target)
    {


    }
    public static void  CornnBerry(Pokemon Holder, Pokemon Target)
    {


    }
    public static void  EnigmaBerry(Pokemon Holder, Pokemon Target)
    {


    }
    public static void  FigyBerry(Pokemon Holder, Pokemon Target)
    {


    }
    public static void  GanlonBerry(Pokemon Holder, Pokemon Target)
    {


    }
    public static void  IapapaBerry(Pokemon Holder, Pokemon Target)
    {


    }
    public static void  MagoBerry(Pokemon Holder, Pokemon Target)
    {


    }
    public static void  NanabBerry(Pokemon Holder, Pokemon Target)
    {


    }
    public static void  NomelBerry(Pokemon Holder, Pokemon Target)
    {


    }
    public static void  PamtreBerry(Pokemon Holder, Pokemon Target)
    {


    }
    public static void  RazzBerry(Pokemon Holder, Pokemon Target)
    {


    }
    public static void  SpelonBerry(Pokemon Holder, Pokemon Target)
    {


    }
    public static void  WikiBerry(Pokemon Holder, Pokemon Target)
    {


    }
    #endregion
  }
}
