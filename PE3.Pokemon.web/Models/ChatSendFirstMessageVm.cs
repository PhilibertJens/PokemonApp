using PE3.Pokemon.web.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PE3.Pokemon.web.Models
{
    public class ChatSendFirstMessageVm
    {
        public Guid SenderId { get; set; }
        public User Sender { get; set; }
        public string Text { get; set; }
        public DateTime SendDate { get; set; }
        public User Receiver { get; set; }
    }
}
