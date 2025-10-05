using Mattioli.Configurations.Models;
using MediatR;
using Phonebook.Domain.Filters;

namespace Phonebook.Application.Input.Handlers.Commands;
public record DeleteContactCommand(ContactFiltersBuilder queryFilter) : IRequest<Result<bool>>;
