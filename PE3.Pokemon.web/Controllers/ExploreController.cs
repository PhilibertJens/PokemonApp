using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PE3.Pokemon.web.Data;
using PE3.Pokemon.web.Entities;
using PE3.Pokemon.web.Models;
using Type = PE3.Pokemon.web.Entities.Type;

namespace PE3.Pokemon.web.Controllers
{
    public class ExploreController : Controller
    {
        private PokemonContext pokemonContext;
        private Random random;
        /*
         Nog te fixen:
         - opslaan van ExploreGeneratePokemonVm viewModel in session i.p.v. string value
         - type bepalen a.d.h.v. omgeving en tijdstip via een switch statement.
         - er komt een error als de pokemon een tweede keer wordt gevangen (duplicate PK). 
           Het databasemodel moet gewijzigd worden.
        */

        public ExploreController(PokemonContext context)
        {
            pokemonContext = context;
            random = new Random();
        }

        public IActionResult WalkAround()
        {
            var listEnvironments = new List<SelectListItem> {
                new SelectListItem { Value = "0", Text = "== Where are you? ==" },
                new SelectListItem { Value = "1", Text = "In a forest" },
                new SelectListItem { Value = "2", Text = "In the deep sea" },
                new SelectListItem { Value = "3", Text = "In the busy street of the city" },
                new SelectListItem { Value = "4", Text = "High in the sky" },
                new SelectListItem { Value = "5", Text = "In the mountains" },
                new SelectListItem { Value = "6", Text = "In a dark cave" }
            };

            var listDayTime = new List<SelectListItem> {
                new SelectListItem { Value = "0", Text = "== When are you? ==" },
                new SelectListItem { Value = "1", Text = "Morning" },
                new SelectListItem { Value = "2", Text = "Midday" },
                new SelectListItem { Value = "3", Text = "Evening" },
                new SelectListItem { Value = "4", Text = "Midnight" }
            };
            ExploreWalkAroundVm vm = new ExploreWalkAroundVm();
            vm.SelectedEnvironmentId = 0;
            vm.Environments = listEnvironments;
            vm.DayTime = listDayTime;
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult WalkAround(ExploreWalkAroundVm userData)//bevat een omgeving en tijdstip
        {
            if (ModelState.IsValid)
            {
                //switch statement dat bepaald welk type is gekoppeld aan omgeving en tijdstip
                HttpContext.Session.SetString("ChosenType", "Fire");//opslaan van Type
                return new RedirectToActionResult("GeneratePokemon", "Explore", null);
            }
            else return View(userData);
        }

        public async Task <IActionResult> GeneratePokemon()
        {
            string type = HttpContext.Session.GetString("ChosenType");
            var getType = pokemonContext.Types
                .Where(t => t.Name == type).FirstOrDefault();
            var appearedPokemon = await LetPokemonAppear(getType);//random pokemon met dit type

            ExploreGeneratePokemonVm vm = new ExploreGeneratePokemonVm();
            vm.AppearedPokemon = appearedPokemon;
            vm.HP = 50; //random bepaald
            vm.Moves = new List<string> { "flamethrower", "bite" }; //deels random bepaald
            return View(vm);
        }

        public async Task<IActionResult> CatchProcesser()
        {
            int luckyNumber = random.Next(0, 2);
            if (luckyNumber == 1)//50% dat de pokemon is gevangen.
            {
                //data ophalen uit sessions
                string userName = HttpContext.Session.GetString("Username");
                string appearedPokemon = HttpContext.Session.GetString("AppearedPokemon");

                userName = "jensph";//vervang dit door gebruiker uit eigen database.
                                    //Dit staat er om niet elke keer te moeten inloggen

                //data ophalen uit database a.d.h.v. session data
                var getPokemon = pokemonContext.Pokemons
                    .Where(p => p.Name == appearedPokemon).FirstOrDefault();
                var me = pokemonContext.Users
                    .Where(u => u.Username == userName).FirstOrDefault();

                PokemonUser pokemonUser = new PokemonUser()
                {
                    Pokemon = getPokemon,
                    PokemonId = getPokemon.Id,
                    User = me,
                    UserId = me.Id
                };

                pokemonContext.PokemonUsers.Add(pokemonUser);
                await pokemonContext.SaveChangesAsync();
                return new RedirectToActionResult("Gotcha", "Explore", null);
            }
            else
            {//de pokemon is niet gevangen. Dezelfde pagina wordt opnieuw getoond tot de pokemon is gevangen
                ExploreGeneratePokemonVm vm = new ExploreGeneratePokemonVm();
                string appearedPokemon = HttpContext.Session.GetString("AppearedPokemon");
                var getPokemon = pokemonContext.Pokemons
                    .Where(p => p.Name == appearedPokemon).FirstOrDefault();
                vm.AppearedPokemon = getPokemon;
                vm.HP = 50; //random bepaald
                vm.Moves = new List<string> { "flamethrower", "bite" }; //deels random bepaald
                return View(vm);
            }
        }


        private async Task<MyPokemon> LetPokemonAppear(Type type)
        {
            var givePokemonType = await pokemonContext.Set<PokemonType>()//een join van Pokemon, PokemonType en Type
                                            .Include(pt => pt.Pokemon)
                                            .ThenInclude(p => p.PokemonTypes)
                                            .Where(p => p.Type.Name.ToLower() == "fire")//zal tot nu toe altijd Charmander teruggeven.
                                            .Include(pt => pt.Type)
                                            .ThenInclude(t => t.PokemonTypes)
                                            .ToListAsync();
            int max = givePokemonType.Count();
            int listItem = random.Next(0, max);
            var appearedPokemon = givePokemonType[listItem];//geeft een Pokemon met type. Moet omgezet worden naar een Pokemon

            MyPokemon getPokemon = new MyPokemon()
            {
                Id = new Guid("00000000-0000-0000-0000-000000000004"),
                Name = "Charmander",
                ImgUrl = "Charmander.png"
            };//moet een query zijn om Pokemon te selecteren
            HttpContext.Session.SetString("AppearedPokemon", getPokemon.Name);
            return getPokemon;
        }

        public IActionResult Gotcha()
        {
            string userName = HttpContext.Session.GetString("Username");
            string appearedPokemon = HttpContext.Session.GetString("AppearedPokemon");
            var getPokemon = pokemonContext.Pokemons
                    .Where(p => p.Name == appearedPokemon).FirstOrDefault();
            ExploreGotchaVm vm = new ExploreGotchaVm();
            vm.Username = userName;
            vm.CaughtPokemon = getPokemon;
            return View(vm);
        }
    }
}