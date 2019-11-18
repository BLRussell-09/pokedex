using Pokedex.Models.Pokemon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Pokedex.Data.Dex
{
  public class Dex
  {
    public string baseUrl = "https://pokeapi.co/api/v2/";
    static readonly HttpClient client = new HttpClient();
    public async Task GetPokeNumAsync(string name)
    {
      try
      {
        string url = $"{baseUrl}pokemon/{name}";
        HttpResponseMessage response = await client.GetAsync(url);
        response.EnsureSuccessStatusCode();
        Pokemon pokemon = await response.Content.ReadAsAsync<Pokemon>();
        Console.WriteLine(pokemon.name);
      }
      catch (HttpRequestException e)
      {
        Console.WriteLine("Message:{0} ", e.Message);
        throw;
      }
    }
  }
}
