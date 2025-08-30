using Phonebook.Domain.Interfaces;
using MongoDB.Driver;
using Phonebook.Domain.Entities;
using Phonebook.Shared.Results;
using Phonebook.Infrastructure.Data;


namespace Phonebook.Infrastructure.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly IMongoDbContext _context;
        private readonly IMongoCollection<Contact> _collection;

        public ContactRepository(IMongoDbContext context)
        {
            _context = context;
            _collection = _context.Contacts;
        }

        public async Task<ResultData<Contact>> CreateContact(Contact contact)
        {
            await _collection.InsertOneAsync(contact);
            return ResultData<Contact>.Success(contact, "Contato criado com sucesso!");
        }

    }
}
