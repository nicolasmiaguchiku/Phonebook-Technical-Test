using MongoDB.Bson;
using MongoDB.Driver;
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
        public IMongoCollection<ContactEntity> Contacts => _database.GetCollection<ContactEntity>("Contacts");

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
