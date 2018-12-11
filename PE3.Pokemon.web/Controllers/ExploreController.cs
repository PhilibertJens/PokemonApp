﻿using System;
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
         - redirect naar GeneratePokemon staat in commentaar tot er extra geseed wordt.
        */

        public ExploreController(PokemonContext context)
        {
            pokemonContext = context;
            random = new Random();
        }

        public IActionResult WalkAround()
        {
            HttpContext.Session.Remove("AppearedPokemon"); //bestaande Sessions worden verwijderd
            HttpContext.Session.Remove("ChosenType");
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
                Type foundType = FindType(userData.SelectedEnvironmentId, userData.SelectedDayTimeId);
                HttpContext.Session.SetString("ChosenType", foundType.Name);
                //return Content($"Found type: {foundType.Name}","text/html");//staat zo tot er nog extra PokemonTypes zijn toegevoegd
                return new RedirectToActionResult("GeneratePokemon", "Explore", null);
            }
            else return View(userData);
        }

        public async Task<IActionResult> GeneratePokemon()
        {
            MyPokemon appearedPokemon;
            string type = HttpContext.Session.GetString("ChosenType");
            var getType = pokemonContext.Types
                .Where(t => t.Name == type).FirstOrDefault();
            if (HttpContext.Session.GetString("AppearedPokemon") == null)//er is nog geen pokemon gegenereerd
            {
                appearedPokemon = await LetPokemonAppear(getType);
            }
            else
            {//vermijden dat de gebruiker de pagina refresht en een nieuwe pokemon krijgt
                string pokemonExists = HttpContext.Session.GetString("AppearedPokemon");
                appearedPokemon = pokemonContext.Pokemons
                        .Where(p => p.Name == pokemonExists).FirstOrDefault();
            }

            if (appearedPokemon != null)
            {
                ExploreGeneratePokemonVm vm = new ExploreGeneratePokemonVm();
                vm.AppearedPokemon = appearedPokemon;
                vm.HP = 50; //random bepaald
                vm.Moves = new List<string> { "flamethrower", "bite" }; //deels random bepaald
                return View(vm);
            }
            else return Content($"No pokemon was found with type {type}","text/html");
            //dit moet uiteindelijk verdwijnen. Dit kan pas wanneer er van elk type een pokemon is.
        }

        public async Task<IActionResult> CatchProcesser()
        {
            string appearedPokemon = HttpContext.Session.GetString("AppearedPokemon");
            var getPokemon = pokemonContext.Pokemons
                    .Where(p => p.Name == appearedPokemon).FirstOrDefault();

            int luckyNumber = random.Next(0,2);
            if (luckyNumber == 1)//50% dat de pokemon is gevangen.
            {
                string userName = HttpContext.Session.GetString("Username");

                var me = pokemonContext.Users
                    .Where(u => u.Username == userName).FirstOrDefault();
                try
                {
                    var alreadyCaught = pokemonContext.PokemonUsers
                                   .Where(pu => pu.UserId == me.Id && pu.PokemonId == getPokemon.Id).FirstOrDefault(); //user heeft resp pokemon al gevangen
                    alreadyCaught.Catches++;
                }
                catch (NullReferenceException)
                {//als de user nog geen pokemon van dit type heeft
                    PokemonUser pokemonUser = new PokemonUser()
                    {
                        PokemonId = getPokemon.Id,
                        UserId = me.Id,
                        Catches = 1
                    };
                    pokemonContext.PokemonUsers.Add(pokemonUser);
                }
                await pokemonContext.SaveChangesAsync();
                return new RedirectToActionResult("Gotcha", "Explore", null);
            }
            else
            {//de pokemon is niet gevangen. Dezelfde pagina wordt opnieuw getoond tot de pokemon is gevangen
                ExploreGeneratePokemonVm vm = new ExploreGeneratePokemonVm();
                vm.AppearedPokemon = getPokemon;
                vm.HP = 50; //random bepaald
                vm.Moves = new List<string> { "flamethrower", "bite" }; //deels random bepaald
                return View(vm);
            }
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

        private async Task<MyPokemon> LetPokemonAppear(Type type)
        {
            var givePokemonType = await pokemonContext.Set<PokemonType>()//een join van Pokemon, PokemonType en Type
                                            .Include(pt => pt.Pokemon)
                                            .ThenInclude(p => p.PokemonTypes)
                                            .Where(p => p.Type.Name.ToLower() == type.Name.ToLower())
                                            .Include(pt => pt.Type)
                                            .ThenInclude(t => t.PokemonTypes)
                                            .ToListAsync();
            int max = givePokemonType.Count();
            if (max != 0)
            {
                int listItem = random.Next(0, max);
                var appearedPokemon = givePokemonType[listItem];//geeft een Pokemon met type. Moet omgezet worden naar een Pokemon
                HttpContext.Session.SetString("AppearedPokemon", appearedPokemon.Pokemon.Name);
                return appearedPokemon.Pokemon;
            }
            else return null;
        }

        private Type FindType(int environmentId, int timeId)
        {
            List<List<string>> environments = new List<List<string>>()
            {
                new List<string>(){ "Grass", "Bug", "Normal" },//default
                new List<string>(){ "Grass", "Bug", "Psychic" },//forest
                new List<string>(){ "Water"},//sea
                new List<string>(){ "Normal", "Fighting", "Electric", "Fire" },//city
                new List<string>(){ "Flying", "Dragon" },//sky
                new List<string>(){ "Grass", "Ground", "Rock", "Ice" },//mountain
                new List<string>(){ "Poison", "Bug", "Dragon", "Ghost" }//cave
            };
            List<List<string>> daytimes = new List<List<string>>()
            {
                new List<string>(){ "Grass", "Bug" },//default
                new List<string>(){ "Normal", "Bug", "Psychic" },//morning
                new List<string>(){ "Water", "Grass", "Fire" },//midday
                new List<string>(){ "Normal", "Ghost" },//evening
                new List<string>(){ "Normal", "Ghost" },//midnight
            };
            List<string> typesPerEnvironment = environments[environmentId];
            List<string> typesPerDaytime = daytimes[timeId];
            List<string> summary = new List<string>();
            foreach (string type in typesPerEnvironment) summary.Add(type);
            foreach (string type in typesPerDaytime) summary.Add(type);

            string selectedType = summary[random.Next(0, summary.Count())];
            var getType = pokemonContext.Types
                .Where(t => t.Name == selectedType).FirstOrDefault();
            return getType;
        }
    }
}