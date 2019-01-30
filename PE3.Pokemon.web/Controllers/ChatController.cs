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
            allUsers = await FilterUserList(allUsers, userName);

            ChatIndexVm vm = new ChatIndexVm()
            {
                User = user,
                AllUsers = new SelectList(allUsers, "Id", "Username")
            };
            return View(vm);
        }

        private async Task<List<User>> FilterUserList(List<User> allUsers, string userName)
        {
            foreach (var item in allUsers)
            {
                if (item.Username == userName)
                {//eigen username verwijderen uit list en de loop stoppen.
                    allUsers.Remove(item);
                    break;
                }
            }

            var allUserChats = await pokemonContext.UserChats
                .Include(uc => uc.Chat).ThenInclude(c => c.UserChats)
                .Include(uc => uc.User).ThenInclude(u => u.UserChats)
                .Where(uc => uc.User.Username == userName).ToListAsync();

            var list = new List<User>();//bepalen met welke andere gebruikers je al een chat hebt
            foreach(var userchat in allUserChats)
            {
                var chat = userchat.Chat;
                foreach(var uc in chat.UserChats)
                {
                    if (uc.User.Username == userName) continue;
                    else list.Add(uc.User);
                }
            }

            foreach(var user in list) allUsers.Remove(user);
            return allUsers;//enkel de gebruikers waarmee je nog geen gesprek bent gestart
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
            var serializedReceiver = HttpContext.Session.GetString("ReceiverData");
            User chatReceiver = JsonConvert.DeserializeObject<User>(serializedReceiver);

            if (ModelState.IsValid)
            {
                string userName = HttpContext.Session.GetString("Username");
                User user = await pokemonContext.Users
                    .Where(u => u.Username == userName)
                    .FirstOrDefaultAsync();

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

                HttpContext.Session.SetString("ChatId", id.ToString());
                return new RedirectToActionResult("ChatWithName", "Chat", id);
            }
            vm.Receiver = chatReceiver;
            return View(vm);
        }

        public async Task<IActionResult> ChatWithName(Guid chatId)//is 000... na Redirect om de een of andere reden
        {
            string chatIdFromSession;
            if (chatId.ToString() == "00000000-0000-0000-0000-000000000000")
            {
                chatIdFromSession = HttpContext.Session.GetString("ChatId");
                if (chatIdFromSession != null) chatId = new Guid(chatIdFromSession);
            }
            HttpContext.Session.Remove("ChatId");

            string userName = HttpContext.Session.GetString("Username");
            var currentChat = await pokemonContext.Chats
                    .Include(c => c.Messages).ThenInclude(m => m.Sender)
                    .Include(c => c.UserChats)
                    .Where(c => c.Id == chatId).FirstOrDefaultAsync();

            ChatWithNameVm vm = new ChatWithNameVm
            {
                Chat = currentChat,
                Username = userName
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChatWithName(ChatWithNameVm userdata)
        {
            if (ModelState.IsValid)
            {
                string userName = HttpContext.Session.GetString("Username");
                var me = await pokemonContext.Users
                    .Where(u => u.Username == userName).FirstOrDefaultAsync();

                Message message = new Message
                {
                    ChatId = userdata.Chat.Id,
                    Sender = me,
                    Text = userdata.Text,
                    SendDate = DateTime.Now
                };
                pokemonContext.Messages.Add(message);
                await pokemonContext.SaveChangesAsync();
                return new RedirectToActionResult("ChatWithName", "Chat", userdata.Chat.Id);
            }
            return View(userdata);
        }
    }
}