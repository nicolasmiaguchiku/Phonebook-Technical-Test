using MediatR;
using Phonebook.Domain.Entities ;
using Phonebook.Shared.Results;

namespace Phonebook.Application.Queries.GetAllContacts
{
   public record GetAllContactsQuery() : IRequest<ResultData<IEnumerable<Contact>>>;
    
}
