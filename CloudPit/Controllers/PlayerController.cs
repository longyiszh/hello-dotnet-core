using System;
using System.Collections.Generic;
using System.Linq;
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
        public Player GetSingle(string dbname)
        {
            return _playerService.GetPlayer(dbname);
        }

    }
}