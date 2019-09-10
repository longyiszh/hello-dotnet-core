using employee.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace employee.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeRepo _employeeRepo;

        public HomeController(IEmployeeRepo employeeRepo)
        {
            _employeeRepo = employeeRepo;
        }

        //public ObjectResult GetSingleEmployee()
        //{
        //    Employee model = _employeeRepo.GetEmployee(1);
        //    return new ObjectResult(model);
        //}

        public ViewResult Details()
        {
            Employee model = _employeeRepo.GetEmployee(1);
            return View(model);
        }

        public string Index()
        {
            return "Employee works";
        }
    }
}
