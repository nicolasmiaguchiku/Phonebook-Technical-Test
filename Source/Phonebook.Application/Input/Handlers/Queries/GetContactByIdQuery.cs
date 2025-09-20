using MediatR;
using Phonebook.Domain.Entities;
using Phonebook.Domain.Results;

namespace Phonebook.Application.Handlers.Queries
{
    public record GetContactByIdQuery(string Id) : IRequest<ResultData<Contact>>;
}
