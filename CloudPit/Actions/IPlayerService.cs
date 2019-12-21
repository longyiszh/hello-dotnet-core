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
        Player GetPlayer(string DBName);
        IEnumerable<Player> GetPlayerList();
        CUDMessage AddPlayer(Player newPlayer);
        CUDMessage UpdatePlayers(JsonElement condition, Player token);
        CUDMessage DeletePlayer(string dbname);
    }
}
