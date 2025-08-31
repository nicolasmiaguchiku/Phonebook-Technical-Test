using MediatR;
using Phonebook.Domain.Entities;
using Phonebook.Shared.Results;

namespace Phonebook.Application.Queries.GetContactById
{
    public record GetContactByIdQuery(string id) : IRequest<ResultData<Contact>>;
}
