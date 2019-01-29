using Microsoft.AspNetCore.Mvc.Rendering;
using PE3.Pokemon.web.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PE3.Pokemon.web.Models
{
    public class ChatIndexVm
    {
        public User User { get; set; }
        //public ICollection<User> AllUsers { get; set; }
        public ICollection<Chat> AllUserChatsForUser { get; set; }

        [Required]
        public Guid SelectedUserId { get; set; }
        public SelectList AllUsers { get; set; }
    }
}
