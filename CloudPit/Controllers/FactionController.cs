using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using CloudPit.Actions;
using CloudPit.Models;
using Microsoft.AspNetCore.Mvc;

namespace CloudPit.Controllers
{
    [Route("api/[controller]")]
    public class FactionController : ControllerBase
    {
        private readonly IFactionService factionService;

        public FactionController(IFactionService factionService)
        {
            this.factionService = factionService;
        }

        public class UpdateRequest
        {
            public JsonElement condition { get; set; }
            public Faction token { get; set; }
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Faction> Get()
        {
            return factionService.GetFactions();
        }

        // GET api/<controller>/faction-backend
        [HttpGet("{dbname}")]
        public IActionResult Get(string dbname)
        {
            Faction faction = factionService.GetFaction(dbname);
            if (faction != null)
            {
                return Ok(faction);
            } else
            {
                return new JsonResult(new object());
            }
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]Faction newFaction)
        {
            CUDMessage message = factionService.AddFaction(newFaction);
            if (message.OK)
            {
                message.Message = $"Successfully added {newFaction.DBName}";
                return Ok(message);
            } else
            {
                message.Message = $"Failed to add {newFaction.DBName}";
                Response.StatusCode = 500;
                return new JsonResult(message);
            }
        }

        // PATCH api/<controller>
        [HttpPatch]
        public IActionResult Patch([FromBody]UpdateRequest reqBody)
        {
            var message = new CUDMessage();

            if (!string.IsNullOrEmpty(reqBody.condition.ToString()) && reqBody.token != null)
            {
                message = factionService.UpdateFactions(reqBody.condition, reqBody.token);
                if (message.OK)
                {
                    message.Message = "Successfuly updated the selected faction(s)";
                    return Ok(message);
                }
                else
                {
                    Response.StatusCode = 500;
                    message.Message = "Failed to update the selected faction(s)!";
                    return new JsonResult(message);
                }
            }

            message.Message = "Invalid parameters provided";
            Response.StatusCode = 400;
            return new JsonResult(message);

        }

        // DELETE api/<controller>/5
        [HttpDelete("{dbname}")]
        public IActionResult Delete(string dbname)
        {
            CUDMessage message = factionService.DeleteFaction(dbname);
            if (message.OK)
            {
                message.Message = $"Successfully deleted {dbname}";
                return Ok(message);
            }
            else
            {
                message.Message = $"Failed to delete {dbname}";
                Response.StatusCode = 500;
                return new JsonResult(message);
            }
        }
    }
}
