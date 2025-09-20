using Phonebook.Domain.Entities;
using Phonebook.Domain.Results;

namespace Phonebook.Domain.Interfaces
{
    public interface IContactRepository
    {
        Task<ResultData<Contact>> CreateContactAsync(Contact contact);
        Task<ResultData<IEnumerable<Contact>>> GetAllContactsAsync();
        Task<ResultData<Contact>> GetContactByIdAsync(string id);
        Task<ResultData<bool>> DeleteContactAsync(string id);
        Task<ResultData<Contact>> UpdadeContactAsync(Contact contact);
    }
}
