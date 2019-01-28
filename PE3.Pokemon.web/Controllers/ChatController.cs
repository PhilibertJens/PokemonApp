using System;
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

namespace PE3.Pokemon.web.Controllers
{
    public class ChatController : Controller
    {
        private PokemonContext pokemonContext;

        public ChatController(PokemonContext context)
        {
            pokemonContext = context;
        }

        public async Task<IActionResult> Index()
        {
            string userName = HttpContext.Session.GetString("Username");

            User user = await pokemonContext.Users
                .Where(u => u.Username == userName)
                .FirstOrDefaultAsync();

            var allUsers = await pokemonContext.Users.ToListAsync();
            foreach (var item in allUsers)
            {
                if (item.Username == userName)
                {//eigen username verwijderen uit list en de loop stoppen.
                    allUsers.Remove(item);
                    break;
                }
            }

            var allUserChatsForUser = await pokemonContext.UserChats
                .Include(uc => uc.Chat).ThenInclude(c => c.UserChats)
                .Include(uc => uc.User).ThenInclude(u => u.UserChats)
                .Where(uc => uc.User.Username == userName)
                .Select(uc => uc.Chat).ToListAsync();

            ChatIndexVm vm = new ChatIndexVm()
            {
                AllUserChatsForUser = allUserChatsForUser,
                User = user,
                AllUsers = new SelectList(allUsers, "Id", "Username")
            };

            return View(vm);
        }
    }
}