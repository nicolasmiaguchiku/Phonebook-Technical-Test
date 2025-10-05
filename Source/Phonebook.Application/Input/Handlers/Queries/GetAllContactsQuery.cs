using MediatR;
using Phonebook.Domain.Dtos.Requests;
using Phonebook.Domain.Dtos.Response;
using Mattioli.Configurations.Models;

namespace Phonebook.Application.Input.Handlers.Queries;
public record GetAllContactsQuery(GetContactRequest ContactRequest) 
    : IRequest<Result<IEnumerable<ContactResponse>>>;
