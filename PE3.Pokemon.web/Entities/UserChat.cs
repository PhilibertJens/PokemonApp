using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PE3.Pokemon.web.Entities
{
    public class UserChat
    {
        public Guid ChatId { get; set; }
        public Guid UserId { get; set; }

        /*Navigation properties*/
        public User User { get; set; }
        public Chat Chat { get; set; }
    }
}
