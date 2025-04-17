﻿namespace pokemonBattleSimulator.PkmnObjects
{
  public class Field
  {

    // trainers
    public ITrainer _Player { get; set; }
    public ITrainer _AI { get; set; }


    // double battle
    public bool _IsDoubleBattle { get; set; } = false;

    // switch-in damage
    public (bool, bool) _StealthRock { get; set; } = (false, false);
    public (int, int) _SpikeLayers { get; set; } = (0, 0);
    public (int, int) _ToxicSpikeLayers { get; set; } = (0, 0);

    // damage reduction
    public (bool, bool) _Reflect { get; set; } = (false, false);
    public (bool, bool) _LightScreen { get; set; } = (false, false);

    // healing
    public (bool, bool) _LeechSeed { get; set; } = (false, false);

    // Type effectiveness/Evasivenss
    public (bool, bool) _Foresight { get; set; } = (false, false);

    // speed
    public (bool, bool) _Tailwind { get; set; } = (false, false);

    // buffs
    public (bool, bool) _FlowerGift { get; set; } = (false, false);
    public (bool, bool) _Battery { get; set; } = (false, false);
    public (bool, bool) _PowerSpot { get; set; } = (false, false);

    // weather specific
    public (bool, bool) _AuroraVeil { get; set; } = (false, false);

    public Field(ITrainer ai, ITrainer player)
    {
      _AI = ai;
      _Player = player;
    }
  }
}
