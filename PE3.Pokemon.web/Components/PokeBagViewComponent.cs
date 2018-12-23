using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PE3.Pokemon.web.Data;
using PE3.Pokemon.web.Entities;
using PE3.Pokemon.web.Models;
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

                var vm = new PokebagVm();
                if (numberOfPokemon != 0)//als deze check niet gedaan wordt komt er een error wanneer je bag leeg is.
                {
                    vm.MostCaught = await _pokemonContext.Set<PokemonUser>()
                                            .Include(pu => pu.Pokemon).ThenInclude(p => p.PokemonUsers)
                                            .Include(pu => pu.User).ThenInclude(u => u.PokemonUsers)
                                            .Where(u => u.UserId == currentUser.Id)
                                            .OrderByDescending(pu => pu.Catches)
                                            .Take(3).ToListAsync();

                    vm.PokemonData = new Dictionary<string, short>();

                    foreach (var mc in vm.MostCaught)
                    {
                        vm.PokemonData.Add(mc.Pokemon.Name, mc.Catches);

                    }
                }
                else vm.MostCaught = new List<PokemonUser>();
                return View(vm);
            }
            else return View();
        }
    }
}
