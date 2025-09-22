using MongoDB.Bson;
using MongoDB.Driver;
using Phonebook.Infrastructure.Persistence;

namespace Phonebook.Infrastructure.Data
{
    public class MongoDbContext(IMongoDatabase Database) : IMongoDbContext
    {
        public IMongoCollection<ContactEntity> Contacts => Database.GetCollection<ContactEntity>("Contacts");

        public async Task<bool> PingAsync()
        {
            try
            {
                await Database.RunCommandAsync<BsonDocument>("{ ping: 1 }");
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
