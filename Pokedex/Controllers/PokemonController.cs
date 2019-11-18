using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pokedex.Data.Dex;

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
        public async void Index(string Name)
        {
            Dex dex = new Dex();
            Name = Name.ToLower();
            await dex.GetPokeNumAsync(Name);
            Console.WriteLine("Gotcha");
        }
    }
}