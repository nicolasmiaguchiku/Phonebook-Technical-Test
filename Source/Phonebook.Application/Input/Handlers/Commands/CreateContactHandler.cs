using MediatR;
using Phonebook.Domain.Results;
using Phonebook.Domain.Entities;
using Phonebook.Domain.Interfaces;
using FluentValidation;

namespace Phonebook.Application.Input.Handlers.Commands
{
    public sealed class CreateContactHandler : IRequestHandler<CreateContactCommand, ResultData<Contact>>
    {
        private readonly IContactRepository _repository;
        private readonly IValidator<CreateContactCommand> _validator;

        public CreateContactHandler(IContactRepository Repository, IValidator<CreateContactCommand> Validator)
        {
            _repository = Repository;
            _validator = Validator;
        }

        public async Task<ResultData<Contact>> Handle(CreateContactCommand request, CancellationToken cancellationToken)
        {
           
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                var errors = string.Join("; ", validationResult.Errors.Select(e => e.ErrorMessage));
                return ResultData<Contact>.Failure(errors);
            }

            var contact = new Contact(request.Name, request.Phone, request.Email, request.DateOfBirth);
            contact.AddAddresses(request.Addresses);

            var result = await _repository.CreateContactAsync(contact);

            return result;
        }
    }
}
