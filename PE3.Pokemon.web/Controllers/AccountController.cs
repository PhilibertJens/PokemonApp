using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PE3.Pokemon.web.Models;

namespace PE3.Pokemon.web.Controllers
{
    public class AccountController : Controller
    {
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
                return new RedirectToActionResult("Index", "Home", null);
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
        public IActionResult Registration(AccountRegistrationVm userData)
        {
            if (ModelState.IsValid)
            {
                return new RedirectToActionResult("RegisterSuccess", "Account", null);
            }
            else return View(userData);
        }

        public IActionResult RegisterSuccess()
        {
            return View();
        }
    }
}