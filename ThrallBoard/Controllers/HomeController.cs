using ThrallBoard.Models;
using ThrallBoard.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace ThrallBoard.Controllers
{
    //[Route("[controller]/[action]")] // <- attribute routing: usual in REST API
    public class HomeController : Controller
    {
        private readonly IEmployeeRepo _employeeRepo;
        private readonly IWebHostEnvironment host;

        public HomeController(
            IEmployeeRepo employeeRepo,
            IWebHostEnvironment host
        )
        {
            _employeeRepo = employeeRepo;
            this.host = host;
        }

        //public ObjectResult GetSingleEmployee()
        //{
        //    Employee model = _employeeRepo.GetAnEmployee(1);
        //    return new ObjectResult(model);
        //}

        //[Route("{id?}")]
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

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(EmployeeCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                string fileName = null;
                if (model.Avatar != null)
                {
                    // To make the filename always unique
                    fileName = Guid.NewGuid().ToString() + "_" + model.Avatar.FileName;
                    string filePath = Path.Combine(host.WebRootPath, "media", fileName);
                    model.Avatar.CopyTo(new FileStream(filePath, FileMode.Create));
                }
                Employee newEmployee = new Employee() { 
                  Avatar = fileName,
                  Department = model.Department,
                  Email = model.Email,
                  Name = model.Name
                };
                _employeeRepo.Add(newEmployee);
                return RedirectToAction("details", new { id = newEmployee.ID });
            } else
            {
                return View();
            }

        }

        //[Route("~/Home")]
        //[Route("~/")]
        public ViewResult Index()
        {
            var model = _employeeRepo.GetEmployees();
            return View(model);
        }
    }
}
