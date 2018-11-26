using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PE3.Pokemon.web.Data;
using PE3.Pokemon.web.Entities;
using PE3.Pokemon.web.Models;
using Microsoft.AspNetCore.Http;

namespace PE3.Pokemon.web.Controllers
{
    public class AccountController : Controller
    {
        private PokemonContext pokemonContext;

        public AccountController(PokemonContext context)
        {
            pokemonContext = context;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(AccountLoginVm userData)
        {
            if (ModelState.IsValid)
            {
                //var getUser = await pokemonContext.Users.FindAsync(userData.Username);

                var getUser = pokemonContext.Users.FirstOrDefault(u => u.Username == userData.Username);
                if (getUser != null && getUser?.Password == userData.Password)
                {
                    HttpContext.Session.SetString("Username", getUser.Username);
                    return new RedirectToActionResult("Index", "Home", null);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Username or password is incorrect. Professor Oak can't remember you.");
                    return View(userData);
                }
                
            }
            else return View(userData);
        }

        public IActionResult Registration()
        {
            AccountRegistrationVm vm = new AccountRegistrationVm();
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registration(AccountRegistrationVm userData)
        {
            if (ModelState.IsValid)
            {
                var getUser = pokemonContext.Users.FirstOrDefault(u => u.Username == userData.Username);
                if (getUser == null)
                {
                    User newUser = new User()
                    {
                        FirstName = userData.FirstName,
                        LastName = userData.LastName,
                        Username = userData.Username,
                        Password = userData.Password //moet eigenlijk een hashwaarde zijn.
                    };
                    //PasswordHasher passwordHasher = new PasswordHasher();
                    //passwordHasher.HashPassword(newUser, newUser.Password);
                    pokemonContext.Users.Add(newUser);
                    await pokemonContext.SaveChangesAsync();
                    return new RedirectToActionResult("RegisterSuccess", "Account", null);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "A trainer with that username already exists");
                    return View(userData);
                }

            }
            else return View(userData);
        }

        public IActionResult RegisterSuccess()
        {
            return View();
        }
    }
}