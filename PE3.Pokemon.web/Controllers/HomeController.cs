using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PE3.Pokemon.web.Data;
using PE3.Pokemon.web.Entities;
using PE3.Pokemon.web.Models;

namespace PE3.Pokemon.web.Controllers
{
    public class HomeController : Controller
    {
        private PokemonContext pokemonContext;

        public HomeController(PokemonContext context)
        {
            pokemonContext = context;
        }

        public async Task<IActionResult> Index()
        {
            string userName = HttpContext.Session.GetString("Username");
            var vm = new HomeIndexVm
            {
                Username = userName
        };
            
            //enkel Bulbasaur en Charmander worden getoond omdat er maar 2 PokemonType queries zijn.
            //De andere moeten automatisch toegevoegd worden.
            var allPokemonWithTypes = await pokemonContext.Set<PokemonType>()
                                            .Include(pt => pt.Pokemon)//join
                                            .ThenInclude(p => p.PokemonTypes)
                                            .Include(pt => pt.Type)//join
                                            .ThenInclude(t => t.PokemonTypes)
                                            .ToListAsync();

            vm.AllPokemonWithTypeInfo = allPokemonWithTypes.Select(pt => pt.Pokemon);
            //vm.AllPokemonWithTypeInfo = await pokemonContext.Pokemons.ToListAsync();
            return View(vm);
        }

        public IActionResult Error(int? statusCode)
        {
            if (statusCode.HasValue)
            {
                if(statusCode == 404)
                {
                    string vn = $"Page{statusCode.ToString()}";
                    return View(vn);
                }
            }
            return View();
        }
    }
}