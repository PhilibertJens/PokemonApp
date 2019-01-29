using PE3.Pokemon.web.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PE3.Pokemon.web.Models
{
    public class ChatSendFirstMessageVm
    {
        public Guid SenderId { get; set; }
        public User Sender { get; set; }

        [Required(ErrorMessage = "Please enter a message")]
        [StringLength(500, MinimumLength = 1, ErrorMessage = "The message must be between {2} and {1} characters")]
        //[Display(Name = "Username")]
        public string Text { get; set; }
        public DateTime SendDate { get; set; }
        public User Receiver { get; set; }
    }
}
