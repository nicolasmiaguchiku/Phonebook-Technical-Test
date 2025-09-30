using MediatR;
using Phonebook.Application.Requests;
using Phonebook.Domain.Entities;
using Phonebook.Domain.Results;

namespace Phonebook.Application.Input.Handlers.Queries
{
   public record GetAllContactsQuery(ContactRequest ContactRequest) : IRequest<ResultData<IEnumerable<Contact>>>;
}
