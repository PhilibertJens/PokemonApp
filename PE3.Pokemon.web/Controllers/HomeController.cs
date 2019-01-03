using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
                .Include(p => p.PokemonTypes).ThenInclude(pt => pt.Type)
                .Where(p => p.NDex == ndex)
                .FirstOrDefaultAsync();

            thisPoke.PokemonUsers = await pokemonContext.PokemonUsers
                .Include(pu => pu.User)
                .Where(pu => pu.PokemonId == thisPoke.Id && pu.User.Username == userName)
                .ToListAsync();

            short catches;
            if (thisPoke.PokemonUsers.FirstOrDefault() == null) catches = 0;
            else catches = thisPoke.PokemonUsers.FirstOrDefault().Catches;

            StringBuilder sb = new StringBuilder();
            var colors = new string[2];
            colors[0] = thisPoke.PokemonTypes.FirstOrDefault().Type.Colour;
            colors[1] = (thisPoke.PokemonTypes.Count < 2) ? colors[0] : thisPoke.PokemonTypes.ElementAtOrDefault(1).Type.Colour;
            foreach (var t in thisPoke.PokemonTypes) sb.Append($"{t.Type.Name} ");

            HomePokemonVm vm = new HomePokemonVm
            {
                SelectedPokemon = thisPoke, Catches = catches,
                Colors = colors, Sb = sb
            };

            return View(vm);
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

        private async Task<IEnumerable<MyPokemon>> getAllCaught(string username)
        {
            var numberOfPokemon = await pokemonContext.Set<PokemonUser>()
                    .Include(pu => pu.Pokemon).ThenInclude(p => p.PokemonUsers)
                    .Include(pu => pu.User).ThenInclude(u => u.PokemonUsers)
                    .Where(u => u.User.Username == username)
                    .CountAsync();

            List<MyPokemon> myPokemonList = new List<MyPokemon>();
            if (numberOfPokemon != 0)
            {
                var allPoke = await pokemonContext.Set<PokemonUser>()//all pokemonuser objects per current user
                    .Include(pu => pu.Pokemon).ThenInclude(p => p.PokemonUsers)
                    .Include(pu => pu.User).ThenInclude(u => u.PokemonUsers)
                    .Where(u => u.User.Username == username).ToListAsync();

                foreach (var el in allPoke) myPokemonList.Add(el.Pokemon);
            }
            else myPokemonList = new List<MyPokemon>();
            return myPokemonList;
        }
    }
}