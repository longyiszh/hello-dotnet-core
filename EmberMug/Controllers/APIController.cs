using System;
using EmberMug.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmberMug.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class APIController : ControllerBase
    {

        [HttpGet]
        public CommonMessage ReadyState()
        {
            var message = new CommonMessage()
            {
                OK = true,
                Message = "API works!",
            };

            return message;
        }
    }

}