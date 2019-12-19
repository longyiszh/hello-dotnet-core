using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ThrallBoard.Controllers
{
    public class ErrorController : Controller
    {
        [Route("Error/{status}")]
        public IActionResult StatusErrorHandler(int status)
        {
            switch (status)
            {
                case 404:
                    ViewBag.Title = "http 404";
                    ViewBag.ErrorMessage = "Oops, you are lost!";
                    break;
                default:
                    ViewBag.Title = "Error!";
                    ViewBag.ErrorMessage = "Something is really wrong!";
                    break;
            }
            return View("HTTPError");
        }
    }
}
