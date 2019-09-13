using employee.Models;
using employee.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace employee.Controllers
{
    [Route("[controller]/[action]")] // <- attribute routing: usual in REST API
    public class HomeController : Controller
    {
        private readonly IEmployeeRepo _employeeRepo;


        public HomeController(IEmployeeRepo employeeRepo)
        {
            _employeeRepo = employeeRepo;
        }

        //public ObjectResult GetSingleEmployee()
        //{
        //    Employee model = _employeeRepo.GetAnEmployee(1);
        //    return new ObjectResult(model);
        //}

        [Route("{id?}")]
        public ViewResult Details(int? id)
        {
            //Employee model = _employeeRepo.GetAnEmployee(1);
            //ViewBag.pageTitle = "Employee Details";
            //return View(model);
            HomeDetailsViewModel vm = new HomeDetailsViewModel()
            {
                Employee = _employeeRepo.GetAnEmployee(id??0),
                title = "Employee Details",
            };

            return View(vm);
        }

        [Route("~/Home")]
        [Route("~/")]
        public ViewResult Index()
        {
            var model = _employeeRepo.GetEmployees();
            return View(model);
        }
    }
}
