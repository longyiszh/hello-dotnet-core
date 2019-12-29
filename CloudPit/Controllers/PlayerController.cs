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

    public class GetListRequestParams
    {
        public JsonElement Q { get; set; }
        public GetListOptions O { get; set; }
    }

    public class GetListRequest
    {
        public string query { get; set; }
    }

    public class UpdateRequest
    {
        public JsonElement condition { get; set; }
        public JsonElement token { get; set; }
    }


    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerService playerService;

        public PlayerController(IPlayerService playerService)
        {
            this.playerService = playerService;
        }

        [HttpGet("all")]
        public async Task<IEnumerable<Player>> GetAll()
        {
            IEnumerable<Player> result = await playerService.GetPlayerList(JsonDocument.Parse("{}").RootElement);
            return result;
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] GetListRequest request)
        {

            GetListRequestParams query;
            try
            {
                query = JsonSerializer.Deserialize<GetListRequestParams>(
                    request.query,
                    new JsonSerializerOptions()
                    {
                        PropertyNameCaseInsensitive = true,
                    }
                );
            }
            catch (Exception e)
            {
                Response.StatusCode = 400;
                Console.WriteLine(e.ToString());
                return new JsonResult(JsonDocument.Parse("{\"message\": \"Invalid Query provided\" }").RootElement);
            }

            try
            {
                IEnumerable<Player> result;

                if (query.O == null)
                {
                    result = await playerService.GetPlayerList(query.Q);
                } else
                {
                    result = await playerService.GetPlayerList(query.Q, query.O);
                }

                return Ok(result);
            }
            catch (Exception e)
            {
                Response.StatusCode = 500;
                Console.WriteLine(e.ToString());
                return new JsonResult(JsonDocument.Parse("{\"message\": \"Failed to perform query\" }").RootElement);
            }

        }

        [HttpGet("{dbname}")]
        public async Task<IActionResult> GetSingle(string dbname)
        {
            Player player = await playerService.GetPlayer(dbname);
            if (player == null)
            {
                return new JsonResult(new object());
            } else
            {
                return Ok(player);
            }
            
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody]Player newPlayer)
        {
            CUDMessage message = await playerService.AddPlayer(newPlayer);
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
        public async Task<IActionResult> Delete(string dbname)
        {
            CUDMessage message = await playerService.DeletePlayer(dbname);
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
        public async Task<IActionResult> UpdateList([FromBody]UpdateRequest reqBody)
        {
            CUDMessage message = new CUDMessage();

            if (!string.IsNullOrEmpty(reqBody.condition.ToString()) && !string.IsNullOrEmpty(reqBody.token.ToString()))
            {
                message = await playerService.UpdatePlayers(reqBody.condition, reqBody.token);
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