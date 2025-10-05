using FluentValidation;
using Mattioli.Configurations.Models;
using MediatR;
using Phonebook.Application.Input.Handlers.Commands;
using Phonebook.Domain.Dtos.Requests;
using Phonebook.Domain.Dtos.Response;
using Phonebook.Domain.Entities;
using Phonebook.Domain.Filters;
using Phonebook.Domain.Interfaces;

public class UpdateContactCommandHandler(IContactRepository Repository, IValidator<UpdateContactCommand> Validator)
    : IRequestHandler<UpdateContactCommand, Result<ContactResponse>>
{
    public async Task<Result<ContactResponse>> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
    {
        var validateContext = new ValidationContext<UpdateContactCommand>(request);
        var validationResult = await Validator.ValidateAsync(validateContext, cancellationToken);

        if (!validationResult.IsValid)
        {
            var errors = string.Join("; ", validationResult.Errors.Select(e => e.ErrorMessage));
            return Result<ContactResponse>.Failure(new Error("", errors));
        }

        var filter = new ContactFiltersBuilder.Builder()
            .WithFileIds(request.ContactRequest.ContactId)
            .Build();

        var contactEntity = await Repository.GetContactByIdAsync(filter, cancellationToken);

        if (contactEntity.IsFailure)
        {
            return Result<ContactResponse>.Failure(contactEntity.Error);
        }
        else
        {
            var contactUpdate = new UpdadeContactRequest.Builder()
                .SetName(request.ContactRequest.Name)
                .SetPhone(request.ContactRequest.Phone)
                .SetDateOfBirth(request.ContactRequest.DateOfBirth)
                .SetEmail(request.ContactRequest.Email)
                .SetAddresses(request.ContactRequest.Addresses)
                .Build();

            return await Repository.UpdadeContactAsync(contactUpdate);
        }
    }
}
