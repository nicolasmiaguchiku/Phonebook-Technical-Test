using Phonebook.Domain.Entities;
using Phonebook.Domain.Filters;
using Phonebook.Domain.Results;

namespace Phonebook.Domain.Interfaces
{
    public interface IContactRepository
    {
        Task<ResultData<Contact>> CreateContactAsync(Contact contact);
        Task<ResultData<IEnumerable<Contact>>> GetAllContactsAsync(ContactFiltersBuilder queryFilter, CancellationToken cancellationToken);
        Task<ResultData<Contact>> GetContactByIdAsync(ContactFiltersBuilder queryFilter, CancellationToken cancellationToken);
        Task<ResultData<bool>> DeleteContactAsync(string id);
        Task<ResultData<Contact>> UpdadeContactAsync(Contact contact);
    }
}
