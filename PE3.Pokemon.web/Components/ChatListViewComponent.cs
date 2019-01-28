using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PE3.Pokemon.web.Data;
using PE3.Pokemon.web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PE3.Pokemon.web.Components
{
    [ViewComponent(Name = "ChatList")]
    public class ChatListViewComponent: ViewComponent
    {
        private PokemonContext _pokemonContext;
        public ChatListViewComponent(PokemonContext context)
        {
            _pokemonContext = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            string userName = HttpContext.Session.GetString("Username");
            var allUserChatsForUser = await _pokemonContext.UserChats
                .Include(uc => uc.Chat).ThenInclude(c => c.UserChats)
                .Include(uc => uc.User).ThenInclude(u => u.UserChats)
                .Where(uc => uc.User.Username == userName)
                .Select(uc => uc.Chat).ToListAsync();

            //if(allUserChatsForUser.Count() == 0)
            //{

            //}

            AllChatsForUserVm vm = new AllChatsForUserVm
            {
                ListChats = allUserChatsForUser
            };
            return View(vm);
        }
    }
}
