using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PE3.Pokemon.web.Models
{
    public class AccountRegistrationVm
    {
        [Required(ErrorMessage ="Please provide your First name")]
        [Display(Name ="First name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please provide your Last name")]
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please provide a Username")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Your Username must be between {1} and 20 characters")]
        [RegularExpression(@"^[\w\d.]{5,}$", ErrorMessage = "Username cannot contain whitespaces or special characters")]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please provide a Password")]
        [MinLength(8, ErrorMessage = "Your password should contain atleast {0} characters")]
        [MaxLength(30, ErrorMessage = "Your password should not be longer {0} characters")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare(nameof(Password), ErrorMessage = "The passwords you provided do not match")]
        [Display(Name = "Repeat password")]
        [DataType(DataType.Password)]
        public string RepeatPassword { get; set; }

        [Required(ErrorMessage = "Please provide a valid e-mail address")]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Remember me")]
        public bool RememberMe { get; set; }
    }
}
