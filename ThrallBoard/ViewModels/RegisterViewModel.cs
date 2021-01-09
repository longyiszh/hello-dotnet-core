using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ThrallBoard.Utilities;

namespace ThrallBoard.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email Address")]
        [Remote(controller: "Account", action: "IsEmailInUse")]
        [ValidEmailDomain(allowedDomain: "jjj.com", ErrorMessage = "Error! This site has been hacked and you can only register with domain jjj.com")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Password confirmation does not match.")]
        public string ConfirmPassword { get; set; }
    }
}
