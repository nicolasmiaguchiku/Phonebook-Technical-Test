using Phonebook.Domain.Filters;
using Phonebook.Domain.Dtos.Requests;
using Phonebook.Domain.Dtos.Response;
using Mattioli.Configurations.Models;

namespace Phonebook.Domain.Interfaces
{
    public interface IContactRepository
    {
        Task<Result<ContactResponse>> AddContactAsync(AddContactRequest contactContactRequest, CancellationToken cancellationToken);
        Task<Result<IEnumerable<ContactResponse>>> GetAllContactsAsync(ContactFiltersBuilder queryFilter, CancellationToken cancellationToken);
        Task<Result<ContactResponse>> GetContactByIdAsync(ContactFiltersBuilder queryFilter, CancellationToken cancellationToken);
        Task<Result<bool>> DeleteContactAsync(ContactFiltersBuilder queryFilter, CancellationToken cancellationToken);
        Task<Result<ContactResponse>> UpdadeContactAsync(UpdadeContactRequest contact);
    }
}
