using MediatR;
using Phonebook.Domain.Entities ;

namespace Phonebook.Application.Queries.GetAllContacts
{
   public record GetAllContactsQuery() : IRequest<IEnumerable<Contact>>;
    
}
