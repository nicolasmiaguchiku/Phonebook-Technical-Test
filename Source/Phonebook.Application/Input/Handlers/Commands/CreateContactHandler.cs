using MediatR;
using Phonebook.Domain.Dtos.Response;
using Phonebook.Domain.Interfaces;
using Mattioli.Configurations.Models;
using FluentValidation;

namespace Phonebook.Application.Input.Handlers.Commands
{
    public sealed class CreateContactHandler(IContactRepository Repository, IValidator<CreateContactCommand> Validator) 
        : IRequestHandler<CreateContactCommand, Result<ContactResponse>>
    {
        public async Task<Result<ContactResponse>> Handle(CreateContactCommand request, CancellationToken cancellationToken)
        {
            var validationContext = new ValidationContext<CreateContactCommand>(request);
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

            return await Repository.CreateContactAsync(contact);
        }
    }
}
