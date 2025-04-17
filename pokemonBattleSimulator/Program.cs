using pokemonBattleSimulator;
using pokemonBattleSimulator.PkmnObjects;

ItemFunctions.LoadItemDictionary();
MoveFunctions.LoadMoveDictionary();

string battle =
  "=Rain\r\n" +
  "=Tailwind\r\n\r\n" +
  "Younster Joey:\r\n\r\n" +
  "Breloom @ Cheri Berry\r\n" +
  "Level: 35\r\n" +
  "Jolly Nature\r\n" +
  "Ability: Poison Heal\r\n" +
  "IVs: 11 HP / 14 Atk / 18 Def / 16 SpD / 23 Spe\r\n" +
  "- Mach Punch\r\n- Brick Break\r\n- Giga Drain\r\n- Fake Tears\r\n" +
  "***\r\n" +
  "Player:\r\n\r\n" +
  "Breloom @ Cheri Berry\r\n" +
  "Level: 35\r\n" +
  "Jolly Nature\r\n" +
  "Ability: Poison Heal\r\n" +
  "IVs: 11 HP / 14 Atk / 18 Def / 16 SpD / 23 Spe\r\n" +
  "- Mach Punch\r\n- Brick Break\r\n- Giga Drain\r\n- Fake Tears";

Field field= PkmnParser.BattleParse(battle);


