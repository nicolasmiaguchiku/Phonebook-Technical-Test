using MediatR;
using Phonebook.Domain.Entities;
using Phonebook.Shared.Results;

namespace Phonebook.Application.Commands
{
    public record class CreateContactCommand() : IRequest<ResultData<Contact>>
    {
        public string Name { get; init; } = string.Empty;
        public string Phone { get; init; } = string.Empty;
        public string Email { get; init; } = string.Empty;
        public DateTime? DateOfBirth { get; init; }
        public IEnumerable<string> Addresses { get; init; } = new List<string>();
    }
}
