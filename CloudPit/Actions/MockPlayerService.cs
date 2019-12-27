using CloudPit.Models;
using CloudPit.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace CloudPit.Actions
{
    public class MockPlayerService : IPlayerService
    {
        private List<Player> players;
        public MockPlayerService()
        {
            players = new List<Player>()
            {
                new Player()
                {
                    ID = "lkjuqkjbcaw23i74689175",
                    DBName = "player-awsec2",
                    Faction = "faction-vps"
                },
                new Player()
                {
                    ID = "nvdiohskjfhih2426592483",
                    DBName = "player-django",
                    Faction = "faction-backend"
                },
                new Player()
                {
                    ID = "asghdfifuaghf77984928349",
                    DBName = "player-angular",
                    Faction = "faction-frontend"
                }
            };
        }

        public async Task<CUDMessage> AddPlayer(Player newPlayer)
        {
            CUDMessage message = new CUDMessage()
            {
                OK = true,
                NumAffected = 0
            };

            try
            {
                newPlayer.ID = Guid.NewGuid().ToString();
                players.Add(newPlayer);
                message.NumAffected = 1;
            }
            catch (Exception e)
            {
                message.OK = false;
                message.Message = e.ToString();
            }
            return message;
        }

        public async Task<CUDMessage> DeletePlayer(string dbname)
        {
            CUDMessage message = new CUDMessage()
            {
                OK = true,
                NumAffected = 0
            };


            Player player = players.FirstOrDefault((player) => { return player.DBName == dbname; });
            if (player != null)
            {
                players.Remove(player);
                message.NumAffected = 1;

            }
            else
            {
                message.NumAffected = 0;
            }

            return message;
        }

        public async Task<Player> GetPlayer(string dbname)
        {
            return players.FirstOrDefault((player) => { return player.DBName == dbname; });
        }

        public async Task<IEnumerable<Player>> GetPlayerList()
        {
            return players;
        }

        public async Task<CUDMessage> UpdatePlayers(JsonElement condition, JsonElement token)
        {
            //List<Player> matchedPlayers = players.GetRange(0, 2);

            //List<Player> updatedPlayers = matchedPlayers.Select((player) => player = Utility.CombineProperties(player, token)).ToList();

            return new CUDMessage()
            {
                OK = true,
                NumAffected = 2
            };
        }



    }
}
