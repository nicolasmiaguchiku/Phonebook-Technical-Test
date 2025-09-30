using Mattioli.Configurations.Stages;
using MongoDB.Bson;
using MongoDB.Driver;
using Phonebook.Domain.Entities;
using Phonebook.Domain.Filters;
using Phonebook.Domain.Interfaces;
using Phonebook.Domain.Results;
using Phonebook.Infrastructure.Data;
using Phonebook.Infrastructure.Mappers;
using Phonebook.Infrastructure.Persistence;
using Phonebook.Infrastructure.Queries.Stages;

namespace Phonebook.Infrastructure.Repositories
{
    public class ContactRepository(IMongoDbContext Context) : IContactRepository
    {

        private readonly IMongoCollection<ContactEntity> _collection = Context.Contacts;
        public async Task<ResultData<Contact>> CreateContactAsync(Contact contact)
        {
            var document = ContactMapper.ToEntity(contact);

            await _collection.InsertOneAsync(document);

            var contactDomain = ContactMapper.ToDomain(document);

            return ResultData<Contact>.Success(contactDomain, "Contato criado com sucesso!");
        }

        public async Task<ResultData<IEnumerable<Contact>>> GetAllContactsAsync(ContactFiltersBuilder queryFilter, CancellationToken cancellationToken)
        {
            var pipelineDefinition = PipelineDefinitionBuilder
                               .For<ContactEntity>()
                               .As<ContactEntity, ContactEntity, BsonDocument>()
                               .FilterContacts(queryFilter);

            if (queryFilter.WithPagination)
            {
                pipelineDefinition = pipelineDefinition.Paginate(queryFilter.PageNumber, queryFilter.PageSize);
            }

            var resultsPipeline = pipelineDefinition.As<ContactEntity, BsonDocument, ContactEntity>();

            var aggregation = await _collection.AggregateAsync(
                   resultsPipeline,
                   new AggregateOptions { AllowDiskUse = true, MaxTime = Timeout.InfiniteTimeSpan, }, cancellationToken);

            var contactsEntity = await aggregation.ToListAsync(cancellationToken);

            if (contactsEntity == null || contactsEntity.Count == 0)
            {
                return ResultData<IEnumerable<Contact>>.Failure("Nenhum contato encontrado.");
            }
            else
            {
                var contacts = contactsEntity.Select(ContactMapper.ToDomain);

                return ResultData<IEnumerable<Contact>>.Success(contacts, "Contatos encontrados com sucesso.");
            }
        }

        public async Task<ResultData<Contact>> GetContactByIdAsync(ContactFiltersBuilder queryFilters, CancellationToken cancellationToken)
        {

            if (!ObjectId.TryParse(queryFilters.ContactsId, out var contactId))
            {
                return ResultData<Contact>.Failure("Id inválido.");
            }

            var contact = await _collection.Find(c => c.Id == queryFilters.ContactsId).FirstOrDefaultAsync();

            if (contact == null)
            {
                return ResultData<Contact>.Failure("Contato não encontrado.");
            }
            else
            {
                var contactDomain = ContactMapper.ToDomain(contact);

                return ResultData<Contact>.Success(contactDomain, "Contato encontrado com sucesso!");
            }
        }

        public async Task<ResultData<bool>> DeleteContactAsync(string id)
        {
            if (!ObjectId.TryParse(id, out var contactId))
            {
                return ResultData<bool>.Failure("Id inválido.");
            }
            var contact = await _collection.Find(c => c.Id == id).FirstOrDefaultAsync();

            if (contact == null)
            {
                return ResultData<bool>.Failure("Contato não encontrado");
            }
            else
            {
                await _collection.DeleteOneAsync(c => c.Id == id);
                return ResultData<bool>.Success(true, "Contato Deletado");
            }
        }

        public async Task<ResultData<Contact>> UpdadeContactAsync(Contact contact)
        {
            var contactentity = ContactMapper.ToEntity(contact);

            var filter = Builders<ContactEntity>.Filter.Eq(c => c.Id, contact.Id);

            var result = await _collection.ReplaceOneAsync(filter, contactentity);

            var updatedContact = ContactMapper.ToDomain(contactentity);

            return ResultData<Contact>.Success(updatedContact, "Contato atualizado com sucesso");
        }
    }
}

