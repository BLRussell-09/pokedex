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

    public async Task<Pokemon> GetPokeNumAsync(string name)
    {
      string url = $"{baseUrl}pokemon/{name}";
      return await PokeApiGet(url);
    }

    public async Task<Pokemon> GetRandomPokemon()
    {
      var rand = new Random();
      int num = rand.Next(808);
      string url = $"{baseUrl}pokemon/{num}";
      return await PokeApiGet(url);
    }

    private async Task<Pokemon> PokeApiGet(string url)
    {
      try
      {
        HttpResponseMessage response = await client.GetAsync(url);
        response.EnsureSuccessStatusCode();
        Pokemon pokemon = await response.Content.ReadAsAsync<Pokemon>();
        return pokemon;
      }
      catch (HttpRequestException e)
      {
        Console.WriteLine("Message:{0} ", e.Message);
        throw;
      }
    }

  }
}
