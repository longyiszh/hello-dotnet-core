using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ThrallBoard.Controllers
{
    public class ErrorController : Controller
    {
        private readonly ILogger<ErrorController> logger;

        public ErrorController(ILogger<ErrorController> logger)
        {
            this.logger = logger;
        }

        [Route("Error/{status}")]
        public IActionResult StatusErrorHandler(int status)
        {
            var statusResult = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();
            switch (status)
            {
                case 404:
                    ViewBag.Title = "http 404";
                    ViewBag.ErrorMessage = "Oops, you are lost!";
                    logger.LogWarning($"Someone was lost: at {statusResult.OriginalPath}, asking {statusResult.OriginalQueryString}");
                    break;
                default:
                    ViewBag.Title = "Error!";
                    ViewBag.ErrorMessage = "Something is really wrong!";
                    logger.LogWarning($"Some weirdo was tring to break our server: at {statusResult.OriginalPath}");
                    break;
            }
            return View("HTTPError");
        }

        [Route("Error")]
        [AllowAnonymous]
        public IActionResult Error()
        {
            var exception = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            //ViewBag.exceptionPath = exception.Path;
            //ViewBag.exceptionMessage = exception.Error.Message;
            //ViewBag.exceptionStack = exception.Error.StackTrace;

            logger.LogError($"A diastrous error occured at {exception.Path}, which is described as {exception.Error.Message}. The complete stack is shown below");
            logger.LogError(exception.Error.StackTrace);

            return View("Error");
        }
    }
}
