using MongoDB.Bson;
using MongoDB.Driver;
using Phonebook.Domain.Entities;
using Phonebook.Infrastructure.Persistence;

namespace Phonebook.Infrastructure.Data
{
    public class MongoDbContext : IMongoDbContext
    {

        private readonly IMongoDatabase _database;

        public MongoDbContext(IMongoDatabase database)
        {
          _database = database;
        }
        public IMongoCollection<Contact> Contacts => _database.GetCollection<Contact>("Contacts");

        public async Task<bool> PingAsync()
        {
            try
            {
                await _database.RunCommandAsync<BsonDocument>("{ ping: 1 }");
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
