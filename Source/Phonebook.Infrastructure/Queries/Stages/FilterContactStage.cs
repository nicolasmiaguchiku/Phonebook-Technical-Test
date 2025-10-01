using MongoDB.Bson;
using MongoDB.Driver;
using Phonebook.Domain.Filters;
using Phonebook.Infrastructure.Persistence;
using System.Text.RegularExpressions;

namespace Phonebook.Infrastructure.Queries.Stages
{
    public static partial class FilterContactStage
    {
        public static PipelineDefinition<ContactEntity, BsonDocument> FilterContacts(
           this PipelineDefinition<ContactEntity, BsonDocument> pipelineDefinition,
           ContactFiltersBuilder queryFilter)
        {
            var matchFilter = BuildMatchFilter(queryFilter);

            if (matchFilter != FilterDefinition<BsonDocument>.Empty)
            {
                pipelineDefinition = pipelineDefinition.Match(matchFilter);
            }
            return pipelineDefinition;
        }

        private static FilterDefinition<BsonDocument> BuildMatchFilter(ContactFiltersBuilder queryFilter)
        {
            var filters = new List<FilterDefinition<BsonDocument>>
            {
                MatchByCustomersNames(queryFilter),
                MatchByContacId(queryFilter)
            };

            filters.RemoveAll(x => x == FilterDefinition<BsonDocument>.Empty);

            if (filters.Count == 0)
            {
                return FilterDefinition<BsonDocument>.Empty;
            }

            return filters.Count == 1 ? filters[0] : Builders<BsonDocument>.Filter.And(filters);
        }

        public static FilterDefinition<BsonDocument> MatchByContacId(
            ContactFiltersBuilder? queryFilter
            )
        {
            if (string.IsNullOrWhiteSpace(queryFilter?.ContactsId))
            {
                return FilterDefinition<BsonDocument>.Empty;
            }
            return Builders<BsonDocument>.Filter.Eq("_id", queryFilter?.ContactsId!);
        }

        private static FilterDefinition<BsonDocument> MatchByCustomersNames(
              ContactFiltersBuilder? queryFilter)
        {
            var listName = queryFilter?.Names?.Where(x => !string.IsNullOrWhiteSpace(x)).ToList();

            if (listName == null || listName.Count == 0)
            {
                return FilterDefinition<BsonDocument>.Empty;
            }

            var names = queryFilter!.Names!.Select(x => new BsonRegularExpression(new Regex(x, RegexOptions.IgnoreCase)));

            var filter = new BsonDocument(
                "Name",
                new BsonDocument("$in", BsonArray.Create(names)));

            return new BsonDocumentFilterDefinition<BsonDocument>(filter);
        }
    }
}
