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
        private PasswordHasher pH = new PasswordHasher();
        private PokemonContext pokemonContext;

        public AccountController(PokemonContext context)
        {
            pokemonContext = context;
        }

        public IActionResult Login()
        {
            HttpContext.Session.Remove("Username");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(AccountLoginVm userData)
        {
            if (ModelState.IsValid)
            {
                var getUser = pokemonContext.Users.FirstOrDefault(u => u.Username == userData.Username);
                
                if (getUser != null && verifyPassword(getUser, userData.Password))
                {
                    HttpContext.Session.SetString("Username", getUser.Username);
                    if (userData.Username == "admin" && verifyPassword(getUser, userData.Password))
                    {
                        return RedirectToAction("Index", "Home", new { area = "Admin" });
                    }
                    
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
            HttpContext.Session.Remove("Username");
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
                        Password = userData.Password
                    };
                    pH.HashPassword(newUser, newUser.Password);
                    pokemonContext.Users.Add(newUser);
                    await pokemonContext.SaveChangesAsync();
                    HttpContext.Session.SetString("Username", newUser.Username);
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

        private bool verifyPassword(User user, string providedPW) => (pH.VerifyHashedPassword(user, user.Password, providedPW) == PasswordVerificationResult.Success);

        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login","Account",null);
        }
    }
}