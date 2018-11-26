using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PE3.Pokemon.web.Areas.Admin.Models;
using PE3.Pokemon.web.Data;
using PE3.Pokemon.web.Entities;



namespace PE3.Pokemon.web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PokemonsController : Controller
    {
        private PokemonContext _pokemonContext;
        private IHostingEnvironment _env;

        public PokemonsController(PokemonContext pokemonContext, IHostingEnvironment environment)
        {
            _pokemonContext = pokemonContext;
            _env = environment;
        }

        // GET: Pokemons
        public ActionResult Index()
        {
            string username = HttpContext.Session.GetString("Username");
            if (username !="admin")
            {
                return RedirectToAction("Login", "Account", new { area = "" });
            }
            else
            {
                var pokemonIndexVm = new PokemonsIndexVm
                {
                    Pokemons = _pokemonContext.Pokemons
                    .OrderBy(p => p.Name)
                    .ToList()
                };

                return View(pokemonIndexVm);
            }
            
        }

        // GET: Pokemons/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id==null)
            {
                return NotFound();
            }

            var pokemon = _pokemonContext.Pokemons
                .SingleOrDefault(p => p.Id == id);

            if (pokemon==null)
            {
                return NotFound();
            }

            var pokemonDetailsVm = new PokemonDetailsVm
            {
                Id = id,
                Pokemon = pokemon
            };


            return View(pokemonDetailsVm);
        }
        // create logic should be done
        #region create
        // GET: Pokemons/Create
        public ActionResult Create()
        {
            var pokemon = new MyPokemon();
            var pokemonCreateVm = new PokemonCreateVm();

            pokemon.PokemonTypes = new List<PokemonType>();
            PopulateAssignedTypeData(pokemon);

            return View(pokemonCreateVm);
        }

        // POST: Pokemons/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PokemonCreateVm pokemonCreateVm, MyPokemon createdPokemon, string[] selectedTypes)
        {
            createdPokemon = new MyPokemon
            {
                Name = pokemonCreateVm.Name,
                HasAllolanForm = pokemonCreateVm.HasAllolanForm,
                ImgUrl = pokemonCreateVm.ImgUrl,
                Description = pokemonCreateVm.Description,
                Location = pokemonCreateVm.location

            };

            if (selectedTypes!= null)
            {
                createdPokemon.PokemonTypes = new List<PokemonType>();
                foreach (var type in selectedTypes)
                {
                    var typeToAdd = _pokemonContext.Types.Find(Guid.Parse(type));
                    var foo = new PokemonType { TypeId = typeToAdd.Id, PokemonId = createdPokemon.Id, Type = typeToAdd };
                    createdPokemon.PokemonTypes.Add(foo);
                }
            }

            if (ModelState.IsValid)
            {
                createdPokemon.ImgUrl = SavePokeImg(pokemonCreateVm.UploadedImage);
                _pokemonContext.Add(createdPokemon);
                _pokemonContext.SaveChanges();
                return (RedirectToAction("Index"));
            }
            PopulateAssignedTypeData(createdPokemon);
            return View(pokemonCreateVm);

        }
        #endregion

        #region edit
        // GET: Pokemons/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Pokemons/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        #endregion

        //delete logic should be done
        #region Delete
        // GET: Pokemons/Delete
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pokemon = _pokemonContext.Pokemons
                .SingleOrDefault(p => p.Id == id);

            if (pokemon == null)
            {
                return NotFound();
            }

            var pokemomDeleteVm = new PokemonDeleteVm
            {
                Id = id,
                Pokemon = pokemon
            };
            return View(pokemomDeleteVm);
        }

        // POST: Pokemons/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id)
        {
            var pokemon = _pokemonContext.Pokemons
                                        .SingleOrDefault(p => p.Id == id);

            DeletePokeImage(pokemon);

            _pokemonContext.Pokemons.Remove(pokemon);
            _pokemonContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region helperMethods
        private void DeletePokeImage(MyPokemon pokemon)
        {
            if (!string.IsNullOrWhiteSpace(pokemon?.ImgUrl))
            {
                string deletePath = Path.Combine(_env.WebRootPath, "images", "PokeImages", pokemon?.ImgUrl);
                System.IO.File.Delete(deletePath);
            }
        }

        private string SavePokeImg(IFormFile file)
        {
            string uniqueFileName = Guid.NewGuid().ToString("N") + file.FileName;
            string savePath = Path.Combine(_env.WebRootPath, "images", "PokeImages", uniqueFileName);

            using(var newFileStream = new FileStream(savePath, FileMode.Create))
            {
                file.CopyTo(newFileStream);
            }
            return uniqueFileName;
        }

        private void PopulateAssignedTypeData(MyPokemon pokemon)
        {
            var allTypes = _pokemonContext.Types;
            var pokemonTypes = new HashSet<Guid>(pokemon.PokemonTypes.Select(pt => pt.TypeId));
            var vm = new List<AssignedTypeDataVm>();

            foreach (var type in allTypes)
            {
                vm.Add(new AssignedTypeDataVm
                {
                    TypeId = type.Id,
                    TypeName = type.Name,
                    Assigned = pokemonTypes.Contains(type.Id)
                });
            }
            ViewBag.Types = vm;
        }
        #endregion
    }
}