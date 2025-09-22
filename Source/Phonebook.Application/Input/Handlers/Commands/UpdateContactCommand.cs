using MediatR;
using Phonebook.Domain.Entities;
using Phonebook.Domain.Results;

namespace Phonebook.Application.Input.Handlers.Commands
{
    public record UpdateContactCommand(
     string Id,
     string Name,
     string Phone,
     string Email,
     DateTime? DateOfBirth,
     IEnumerable<string> Addresses) : IRequest<ResultData<Contact>>;

}
