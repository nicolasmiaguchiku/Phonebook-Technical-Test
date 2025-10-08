using Mattioli.Configurations.Models;
using Mattioli.Configurations.Stages;
using MongoDB.Bson;
using MongoDB.Driver;
using Phonebook.Domain.Dtos.Requests;
using Phonebook.Domain.Dtos.Response;
using Phonebook.Domain.Errors;
using Phonebook.Domain.Filters;
using Phonebook.Domain.Interfaces;
using Phonebook.Infrastructure.Mappers;
using Phonebook.Infrastructure.Persistence;
using Phonebook.Infrastructure.Queries.Stages;

namespace Phonebook.Infrastructure.Repositories
{
    public class ContactRepository(IMongoDatabase mongoDb) : IContactRepository
    {
        private readonly IMongoCollection<ContactEntity> _collection = mongoDb.GetCollection<ContactEntity>("Contacts");

        public async Task<Result<ContactResponse>> CreateContactAsync(CreateContactRequest request)
        {
            var contactEntity = request.ToEntity();

            await _collection.InsertOneAsync(contactEntity);

            var contactResponse = contactEntity.ToResponse();

            return Result<ContactResponse>.Success(contactResponse);
        }

        public async Task<Result<IEnumerable<ContactResponse>>> GetAllContactsAsync(ContactFiltersBuilder queryFilter, CancellationToken cancellationToken)
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
                return Result<IEnumerable<ContactResponse>>.Failure(ContactErrors.ContactNotExist);
            }
            else
            {
                var contacts = contactsEntity.Select(ContactMapper.ToResponse);

                return Result<IEnumerable<ContactResponse>>.Success(contacts);
            }
        }

        public async Task<Result<ContactResponse>> GetContactByIdAsync(ContactFiltersBuilder queryFilters, CancellationToken cancellationToken)
        {

            if (!ObjectId.TryParse(queryFilters.ContactsId, out var contactId))
            {
                return Result<ContactResponse>.Failure(ContactErrors.IdInformedInvalid);
            }

            var contact = await _collection.Find(c => c.Id == queryFilters.ContactsId).FirstOrDefaultAsync(cancellationToken);

            if (contact == null)
            {
                return Result<ContactResponse>.Failure(ContactErrors.ContactNotExist);
            }
            else
            {
                var contactResponse = contact.ToResponse();

                return Result<ContactResponse>.Success(contactResponse);
            }
        }

        public async Task<Result<bool>> DeleteContactAsync(ContactFiltersBuilder queryFilter, CancellationToken cancellationToken)
        {
            if (!ObjectId.TryParse(queryFilter.ContactsId, out var contactId))
            {
                return Result<bool>.Failure(ContactErrors.IdInformedInvalid);
            }
            var contact = await GetContactByIdAsync(queryFilter, cancellationToken);

            if (contact == null)
            {
                return Result<bool>.Failure(ContactErrors.ContactNotExist);
            }
            else
            {
                await _collection.DeleteOneAsync(c => c.Id == queryFilter.ContactsId, cancellationToken: cancellationToken);
                return Result<bool>.Success(true);
            }
        }

        public async Task<Result<ContactResponse>> UpdadeContactAsync(UpdadeContactRequest request)
        {

            if (!ObjectId.TryParse(request.ContactId, out var contactId))
            {
                return Result<ContactResponse>.Failure(ContactErrors.IdInformedInvalid);
            }

            var contactEntity = request.ToEntity();

            var filter = Builders<ContactEntity>.Filter.Eq(c => c.Id, request.ContactId);

            await _collection.ReplaceOneAsync(filter, contactEntity);

            var updatedContact = contactEntity.ToResponse();

            return Result<ContactResponse>.Success(updatedContact);
        }
    }
}

