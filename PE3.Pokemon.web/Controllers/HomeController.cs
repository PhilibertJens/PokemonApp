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
            if (userName == null) return new RedirectToActionResult("Login", "Account", null);
            var vm = new HomeIndexVm
            {
                Username = userName
            };
           
            var allPokemonWithTypes = await pokemonContext.Set<PokemonType>()
                                            .Include(pt => pt.Pokemon)//join
                                            .ThenInclude(p => p.PokemonTypes)
                                            .Include(pt => pt.Type)//join
                                            .ThenInclude(t => t.PokemonTypes)
                                            .ToListAsync();

            vm.AllPokemonWithTypeInfo = allPokemonWithTypes.Select(pt => pt.Pokemon);
            vm.AllCaughtPokemon = await getAllCaught(userName);
            return View(vm);
        }

        public async Task<IActionResult> Pokemon(short ndex)
        {
            string userName = HttpContext.Session.GetString("Username");
            if (userName == null) return new RedirectToActionResult("Login", "Account", null);

            var thisPoke = await pokemonContext.Pokemons
                .Where(p => p.NDex == ndex)
                .FirstOrDefaultAsync();

            thisPoke.PokemonTypes = await pokemonContext.PokemonTypes
                .Where(pt => pt.PokemonId == thisPoke.Id)
                .Include(pt => pt.Type)
                .ToListAsync();

            thisPoke.PokemonUsers = await pokemonContext.PokemonUsers
                .Where(pu => pu.PokemonId == thisPoke.Id)
                .ToListAsync();

            return View(thisPoke);
        }

        public IActionResult Error(int? statusCode) //refactor to simplicity/more use
        {
            string userName = HttpContext.Session.GetString("Username");
            if (userName == null) return new RedirectToActionResult("Login", "Account", null);

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

        private async Task<IDictionary<MyPokemon, PokemonUser>> getAllCaught(string username)
        {
            var numberOfPokemon = await pokemonContext.Set<PokemonUser>()
                    .Include(pu => pu.Pokemon).ThenInclude(p => p.PokemonUsers)
                    .Include(pu => pu.User).ThenInclude(u => u.PokemonUsers)
                    .Where(u => u.User.Username == username)
                    .CountAsync();

            IDictionary<MyPokemon, PokemonUser> myPokemons;
            if(numberOfPokemon != 0)
            {
                var allPoke = await pokemonContext.Set<PokemonUser>()//all pokemonuser objects per current user
                    .Include(pu => pu.Pokemon).ThenInclude(p => p.PokemonUsers)
                    .Include(pu => pu.User).ThenInclude(u => u.PokemonUsers)
                    .Where(u => u.User.Username == username).ToListAsync();
                myPokemons = new Dictionary<MyPokemon, PokemonUser>();
                foreach (var o in allPoke)
                {
                    myPokemons.Add(o.Pokemon, o);
                }
            }
            else myPokemons = new Dictionary<MyPokemon, PokemonUser>();

            return myPokemons;
        }
    }
}