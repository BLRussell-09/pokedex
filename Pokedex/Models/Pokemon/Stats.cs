using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.Models.Pokemon
{
  public class Stats
  {
    public int base_stat { get; set; }
    public int effort { get; set; }
    public Dictionary<string, string> stat { get; set; }
  }
}
