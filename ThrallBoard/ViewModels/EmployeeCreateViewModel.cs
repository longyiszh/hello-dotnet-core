using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ThrallBoard.Models;

namespace ThrallBoard.ViewModels
{
    public class EmployeeCreateViewModel
    {
        [Required]
        [MaxLength(30, ErrorMessage = "Your name is too long (> 30 char)")]
        public string Name { get; set; }

        public IFormFile Avatar { get; set; }

        [Required]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Invalid Email Format")]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Required]
        public Dept? Department { get; set; }
    }
}
