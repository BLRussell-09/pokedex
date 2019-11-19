using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.Models.Pokemon
{
  public class Abilities
  {
    public bool is_hidden { get; set; }
    public int slot { get; set; }
    public Dictionary<string, string> ability { get; set; }
  }
}
