using Phonebook.Domain.Entities;
using Phonebook.Infrastructure.Persistence;
using Phonebook.Domain.Dtos.Response;
using Phonebook.Domain.Dtos.Requests;

namespace Phonebook.Infrastructure.Mappers
{
    public static class ContactMapper
    {
        public static ContactEntity ToEntity(this AddContactRequest contact) => new ()
        {
            Name = contact.Name,
            Phone = contact.Phone,
            Email = contact.Email,
            DateOfBirth = contact.DateOfBirth,
            Addresses = contact.Addresses
        };

        public static ContactEntity ToEntity(this UpdadeContactRequest contact) => new()
        {
            Id = contact.ContactId,
            Name = contact.Name,
            Phone = contact.Phone,
            Email = contact.Email,
            DateOfBirth = contact.DateOfBirth,
            Addresses = contact.Addresses
        };

        public static ContactResponse ToResponse(this ContactEntity contact) => new ()
        {
            ContactId = contact.Id,
            Name = contact.Name,
            Phone = contact.Phone,
            Email = contact.Email,
            DateOfBirth = contact.DateOfBirth,
            Addresses = contact.Addresses!
        };


        public static ContactResponse ToResponse(this UpdadeContactRequest contact) => new()
        {
            ContactId = contact.ContactId,
            Name = contact.Name,
            Phone = contact.Phone,
            Email = contact.Email,
            DateOfBirth = contact.DateOfBirth,
            Addresses = contact.Addresses
        };
    }
}
