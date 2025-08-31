using MongoDB.Driver;
using Phonebook.Infrastructure.Persistence;

namespace Phonebook.Infrastructure.Data
{
    public interface IMongoDbContext
    {
        IMongoCollection<ContactEntity> Contacts { get; }

        Task<bool> PingAsync();
    }
}
