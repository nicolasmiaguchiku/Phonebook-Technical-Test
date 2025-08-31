using MongoDB.Bson;
using MongoDB.Driver;
using Phonebook.Domain.Entities;
using Phonebook.Domain.Interfaces;
using Phonebook.Infrastructure.Data;
using Phonebook.Infrastructure.Mappers;
using Phonebook.Infrastructure.Persistence;
using Phonebook.Shared.Results;

namespace Phonebook.Infrastructure.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly IMongoDbContext _context;
        private readonly IMongoCollection<ContactEntity> _collection;

        public ContactRepository(IMongoDbContext context)
        {
            _context = context;
            _collection = _context.Contacts;
        }

        public async Task<ResultData<Contact>> CreateContactAsync(Contact contact)
        {
            var document = ContactMapper.ToEntity(contact);
            await _collection.InsertOneAsync(document);

            var contactDomain = ContactMapper.ToDomain(document);

            return ResultData<Contact>.Success(contactDomain, "Contato criado com sucesso!");
        }

        public async Task<ResultData<IEnumerable<Contact>>> GetAllContactsAsync()
        {
            var listContact = await _collection.FindAsync(FilterDefinition<ContactEntity>.Empty);
            var contactsEntity = await listContact.ToListAsync();

            if (contactsEntity == null || !contactsEntity.Any())
            {
                return ResultData<IEnumerable<Contact>>.Failure("Nenhum contato encontrado.");
            }

            var contacts = contactsEntity.Select(ContactMapper.ToDomain);

            return ResultData<IEnumerable<Contact>>.Success(contacts, "Contatos encontrados com sucesso.");
        }

        public async Task<ResultData<Contact>> GetContactByIdAsync(string id)
        {
            try
            {
                if (!ObjectId.TryParse(id, out _))
                {
                    return ResultData<Contact>.Failure("Id inválido.");
                }

                var contact = await _collection.Find(c => c.Id == id).FirstOrDefaultAsync();

                if (contact == null)
                {
                    return ResultData<Contact>.Failure("Contato não encontrado.");
                }

                var contactDomain = ContactMapper.ToDomain(contact);

                return ResultData<Contact>.Success(contactDomain, "Contato encontrado com sucesso!");
            }
            catch (Exception ex)
            {
                return ResultData<Contact>.Failure($"Erro ao buscar contato: {ex.Message}");
            }
        }

        public async Task<ResultData<bool>> DeleteContactAsync(string id)
        {
            var contactDedelete = await _collection.DeleteOneAsync(c => c.Id == id);

            if (contactDedelete == null)
            {
                return ResultData<bool>.Failure("Contato não encontrado");
            }
            else
            {
                return ResultData<bool>.Success(true, "Contato Deletado");
            }

        }

        public async Task<ResultData<Contact>> UpdadeContactAsync(Contact contact)
        {

            if (contact == null)
                return ResultData<Contact>.Failure("Contact is null");

            var entity = ContactMapper.ToEntity(contact);

            var filter = Builders<ContactEntity>.Filter.Eq(c => c.Id, contact.Id);


            var result = await _collection.ReplaceOneAsync(filter, entity);

            if (result.MatchedCount == 0)
                return ResultData<Contact>.Failure("Contact not found");

            var updatedContact = ContactMapper.ToDomain(entity);

            return ResultData<Contact>.Success(updatedContact, "Contact updated successfully");
        }
    }
}

 