using MediatR;
using Phonebook.Domain.Dtos.Requests;
using Phonebook.Domain.Dtos.Response;
using Phonebook.Domain.Results;

namespace Phonebook.Application.Input.Handlers.Commands
{
    public record UpdateContactCommand(UpdadeContactRequest ContactRequest) : IRequest<ResultData<ContactResponse>>;

}
