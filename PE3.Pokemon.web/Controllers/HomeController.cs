using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            HomeIndexVm vm = new HomeIndexVm();
            //var allPokemonTypes = await pokemonContext.Set<PokemonType>()
            //                                .Include(pt => pt.Pokemon)
            //                                .Include(pt => pt.Type)
            //                                .ToListAsync();

            //vm.AllPokemonWithTypeInfo = allPokemonTypes.Select(pt => pt.Pokemon);
            vm.AllPokemonWithTypeInfo = await pokemonContext.Pokemons.ToListAsync();
            return View(vm);
        }
    }
}