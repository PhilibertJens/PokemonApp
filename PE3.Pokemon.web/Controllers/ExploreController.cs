using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PE3.Pokemon.web.Data;
using PE3.Pokemon.web.Entities;
using PE3.Pokemon.web.Models;
using Type = PE3.Pokemon.web.Entities.Type;//om een ambiguous reference naar 'Type' error te vermijden

namespace PE3.Pokemon.web.Controllers
{
    public class ExploreController : Controller
    {
        private PokemonContext pokemonContext;
        private Random random;

        public ExploreController(PokemonContext context)
        {
            pokemonContext = context;
            random = new Random();
        }

        public IActionResult WalkAround()
        {
            string userName = HttpContext.Session.GetString("Username");
            if (userName == null) return new RedirectToActionResult("Login", "Account", null);
            HttpContext.Session.Remove("PokemonData"); //bestaande Session wordt verwijderd
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
                PokemonSessionData pokemonData = new PokemonSessionData();
                pokemonData.Type = foundType.Name;
                string serializedPokemonData = JsonConvert.SerializeObject(pokemonData);
                HttpContext.Session.SetString("PokemonData", serializedPokemonData);
                return new RedirectToActionResult("GeneratePokemon", "Explore", null);
            }
            else return View(userData);
        }

        public async Task<IActionResult> GeneratePokemon()
        {
            MyPokemon appearedPokemon;
            PokemonSessionData pokemonData;
            string serializedPokemon, userName;

            userName = HttpContext.Session.GetString("Username");
            if (UserNameErrorCheck(userName)) return new RedirectToActionResult("Login", "Account", null);
            serializedPokemon = HttpContext.Session.GetString("PokemonData");
            if (PokemonErrorCheck(serializedPokemon)) return new RedirectToActionResult("Walkaround", "Explore", null);

            pokemonData = JsonConvert.DeserializeObject<PokemonSessionData>(serializedPokemon);
            var getType = pokemonContext.Types
                .Where(t => t.Name == pokemonData.Type).FirstOrDefault();
            if (pokemonData.Name == null)//er is nog geen pokemon gegenereerd. Is dit wel zo zal de bovenstaande terug getoond worden
            {
                appearedPokemon = await LetPokemonAppear(getType);
                serializedPokemon = HttpContext.Session.GetString("PokemonData");
                pokemonData = JsonConvert.DeserializeObject<PokemonSessionData>(serializedPokemon);
            }

            appearedPokemon = pokemonContext.Pokemons
                    .Where(p => p.Name == pokemonData.Name).FirstOrDefault();

            ExploreGeneratePokemonVm vm = new ExploreGeneratePokemonVm();
            vm.AppearedPokemon = appearedPokemon;
            vm.HP = pokemonData.HP;
            vm.Moves = pokemonData.Moves;
            vm.CheatingWarning = pokemonData.CheatingWarning;
            return View(vm);
        }

        public async Task<IActionResult> CatchProcesser()
        {
            string userName = HttpContext.Session.GetString("Username");
            if (UserNameErrorCheck(userName)) return new RedirectToActionResult("Login", "Account", null);
            string serializedPokemon = HttpContext.Session.GetString("PokemonData");
            if (PokemonErrorCheck(serializedPokemon)) return new RedirectToActionResult("Walkaround", "Explore", null);

            var pokemonData = JsonConvert.DeserializeObject<PokemonSessionData>(serializedPokemon);
            var getPokemon = pokemonContext.Pokemons
                    .Where(p => p.Name == pokemonData.Name).FirstOrDefault();

            int luckyNumber = random.Next(0,2);
            if (luckyNumber == 1)//50% dat de pokemon is gevangen.
            {
                pokemonData.Caught = true;/*om cheaten te vermijden*/
                string serializedPokemonData = JsonConvert.SerializeObject(pokemonData);
                HttpContext.Session.SetString("PokemonData", serializedPokemonData);


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
                vm.HP = pokemonData.HP;
                vm.Moves = pokemonData.Moves;
                return View(vm);
            }
        }

        public IActionResult Gotcha()
        {
            string userName = HttpContext.Session.GetString("Username");
            if (UserNameErrorCheck(userName)) return new RedirectToActionResult("Login", "Account", null);
            string serializedPokemon = HttpContext.Session.GetString("PokemonData");
            if(PokemonErrorCheck(serializedPokemon)) return new RedirectToActionResult("Walkaround", "Explore", null);
            var pokemonData = JsonConvert.DeserializeObject<PokemonSessionData>(serializedPokemon);

            if (!pokemonData.Caught)
            {/*de bool niet op true gezet in CatchProcesser. De user heeft dus gecheat*/
                pokemonData.CheatingWarning = "Professor Oak can't allow cheating!";
                string serializedPokemonData = JsonConvert.SerializeObject(pokemonData);
                HttpContext.Session.SetString("PokemonData", serializedPokemonData);
                return new RedirectToActionResult("GeneratePokemon", "Explore", null);
            }

            var getPokemon = pokemonContext.Pokemons
                    .Where(p => p.Name == pokemonData.Name).FirstOrDefault();
            ExploreGotchaVm vm = new ExploreGotchaVm();
            vm.Username = userName;
            vm.CaughtPokemon = getPokemon;
            return View(vm);
        }

        private bool UserNameErrorCheck(string userName)
        {
            return userName == null;
        }

        private bool PokemonErrorCheck(string serializedPokemon)
        {
            return serializedPokemon == null;
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
                                                                //HttpContext.Session.SetString("AppearedPokemon", appearedPokemon.Pokemon.Name);
                string serializedPokemon = HttpContext.Session.GetString("PokemonData");
                var pokemonData = JsonConvert.DeserializeObject<PokemonSessionData>(serializedPokemon);
                pokemonData.Name = appearedPokemon.Pokemon.Name;
                pokemonData.Id = appearedPokemon.Pokemon.Id;
                pokemonData.HP = 50; //dit wordt random bepaald
                pokemonData.Moves = new List<string> { "Bite", "Shadowball" };//dit wordt bepaald per type
                string serializedPokemonData = JsonConvert.SerializeObject(pokemonData);
                HttpContext.Session.SetString("PokemonData", serializedPokemonData);

                return appearedPokemon.Pokemon;
            }
            else return null;
        }

        private Type FindType(int environmentId, int timeId)
        {
            List<List<string>> environments = new List<List<string>>()
            {
                new List<string>(){ "Grass", "Fire", "Water", "Bug", "Normal" },//default
                new List<string>(){ "Grass", "Bug", "Psychic" },//forest
                new List<string>(){ "Water"},//sea
                new List<string>(){ "Fighting", "Electric", "Fire" },//city
                new List<string>(){ "Flying", "Dragon" },//sky
                new List<string>(){ "Grass", "Ground", "Rock", "Ice" },//mountain
                new List<string>(){ "Poison", "Bug", "Dragon", "Ghost" }//cave
            };
            List<List<string>> daytimes = new List<List<string>>()
            {
                new List<string>(){ "Water", "Bug" },//default
                new List<string>(){ "Normal", "Bug", "Psychic" },//morning
                new List<string>(){ "Normal" },//midday
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