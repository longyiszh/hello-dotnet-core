using CloudPit.Models;
using CloudPit.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace CloudPit.Actions
{
    public class MockFactionService : IFactionService
    {
        private List<Faction> factions; 
        public MockFactionService()
        {
            factions = new List<Faction>()
            {
                new Faction()
                {
                    ID = "ahsfhiuwehf348578934759",
                    DBName = "faction-frontend"
                },
                new Faction()
                {
                    ID = "bkdjhbgbkr039485836",
                    DBName = "faction-backend"
                },
                new Faction()
                {
                    ID = "blgbhoedrhg3847598465",
                    DBName = "faction-database"
                },
                new Faction()
                {
                    ID = "viagikdbvi2347956496",
                    DBName = "faction-vps"
                }
            };
        }
        public CUDMessage AddFaction(Faction newFaction)
        {
            factions.Add(newFaction);
            return new CUDMessage() {
                NumAffected = 1,
                OK = true
            };
        }

        public CUDMessage DeleteFaction(string dbname)
        {
            Faction faction = factions.FirstOrDefault(fac => fac.DBName == dbname);
            if (faction != null)
            {
                factions.Remove(faction);
                return new CUDMessage() { 
                    NumAffected = 1,
                    OK = true
                };
            }
            return new CUDMessage()
            {
                NumAffected = 0,
                OK = false
            };
        }

        public Faction GetFaction(string dbname)
        {
            return factions.FirstOrDefault(fac => fac.DBName == dbname);
        }

        public IEnumerable<Faction> GetFactions()
        {
            return factions;
        }

        public CUDMessage UpdateFactions(JsonElement condition, Faction token)
        {
            List<Faction> matchedFactions = factions.GetRange(0, 2);

            List<Faction> updatedFactions = matchedFactions.Select((fac) => fac = Utility.CombineProperties(fac, token)).ToList();

            return new CUDMessage()
            {
                OK = true,
                NumAffected = updatedFactions.Count
            };
        }
    }
}
