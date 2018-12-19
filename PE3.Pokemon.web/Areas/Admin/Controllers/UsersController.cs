using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PE3.Pokemon.web.Areas.Admin.Models;
using PE3.Pokemon.web.Data;

namespace PE3.Pokemon.web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersController : Controller
    {
        private PokemonContext _pokemonContext;
        private IHostingEnvironment _env;

        public UsersController(PokemonContext pokemonContext, IHostingEnvironment environment)
        {
            _pokemonContext = pokemonContext;
            _env = environment;
        }

        public IActionResult Index()
        {
            string username = HttpContext.Session.GetString("Username");
            if (username != "admin")
            {
                return RedirectToAction("Login", "Account", new { area = "" });
            }
            else
            {
                var usersIndexVm = new UsersIndexVm
                {
                    Users = _pokemonContext.Users
                    .OrderBy(u=>u.Username)
                    .ToList()
                };

                return View(usersIndexVm);
            }
        }
    }
}