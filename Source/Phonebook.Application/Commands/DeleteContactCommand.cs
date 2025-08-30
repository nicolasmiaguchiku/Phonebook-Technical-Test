using MediatR;
using Phonebook.Shared.Results;

namespace Phonebook.Application.Commands
{
    public record DeleteContactCommand(string Id) : IRequest<ResultData<bool>>;
}
