using employee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace employee.ViewModels
{
    public class HomeDetailsViewModel
    {
        public Employee Employee { get; set; }
        public string title { get; set; }
    }
}
