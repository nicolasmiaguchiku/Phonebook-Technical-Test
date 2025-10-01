using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Phonebook.Infrastructure.Persistence
{
    public class ContactEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        [BsonElement("Name")]
        public string Name { get; set; } = string.Empty;

        [BsonElement("Phone")]
        public string Phone { get; set; } = string.Empty;

        [BsonElement("Email")]
        public string Email { get; set; } = string.Empty;

        [BsonElement("DateOfBirth")]
        public DateTime DateOfBirth { get; set; }

        [BsonElement("Addresses")]
        public IEnumerable<string>? Addresses { get; set; }
    }
}
