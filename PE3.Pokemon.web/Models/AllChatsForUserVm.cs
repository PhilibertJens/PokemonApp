﻿using PE3.Pokemon.web.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PE3.Pokemon.web.Models
{
    public class AllChatsForUserVm
    {
        public string Username { get; set; }
        public ICollection<Chat> ListChats { get; set; }
    }
}
