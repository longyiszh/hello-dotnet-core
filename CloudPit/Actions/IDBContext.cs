using CloudPit.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudPit.Actions
{
    public interface IDBContext
    {
        IMongoCollection<Player> Players { get; }
        IMongoCollection<Faction> Factions { get; }
    }
}
