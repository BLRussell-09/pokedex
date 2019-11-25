using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.Models.Moveset
{
  public class Move
  {
    public string name { get; set; }
    public int id { get; set; }
    public Effects[] effect_entries { get; set; }
  }

  public class Effects
  {
      public string effect { get; set; }
  }
}
