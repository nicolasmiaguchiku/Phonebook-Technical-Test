using Phonebook.Domain.Entities;
using Phonebook.Domain.Filters;
using Phonebook.Domain.Results;
using Phonebook.Domain.Dtos.Requests;
using Phonebook.Domain.Dtos.Response;

namespace Phonebook.Domain.Interfaces
{
    public interface IContactRepository
    {
        Task<ResultData<ContactResponse>> CreateContactAsync(AddContactRequest contactContactRequest);
        Task<ResultData<IEnumerable<ContactResponse>>> GetAllContactsAsync(ContactFiltersBuilder queryFilter, CancellationToken cancellationToken);
        Task<ResultData<ContactResponse>> GetContactByIdAsync(ContactFiltersBuilder queryFilter, CancellationToken cancellationToken);
        Task<ResultData<bool>> DeleteContactAsync(string id);
        Task<ResultData<ContactResponse>> UpdadeContactAsync(UpdadeContactRequest contact);
    }
}
