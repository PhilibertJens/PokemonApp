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

        public ExploreController(PokemonContext context)
        {
            pokemonContext = context;
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
                //query om type te selecteren en typenaam mee te geven met de session.
                HttpContext.Session.SetString("ChosenType", "fire");//opslaan van omgeving en tijdstip
                return new RedirectToActionResult("GeneratePokemon", "Explore", null);
            }
            else return View(userData);
        }

        public async Task <IActionResult> GeneratePokemon()
        {
            string type = HttpContext.Session.GetString("ChosenType");//opvangen van omgeving en tijdstip
            Type myType = new Type()//query om type te selecteren a.d.h.v. typenaam uit session.
            {
                Name = "Fire"
            };
            var appearedPokemon = await LetPokemonAppear(myType);//random pokemon met dit type

            ExploreGeneratePokemonVm vm = new ExploreGeneratePokemonVm();
            vm.AppearedPokemon = appearedPokemon;
            vm.HP = 50; //random bepaald
            vm.Moves = new List<string> { "flamethrower", "bite" }; //deels random bepaald

            return View(vm);//file met javascript om pokemon te vangen (vb. klikken op image, pokebal drag/drop,...)
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
            Random random = new Random();
            int max = givePokemonType.Count();
            int listItem = random.Next(0, max);
            var appearedPokemon = givePokemonType[listItem];//geeft een Pokemon met type. Moet omgezet worden naar een Pokemon

            MyPokemon getPokemon = new MyPokemon()
            {
                Name = "Charmander",
                ImgUrl = "Charmander.png"
            };//moet een query zijn om Pokemon te selecteren 

            HttpContext.Session.SetString("AppearedPokemon", getPokemon.Name);//naam wordt opgeslaan. Kun je een object opslaan?

            return getPokemon;
        }
    }
}