using CloudPit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace CloudPit.Actions
{
    public interface IFactionService
    {
        Faction GetFaction(string dbname);
        IEnumerable<Faction> GetFactions();
        CUDMessage AddFaction(Faction newFaction);
        CUDMessage UpdateFactions(JsonElement condition, Faction token);
        CUDMessage DeleteFaction(string dbname);
    }
}
