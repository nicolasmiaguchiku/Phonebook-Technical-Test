using MediatR;
using Phonebook.Domain.Entities;
using Phonebook.Shared.Results;

namespace Phonebook.Application.Commands
{
    public record  CreateContactCommand
        (
        string Name, 
        string Phone, 
        string Email, 
        DateTime? DateOfBirth, 
        IEnumerable<string> Addresses) : IRequest<ResultData<Contact>>;

}
