using CloudPit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace CloudPit.Actions
{
    public interface IPlayerService
    {
        Task<Player> GetPlayer(string dbname);
        Task<IEnumerable<Player>> GetPlayerList();
        Task<CUDMessage> AddPlayer(Player newPlayer);
        Task<CUDMessage> UpdatePlayers(JsonElement condition, JsonElement token);
        Task<CUDMessage> DeletePlayer(string dbname);
    }
}
