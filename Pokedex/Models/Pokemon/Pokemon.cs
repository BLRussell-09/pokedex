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
    public Dictionary<string, string> sprites { get; set; }
    public Abilities[] abilities { get; set; }
    public Stats[] stats { get; set; }
    public string sprite { get; set; }
    public Moves[] moves { get; set; }

    public Pokemon treatPokemon(Pokemon pokemon)
    {
      pokemon.name = Caps(pokemon.name);

      foreach (var set in pokemon.abilities)
      {
        set.ability["name"] = Caps(set.ability["name"]);
      }
      foreach (var stat in pokemon.stats)
      {
        stat.stat["name"] = Caps(stat.stat["name"]);
      }
      foreach (var move in pokemon.moves)
      {
        move.move["name"] = Caps(move.move["name"]);
      }
      
      pokemon.sprite = $"https://projectpokemon.org/images/normal-sprite/{pokemon.name.ToLower()}.gif";

      return pokemon;
    }

    private string Caps(string s)
    {
      if (string.IsNullOrEmpty(s))
      {
        return string.Empty;
      }
      char[] a = s.ToCharArray();
      a[0] = char.ToUpper(a[0]);
      return new string(a);
    }
  }
}
