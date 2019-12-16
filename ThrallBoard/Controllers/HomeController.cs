﻿using ThrallBoard.Models;
using ThrallBoard.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThrallBoard.Controllers
{
    //[Route("[controller]/[action]")] // <- attribute routing: usual in REST API
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
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                Employee newEmployee = _employeeRepo.Add(employee);
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