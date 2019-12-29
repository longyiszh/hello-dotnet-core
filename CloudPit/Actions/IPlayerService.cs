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
        Task<IEnumerable<Player>> GetPlayerList(JsonElement condition);
        Task<IEnumerable<Player>> GetPlayerList(JsonElement condition, GetListOptions options);
        Task<CUDMessage> AddPlayer(Player newPlayer);
        Task<CUDMessage> UpdatePlayers(JsonElement condition, JsonElement token);
        Task<CUDMessage> DeletePlayer(string dbname);
    }
}
