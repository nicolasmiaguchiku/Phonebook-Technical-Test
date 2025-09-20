using MediatR;
using Phonebook.Domain.Entities;
using Phonebook.Domain.Results;


namespace Phonebook.Application.Handlers.Queries
{
   public record GetAllContactsQuery() : IRequest<ResultData<IEnumerable<Contact>>>;
    
}
