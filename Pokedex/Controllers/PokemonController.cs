using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pokedex.Data.Dex;
using Pokedex.Models.Pokemon;

namespace Pokedex.Controllers
{
    public class PokemonController : Controller
    {
        private readonly Dex _dex;
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Pokesolo(string Name)
        {
            Dex dex = new Dex();
            Name = Name.ToLower();
            Pokemon pokemon = await dex.GetPokeNumAsync(Name);
            ViewBag.Pokemon = pokemon;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Pokerandom()
        {
            Dex dex = new Dex();
            Pokemon pokemon = await dex.GetRandomPokemon();
            ViewBag.Pokemon = pokemon;
            return View();
        }
    }
}