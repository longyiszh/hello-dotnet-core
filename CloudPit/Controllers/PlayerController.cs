using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using CloudPit.Actions;
using CloudPit.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CloudPit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerService _playerService;

        public class UpdateRequest
        {
            public JsonElement condition { get; set; }
            public Player token { get; set; }
        }

        public PlayerController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        [HttpGet]
        public IEnumerable<Player> GetAll()
        {
            return _playerService.GetPlayerList();
        }

        [HttpGet("{dbname}")]
        public IActionResult GetSingle(string dbname)
        {
            Player player = _playerService.GetPlayer(dbname);
            if (player == null)
            {
                return new JsonResult(new object());
            } else
            {
                return Ok(_playerService.GetPlayer(dbname));
            }
            
        }

        [HttpPost]
        public IActionResult Add(Player newPlayer)
        {
            CUDMessage message = _playerService.AddPlayer(newPlayer);
            if (message.OK)
            {
                message.Message = "Successfuly added the new player: " + newPlayer.DBName;
                return Ok(message);
            } else
            {
                message.Message = "Failed to add the player: " + newPlayer.DBName + "!";
                Response.StatusCode = 500;
                return new JsonResult(message);
            }
        }

        [HttpDelete("{dbname}")]
        public IActionResult Delete(string dbname)
        {
            CUDMessage message = _playerService.DeletePlayer(dbname);
            if (message.OK)
            {
                message.Message = "Successfuly deleted player: " + dbname;
                return Ok(message);
            }
            else
            {
                message.Message = "Failed to add the player: " + dbname + "!";
                Response.StatusCode = 500;
                return new JsonResult(message);
            }
        }

        [HttpPatch]
        public IActionResult UpdateList(UpdateRequest reqBody)
        {
            CUDMessage message = new CUDMessage();

            if (!string.IsNullOrEmpty(reqBody.condition.ToString()) && reqBody.token != null)
            {
                message = _playerService.UpdatePlayers(reqBody.condition, reqBody.token);
                if (message.OK)
                {
                    message.Message = "Successfuly updated the selected player(s)";
                    return Ok(message);
                }
                else
                {
                    Response.StatusCode = 500;
                    message.Message = "Failed to update the selected player(s)!";
                    return new JsonResult(message);
                }
            }

            message.Message = "Invalid parameters provided";
            Response.StatusCode = 400;
            return new JsonResult(message);

        }

    }
}