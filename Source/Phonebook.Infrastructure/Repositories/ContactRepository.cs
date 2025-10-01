using Mattioli.Configurations.Stages;
using MongoDB.Bson;
using MongoDB.Driver;
using Phonebook.Domain.Dtos.Requests;
using Phonebook.Domain.Dtos.Response;
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
        public async Task<ResultData<ContactResponse>> CreateContactAsync(AddContactRequest request)
        {
            var contactEntity = request.ToEntity();

            await _collection.InsertOneAsync(contactEntity);

            var contactResponse= contactEntity.ToResponse();

            return ResultData<ContactResponse>.Success(contactResponse, "Contato criado com sucesso!");
        }

        public async Task<ResultData<IEnumerable<ContactResponse>>> GetAllContactsAsync(ContactFiltersBuilder queryFilter, CancellationToken cancellationToken)
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
                return ResultData<IEnumerable<ContactResponse>>.Failure("Nenhum contato encontrado.");
            }
            else
            {
                var contacts = contactsEntity.Select(ContactMapper.ToResponse);

                return ResultData<IEnumerable<ContactResponse>>.Success(contacts, "Contatos encontrados com sucesso.");
            }
        }

        public async Task<ResultData<ContactResponse>> GetContactByIdAsync(ContactFiltersBuilder queryFilters, CancellationToken cancellationToken)
        {

            if (!ObjectId.TryParse(queryFilters.ContactsId, out var contactId))
            {
                return ResultData<ContactResponse>.Failure("Id inválido.");
            }

            var contact = await _collection.Find(c => c.Id == queryFilters.ContactsId).FirstOrDefaultAsync(cancellationToken);

            if (contact == null)
            {
                return ResultData<ContactResponse>.Failure("Contato não encontrado.");
            }
            else
            {
                var contactResponse= contact.ToResponse();

                return ResultData<ContactResponse>.Success(contactResponse, "Contato encontrado com sucesso!");
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

        public async Task<ResultData<ContactResponse>> UpdadeContactAsync(UpdadeContactRequest request)
        {
            var contactEntity = request.ToEntity();

            var filter = Builders<ContactEntity>.Filter.Eq(c => c.Id, request.ContactId);

            await _collection.ReplaceOneAsync(filter, contactEntity);

            var updatedContact = contactEntity.ToResponse();

            return ResultData<ContactResponse>.Success(updatedContact, "Contato atualizado com sucesso");
        }
    }
}

