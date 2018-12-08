using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PE3.Pokemon.web.Data;
using PE3.Pokemon.web.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PE3.Pokemon.web.Components
{
    [ViewComponent(Name = "PokeBag")]
    public class PokeBagViewComponent : ViewComponent
    {
        private PokemonContext _pokemonContext;
        public PokeBagViewComponent(PokemonContext context)
        {
            _pokemonContext = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            //----query in SSMS:----
            //select u.Username, p.Name, pu.Catches
            //from[dbo].[PokemonUsers] pu
            //join Pokemons p on pu.PokemonId = p.Id
            //join Users u on pu.UserId = u.Id
            //where u.Id = '10000000-0000-0000-0000-000000000000'
            //order by pu.Catches desc

            string userName = HttpContext.Session.GetString("Username");
            if (userName != null)
            {
                var currentUser = _pokemonContext.Users
                .Where(u => u.Username == userName).FirstOrDefault();

                var numberOfPokemon = await _pokemonContext.Set<PokemonUser>()
                    .Include(pu => pu.Pokemon).ThenInclude(p => p.PokemonUsers)
                    .Include(pu => pu.User).ThenInclude(u => u.PokemonUsers)
                    .Where(u => u.UserId == currentUser.Id)
                    .CountAsync();

                IDictionary<MyPokemon, PokemonUser> myPokemons;
                if (numberOfPokemon != 0)//als deze check niet gedaan wordt komt er een error wanneer je bag leeg is.
                {
                    var top3PokemonUser = await _pokemonContext.Set<PokemonUser>()
                    .Include(pu => pu.Pokemon).ThenInclude(p => p.PokemonUsers)
                    .Include(pu => pu.User).ThenInclude(u => u.PokemonUsers)
                    .Where(u => u.UserId == currentUser.Id)
                    .OrderByDescending(pu => pu.Catches)
                    .Take(3).ToListAsync();

                    myPokemons = new Dictionary<MyPokemon, PokemonUser>();
                    foreach (var o in top3PokemonUser)
                    {
                        myPokemons.Add(o.Pokemon, o);
                    }
                }
                else myPokemons = new Dictionary<MyPokemon, PokemonUser>();
                return View(myPokemons);
            }
            else return View(new Dictionary<MyPokemon, PokemonUser>());
        }
    }
}
