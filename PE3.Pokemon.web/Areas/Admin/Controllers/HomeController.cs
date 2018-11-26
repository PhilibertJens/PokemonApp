using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PE3.Pokemon.web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            string userName = HttpContext.Session.GetString("Username");
            if (userName != "admin")
            {
                return RedirectToAction("Login", "Account", new { area = "" });
            }

            return View();
        }
    }
}