using MediatR;
using Phonebook.Domain.Dtos.Requests;
using Phonebook.Domain.Dtos.Response;
using Phonebook.Domain.Results;

namespace Phonebook.Application.Input.Handlers.Queries
{
   public record GetAllContactsQuery(GetContactRequest ContactRequest) : IRequest<ResultData<IEnumerable<ContactResponse>>>;
}
