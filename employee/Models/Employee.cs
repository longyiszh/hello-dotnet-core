using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace employee.Models
{
    public class Employee
    {
        public int ID { get; set; }

        [Required]
        [MaxLength(30, ErrorMessage = "Your name is too long (> 30 char)")]
        public string Name { get; set; }

        public string Avatar { get; set; }

        [Required]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Invalid Email Format")]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Required]
        public Dept? Department { get; set; }
        
    }
}
