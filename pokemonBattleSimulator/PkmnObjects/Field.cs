using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pokemonBattleSimulator.PkmnObjects
{
  public class Field
  {
    public Pokemon PlayerPkmn { get; set; }
    public Pokemon EnemyPkmn { get; set; }

    // double battle
    public bool IsDoubleBattle { get; set; } = false;

    // switch-in damage
    public (bool, bool) StealthRock { get; set; } = (false, false);
    public (int, int) SpikeLayers { get; set; } = (0, 0);
    public (int, int) ToxicSpikeLayers { get; set; } = (0, 0);

    // damage reduction
    public (bool, bool) Reflect { get; set; } = (false, false);
    public (bool, bool) LightScreen { get; set; } = (false, false);

    // healing
    public (bool, bool) LeechSeed { get; set; } = (false, false);

    // Type effectiveness/Evasivenss
    public (bool, bool) Foresight { get; set; } = (false, false);

    // speed
    public (bool, bool) Tailwind { get; set; } = (false, false);

    // buffs
    public (bool, bool) FlowerGift { get; set; } = (false, false);
    public (bool, bool) Battery { get; set; } = (false, false);
    public (bool, bool) PowerSpot { get; set; } = (false, false);

    // weather specific
    public (bool, bool) AuroraVeil { get; set; } = (false, false);



    public Field(Pokemon player, Pokemon enemy)
    {
      PlayerPkmn = player;
      EnemyPkmn = enemy;
    }
  }
}
