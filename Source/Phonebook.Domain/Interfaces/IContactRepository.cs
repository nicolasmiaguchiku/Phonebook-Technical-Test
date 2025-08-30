using Phonebook.Domain.Entities;
using Phonebook.Shared.Results;

namespace Phonebook.Domain.Interfaces
{
    public interface IContactRepository
    {
        Task<ResultData<Contact>> CreateContactAsync(Contact contact);
        Task<IEnumerable<Contact>> GetAllContactsAsync();
        Task<ResultData<Contact>> GetContactByIdAsync(string id);
        Task<ResultData<bool>> DeleteContactAsync(string id);
        //Task<ResultData<Contact>> UpdadeContactAsync(string id, Contact contact, string? novoEndereco = null);
    }
}
