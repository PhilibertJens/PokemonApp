using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PE3.Pokemon.web
{
    public class LoginChecker: Controller //als er geen overerving is kun je HttpContext niet gebruiken
    {
        public bool UserIsLoggedIn()
        {
            string userName = HttpContext.Session.GetString("Username");//is momenteel altijd null, ook al bestaat de session
            return userName != null;//returned true als de user is ingelogd
        }
    }
}
