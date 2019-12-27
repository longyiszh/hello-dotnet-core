using CloudPit.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace CloudPit.Actions
{
    public class MongoPlayerService : IPlayerService
    {
        private readonly IDBContext context;

        public MongoPlayerService(IDBContext context)
        {
            this.context = context;
        }

        public async Task<CUDMessage> AddPlayer(Player newPlayer)
        {
            var message = new CUDMessage()
            {
                NumAffected = 1,
                OK = true
            };
            try
            {
                await context.Players.InsertOneAsync(newPlayer);
            }
            catch (Exception e)
            {
                message.OK = false;
                message.NumAffected = 0;
                message.Message = e.ToString();
            }

            return message;
        }


        public async Task<CUDMessage> DeletePlayer(string dbname)
        {
            DeleteResult result = await context.Players.DeleteOneAsync(p => p.DBName == dbname);
            try
            {
                long numDeleted = result.DeletedCount;
            }
            catch (Exception e)
            {
                return new CUDMessage()
                {
                    OK = false,
                    NumAffected = 0,
                    Message = e.ToString()
                };
            }

            return new CUDMessage()
            {
                OK = true,
                NumAffected = result.DeletedCount
            };

        }

        public async Task<Player> GetPlayer(string dbname)
        {
            return await context.Players.Find(p => p.DBName == dbname).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Player>> GetPlayerList()
        {
            return await context.Players.Find(_ => true).ToListAsync();
        }

        public async Task<CUDMessage> UpdatePlayers(JsonElement condition, JsonElement token)
        {
            FilterDefinition<Player> filter = condition.ToString();
            UpdateDefinition<Player> updateToken = token.ToString();

            try
            {
                UpdateResult result = await context.Players.UpdateManyAsync(filter, updateToken);
                return new CUDMessage()
                {
                    NumAffected = result.ModifiedCount,
                    OK = true
                };
            }
            catch (Exception e)
            {
                return new CUDMessage()
                {
                    Message = e.ToString(),
                    NumAffected = 0,
                    OK = false
                };
            }
            
        }
    }
}
