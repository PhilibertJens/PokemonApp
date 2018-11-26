using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        // GET: Pokemons/Details
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
        // GET: Pokemons/Edit
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pokemon = _pokemonContext.Pokemons
                                        .Include(p => p.PokemonTypes)
                                        .SingleOrDefault(p => p.Id == id);
            PopulateAssignedTypeData(pokemon);

            if (pokemon == null)
            {
                return NotFound();
            }
            var pokemonEditVm = new PokemonEditVm
            {
                Id = pokemon.Id,
                HasAllolanForm = pokemon.HasAllolanForm,
                ImgUrl = pokemon.ImgUrl,
                Description = pokemon.Description,
                location = pokemon.Location,
                Name = pokemon.Name,

            };
            return View(pokemonEditVm);
        }

        // POST: Pokemons/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id,PokemonEditVm pokemonEditVm, string[] selectedTypes)
        {
            if (id != pokemonEditVm.Id)
            {
                return NotFound();
            }
            var pokemonToUpdate = _pokemonContext.Pokemons
                    .Include(p => p.PokemonTypes)
                    .ThenInclude(pt => pt.Type)
                    .Where(p => p.Id == id)
                    .Single();


            if (ModelState.IsValid)
            {
                try
                {
                    pokemonToUpdate.Name = pokemonEditVm.Name;
                    pokemonToUpdate.Location = pokemonEditVm.location;
                    pokemonToUpdate.Description = pokemonEditVm.Description;
                    pokemonToUpdate.HasAllolanForm = pokemonEditVm.HasAllolanForm;

                    if (pokemonEditVm.UploadedImage !=null)
                    {
                        DeletePokeImage(pokemonToUpdate);
                        pokemonToUpdate.ImgUrl = SavePokeImg(pokemonEditVm.UploadedImage);
                    }

                    UpdatePokemonTypes(selectedTypes, pokemonToUpdate);
                    _pokemonContext.Update(pokemonToUpdate);
                    _pokemonContext.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PokemonExists(pokemonEditVm.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            PopulateAssignedTypeData(pokemonToUpdate);
            return View(pokemonEditVm);
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

        private bool PokemonExists(Guid id)
        {
            return _pokemonContext.Pokemons.Any(p => p.Id == id);
        }

        private void UpdatePokemonTypes(string[] selectedTypes,MyPokemon pokemonToUpdate)
        {
            if (selectedTypes == null)
            {
                pokemonToUpdate.PokemonTypes = new List<PokemonType>();
                return;
            }
            var selectedPokemonHS = new HashSet<string>(selectedTypes);

            IEnumerable<Guid> pokemonTypes = pokemonToUpdate.PokemonTypes.Select(pt => pt.TypeId);

            List<PokemonType> newLink = new List<PokemonType>();

            foreach (var type in _pokemonContext.Types)
            {
                if (selectedPokemonHS.Contains(type.Id.ToString()))
                {
                    if (!pokemonTypes.Contains(type.Id))
                    {
                        var foo = new PokemonType { TypeId = type.Id, PokemonId = pokemonToUpdate.Id, Pokemon = pokemonToUpdate, Type = type };
                        newLink.Add(foo);
                    }
                }

                else
                {
                    if (pokemonTypes.Contains(type.Id))
                    {
                        foreach (var pokemonType in _pokemonContext.PokemonTypes)
                        {
                            if (pokemonType.TypeId == type.Id)
                            {
                                pokemonToUpdate.PokemonTypes.Remove(pokemonType);
                            }
                        }
                    }
                }
            }

            foreach (var pokemonType in newLink)
            {
                _pokemonContext.Add(pokemonType);
            }
            _pokemonContext.SaveChanges();

        }
        #endregion
    }
}