using Pokedex.Models.Moveset;
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
        pokemon = pokemon.treatPokemon(pokemon);
        //await GetMoveDesc(pokemon);
        return pokemon;
      }
      catch (HttpRequestException e)
      {
        Console.WriteLine("Message:{0} ", e.Message);
        throw;
      }
    }

    private async Task<Pokemon> GetMoveDesc(Pokemon pokemon)
    {
        var moves = pokemon.moves;
        foreach (var move in moves)
        {
            string url = move.move["url"];
            try
            {
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                Move pokemove = await response.Content.ReadAsAsync<Move>();
                Console.WriteLine(pokemove);
                move.move["effect"] = pokemove.effect_entries[0].effect;
            }
            catch (HttpRequestException e)
            {
              Console.WriteLine("Message:{0} ", e.Message);
              throw;
            }
        }
        return pokemon;
    }

  }
}
