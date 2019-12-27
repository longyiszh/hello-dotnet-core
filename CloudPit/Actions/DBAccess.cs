using CloudPit.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudPit.Actions
{
    public class DBAccess : IDBContext
    {
        private readonly IProjectSettings settings;
        private readonly IMongoDatabase dbInstance;

        public DBAccess(IProjectSettings settings)
        {
            this.settings = settings;
            dbInstance = Connect();
        }
        private IMongoDatabase Connect()
        {
            var client = new MongoClient(settings.ConnectionString);
            return client.GetDatabase("cloudPit");
        }

        public IMongoCollection<Player> Players => dbInstance.GetCollection<Player>("players");

        public IMongoCollection<Faction> Factions => dbInstance.GetCollection<Faction>("factions");
    }
}
