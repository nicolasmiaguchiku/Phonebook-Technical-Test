using MongoDB.Driver;
using Phonebook.Domain.Entities;

namespace Phonebook.Infrastructure.Data
{
    public interface IMongoDbContext
    {
        IMongoCollection<Contact> Contacts { get; }

        Task<bool> PingAsync();
    }
}
