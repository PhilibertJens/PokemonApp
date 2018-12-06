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
            var top3PokemonUser = await _pokemonContext.Set<PokemonUser>()
                .Join(_pokemonContext.Pokemons, pu => pu.PokemonId, p => p.Id, (pu, p) => new { PokemonUser = pu, MyPokemon = p })
                .OrderByDescending(x => x.PokemonUser.Catches)
                .Take(3)
                .Where(pup => pup.PokemonUser.PokemonId == pup.MyPokemon.Id)
                .ToListAsync();

            IDictionary<MyPokemon,PokemonUser> myPokemons = new Dictionary<MyPokemon,PokemonUser>();
            foreach(var o in top3PokemonUser)
            {
                myPokemons.Add(o.MyPokemon,o.PokemonUser);
            }

                
            return View(myPokemons);
        }
    }
}
