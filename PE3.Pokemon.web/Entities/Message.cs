using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PE3.Pokemon.web.Entities
{
    public class Message
    {
        public Guid Id { get; set; }
        public Guid ChatId { get; set; }
        public Guid SenderId { get; set; }

        public string Text { get; set; }
        public string ImageName { get; set; }

        public DateTime SendDate { get; set; }

        /*Navigation properties*/
        public Chat Chat { get; set; }
        public User Sender { get; set; }
    }
}
