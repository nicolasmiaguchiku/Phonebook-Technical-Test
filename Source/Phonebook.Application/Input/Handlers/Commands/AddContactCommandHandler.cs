using MediatR;
using Phonebook.Domain.Dtos.Response;
using Phonebook.Domain.Interfaces;
using Mattioli.Configurations.Models;
using FluentValidation;

namespace Phonebook.Application.Input.Handlers.Commands
{
    public sealed class AddContactCommandHandler(IContactRepository Repository, IValidator<AddContactCommand> Validator)
        : IRequestHandler<AddContactCommand, Result<ContactResponse>>
    {
        public async Task<Result<ContactResponse>> Handle(AddContactCommand request, CancellationToken cancellationToken)
        {
            var validationContext = new ValidationContext<AddContactCommand>(request);
            var validationResult = await Validator.ValidateAsync(validationContext, cancellationToken);

            if (!validationResult.IsValid)
            {
                var errors = string.Join("; ", validationResult.Errors.Select(e => e.ErrorMessage));
                return Result<ContactResponse>.Failure(new Error("", errors));
            }

            var contact = request.AddContactRequest
                .ToBuilder()
                .SetName(request.AddContactRequest.Name)
                .SetPhone(request.AddContactRequest.Phone)
                .SetEmail(request.AddContactRequest.Email)
                .SetDateOfBirth(request.AddContactRequest.DateOfBirth)
                .SetAddresses(request.AddContactRequest.Addresses)
                .Build();

            return await Repository.AddContactAsync(contact, cancellationToken);
        }
    }
}
