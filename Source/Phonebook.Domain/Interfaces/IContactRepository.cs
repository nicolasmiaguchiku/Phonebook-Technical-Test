using Phonebook.Domain.Entities;
using Phonebook.Shared.Results;

namespace Phonebook.Domain.Interfaces
{
    public interface IContactRepository
    {
        Task<ResultData<Contact>> CreateContact(Contact contact);
    }
}
