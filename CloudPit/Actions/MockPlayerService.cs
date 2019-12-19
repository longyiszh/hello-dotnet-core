using CloudPit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public Player GetPlayer(string DBName)
        {
            return players.FirstOrDefault((player) => { return player.DBName == DBName; });
        }

        public IEnumerable<Player> GetPlayerList()
        {
            return players;
        }
    }
}
