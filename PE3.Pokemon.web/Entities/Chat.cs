using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PE3.Pokemon.web.Entities
{
    public class Chat
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ChatImage { get; set; }
        public string ChatTheme { get; set; }

        public Guid CreatorId { get; set; }
        public DateTime CreateDate { get; set; }

        public int NumberOfMessages { get; set; }
        public int NumberOfUsers { get; set; }
        public string LastMessage { get; set; }
        
        /*Navigation properties*/
        public ICollection<UserChat> UserChats { get; set; }
        public ICollection<Message> Messages { get; set; }
    }
}
