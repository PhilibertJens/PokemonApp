using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(ChatIndexVm userdata)
        {
            if (ModelState.IsValid)
            {
                User selectedUser = await pokemonContext.Users
                .Where(u => u.Id == userdata.SelectedUserId)
                .FirstOrDefaultAsync();
                string serializedReceiver = JsonConvert.SerializeObject(selectedUser);
                HttpContext.Session.SetString("ReceiverData", serializedReceiver);
                return new RedirectToActionResult("SendFirstMessage", "Chat", null);
            }

            return View(userdata);
        }

        public IActionResult SendFirstMessage()
        {
            var serializedReceiver = HttpContext.Session.GetString("ReceiverData");
            User ChatReceiver = JsonConvert.DeserializeObject<User>(serializedReceiver);

            ChatSendFirstMessageVm vm = new ChatSendFirstMessageVm()
            {
                Receiver = ChatReceiver
            };
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SendFirstMessage(ChatSendFirstMessageVm vm)
        {
            if (ModelState.IsValid)
            {
                string userName = HttpContext.Session.GetString("Username");
                User user = await pokemonContext.Users
                    .Where(u => u.Username == userName)
                    .FirstOrDefaultAsync();

                var serializedReceiver = HttpContext.Session.GetString("ReceiverData");
                User chatReceiver = JsonConvert.DeserializeObject<User>(serializedReceiver);

                var chatName = userName + ", " + chatReceiver.Username;
                Chat chat = new Chat
                {
                    Name = chatName,
                    CreatorId = user.Id,
                    CreateDate = DateTime.Now,
                    LastMessage = vm.Text,
                    NumberOfUsers = 2,
                    NumberOfMessages = 2
                };
                pokemonContext.Chats.Add(chat);
                var id = chat.Id;

                UserChat userChat = new UserChat
                {
                    Chat = chat,
                    User = user
                };
                pokemonContext.UserChats.Add(userChat);

                UserChat userChat2 = new UserChat
                {
                    Chat = chat,
                    UserId = chatReceiver.Id
                };
                pokemonContext.UserChats.Add(userChat2);

                Message message = new Message
                {
                    ChatId = id,
                    Sender = user,
                    Text = vm.Text,
                    SendDate = DateTime.Now
                };
                pokemonContext.Messages.Add(message);
                await pokemonContext.SaveChangesAsync();
                return new RedirectToActionResult("Index", "Chat", null);
            }
            return View(vm);
        }


    }
}