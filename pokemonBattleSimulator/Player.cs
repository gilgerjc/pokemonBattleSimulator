using pokemonBattleSimulator.PkmnObjects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace pokemonBattleSimulator
{
  public class Player : ITrainer
  {
    public string _Name { get; set; }
    public Pokemon?[] _Party { get; set; }
    public Pokemon?[] _ActivePkmn { get; set; }

    public Player(string name, Pokemon?[] box)
    {
      _Name = name;
      _Party = box;
      _ActivePkmn = [box[0], box[1]];
    }

    public Move ChoseMove(Pokemon playerMon, Field field)
    {
      throw new NotImplementedException();
    }
  }
}
