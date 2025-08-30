using Phonebook.Domain.Entities;
using Phonebook.Infrastructure.Persistence;

namespace Phonebook.Infrastructure.Mappers
{
    public static class ContactMapper
    {
        public static ContactEntity ToEntity(Contact contact) => new ContactEntity
        {
            Id = contact.Id,
            Name = contact.Name,
            Phone = contact.Phone,
            Email = contact.Email,
            DateOfBirth = contact.DateOfBirth,
            Addresses = contact.Addresses.ToList()
        };

        public static Contact ToDomain(ContactEntity entity)
        {
            var contact = new Contact
            {
                Id = entity.Id,
                Name = entity.Name,
                Phone = entity.Phone,
                Email = entity.Email,
                DateOfBirth = entity.DateOfBirth
            };

            if (entity.Addresses != null)
                contact.AddAddresses(entity.Addresses);

            return contact;
        }
    }
}
