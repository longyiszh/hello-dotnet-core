using employee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace employee.Controllers
{
    public class HomeController
    {
        private IEmployeeRepo _employeeRepo;

        public HomeController(IEmployeeRepo employeeRepo)
        {
            _employeeRepo = employeeRepo;
        }

        public string Index()
        {
            return _employeeRepo.GetEmployee(1).Name;
        }
    }
}
