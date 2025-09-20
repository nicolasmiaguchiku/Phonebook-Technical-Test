using MediatR;
using Phonebook.Domain.Results;

namespace Phonebook.Application.Input.Handlers.Commands
{
    public record DeleteContactCommand(string Id) : IRequest<ResultData<bool>>;
}
