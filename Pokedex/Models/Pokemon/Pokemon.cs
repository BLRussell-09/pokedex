using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.Models.Pokemon
{
  public class Pokemon
  {
    public int id { get; set; }
    public string name { get; set; }
    public int base_experience { get; set; }
    public int height { get; set; }
    public int weight { get; set; }
  }
}
