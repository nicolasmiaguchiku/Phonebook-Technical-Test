using MediatR;
using Phonebook.Domain.Entities;
using Phonebook.Shared.Results;

namespace Phonebook.Application.Commands
{
    public record CreateContactCommand(
        string Nome,
        string Telefone,
        string Email,
        DateTime? DataNascimento,
        IEnumerable<string> Enderecos
    ) : IRequest<ResultData<Contact>>;
}
