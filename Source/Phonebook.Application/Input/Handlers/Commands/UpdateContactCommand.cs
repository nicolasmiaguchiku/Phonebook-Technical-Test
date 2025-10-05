using MediatR;
using Phonebook.Domain.Dtos.Requests;
using Phonebook.Domain.Dtos.Response;
using Mattioli.Configurations.Models;

namespace Phonebook.Application.Input.Handlers.Commands;
public record UpdateContactCommand(UpdadeContactRequest ContactRequest) : IRequest<Result<ContactResponse>>;

