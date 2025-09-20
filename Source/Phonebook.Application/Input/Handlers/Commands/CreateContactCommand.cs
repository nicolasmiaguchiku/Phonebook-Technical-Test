using MediatR;
using Phonebook.Domain.Entities;
using Phonebook.Domain.Results;

namespace Phonebook.Application.Handlers.Commands
{
    public record  CreateContactCommand
        (
        string Name, 
        string Phone, 
        string Email, 
        DateTime? DateOfBirth, 
        IEnumerable<string> Addresses) : IRequest<ResultData<Contact>>;

}
